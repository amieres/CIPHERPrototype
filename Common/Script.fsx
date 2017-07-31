//#define WEBSHARPER
#r @"ZafirTranspiler.dll"
#r @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.1\System.Web.dll"
#r @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.1\System.Core.dll"
    
#r @"WebSharper.Core.dll"
#r @"WebSharper.Collections.dll"
#r @"WebSharper.Main.dll"
#r @"WebSharper.UI.Next.dll"
#r @"WebSharper.JavaScript.dll"
#r @"WebSharper.Web.dll"
#r @"WebSharper.UI.Next.dll"
#r @"WebSharper.Sitelets.dll"
    
#r @"WebSharper.Core.dll"
#r @"WebSharper.Main.dll"
#r @"WebSharper.Web.dll"
#r @"Common.dll"
      
#r "remote.dll"
      
      open CIPHERPrototype.Messaging
      
#r @"WebSharper.Core.dll"
#r @"WebSharper.Main.dll"
#r @"WebSharper.Web.dll"
#r @"Common.dll"
      
//@" F# FSSGlobal.fsx"
#nowarn "1182"
#nowarn "40"

#if INTERACTIVE
#I @"../WebServer/bin"
module FSSGlobal   =
#else
namespace FSSGlobal
#endif

//@" F# Evaluate F# Code.fsx"
// Code to be evaluated using FSI: `Evaluate F#`
//@"(4) F# FsStationShared.fsx"
#if WEBSHARPER
    [<WebSharper.JavaScript>]
#endif
    module FsStationShared =
//@"(6) F# CodeSnippet.fsx"
      type CodeSnippetId = CodeSnippetId of System.Guid        
      with static member New = CodeSnippetId <| System.Guid.NewGuid()
      
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
      
      
      type CodeSnippet = {
          name         : string
          content      : string
          parent       : CodeSnippetId option
          predecessors : CodeSnippetId list
          companions   : CodeSnippetId list
          id           : CodeSnippetId
          expanded     : bool
      } with
          member this.Name = snippetName this.name this.content
      
      
//@"(6) F# type FSMessage =.fsx"
      type FSMessage =
          | GetSnippetContentById of CodeSnippetId
          | GetSnippetCodeById    of CodeSnippetId
          | GetSnippetById        of CodeSnippetId
          | GetSnippetContent     of string []
          | GetSnippetCode        of string []
          | GetSnippet            of string []
          | GenericMessage        of string
          | GetIdentification
      
      type FSResponse =
          | SnippetResponse   of CodeSnippet option
          | StringResponse    of string option
          | IdResponse        of string
      
      
//@"(6) F# MessagingClient.fsx"
      open WebSharper
      open WebSharper.Remoting
      open Rop
      
      type MessagingClient(clientId, ?endPoint:string) =
          let wsEndPoint = endPoint    |> Option.defaultValue "http://localhost:9000/FSharpStation.html"
          let fromId     = AddressId clientId
          do WebSharper.Remoting.EndPoint <- wsEndPoint 
          let awaitMessage respond =
              async {
                  while true do
#if WEBSHARPER
                      let! msg   = awaitRequestFor    fromId
#else
                      let! msg   = awaitRequestForRpc fromId
#endif                
                      let  resp  = respond clientId msg.content
#if WEBSHARPER
                      do!          replyTo    msg.messageId.Value resp
#else
                      do!          replyToRpc msg.messageId.Value resp
#endif                
              } |> Async.Start
#if WEBSHARPER
          let sendMessage  toId msg = sendRequest    toId fromId msg
#else
          let sendMessage  toId msg = sendRequestRpc toId fromId msg
#endif                
          let poMessage msg =
              async {
                  let! resp = sendMessage (AddressId "WebServer:PostOffice") (Json.Serialize<POMessage> msg)
                  return resp |> Json.Deserialize<POResponse>
              }
        with 
          member this.AwaitMessage respond = awaitMessage respond
          member this.SendMessage toId msg = sendMessage toId msg
          member this.POMessage        msg = poMessage msg
          member this.POListeners      ()  = 
              async {
                  let! resp = poMessage POListeners
                  return
                      match resp with
                      | POString  v  -> [| v |]
                      | POStrings vs -> vs
              }
          member this.EndPoint             = wsEndPoint
          static member EndPoint_          = "http://localhost:9000/FSharpStation.html"
          
          
      
      
//@"(6) F# FsStationClient.fsx"
      open WebSharper
      open WebSharper.JavaScript
      open WebSharper.Remoting
      open CIPHERPrototype.Messaging
      open Rop
      
      type FsStationClientErr =
          | SnippetNotFound of string
      with interface ErrMsg with
              member this.ErrMsg    = 
                  match this with 
                  | msg                        -> sprintf "%A" msg
              member this.IsWarning = false     
      
      type FsStationClient(clientId, ?fsStationId:string, ?endPoint:string) =
          let fsIds      = fsStationId |> Option.defaultValue "FSharpStation-362703e5-e01a-4bac-a083-6fc6eefe0f26"
          let wsEndPoint = endPoint    |> Option.defaultValue "http://localhost:9000/FSharpStation.html"
          let msgClient  = MessagingClient(clientId, wsEndPoint)
          let toId       = AddressId fsIds
          let sendMessage (msg:FSMessage) =
              Wrap.wrapper {
                  let! response = msgClient.SendMessage toId (Json.Serialize msg)
                  return response |> Json.Deserialize<FSResponse>
              } 
          let requestCode (snpName:string) = 
              Wrap.wrapper {
                  let! response = sendMessage (snpName.Split '/' |> GetSnippetCode)
                  let! resp =
                      match response with
                      | StringResponse (Some code)    -> Result.succeed code
                      | _                             -> Result.fail    (SnippetNotFound <| response.ToString()) 
                  return resp
              } 
          let genericMessage txt = 
              Wrap.wrapper {
                  let! response = sendMessage (GenericMessage txt)
                  let! resp =
                      match response with
                      | StringResponse (Some code)    -> Result.succeed code
                      | _                             -> Result.fail    (SnippetNotFound  <| response.ToString()) 
                  return resp
              } 
        with 
          member this.SendMessage    msg     = sendMessage   msg
          member this.RequestCode    snpPath = requestCode    snpPath
          member this.GenericMessage txt     = genericMessage txt
          member this.FSStationId            = fsIds
          member this.MessagingClient        = msgClient    
          static member FSStationId_       = "FSharpStation-362703e5-e01a-4bac-a083-6fc6eefe0f26"
      
      
//@" F# WebSharper Code.fsx"
(*
 Code to be Compiled to Javascript and run in the browser
 using `Compile WebSharper` or `Run WebSharper`
*)
//@"(4) F# open WebSharper.fsx"
    open WebSharper
    open WebSharper.JavaScript
    open WebSharper.UI.Next
    open WebSharper.UI.Next.Client
    type on   = WebSharper.UI.Next.Html.on
    type attr = WebSharper.UI.Next.Html.attr
    
//@"(4) F# module HtmlNode      =.fsx"
    
    [<JavaScript>]
    module HtmlNode      =
    
//@"(6) F# type Val'a =.fsx"
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
          
              contentVar.View |> View.Sink (fun v -> !changingIRefO |> Option.iter (fun r -> if r.Value <> v then r.Value <- v))
          
              view |> View.Bind (fun cur ->
                  let r = f cur
                  changingIRefO    := Some r
                  contentVar.Value <- r.Value
                  r.View
              ) |> View.Sink (fun v -> contentVar.Value <- v)
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
      
//@"(6) F# type HtmlNode =.fsx"
      [<NoComparison ; NoEquality>]
      type HtmlNode =
          | HtmlElement   of name: string * children: HtmlNode seq
          | HtmlAttribute of name: string * value:    Val<string>
          | HtmlText      of Val<string>
          | HtmlEmpty
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
          | HtmlElement(name, children) -> Some <| (Doc.Element name (getAttrsFromSeq children) (children |> Seq.choose chooseNode) :> Doc)
          | HtmlText    vtext           -> Some <| Val.tagDoc WebSharper.UI.Next.Html.text vtext
          | SomeDoc     doc             -> Some <| doc
          | _                           -> None
      
      let getAttrChildren attr =
          Seq.tryPick (function 
                      | HtmlAttribute(a, v) when a = attr -> Some v 
                      | _                                 -> None)
          >> Option.defaultValue (Constant "")
      
      let mapHtmlElement f element =
          match element with
          | HtmlElement(name, children) -> f name  children
          | _                           -> element
      
      let getAttr attr element =
          match element with
          | HtmlElement(_, children) -> children
          | _                        -> seq []
          |> getAttrChildren attr
      
      let getClass = getAttr "class"
      let getStyle = getAttr "style"
      
      let replaceAttribute att (children: HtmlNode seq) newVal =
          HtmlAttribute(att, newVal)
          :: (children
              |> Seq.filter (function HtmlAttribute(old, _) when old = att -> false | _ -> true)
              |> Seq.toList
             )
      
      let replaceAtt att node newVal = mapHtmlElement (fun n ch -> HtmlElement(n, replaceAttribute att ch newVal)) node
      
      type HtmlNode with
          member inline this.toDoc = 
              match this with
              | HtmlAttribute _
              | HtmlEmpty       -> Doc.Empty
              | _               -> chooseNode this |> Option.defaultValue Doc.Empty
          member inline   this.Class          clas = Val.fixit clas |> replaceAtt "class" this
          member          this.AddChildren    add  = mapHtmlElement (fun n ch -> HtmlElement(n, Seq.append ch  add )) this
          member          this.InsertChildren add  = mapHtmlElement (fun n ch -> HtmlElement(n, Seq.append add ch  )) this
      
      let renderDoc = chooseNode >> Option.defaultValue Doc.Empty
          
//@"(6) F# let inline atr att v = Val.attrV  att (Val.fixit v).fsx"
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
      
      let composeDoc elt dtl dtlVal = dtlVal |> Val.toView |> Doc.BindView (Seq.append dtl >> elt >> renderDoc) |> SomeDoc
      
      let inline bindHElem hElem v  = Doc.BindView (hElem >> renderDoc)  (Val.toView <| Val.fixit v)            |> SomeDoc
      
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
      
//@"(4) F# open HtmlNode.fsx"
    open HtmlNode
//@"(4) F# module Template      =.fsx"
    [<JavaScript>]
    module Template      =
//@"(6) F# type Button = {.fsx"
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
//@"(6) F# type Input = {.fsx"
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
//@"(6) F# type Panel = {.fsx"
      [<NoComparison ; NoEquality>]
      type Panel = {
          _class   : Val<string>
          _style   : Val<string>
          title    : Val<string>
          header   : HtmlNode seq
          content  : HtmlNode seq
          disabled : Val<bool>
      } with
        static member  New   = { _class   = Val.fixit <| "panel panel-default shadow"
                                 _style   = Val.fixit <| "text-align:center" 
                                 title    = Val.fixit <| "Panel"        
                                 header   =          [ htmlText "Some text"    ] 
                                 content  =          [ htmlText "Some Content" ] 
                                 disabled = Val.fixit <| Var.Create false
                               }
        member        this.Render          =  
          fieldset [ SomeAttr <| attr.disabledDynPred (View.Const "")  (this.disabled |> Val.toView)
                     div [ ``class`` this._class
                           div (Seq.append
                                    [ ``class`` "panel-heading"
                                      label [ ``class``  "panel-title text-center" ; htmlText this.title ]
                                    ]
                                    this.header)
      
                           div (Seq.append
                                    [ ``class`` "panel-body"
                                      style     this._style 
                                    ]
                                    this.content)
                         ] 
                   ]
        member inline this.Class       clas = { this with _class   = Val.fixit clas                                        }
        member inline this.Style       sty  = { this with _style   = Val.fixit sty                                         }
        member inline this.Title       txt  = { this with title    = Val.fixit txt                                         }
        member inline this.Header      h    = { this with header   =       h                                           }
        member inline this.Content     c    = { this with content  =       c                                           }
        member inline this.Disabled    dis  = { this with disabled =       dis                                         }
      
//@"(6) F# type TextArea = {.fsx"
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
          someElt 
          <| Doc.InputArea
              [ 
                _class              this._class
                attr.id             this.id  
                atr "spellcheck" <| Val.map (fun spl -> if spl then "true" else "false") this.spellcheck
                atr "title"         this.title
                atr "style"        "height: 100%;  width: 100%"
                _placeholder        this.placeholder 
              ]
              this.var
          |> Seq.singleton |> span
        member inline this.Class       clas = { this with _class      = Val.fixit clas }
        member inline this.Placeholder plc  = { this with placeholder = Val.fixit plc  }
        member inline this.Title       ttl  = { this with title       = Val.fixit ttl  }
        member inline this.Spellcheck  spl  = { this with spellcheck  = spl            }
        member inline this.Id          id   = { this with id          = id             }
        member inline this.SetVar      v    = { this with var         = v              }
        member inline this.Var              = this.var
        
//@"(4) F# module RunCode       =.fsx"
    [<JavaScript>]
    module RunCode       =
//@"(6) F# module EditorRpc =.fsx"
      module EditorRpc =
          let callRPC asy callback =
              Async.StartWithContinuations(asy, callback, (fun e -> JS.Alert(e.ToString()) ), fun c -> JS.Alert(c.ToString()))
      
          let checkSource  callback          source = CIPHERPrototype.Editor.checkSource  source          |> callRPC <| callback
          let methods      callback line col source = CIPHERPrototype.Editor.methods      source line col |> callRPC <| callback
          let declarations callback line col source = CIPHERPrototype.Editor.declarations source line col |> callRPC <| callback
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
      
//@"(6) F# type RunNode(nodeName, clearNode bool) =.fsx"
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
//@"(6) F# AddBootstrap.fsx"
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
//@"(6) F# RunDoc.fsx"
        member inline this.RunDoc  doc  = doc  :> Doc       |> Doc.Run this.RunNode
//@"(6) F# RunHtml.fsx"
        member inline this.RunHtml node = node |> renderDoc |> this.RunDoc
//@"(6) F# RunHtmlPlusFree.fsx"
        member        this.RunHtmlPlusFree node =
          let freeHtml    = Var.Create ""
          let freeCSS     = Var.Create ""
          let freeFS      = Var.Create ""
          let freeJS      = Var.Create ""
          let freeMsgs    = Var.Create ""
          let sendMsg msg = 
              freeMsgs.Value  <- 
                  match freeMsgs.Value, msg with
                  | null, m 
                  | ""  , m
                  | m   , null
                  | m   , ""   -> m
                  | m1  , m2   -> m1 + "\n" + m2
          let runJS () =
              sendMsg "Running JavaScript..."
              try JS.Eval(freeJS.Value) |> (fun v -> sendMsg "Done!"; v.ToString())
              with e -> sendMsg "Failed!"; e.ToString()
              |> sendMsg
          let runFS () =
              freeMsgs.Value <- "Compiling to JavaScript..."
              freeJS.Value   <- ""
              compile (fun msgs js -> freeJS.Value <- js ; runJS() ) sendMsg freeFS.Value
          div [ style "height: 100%"
                node
                Template.Button.New("Eval F#").Style("vertical-align:top").OnClick(fun _ _ -> runFS()                        ).Render  
                someElt <| Doc.InputArea [ attr.placeholder "F#:"         ; attr.title "Add F# code and invoke with Eval F#" ] freeFS
                someElt <| Doc.InputArea [ attr.placeholder "HTML:"       ; attr.title "Enter HTML tags and text"            ] freeHtml 
                someElt <| Doc.InputArea [ attr.placeholder "CSS:"        ; attr.title "Test your CSS styles dynamically"    ] freeCSS 
                someElt <| Doc.InputArea [ attr.placeholder "JavaScript:" ; attr.title "Add JS code and invoke with Eval JS" ] freeJS
                Template.Button.New("Eval JS").Style("vertical-align:top").OnClick(fun _ _ -> freeMsgs.Value <- "" ; runJS() ).Render  
                someElt <| Doc.InputArea [ attr.placeholder "Output:"     ; attr.title "Messages"                            ] freeMsgs
                SomeDoc <| tag Doc.Verbatim (Val.map2 (sprintf "%s<style>%s</style>") freeHtml freeCSS)
          ]
          |> this.RunHtml
//@"(6) F# ShowHtmlResult.fsx"
        member inline this.ShowHtmlResult res =
          this.AddBootstrap |> ignore
          div [ ``class`` "container"
                Template.Panel.New
                  .Title("Result:")
                  .Header([])
                  .Content([ h3 res ; style "font-family:monospace;" ])
                  .Render
           ] |> this.RunHtml
        member inline this.ShowHtmlResult res = this.ShowHtmlResult [res]
      
//@"(6) F# ShowResult.fsx"
        member inline this.ShowResult res = htmlText (sprintf "%A" res) |> this.ShowHtmlResult
      
//@"(4) F# module Snippets      =.fsx"
    [< JavaScript >]
    module Snippets      =
//@"(6) F# Messaging Test.fsx"
      
      open CIPHERPrototype.Messaging
      open FsStationShared
      open System
      open Rop
      
      //let awaitMessage () =
      //    async {
      //        while true do
      //            let! msg = CIPHERPrototype.Editor.awaitRequestFor <| AddressId "FSharpStation1"
      //            message.Value <- msg.content
      //            do! CIPHERPrototype.Editor.replyTo msg.messageId.Value (sprintf "Ok message %A received." msg.messageId.Value)
      //    } |> Async.Start
      //
      //awaitMessage()
      
      //type CodeSnippetId = CodeSnippetId of System.Guid        
      
      let messageTypes = 
          [
              GetSnippetContentById CodeSnippetId.New
              GetSnippetCodeById    CodeSnippetId.New
              GetSnippetById        CodeSnippetId.New
              GetSnippetContent     [||]
              GetSnippetCode        [||]
              GetSnippet            [||]
              GenericMessage        ""
              GetIdentification     
          ]
          
      let messageTxt v =
          match v with
          | GetSnippetContentById _ -> "GetSnippetContentById"
          | GetSnippetCodeById    _ -> "GetSnippetCodeById   "
          | GetSnippetById        _ -> "GetSnippetById       "
          | GetSnippetContent     _ -> "GetSnippetContent    "
          | GetSnippetCode        _ -> "GetSnippetCode       "
          | GetSnippet            _ -> "GetSnippet           "
          | GenericMessage        _ -> "GenericMessage       "
          | GetIdentification       -> "GetIdentification    "
      
      let fsClient = FsStationClient("MessagingTest")//, "ButtonTest")
      
      let snpId       = Var.Create "" 
      let message     = Var.Create ""
      let messageType = Var.Create GetIdentification
      
      let requestMessage msgT (content:string) : Async<string> =
          let msg =
              match msgT with
              | GetSnippetContentById _ -> GetSnippetContentById  <| CodeSnippetId (Guid content)
              | GetSnippetCodeById    _ -> GetSnippetCodeById     <| CodeSnippetId (Guid content)
              | GetSnippetById        _ -> GetSnippetById         <| CodeSnippetId (Guid content)
              | GetSnippetContent     _ -> GetSnippetContent      <| content.Split '/'
              | GetSnippetCode        _ -> GetSnippetCode         <| content.Split '/'
              | GetSnippet            _ -> GetSnippet             <| content.Split '/'
              | GenericMessage        _ -> GenericMessage         <| content
              | GetIdentification       -> GetIdentification    
          async {
              let! response = fsClient.SendMessage msg |> Wrap.getAsync
              let resp =
                  match response with
                  | SnippetResponse(Some snp )    -> snp  |> Json.Serialize
                  | StringResponse (Some code)    -> code
                  | IdResponse      id            -> id
                  | _                             -> sprintf "<Incomplete response: %A>" response
              return resp
          }
      
      let listener                  = Var.Create ""
      let listeners : Var<string[]> = Var.Create [||]
      
      async {
          let! ls          = fsClient.MessagingClient.POListeners()
          listeners.Value <- ls
      } |> Async.Start
      
      div [
          Doc.SelectDynOptional [ ] id         listeners.Value    listener    |> someElt
          Doc.Select [ ] messageTxt messageTypes messageType |> someElt
          Template.Input   .New(snpId  ).Render
          Template.TextArea.New(message).Render
          Template.Button.New("Send Message to Server").OnClick(fun _ _ ->
              async {
                message.Value <- "Sending request..."
                let! code = requestMessage messageType.Value snpId.Value
                message.Value <- code
                return ()
              }  |> Async.Start
            ).Render
      ]    
      |> RunCode.RunNode().ShowHtmlResult