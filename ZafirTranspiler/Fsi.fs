module CIPHERPrototype.Fsi

open Microsoft.FSharp.Collections;
open Microsoft.FSharp.Compiler;
open Microsoft.FSharp.Compiler.Interactive;
open Microsoft.FSharp.Control;
open Microsoft.FSharp.Core;
open Microsoft.FSharp.Core.CompilerServices;
open Rop;
open System;
open System.Collections;
open System.Collections.Generic;
open System.Diagnostics;
open System.IO;
open System.Runtime.CompilerServices;
open System.Runtime.InteropServices;
open System.Text;
open System.Text.RegularExpressions;
open System.Threading;
open Microsoft.FSharp.Compiler.Interactive.Shell

type TranspilerError =
    | MustProvideAssemblyOutputPath
    | MustProvideProjectPath
    | WarningFSharp                 of string
    | ErrFSharp                     of string
    | ErrWebSharper                 of string
    | NothingToTranslateToJavaScript
    | OutputAssemblyNotFound        of string
with interface ErrMsg with
        member this.ErrMsg =
            if this = NothingToTranslateToJavaScript then "WebSharper found nothing that required translation to JavaScript. Possibly a [< JavaScript >] attribute is missing." else
            sprintf "%A"this
        member this.IsWarning = match this with | WarningFSharp _ -> true | _ -> false
        
type ResourceAgent<'T>(restartAfter:int, ctor: unit->'T, ?cleanup) =
    let mutable resource = ctor()
    let agent    = 
        MailboxProcessor.Start(fun inbox ->
            async {
               while true do
                 try
                     for i in 1 .. restartAfter do
                         let! work = inbox.Receive()
                         do!  work resource
                 finally
                     cleanup |> Option.iter (fun clean -> clean resource) 
                     resource <- ctor()
            }
        )
    member x.Process work =
        agent.PostAndAsyncReply(
            fun reply checker ->
              async {
                   let! res = work checker
                   reply.Reply res
              }
            )

let (|InterpretedMatch|_|) pattern input =
    if input = null then None else
    let m = Regex.Match(input, pattern)
    if not m.Success then None else
    Some [for x in m.Groups -> x]

///Match the pattern using a cached compiled Regex
let (|CompiledMatch|_|) pattern input =
    if input = null  then None else
    let m = Regex.Match(input, pattern, RegexOptions.Compiled)
    if not m.Success then None else
    Some [for x in m.Groups -> x]


let getIndentFile input =
    match input with
    | CompiledMatch "^\\((\\d+)\\)\\s(.*)$" [_ ; indent ; file] -> int indent.Value, file.Value
    | _                                                         -> 0               , input

let  fSharpError2TranspilerError (error : FSharpErrorInfo) =
    let indent, file = System.IO.Path.GetFileNameWithoutExtension error.FileName |> getIndentFile  
    sprintf "%s (%d,%d) - (%d,%d) %s %d: %s" 
       file 
       error.StartLineAlternate (error.StartColumn - indent) 
       error.EndLineAlternate   (error.EndColumn   - indent) 
       error.Subcategory error.ErrorNumber error.Message
    |> (if   error.Severity = FSharpErrorSeverity.Error  
        then ErrFSharp     
        else WarningFSharp
       )
    :> ErrMsg

let startSession() : FsiEvaluationSession =
    FsiEvaluationSession.Create(FsiEvaluationSession.GetDefaultConfiguration(), 
       [| "/temp/fsi.exe" ; "--noninteractive" |]
      , new StringReader(""), new StringWriter(new StringBuilder()), new StringWriter(new StringBuilder()), true)


let fsharpInteractive = lazy ResourceAgent(20, (fun () -> startSession()), fun fsi -> (fsi :> IDisposable).Dispose())

let processFSI (code:string) (assemblies: string seq) : Wrap.Wrapper<string> =
    Wrap.wrapper {
        let! choice, errors = fsharpInteractive.Value.Process(fun fsi -> 
            async {
              return
                Seq.map (fun assem -> sprintf "#r @\"%s\"" assem) assemblies
                |> Seq.append    <| [ code ]
                |> String.concat "\n" 
                |> fsi.EvalInteractionNonThrowing
            }
        )
        let  msgs = errors |> Seq.map fSharpError2TranspilerError |> Seq.toList
        let! res =
             match choice with
             | Choice1Of2 _ -> Result.succeedWithMsgs "()"  msgs 
             | Choice2Of2 e -> Result.failWithMsgs         (msgs |> Seq.append <| [ ExceptionThrown e ] |> Seq.toList)
        return res
    }
