module CIPHERPrototype.Fsi

open FsiExe
open Rop;
open System;
open System.IO;
open System.Text;
open Microsoft.FSharp.Core;
open Microsoft.FSharp.Control;
open Microsoft.FSharp.Collections;
open Microsoft.FSharp.Compiler;
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
        
let fSharpError2TranspilerError (error : FSharpErrorInfo) =
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


let fsharpInteractive = lazy ResourceAgent<_, unit>(20, (fun _ -> startSession()), fun fsi -> (fsi :> IDisposable).Dispose())

let processFSI (code:string) (assemblies: string seq) (definesNotUSINGIT: string seq) : Wrap.Wrapper<string> =
    Wrap.wrapper {
        let! evalR = fsharpInteractive.Value.Process(fun fsi -> 
            Wrap.wrapper {
              return
                Seq.map (fun assem -> sprintf "#r @\"%s\"" assem) assemblies
                |> Seq.append    <| [ code ]
                |> String.concat "\n" 
                |> fsi.EvalInteractionNonThrowing
            }
        )
        let! choice, errors = evalR
        let  msgs = errors |> Seq.map fSharpError2TranspilerError |> Seq.toList
        let! res =
             match choice with
             | Choice1Of2 _ -> Result.succeedWithMsgs "()"  msgs 
             | Choice2Of2 e -> Result.failWithMsgs         (msgs |> Seq.append <| [ ExceptionThrown e ] |> Seq.toList)
        return res
    }
