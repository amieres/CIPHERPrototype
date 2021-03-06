﻿module CIPHERPrototype.FsiExe

open Rop
open System.Text.RegularExpressions;
open System.Text
open System.Diagnostics

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

type ShellExError =
    | ShellFailWithMessage       of string
    | ShellFinishedWithNoMessage 
    | ShellCrashed               of string
with interface ErrMsg with
        member this.ErrMsg    = 
            match this with 
            | ShellFailWithMessage msg   -> msg  
            | ShellFinishedWithNoMessage -> "warning - No output"
            | ShellCrashed         msg   -> "Crashed " + msg
            | msg                        -> sprintf "%A" msg
        member this.IsWarning =
            match this with 
            | ShellFinishedWithNoMessage -> true
            | _                          -> false 


type ShellEx(startInfo: ProcessStartInfo) =
    let proc                              = new Process()
    let bufferOutput                      = new StringBuilder()
    let bufferError                       = new StringBuilder()
    let consume (sb: StringBuilder)       = 
        let v = sb.ToString()
        sb.Clear() |> ignore
        v
    do  startInfo.RedirectStandardInput  <- true
        startInfo.RedirectStandardOutput <- true
        startInfo.RedirectStandardError  <- true
        startInfo.UseShellExecute        <- false
        proc.StartInfo                   <- startInfo
        proc.EnableRaisingEvents         <- true
        proc.OutputDataReceived.AddHandler(DataReceivedEventHandler(fun sender args -> try bufferOutput.Append(args.Data + "\n") |> ignore with _ -> () ))
        proc.ErrorDataReceived .AddHandler(DataReceivedEventHandler(fun sender args -> try bufferError .Append(args.Data + "\n") |> ignore with _ -> () ))
        proc.Exited            .AddHandler(System.EventHandler     (fun sender args -> try proc.Close()                                    with _ -> () ))
    new (program, args) =             
        let startInfo                         = new ProcessStartInfo()
        do  startInfo.FileName               <- program
            startInfo.Arguments              <- args
        new ShellEx(startInfo)
    member this.Start() = 
        let r = proc.Start() 
        proc.BeginOutputReadLine()
        proc.BeginErrorReadLine ()
        r
    member this.Send(txt: string)   = proc.StandardInput.WriteLine txt
    member this.Output  ()          = consume bufferOutput
    member this.Error   ()          = consume bufferError
    member this.Response(out:string, err:string)  = 
        match out.Trim(), err.Trim() with
//        | ""  , ""  -> None
        | good, ""  -> Some( Result.succeed        good                             )
        | ""  , bad -> Some( Result.fail                <| ShellFailWithMessage bad )
        | good, bad -> Some( Result.succeedWithMsg good <| ShellFailWithMessage bad )
    member this.Response()          = this.Response(this.Output(), this.Error())
    member this.SendAndWait(send, wait, ?onError) =
        let eventWait = 
            if defaultArg onError false then proc.ErrorDataReceived else proc.OutputDataReceived
            |> Event.choose (fun evArgs -> try evArgs.Data |> (fun v -> if v.Contains wait then Some <| Result.succeed v else None) with _ -> None)
        let eventAll = Event.merge eventWait  (Event.map (fun _ -> Result.fail <| ShellCrashed startInfo.FileName) proc.Exited)
        Wrap.wrapper {
            do! Result.tryProtection()
            async { 
                do!    Async.Sleep 20 
                this.Send send        } |> Async.Start
            let!   waitedR = Async.AwaitEvent eventAll
            let!   waited  = waitedR
            do!    Async.Sleep 200
            let!   res =
                   if defaultArg onError false then 
                       this.Response(this.Output(), this.Error() |> fun msg -> msg.Split([| waited |], System.StringSplitOptions.None) |> Array.head)
                   else this.Response()
                   |> Option.defaultWith (fun () -> Result.succeedWithMsg "" ShellFinishedWithNoMessage)
            return res
        }
    member this.HasExited = try proc.HasExited with _ -> true
    interface System.IDisposable with
        member this.Dispose () =
            try proc.Kill   () with _ -> ()
            try proc.Close  () with _ -> ()
            try proc.Dispose() with _ -> ()

type FsiExe(config) =
    let startInfo                 = ProcessStartInfo(@"fsiAnyCPU.exe", config |> String.concat " ")             
    let shell                     = new ShellEx(startInfo)  // --noninteractive
    let endToken                  = "xXxY" + "yYyhH"
    do  startInfo.CreateNoWindow <- false
        shell.Start() |> ignore
    member this.Eval txt =
        Wrap.wrapper {
            do! Result.tryProtection()
            shell.Send txt 
            shell.Send ";;"
            let! res = shell.SendAndWait(endToken + ";;", endToken, true)
            return res
        }
    member this.IsAlive = not shell.HasExited
    interface System.IDisposable with
        member this.Dispose () = 
            (shell :> System.IDisposable).Dispose()

type ResourceAgent<'T, 'C when 'C : equality>(restartAfter:int, ctor: 'C option ->'T, ?cleanup, ?isAlive, ?configuration: 'C) =
    let mutable configuration = configuration
    let mutable resource = ctor configuration
    let respawn() =
        cleanup |> Option.iter (fun clean -> clean resource) 
        resource <- ctor configuration
    let agent    = 
        MailboxProcessor.Start(fun inbox ->
            async {
               while true do
                 try
                     for i in 1 .. restartAfter do
                         let! config, work = inbox.Receive()
                         isAlive |> Option.iter (fun alive -> if not (alive resource) then respawn())
                         if config <> configuration then
                            configuration <- config
                            respawn()
                         do!  work resource
                     respawn()
                 with _ -> respawn() 
            }
        )
    do agent.Error.AddHandler <| Handler (fun _ _ -> respawn())
    member x.Process (work:'T -> Wrap<'a>, ?config) =
        agent.PostAndAsyncReply
            (fun reply ->
                 (config, fun resource ->
                          async {
                               let! res = work resource |> Wrap.getAsyncR
                               reply.Reply res
                          } 
                 )
            )

let getIndentFile input =
    match input with
    | CompiledMatch "^\\((\\d+)\\)\\s(.*)$" [_ ; indent ; file] -> int indent.Value, file.Value
    | _                                                         -> 0               , input

let fsiExe = lazy ResourceAgent<_, string> (20, (fun config -> new FsiExe(["--nologo" ; "--quiet" ; defaultArg config ""] )), (fun fsi -> (fsi :> System.IDisposable).Dispose()), (fun fsi -> fsi.IsAlive), "")

type PreproDirective =
| PrepoR      of string
| PrepoDefine of string
| PrepoLoad   of string
| PrepoLine   of string //* int
| PrepoNoWarn of string
| PrepoI      of string
| PrepoIf     of string
| PrepoElse   
| PrepoEndIf
| PrepoLight  of bool
| PrepoOther  of string
| NoPrepo

let prepareCode (code:string) =
    let  quoted (line:string) = line.Trim().Split([| "\""       |], System.StringSplitOptions.RemoveEmptyEntries) |> Seq.tryLast |> Option.defaultValue line
    let  define (line:string) = line.Trim().Split([| "#define " |], System.StringSplitOptions.RemoveEmptyEntries) |> Seq.tryHead |> Option.defaultValue ""
    let  comment = ((+)"//") 
    let  prepro (line:string) = match true with 
                                | true when line.StartsWith("#define") -> (comment line, line |> define |> PrepoDefine)
                                | true when line.StartsWith("#r"     ) -> (comment line, line |> quoted |> PrepoR     )
                                | true when line.StartsWith("#load"  ) -> (comment line, line |> quoted |> PrepoLoad  )
                                | true when line.StartsWith("#nowarn") -> (        line, line |> quoted |> PrepoNoWarn)
                                | true when line.StartsWith("# "     ) -> (        line, line |> quoted |> PrepoLine  )
                                | true when line.StartsWith("#line"  ) -> (        line, line |> quoted |> PrepoLine  )
                                | true when line.StartsWith("#I"     ) -> (comment line, line |> quoted |> PrepoI     )
                                | true when line.StartsWith("#if"    ) -> (        line, line           |> PrepoIf    )
                                | true when line.StartsWith("#else"  ) -> (        line,                   PrepoElse  )
                                | true when line.StartsWith("#endif" ) -> (        line,                   PrepoEndIf )
                                | true when line.StartsWith("#light" ) -> (        line, false          |> PrepoLight )
                                | true when line.StartsWith("#"      ) -> (comment line, line           |> PrepoOther )
                                | _                                    -> (        line,                   NoPrepo    ) 
    let  fsNass   = code.Split([| "\r\n"; "\n" ; "\r" |], System.StringSplitOptions.None) |> Seq.map prepro
    let  assembs  = fsNass |> Seq.choose (snd >> (function | PrepoR assemb -> Some assemb | _ -> None)) |> Seq.toArray
    let  prepoIs  = fsNass |> Seq.choose (snd >> (function | PrepoI      d -> Some d      | _ -> None)) |> Seq.toArray
    let  code     = fsNass |> Seq.map     fst |> String.concat "\r\n"
    code, assembs, prepoIs

let extractConfig (code:string) =
    let n = code.IndexOf("\n")
    if n > 5 && code.StartsWith "////-d:" then code.Substring(4, n - 4) else ""

let evalFsiExe (code:string) =
    Wrap.wrapper {
        let config = extractConfig code
        let! resR = fsiExe.Value.Process(fun fsi -> 
            Wrap.wrapper {
              do! Result.tryProtection()
              let! res = fsi.Eval code
//                Seq.map (fun assem -> sprintf "#r @\"%s\"" assem) assemblies
//                |> Seq.append    <| [ code ]
//                |> String.concat "\n" 
//                |> fsi.Eval
              return res
            }
        , config)
        let! res = resR
        return res
    }