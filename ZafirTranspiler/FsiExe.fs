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
    | ShellFailWithMessage of string
with interface ErrMsg with
        member this.ErrMsg    = match this with ShellFailWithMessage msg -> msg
        member this.IsWarning = false


type ShellEx(program, args)               =
    let startInfo                         = new ProcessStartInfo()
    let proc                              = new Process()
    let bufferOutput                      = new StringBuilder()
    let bufferError                       = new StringBuilder()
    let consume (sb: StringBuilder)       = 
        let v = sb.ToString()
        sb.Clear() |> ignore
        v
    do  startInfo.FileName               <- program
        startInfo.Arguments              <- args
        startInfo.UseShellExecute        <- false
        startInfo.RedirectStandardInput  <- true
        startInfo.RedirectStandardOutput <- true
        startInfo.RedirectStandardError  <- true
        proc.StartInfo                   <- startInfo
        proc.EnableRaisingEvents         <- true
        proc.OutputDataReceived.AddHandler(DataReceivedEventHandler(fun sender args -> bufferOutput.Append(args.Data + "\n") |> ignore))
        proc.ErrorDataReceived .AddHandler(DataReceivedEventHandler(fun sender args -> bufferError .Append(args.Data + "\n") |> ignore))
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
        | ""  , ""  -> None
        | good, ""  -> Some( Result.succeed        good                             )
        | ""  , bad -> Some( Result.fail                <| ShellFailWithMessage bad )
        | good, bad -> Some( Result.succeedWithMsg good <| ShellFailWithMessage bad )
    member this.Response()          = this.Response(this.Output(), this.Error())
    member this.CheckForResult(res) = proc.OutputDataReceived |> Event.filter (fun evArgs -> evArgs.Data.Contains res)
    member this.CheckForError (res) = proc.ErrorDataReceived  |> Event.filter (fun evArgs -> evArgs.Data.Contains res)
    member this.SendAndWait(send, wait, ?onError) =
        Wrap.wrapper {
            do! Result.tryProtection()
            this.Send send
            let!   evArgs = Async.AwaitEvent <| (if defaultArg onError false then this.CheckForError else this.CheckForResult) wait            
            do!    Async.Sleep 200
            let!   res1 =
                   if defaultArg onError false then 
                       this.Response(this.Output(), this.Error() |> fun msg -> msg.Split([| evArgs.Data |], System.StringSplitOptions.None) |> Array.head)
                   else this.Response()
            let!   res2 = res1
            return res2
        }
    member this.Exit() =
        proc.CloseMainWindow() |> ignore
        if not proc.HasExited then
            proc.WaitForExit()
        (proc.ExitCode, this.Output, this.Error)
    interface System.IDisposable with
        member this.Dispose () = 
            proc.Dispose()

type FsiExe() =
    let shell    = new ShellEx(@"C:\Program Files (x86)\Microsoft SDKs\F#\4.1\Framework\v4.0\fsiAnyCPU.exe", "--nologo --quiet")  // --noninteractive
    let endToken = "xXxY" + "yYyhH"
    do shell.Start() |> ignore
    member this.Eval txt =
        Wrap.wrapper {
            do! Result.tryProtection()
            shell.Send <| txt + ";;"
            let! res = shell.SendAndWait(endToken + ";;", endToken, true)
            return res
        }
    interface System.IDisposable with
        member this.Dispose () = 
            (shell :> System.IDisposable).Dispose()

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

let getIndentFile input =
    match input with
    | CompiledMatch "^\\((\\d+)\\)\\s(.*)$" [_ ; indent ; file] -> int indent.Value, file.Value
    | _                                                         -> 0               , input

let fsiExe = lazy ResourceAgent(20, (fun () -> new FsiExe()), fun fsi -> (fsi :> System.IDisposable).Dispose())

let processFsiExe (code:string) (assemblies: string seq) : Wrap.Wrapper<string> =
    Wrap.wrapper {
        let! res1 = fsiExe.Value.Process(fun fsi -> 
            Wrap.wrapper {
              do! Result.tryProtection()
              let! res =
                Seq.map (fun assem -> sprintf "#r @\"%s\"" assem) assemblies
                |> Seq.append    <| [ code ]
                |> String.concat "\n" 
                |> fsi.Eval
              return res
            } |> Wrap.getAsyncR
        )
        let!   res2 = res1
        return res2
    }