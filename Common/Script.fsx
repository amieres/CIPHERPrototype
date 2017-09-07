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
#r @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.1\System.dll"
#r @"FSharp.Data.dll"
#r @"FSharp.Compiler.Service.dll"
#r @"remote.dll"
//# 1 "required for nowarns to work"
#nowarn "1182"
#nowarn "40"
#nowarn "1178"
//# 1 @"bf864f3c-1370-42f2-ac8a-565a604892e8 FSSGlobal.fsx"
//#nowarn "1182"
//#nowarn "40"
//#r @"D:\Abe\CIPHERWorkspace\CIPHERPrototype\WebServer\bin\FSharp.Core.dll"
#if INTERACTIVE
#I @"../WebServer/bin"
module FSSGlobal   =
#else
namespace FSSGlobal
#endif

  //# 1 @"(2)edbbf11e-4698-4e33-af0c-135d5b21799b F# Code.fsx"
  // Code to be evaluated using FSI: `Evaluate F#`
    //# 1 @"(4)60bffe71-edde-4971-8327-70b9f5c578bb open WebSharper.fsx"
    #if WEBSHARPER
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
    #endif
    //# 1 @"(4)7c4a82bc-58cd-48a7-bd7e-79de148a1cf0 Useful.fsx"
    #if WEBSHARPER
    [<WebSharper.JavaScript>]
    #endif
    module Useful =
      //# 1 @"(6)368caae7-6a67-4063-9af3-978c25b81ac2 Result, Wrap.fsx"
      open System
      //#nowarn "1178"
      #if WEBSHARPER
      [<JavaScript>]
      #endif
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
      
      #if WEBSHARPER
      [<JavaScript>]
      #endif
      type ExceptionThrown(exn:Exception) =
          interface ErrMsg with
              member this.ErrMsg   : string = sprintf "%A" exn
              member this.IsWarning: bool   = false
      
      #if WEBSHARPER
      [<JavaScript>]
      #endif
      type ErrOptionIsNone() =
          interface ErrMsg with
              member this.ErrMsg   : string = "Option is None"
              member this.IsWarning: bool   = false
      
      #if WEBSHARPER
      [<JavaScript>]
      #endif
      type Result<'TSuccess> = Result of 'TSuccess option * ErrMsg list     
      
      #if WEBSHARPER
      [<JavaScript>]
      #endif
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
      
      #if WEBSHARPER
      [<JavaScript>]
      #endif
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
      #if WEBSHARPER
          [< Inline "console.log('runSynchronously should not be used in Javascript')" >]                       
      #endif
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
      
      #if WEBSHARPER
      [<JavaScript>]
      #endif
      type Wrap<'T> with
          static member Start           (w:Wrap<_   >,           ?cancToken) = Async.Start           (Wrap.getAsync  w,                                ?cancellationToken= cancToken)
          static member StartAsTask     (w:Wrap<'T  >, ?options, ?cancToken) = Async.StartAsTask     (Wrap.getAsyncR w, ?taskCreationOptions= options, ?cancellationToken= cancToken)
      #if WEBSHARPER
          [< Inline "console.log('RunSynchronously should not be used in Javascript')" >]                       
      #endif
          static member RunSynchronously(w:Wrap<'T  >, ?timeout, ?cancToken) = Async.RunSynchronously(Wrap.getAsyncR w, ?timeout            = timeout, ?cancellationToken= cancToken)
      
      //# 1 @"(6)7a655466-e218-4121-a7b6-f9c70a922e07 extract, now, Async.fsx"
      let extract n (s:string) = s.Substring(0, min n s.Length)
      
      #if WEBSHARPER
      [< Inline "(function (n) { return n.getFullYear() + '-' +(n.getMonth() + 1) + '-' +  n.getDate() + ' '+n.getHours()+ ':'+n.getMinutes()+ ':'+n.getSeconds()+ ':'+n.getMilliseconds() })(new Date(Date.now()))" >]
      #endif
      let nowStamp() = System.DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture)
      
      module Async =
          let map f va = 
              async { 
                  let! a = va
                  return f a 
              } 
      //# 1 @"(6)218507eb-4a87-4c11-b5d9-53a2213dd36a Regex.fsx"
      #if WEBSHARPER
      
      let (|REGEX|_|) (expr: string) (opt: string) (value: string) =
          if value = null then None else
          try 
              match JavaScript.String(value).Match(RegExp(expr, opt)) with
              | null         -> None
              | [| |]        -> None
              | m            -> Some m
          with e -> None
      #endif
      
      //#r @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.1\System.dll"
      open System.Text.RegularExpressions
      
      #if WEBSHARPER
      [< Inline "console.log('not implemented in JavaScript')" >]
      #endif
      let (|Regex|_|) pattern input =
          if input = null then None else
          try 
              let m = Regex.Match(input, pattern)
              if m.Success then Some(List.tail [ for g in m.Groups -> g.Value ])
              else None
          with e -> None
      
      //# 1 @"(6)ace1fc12-3dfb-4db8-80c9-5bde1e7d0597 separateDirectives.fsx"
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
                                      | true when line.StartsWith("#else"  ) -> (        line,                   PrepoElse  )
                                      | true when line.StartsWith("#endif" ) -> (        line,                   PrepoEndIf )
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
      
      let copyIfNotExistsToFile from dest =
          let fit = FileInfo dest
          if not fit.Exists then
              File.Copy(from, dest, true )
      
      let copyIfMustToFile from dest =
          let fit = FileInfo dest
          let must = 
              match fit.Exists with 
              | false -> true
              | true  ->
                  let fif = FileInfo dest
                  fif.Length <> fit.Length || fif.LastWriteTime <> fit.LastWriteTime
          if must then
              File.Copy(from, dest, true )
      
      let copyIfMustToDir from destDir =
          let dest = Path.Combine(destDir, Path.GetFileName(from))
          copyIfMustToFile from dest
          
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
      
      //# 1 @"(6)15cf771f-22b1-4796-8e34-6c16f35d6506 Path.Combine.fsx"
      let inline (+/+) a b = System.IO.Path.Combine(a, b)
      //# 1 @"(6)ef053bdf-997b-49c8-a401-1611a568bd8a CompOptions.fsx"
      type CompOptionClass = 
          | OpFSharp
          | OpWebSharper
          | OpInternal
      
      type CompOption = 
          {
              name   : string
              unique : bool
              opClass: CompOptionClass  
              prefix : string
          }
      with
          static member (/=) (op: CompOption, v: CompOptionValue) = op,           v
          static member (/=) (op: CompOption, v                 ) = op, OpVText   v
          static member (/=) (op: CompOption, v                 ) = op, OpVTextOF v
      
      and CompOptionValue =
          | OpVText   of                string
          | OpVTextOF of (CompOptions -> string)
      with 
          member this.Value ops = 
              match this with
              | OpVText   v  -> v
              | OpVTextOF fo -> fo ops
      
      and CompOptions = CompOptions of (CompOption * CompOptionValue) []
      with
          member this.Find  name        =  this |> function CompOptions ops ->  ops |> Array.find   (fun (opT, opV) -> name = opT.name                      )
          member this.FindV name        = (this.Find name |> snd).Value this
          member this.Contains v        =  this |> function CompOptions ops ->  ops |> Array.exists (fun (opT, opV) -> v    = opT.prefix + (opV.Value this) )
          member this.Get   f           =  this |> function CompOptions ops ->  ops |> Array.filter f |> Array.map (fun (opT, opV) ->        opT.prefix + (opV.Value this) )
          static member FSharpOptions   = fun ({opClass=cls}, _) -> cls = OpFSharp
          static member WSharperOptions = fun ({opClass=cls}, _) -> cls = OpFSharp || cls = OpWebSharper
          static member (?) (ops: CompOptions, name: string) = ops.FindV name
          static member (+) (os1: CompOptions, a2: (CompOption * CompOptionValue) []) = 
              match os1 with 
              | CompOptions a1 -> 
                  a1
                  |> Array.filter (fun (opT, _) -> (not opT.unique) || (a2 |> Array.exists (fst >> (=) opT) |> not) )
                  |> Array.append <| a2 
                  |> CompOptions
          static member (+) (ops: CompOptions, o:   CompOption * CompOptionValue    ) = ops + [| o |]
          static member (+) (os1: CompOptions, os2: CompOptions                     ) = match os2 with | CompOptions a2 -> os1 + a2
      
      let (?) (ops:CompOptions) name = ops.FindV name
      
      let opSnippet     = { name = "Snippet"     ; unique = true  ; opClass = OpInternal   ; prefix = "++snippet:"   }
      let opDirectory   = { name = "Directory"   ; unique = true  ; opClass = OpInternal   ; prefix = "++directory:" }
      let opName        = { name = "Name"        ; unique = true  ; opClass = OpInternal   ; prefix = "++name:"      }
      let opExtension   = { name = "Extension"   ; unique = true  ; opClass = OpInternal   ; prefix = "++extension:" }
      let opFileName    = { name = "Filename"    ; unique = true  ; opClass = OpInternal   ; prefix = "++filename:"  }
      let opConfig      = { name = "Config"      ; unique = true  ; opClass = OpInternal   ; prefix = "++config:"    }
      let opGenInternal = { name = "GenInternal" ; unique = false ; opClass = OpInternal   ; prefix = "++"           }
          
      let opIOption     = { name = "IOption"     ; unique = false ; opClass = OpFSharp     ; prefix = "-I:"          }
      let opReference   = { name = "Reference"   ; unique = false ; opClass = OpFSharp     ; prefix = "-r:"          }
      let opSource      = { name = "Source"      ; unique = false ; opClass = OpFSharp     ; prefix = ""             }
      let opTarget      = { name = "Target"      ; unique = true  ; opClass = OpFSharp     ; prefix = "--target:"    }
      let opOutput      = { name = "Output"      ; unique = true  ; opClass = OpFSharp     ; prefix = "-o:"          }
      let opDebug       = { name = "Debug"       ; unique = true  ; opClass = OpFSharp     ; prefix = "--debug:"     }
      let opDefine      = { name = "Define"      ; unique = false ; opClass = OpFSharp     ; prefix = "--define:"    }
      let opGenFSharp1  = { name = "GenFSharp1"  ; unique = false ; opClass = OpFSharp     ; prefix = "-"            }
      let opGenFSharp2  = { name = "GenFSharp2"  ; unique = false ; opClass = OpFSharp     ; prefix = "--"           }
      
      let opWebSite     = { name = "Website"     ; unique = true  ; opClass = OpWebSharper ; prefix = "--wsoutput:"  }
      let opGenWSharper = { name = "GenWSharper" ; unique = false ; opClass = OpWebSharper ; prefix = "--"           }
      
      
    //# 1 @"(4)376fdef6-dfcf-40c5-bd14-97c3b246bb30 UsefulNoWS.fsx"
    module UsefulNoWS =
      //# 1 @"(6)82ab58ca-79e8-47f9-8917-f444d3320751 Rpc Calling.fsx"
      //#r "FSharp.Data.dll"
      
      open System
      open System.Net
      open System.Text
      open System.IO
      open WebSharper
      open WebSharper.Remoting
      open WebSharper.JavaScript
      
      #if WEBSHARPER
      [<WebSharper.JavaScript>]
      #endif
      type AddressId = AddressId of string
      
      #if WEBSHARPER
      [<WebSharper.JavaScript>]
      #endif
      type Request = {
          toId              : AddressId
          fromId            : AddressId
          content           : string
          mutable messageId : Guid option
      }
      
      #if WEBSHARPER
      [<WebSharper.JavaScript>]
      #endif
      type MBMessage =
      | Listener of AddressId * (Request->unit) * (exn->unit) * (OperationCanceledException->unit)
      | Request  of Request   * (string ->unit) * (exn->unit) * (OperationCanceledException->unit)
      | Reply    of Guid      *  string
      
      #if WEBSHARPER
      [<WebSharper.JavaScript>]
      #endif
      type POMessage =
      | POIdentification
      | POEcho   of string
      | POListeners
      | POPendingRequests
      | POPendingReplys
      
      #if WEBSHARPER
      [<WebSharper.JavaScript>]
      #endif
      type POResponse =
      | POString  of string
      | POStrings of string[]
      
      let extract n (s:string) = s.Substring(0, min n s.Length)
      let now() = System.DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture)
      
      type PostOffice() =
          let mutable listeners = [| |]
          let mutable requests  = [| |]
          let mutable sent      = [| |]
          let agent = MailboxProcessor.Start(fun mail ->
              async {
                  while true do
                      let! mbMsg = mail.Receive()
                      match mbMsg with
                      | Listener                    (listener, lfs, lfe, lfc)  ->
                          requests
                          |> Array.indexed
                          |> Array.tryPick (fun (i, (request , rfs, rfe, rfc)) -> 
                              if request.toId <> listener then None else
                              requests <- Array.append requests .[0..i-1]  requests .[i+1..requests .Length - 1]
                              Some(lfs, request, rfs))
                          |> (fun v -> (if v.IsNone then 
                                          listeners <- 
                                              listeners 
                                              |> Array.filter(fun (lnr, lfs, exn, cen) -> 
                                                  if lnr = listener then
                                                      //exn <| DivideByZeroException ()
                                                      //exn <| TimeoutException ()
                                                      lfs <| {
                                                                  toId      = AddressId ""
                                                                  fromId    = AddressId ""
                                                                  content   = "{\"$\":0}"
                                                                  messageId = None
                                                              }
                                                      false
                                                  else true) 
                                              |> Array.append [| listener, lfs, lfe, lfc |]); v)
                      | Request                     (request , rfs, rfe, rfc)  ->
                          listeners
                          |> Array.indexed
                          |> Array.tryPick (fun (i, (listener, lfs, lfe, lfc)) -> 
                              if request.toId <> listener then None else 
                              listeners <- Array.append listeners.[0..i-1] listeners.[i+1..listeners.Length - 1]
                              Some(lfs, request, rfs))
                          |> (fun v -> (if v.IsNone then requests  <- requests  |> Array.append [| request , rfs, rfe, rfc |]); v)
                      | Reply                       (reply   , response)  ->
                          sent
                          |> Array.indexed
                          |> Array.pick (fun (i, (request , rfs)) -> 
                              if request.messageId.Value <> reply then None else
                              sent      <- Array.append sent     .[0..i-1] sent     .[i+1..sent     .Length - 1]
                              rfs response
                              Some ())
                          None
                      |> Option.iter (fun (lfs, request, rfs) -> 
                          request.messageId <- Some <| Guid.NewGuid()
                          sent <- sent |> Array.append [| request, rfs |]
                          lfs request
                      )
              }
          )
          with
              member this.AwaitRequest    listener  fs fe fc = agent.Post <| Listener (listener, fs, fe, fc)
              member this.SendRequest     request   fs fe fc = 
                  printfn "%s Request: %A %A %A" (now()) request.toId request.fromId (extract 80 request.content)
                  agent.Post <| Request  (request , fs, fe, fc)
              member this.ReplyTo         request   response = 
                  printfn "%s Reply:   %s"       (now()) (extract 100 response)
                  agent.Post <| Reply    (request , response  )
              member this.Listeners       ()                 = listeners |> Array.map (function | AddressId id, _, _, _ -> id)
              member this.Requests        ()                 = requests  |> Array.map (sprintf "%A")
              member this.Sent            ()                 = sent      |> Array.map (sprintf "%A")
      
      let postOffice = PostOffice()
      
      [< Rpc >]
      let awaitRequestFor (listener:AddressId) =
          let startAsync (fs, fe, fc) = postOffice.AwaitRequest listener fs fe fc
          Async.FromContinuations startAsync
      
      [< Rpc >]
      let replyTo    (reply:Guid) response =
          async {
              postOffice.ReplyTo reply response
          }
      
      open FSharp.Data
      open FSharp.Data.JsonExtensions
      
      [< Rpc >]
      let sendRequest  toId fromId content =
          if toId = AddressId "WebServer:PostOffice" then
              async {
                  let msg = Json.Deserialize<POMessage> content
                  return
                      match msg with
                      | POIdentification  -> POString     "WebServer:PostOffice"
                      | POEcho        txt -> POString     txt
                      | POListeners       -> POStrings <| postOffice.Listeners()
                      | POPendingRequests -> POStrings <| postOffice.Requests ()
                      | POPendingReplys   -> POStrings <| postOffice.Sent     ()
                      |> Json.Serialize 
              }
          else
          let startAsync (fs, fe, fc) = postOffice.SendRequest   
                                          { toId      = toId   
                                            fromId    = fromId 
                                            content   = content 
                                            messageId = None }
                                          fs fe fc
          Async.FromContinuations startAsync
      
      let RpcCall (url:string) method (data:string) =
          async {
              //printfn "RpcCall %s" (extract 100 data)
              let req = WebRequest.Create(url) :?> HttpWebRequest 
              req.Timeout         <- 300_000
              req.ProtocolVersion <- HttpVersion.Version10
              req.Method          <- "POST"
              req.ContentType     <- "application/json"
              req.Headers.Add("x-websharper-rpc", method            )
              let postBytes = Encoding.ASCII.GetBytes(data)
              req.ContentLength <- int64 postBytes.Length
              let reqStream = req.GetRequestStream() 
              reqStream.Write(postBytes, 0, postBytes.Length);
              reqStream.Close()
              
              // Obtain response and download the resulting page 
              // (The sample contains the first & last name from POST data)
              use resp   = req.GetResponse() 
              use stream = resp.GetResponseStream() 
              use reader = new StreamReader(stream)
              let msg    = reader.ReadToEnd()
              //printfn "RpcCallResponse %s" (extract 100 msg)
              let json   = JsonValue.Parse msg
              return       json.["$DATA"]
          }
      
      let serializeAddressId aId =
          match aId with
          | AddressId v -> sprintf """{"$":0,"$0":"%s"}""" v
      
      let sendRequestRpc (toId: AddressId) (fromId: AddressId) (content: string): Async<string> =
          async {
              let! msg =
                  [| serializeAddressId toId ; serializeAddressId fromId ; Json.Serialize content |]
                  |> String.concat ", "
                  |> sprintf "[%s]"
                  |> RpcCall WebSharper.Remoting.EndPoint "Remote:CIPHERPrototype.Messaging.sendRequest:1096816393"
              return msg.AsString()
          }
      
      let awaitRequestForRpc (listener:AddressId) =
          async {
              let! msg =
                  [| serializeAddressId listener |]
                  |> String.concat ", "
                  |> sprintf "[%s]"
                  |> RpcCall WebSharper.Remoting.EndPoint "Remote:CIPHERPrototype.Messaging.awaitRequestFor:278590570"
              let  v = msg.["$V"]
              let req    =
                  {
                      toId      = AddressId <| v?toId  .["$V"].["$0"].AsString()
                      fromId    = AddressId <| v?fromId.["$V"].["$0"].AsString()
                      content   = v?content                          .AsString()
                      messageId = Some <| v?messageId  .["$V"].["$0"].AsGuid  ()
                  }
              return req
          }
      
      let replyToRpc (reply:Guid) response =
          async {
              let! msg =
                  [| sprintf "\"%s\"" <| reply.ToString() ; Json.Serialize response |]
                  |> String.concat ", "
                  |> sprintf "[%s]"
                  |> RpcCall WebSharper.Remoting.EndPoint "Remote:CIPHERPrototype.Messaging.replyTo:-1092841374"
              return ()
          }
      
    //# 1 @"(4)6568955e-6aa8-4f8f-b93f-b7e97622c677 FsTranslator.fsx"
    module FsTranslator =
      //# 1 @"(6)b7c2d8cd-7246-4ad1-af46-ffbb7acde6e0 TranslatorError.fsx"
      //#r "FSharp.Compiler.Service.dll"
      open Microsoft.FSharp.Compiler.SourceCodeServices
      open Microsoft.FSharp.Compiler
      open Useful
      
      type TranslatorError =
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
      
      let getIndentFile input =
          match input with
          | Regex "^\\((\\d+)\\)\\s(.*)$" [_ ; indent ; file] -> int indent, file
          | _                                                 -> 0         , input
      
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
          
      let extractConfig (code:string[]) = if code.[0].StartsWith "////-d:" then code.[0].[4..] else ""
      
      
    //# 1 @"(4)63eca270-405a-4789-941a-e298bbd265bd FsStationShared.fsx"
    #if WEBSHARPER
    [<WebSharper.JavaScript>]
    #endif
    module FsStationShared =
    
      //# 1 @"(6)eb54ba64-3d11-4347-97c8-aeae9e3e3121 MessagingClient.fsx"
      #if FSS_SERVER
      #else
      
      //#r "remote.dll"
      open CIPHERPrototype.Messaging
      #endif
      
      open WebSharper
      open Useful
      open UsefulNoWS
      
      
      #if WEBSHARPER
      [< Inline "true" >]
      #endif          
      let inJavaScript = false
      
      let selectF fj fn =
          match inJavaScript with
          | true  -> fj
          | false -> fn
          
      #if WEBSHARPER
      let AsyncStart asy     = Async.StartWithContinuations(asy, id, (fun e -> JS.Alert(e.ToString()) ), fun c -> JS.Alert(c.ToString()))    
      [< Inline "" >]
      let awaitRequestForRpc = awaitRequestForRpc
      [< Inline "" >]
      let sendRequestRpc     = sendRequestRpc
      [< Inline "" >]
      let replyToRpc         = replyToRpc
      #else
      let AsyncStart asy = Async.Start asy
      #endif          
      
      let AddressId = AddressId
      
      let awaitRequestForF = selectF awaitRequestFor awaitRequestForRpc
      let sendRequestF     = selectF sendRequest         sendRequestRpc
      let replyToF         = selectF replyTo                 replyToRpc
      let AsyncStartF      = selectF AsyncStart             Async.Start
      
      type MessagingClient(clientId, ?timeout, ?endPoint:string) =
          let wsEndPoint = endPoint    |> Option.defaultValue "http://localhost:9000/FSharpStation.html"
          let tout       = timeout     |> Option.defaultValue 100_000
          let fromId     = AddressId clientId
          do WebSharper.Remoting.EndPoint <- wsEndPoint 
          let awaitMessage respond =
              async {
                  while true do
                      printfn "%s awaitRequest %s" (nowStamp()) clientId
                      let! msgA  = Async.StartChild(awaitRequestForF fromId, tout)
                      try
                          let! msg   = msgA
                          let! resp  = respond clientId msg.content
                          do!          replyToF msg.messageId.Value resp
                      with 
                      | :? System.TimeoutException -> ()
                      | e                          -> printfn "%A" e
              } 
              |> AsyncStartF
          let sendMessage  toId msg = sendRequestF toId fromId msg
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
      open Useful
      open FsTranslator
      open System.IO
      open Microsoft.FSharp.Compiler.SourceCodeServices
      
      let prepOptions (options:CompOptions) (code, assembs, defines, prepoIs, nowarns) =
          let  code2 =
             [
                yield! nowarns |> Seq.distinct |> Seq.map (sprintf "#nowarn \"%s\"")
                yield! code 
             ] |> String.concat "\n"
          let  fileName = options?Filename
          do   File.WriteAllText(fileName, code2)
          let  options2 = 
               options  + [|
                             yield! prepoIs |> Array.map ((/=) opIOption  ) 
                             yield! assembs |> Array.map ((/=) opReference)
                             yield! defines |> Array.map ((/=) opDefine   )
                             if options.Contains "++staticlinkall" then 
                                 yield! assembs |> Array.map (Path.GetFileNameWithoutExtension >> ((+) "staticlink:") >> ((/=) opGenFSharp2 ))         
                          |]
          if options.Contains "++showoptions"    then printfn "%s" (options2.Get (fun _ -> true) |> String.concat "\n")               
          if options.Contains "++copyassemblies" then 
              assembs |> Array.iter (fun f -> Path.GetDirectoryName(fileName) |> copyIfMustToDir f)      
          options2
          
      type CodeSnippet with
          static member PrepareCompileOptions (options1: CompOptions) (snps: CodeSnippet seq) =
              let  addLinePrepos =  options1.Contains "++removelinedirectives" |> not
              let  lines, code, assembs, defines, prepoIs, nowarns = CodeSnippet.ReducedCode addLinePrepos snps
              let  options2      = prepOptions options1 (code, assembs, defines, prepoIs, nowarns)
              options2
      
      let dllOptions     = CompOptions [| opTarget      /= "library"                                                                     |]  
      let exeOptions     = CompOptions [| opTarget      /= "exe"     ; opGenInternal /= "copyassemblies" ; opGenInternal /= "copyconfig" |]
      let winExeOptions  = CompOptions [| opTarget      /= "winexe"  ; opGenInternal /= "copyassemblies" ; opGenInternal /= "copyconfig" |]
      
      let genericOptions = 
        CompOptions
          [|
             opSnippet     /= "Test"
             opName        /= fun os -> (os?Snippet : string).Split('/') |> Array.last
             opDirectory   /= fun os -> "Compiled" +/+ os?Name
             opExtension   /= fun os -> match os?Target with | "library" -> "dll" | _ -> "exe"
             opFileName    /= fun os -> os?Directory +/+ os?Name + ".fs"
             opSource      /= fun os -> os?Filename
             opOutput      /= fun os -> System.IO.Path.ChangeExtension(os?Source, os?Extension)
             opConfig      /= fun os -> os?Output + ".config"
          |]
          
      let siteOptions =
        CompOptions
          [|
             opGenWSharper /= "ws:Site"
             opWebSite     /= fun os -> os?Directory +/+ "website"
             opGenWSharper /= fun os -> sprintf "project:%s"  os?Name
          |] 
       
      let debugOptions = 
        CompOptions
          [|
             opDebug       /= "full"
             opDefine      /= "DEBUG"
             opDefine      /= "TRACE"
             opGenFSharp2  /= "optimize-"
             opGenFSharp2  /= "tailcalls-"
          |]
      
      let otherOptions =
        CompOptions
          [|
             opGenFSharp1  /= "g"
             //@"--noframework"
             opGenFSharp2  /= "warn:3"
             opGenFSharp2  /= "warnaserror:76"
             opGenFSharp2  /= "vserrors"
             opGenFSharp2  /= "utf8output"
             opGenFSharp2  /= "fullpaths"
             opGenFSharp2  /= "flaterrors"
             opGenFSharp2  /= "subsystemversion:6.00"
             opGenFSharp2  /= "highentropyva+"
             opGenInternal /= "showoptions"
             opGenInternal /= "removelinedirectives"
          |]
      
      let compileOptionsDllDebug (snp:string) = 
          genericOptions
          + dllOptions
          + siteOptions
          + debugOptions
          + otherOptions
          + opSnippet     /= snp
          
      let compileOptionsExeDebug    snp = compileOptionsDllDebug snp + exeOptions   
      let compileOptionsWinExeDebug snp = compileOptionsDllDebug snp + winExeOptions
          
      type FsStationClient with
          member this.PrepareCompileOptions(options1) = 
              Wrap.wrapper {
                  let  snpPath   = options1?Snippet
                  let!   preds   = this.RequestPreds snpPath
                  let    options = CodeSnippet.PrepareCompileOptions options1 preds
                  return options
              }
          member this.CompileSnippetW(options1, printMsgs) = 
              Wrap.wrapper {
                  let  snpPath   = options1?Snippet
                  //printMsgs <| sprintf "Compiling %s ..." snpPath
                  let  directory = options1?Directory
                  let  config    = options1?Config
                  do   Directory.CreateDirectory(directory) |> ignore
                  let! options2   = this.PrepareCompileOptions options1
                  let! msgs, stat = options2.Get CompOptions.FSharpOptions 
                                    |> Array.append [| "IGNORED" |] 
                                    |> FSharpChecker.Create().Compile
                  let! res = Result.succeedWithMsgs () (msgs |> Array.map fSharpError2TranspilerError |> Seq.toList)
                  if options2.Contains "++copyassemblies" then copyIfMustToDir        "FSharp.Core.dll"      directory
                  if options2.Contains "++copyconfig"     then copyIfNotExistsToFile  "WebServer.exe.config" config
                  return res
              }
          member this.CompileSnippetW options  = this.CompileSnippetW(options,  printfn "%s")
          member this.CompileWsSiteW options1 =
              Wrap.wrapper {
                  let  snpPath   = options1?Snippet
                  let  site      = options1?Website
                  let  dest      = options1?Directory
                  let  config    = options1?Config
                  do   Directory.CreateDirectory(site) |> ignore
                  let! options2  = this.PrepareCompileOptions options1
                  do!  options2.Get CompOptions.WSharperOptions
                       |> Seq.map (sprintf "%A")
                       |> String.concat "  "
                       |> fun ops -> (new ShellEx(@"..\..\Common\packages\Zafir.FSharp\tools\WsFsc.exe", ops)).StartAndWait()
                  if options2.Contains "++copyassemblies" then copyIfMustToDir        "FSharp.Core.dll"      dest
                  if options2.Contains "++copyconfig"     then copyIfNotExistsToFile  "WebServer.exe.config" config
              }
      
  //# 1 @"(2)7479dc9d-94cd-4762-a1b8-cf6e09436c3f WebSharper Code.fsx"
  //#define WEBSHARPER
  (*
   Code to be Compiled to Javascript and run in the browser
   using `Compile WebSharper` or `Run WebSharper`
  *)
  
    //# 1 @"(4)5035c5c2-a9d2-49eb-a26c-e0a9637e1af0 FSharpStationServer.fsx"
    
      //# 1 @"(6)5e8209e0-9203-4fe0-8289-fb4579b24038 compile & run FSharpStation.fsx"
      open System.IO
      open FsStationShared
      open Useful
      
      Wrap.wrapper {
          let  options   = compileOptionsExeDebug "FSSGlobal/WebSharper Code/FSharpStationServer/FSharpStation"
          let  exeFile   = options?Output
          let  site      = Path.GetFullPath(options?Website)
          do!  FsStationClient("Compile WebSharper").CompileWsSiteW options
          do   printfn     "Starting %s"     exeFile
          let  url       = @"http://localhost:9010/"
          let  parms     = sprintf "%A %A" site url 
          do   runProcess  exeFile parms |> ignore
          do   runProcess  url     ""    |> ignore
      } |> Wrap.runSynchronously (printfn "%s")
      