////-d:WEBSHARPER
#r @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.1\System.Web.dll"
#r @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.1\System.Core.dll"
#r @"WebSharper.Core.dll"
#r @"WebSharper.Collections.dll"
#r @"WebSharper.Main.dll"
#r @"WebSharper.UI.Next.dll"
#r @"WebSharper.JavaScript.dll"
#r @"WebSharper.Web.dll"
#r @"WebSharper.Sitelets.dll"
#r @"remote.dll"
#r @"FSharp.Compiler.Service.dll"
//# 1 "required for nowarns to work"
#nowarn "1182"
#nowarn "40"
#nowarn "1178"
//# 1 @"bf864f3c-1370-42f2-ac8a-565a604892e8 FSSGlobal.fsx"
//#nowarn "1182"
//#nowarn "40"
//#r @"D:\Abe\CIPHERWorkspace\CIPHERPrototype\WebServer\bin\FSharp.Core.dll"
//#if INTERACTIVE
#I @"../WebServer/bin"
module FSSGlobal   =
//#endif

  //# 1 @"(2)edbbf11e-4698-4e33-af0c-135d5b21799b F# Code.fsx"
  // Code to be evaluated using FSI: `Evaluate F#`
    //# 1 @"(4)60bffe71-edde-4971-8327-70b9f5c578bb open WebSharper.fsx"
//    //#if WEBSHARPER
    //#r @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.1\System.Web.dll"
    //#r @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.1\System.Core.dll"
    
    //#r @"WebSharper.Core.dll"
    //#r @"WebSharper.Collections.dll"
    //#r @"WebSharper.Main.dll"
    //#r @"WebSharper.UI.Next.dll"
    //#r @"WebSharper.JavaScript.dll"
    //#r @"WebSharper.Web.dll"
    //#r @"WebSharper.UI.Next.dll"
    //#r @"WebSharper.Sitelets.dll"
    
    open WebSharper
    open WebSharper.JavaScript
    open WebSharper.UI.Next
    open WebSharper.UI.Next.Client
    type on   = WebSharper.UI.Next.Html.on
    type attr = WebSharper.UI.Next.Html.attr
    //#endif
    //# 1 @"(4)7c4a82bc-58cd-48a7-bd7e-79de148a1cf0 Useful.fsx"
    [<WebSharper.JavaScript>]
    module Useful =
      //# 1 @"(6)368caae7-6a67-4063-9af3-978c25b81ac2 Result, Wrap.fsx"
      open System
      //#nowarn "1178"
      //#if WEBSHARPER
      [<JavaScript>]
      ////#endif
      module Option =
          let defaultValue v =
              function
              | Some x -> x
              | None   -> v
      
          let defaultWith f =
              function
              | Some x -> x
              | None   -> f()
      
          let call v = 
              function
              | None   -> None
              | Some f -> f v |> Some
      
          let iterF v = 
              function
              | None   -> ()
              | Some f -> f v
      
          let iterFO vO fO = 
              match vO, fO with
              | Some v, Some f -> f v
              | _     , _      -> ()
      
          let apply vO fO =
              match vO, fO with
              | Some v, Some f -> f v |> Some
              | _     , _      -> None
      
          let modify modifier = Option.map (fun f -> modifier f) >> defaultValue id
            
      
      //#nowarn "25"
      type ErrMsg = 
          abstract member ErrMsg   : string
          abstract member IsWarning: bool
      
      //#if WEBSHARPER
      [<JavaScript>]
      //#endif
      type ExceptionThrown(exn:Exception) =
          interface ErrMsg with
              member this.ErrMsg   : string = sprintf "%A" exn
              member this.IsWarning: bool   = false
      
      //#if WEBSHARPER
      [<JavaScript>]
      //#endif
      type ErrOptionIsNone() =
          interface ErrMsg with
              member this.ErrMsg   : string = "Option is None"
              member this.IsWarning: bool   = false
      
      //#if WEBSHARPER
      [<JavaScript>]
      //#endif
      type Result<'TSuccess> = Result of 'TSuccess option * ErrMsg list     
      
      //#if WEBSHARPER
      [<JavaScript>]
      //#endif
      module Result =
          let inline succeed             x       = Result (Some x           , [  ]             )
          let inline succeedWithMsg      x  m    = Result (Some x           , [m ]             )
          let inline succeedWithMsgs     x  ms   = Result (Some x           ,  ms              )
          let inline fail                   m    = Result (None             , [m ]             )
          let inline failWithMsgs           ms   = Result (None             ,  ms              )
          let inline map       f (Result(o, ms)) = Result (o |> Option.map f,  ms              )
          let inline mapMsg    f (Result(o, ms)) =        (o                ,  ms |> List.map f)
          let inline mapMsgs   f (Result(o, ms)) =        (o                ,  ms |>          f)
          let inline getOption   (Result(o, _ )) =         o                   
          let inline getMsgs     (Result(_, ms)) =                             ms
          let inline mergeMsgs              ms r = Result (r |> mapMsgs   ((@) ms) )
          let inline combine     (Result(_, ms)) = mergeMsgs ms
          let inline bind      f (Result(o, ms)) = 
              match o with
              | Some x   -> match f x with Result(o2, ms2) -> Result(o2, ms @ ms2)
              | None     -> Result(None, ms)
          let inline apply (Result(fO, fMs))  (Result(o , ms)) = 
              match fO, o with
              | Some f, Some x -> Result(f x |> Some, fMs @ ms)
              | _              -> Result(None       , fMs @ ms)
      
      
          let (|Success|Failure|) =
              function 
              | Result(Some x, ms) -> Success (x, ms) 
              | Result(None  , ms) -> Failure     ms  
      
          let x = function
                    | Success (x, ms) -> "yes"
                    | Failure     ms  -> "No"
      
      //    let successTee f result =                           // given an RopResult, call a unit function on the success branch
      //        let fSuccess (x,msgs) =                         // and pass thru the result
      //            f (x,msgs)
      //            Success (x,msgs) 
      //        either fSuccess Failure result
      //
      //    let fFailure2 f errs = 
      //        f errs
      //        Failure errs 
      //    let failureTee f result =                           /// given an RopResult, call a unit function on the failure branch
      //        either Success (fFailure2 f) result
      //
      //    let mapMessagesR f result =                         /// given an RopResult, map the messages to a different error type
      //        match result with 
      //        | Success (x,msgs) -> 
      //            let msgs' = List.map f msgs
      //            Success (x, msgs')
      //        | Failure errors -> 
      //            let errors' = List.map f errors 
      //            Failure errors' 
      //
      //    let valueOrDefault f result =                       /// given an RopResult, in the success case, return the value.
      //        match result with                               /// In the failure case, determine the value to return by 
      //        | Success (x,_) -> x                            /// applying a function to the errors in the failure case
      //        | Failure errors -> f errors
      //
      //    let failIfNone message = function                   /// lift an option to a RopResult.
      //        | Some x -> succeed x                           /// Return Success if Some
      //        | None -> fail message                          /// or the given message if None
      //
      //    let failIfNoneR message = function                  /// given an RopResult option, return it
      //        | Some rop -> rop                               /// or the given message if None
      //        | None -> fail message 
      
          let failException e = ExceptionThrown(e) :> ErrMsg
      
      ///            tryCall: (exn -> Result<'b>) ->  ('a -> Result<'b>) -> 'a -> Result<'b> =
          let inline tryCall (f:'a -> Result<'b>) (v:'a) : Result<'b> = try f v with e -> failException e |> fail
      
          type ropBuilder() =
              member inline this.Return     (x)                       = succeed x
              member inline this.ReturnFrom (x)                       = x
              member        this.Bind       (w:Result<'a>, r: 'a -> Result<'b>) = bind (tryCall r) w
              member inline this.Using      (disposable, restOfCExpr) = using disposable restOfCExpr
              member inline this.Zero       ()                        = succeed ()
              member inline this.Delay      (f)                       = f()
              member inline this.Combine    (a, b)                    = combine a b
      //        member this.Run        (f)                       = f
      //        member this.While(guard, body) =
      //            if not (guard()) 
      //            then this.Zero() 
      //            else this.Bind( body(), fun () -> 
      //                this.While(guard, body))  
      //        member this.For(sequence:seq<_>, body) =
      //            this.Using(sequence.GetEnumerator(),fun enum -> 
      //                this.While(enum.MoveNext, 
      //                    this.Delay(fun () -> body enum.Current)))
      
          let result = ropBuilder()
      //    let inline flow_ () = new ropBuilder ()
      
          let fromChoice context c =
              match c with | Choice1Of2 v -> succeed v
                           | Choice2Of2 e -> fail    e
      
          let fromOption m =
              function | None   -> fail    m
                       | Some v -> succeed v
      
          let toOption (Result(o, _)) = o
      
          let tryProtection() : Result<unit> = succeed ()
      
          let failIfFalse m v : Result<unit>  = if v then succeed () else m |> fail 
          let failIfTrue  m v : Result<unit>  = if v then m |> fail  else succeed () 
                  
          let ifError   def (Result(o, _ )) = o |> Option.defaultValue            def
          let withError f   (Result(o, ms)) = o |> Option.defaultWith  (fun () -> f ms)
      
      //    let processMessages mtype (msgs: PossibleMessages list) =
      //        msgs
      //        |> List.iter (fun o -> WebSharper.JavaScript.JS.Alert     <| mtype + ": " + (sprintf "%A" o)
      //                               WebSharper.JavaScript.Console.Log o)
      //
      //    let notifyMessages R =
      //        match R with | Success (_, m) -> processMessages "N" m
      //                     | Failure     m  -> processMessages "E" m
      //
      //    let messagesDo f =
      //        function | Success (_, ms) -> f false ms
      //                 | Failure     ms  -> f true  ms
      
          let seqCheck s = 
              s 
              |> (fun elems -> match      elems |> Seq.exists(function | Failure _    -> true    | _ -> false) with
                               | true  -> elems |> Seq.pick  (function | Failure ms   -> Some ms | _ -> None ) |> failWithMsgs
                               | false -> elems |> Seq.map   (function | Result (vO,_)-> vO.Value            ) |> succeed
              )
      
          let getMessages (ms: ErrMsg list) =
              if ms = [] then "" else
              let errors   = ms |> List.filter(fun m -> m.IsWarning |> not)
              let warnings = ms |> List.filter(fun m -> m.IsWarning       )
              if errors.Length = 0 
              then sprintf "%s"
              else sprintf "%d errors\n%s" errors.Length
              <| (ms |> List.map (fun m -> m.ErrMsg) |> String.concat "\n")
       
      open Result
      
      type Wrap<'T> =
      | WResult of Result<'T>
      | WAsync  of Async<'T>
      | WAsyncR of Async<Result<'T>>
      | WSimple of 'T
      | WOption of 'T option
      
      //#if WEBSHARPER
      [<JavaScript>]
      //#endif
      module Wrap =
          let errOptionIsNone = ErrOptionIsNone() :> ErrMsg
      
          let wb2arb ms = 
              function
              | WAsync       ab  -> async { let!   b = ab
                                            return succeedWithMsgs b                   ms }
              | WAsyncR     arb  -> async { let!   rb = arb                               
                                            return rb |> mergeMsgs                     ms }
              | WResult      rb  -> async { return rb |> mergeMsgs                     ms }
              | WSimple       b                                                           
              | WOption (Some b) -> async { return succeedWithMsgs b                   ms }
              | WOption None     -> async { return failWithMsgs      (errOptionIsNone::ms)}
      
          let tryCall (f: 'a -> Wrap<'b>) (a:'a) = 
              try f a 
              with e -> failException e |> fail |> WResult
      
          let bind (f: 'a -> Wrap<'b>) (wa: Wrap<'a>) :Wrap<'b> =
              match wa with
              | WSimple         a       
              | WOption(Some    a)       
              | WResult(Success(a, [])) -> tryCall f a
              | WOption None            -> None            |> WOption
              | WResult(Failure    ms ) -> failWithMsgs ms |> WResult 
              | WResult(Success(a, ms)) -> tryCall f a
                                           |> function
                                           | WSimple         b              
                                           | WOption(Some    b     ) -> succeedWithMsgs b  ms             |> WResult 
                                           | WOption None            -> failWithMsgs (errOptionIsNone::ms)|> WResult
                                           | WResult(Success(b, [])) -> succeedWithMsgs b  ms             |> WResult 
                                           | WResult(Success(b, m2)) -> succeedWithMsgs b (ms @ m2)       |> WResult 
                                           | WResult(Failure    m2)  -> failWithMsgs      (ms @ m2)       |> WResult 
                                           | WAsync  ab              -> async { let!  b = ab
                                                                                return succeedWithMsgs b ms
                                                                        } |> WAsyncR
                                           | WAsyncR arb             -> async { let! rb = arb
                                                                                return mergeMsgs ms rb
                                                                        } |> WAsyncR
              | WAsync         aa       -> async {
                                               let! a  = aa
                                               return! tryCall f a |> wb2arb []
                                           } |> WAsyncR
              | WAsyncR       ara       -> async {
                                               let! ar  = ara
                                               let  arb = match ar with
                                                          | Success(a, ms) -> tryCall f a |> wb2arb ms
                                                          | Failure    ms  -> async { return failWithMsgs ms }
                                               return! arb
                                           } |> WAsyncR
          let Return = WSimple 
          let map  (f: 'a -> 'b  ) = bind (f >> Return)     
      
          let wrapper2Async (f: 'a -> Wrap<'b>) a : Async<Result<'b>> =
              let wb = tryCall f a
              match wb with
              | WSimple _
              | WOption _               -> wb |> wb2arb []
              | WResult (Result(_, ms)) -> wb |> wb2arb ms
              | WAsync  ab              -> async { let!   b = ab
                                                   return succeed b }
              | WAsyncR arb              -> arb
      
          let addMsgs errOptionIsNone ms wb =
              if ms = [] then wb else
              match wb with
              | WSimple          v       
              | WOption (Some    v)      -> WResult (succeedWithMsgs                        v ms)
              | WOption (None     )      -> WResult (fail errOptionIsNone |> Result.mergeMsgs ms)
              | WResult r                -> WResult (r                    |> Result.mergeMsgs ms)
              | WAsync           va      -> async {
                                              let! v = va
                                              return succeedWithMsgs v ms
                                            } |> WAsyncR
              | WAsyncR          vra     -> async {
                                              let! vr = vra
                                              return vr                    |> Result.mergeMsgs ms
                                            } |> WAsyncR
      
          let combine errOptionIsNone wa wb =
              match wa with
              | WSimple          _
              | WOption (Some    _)
              | WResult (Result (_, []))
              | WAsync           _       -> wb
              | WAsyncR          _       -> wb
              | WOption (None     )      -> wb |> addMsgs errOptionIsNone [errOptionIsNone]
              | WResult (Result(_, ms))  -> wb |> addMsgs errOptionIsNone ms
      
          type Builder() =
      //        member        this.Bind (wrapped: Async<Result<'a>>, restOfCExpr: 'a -> Wrap<'b>) = wrapped |> WAsyncR |> bind restOfCExpr //<< cannot differentiate from next 
              member        this.Bind (wrapped: Wrap<'a>         , restOfCExpr: 'a -> Wrap<'b>) = wrapped            |> bind restOfCExpr 
              member        this.Bind (wrapped: Async<'a>        , restOfCExpr: 'a -> Wrap<'b>) = wrapped |> WAsync  |> bind restOfCExpr  
              member        this.Bind (wrapped: Result<'a>       , restOfCExpr: 'a -> Wrap<'b>) = wrapped |> WResult |> bind restOfCExpr 
              member        this.Bind (wrapped: 'a option        , restOfCExpr: 'a -> Wrap<'b>) = wrapped |> WOption |> bind restOfCExpr 
              member inline this.Zero         ()  = WSimple ()
              member inline this.Return       (x) = WSimple x
              member inline this.ReturnFrom   (w) = w
      //        member inline this.ReturnFrom   (w) = WAsync  w
      //        member inline this.ReturnFrom   (w) = WResult w
      //        member inline this.ReturnFrom   (w) = WOption w        
              member inline this.Delay        (f) = f()
              member        this.Combine   (a, b) = combine errOptionIsNone a b
              member        this.Using (resource, body: 'a -> Wrap<'b>) =
                  async.Using(resource, wrapper2Async body) |> WAsyncR
                          
          let wrapper = Builder()
      
          let getResult callback (wb: Wrap<'T>) =
              match wb with
              | WSimple      s  -> s               |> succeed                                      |> callback
              | WOption(Some s) -> s               |> succeed                                      |> callback
              | WOption None    -> errOptionIsNone |> fail                                         |> callback
              | WResult      rb -> rb                                                              |> callback
              | WAsync       ab -> Async.StartWithContinuations(ab , (fun v   -> succeed v         |> callback), 
                                                                     (fun exc -> failException exc |> fail |> callback), 
                                                                      fun can -> failException can |> fail |> callback)
              | WAsyncR     arb -> Async.StartWithContinuations(arb,                                          callback , 
                                                                     (fun exc -> failException exc |> fail |> callback), 
                                                                      fun can -> failException can |> fail |> callback)
      
          let inline getAsyncR (wb: Wrap<'T>) =
              match wb with
              | WAsync      va  -> async {
                                     let! v = va
                                     return      succeed                           v}
              | WSimple     v   -> async.Return (succeed                           v)
              | WOption     v   -> async.Return (Result.fromOption errOptionIsNone v)
              | WResult     v   -> async.Return                                    v
              | WAsyncR     vra -> vra
              
          let inline getAsyncWithDefault f (wb: Wrap<'T>) = 
              async {
                  let!   vR = getAsyncR wb
                  return vR |> Result.withError f
              }
      
          let inline getAsync w =
              match w with
              | WAsync      va  ->              va
              | WSimple     v   -> async.Return v
              | WOption     vo  -> async {
                                      return
                                          match vo with 
                                          | Some v         -> v
                                          | None           -> raise (exn(getMessages [errOptionIsNone]))
                                   }
              | WResult     vr  -> async {
                                      return
                                          match vr with 
                                          | Success (v, _) -> v
                                          | Failure ms     -> raise (exn(getMessages ms))
                                   }
              | WAsyncR     vra -> async {
                                      let! vr = vra
                                      return
                                          match vr with 
                                          | Success (v, _) -> v
                                          | Failure ms     -> raise (exn(getMessages ms))
                                   }
      //    let call wb = wb |> getR Rop.notifyMessages
          let start (printMsg: string->unit) (w: Wrap<unit>) =
              w
              |> getAsyncR
              |> fun asy -> Async.StartWithContinuations
                              (asy 
                             , Result.mapMsgs Result.getMessages
                               >> function
                                  | Some _, msgs -> msgs
                                  | None  , msgs -> printfn "Failed!" ; msgs
                               >> sprintf "%s" >> printMsg
                             ,    sprintf "%A" >> printMsg
                             ,    sprintf "%A" >> printMsg)
      //#if WEBSHARPER
          [< Inline "console.log('runSynchronously should not be used in Javascript')" >]                       
      //#endif
          let runSynchronously (printMsg: string->unit) (w: Wrap<unit>) =
              w
              |> getAsyncR
              |> Async.RunSynchronously
              |> (Result.mapMsgs Result.getMessages
                  >> function
                     | Some _, msgs -> msgs
                     | None  , msgs -> printfn "Failed!" ; msgs
                  >> sprintf "%s" 
                  >> printMsg
                 )
      
      //#if WEBSHARPER
      [<JavaScript>]
      //#endif
      type Wrap<'T> with
          static member Start           (w:Wrap<_   >,           ?cancToken) = Async.Start           (Wrap.getAsync  w,                                ?cancellationToken= cancToken)
          static member StartAsTask     (w:Wrap<'T  >, ?options, ?cancToken) = Async.StartAsTask     (Wrap.getAsyncR w, ?taskCreationOptions= options, ?cancellationToken= cancToken)
      //#if WEBSHARPER
          [< Inline "console.log('RunSynchronously should not be used in Javascript')" >]                       
      //#endif
          static member RunSynchronously(w:Wrap<'T  >, ?timeout, ?cancToken) = Async.RunSynchronously(Wrap.getAsyncR w, ?timeout            = timeout, ?cancellationToken= cancToken)
      
      //# 1 @"(6)7a655466-e218-4121-a7b6-f9c70a922e07 extract, now, Async.fsx"
      let extract n (s:string) = s.Substring(0, min n s.Length)
      
      //#if WEBSHARPER
      [< Inline "(function (n) { return n.getFullYear() + '-' +(n.getMonth() + 1) + '-' +  n.getDate() + ' '+n.getHours()+ ':'+n.getMinutes()+ ':'+n.getSeconds()+ ':'+n.getMilliseconds() })(new Date(Date.now()))" >]
      //#endif
      let nowStamp() = System.DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture)
      
      module Async =
          let map f va = 
              async { 
                  let! a = va
                  return f a 
              } 
      //# 1 @"(6)ace1fc12-3dfb-4db8-80c9-5bde1e7d0597 prepareFsCode.fsx"
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
      
      let separatePrepros removePrepoLine (code:string[]) =
          let  quoted (line:string) = line.Trim().Split([| "\""       |], System.StringSplitOptions.RemoveEmptyEntries) |> Seq.tryLast |> Option.defaultValue line
          let  define (line:string) = line.Trim().Split([| "#define " |], System.StringSplitOptions.RemoveEmptyEntries) |> Seq.tryHead |> Option.defaultValue ""
          let  comment = ((+)"//") 
          let  preL    = if removePrepoLine then comment else id 
          let  prepro (line:string) = match true with 
                                      | true when line.StartsWith("#define") -> (comment line, line |> define |> PrepoDefine)
                                      | true when line.StartsWith("#r"     ) -> (comment line, line |> quoted |> PrepoR     )
                                      | true when line.StartsWith("#load"  ) -> (comment line, line |> quoted |> PrepoLoad  )
                                      | true when line.StartsWith("#nowarn") -> (comment line, line |> quoted |> PrepoNoWarn)
                                      | true when line.StartsWith("# "     ) -> (preL    line, line |> quoted |> PrepoLine  )
                                      | true when line.StartsWith("#line"  ) -> (preL    line, line |> quoted |> PrepoLine  )
                                      | true when line.StartsWith("#I"     ) -> (comment line, line |> quoted |> PrepoI     )
                                      | true when line.StartsWith("#if"    ) -> (        line, line           |> PrepoIf    )
                                      | true when line.StartsWith("//#else"  ) -> (        line,                   PrepoElse  )
                                      | true when line.StartsWith("//#endif" ) -> (        line,                   PrepoEndIf )
                                      | true when line.StartsWith("#light" ) -> (        line, false          |> PrepoLight )
                                      | true when line.StartsWith("#"      ) -> (comment line, line           |> PrepoOther )
                                      | _                                    -> (        line,                   NoPrepo    ) 
          code |> Array.map prepro
          
      let separateDirectives (fsNass:(string * PreproDirective) seq) =
          let  assembs  = fsNass |> Seq.choose (snd >> (function | PrepoR assemb -> Some assemb | _ -> None)) |> Seq.distinct |> Seq.toArray
          let  defines  = fsNass |> Seq.choose (snd >> (function | PrepoDefine d -> Some d      | _ -> None)) |> Seq.distinct |> Seq.toArray
          let  prepoIs  = fsNass |> Seq.choose (snd >> (function | PrepoI      d -> Some d      | _ -> None)) |> Seq.distinct |> Seq.toArray
          let  nowarns  = fsNass |> Seq.choose (snd >> (function | PrepoNoWarn d -> Some d      | _ -> None)) |> Seq.distinct |> Seq.toArray
          let  code     = fsNass |> Seq.map     fst                                                                           |> Seq.toArray
          code, assembs, defines, prepoIs, nowarns
      
      
      //# 1 @"(6)ab5ab0ca-eb45-4851-affe-4690bb75d055 copyIfMust.fsx"
      open System.IO
      
      let copyIfMust f destDir =
          let t = Path.Combine(destDir, Path.GetFileName(f))
          let fit = FileInfo t
          let must = 
              match fit.Exists with 
              | false -> true
              | true  ->
                  let fif = FileInfo t
                  fif.Length <> fit.Length || fif.LastWriteTime <> fit.LastWriteTime
          if must then
              File.Copy(f, t, true )    
          
      //# 1 @"(6)b30f4582-64bd-49e5-aca2-29897fef74c5 runProcess.fsx"
      open System.Diagnostics
      open System.Text
      
      let runProcess p ops =
          let procStart   = ProcessStartInfo(p, ops)
          let proc        = new Process()
          proc.StartInfo <- procStart
          proc.Start() 
      
      type ShellExError =
          | ShellExitCode              of int
          | ShellOutput                of string
          | ShellErrors                of string
          | ShellFailWithMessage       of string
          | ShellFinishedWithNoMessage 
          | ShellDidNotStart 
          | ShellCrashed               of string
      with interface ErrMsg with
              member this.ErrMsg    = 
                  match this with 
                  | ShellFailWithMessage msg   -> msg  
                  | ShellFinishedWithNoMessage -> "warning - No output"
                  | ShellOutput          msg   -> msg
                  | ShellCrashed         msg   -> "Crashed " + msg
                  | msg                        -> sprintf "%A" msg
              member this.IsWarning =
                  match this with 
                  | ShellFinishedWithNoMessage
                  | ShellOutput _              -> true
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
      //        proc.Exited            .AddHandler(System.EventHandler     (fun sender args -> try proc.Close()                                    with _ -> () ))
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
          member this.StartAndWait() =
              let started = this.Start()
              proc.WaitForExit()
              let    output  = (consume bufferOutput).Trim()
              let    error   = (consume bufferError ).Trim() 
              let    msgs    = [ if                   output        <> "" then yield ShellOutput   output        :> ErrMsg
                                 if                   error         <> "" then yield ShellErrors   error         :> ErrMsg
                                 if proc.HasExited && proc.ExitCode <> 0  then yield ShellExitCode proc.ExitCode :> ErrMsg]
              let    msgs2   = if msgs.IsEmpty && not started then [ ShellDidNotStart :> ErrMsg ] else msgs                           
              let    res     = Result ((if not started || (proc.HasExited && proc.ExitCode = 0) then Some() else None), msgs2) 
              res
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
      
    //# 1 @"(4)63eca270-405a-4789-941a-e298bbd265bd FsStationShared.fsx"
    //#if WEBSHARPER
    [<WebSharper.JavaScript>]
    //#endif
    module FsStationShared =
    
      //# 1 @"(6)2deb54e7-009e-4297-b2bc-1c86d04203a4 CodeSnippet.fsx"
      open Useful
      
      let inline swap f a b = f b a
            
      let snippetName name (content: string) =
          if name <> "" then name else 
          content.Split([| '\n' |], System.StringSplitOptions.RemoveEmptyEntries)
          |> Seq.map    (fun l -> l.Trim())
          |> Seq.filter (fun l -> not (l.StartsWith("#") || l.StartsWith("[<") || l.StartsWith("//")))
          |> Seq.tryHead
          |> Option.defaultValue "<empty>"
      
      let sanitize n =
          let illegal = [|'"'   ; '<'   ; '>'   ; '|'   ; '\000'; '\001'; '\002'; '\003'; '\004'; '\005'; '\006';
                          '\007'; '\b'  ; '\009'; '\010'; '\011'; '\012'; '\013'; '\014'; '\015';
                          '\016'; '\017'; '\018'; '\019'; '\020'; '\021'; '\022'; '\023'; '\024';
                          '\025'; '\026'; '\027'; '\028'; '\029'; '\030'; '\031'; ':'   ; '*'   ; '?';
                          '\\'  ; '/'|] //"
          n |> String.filter (fun c -> not <| Array.contains c illegal)
      
      type CodeSnippetId = CodeSnippetId of System.Guid   
      with static member New = CodeSnippetId <| System.Guid.NewGuid()
           member this.Text  = match this with CodeSnippetId guid -> guid.ToString()
      
      type CodeSnippet = {
          name         : string
          content      : string
          parent       : CodeSnippetId option
          predecessors : CodeSnippetId list
          id           : CodeSnippetId
          expanded     : bool
          level        : int
          properties   : Map<string, string>
      } with
          member this.Name = snippetName this.name this.content
          member this.NameSanitized =
              this.Name
              |> sanitize
              |> (fun c -> this.id.Text + " " + c + ".fsx")
      //    member this.ContentIndented addLinePrepos =
      //        let indent        = this.level * 2
      //        let indentF, prfx = if indent = 0         then (id, "") else (Array.map    (fun (l, pr) -> String.replicate indent " " + l, pr), sprintf"(%d)" indent)
      //        let addLinePs     = if not addLinePrepos  then  id      else  Array.append [| sprintf "//# 1 @\"%s%s\"" prfx this.NameSanitized |] 
      //        this.content.Split('\n') 
      //        |> addLinePs
      //        |> separatePrepros (not addLinePrepos)
      //        |> indentF
      //      , indent
      
      // tail recursion does not optimize
      let rec preds fetcher outs (ins : CodeSnippetId list) : CodeSnippetId list =
          match ins with
          | []         -> outs
          | hd :: rest -> List.collect id [ rest ; hd |> fetcher |> Option.toList |> List.collect (fun s -> s.parent |> Option.toList |> List.append <| s.predecessors) ]
                          |> preds fetcher (if outs |> Seq.contains hd then outs else hd::outs)
      
      let predsL fetcher (ins : CodeSnippetId list) : CodeSnippetId list =
          let mutable ins  = ins 
          let mutable outs = []
          while not ins.IsEmpty do
              match ins with
              | []         -> ()
              | hd :: rest -> if outs |> Seq.contains hd then
                                  ins  <- rest
                              else
                                  ins  <- List.collect id [ rest ; hd |> fetcher |> Option.toList |> List.collect (fun s -> s.parent |> Option.toList |> List.append <| s.predecessors) ]
                                  outs <- hd::outs
          outs
      
      type CodeSnippet with
          member this.UniquePredecessors (fetcher: CodeSnippetId -> CodeSnippet option) = predsL fetcher [ this.id ]        
          static member TryFindByKey  snps key = snps |> Seq.tryFind (fun snp        -> snp.id = key)
          member this.SeparateCode addLinePrepos =
              let indent        = this.level * 2
              let indentF, prfx = if indent = 0         then (id, "") else (Array.map    (fun (l, pr) -> String.replicate indent " " + l, pr), sprintf"(%d)" indent)
              let addLinePs     = if not addLinePrepos  then  id      else  Array.append [| sprintf "//# 1 @\"%s%s\"" prfx this.NameSanitized |]
              let code, assembs, defines, prepIs, nowarns  =
                  this.content.Split('\n') 
                  |> addLinePs
                  |> separatePrepros (not addLinePrepos)
                  |> indentF
                  |> separateDirectives
              [| this.NameSanitized, code.Length, indent |] , code, assembs, defines, prepIs, nowarns
          static member AddSeps (lines1:(string*int*int)[], code1:string[], assembs1:string[], defines1:string[], prepIs1:string[], nowarns1:string[])
                                (lines2:(string*int*int)[], code2:string[], assembs2:string[], defines2:string[], prepIs2:string[], nowarns2:string[]) =
              Array.append lines1   lines2
            , Array.append code1    code2
            , Seq  .append assembs1 assembs2 |> Seq.distinct |> Seq.toArray
            , Seq  .append defines1 defines2 |> Seq.distinct |> Seq.toArray
            , Seq  .append prepIs1  prepIs2  |> Seq.distinct |> Seq.toArray
            , Seq  .append nowarns1 nowarns2 |> Seq.distinct |> Seq.toArray
          static member ReducedCode  addLinePrepos (snippets: CodeSnippet seq) =
              snippets
              |> Seq.map(fun snp -> snp.SeparateCode addLinePrepos)
              |> fun snps -> if snps |> Seq.isEmpty then seq [ [||],  [||],  [||],  [||],  [||],  [||] ] else snps
              |> Seq.reduce CodeSnippet.AddSeps
              |> fun (lines, code, assembs, defines, prepIs, nowarns) ->
                 (lines, code |> String.concat "\n" |> Array.singleton, assembs, defines, prepIs, nowarns)
          static member FinishCode addLinePrepos (lines:(string*int*int)[],code:string[], assembs:string[], defines:string[], prepIs:string[], nowarns:string[]) =
              let config = defines |> Seq.sort |> Seq.map ((+)"-d:") |> String.concat " "
              let part1  =
                [ if config <> "" then yield "////" + config
                  yield! prepIs  |> Seq.map (sprintf "#I @\"%s\""    )
                  yield! assembs |> Seq.map (sprintf "#r @\"%s\""    )
                  if addLinePrepos && (nowarns |> Seq.isEmpty |> not) then yield "//# 1 \"required for nowarns to work\""
                  yield! nowarns |> Seq.map (sprintf "#nowarn \"%s\"")
                ]
              Seq.append part1 code |> String.concat "\n"
            , lines 
              |> Seq.mapFold (fun firstLine (name, len, ind) -> (name, (ind, firstLine, firstLine + len)), firstLine + len) part1.Length
              |> fst
              |> Seq.toArray
          static member CodeAndStarts   addLinePrepos (snippets:CodeSnippet seq) =
              CodeSnippet.ReducedCode   addLinePrepos snippets
              |> CodeSnippet.FinishCode addLinePrepos
          static member CodeFsx         addLinePrepos snps = CodeSnippet.CodeAndStarts addLinePrepos snps |> fst
      //    static member CodeMerged  addLinePrepos (snippets: CodeSnippet seq) =
      //        let bySnippet = 
      //            snippets
      //            |> Seq.map(fun snp -> 
      //                let code, indent = snp.ContentIndented addLinePrepos
      //                snp, indent, code
      //            )
      //        (bySnippet, bySnippet |> Seq.collect (function _, _, code -> code))
      //    static member CodeParts addLinePrepos snippets =
      //        let bySnippet, merged                        = CodeSnippet.CodeMerged addLinePrepos snippets
      //        let code, assembs, defines, prepIs, nowarns  = separateDirectives merged
      //        let config = defines |> Seq.distinct |> Seq.sort |> Seq.map ((+)"-d:")             |> String.concat " "
      //        [   if config <> "" then yield "////" + config
      //            yield! prepIs  |> Seq.distinct             |> Seq.map (sprintf "#I @\"%s\""    )
      //            yield! assembs |> Seq.distinct             |> Seq.map (sprintf "#r @\"%s\""    )
      //            if addLinePrepos && (nowarns |> Seq.isEmpty |> not) then yield "//# 1 \"required for nowarns to work\""
      //            yield! nowarns |> Seq.distinct             |> Seq.map (sprintf "#nowarn \"%s\"")
      //        ], code, bySnippet
      //    static member CodeFsx0 addLinePrepos (cur, snippets) =
      //        let part1, part2, bySnippet = CodeSnippet.CodeParts addLinePrepos (Array.append snippets [| cur |])
      //        [ yield! part1 ; yield! part2 ] |> String.concat "\n"
      
      
      //# 1 @"(6)eb54ba64-3d11-4347-97c8-aeae9e3e3121 MessagingClient.fsx"
      //#r "remote.dll"
      open CIPHERPrototype.Messaging
      
      open WebSharper
      open Useful
      
      type MessagingClient(clientId, ?timeout, ?endPoint:string) =
          let wsEndPoint = endPoint    |> Option.defaultValue "http://localhost:9000/FSharpStation.html"
          let tout       = timeout     |> Option.defaultValue 100_000
          let fromId     = AddressId clientId
          do WebSharper.Remoting.EndPoint <- wsEndPoint 
          let awaitMessage respond =
              async {
                  while true do
                      printfn "%s awaitRequest %s" (nowStamp()) clientId
      //#if WEBSHARPER
                      let! msgA  = Async.StartChild(awaitRequestFor    fromId, tout)
      //#else
                      let! msgA  = Async.StartChild(awaitRequestForRpc fromId, tout)
      //#endif          
                      try
                          let! msg   = msgA
                          let! resp  = respond clientId msg.content
      //#if WEBSHARPER
                          do!          replyTo    msg.messageId.Value resp
      //#else
                          do!          replyToRpc msg.messageId.Value resp
      //#endif              
                      with 
                      | :? System.TimeoutException -> ()
                      | e                          -> printfn "%A" e
              } 
      //#if WEBSHARPER
              |> fun asy -> Async.StartWithContinuations(asy, id, (fun e -> JS.Alert(e.ToString()) ), fun c -> JS.Alert(c.ToString()))
      //#else
              |> Async.Start
      //#endif                
      //#if WEBSHARPER
          let sendMessage  toId msg = sendRequest    toId fromId msg
      //#else
          let sendMessage  toId msg = sendRequestRpc toId fromId msg
      //#endif                
          let poMsg checkResponse msg =
              async {
                  let! resp = sendMessage (AddressId "WebServer:PostOffice") (Json.Serialize<POMessage> msg)
                  return checkResponse (Json.Deserialize<POResponse> resp)
              }
          let poString resp =
                      match resp with
                      | POString  v  -> v
                      | POStrings vs -> sprintf "%A" vs
          let poStrings resp =
                      match resp with
                      | POString  v  -> [| sprintf "unexpected response: %s" v |]
                      | POStrings vs -> vs
        with 
          member this.AwaitMessage respond  = awaitMessage (fun clientId request -> async { return respond clientId request })
          member this.AwaitMessage respondA = awaitMessage respondA
          member this.SendMessage toId msg  = sendMessage toId msg
          member this.POMessage        msg  = poMsg id        msg
          member this.POListeners      ()   = poMsg poStrings POListeners
          member this.EndPoint              = wsEndPoint
          member this.ClientId              = clientId
          static member EndPoint_           = "http://localhost:9000/FSharpStation.html"
          
          
      
      
      //# 1 @"(6)f6ebdffc-049c-4493-8de8-e32072419479 FSMessage,FSResponse.fsx"
      type FSMessage =
          | GetIdentification
          | GenericMessage        of string
          | GetSnippetContentById of CodeSnippetId
          | GetSnippetCodeById    of CodeSnippetId
          | GetSnippetPredsById   of CodeSnippetId
          | GetSnippetById        of CodeSnippetId
          | GetSnippetContent     of string []
          | GetSnippetCode        of string []
          | GetSnippetPreds       of string []
          | GetSnippet            of string []
          | GetSnippetJSCode      of string []
          | GetWholeFile
          | RunSnippetUrlJSById   of CodeSnippetId * string
          | RunSnippetUrlJS       of string []     * string
      
      type FSSeverity =
          | FSError
          | FSWarning
          | FSInfor
      
      type FSResponse =
          | IdResponse        of string
          | StringResponse    of string option
          | SnippetResponse   of CodeSnippet option
          | SnippetsResponse  of CodeSnippet []
          | StringResponseR   of string option * (string * FSSeverity)[]
      
      
      //# 1 @"(6)5597a227-c983-46fc-87e2-cbe241faa279 FsStationClient.fsx"
      open CIPHERPrototype.Messaging
      
      type FsStationClientErr =
          | FSMessage             of string * FSSeverity
          | ``Snippet Not Found`` of string
      with interface ErrMsg with
              member this.ErrMsg    = 
                  match this with 
                  | FSMessage (msg, sev    )   -> sprintf "%A %s" sev msg
                  | msg                        -> sprintf "%A"        msg
              member this.IsWarning =     
                  match this with 
                  | FSMessage (_  , FSError)   -> true
                  | msg                        -> false
      
      type FsStationClient(clientId, ?fsStationId:string, ?timeout, ?endPoint) =
          let fsIds      = fsStationId |> Option.defaultValue "FSharpStation"
          let msgClient  = MessagingClient(clientId, ?timeout= timeout, ?endPoint= endPoint)
          let toId       = AddressId fsIds
          let stringResponseR response =
              match response with
              | StringResponseR (Some code, msgs) -> Result.succeedWithMsgs code (msgs |> Seq.map (fun v -> FSMessage v :> ErrMsg) |> Seq.toList)
              | _                                 -> Result.fail    (``Snippet Not Found`` <| response.ToString()) 
          let stringResponse  response =
              match response with
              | StringResponse (Some code)    -> Result.succeed code
              | _                             -> Result.fail    (``Snippet Not Found`` <| response.ToString()) 
          let snippetsResponse response =
              match response with
              | SnippetsResponse snps         -> Result.succeed snps
              | _                             -> Result.fail    (``Snippet Not Found`` <| response.ToString()) 
          let snippetResponse response =
              match response with
              | SnippetResponse  snp          -> Result.succeed snp
              | _                             -> Result.fail    (``Snippet Not Found`` <| response.ToString()) 
          [< Inline >]
          let sendMsg toId (msg: FSMessage) (checkResponse: FSResponse -> Result<'a>) =
              Wrap.wrapper {
                  let!   response = msgClient.SendMessage toId (msg |> Json.Serialize)
                  let!   resp     = checkResponse (Json.Deserialize<FSResponse> response)
                  return resp
              } 
        with 
          member this.SendMessage     (toId2,  msg:FSMessage) = sendMsg toId2  msg    Result.succeed   
          member this.SendMessage     (        msg:FSMessage) = sendMsg toId   msg    Result.succeed   
          member this.RequestSnippet  (    snpPath:string   ) = sendMsg toId  (GetSnippet          (snpPath.Split '/'     ))    snippetResponse  
          member this.RequestCode     (    snpPath:string   ) = sendMsg toId  (GetSnippetCode      (snpPath.Split '/'     ))    stringResponse   
          member this.RequestJSCode   (    snpPath:string   ) = sendMsg toId  (GetSnippetJSCode    (snpPath.Split '/'     ))    stringResponseR  
          member this.RequestPreds    (    snpPath:string   ) = sendMsg toId  (GetSnippetPreds     (snpPath.Split '/'     ))    snippetsResponse 
          member this.RequestPredsById(      snpId          ) = sendMsg toId  (GetSnippetPredsById  snpId                  )    snippetsResponse 
          member this.RequestWholeFile(                     ) = sendMsg toId   GetWholeFile                                     stringResponse   
          member this.GenericMessage  (        txt:string   ) = sendMsg toId  (GenericMessage       txt                    )    stringResponse   
          member this.RunSnippet      (url,snpPath:string   ) = sendMsg toId  (RunSnippetUrlJS     (snpPath.Split '/', url))    stringResponseR
          member this.FSStationId                             = fsIds
          member this.MessagingClient                         = msgClient    
          static member FSStationId_                          = "FSharpStation"
      
      
      //# 1 @"(6)56e5bc09-e528-49cc-9d42-6359b32a0cc9 FsStationClient Compile Extension.fsx"
      //#r "FSharp.Compiler.Service.dll"
      open Microsoft.FSharp.Compiler.SourceCodeServices
      open System.IO
      
      let prepOptions options file (code, assembs, defines, prepoIs, nowarns) =
          let  code2 =
             [
                yield! nowarns |> Seq.distinct |> Seq.map (sprintf "#nowarn \"%s\"")
                yield! code 
             ] |> String.concat "\n"
          do System.IO.File.WriteAllText(file, code2)
          let  options2 = [|
                             yield  "IGNOREDfsc.exe"
                             yield! prepoIs |> Array.map ((+) "-I:")
                             yield! assembs |> Array.map ((+) "-r:")
                             yield! defines |> Array.map ((+) "-d:")
                             yield! options |> Array.filter (fun (s:string) -> s.StartsWith "++" |> not)
                             yield  file 
                             if options |> Array.exists ((=) "++staticlinkall") then 
                                 yield! assembs |> Array.map (Path.GetFileNameWithoutExtension >> ((+) "--staticlink:"))         
                         |]        
          if options |> Array.exists ((=) "++showoptions"   ) then printfn "%s" (options2 |> String.concat "\n")               
          if options |> Array.exists ((=) "++copyassemblies") then 
              assembs |> Array.iter (fun f -> Path.GetDirectoryName(file) |> copyIfMust f)      
          options2
          
      type CodeSnippet with
          static member PrepareCompileOptions options fileName (snps: CodeSnippet seq) =
              let  addLinePrepos =  options |> Array.exists ((=) "++removelinedirectives") |> not
              let  lines, code, assembs, defines, prepoIs, nowarns = CodeSnippet.ReducedCode addLinePrepos snps
              let  options2    = prepOptions options fileName (code, assembs, defines, prepoIs, nowarns)
              options2
      
      open System.IO
      
      let compileOptionsWinExeDebug filename =
          [| @"--target:winexe"    
             sprintf "-o:%s" <| Path.ChangeExtension(filename, "exe")
             @"-g"
             @"--debug:full"
             //@"--noframework"
             @"--define:DEBUG"
             @"--define:TRACE"
             @"--optimize-"
             @"--tailcalls-"
             @"--warn:3"
             @"--warnaserror:76"
             @"--vserrors"
             @"--utf8output"
             @"--fullpaths"
             @"--flaterrors"
             @"--subsystemversion:6.00"
             @"--highentropyva+"
             //@"++showoptions"
             @"++removelinedirectives"
          |]
                
      let compileOptionsExeDebug filename =
          [| @"--target:exe"    
             sprintf "-o:%s" <| Path.ChangeExtension(filename, "exe")
             @"-g"
             @"--debug:full"
             //@"--noframework"
             @"--define:DEBUG"
             @"--define:TRACE"
             @"--optimize-"
             @"--tailcalls-"
             @"--warn:3"
             @"--warnaserror:76"
             @"--vserrors"
             @"--utf8output"
             @"--fullpaths"
             @"--flaterrors"
             @"--subsystemversion:6.00"
             @"--highentropyva+"
             //@"++showoptions"
             @"++removelinedirectives"
          |]
                
      let compileOptionsDllDebug filename =
          [| @"--target:library"   
             sprintf "-o:%s" <| Path.ChangeExtension(filename, "dll")
             @"-g"
             @"--debug:full"
             //@"--noframework"
             @"--define:DEBUG"
             @"--define:TRACE"
             @"--optimize-"
             @"--tailcalls-"
             @"--warn:3"
             @"--warnaserror:76"
             @"--vserrors"
             @"--utf8output"
             @"--fullpaths"
             @"--flaterrors"
             @"--subsystemversion:6.00"
             @"--highentropyva+"
             //@"++showoptions"
             @"++removelinedirectives"
          |]
      
      type FsStationClient with
          member this.PrepareCompileOptions(optionsC, fileName, snpPath) = 
              Wrap.wrapper {
                  let!   preds   = this.RequestPreds snpPath
                  let    options = CodeSnippet.PrepareCompileOptions (optionsC fileName) fileName preds
                  return options
              }
          member this.CompileSnippet(optionsC, fileName, snpPath, printMsgs) = 
              Wrap.wrapper {
                  printMsgs <| sprintf "Compiling %s ..."                      snpPath
                  let! options2   = this.PrepareCompileOptions (optionsC, fileName, snpPath)
                  let! msgs, stat = FSharpChecker.Create().Compile options2
                  printMsgs <|
                      match msgs with
                      | [||] -> "Compiled " + fileName
                      | _    -> msgs |> Seq.map (sprintf "%A") |> String.concat "\n"
              } |> Wrap.runSynchronously printMsgs
          member this.CompileSnippet(optionsC, fileName, snpPath) = this.CompileSnippet(optionsC, fileName, snpPath, printfn "%s")
              
      
//# 1 @"f3c40a7d-724c-47fb-88fd-a38b9680b7cb ACTIONS.fsx"
module Actions =
  //# 1 @"(2)c8c93861-321c-4d73-beb0-2fef0052bc7b compile & run Demo as WebServer3.fsx"
  //#define WEBSHARPER
  
  open System.IO
  open FSSGlobal.FsStationShared
  open FSSGlobal.Useful
  
  Wrap.wrapper {
      let  snippet   = @"FSSGlobal/WebSharper Code/WebSharper Client-Server Demo/Server"
      let  dest      = @"Compiled\WebServer3"
      let  fsFile    = @"WebServer3.fs"
      let  url       = @"http://localhost:9001/"
      let  file      = Path.Combine(dest, fsFile)
      let  optionsF  = compileOptionsExeDebug >> Array.append [| "++copyassemblies" ;  "--project:WebServer3" ; "--ws:Site" ; sprintf @"--wsoutput:%s\site" dest |]
      let  fsstation = FsStationClient("Compile Server3")
      do   printfn     "Assembling Code %s" fsFile
      let! options   = fsstation.PrepareCompileOptions(optionsF, file, snippet)
      do   Directory.CreateDirectory(dest + @"\site") |> ignore
      do   printfn     "Compiling %s" fsFile
      do!  options
           |> Seq.skip 1
           |> Seq.map (sprintf "%A")
           |> String.concat "  "
           |> fun ops -> printfn "%s" ops ; ops
           |> fun ops -> (new ShellEx(@"D:\Abe\CIPHERWorkspace\CIPHERPrototype\Common\packages\Zafir.FSharp\build\..\tools\WsFsc.exe", ops)).StartAndWait()
      do   copyIfMust  "FSharp.Core.dll" dest
      do   printfn     "Starting %s"     fsFile
      do   runProcess  (System.IO.Path.ChangeExtension(file, "exe")) url |> ignore
      do   runProcess  url "" |> ignore
  } |> Wrap.runSynchronously (printfn "%s")
  
  