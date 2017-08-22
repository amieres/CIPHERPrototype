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
#r @"remote.dll"
#r @"Compiled\FSharp.Compiler.Service.dll"
#r @"ZafirTranspiler.dll"
# 1 "required for nowarns to work"
#nowarn "1182"
#nowarn "40"
#nowarn "1178"
#nowarn "52"
# 1 @"bf864f3c-1370-42f2-ac8a-565a604892e8 FSSGlobal.fsx"
//#nowarn "1182"
//#nowarn "40"
//#r @"D:\Abe\CIPHERWorkspace\CIPHERPrototype\WebServer\bin\FSharp.Core.dll"
#if INTERACTIVE
//#I @"../WebServer/bin"
module FSSGlobal   =
#else
namespace FSSGlobal
#endif

  # 1 @"(2)edbbf11e-4698-4e33-af0c-135d5b21799b F# Code.fsx"
  // Code to be evaluated using FSI: `Evaluate F#`
    # 1 @"(4)60bffe71-edde-4971-8327-70b9f5c578bb open WebSharper.fsx"
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
    # 1 @"(4)7c4a82bc-58cd-48a7-bd7e-79de148a1cf0 Useful.fsx"
    #if WEBSHARPER
    [<WebSharper.JavaScript>]
    #endif
    module Useful =
      # 1 @"(6)368caae7-6a67-4063-9af3-978c25b81ac2 Result, Wrap.fsx"
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
              sprintf "%d errors, %d warnings\n%s"
              <| errors  .Length
              <| warnings.Length
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
          #else
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
          #endif
      
      type Wrap<'T> with
          #if WEBSHARPER
          [<JavaScript>]
          #endif
          static member Start           (w:Wrap<_   >,           ?cancToken) = Async.Start           (Wrap.getAsync  w,                                ?cancellationToken= cancToken)
          #if WEBSHARPER
          [<JavaScript>]
          #endif
          static member StartAsTask     (w:Wrap<'T  >, ?options, ?cancToken) = Async.StartAsTask     (Wrap.getAsyncR w, ?taskCreationOptions= options, ?cancellationToken= cancToken)
          #if WEBSHARPER
          #else
          static member RunSynchronously(w:Wrap<'T  >, ?timeout, ?cancToken) = Async.RunSynchronously(Wrap.getAsyncR w, ?timeout            = timeout, ?cancellationToken= cancToken)
          #endif
      
      # 1 @"(6)7a655466-e218-4121-a7b6-f9c70a922e07 extract, now, Async.fsx"
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
      # 1 @"(6)218507eb-4a87-4c11-b5d9-53a2213dd36a Regex.fsx"
      #if WEBSHARPER
      
      let (|REGEX|_|) (expr: string) (opt: string) (value: string) =
          if value = null then None else
          try 
              match JavaScript.String(value).Match(RegExp(expr, opt)) with
              | null         -> None
              | [| |]        -> None
              | m            -> Some m
          with e -> None
          
      #else
      
      //#r @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.1\System.dll"
      open System.Text.RegularExpressions
      
      let (|Regex|_|) pattern input =
          if input = null then None else
          try 
              let m = Regex.Match(input, pattern)
              if m.Success then Some(List.tail [ for g in m.Groups -> g.Value ])
              else None
          with e -> None
      
      #endif
      # 1 @"(6)8efdcd5a-95c4-4212-9c75-1ebedce83dd8 memoize.fsx"
      #if WEBSHARPER
      [< Inline >]
      #endif
      let memoize f = 
          let cache = System.Collections.Generic.Dictionary<_, _>()
          fun x -> 
              let mutable res = Unchecked.defaultof<_>
              let ok = cache.TryGetValue(x, &res)
              if ok then res 
              else let res = f x
                   cache.[x] <- res
                   res
                   
      type ResetableMemoize(f) =             
          let cache = System.Collections.Generic.Dictionary<_, _>()
          member this.ClearCache() = cache.Clear()
          #if WEBSHARPER
          [< Inline >]
          #endif
          member this.Call x =
              let mutable res = Unchecked.defaultof<_>
              let ok = cache.TryGetValue(x, &res)
              if ok then res 
              else let res = f x
                   cache.[x] <- res
                   res
          
      # 1 @"(6)ace1fc12-3dfb-4db8-80c9-5bde1e7d0597 prepareFsCode.fsx"
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
      
      
    # 1 @"(4)63eca270-405a-4789-941a-e298bbd265bd FsStationShared.fsx"
    #if WEBSHARPER
    [<WebSharper.JavaScript>]
    #endif
    module FsStationShared =
    
      # 1 @"(6)2deb54e7-009e-4297-b2bc-1c86d04203a4 CodeSnippet.fsx"
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
      //        let addLinePs     = if not addLinePrepos  then  id      else  Array.append [| sprintf "# 1 @\"%s%s\"" prfx this.NameSanitized |] 
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
              let addLinePs     = if not addLinePrepos  then  id      else  Array.append [| sprintf "# 1 @\"%s%s\"" prfx this.NameSanitized |]
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
                  if addLinePrepos && (nowarns |> Seq.isEmpty |> not) then yield "# 1 \"required for nowarns to work\""
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
      //            if addLinePrepos && (nowarns |> Seq.isEmpty |> not) then yield "# 1 \"required for nowarns to work\""
      //            yield! nowarns |> Seq.distinct             |> Seq.map (sprintf "#nowarn \"%s\"")
      //        ], code, bySnippet
      //    static member CodeFsx0 addLinePrepos (cur, snippets) =
      //        let part1, part2, bySnippet = CodeSnippet.CodeParts addLinePrepos (Array.append snippets [| cur |])
      //        [ yield! part1 ; yield! part2 ] |> String.concat "\n"
      
      
      # 1 @"(6)eb54ba64-3d11-4347-97c8-aeae9e3e3121 MessagingClient.fsx"
      //#r "remote.dll"
      
      open CIPHERPrototype.Messaging
      
      //#r @"WebSharper.Core.dll"
      //#r @"WebSharper.Main.dll"
      //#r @"WebSharper.Web.dll"
      //#r @"Common.dll"
      
      open WebSharper
      open WebSharper.Remoting
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
      #if WEBSHARPER
                      let! msgA  = Async.StartChild(awaitRequestFor    fromId, tout)
      #else
                      let! msgA  = Async.StartChild(awaitRequestForRpc fromId, tout)
      #endif          
                      try
                          let! msg   = msgA
                          let! resp  = respond clientId msg.content
      #if WEBSHARPER
                          do!          replyTo    msg.messageId.Value resp
      #else
                          do!          replyToRpc msg.messageId.Value resp
      #endif              
                      with 
                      | :? System.TimeoutException -> ()
                      | e                          -> printfn "%A" e
              } 
      #if WEBSHARPER
              |> fun asy -> Async.StartWithContinuations(asy, id, (fun e -> JS.Alert(e.ToString()) ), fun c -> JS.Alert(c.ToString()))
      #else
              |> Async.Start
      #endif                
      #if WEBSHARPER
          let sendMessage  toId msg = sendRequest    toId fromId msg
      #else
          let sendMessage  toId msg = sendRequestRpc toId fromId msg
      #endif                
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
          
          
      
      
      # 1 @"(6)f6ebdffc-049c-4493-8de8-e32072419479 FSMessage,FSResponse.fsx"
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
      
      
      # 1 @"(6)5597a227-c983-46fc-87e2-cbe241faa279 FsStationClient.fsx"
      //#r @"WebSharper.Core.dll"
      //#r @"WebSharper.Main.dll"
      //#r @"WebSharper.Web.dll"
      //#r @"Common.dll"
      
      open WebSharper
      //open WebSharper.JavaScript
      open WebSharper.Remoting
      open CIPHERPrototype.Messaging
      //open Rop
      
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
          member this.SendMessage     (toId2, msg:FSMessage) = sendMsg toId2  msg    Result.succeed   
          member this.SendMessage     (       msg:FSMessage) = sendMsg toId   msg    Result.succeed   
          member this.RequestSnippet  (   snpPath:string   ) = sendMsg toId  (GetSnippet          (snpPath.Split '/'))    snippetResponse  
          member this.RequestCode     (   snpPath:string   ) = sendMsg toId  (GetSnippetCode      (snpPath.Split '/'))    stringResponse   
          member this.RequestJSCode   (   snpPath:string   ) = sendMsg toId  (GetSnippetJSCode    (snpPath.Split '/'))    stringResponseR  
          member this.RequestPreds    (   snpPath:string   ) = sendMsg toId  (GetSnippetPreds     (snpPath.Split '/'))    snippetsResponse 
          member this.RequestPredsById(     snpId          ) = sendMsg toId  (GetSnippetPredsById  snpId             )    snippetsResponse 
          member this.RequestWholeFile(                    ) = sendMsg toId   GetWholeFile                                stringResponse   
          member this.GenericMessage  (       txt:string   ) = sendMsg toId  (GenericMessage       txt               )    stringResponse   
          member this.FSStationId                            = fsIds
          member this.MessagingClient                        = msgClient    
          static member FSStationId_                         = "FSharpStation"
      
      
    # 1 @"(4)40789dbb-34ba-4490-96d0-d0c1848dfad6 FSAutoComplete.fsx"
    module FSAutoComplete =
      # 1 @"(6)e49f4514-9b78-4a39-8b30-7289648edbb5 Utils.fsx"
      //#r @"Compiled\FSharp.Compiler.Service.dll"
      open System.IO
      open System.Collections.Concurrent
      open System.Diagnostics
      open System
      //#nowarn "1182"
      //#nowarn "1178"
      //#nowarn "52"
      
      #if WEBSHARPER
      [<WebSharper.JavaScript>]
      #endif
      module Utils =
          
          type Result<'a> =
            | Success of 'a
            | Failure of string
          
          type Pos =
              { Line: int
                Col: int }
          
          type Range =
              { StartLine : int
                StartColumn : int
                EndLine : int
                EndColumn: int}
          
          type Document =
              { FullName : string
                LineCount : int
                GetText : unit -> string
                GetLineText0 : int -> string
                GetLineText1 : int -> string}
          
      
      # 1 @"(6)0ab13bad-870c-464e-9bb2-9735b826746a CommandResponse.fsx"
      #if WEBSHARPER
      [<WebSharper.JavaScript>]
      #endif
      module CommandResponse =
        # 1 @"(8)4f394f9e-3597-40dc-b5e0-4c89808dd0ae CommandResponseTypes.fsx"
        open Utils
        
        type Location =
          {
            File: string
            Line: int
            Column: int
          }
        type CompletionResponse =
          {
            Name: string
            ReplacementText: string
            Glyph: string
            GlyphChar: string
          }
        //type ProjectResponse =
        //  {
        //    Project: ProjectFilePath
        //    Files: List<SourceFilePath>
        //    Output: string
        //    References: List<ProjectFilePath>
        //    Logs: Map<string, string>
        //  }
        type OverloadDescription =
          {
            Signature: string
            Comment: string
          }
        type OverloadParameter =
          {
            Name : string
            CanonicalTypeTextForSorting : string
            Display : string
            Description : string
          }
        type Overload =
          {
            Tip : OverloadDescription list list
            TypeText : string
            Parameters : OverloadParameter list
            IsStaticArguments : bool
          }
        type MethodResponse =
          {
            Name : string
            CurrentParameter : int
            Overloads : Overload list
          }
        type SymbolUseRange =
          {
            FileName: string
            StartLine: int
            StartColumn: int
            EndLine: int
            EndColumn: int
            IsFromDefinition: bool
            IsFromAttribute : bool
            IsFromComputationExpression : bool
            IsFromDispatchSlotImplementation : bool
            IsFromPattern : bool
            IsFromType : bool
          }
        type SymbolUseResponse =
          {
            Name: string
            Uses: SymbolUseRange list
          }
        type HelpTextResponse =
          {
            Name: string
            Overloads: OverloadDescription list list
          }
        type CompilerLocationResponse =
          {
            Fsc: string
            Fsi: string
            MSBuild: string
          }
        type FSharpErrorInfo =
          {
            FileName: string
            StartLine:int
            EndLine:int
            StartColumn:int
            EndColumn:int
           // Severity:FSharpErrorSeverity
            Message:string
            Subcategory:string
          }
        type ErrorResponse =
          {
            File: string
            Errors: FSharpErrorInfo []
          }
        type Colorization =
          {
            Range: Range
            Kind: string
          }
        type Declaration =
          {
            UniqueName: string
            Name: string
            Glyph: string
            GlyphChar: string
            IsTopLevel: bool
            Range     : Utils.Range
            BodyRange : Utils.Range
            File : string
            EnclosingEntity: string
            IsAbstract: bool
          }
        type DeclarationResponse = {
            Declaration : Declaration;
            Nested : Declaration []
        }
        type OpenNamespace = {
          Namespace : string
          Name : string
          Type : string
          Line : int
          Column : int
          MultipleNames : bool
        }
        type QualifySymbol = {
          Name : string
          Qualifier : string
        }
        type ResolveNamespaceResponse = {
          Opens : OpenNamespace []
          Qualifies: QualifySymbol []
          Word : string
        }
        type UnionCaseResponse = {
          Text : string
          Position : Pos
        }
        type Kind = 
        | KInfo             of string
        | KError            of string
        | KHelpText         of HelpTextResponse
        | KCompletion       of CompletionResponse  []
        | KSymbolUse        of SymbolUseResponse
        | KHelp             of string
        | KMethod           of MethodResponse
        | KErrors           of ErrorResponse
        | KColorizations    of Colorization list
        | KFindDecl         of Location
        | KDeclarations     of DeclarationResponse []
        | KToolTip          of OverloadDescription []
        | KTypeSig          of string
        | KCompilerLocation of CompilerLocationResponse
        | KNamespaces       of ResolveNamespaceResponse
        | KUnionCase        of UnionCaseResponse
        | KMultiple         of Kind                []
        
        type ACMessage =
        | ACMIdentification
        | ACMEcho      of string
        | ACMToolTip   of string * int * int
        | ACMToolTip2  of string * int * int *  string
        | ACMComplete  of string * int * int
        | ACMComplete2 of string * int * int *  string
        | ACMParse     of string * string    * (string * (int * int * int)) []
        | ACMMustParse of string * string
        
      # 1 @"(6)08e9600a-804b-4aba-a262-85f22e0cc8de FSAutoCompleteClient.fsx"
      open Useful
      open CIPHERPrototype.Messaging
      open FsStationShared
      open CommandResponse
      open WebSharper
      open WebSharper.Remoting
      
      #if WEBSHARPER
      [<WebSharper.JavaScript>]
      #endif
      type FSAutoCompleteClient(clientId) =
           let msgClient = MessagingClient(clientId)
           let toId      = AddressId "FSAutoComplete"
           let sendMessage (msg:ACMessage) =
               Wrap.wrapper {
                   let! resp = msgClient.SendMessage toId (Json.Serialize msg)
                   let  acr  = resp |> Json.Deserialize<CommandResponse.Kind>
                   return acr
               } |> Wrap.getAsyncWithDefault (Result.getMessages >> CommandResponse.KError)
           let Async_map f aa = 
               async { 
                   let! a = aa
                   return f a
               }
           let rec comp2Strings comp =
               match comp with 
               | KCompletion cs -> cs |> Array.map (fun cs -> cs.Name, cs.ReplacementText, cs.Glyph, cs.GlyphChar)
               | KHelpText   _  -> [||]
               | KMultiple   ks -> ks |> Array.collect comp2Strings 
               | m              -> [| sprintf "%A" m, "", "ErrorMsg", "E" |] 
           let tip2String tip =
               match tip with 
               | KToolTip ts -> ts |> Seq.collect (fun t -> [ t.Signature ; t.Comment ] ) |> String.concat "\n"
               | m           -> sprintf "%A" m 
           let errors2String errs =
               match errs with 
               | KErrors  es -> 
                   es.Errors 
                   |> Seq.map (fun er -> sprintf "ErrFSharp \"F# %s.fsx (%d,%d) - (%d,%d) %s:%s\"" 
                                            er.FileName er.StartLine er.StartColumn er.EndLine er.EndColumn er.Subcategory er.Message) 
                   |> String.concat "\n"
               | m           -> sprintf "%A" m 
           let info2Bool inf =
               match inf with
               | KInfo "true" -> true
               | _            -> false
              
         with
           member this.MustParse(fname,            sId) = sendMessage (ACMMustParse(fname,             sId)) |> Async_map info2Bool
           member this.Parse    (fname, txt , sts     ) = sendMessage (ACMParse    (fname, txt , sts      )) |> Async_map errors2String
           member this.Parse    (fname, txt           ) = sendMessage (ACMParse    (fname, txt , [||]     )) |> Async_map errors2String
           member this.ToolTip  (fname, line, col     ) = sendMessage (ACMToolTip  (fname, line, col      )) |> Async_map tip2String
           member this.ToolTip  (fname, line, col, sId) = sendMessage (ACMToolTip2 (fname, line, col , sId)) |> Async_map tip2String
           member this.Complete (fname, line, col     ) = sendMessage (ACMComplete (fname, line, col      )) |> Async_map comp2Strings
           member this.Complete (fname, line, col, sId) = sendMessage (ACMComplete2(fname, line, col , sId)) |> Async_map comp2Strings
      
  # 1 @"(2)7479dc9d-94cd-4762-a1b8-cf6e09436c3f WebSharper Code.fsx"
  //#define WEBSHARPER
  (*
   Code to be Compiled to Javascript and run in the browser
   using `Compile WebSharper` or `Run WebSharper`
  *)
  
    # 1 @"(4)495bce0a-4fb6-48fa-9158-c242d5965baa HtmlNode.fsx"
    
    [<JavaScript>]
    module HtmlNode      =
    
      # 1 @"(6)0f5719f0-e95e-498d-ab88-f89ff1440e32 Val.fsx"
      [<NoComparison>]
      type Val<'a> =
          | Constant  of 'a
          | DynamicV  of IRef<'a>
          | Dynamic   of View<'a>
      
      module Val =
          
          let mapV : ('a -> 'b) -> Val<'a> -> Val<'b> =
              fun    f             va      ->
                  match va with
                  | Constant  a -> f a                   |> Constant
                  | Dynamic  wa -> wa      |> View.Map f |> Dynamic 
                  | DynamicV va -> va.View |> View.Map f |> Dynamic 
      
          let iterV : ('a -> unit) -> Val<'a> -> unit = //f v = toView v |> View.Get f
              fun     f               va      ->
                  match va with
                  | Constant  a ->          f  a                  
                  | Dynamic  wa -> View.Get f wa 
                  | DynamicV va ->          f va.Value 
      
          let toView v =
              match v with
              | Constant  a -> View.Const a
              | Dynamic  wa -> wa
              | DynamicV va -> va.View
      
          let bindV : ('a -> Val<'b>) -> Val<'a> -> Val<'b> =
              fun     f                  v       -> 
                  match v with
                  | Constant  a -> f a
                  | Dynamic  wa -> wa      |> View.Bind (f >> toView) |> Dynamic 
                  | DynamicV va -> va.View |> View.Bind (f >> toView) |> Dynamic 
      
          let inline map2V f = // : ('a -> 'b -> 'c) -> Val<'a> -> Val<'b> -> Val<'c> =
              //fun     f                ->
              let inline swap f a b = f b a
              let inline fv vb = bindV (swap (f >> mapV) vb)
              swap fv
      
          let inline map3V f3 v1 v2 v3    = map2V f3 v1 v2    |> map2V (|>) v3
          let inline map4V f3 v1 v2 v3 v4 = map3V f3 v1 v2 v3 |> map2V (|>) v4
          
          let tagDoc: ('a -> Doc) -> Val<'a> -> Doc =
              fun     tag            va      ->
                  match va with
                  | Constant  a -> tag   a
                  | Dynamic  wa -> wa      |> View.Map tag |> Doc.EmbedView
                  | DynamicV va -> va.View |> View.Map tag |> Doc.EmbedView
      
          let tagElt: ('a -> Elt) -> Val<'a> -> Doc =
              fun     tag            va     ->
                  match va with
                  | Constant  a -> tag   a :> Doc
                  | Dynamic  wa -> wa     |> View.Map tag |> Doc.EmbedView
                  | DynamicV va -> va.View |> View.Map tag |> Doc.EmbedView
      
          let attrV att       va      =
                  match va with
                  | Constant  a -> Attr.Create  att   a
                  | Dynamic  wa -> Attr.Dynamic att  wa
                  | DynamicV va -> Attr.Dynamic att  va.View
      
      
          type HelperType = HelperType with
              static member inline (&>) (HelperType, a : string      ) = Constant  a
              static member (&>) (HelperType, a : bool        ) = Constant  a
              static member (&>) (HelperType, a : int         ) = Constant  a
              static member (&>) (HelperType, a : float       ) = Constant  a
              static member (&>) (HelperType, a : Doc         ) = Constant  a
              static member (&>) (HelperType, va: Val<string> ) =          va
              static member (&>) (HelperType, va: Val<bool  > ) =          va
              static member (&>) (HelperType, va: Val<int   > ) =          va
              static member (&>) (HelperType, va: Val<float > ) =          va
              static member (&>) (HelperType, va: Val<Doc   > ) =          va
              static member (&>) (HelperType, va: Val<_     > ) =          va
              static member (&>) (HelperType, vr: IRef<_    > ) = DynamicV vr
              static member (&>) (HelperType, vw: View<_    > ) = Dynamic  vw
      
          [< Inline @"(
                  typeof($v) == 'function' ? {$:2, $0:$v} // View
                  :   typeof($v) == 'object'
                            ? typeof($v.$) != 'undefined' // Val
                                  ? $v 
                                  : typeof($v.Id) == 'number' || typeof($v.i) == 'number' || typeof($v.RView == 'function')// Var
                                       ? {$:1, $0:$v}
                                       : typeof($v.docNode) != 'undefined'
                                           ? {$:0, $0:$v} // Doc
                                           : {$:2, $0:$v} // View?
                            : {$:0, $0:$v}) // other
                                           " >]
          let fixit0 v = Constant v
          let fixit2 v = let result = fixit0 v
                         result
                         
          [< Direct "FSSGlobal.HtmlNode.Val.fixit2($v)" >]
          //[< Inline >]
          let inline fixit v = HelperType &> v
      
          [< Inline >]
          let inline bindIRef0 (f: 'a->IRef<'b>) (view: View<'a>) = 
              let contentVar = Var.Create Unchecked.defaultof<'b>
              let changingIRefO : IRef<'b> option ref = ref None
              let contentVarChanged = ref 0L
              let refVarChanged     = ref 0L
          
              contentVar.View 
              |> View.Sink (fun _ -> 
                  !changingIRefO 
                  |> Option.iter (fun r -> 
                      if  !contentVarChanged  > !refVarChanged   then refVarChanged := !contentVarChanged
                      elif r.Value           <> contentVar.Value then refVarChanged := !refVarChanged       + 1L ; r.Value         <-  contentVar.Value
                     )
                 )
          
              view |> View.Bind (fun cur ->
                  let r = f cur
                  changingIRefO    := Some r
                  refVarChanged    := !contentVarChanged + 100L
                  contentVar.Value <- r.Value
                  r.View
              ) |> View.Sink (fun _ -> 
                  !changingIRefO 
                  |> Option.iter (fun r -> 
                      if  !refVarChanged  > !contentVarChanged then contentVarChanged := !refVarChanged
                      elif r.Value       <> contentVar.Value   then contentVarChanged := !contentVarChanged + 10L; contentVar.Value  <-  r.Value
                     )
                  )
              contentVar
          
          let inline toDoc       v           = toView      (fixit v ) |> Doc.EmbedView
          [< Inline >]
          let inline bindIRef f  v           = bindIRef0 f (fixit v   |> toView)
          let inline iter     f  v           = iterV     f (fixit v )
          let inline bind     f  v           = bindV     f (fixit v )
          let inline map      f  v           = mapV      f (fixit v )
          let inline map2     f  v1 v2       = map2V     f (fixit v1) (fixit v2)
          let inline map3     f  v1 v2 v3    = map3V     f (fixit v1) (fixit v2) (fixit v3)
          let inline map4     f  v1 v2 v3 v4 = map4V     f (fixit v1) (fixit v2) (fixit v3) (fixit v4)
          let inline sink     f  v           = fixit v |> toView |> View.Sink f
      
          let inline iter2    f  v1 v2       = map2      f v1 v2       |> iterV id
          let inline iter3    f  v1 v2 v3    = map3      f v1 v2 v3    |> iterV id
          let inline iter4    f  v1 v2 v3 v4 = map4      f v1 v2 v3 v4 |> iterV id
      
      # 1 @"(6)d9124644-0af6-4a7f-a711-ef76ca77f0de HtmlNode.fsx"
      [<NoComparison ; NoEquality>]
      type HtmlNode =
          | HtmlElement   of name: string * children: HtmlNode seq
          | HtmlAttribute of name: string * value:    Val<string>
          | HtmlText      of Val<string>
          | HtmlEmpty
          | HtmlElementV  of Val<HtmlNode>
          | SomeDoc       of Doc
          | SomeAttr      of Attr
          
      let addClass    (classes:string) (add:string) = classes.Split ' ' |> Set.ofSeq |> Set.union  (Set.ofSeq <| add.Split ' ') |> String.concat " "
      let removeClass (classes:string) (rem:string) = classes.Split ' ' |> Set.ofSeq |> Set.remove               rem            |> String.concat " "
      
      let callAddClass = addClass "a" "b" // so that WebSharper.Collections.js is included
      
      let inline chooseAttr node = 
          match node with
          | HtmlAttribute (name, value   ) when name <> "class" && name <> "style" 
                                           -> Some <| Val.attrV name value
          | SomeAttr             value     -> Some <|                value
          | _                              -> None
      
      let chooseThisAttr this node =
          match node with
          | HtmlAttribute (att, value) when att = this -> Some value
          | _                                          -> None
      
      let concat s a b = a + s + b
      let groupAttr name sep children = 
          children 
          |> Seq.choose (chooseThisAttr name)
          |> (fun ss -> if ss |> Seq.isEmpty 
                        then None 
                        else ss |> Seq.reduce (Val.map2 <| concat sep ) |> Val.attrV name |> Some)
      
      let inline getAttrsFromSeq children =
          children 
          |> Seq.choose chooseAttr
          |> Seq.append (List.choose id [ children |> groupAttr "class" " " ; children |> groupAttr "style" "; " ])
      
      let rec chooseNode node =
          match node with
          | HtmlElement (name, children) -> Some <| (Doc.Element name (getAttrsFromSeq children) (children |> Seq.choose chooseNode) :> Doc)
          | HtmlText     vtext           -> Some <| Val.tagDoc WebSharper.UI.Next.Html.text vtext
          | SomeDoc      doc             -> Some <| doc
          | HtmlElementV vnode           -> Some <| (vnode |> Val.toView |> Doc.BindView (chooseNode >> Option.defaultValue Doc.Empty))
          | _                            -> None
      
      let getAttrChildren attr =
          Seq.tryPick (function 
                      | HtmlAttribute(a, v) when a = attr -> Some v 
                      | _                                 -> None)
          >> Option.defaultValue (Constant "")
      
      let rec mapHtmlElement (f:string -> seq<HtmlNode> -> string * HtmlNode seq) (element:HtmlNode) :HtmlNode =
          match element with
          | HtmlElement (name, children) -> f name  children                    |> HtmlElement
          | HtmlElementV vnode           -> vnode |> Val.map (mapHtmlElement f) |> HtmlElementV
          | _                            -> element
      
      //let getAttr attr element =
      //    match element with
      //    | HtmlElement(_, children) -> children
      //    | _                        -> seq []
      //    |> getAttrChildren attr
      //
      //let getClass = getAttr "class"
      //let getStyle = getAttr "style"
      
      let replaceAttribute att (children: HtmlNode seq) newVal =
          HtmlAttribute(att, newVal)
          :: (children
              |> Seq.filter (function HtmlAttribute(old, _) when old = att -> false | _ -> true)
              |> Seq.toList
             )
      
      let replaceAtt att node newVal = mapHtmlElement (fun n ch -> n, replaceAttribute att ch newVal |> Seq.ofList) node
      
      type HtmlNode with
          member inline this.toDoc = 
              match this with
              | HtmlAttribute _
              | HtmlEmpty       -> Doc.Empty
              | _               -> chooseNode this |> Option.defaultValue Doc.Empty
          // member inline   this.Class          clas = Val.fixit clas |> replaceAtt "class" this
          member          this.AddChildren    add  = mapHtmlElement (fun n ch -> n, Seq.append ch  add ) this
          member          this.InsertChildren add  = mapHtmlElement (fun n ch -> n, Seq.append add ch  ) this
      
      let renderDoc = chooseNode >> Option.defaultValue Doc.Empty
          
      # 1 @"(6)c3755c07-1385-495d-bad7-a5b0fa54ac9b HTML Elements & Attributes.fsx"
      let inline atr att v = Val.attrV  att (Val.fixit v)
      let inline tag tag v = Val.tagDoc tag (Val.fixit v)
      
      let inline _class       v = atr "class"       v
      let inline _type        v = atr "type"        v
      let inline _style       v = atr "style"       v
      let inline _placeholder v = atr "placeholder" v
      let inline textV        v = tag  Html.text    v
      
      let inline htmlElement   name ch = HtmlElement  (name, ch           )
      let inline htmlAttribute name v  = HtmlAttribute(name, Val.fixit v  )
      let inline htmlText      txt     = HtmlText     (      Val.fixit txt)
      let inline someElt       elt     = SomeDoc      (elt :> Doc         )    
        
      let inline ul          ch = htmlElement   "ul"          ch
      let inline li          ch = htmlElement   "li"          ch
      let inline br          ch = htmlElement   "br"          ch
      let inline hr          ch = htmlElement   "hr"          ch
      let inline h1          ch = htmlElement   "h1"          ch
      let inline h2          ch = htmlElement   "h2"          ch
      let inline h3          ch = htmlElement   "h3"          ch
      let inline h4          ch = htmlElement   "h4"          ch
      let inline h5          ch = htmlElement   "h5"          ch
      let inline h6          ch = htmlElement   "h6"          ch
      let inline div         ch = htmlElement   "div"         ch
      let inline img         ch = htmlElement   "img"         ch
      let inline span        ch = htmlElement   "span"        ch
      let inline form        ch = htmlElement   "form"        ch
      let inline table       ch = htmlElement   "table"       ch
      let inline thead       ch = htmlElement   "thead"       ch
      let inline th          ch = htmlElement   "th"          ch
      let inline tr          ch = htmlElement   "tr"          ch
      let inline td          ch = htmlElement   "td"          ch
      let inline tbody       ch = htmlElement   "tbody"       ch
      let inline label       ch = htmlElement   "label"       ch
      let inline button      ch = htmlElement   "button"      ch
      let inline script      sc = htmlElement   "script"      sc
      let inline styleH      st = htmlElement   "style"       st
      let inline fieldset    ch = htmlElement   "fieldset"    ch
      let inline link        sc = htmlElement   "link"        sc
      let inline iframe      at = htmlElement   "iframe"      at
      let inline body        ch = htmlElement   "body"        ch
      
      
      let inline href        v  = htmlAttribute "href"        v
      let inline rel         v  = htmlAttribute "rel"         v
      let inline src         v  = htmlAttribute "src"         v
      let inline ``class``   v  = htmlAttribute "class"       v
      let inline ``type``    v  = htmlAttribute "type"        v
      let inline width       v  = htmlAttribute "width"       v
      let inline title       v  = htmlAttribute "title"       v
      let inline Id          v  = htmlAttribute "id"          v
      let inline frameborder v  = htmlAttribute "frameborder" v
      let inline spellcheck  v  = htmlAttribute "spellcheck"  v
      let inline draggable   v  = htmlAttribute "draggable"   v
      let inline style       v  = htmlAttribute "style"       v
      
      let inline style1    n v  = style <| Val.map ((+) (n + ":")) v
      
      type HtmlNode with
          member inline   this.Style          sty  = this.AddChildren([ style sty ])
      
      let inline css         v  = styleH [ htmlText v ] 
      
      let inline classIf cls v = ``class`` <| Val.map (fun b -> if b then cls else "") (Val.fixit v)
      
      let inline ``xclass`` v  = 
          match Val.fixit v with
          | Constant c  -> Attr.Class        c       
          | Dynamic  cw -> Attr.DynamicClass "class_for_view_not_implemented" cw      ((<>)"")
          | DynamicV cv -> Attr.DynamicClass cv.Value                         cv.View ((<>)"")
          |> SomeAttr
      
      let style2pairs (ss:string) : (string * string) [] =
          ss.Split(';') 
          |> Array.map   (fun s -> s.Split(':') ) 
          |> Array.filter(fun d -> d.Length = 2 )
          |> Array.map   (fun d -> d.[0].Trim(), d.[1].Trim() )
      
      let string2Styles = style2pairs >> Array.map (fun (n, v) -> Attr.Style n v |> SomeAttr)
      
      //let composeDoc elt dtl dtlVal = dtlVal |> Val.toView |> Doc.BindView (Seq.append dtl >> elt >> renderDoc) |> SomeDoc
      
      let inline bindHElem hElemF v  = Val.map hElemF  (Val.fixit v) |> HtmlElementV
      
      let createIFrame f =
          let cover = Var.Create true
          div [ style           "position: relative; overflow: hidden; height: 100%; width: 100%;" 
                iframe 
                  [ style       "position: absolute; width:100%; height:100%;"
                    frameborder "0"
                    SomeAttr <| on.afterRender f
                    SomeAttr <| on.mouseLeave (fun _ _ -> cover.Value <- true)
                  ]
                div 
                  [ style       "position: absolute;"
                    classIf     "iframe-cover" (Val.map id cover)               
                    SomeAttr <| on.mouseEnter (fun _ _ -> Input.Mouse.MousePressed 
                                                          |> View.Get (fun pressed -> if not pressed then cover.Value <- false))
                  ]          
                styleH [ htmlText ".iframe-cover { top:0; left:0; right:0; bottom:0; background: blue; opacity: 0.04; z-index: 2; }" ]
              ]
      
      [< Inline """(!$v)""">]
      let isUndefined v = true
      
      let  findRootElement (e:Dom.Element) =
          let root = e.GetRootNode()
          if isUndefined root?body 
          then root.FirstChild :?> Dom.Element
          else root?body  |> unbox<Dom.Element>
      
      # 1 @"(6)336d6f19-0c57-4af9-8716-1b3fbf6b112c let inline storeVar'T storeName (varIRef_) =.fsx"
      [< Inline >]
      let inline storeVar<'T> storeName (var:IRef<_>) =
          JS.Window.LocalStorage.GetItem storeName |> fun v -> if v <> null then           var.Value <- Json.Deserialize<'T> v
          Val.sink (fun v -> JS.Window.LocalStorage.SetItem (storeName, Json.Serialize v)) var
      
      
      # 1 @"(6)1f1aa135-fd74-42cc-b9a5-87f380c113a9 LoadFiles.fsx"
      [< Inline "CIPHERSpaceLoadFiles($files, $cb)" >]
      let LoadFiles (files: string []) (cb: unit -> unit) : unit = X<_>
    # 1 @"(4)3709b431-1507-48ed-9487-dd49ce7be748 open HtmlNode.fsx"
    open HtmlNode
    # 1 @"(4)e9ac2d66-474a-46a6-95fa-d369e6d703d1 Template.fsx"
    [<JavaScript>]
    module Template      =
      # 1 @"(6)5e1dd5fc-a27c-4b0d-821a-06cc8a27bb82 Button.fsx"
      [<NoComparison ; NoEquality>]
      type Button = {
          _class  : Val<string>
          _type   : Val<string>
          style   : Val<string>
          text    : Val<string>
          onClick : Dom.Element -> Dom.MouseEvent -> unit
          disabled: Val<bool>
          id      : string
      } with
        static member inline New txt = 
            { _class   = Val.fixit "btn" 
              _type    = Val.fixit "button" 
              style    = Val.fixit "" 
              text     = Val.fixit txt
              onClick  = fun _ _ -> ()
              disabled = Val.fixit false
              id       = ""
            }
        member        this.Render     =         
          button [ ``type``  <| this._type
                   ``class`` <| this._class
                   Id        <| this.id  
                   style     <| this.style
                   SomeAttr  <| attr.disabledDynPred (View.Const "") (this.disabled |> Val.toView)
                   SomeAttr  <| on.click <@ this.onClick @>
                   HtmlText  <| this.text 
                 ]
        member inline this.Id          id   = { this with id       = id             }
        member inline this.Class       clas = { this with _class   = Val.fixit clas }
        member inline this.Type        typ  = { this with _type    = Val.fixit typ  }
        member inline this.Style       sty  = { this with style    = Val.fixit sty  }
        member inline this.Text        txt  = { this with text     = Val.fixit txt  }
        member inline this.Disabled    dis  = { this with disabled = Val.fixit dis  }
        member inline this.OnClick     f    = { this with onClick  = f              }
      # 1 @"(6)29c4d6ae-2bb7-457a-ba64-fcb7cce96a30 Input.fsx"
      [<NoComparison ; NoEquality>]
      type Input = {
          _type       : Val<string>
          _class      : Val<string>
          style       : Val<string>
          placeholder : Val<string>
          id          : string
          var         : IRef<string>
          prefix      : HtmlNode
          suffix      : HtmlNode
          content     : Attr seq
          prefixAdded : bool
          suffixAdded : bool
      } with
        static member  New(var) = { _class      = Val.fixit "form-control" 
                                    _type       = Val.fixit "text" 
                                    style       = Val.fixit "" 
                                    placeholder = Val.fixit "Enter text:"
                                    id          = ""
                                    content     = []
                                    prefix      = HtmlEmpty
                                    prefixAdded = false
                                    suffix      = HtmlEmpty
                                    suffixAdded = false
                                    var         = var   
                                  }
        static member  New(v)   = Input.New(Var.Create v)
        member        this.Render    =         
          let groupClass det = match det with HtmlText _  -> "input-group-addon" | _ -> "input-group-btn"
          div [
              if this.prefixAdded || this.suffixAdded then
                  yield ``class`` "input-group"
              if this.prefixAdded then
                  yield  span     [ ``class`` <| groupClass this.prefix 
                                    this.prefix       ]
              yield Doc.Input ([_type            this._type
                                _class           this._class
                                _style           this.style
                                attr.id          this.id  
                                _placeholder     this.placeholder ] |> Seq.append this.content)
                                this.var
                    :> Doc |> SomeDoc
              if this.suffixAdded then
                  yield  span     [ ``class`` <| groupClass this.suffix 
                                    this.suffix       ]
            ]
        member inline this.Class       clas = { this with _class      = Val.fixit clas                  }
        member inline this.Type        typ  = { this with _type       = Val.fixit typ                   }
        member inline this.Style       sty  = { this with style       = Val.fixit sty                   }
        member inline this.Placeholder plc  = { this with placeholder = Val.fixit plc                   }
        member inline this.Id          id   = { this with id          =       id                        }
        member inline this.Content     c    = { this with content     =       c                         }
        member inline this.Prefix      p    = { this with prefix      =       p    ; prefixAdded = true }
        member inline this.Suffix      s    = { this with suffix      =       s    ; suffixAdded = true }
        member inline this.SetVar      v    = { this with var         = v                               }
        member inline this.Var              = this.var
      # 1 @"(6)c7841be7-5cd5-40f3-b91c-c107b487bc0c Hoverable.fsx"
      [<NoComparison ; NoEquality>]
      type Hoverable = {
          hover      : IRef<bool>
      } with
        static member  New   = 
          let hover      = Var.Create false
          { 
              hover      = hover     
          }
        member inline this.Content    (c: HtmlNode seq) = 
          [ classIf "hovering" this.hover
            SomeAttr <| on.mouseEnter (fun _ _ -> this.hover.Value <- true )
            SomeAttr <| on.mouseLeave (fun _ _ -> this.hover.Value <- false)
          ] 
          |> Seq.append  c
          |> div
        member inline this.Content    (c:HtmlNode) = 
            c.AddChildren 
                [ classIf "hovering" this.hover
                  SomeAttr <| on.mouseEnter (fun _ _ -> this.hover.Value <- true )
                  SomeAttr <| on.mouseLeave (fun _ _ -> this.hover.Value <- false)
                ] 
        static member  Demo  = Hoverable.New.Content(div [ style "flex-flow: column;" ])
      
      # 1 @"(6)3234a0bf-4541-4f2c-8bbf-b5ab3a0e415b TextArea.fsx"
      [<NoComparison ; NoEquality>]
      type TextArea = {
          _class      : Val<string>
          placeholder : Val<string>
          title       : Val<string>
          spellcheck  : Val<bool>
          id          : string
          var         : IRef<string>
      } with
        static member  New(var) = { _class      = Val.fixit "form-control"
                                    placeholder = Val.fixit "Enter text:"
                                    title       = Val.fixit ""
                                    spellcheck  = Val.fixit false
                                    id          = ""
                                    var         = var 
                                  }
        static member  New(v)   = TextArea.New(Var.Create v)
        member        this.Render    =    
          Doc.InputArea
              [ 
                _class              this._class
                attr.id             this.id  
                atr "spellcheck" <| Val.map (fun spl -> if spl then "true" else "false") this.spellcheck
                atr "title"         this.title
                atr "style"        "height: 100%;  width: 100%; box-sizing: border-box; "
                _placeholder        this.placeholder 
              ]
              this.var
          |> someElt 
          |> Seq.singleton 
          //|> Seq.append [ style "height: 100%;  width: 100%; box-sizing: border-box; " ] 
          |> div
        member inline this.Class       clas = { this with _class      = Val.fixit clas }
        member inline this.Placeholder plc  = { this with placeholder = Val.fixit plc  }
        member inline this.Title       ttl  = { this with title       = Val.fixit ttl  }
        member inline this.Spellcheck  spl  = { this with spellcheck  = spl            }
        member inline this.Id          id   = { this with id          = id             }
        member inline this.SetVar      v    = { this with var         = v              }
        member inline this.Var              = this.var
        
      # 1 @"(6)4180353c-9dc5-438d-862d-851539b02075 codeMirrorIncludes.fsx"
      let codeMirrorIncludes =
         [| "/EPFileX/codemirror/scripts/codemirror/codemirror.js"             
            "/EPFileX/codemirror/scripts/intellisense.js"                      
            "/EPFileX/codemirror/scripts/codemirror/codemirror-intellisense.js"
            "/EPFileX/codemirror/scripts/codemirror/codemirror-compiler.js"    
            "/EPFileX/codemirror/scripts/codemirror/mode/fsharp.js"            
            "/EPFileX/codemirror/scripts/addon/search/searchcursor.js"          
            "/EPFileX/codemirror/scripts/addon/search/search.js"          
            "/EPFileX/codemirror/scripts/addon/search/jump-to-line.js"          
            "/EPFileX/codemirror/scripts/addon/dialog/dialog.js"          
            "/EPFileX/codemirror/scripts/addon/edit/matchbrackets.js"          
            "/EPFileX/codemirror/scripts/addon/selection/active-line.js"       
            "/EPFileX/codemirror/scripts/addon/display/fullscreen.js"          
            "/EPFileX/codemirror/scripts/addon/hint/show-hint.js"          
            "/EPFileX/codemirror/scripts/addon/lint/lint.js"          
      //      "/EPFileX/codemirror/scripts/codemirror/mode/markdown.js"                 
         |]
      # 1 @"(6)b03ba35c-a03c-4bbe-a373-1ce551524e56 CodeMirror.fsx"
      type CodeMirrorPos = { line: int ; ch  : int }
      let inline cmPos(l, c) = { line = l ; ch  = c }
      
      type CodeMirrorEditor() =
          let a = 1
        with
          [< Inline "CodeMirror($elt, {
      	    theme        : 'rubyblue'
      	  , lineNumbers  : true
      	  , matchBrackets: true
            , gutters      : ['CodeMirror-lint-markers']
            , extraKeys    : {
      		    Tab  : function (cm) { cm.replaceSelection('    ', 'end'); }
      		  , 'F11': function (cm) { cm.setOption('fullScreen', !cm.getOption('fullScreen')); }
              }
      })"    >]
      //    [< Inline "setupEditor($elt)" >]
          static member SetupEditor elt                                     : CodeMirrorEditor = X<_>
          [< Inline "$this.getValue()"              >]      
          member this.GetValue()                                            : string           = X<_>
          [< Inline "$this.setValue($v)"            >]      
          member this.SetValue(v:string)                                    : unit             = X<_>
          [< Inline "$this.setOption($o, $v)"       >]      
          member this.SetOption(o:string, v:obj)                            : unit             = X<_>
          [< Inline "$this.getCursor()"             >]      
          member this.GetCursor()                                           : CodeMirrorPos    = X<_>
          [< Inline "$this.getLine($l)"             >]      
          member this.GetLine(l:int)                                        : string           = X<_>
          [< Inline "$this.getDoc().markText({line:$fl, ch:$fc}, {line:$tl, ch:$tc}, {className: $className, title: $title})" >]
          member this.MarkText (fl:int, fc:int) (tl:int, tc:int) (className: string) (title: string): unit       = X<_>
          [< Inline "while($this.getAllMarks().length > 0) { $this.getAllMarks()[0].clear() }" >]
          member this.RemoveMarks() : unit       = X<_>
          [< Inline "$this.getDoc().clearHistory()" >]
          member this.ClearHistory()                                        : unit             = X<_>
          [< Inline "$this.on($event, $f)"          >]
          member this.On(event: string, f:(CodeMirrorEditor * obj) -> unit) : unit             = X<_>
          [< Inline "$this.addKeyMap($keyMap)"      >]
          member this.AddKeyMap(keyMap: obj)                                : unit              = X<_>
          [< Inline "$this.getWrapperElement()"     >]
          member this.GetWrapperElement()                                   : Dom.Element       = X<_>
      
      [<NoComparison ; NoEquality>]
      type CodeMirror = {
          _class          : Val<string>
          style           : Val<string>
          id              : string
          var             : IRef<string>
          onChange        : (unit             -> unit)
          onRender        : (CodeMirrorEditor -> unit) option
          mutable editorO : CodeMirrorEditor option
      } with
      
        static member  New(var) = 
            { _class   = Val.fixit "" 
              style    = Val.fixit "" 
              id       = ""
              var      = var 
              onChange = ignore
              onRender = None
              editorO  = None
            }
        static member  New(v)   = CodeMirror.New(Var.Create v)
        member        this.Render    =
          div [ 
                ``class``            this._class
                SomeAttr <| attr.id  this.id 
                style "position: relative; height: 300px"
                style                this.style
                div [
                      style "height: 100%; width: 100%; position: absolute;"
                      SomeAttr <| on.afterRender (fun el ->
                        LoadFiles codeMirrorIncludes
                          (fun () ->                       
                             let editor = CodeMirrorEditor.SetupEditor el
                             this.editorO <- Some editor
                             this.onRender |> Option.iter (fun onrender -> onrender editor)
                             let editorChanged = ref 0L
                             let varChanged    = ref 0L
                             editor.On("changes", fun (cm, change) ->
                                 let v = editor.GetValue() 
                                 if this.var.Value <> v then editorChanged := !editorChanged + 1L; this.var.Value <- v; this.onChange() 
                             )
                             this.var.View |> View.Sink (fun _ ->
                                 if  !editorChanged      > !varChanged    then varChanged := !editorChanged
                                 elif editor.GetValue() <> this.var.Value then editor.SetValue this.var.Value ; editor.ClearHistory()
                             )
                          )
                      )    
                    ]
                link [ href "/EPFileX/codemirror/content/editor.css"                   ; ``type`` "text/css" ; rel "stylesheet" ]
                link [ href "/EPFileX/codemirror/content/codemirror.css"               ; ``type`` "text/css" ; rel "stylesheet" ]
                link [ href "/EPFileX/codemirror/content/theme/rubyblue.css"           ; ``type`` "text/css" ; rel "stylesheet" ]
                link [ href "/EPFileX/codemirror/scripts/addon/display/fullscreen.css" ; ``type`` "text/css" ; rel "stylesheet" ]
                link [ href "/EPFileX/codemirror/scripts/addon/dialog/dialog.css"      ; ``type`` "text/css" ; rel "stylesheet" ]
                link [ href "/EPFileX/codemirror/scripts/addon/hint/show-hint.css"     ; ``type`` "text/css" ; rel "stylesheet" ]
                link [ href "/EPFileX/codemirror/scripts/addon/lint/lint.css"          ; ``type`` "text/css" ; rel "stylesheet" ]
                css  ".CodeMirror { height: 100% }"
           ]
        member inline this.Class    clas = { this with _class    = Val.fixit clas }
        member inline this.Id       id   = { this with id        =       id       }
        member inline this.SetVar   v    = { this with var       = v              }
        member inline this.Style    sty  = { this with style     = Val.fixit sty  }
        member inline this.OnChange f    = { this with onChange  = f              }
        member inline this.OnRender f    = { this with onRender  = Some f         }
        member inline this.Var           = this.var
      
      # 1 @"(6)a05dd36e-a15e-4394-8013-128e21e69574 CodeMirror Hints.fsx"
      
      type Hint = {
          text        : string
          displayText : string
          className   : string
      }
      
      type HintResponse  = {
          list           : Hint []
          from           : CodeMirrorPos   
          ``to``         : CodeMirrorPos   
      }
      
      type HintFunc      = FuncWithArgs<CodeMirrorEditor * (HintResponse -> unit) * obj,  unit>
      
      type HintOptions   = {
          hint           : HintFunc
          completeSingle : bool   
          container      : Dom.Element
      }
      
      [< Inline "($v.hint.async = 1, $ed.showHint($v))"          >]
      let showHint_ (ed:CodeMirrorEditor) v   : unit       = X<_>
      let showHints (ed:CodeMirrorEditor) getHints completeSingle _ =
          showHint_ ed
              {  completeSingle = completeSingle
                 hint           = HintFunc getHints
                 container      = ed.GetWrapperElement() |> findRootElement
              }
      
      # 1 @"(6)18d8153d-422c-42f6-8266-9a9d854bd6a1 CodeMirror Lint.fsx"
      type LintResponse  = {
          message        : string
          severity       : string
          from           : CodeMirrorPos   
          ``to``         : CodeMirrorPos   
      }
      
      type LintFunc      = FuncWithArgs<string * (LintResponse[] -> unit) * obj * CodeMirrorEditor,  unit>
      
      [< Inline "($ed.setOption('lint', { async: 1, getAnnotations: $f, container: $elm }))"          >]
      let setLint_(ed:CodeMirrorEditor) (f:LintFunc) (elm:Dom.Element)  : unit = X<_>
      let setLint (ed:CodeMirrorEditor) getAnnotations       = 
          setLint_ ed (LintFunc getAnnotations) (ed.GetWrapperElement() |> findRootElement)
      
      
      # 1 @"(6)70030378-692d-431d-bed9-c839a7f95798 SplitterBar.fsx"
      [<NoComparison ; NoEquality>]
      type HtmlMeasure =
      | Percentage of Val<float>
      | Pixel      of Val<float>
      
      [<NoComparison ; NoEquality>]
      type SplitterBar = {
          value            : IRef<float>
          min              : Val<float>
          max              : Val<float>
          vertical         : Val<bool>
          node             : HtmlNode
          children         : HtmlNode seq
          after            : bool
          mutable dragging : bool
          mutable startVer : bool 
          mutable startP   : float 
          mutable start    : float 
          mutable size     : float 
          mutable domElem  : Dom.Element option
      }
      with
          static member New(var) = 
              {
                  value    = var
                  min      = Val.fixit   5.0
                  max      = Val.fixit  95.0
                  vertical = Val.fixit  true  
                  node     = div [ ``class`` "Splitter" ]
                  children = []
                  after    = true
                  dragging = false
                  startVer = true
                  startP   = 0.0
                  start    = 0.0
                  size     = 0.0
                  domElem  = None
              }
          static member New(value)    = SplitterBar.New(Var.Create value)
          member        this.Var      = this.value
          member        this.GetValue = this.value |> Val.map2 max this.min |> Val.map2 min this.max
          member        this.Render   =
              let mouseCoord (ev: Dom.MouseEvent) = if this.startVer then float ev.ClientX else float ev.ClientY
              let size () : float =
                  match this.domElem with
                  | None    -> 100.0
                  | Some el -> 
                   el.ParentElement.GetBoundingClientRect() 
                   |> fun r -> 
                       match this.startVer, this.after with
                       | true , true  ->  r.Width  
                       | true , false -> -r.Width 
                       | false, true  ->  r.Height
                       | false, false -> -r.Height
              let drag (ev: Dom.Event) =
                  ev :?> Dom.MouseEvent
                  |> mouseCoord
                  |> fun m   -> (m - this.start) * 100.0 / this.size + this.startP
                  |> fun v   -> this.value.Value <- v // ; JS.Inline("console.log($0)", this)
                 
              let rec finishDragging (_: Dom.Event) =
                  if this.dragging then
                      this.dragging <- false
                      JS.Window.RemoveEventListener("mousemove", drag          , false) 
                      JS.Window.RemoveEventListener("mouseup"  , finishDragging, false) 
                      //printfn "mouseup"
              let startDragging _ (ev: Dom.MouseEvent) =
                  if not this.dragging then
                      Val.map2 (fun startP dirV ->
                          this.dragging <- true
                          this.startVer <- dirV
                          this.startP   <- startP
                          this.start    <- mouseCoord ev
                          this.size     <- size()
                          JS.Window.AddEventListener("mousemove", drag          , false) 
                          JS.Window.AddEventListener("mouseup"  , finishDragging, false) 
                          ev.PreventDefault()
                      ) this.GetValue this.vertical
                      |> Val.iter id
              this.node
                .AddChildren(
                [
                  ``class`` <| Val.map (fun ver -> if ver then "Vertical" else "Horizontal") this.vertical 
                  SomeAttr  <| on.mouseDown startDragging
                  SomeAttr  <| on.afterRender (fun el -> this.domElem <- Some el)
                  css "
                      .Splitter.Vertical   { cursor: col-resize; background-color: #eef ; width : 5px ; margin-left:-7px; }
                      .Splitter.Horizontal { cursor: row-resize; background-color: #eef ; height: 5px ; margin-top :-7px; }
                  "
                ])
                .AddChildren this.children
          member inline this.Value       v =   this.value.Value <- v  ; this
          member inline this.Node     node = { this with node         = node                        }
          member inline this.Min         v = { this with min          = Val.fixit v                 }
          member inline this.Max         v = { this with max          = Val.fixit v                 }
          member inline this.Vertical    v = { this with vertical     = Val.fixit v                 }
          member inline this.Horizontal  v = { this with vertical     = Val.fixit v |> Val.map not  }
          member inline this.Vertical   () = { this with vertical     = Val.fixit true              }
          member inline this.Horizontal () = { this with vertical     = Val.fixit false             }
          member inline this.Before        = { this with after        =           false             }
          member inline this.After         = { this with after        =           true              }
          member inline this.Children   ch = { this with children     = ch                          }
          
      # 1 @"(6)0047d2f0-ec1d-43b1-b432-95462c318445 Grid.fsx"
      [<NoComparison ; NoEquality>]
      type Area =
      | Auto     of SplitterBar
      | Fixed    of HtmlMeasure
      | Splitter of SplitterBar
      
      [< Inline "new ResizeObserver($f).observe($el)" >]
      let resizeObserver (f: unit->unit) (el:Dom.Element) = X<_> 
      
      [<NoComparison ; NoEquality>]
      type Grid = {
          padding       : float
          gap           : float
          content       : (string option * HtmlNode) []
          cols          : Area []
          rows          : Area []
          width         : IRef<float>
          height        : IRef<float>
          lastSplitter  : (int * bool) option
      }
      with
          static member New = {
             padding       = 9.0
             gap           = 9.0
             cols          = [| |]
             rows          = [| |]
             content       = [| |]
             width         = Var.Create 1000.0
             height        = Var.Create  100.0
             lastSplitter  = None
          }
          member this.NewSplitter  (f: float)  col =
              let spl = SplitterBar.New(f)
              if col then
                  { this with lastSplitter = Some (this.cols.Length, col) ; cols = Array.append this.cols  [| spl              |> Splitter |] }
              else 
                  { this with lastSplitter = Some (this.rows.Length, col) ; rows = Array.append this.rows  [| spl.Horizontal() |> Splitter |] }
          member inline this.ColFixedPx   f              = { this with cols    = Array.append this.cols    [| Pixel     (Val.fixit f)              |> Fixed    |] }
          member inline this.ColFixed     f              = { this with cols    = Array.append this.cols    [| Percentage(Val.fixit f)              |> Fixed    |] }
          member inline this.ColVariable (s:SplitterBar) = { this with cols    = Array.append this.cols    [| s                                    |> Splitter |] }
          member inline this.ColVariable (f:float)       = this.NewSplitter f true
          member inline this.ColAuto     (f:float)       = { this with cols    = Array.append this.cols    [| SplitterBar.New(     f)              |> Auto     |] }
          member inline this.RowFixedPx   f              = { this with rows    = Array.append this.rows    [| Pixel     (Val.fixit f)              |> Fixed    |] }
          member inline this.RowFixed     f              = { this with rows    = Array.append this.rows    [| Percentage(Val.fixit f)              |> Fixed    |] }
          member inline this.RowVariable (s:SplitterBar) = { this with rows    = Array.append this.rows    [| s                                    |> Splitter |] }
          member inline this.RowVariable (f:float)       = this.NewSplitter f false
          member inline this.RowAuto     (f:float)       = { this with rows    = Array.append this.rows    [| SplitterBar.New(     f).Horizontal() |> Auto     |] }
          member        this.Content (area, html)        = { this with content = Array.append this.content [| Some area, html                                  |] }
          member        this.Content        html         = { this with content = Array.append this.content [| None     , html                                  |] }
          member inline this.Padding      f              = { this with padding = f                                                                                }
          member inline this.Gap          f              = { this with gap     = f                                                                                }
          member this.changeSplitter f =
              this.lastSplitter
              |> Option.iter (fun (pos, col) ->
                  if col then
                      match this.cols.[pos] with
                      | Splitter spl -> this.cols.[pos] <- Splitter <| f spl 
                      | _            -> ()
                  else 
                      match this.rows.[pos] with
                      | Splitter spl -> this.rows.[pos] <- Splitter <| f spl 
                      | _            -> ()
              )
              this
          member        this.Before                = this.changeSplitter (fun spl -> spl.Before     )
          member inline this.Max                 v = this.changeSplitter (fun spl -> spl.Max       v)
          member inline this.Min                 v = this.changeSplitter (fun spl -> spl.Min       v)
          member inline this.Children           ch = this.changeSplitter (fun spl -> spl.Children ch)
          member this.style    (areas:Area[]) size =
              if areas.Length = 0 then Val.Constant "100%" else
              let pcs, pxs = 
                  areas 
                  |> Seq.fold (fun (pcs, pxs) a ->
                      match a with
                      | Auto              spl -> (                          pcs,                pxs)          
                      | Splitter          spl -> (Val.map2 (+) spl.GetValue pcs,                pxs) 
                      | Fixed (Percentage v)  -> (Val.map2 (+) v            pcs,                pxs)
                      | Fixed (Pixel      v)  -> (                          pcs, Val.map2 (+) v pxs)
                  ) (Val.Constant 0.0, Val.Constant 0.0)
              let finalPerc = Val.map2 (fun v size -> (size - this.padding * 2. - this.gap * ((float areas.Length) - 1.) - v) / (size - this.padding * 2.)) pxs size
              let autoPct   = Val.map  ((-) 100.0)  pcs 
              let perc   pc = Val.map2 (fun finalPerc pc -> finalPerc * pc |> max 0.0 |> sprintf "%f%%") finalPerc pc
              let pixel  px = Val.map  (fun           px ->             px |> max 0.0 |> sprintf "%fpx")           px
              areas
              |> Seq.foldBack (fun a state ->
                  match a with
                  |  Auto              spl -> perc  autoPct          
                  |  Splitter          spl -> perc  spl.GetValue
                  |  Fixed (Percentage v)  -> perc  v
                  |  Fixed (Pixel      v)  -> pixel v
                  |> Val.map2(fun state v -> v::state) state
                 )  <| (Val.Constant [])
              |> Val.map (String.concat " ")
          member this.styles() =
              [ style1 "grid-template-columns" <| this.style this.cols this.width
                style1 "grid-template-rows"    <| this.style this.rows this.height
              ]
          member this.GridTemplate() =
              [ 
                  yield!
                      this.content
                      |> Seq.map (fun (area, html) ->
                          match area with
                          | None   -> html
                          | Some a -> html.AddChildren([ style <| sprintf "grid-area: %s" a ])
                         )
                  yield!
                      this.cols
                      |> Seq.indexed
                      |> Seq.choose (function
                          | i, Auto     spl -> None           
                          | i, Splitter spl -> Some <| spl.Render.InsertChildren( 
                                                  [ style1 "grid-column" (string (i + if spl.after then 2 else 1))
                                                    style1 "grid-row"    (sprintf "1 / %d" (this.rows.Length + 1)) ] ) 
                          | i, Fixed    _   -> None
                     )
                  yield!
                      this.rows
                      |> Seq.indexed
                      |> Seq.choose (function
                          | i, Auto     spl -> None           
                          | i, Splitter spl -> Some <| spl.Render.InsertChildren( 
                                                  [ style1 "grid-row"    (string (i + if spl.after then 2 else 1))
                                                    style1 "grid-column" (sprintf "1 / %d" (this.cols.Length + 1)) ] ) 
                          | i, Fixed    _   -> None
                     )
                  yield! this.styles() 
                  yield style    <| sprintf "display: grid; grid-gap: %fpx; padding: %fpx; box-sizing: border-box" this.gap this.padding 
                  yield SomeAttr <| on.afterRender(fun el   -> 
                      let setDimensions () =
                          this.width.Value  <- el.GetBoundingClientRect().Width
                          this.height.Value <- el.GetBoundingClientRect().Height
                      JS.SetTimeout setDimensions 60 |> ignore
                      resizeObserver setDimensions el
                    ) 
              ]
          member this.Render =
              div <| this.GridTemplate()
      # 1 @"(6)cddabd38-7ecb-4692-99bd-13ca70e4232f TabStrip.fsx"
      let reorderList (ts:'a list) drag drop =
          if drop < drag then
             ts.[0       ..drop - 1     ]
           @    [      ts.[drag]        ]
           @ ts.[drop    ..drag - 1     ]
           @ ts.[drag + 1..ts.Length - 1]
          else
             ts.[0..drag - 1            ]
           @ ts.[drag + 1..drop         ]
           @    [      ts.[drag]        ]
           @ ts.[drop + 1..ts.Length - 1]
      
      let reorderArray (ts:'a []) drag drop =
         (if drop < drag then
            [|
             ts.[0       ..drop - 1     ]
             [|        ts.[drag]       |]
             ts.[drop    ..drag - 1     ]
             ts.[drag + 1..ts.Length - 1]
            |]
          else
            [|
             ts.[0..drag - 1            ]
             ts.[drag + 1..drop         ]
             [|        ts.[drag]       |]
             ts.[drop + 1..ts.Length - 1]
            |]
         )|> Array.collect id 
      
      
      [< NoComparison >]
      type TabStrip =
          { selected  : IRef<int>
            tabs      : IRef<(System.Guid * (string * HtmlNode)) []>
            top       : bool
            horizontal: bool
            id        : System.Guid
          } 
      
      let draggedTab: (TabStrip * int) option ref = ref None
      
      let uid2s (uid: System.Guid) = "X" + uid.ToString().Replace("-", "")
      
      let selectedPanels: Var<Map<System.Guid, System.Guid>> = Var.Create Map.empty 
      
      let setSelectedPanel group panelO = 
          selectedPanels.Value <- 
              match panelO with
              | Some panel -> selectedPanels.Value.Add    (group, panel)
              | None       -> selectedPanels.Value.Remove  group
      
      let mutable TabMoved : ((TabStrip * TabStrip) -> unit) option = None
      let RaiseTabMoved fromS toS = TabMoved |> Option.iter (fun f -> f (fromS, toS))
      
      type TabStrip with
          member this.moveTab from drag drop =
              let ts = this.tabs.Value
              let ft = from.tabs.Value
              let newTabsT =
                  [|
                   ts.[0       ..drop - 1     ]
                   [|        ft.[drag]       |]
                   ts.[drop    ..ts.Length - 1]
                  |]
                  |> Array.collect id
              let newTabsF =
                  [|
                   ft.[0       ..drag - 1     ]
                   ft.[drag + 1..ft.Length - 1]
                  |]
                  |> Array.collect id
              from.tabs.Value     <- newTabsF
              this.tabs.Value     <- newTabsT
              this.selected.Value <- drop
              if from.selected.Value >= newTabsF.Length then from.selected.Value <- 0
              RaiseTabMoved from this
      
          member this.reorder drop =
              match !draggedTab with
              | None                                     -> ()
              | Some(from, drag) when from.id <> this.id -> this.moveTab from drag drop
              | Some(from, drag)                         ->
              this.tabs.Value     <- reorderArray this.tabs.Value drag drop
              let sel = this.selected.Value
              this.selected.Value <- if    sel = drag                then drop
                                     elif (sel < drag && sel < drop)
                                       || (sel > drag && sel > drop) then sel 
                                     elif  sel < drag                then sel + 1
                                     else                                 sel - 1
                                     
          static member New(tabs)    =
              { selected   = Var.Create 0
                tabs       = tabs 
                top        = false 
                horizontal = true
                id         = System.Guid.NewGuid() 
              } 
          static member New(tabs) = TabStrip.New(tabs |> Seq.map (fun def -> System.Guid.NewGuid(), def) |> Seq.toArray |> Var.Create)
          member this.Top         = { this with top        = true  }
          member this.Bottom      = { this with top        = false }
          member this.Horizontal  = { this with horizontal = true  }
          member this.Vertical    = { this with horizontal = false }
          member this.Selected    = Val.map2 (fun tabs sel -> tabs |> Seq.tryItem sel |> Option.map fst) this.tabs this.selected
          member this.Render      =
              let strip =
                  this.tabs
                  |> bindHElem (
                      fun tabs ->
                          div [ yield ``class`` <| sprintf "tab-strip %s %s"
                                                      (if this.top        then "top"        else "bottom"  ) 
                                                      (if this.horizontal then "horizontal" else "vertical")
                                
                                for i, (uid, (txt, _)) in  tabs |> Seq.indexed  do
                                    yield Hoverable.New.Content(
                                          div [ htmlText txt
                                                ``class`` <| Val.map (fun sel -> "tab" + (if sel = i then " selected" else "")) this.selected
                                                draggable "true"
                                                SomeAttr <| on.dragOver(fun _ ev -> ev.PreventDefault()                            )
                                                SomeAttr <| on.drag    (fun _ _  ->                     draggedTab := Some(this, i))
                                                SomeAttr <| on.drop    (fun e ev -> ev.PreventDefault(); ev.StopPropagation() ; this.reorder i )
                                                SomeAttr <| on.click   (fun _ _  ->                       this.selected.Value <- i ) 
                                              ])
                              ]
                  )
              Val.sink (setSelectedPanel this.id) this.Selected  
              let content = 
                  this.tabs
                  |> bindHElem (fun tabs ->
                      div [
                        yield  ``class`` "tab-children"
                        yield  Id <| uid2s this.id
                        yield!
                            tabs
                            |> Seq.map (fun (uid, (txt, sub)) -> 
                                sub.AddChildren(
                                  [ style <| Val.map (fun sels -> if sels |> Map.toSeq |> Seq.map snd |> Seq.contains uid then "" else "display : none") selectedPanels
                                    Id    <| uid2s uid
                                  ]))
                      ] 
                   )
              div [ ``class`` "tab-panel"
                    (if     this.top then strip else HtmlEmpty)
                    div [ content ; ``class`` "tab-content" ]
                    (if not this.top then strip else HtmlEmpty)
                    SomeAttr <| on.dragOver(fun _ ev -> ev.PreventDefault()                                      )
                    SomeAttr <| on.drop    (fun e ev -> ev.PreventDefault() ; this.reorder this.tabs.Value.Length)
                    css @"
      
      .tab-panel {
       overflow : hidden ;
       display  : flex   ;
       flex-flow: column ;
       background: pink    ;
      }
      .tab-content {
       flex      : 1 1     ;
       overflow  : auto    ;
       position  : relative;
      }
      .tab-children {
       height    : 100%    ;
       width     : 100%    ;
       position  : absolute;
       display   : grid    ;
      }
      .tab-strip {
       padding   : 0pt     ;
       flex      : 0 0     ;
      }
      .tab {
       border     : 0.2pt solid transparent;
       padding    : 0pt 4pt;
       display    : inline-block;
       font-family: sans-serif;
       font-weight: 200;
       font-size  : small;
       color      : #666;
       cursor     : pointer;
      }
      .top>.tab {
       border-radius: 2pt 2pt 0pt 0pt;
       border-bottom-width: 0pt;
       vertical-align: bottom;
      }
      .bottom>.tab {
       border-top-width: 0pt;
       border-radius: 0pt 0pt 2pt 2pt;
       vertical-align: top;
      }
      .horizontal>.tab:not(:first-child) {
       border-left-width: 0pt;
      }
      .tab.hovering {
       background: red;
      }
      .tab.selected {
       background: white;
       border-left-width: 0.2pt;
       color: black;
       font-weight: 500;
       border-color: black;
      }
      .horizontal>.tab.selected {
       border-left-width: 0.2pt;
      }
      "]
      # 1 @"(6)a48d72fc-5220-4dac-b3b3-98bad48b0561 SplitterNode.fsx"
      //#nowarn "1178"
      type SplitterNode = | SplitterNode of Var<SplitterStructure>
      and  SplitterStructure =
          | SHtmlNode of HtmlNode
          | STabStrip of TabStrip
          | Split     of SplitterNode * SplitterNode * (SplitterNode -> SplitterNode -> HtmlNode)
      
      let rec renderSplitterNode      sn = match sn with SplitterNode chV -> bindHElem (fun ch -> renderSplitterStructure ch) chV 
      and     renderSplitterStructure ss =
              match ss with
              | SHtmlNode node        -> node
              | STabStrip strip       -> strip.Render  
              | Split   (ch1, ch2, f) -> f ch1 ch2
      
      let renderSplitter (per:float) ver ch1 ch2 =
          let grid = Grid.New.Content("one", renderSplitterNode ch1)
                             .Content("two", renderSplitterNode ch2).Padding(0.0)
          if ver then grid.ColVariable(per).ColAuto(50.0).Content( style "grid-template-areas: 'one   two' " ).Render
                 else grid.RowVariable(per).RowAuto(50.0).Content( style "grid-template-areas: 'one' 'two' " ).Render
      
      type SplitterStructure with    
          static member New(vertical : bool, child1, child2, per) = Split(SplitterNode (Var.Create              child1), SplitterNode (Var.Create              child2), renderSplitter per  vertical)
          static member New(vertical : bool, child1, child2     ) = Split(SplitterNode (Var.Create              child1), SplitterNode (Var.Create              child2), renderSplitter 50.0 vertical)
          static member New(vertical : bool, child1, child2, per) = Split(SplitterNode (Var.Create <| SHtmlNode child1), SplitterNode (Var.Create <| SHtmlNode child2), renderSplitter per  vertical)
          static member New(vertical : bool, child1, child2, per) = Split(SplitterNode (Var.Create <| STabStrip child1), SplitterNode (Var.Create <| STabStrip child2), renderSplitter per  vertical)
          static member New(ss1, ss2, f                    ) = Split(SplitterNode (Var.Create ss1                ), SplitterNode (Var.Create ss2                ), f                      )
          static member New(strip                          ) = STabStrip strip
          static member New(node                           ) = SHtmlNode node
      
      type SplitterNode with
          static member New        ss           = SplitterNode <| Var.Create ss
          static member New       (ss:HtmlNode) = SplitterNode <| Var.Create (SplitterStructure.New(ss))
          static member New       (ss:TabStrip) = SplitterNode <| Var.Create (SplitterStructure.New(ss))
          member this.Render                    = renderSplitterNode this
          member this.Var                       = match this with SplitterNode chV -> chV
          member this.Value                     = this.Var.Value
          member this.SplitMe(first, ver, node) =
              this.Var.Value <- if first then SplitterStructure.New(ver, node      , this.Value) 
                                         else SplitterStructure.New(ver, this.Value, node      )
          member this.SplitMe(first, ver, node:TabStrip) = this.SplitMe(first, ver, STabStrip node      )
          member this.SplitMe(first, ver, node:HtmlNode) = this.SplitMe(first, ver, SHtmlNode node      )
          member this.SplitMe(first, ver               ) = this.SplitMe(first, ver, TabStrip.New([||])  )
          member this.IsEmpty                            =
              match this.Value with
              | SHtmlNode HtmlEmpty   -> true
              | SHtmlNode _           -> false
              | STabStrip strip       -> strip.tabs.Value.Length = 0
              | Split   (ch1, ch2, f) -> ch1.IsEmpty && ch2.IsEmpty
          member this.UnSplitEmpties()                   =
              if                                    this.IsEmpty then this.Var.Value <- SplitterStructure.New(TabStrip.New([||])) else
              match this.Value with
              | Split   (ch1, ch2, f) -> if   ch1.IsEmpty then ch2.UnSplitEmpties() ; this.Var.Value <- ch2.Value 
                                         elif ch2.IsEmpty then ch1.UnSplitEmpties() ; this.Var.Value <- ch1.Value 
                                                          else ch1.UnSplitEmpties()
                                                               ch2.UnSplitEmpties()
              | _                     -> ()  
      
    # 1 @"(4)e2ca8cb1-fb1e-4793-855f-55e3ca07b8f5 RunCode.fsx"
    [<JavaScript>]
    module RunCode       =
      # 1 @"(6)79f8f6c6-d1f5-4593-9775-60ba2863e94d module EditorRpc =.fsx"
      //#r @"ZafirTranspiler.dll"
      module EditorRpc =
          let callRPC asy callback =
              Async.StartWithContinuations(asy, callback, (fun e -> JS.Alert(e.ToString()) ), fun c -> JS.Alert(c.ToString()))
      
          let translate    callback minified source = CIPHERPrototype.Editor.translate    source minified |> callRPC <| callback
          let evaluate     callback          source = CIPHERPrototype.Editor.evaluate     source          |> callRPC <| callback
      
      let completeJS js = 
        """
          CIPHERSpaceLoadFileGlobalFileRef = null;
          CIPHERSpaceLoadFile = function (filename, callback) {
              if (filename.slice(-3) == ".js" || filename.slice(-4) == ".fsx" || filename.slice(-3) == ".fs") { //if filename is a external JavaScript file
                  var fileRef = null;
                  var pre = document.querySelector('script[src="' + filename + '"]')
                  if (!pre) {
                      fileRef = document.createElement('script')
                      fileRef.setAttribute("type", "text/javascript")
                      fileRef.setAttribute("src", filename)
                  }
                  else callback();
              }
              else if (filename.slice(-4) == ".css") { //if filename is an external CSS file
                  var pre = document.querySelector('script[src="' + filename + '"]')
                  if (!pre) {
                      fileRef = document.createElement("link")
                      fileRef.setAttribute("rel", "stylesheet")
                      fileRef.setAttribute("type", "text/css")
                      fileRef.setAttribute("href", filename)
                  }
                  else callback();
              }
              else if (filename.slice(-5) == ".html") { //if filename is an external HTML file
                  var pre = document.querySelector('script[src="' + filename + '"]')
                  if (!pre) {
                      fileRef = document.createElement("link")
                      fileRef.setAttribute("rel", "import")
                      fileRef.setAttribute("type", "text/html")
                      fileRef.setAttribute("href", filename)
                  }
                  else callback();
              }
              if (!!fileRef) {
                  CIPHERSpaceLoadFileGlobalFileRef = fileRef;
      			fileRef.onload = function () { fileRef.onload = null;  callback(); }
                  document.getElementsByTagName("head")[0].appendChild(fileRef);
              }
          }
          CIPHERSpaceLoadFiles = function (files, callback) {
              var newCallback = callback
              if (!!CIPHERSpaceLoadFileGlobalFileRef && !!(CIPHERSpaceLoadFileGlobalFileRef.onload)) {
                  var oldCallback = CIPHERSpaceLoadFileGlobalFileRef.onload;
                  CIPHERSpaceLoadFileGlobalFileRef.onload = null;
                  newCallback = function () {
                      callback();
                      oldCallback();
                  }
              }
              var i = 0;
              loadNext = function () {
                  if (i < files.length) {
                      var file = files[i];
                      i++;
                      CIPHERSpaceLoadFile(file, loadNext);
                  }
                  else newCallback();
              };
              loadNext();
      	}
          CIPHERSpaceLoadFiles(['https://code.jquery.com/jquery-3.1.1.min.js'], function() {}); 
      	CIPHERSpaceLoadFilesDoAfter = function (callback) {
      		var newCallback = callback
      		if (!!CIPHERSpaceLoadFileGlobalFileRef) {
      			if (!!(CIPHERSpaceLoadFileGlobalFileRef.onload)) {
      				var oldCallback = CIPHERSpaceLoadFileGlobalFileRef.onload;
      				CIPHERSpaceLoadFileGlobalFileRef.onload = null;
      				newCallback = function () {
      					oldCallback();
      					callback();
      				}
      			}
      		}
      		else CIPHERSpaceLoadFileGlobalFileRef = {};
      		CIPHERSpaceLoadFileGlobalFileRef.onload = newCallback;
      	}
      
      CIPHERSpaceLoadFilesDoAfter(function() { 
        if (typeof IntelliFactory !=='undefined')
          IntelliFactory.Runtime.Start();
        for (key in window) { 
          if (key.startsWith("StartupCode$")) 
            try { window[key].$cctor(); } catch (e) {} 
        } 
      })
                       """ + js
      
      let compile fThen fFail code =
          EditorRpc.translate 
              <| (fun (jsO, msgs) ->
                   jsO
                   |> Option.map completeJS
                   |> function
                   | Some js -> fThen  msgs   js
                   | None    -> fFail  msgs
                  )
              <| false <| code
      
      let startRPC  asy = Async.StartWithContinuations(asy, id, (fun e -> JS.Alert(e.ToString()) ), fun c -> JS.Alert(c.ToString()))
      
      # 1 @"(6)f2571ac9-37ec-4d7c-9ead-9e5f79ae1be1 type RunNode(nodeName, clearNode bool) =.fsx"
      type RunNode(nodeName, ?clearNode: bool) =
        let bClearNode    = defaultArg clearNode true
        let createBaseNode () =
            let el = JS.Document.CreateElement "div"
            el.SetAttribute("id", nodeName)
            JS.Document.Body.AppendChild el |> ignore
            el
        let baseNode = 
            match JS.Document.GetElementById nodeName with
            | null -> createBaseNode()
            | node -> node
        let runNode =
            match baseNode.ShadowRoot with
            | null -> let e = JS.Document.CreateElement "div"
                      baseNode.AttachShadow(Dom.ShadowRootInit(Dom.ShadowRootMode.Open)).AppendChild e |> ignore
                      e?style <- "height: 100%; width: 100%;"
                      e
            | root -> root.FirstChild :?> Dom.Element
        do if bClearNode then runNode.InnerHTML <- ""
      with
        new(?clearNode: bool) = RunNode("TestNode", defaultArg clearNode true)
        member this.RunNode   = runNode
      # 1 @"(6)081bac32-e739-4124-87eb-eb7d6f2220bc AddBootstrap.fsx"
        member this.AddBootstrap =
          JS.Document.CreateElement "div"
          |> fun el -> 
              el.InnerHTML <- 
                @"<script src='http://code.jquery.com/jquery-3.1.1.min.js' type='text/javascript' charset='UTF-8'></script>
                  <script src='http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js' type='text/javascript' charset='UTF-8'></script>
                  <link type='text/css' rel='stylesheet' href='http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css'>
                  <link type='text/css' rel='stylesheet' href='/EPFileX/css/main.css'>
                 "
              runNode.AppendChild el |> ignore
          this
      # 1 @"(6)c110a9c9-bc3b-4be7-8e5d-f43cc75f93ed RunDoc.fsx"
        member inline this.RunDoc  doc  = doc  :> Doc       |> Doc.Run this.RunNode
      # 1 @"(6)3038cd62-093c-4385-aa9b-799297bd379c RunHtml.fsx"
        member inline this.RunHtml node = node |> renderDoc |> this.RunDoc
    # 1 @"(4)c2188026-a06a-4963-a95a-93075e5f5b6e FSharpStation.fsx"
    [<JavaScript>]
    module FSharpStation =
    
      # 1 @"(6)987560b0-1fe6-4835-ad99-aed93db7da1a currentCodeSnippetId.fsx"
      open FsStationShared
      
      //let codeSnippetsStorage = WebSharper.UI.Next.Storage.LocalStorage "CodeSnippets" Serializer.Typed<CodeSnippet>
      //let codeSnippets        = ListModel.CreateWithStorage<CodeSnippetId, CodeSnippet> (fun s -> s.id) codeSnippetsStorage
      let codeSnippets        = ListModel.Create<CodeSnippetId, CodeSnippet> (fun s -> s.id) []
      let fsIds  = "FSharpStation" //+ (System.Guid.NewGuid() |> string)
      
      let tryPickI f s = s |> Seq.indexed |> Seq.filter f |> Seq.tryHead
      
      type CodeSnippet 
          with
          static member PickIO       id   = codeSnippets.Value    |> tryPickI (fun (_, snp) -> snp.id = id)
          static member FetchO       id   = codeSnippets.TryFindByKey id
          static member FetchL       id   = CodeSnippet.FetchO id |> Option.toList
          static member New(            pred    , cnt) = CodeSnippet.New("", None   , pred, [], cnt)
          static member New(        pa, pred    , cnt) = CodeSnippet.New("", Some pa, pred, [], cnt)
          static member New(        pa,           cnt) = CodeSnippet.New("", Some pa, []  , [], cnt)
          static member New(                      cnt) = CodeSnippet.New("", None   , []  , [], cnt)
          static member New(    nm, pa, pred, co, cnt) = CodeSnippet.New(codeSnippets.Length, nm, pa, pred, co, cnt)
          static member New(od, nm, pa, pred, co, cnt) =
              let newS =
                  {
                      name         = nm
                      content      = cnt
                      parent       = pa
                      predecessors = pred
                      id           = CodeSnippetId.New
                      expanded     = true
                      level        = 0
                      properties   = Map.empty
                  }
              match od, codeSnippets.Length with
              | _, 0            -> codeSnippets.Append newS
              | 0, _            -> codeSnippets.Set <| Seq.append [| newS |] codeSnippets.Value
              | i, n when i < n -> codeSnippets.Value 
                                      |> Seq.toArray
                                      |> Array.splitAt od
                                      |> fun (fst, snd) -> Array.append fst <| Array.append [| newS |] snd
                                      |> codeSnippets.Set 
              | _, _            -> codeSnippets.Append newS
              newS
          member this.Level =
              let rec level out snp = 
                  snp.parent
                  |> Option.bind CodeSnippet.FetchO
                  |> Option.map (level <| out + 1) 
                  |> Option.defaultValue out
              level 0 this
          member this.PrepareSnippet   = { this with level   = this.Level
                                                     content = this.content
                                                                    .Replace("##" + "FSHARPSTATION_ID" + "##"      , fsIds                  )
                                                                    .Replace("##" + "FSHARPSTATION_ENDPOINT" + "##", JS.Window.Location.Href) }
          member this.Predecessors     () =
              let preds = this.UniquePredecessors CodeSnippet.FetchO |> Seq.toArray
              codeSnippets.Value
              |> Seq.filter (fun snp -> preds |> Array.contains snp.id)
              |> Seq.map    (fun snp -> snp.PrepareSnippet)
              |> Seq.toArray
          member this.GetCodeAndStarts addLinePrepos = this.Predecessors() |> CodeSnippet.CodeAndStarts addLinePrepos
          member this.GetCodeFsx       addLinePrepos = this.GetCodeAndStarts addLinePrepos |> fst
          member this.IsDescendantOf antId =
              let rec isDescendantOf snp =
                  match snp.parent with
                  | None       -> false
                  | Some parId ->
                  if parId = antId then true else
                  CodeSnippet.FetchO parId
                  |> Option.map isDescendantOf
                  |> Option.defaultValue false
              isDescendantOf this
          static member FetchByPathO names      = 
              let tryFindByName      snps name  = snps |> Seq.filter (fun (snp:CodeSnippet) -> snp.Name = name) |> Seq.tryHead
              let rec tryFindByPath  snps names = 
                  let first = names |> Seq.tryHead |> Option.bind (tryFindByName snps)
                  if names |> Seq.length <= 1 then first else
                  first
                  |> Option.bind (fun f ->
                      names 
                      |> Seq.tail
                      |> tryFindByPath  (codeSnippets.Value |> Seq.filter (fun snp -> snp.parent = Some f.id))
                  )
              names 
              |> tryFindByPath (codeSnippets.Value |> Seq.filter (fun snp -> snp.parent.IsNone))  
      
      
      
      let missingVar  = Var.Create ""
      let missing find lens k =
          match find k with
          | Some _ -> lens k
          | None   -> missingVar.Lens (fun _ -> "") (fun _ _ -> "")
          
      let currentCodeSnippetId  = Var.Create <| CodeSnippetId.New
      
      [< Inline >]
      let inline storeVarCodeEditor name = storeVar <| "CodeEditor." + name
      storeVarCodeEditor "currentCodeSnippetId" currentCodeSnippetId
      
      let refresh       = Var.Create()
      let refreshView b = refresh.Value <- b
      
      let currentCodeSnippetO = Val.map2 (fun k () -> codeSnippets.TryFindByKey k) currentCodeSnippetId refresh
      
      let curSnippetNameOf k = missing codeSnippets.TryFindByKey <| codeSnippets.LensInto (fun s -> s.Name   ) (fun s n -> { s with name    = n }) <| k
      let curSnippetCodeOf k = missing codeSnippets.TryFindByKey <| codeSnippets.LensInto (fun s -> s.content) (fun s n -> { s with content = n }) <| k
          
      type Position =
          | Below
          | Right
          | Tab
          | NewBrowser
          
      let positionTxt v =
          match v with
          | Below      -> "Below"
          | Right      -> "Right"
          | Tab        -> "In Tab"
          | NewBrowser -> "New Browser"
          
      let position = Var.Create Below
      storeVarCodeEditor "position" position
      
      let directionVertical    = 
          Val.map (fun pos -> 
              match pos with
              | Right -> true
              | _     -> false
          ) position
          
          
      # 1 @"(6)95ca1e9f-4029-4fc1-8b1c-ab12db71c90b Messaging.fsx"
      //#r "remote.dll"
      open CIPHERPrototype.Messaging
      open FsStationShared
      
      let fsStationClient = FsStationClient(fsIds, fsIds)
      
      let transMsgs msgs  =  msgs |> Array.map (fun (m, w) -> m, if w then FSWarning else FSError)
      
      let respond fromId (msg:FSMessage) : Async<FSResponse> =
          async {
              match msg with
              | GetWholeFile               -> return codeSnippets.Value            |> Seq.toArray |> Json.Serialize |> Some                                   |> StringResponse       
              | GetSnippetContentById sId  -> return CodeSnippet.FetchO       sId  |> Option.map (fun snp -> snp.content        )                             |> StringResponse       
              | GetSnippetCodeById    sId  -> return CodeSnippet.FetchO       sId  |> Option.map (fun snp -> snp.GetCodeFsx true)                             |> StringResponse 
              | GetSnippetPredsById   sId  -> return CodeSnippet.FetchO       sId  |> Option.map (fun snp -> snp.Predecessors ()) |> Option.defaultValue [||] |> SnippetsResponse
              | GetSnippetById        sId  -> return CodeSnippet.FetchO       sId                                                                             |> SnippetResponse 
              | GetSnippetContent     path -> return CodeSnippet.FetchByPathO path |> Option.map (fun snp -> snp.content        )                             |> StringResponse
              | GetSnippetCode        path -> return CodeSnippet.FetchByPathO path |> Option.map (fun snp -> snp.GetCodeFsx true)                             |> StringResponse
              | GetSnippetJSCode      path -> match CodeSnippet.FetchByPathO path with
                                              | Some snp -> let!    jsO, msgs = CIPHERPrototype.Transpiler.translate2 (snp.GetCodeFsx true) false
                                                            return (jsO |> Option.map RunCode.completeJS, transMsgs msgs)                                     |> StringResponseR
                                              | None     -> return (None, [| "Snippet not found" , FSError |] )                                               |> StringResponseR
              | GetSnippetPreds       path -> return CodeSnippet.FetchByPathO path |> Option.map (fun snp -> snp.Predecessors ()) |> Option.defaultValue [||] |> SnippetsResponse
              | GetSnippet            path -> return CodeSnippet.FetchByPathO path                                                                            |> SnippetResponse 
              | GenericMessage        txt  -> return (Some <| "Message received: " + txt)                                                                     |> StringResponse
              | GetIdentification          -> return fromId                                                                                                   |> IdResponse  
          }
      
      let respondMessage fromId txt =
          async {
              let  msg = Json.Deserialize txt 
              let! res = respond fromId msg
              return Json.Serialize res
          }
      
      1000 |> JS.SetTimeout (fun () -> fsStationClient.MessagingClient.AwaitMessage respondMessage) |> ignore
      
      
      # 1 @"(6)07e477d3-fb6e-4c83-bb89-b4b2cce55d7b CodeEditorMain.fsx"
      open System.Collections.Generic
      
      let noSelection cur = CodeSnippet.FetchO cur = None
      let noSelectionVal  = Val.map noSelection currentCodeSnippetId
      
      let mutable lastCodeAndStarts : (CodeSnippetId * bool * ((string * int * int) [] * string [] * string [] * string [] * string [] * string [])) option = None
      
      let getPredecessors curO =
          curO
          |> Option.map (fun (snp:CodeSnippet) -> snp.UniquePredecessors CodeSnippet.FetchO |> HashSet)
          |> Option.defaultValue (System.Collections.Generic.HashSet())
      
      let getPredecessorsM = Useful.ResetableMemoize(getPredecessors)
      
      let codeFS         = Var.Create ""
      let codeJS         = Var.Create ""
      let codeMsgs       = Var.Create ""
      let mutable parsed = false
      let dirty          = Var.Create false 
      let setDirtyPart() = parsed            <- false
                           dirty.Value       <- true       
      let setDirty()     = lastCodeAndStarts <- None
                           setDirtyPart               ()
      let setDirtyPred() = setDirty                   ()
                           getPredecessorsM.ClearCache()
                           refreshView                ()
      let setClean()     = getPredecessorsM.ClearCache()
                           dirty.Value       <- false
                           lastCodeAndStarts <- None
                           
      
      //storeVarCodeEditor "dirty" dirty
      let sendMsg msg =
          if isUndefined msg then () else
          codeMsgs.Value  <- 
              match codeMsgs.Value, msg.ToString() with
              | null, m 
              | ""  , m
              | m   , null
              | m   , ""   -> m
              | m1  , m2   -> m1 + "\n" + m2
      
      let getFSCode () =
          CodeSnippet.FetchO currentCodeSnippetId.Value 
          |> Option.iter (fun snp -> codeFS.Value <- snp.GetCodeFsx true )
      
      do Val.sink (fun m -> 
          JS.Window.Onbeforeunload <- 
              if m then System.Action<Dom.Event>(fun (e:Dom.Event) -> e?returnValue  <- "Changes you made may not be saved.")
              else null
          ) dirty 
      
      let evalIFrameJS success failure js =
          createIFrame (fun frame ->
              try
                   let window   = frame?contentWindow
                   let eval   s = JS.Apply window "eval" [| s |]
                   eval js           |> success
              with e -> e.ToString() |> failure
          )
          |> RunCode.RunNode().RunHtml
      
      let evalWindowJS success failure js =
          let window       = JS.Apply JS.Window "open" [| JS.Window.Location.Origin + "/Main.html" |]
          match window with
          | null -> failure "could not open new browser. Popup blocker may be active."
          | _    ->
          600 
          |> JS.SetTimeout (fun () -> 
              try
                   let eval   s = JS.Apply window   "eval" [| s |]
                   //printfn "Evaluating..."
                   JS.Apply window   "focus" [|  |]
                   eval js           |> success
              with e -> e.ToString() |> failure)
          |> ignore
                                     
      let runJS msgs js =
          sendMsg "Running JavaScript..."
          match position.Value with
          | NewBrowser -> evalWindowJS
          | _          -> evalIFrameJS
          <| (fun res  -> sendMsg "Done!"   ; sendMsg res ; sendMsg msgs) 
          <| (fun res  -> sendMsg "Failed!" ; sendMsg res ; sendMsg msgs)
          <| js
      
      let processSnippet getCode msg processCode =
          CodeSnippet.FetchO currentCodeSnippetId.Value 
          |> Option.iter (fun snp -> 
              codeMsgs.Value <- msg
              codeJS.Value   <- ""
              let code = getCode snp
              codeFS.Value   <- code
              processCode       code
          )
      
      let compileSnippet fThen fFail = 
          processSnippet (fun snp -> snp.GetCodeFsx true) "Compiling to JavaScript..." (RunCode.compile (fun msgs js -> codeJS.Value <- js ; fThen msgs js) fFail)
      
      let compileRun  () = compileSnippet runJS                                               sendMsg
      let justCompile () = compileSnippet (fun msgs _ -> sendMsg "Compiled!" ; sendMsg msgs)  sendMsg
      let evaluateFS  () = 
          processSnippet (fun snp -> snp.GetCodeFsx true) "Evaluating F# code..." 
              (RunCode.EditorRpc.evaluate 
                (function 
                 | None    , ""
                 | Some "" , ""   -> "Done!"
                 | None    , msgs -> msgs
                 | Some out, ""   ->               out
                 | Some out, msgs -> msgs + "\n" + out
                 >> sendMsg))
      
      let reorderSnippet toId fromId =
          let trySnippet id = tryPickI (fun (_, snp) -> snp.id = id) 
          let moving, others = codeSnippets.Value |> Seq.toArray |> Array.partition (fun snp -> snp.id = fromId || snp.IsDescendantOf fromId)
          match trySnippet fromId moving, trySnippet toId others with
          | Some(_, snp), Some(ti, tsn) ->
              [| others.[0..ti - 1] ; moving ; others.[ti..] |]
              |> Array.collect id
              |> codeSnippets.Set
              codeSnippets.UpdateBy (fun c -> Some { c with parent = tsn.parent }) snp.id
          | _ -> ()
          setDirtyPred()
      
      let indentCodeIn () =
          CodeSnippet.PickIO currentCodeSnippetId.Value
          |> Option.iter (fun (j, snp) ->
              let rec doPriorUntil f i =
                  if i < 0 then () else
                  if codeSnippets.Value |> Seq.item i |> f then () else
                  doPriorUntil f (i - 1)
              j - 1 |> doPriorUntil (fun pri ->
                  if pri.parent = snp.parent 
                  then codeSnippets.UpdateBy (fun c -> Some { c with parent = Some pri.id }) snp.id
                       true
                  else false
              )
              setDirtyPred()
          )
      
      let indentCodeOut () =
          CodeSnippet.FetchO currentCodeSnippetId.Value
          |> Option.iter (fun snp ->
              let newP = snp.parent
                         |> Option.bind CodeSnippet.FetchO
                         |> Option.bind (fun p -> p.parent)
              codeSnippets.UpdateBy (fun c -> Some { c with parent = newP }) snp.id
              setDirtyPred()
          )
      
      let mutable draggedId   = CodeSnippetId.New
      
      
      # 1 @"(6)93f32df7-da8b-472f-8bad-e82cc58ec52b List Code.fsx"
      let isDirectPredecessor pre curO =
          curO
          |> Option.map (fun snp -> snp.predecessors |> List.contains pre)
          |> Option.defaultValue false
      
      
      let curPredecessors = Val.map getPredecessorsM.Call currentCodeSnippetO
      
      let isIndirectPredecessor pre (predecessors: HashSet<CodeSnippetId>) = predecessors.Contains pre //predecessors |> Set.contains pre
      
      //let isIndirectPredecessorT (preId, curId) = getPredecessors curId |> Set.contains preId            // horrible performance
      //let isIndirectPredecessorM  preId  curId  = (Useful.memoize isIndirectPredecessorT) (preId, curId) // horrible performance
      
      let togglePredecessorForCur (pre:CodeSnippet) curO =
          curO |> Option.iter (fun cur ->
              if cur = pre || isIndirectPredecessor cur.id (pre.UniquePredecessors CodeSnippet.FetchO |> HashSet) then () else
              let preds = 
                  if cur.predecessors |> List.contains pre.id
                  then List.filter ((<>) pre.id)
                  else fun l -> pre.id :: l
                  <| cur.predecessors
              codeSnippets.UpdateBy  (fun c -> Some { c with predecessors = preds }) cur.id
              setDirtyPred()
          )
      
      let toggleExpanded snp =
          codeSnippets.UpdateBy  (fun c -> Some { c with expanded = not c.expanded }) snp.id
          refreshView()
      
      let listEntry isParent isExpanded code =
          Template.Hoverable.New
              .Content( [ ``class`` "code-editor-list-tile"
                          classIf   "selected"              <| Val.map ((=)                    code.id) currentCodeSnippetId
                          classIf   "direct-predecessor"    <| Val.map (isDirectPredecessor    code.id) currentCodeSnippetO
                          classIf   "indirect-predecessor"  <| Val.map (isIndirectPredecessor  code.id) curPredecessors
                          draggable "true"
                          SomeAttr <| on.dragOver(fun _ ev -> ev.PreventDefault()                                              )
                          SomeAttr <| on.drag    (fun _ _  ->                                              draggedId <- code.id)
                          SomeAttr <| on.drop    (fun _ ev -> ev.PreventDefault() ; reorderSnippet code.id draggedId           )
                          span    [ ``class`` "node"
                                    classIf   "parent"   isParent
                                    classIf   "expanded" isExpanded
                                    SomeAttr <| on.click(fun _ _ -> if isParent then toggleExpanded code)
                                    title    <| if isParent then (if isExpanded then "collapse" else "expand") else ""
                                    htmlText <| if isParent then (if isExpanded then "-"        else "+"     ) else ""
                                  ]
                          div     [ ``class`` "code-editor-list-text"
                                    style1 "text-indent" (sprintf "%dem" <| code.Level)
                                    style  "white-space: pre"
                                    htmlText <| Val.map2 snippetName (curSnippetNameOf code.id) (curSnippetCodeOf code.id)
                                    SomeAttr <| on.click (fun _ _ -> currentCodeSnippetId.Value <- code.id)
                                  ]
                          span    [ ``class``   "predecessor"
                                    title       "toggle predecessor"
                                    SomeAttr <| on.click(fun _ _ -> Val.iter (togglePredecessorForCur code) currentCodeSnippetO)
                                    htmlText    "X"
                                  ]
                          ])
      
      let listEntries snps =
          div [ 
              yield style "overflow: auto"
              yield! 
                  snps
                  |> Seq.indexed
                  |> Seq.mapFold (fun expanded (i, snp) ->
                      if snp.parent |> Option.map (fun p -> Set.contains p expanded) |> Option.defaultValue true then 
                          let isParent    = codeSnippets |> Seq.tryItem (i + 1) |> Option.map (fun nxt -> nxt.parent = Some snp.id) |> Option.defaultValue false
                          let isExpanded  = isParent && snp.expanded
                          (listEntry isParent isExpanded snp |> Some, if isExpanded then Set.add snp.id expanded else expanded)
                      else  (None, expanded)
                  )  (Set [])
                  |> fst
                  |> Seq.choose id
          ]
      # 1 @"(6)54304360-819a-498c-a091-e6ece880a35a Deserialize.fsx"
      let inline ifUndef def v = if isUndefined v then def else v
      let obj2CodeSnippetId o = 
          if isUndefined o then
              System.Guid("00000000-0000-0000-0000-000000000000")
          else
              o?Item
          |> CodeSnippetId 
      
      let obj2CodeSnippetIdO o = // the json representation of an option is different from the internal representation
          if isUndefined o then
              None
          else
              Some <| obj2CodeSnippetId o
      
      let obj2Map o =
          if isUndefined o then
              Map.empty
          else
              JS.GetFields o |> Array.map (fun (f, v) -> f, v :?> string ) |> Map.ofSeq
      
      let deserializeCodeSnipets v = 
          try
              let objs= WebSharper.Json.Parse v |> unbox<obj[]>
              printfn "%A" <| Array.length objs
              let snps =
                  objs
                  |> Array.choose (fun o ->
                       if isUndefined o then None else
                       {
                          name         = o?name         |> ifUndef ""
                          content      = o?content      |> ifUndef ""
                          parent       = o?parent       |> obj2CodeSnippetIdO
                          predecessors = o?predecessors |> ifUndef [||] |> Array.map  obj2CodeSnippetId |> Seq.toList
                          id           = o?id           |> obj2CodeSnippetId
                          expanded     = o?expanded     |> ifUndef false
                          level        = o?level        |> ifUndef 0
                          properties   = o?properties   |> obj2Map
                        } |> Some)
              snps
          with _ -> [||]
      # 1 @"(6)60191ea0-da20-4fbf-96b8-3871338a66d8 Add,Delete,Load,Save.fsx"
      let addCode   ()   =
          CodeSnippet.PickIO currentCodeSnippetId.Value
          |> Option.map (fun (i, snp) -> CodeSnippet.New(i + 1, "", snp.parent, [], [], ""))
          |> Option.defaultWith (fun _ -> CodeSnippet.New "")
          |> fun n -> currentCodeSnippetId.Value <- n.id
          setDirty()
          refreshView()
      
      
      let deleteCode () =
          CodeSnippet.FetchO currentCodeSnippetId.Value
          |> Option.iter (fun snp -> 
              if JS.Confirm (sprintf "Do you want to delete %s?" snp.Name) then
                  currentCodeSnippetId.Value <- CodeSnippetId.New
                  codeSnippets.Remove snp
                  setDirty()
                  refreshView()
          )
          
      let justFileName (f:string) = f.Split [| '/' ; '\\' |] |> Seq.last
      
      let fileName  = Var.Create ""
      let emptyFile = Val.map (fun v -> v = "") fileName
      
      let loadTextFile element (f: string -> unit) =
          let files = element |> FileList.OfElement 
          if files.Length > 0 then
              let  reader  = TextFileReader()
              reader.Onload <- (fun e -> f e.Target?result)
              reader.ReadAsText files.[0] 
      
      let fileInputElementId = "CodeEditorFileSel"
      let loadFile (e: Dom.Element) =
          if (not dirty.Value) || JS.Confirm "Changes have not been saved, do you really want to load?" then
            let root = findRootElement e
            loadTextFile (root.QuerySelector("#" + fileInputElementId))
              (fun txt ->
                  try
                      txt
                      |> deserializeCodeSnipets
                      |> codeSnippets.Set
                      setClean()
                      refreshView()
                  with e -> JS.Alert <| e.ToString()
              )
      
      [< Inline "saveAs(new Blob([$txt], {type: 'text/plain;charset=utf-8'}), $name)" >]
      let saveAs (txt:string) (name:string) = ()
      
      let downloadFile() =
          codeSnippets.Value
              |> Seq.toArray
              |> Json.Serialize
              |> saveAs <| match justFileName fileName.Value with | "" -> "snippets.fsjson" | fname -> fname
          setClean()
      
      let loadFileElement =
          Template.Input.New(fileName.Lens justFileName (fun prev n -> prev) )
              .Prefix( label [ ``class`` "btn btn-primary" ; htmlText "Load File..." 
                               Template.Input.New(fileName)
                                       .Type("file")
                                       .Style("display: none")
                                       .Content([ on.change (fun el _ -> loadFile el   )
                                                  on.click  (fun el _ -> el?value <- "")
                                                ])
                                       .Id(fileInputElementId)
                                       .Render 
                              ]
                      )
      
      let Do f = (fun _ _ -> f())
      # 1 @"(6)47f7c0ba-35b0-466e-a759-4e4d9963e524 codeMirror.fsx"
      open Useful
      
      let autoCompleteClient = FSAutoComplete.FSAutoCompleteClient("FSharpStation")
      let parseFile = @"..\F#.fsx"
      
      type KeyMapAutoComplete = { 
          F2              : Template.CodeMirrorEditor -> unit 
          LeftDoubleClick : Template.CodeMirrorEditor -> unit
          ``Ctrl-Space``  : Template.CodeMirrorEditor -> unit
      }
      
      let setDirtyCond() =
          match lastCodeAndStarts with
          | Some (pId, _, red) when pId = currentCodeSnippetId.Value -> setDirtyPart()
          | _                                                        -> setDirty    ()
      
      let getCodeAndStartsFast msgF (snp:CodeSnippet) addLinePrepos =
          let red0, cur = 
              match lastCodeAndStarts with
              | Some (pId, alp, red) when pId = snp.id && alp = addLinePrepos -> msgF "Reparsing..."; red, snp.PrepareSnippet
              | _ -> 
              msgF "Parsing..."
              let preds = snp.Predecessors()
              let red = CodeSnippet.ReducedCode addLinePrepos preds.[0..preds.Length - 2]
              let cur = preds.[preds.Length - 1]
              lastCodeAndStarts <- Some(cur.id, addLinePrepos, red)
              red, cur
          let red1 = CodeSnippet.ReducedCode addLinePrepos [| cur |]
          CodeSnippet.AddSeps red0 red1
          |> CodeSnippet.FinishCode addLinePrepos
      
      let mutable parseRun = 1
      
      let parseFSA silent =
          async {
              let msgF = if silent then ignore else fun txt -> codeMsgs.Value <- txt
              match CodeSnippet.FetchO currentCodeSnippetId.Value with 
              | None     -> ()
              | Some cur ->
              let runN = parseRun + 1
              parseRun <- runN
              let  code, starts = getCodeAndStartsFast msgF cur false
              let! res          = autoCompleteClient.Parse(parseFile, code, starts)
              parsed           <- true
              if not silent && runN = parseRun then
                  sendMsg res
                  sendMsg "Parsed!"
          }
      
      let parseFS() = 
          async {
              lastCodeAndStarts <- None
              do! parseFSA false
          } |> Async.Start 
      
      let parseIfMustThen (cur:CodeSnippet) silent =
          async {
              if not parsed then do! parseFSA silent else
              let! must = autoCompleteClient.MustParse(parseFile, cur.NameSanitized)
              if must       then do! parseFSA silent
          }
      
      let getStartWord (line:string) ch =
          match line.Substring(0, ch) with
          | REGEX @"([a-zA-Z_]\w*)$" "g" [| txt |] -> txt
          | _                                      -> ""          
      
      let getEndWord (line:string) ch =
          match line.Substring(ch) with
          | REGEX @"^([a-zA-Z_]\w*)" "g" [| txt |] -> txt
          | _                                      -> ""          
      
      let showToolTip (ed:Template.CodeMirrorEditor) =
          async {
              match CodeSnippet.FetchO currentCodeSnippetId.Value with 
              | None     -> ()
              | Some cur ->
              do!  parseIfMustThen cur false
              let  pos   = ed.GetCursor()
              let  l     = ed.GetLine pos.line
              let  sub   = (getStartWord l pos.ch |> String.length)   
              let  add0  = (getEndWord   l pos.ch |> String.length)    
              let  add   = if sub = 0 && add0 = 0 then 2 else add0 
              let! tip   = autoCompleteClient.ToolTip  (parseFile, pos.line + 1, pos.ch + 1, cur.NameSanitized)
              sendMsg <| sprintf "InfoFSharp \"%s %A - %A %s \"" cur.NameSanitized (pos.line + 1, pos.ch - sub + 1) (pos.line + 1, pos.ch + add + 1) (tip.Replace("\"","''"))
          } |> Async.Start
      
      let getHints (ed:Template.CodeMirrorEditor, cb, _) =
          async {
              match CodeSnippet.FetchO currentCodeSnippetId.Value with 
              | None     -> ()
              | Some cur ->
              do!  parseIfMustThen cur true
              let  pos    = ed.GetCursor()
              let  l      = ed.GetLine pos.line
              let  word   = getStartWord l pos.ch     
              let! com    = autoCompleteClient.Complete(parseFile, pos.line + 1, pos.ch + 1, cur.NameSanitized)
              cb { Template.list   = com 
                                     |> Array.map (fun (dis, rep, cls, chr) -> 
                                          { text        = rep
                                            displayText = chr + "| " + dis
                                            className   = cls                              
                                          })
                   Template.from   = { pos with ch = pos.ch - word.Length }
                   Template.``to`` = pos 
                 }
          } |> Async.Start
          
      let rex1 = """\((\d+)\) F# (.+).fsx\((\d+)\,(\d+)\): (error|warning) ((.|\b)+)"""
      let rex2 = """(Err|Warning|Info)(FSharp|WebSharper)\s+"(\((\d+)\) ?)?F?#? ?(.+?)(.fsx)? \((\d+)\,\s*(\d+)\) - \((\d+)\,\s*(\d+)\) ((.|\s)+?)""" + "\""
      let rex = rex1 + "|" + rex2
      
      let getAnnotations (txt, cb, _, ed:Template.CodeMirrorEditor) =
          async {
              match CodeSnippet.FetchO currentCodeSnippetId.Value with 
              | None     -> ()
              | Some cur ->
              do!  parseIfMustThen cur false
              match codeMsgs.Value with
              | REGEX rex "g" m -> m
              | _               -> [||]
              |> Array.choose (fun v ->
                  match v with
                  | REGEX rex2 "" [| _ ; sev; from;  _; indent; file; _; fl; fc; tl; tc; msg; _ |] -> Some (file, int fl, int fc - int indent    , int tl, int tc - int indent, sev, from , msg)
                  | REGEX rex1 "" [| _ ;                indent; file   ; fl; fc;    sev; msg; _ |] -> Some (file, int fl, int fc - int indent - 1, int fl, int fc - int indent, sev, "fsi", msg)
                  | _ -> None
              )
              |> Array.choose (fun (file, fl, fc, tl, tc, sev, from, msg) ->
                  if file.StartsWith cur.id.Text || file = sanitize cur.name then
                      { Template.LintResponse.message  = msg
                        Template.LintResponse.severity = (if sev.ToUpper().StartsWith("ERR") then "error" elif sev.ToUpper().StartsWith("INFO") then "info" else "warning")
                        Template.LintResponse.from     = Template.cmPos(fl - 1, fc - 1) 
                        Template.LintResponse.``to``   = Template.cmPos(tl - 1, tc - 1)
                      } |> Some
                  else     None
                )
              |> cb
          } |> Async.Start
      
      let codeMirror = 
          Template.CodeMirror.New(Val.bindIRef curSnippetCodeOf currentCodeSnippetId)
              .OnChange(setDirtyCond)
              .OnRender(fun ed ->
                ed.AddKeyMap({  F2              = showToolTip            
                                LeftDoubleClick = showToolTip
                                ``Ctrl-Space``  = Template.showHints ed getHints false
                             })
                Template.setLint ed getAnnotations 
              )
              .Style("height: 100%")
      
      codeMsgs
      |> Val.sink (fun msgs ->
          async {
              if not parsed then () else
              match codeMirror.editorO  with
              | None    -> () 
              | Some ed ->
              match CodeSnippet.FetchO currentCodeSnippetId.Value with 
              | None     -> ()
              | Some cur ->
              let! must = autoCompleteClient.MustParse(parseFile, cur.NameSanitized)
              if must       then () else
              ed?performLint() |> ignore
          } |> Async.Start      
      )
      //let mutable prior = "", ""
      //Val.map2 (fun msgs curO -> msgs, curO) codeMsgs currentCodeSnippetO
      //|> Val.sink (fun (msgs, curO) ->
      //    async {
      //        match codeMirror.editorO  with
      //        | None        -> () 
      //        | Some editor ->
      //            match curO with 
      //            | None -> () 
      //            | Some cur ->
      //            curSnippetNameOf cur.id
      //            |> Val.iter (fun name ->
      //                printfn "RemoveMarks: %s" name
      //                if prior = (msgs, name) then () else
      //                prior   <- (msgs, name)
      //                editor.RemoveMarks()
      //                match msgs with
      //                | REGEX rex "g" m -> m
      //                | _               -> [||]
      //                |> Array.choose (fun v ->
      //                    match v with
      //                    | REGEX rex2 "" [| _ ; sev; from;  _; indent; file; _; fl; fc; tl; tc; msg; _ |] -> Some (file, int fl, int fc - int indent    , int tl, int tc - int indent, sev, from , msg)
      //                    | REGEX rex1 "" [| _ ;                indent; file   ; fl; fc;    sev; msg; _ |] -> Some (file, int fl, int fc - int indent - 1, int fl, int fc - int indent, sev, "fsi", msg)
      //                    | _ -> None
      //                )
      //                |> Array.iter (fun (file, fl, fc, tl, tc, sev, from, msg) ->
      //                    printfn "inside -%s-%s-" file (sanitize name)
      //                    if file.StartsWith cur.id.Text || file = sanitize name then
      //                        100
      //                        |> JS.SetTimeout (fun () ->
      //                            editor.MarkText (fl - 1, fc - 1) (tl - 1, tc - 1) (if sev.ToUpper().StartsWith("ERR") then "Error" else "Warning")  msg)
      //                        |> ignore
      //    
      //                )
      //            )
      //    } |> Async.Start
      //)
      
      # 1 @"(6)fa5b4506-b26d-4387-8e04-ac7a5a90861a styleEditor.fsx"
      let styleEditor    =
           """
      div textarea {
      font-family: monospace;
      }
      .code-editor-list-tile {
      white-space: nowrap; 
      border-style: solid none none;
      border-color: white;
      border-width: 1px;
      background-color: #D8D8D8;
      display: flex;
      }
      .code-editor-list-text{
      padding: 1px 10px 1px 5px;
      overflow:hidden;
      text-overflow: ellipsis;
      white-space: nowrap;
      flex: 1;
      }
      
      .code-editor-list-tile.direct-predecessor {
      font-weight: bold;
      }
      .code-editor-list-tile.indirect-predecessor {
      color: blue;
      }
      .code-editor-list-tile.selected {
      background-color: #77F;
      color: white;
      }
      .code-editor-list-tile.hovering {
      background: lightgray;
      }
      .code-editor-list-tile.hovering.selected {
      background:  blue;
      }
      .code-editor-list-tile>.predecessor {
      font-weight: bold;
      border-style: inset;
      border-width: 1px;
      text-align: center;
      color: transparent;
      }
      .code-editor-list-tile.direct-predecessor>.predecessor {
      color: blue;
      }
      
      .CodeMirror { height: 100%; }
      
      .node {
          background-color:white; 
          width: 2ch; 
          color: #A03; 
          font-weight:bold; 
          text-align: center;
          font-family: arial;
      }
      .Warning { text-decoration: underline lightblue } 
      .Error   { text-decoration: underline red       } 
      .body    { margin         : 0px                 }
          """
      # 1 @"(6)75c3d033-99b5-409f-8ecb-cd9bd8b101ab CodeEditorGrid.fsx"
      let spl1         = Template.SplitterBar.New(20.0).Children([ style "grid-row: 2 / 4" ])
      storeVarCodeEditor "splitterV1" spl1.Var
      //storeVarCodeEditor "splitterV2" splitterV2.Var
      //storeVarCodeEditor "splitterH3" splitterH3.Var
      
      let Messages =
          [
           "Output"    , Template.TextArea.New(codeMsgs).Placeholder("Output:"    ).Title("Messages"                 ).Render
           "JavaScript", Template.TextArea.New(codeJS  ).Placeholder("Javascript:").Title("JavaScript code generated").Render
           "F# code"   , Template.TextArea.New(codeFS  ).Placeholder("F# code:"   ).Title("F# code assembled"        ).Render
           "WS Result" , div [ div [ Id "TestNode" ; style "background: white; height: 100%; width: 100%; "] ]
          ]
      
      let CodeEditor() =
        Template.Grid.New
           .ColVariable(spl1)
           .ColAuto(     0.0)
           .ColVariable( 0.0).Min(0.0).Max(Val.map ((-) 92.0) spl1.GetValue).Before.Children([ style "grid-row   : 1 / 5" ])
           .RowFixedPx( 34.0) 
           .RowAuto(     0.0)
           .RowVariable(17.0)                                               .Before.Children([ style "grid-column: 2 / 3" ])
           .RowFixedPx( 80.0)
           .Padding(1.0)
           .Content("sidebar", 
               codeSnippets.View
               |> View.SnapshotOn codeSnippets.Value refresh.View
               |> bindHElem listEntries
            )
           .Content("header"  , Template.Input     .New(Val.bindIRef curSnippetNameOf currentCodeSnippetId).Prefix(htmlText "name:")         .Render)
           .Content("content1", codeMirror                                                                                                   .Render)
           .Content("content2", Template.TabStrip  .New(Messages).Top                                                                        .Render)
           .Content("footer"  ,       
              div [ 
                    Template.Button.New("Add code"              ).Class("btn btn-xs"     ).OnClick(Do addCode      )                          .Render
                    Template.Button.New("<<"                    ).Class("btn btn-xs"     ).OnClick(Do indentCodeOut).Disabled(noSelectionVal) .Render
                    Template.Button.New(">>"                    ).Class("btn btn-xs"     ).OnClick(Do indentCodeIn ).Disabled(noSelectionVal) .Render
                    loadFileElement.Render.AddChildren([ style "grid-column: 4/6" ])
                    Template.Button.New("Parse F#"              ).Class("btn btn-xs"     ).OnClick(Do parseFS      ).Disabled(noSelectionVal) .Render
                    Template.Button.New("Evaluate F# (FSI)"     ).Class("btn btn-xs"     ).OnClick(Do evaluateFS   ).Disabled(noSelectionVal) .Render
                    Template.Button.New("Get F# code ==>"       ).Class("btn btn-xs"     ).OnClick(Do getFSCode    ).Disabled(noSelectionVal) .Render
             
                    Template.Button.New("Delete code"           ).Class("btn btn-xs"     ).OnClick(Do deleteCode   ).Disabled(noSelectionVal) .Render
                    span []       
                    span []       
                    Template.Button.New("Save as..."            ).Class("btn            ").OnClick(Do downloadFile )                          .Render.AddChildren([classIf "btn-primary" dirty])
                    span []
                    Template.Button.New("Compile WebSharper"    ).Class("btn btn-xs"     ).OnClick(Do justCompile  ).Disabled(noSelectionVal) .Render
                    Template.Button.New("Run WebSharper in ..." ).Class("btn btn-xs"     ).OnClick(Do compileRun ).Disabled(noSelectionVal) .Render
                    Doc.Select [ attr.id "Position" ] positionTxt [ Below ; Right ; NewBrowser ] position |> someElt
                    style """
                        overflow: hidden;
                        display: grid;
                        grid-template-columns: repeat(8, 12.1%);
                        bxackground-color: #eee;
                        padding : 5px;
                        grid-gap: 5px;
                    """
                  ]
              )
           .Content( script [ src  "/EPFileX/FileSaver/FileSaver.js"                                     ; ``type`` "text/javascript"             ] )
           .Content( script [ src  "http://code.jquery.com/jquery-3.1.1.min.js"                          ; ``type`` "text/javascript"             ] )
           .Content( script [ src  "http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"  ; ``type`` "text/javascript"             ] )
           .Content( link   [ href "http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"; ``type`` "text/css" ; rel "stylesheet" ] )
           .Content( link   [ href "/EPFileX/css/main.css"                                               ; ``type`` "text/css" ; rel "stylesheet" ] )
           .Content( css styleEditor                                                                                                                )
           .Render
           .Style(""" 
                  grid-template-areas:
                      'header0 header   sidebar2'
                      'sidebar content1 sidebar2'
                      'sidebar content2 sidebar2'
                      'footer  footer   sidebar2';
                  color      : #333;
                  height     : 100%;
                  font-size  : small;
                  font-family: monospace;
                  line-height: 1.2;
                      """)
      
      
      # 1 @"(6)8ee8705a-f115-437e-8d7d-418773f3c6d4 Editor2.fsx"
      open Template
      
      let snippetList = 
          codeSnippets.View
             |> View.SnapshotOn codeSnippets.Value refresh.View
             |> bindHElem listEntries
             
      let buttonsH =
          div [ 
                Template.Button.New("Add code"              ).Class("btn btn-xs"     ).OnClick(Do addCode      )                          .Render
                Template.Button.New("<<"                    ).Class("btn btn-xs"     ).OnClick(Do indentCodeOut).Disabled(noSelectionVal) .Render
                Template.Button.New(">>"                    ).Class("btn btn-xs"     ).OnClick(Do indentCodeIn ).Disabled(noSelectionVal) .Render
                loadFileElement.Render.Style("grid-column: 4/6")
                Template.Button.New("Parse F#"              ).Class("btn btn-xs"     ).OnClick(Do parseFS      ).Disabled(noSelectionVal) .Render
                Template.Button.New("Evaluate F# (FSI)"     ).Class("btn btn-xs"     ).OnClick(Do evaluateFS   ).Disabled(noSelectionVal) .Render
                Template.Button.New("Get F# code ==>"       ).Class("btn btn-xs"     ).OnClick(Do getFSCode    ).Disabled(noSelectionVal) .Render
          
                Template.Button.New("Delete code"           ).Class("btn btn-xs"     ).OnClick(Do deleteCode   ).Disabled(noSelectionVal) .Render
                span []       
                span []       
                Template.Button.New("Save as..."            ).Class("btn            ").OnClick(Do downloadFile )                          .Render.AddChildren([classIf "btn-primary" dirty])
                span []
                Template.Button.New("Compile WebSharper"    ).Class("btn btn-xs"     ).OnClick(Do justCompile  ).Disabled(noSelectionVal) .Render
                Template.Button.New("Run WebSharper in ..." ).Class("btn btn-xs"     ).OnClick(Do compileRun   ).Disabled(noSelectionVal) .Render
                Doc.Select [ attr.id "Position" ] positionTxt [ Below ; NewBrowser ] position |> someElt
                style """
                    overflow: hidden;
                    display: grid;
                    grid-template-columns: repeat(8, 12.1%);
                    bxackground-color: #eee;
                    padding : 5px;
                    grid-gap: 5px;
                """
              ]
      
      let inline fixedHorSplitter1 px ch1 ch2 =
          let grid = Grid.New.Content("one", renderSplitterNode ch1)
                             .Content("two", renderSplitterNode ch2).Padding(0.0)
          grid.RowFixedPx(px).RowAuto(50.0).Content( style "grid-template-areas: 'one' 'two' " ).Render
      
      let inline fixedHorSplitter2 px ch1 ch2 =
          let grid = Grid.New.Content("one", renderSplitterNode ch1)
                             .Content("two", renderSplitterNode ch2).Padding(0.0)
          grid.RowAuto(50.0).RowFixedPx(px).Content( style "grid-template-areas: 'one' 'two' " ).Render
      
      
      let title         = SHtmlNode <| Template.Input.New(Val.bindIRef curSnippetNameOf currentCodeSnippetId).Prefix(htmlText "name:").Render
      let messages      = STabStrip <| TabStrip.New(Messages).Top
      let code          = SHtmlNode <| codeMirror.Render
      let snippets      = SHtmlNode <| snippetList
      let buttons       = SHtmlNode <| buttonsH
      
      let title_code    = SplitterStructure.New(       title        , code        , fixedHorSplitter1 34.0)
      let code_buttons  = SplitterStructure.New(       title_code   , buttons     , fixedHorSplitter2 80.0)
      let snippets_code = SplitterStructure.New(true , snippets     , code_buttons,                   15.0)
      let main_messages = SplitterStructure.New(false, snippets_code, messages    ,                   82.0)
      
      //let code_messages = SplitterStructure.New(false, title_Code           , STabStrip messages,                   75.0)
      //let main_Buttons  = SplitterStructure.New(       snippets_code        , SHtmlNode buttons                 , fixedHorSplitter2 80.0)
      
      
      let rootSplitter = SplitterNode.New(main_messages)
      
      div [ style "height: 100vh; width: 100% "
            rootSplitter.Render.Style("height: 100%; width: 100% ")
            script [ src  "/EPFileX/FileSaver/FileSaver.js"                                     ; ``type`` "text/javascript"             ]
            script [ src  "http://code.jquery.com/jquery-3.1.1.min.js"                          ; ``type`` "text/javascript"             ]
            script [ src  "http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"  ; ``type`` "text/javascript"             ]
            link   [ href "http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"; ``type`` "text/css" ; rel "stylesheet" ]
            link   [ href "/EPFileX/css/main.css"                                               ; ``type`` "text/css" ; rel "stylesheet" ]
            css styleEditor                                                                                                               
            style  """ 
                  color      : #333;
                  font-size  : small;
                  font-family: monospace;
                  line-height: 1.2;
                      """
          ]
      |> renderDoc
      |> Doc.Run JS.Document.Body
      