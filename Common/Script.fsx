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
#r @"ZafirTranspiler.dll"
# 1 "required for nowarns to work"
#nowarn "1182"
#nowarn "40"
# 1 @"bf864f3c-1370-42f2-ac8a-565a604892e8 FSSGlobal.fsx"
//#nowarn "1182"
//#nowarn "40"
//#r @"D:\Abe\CIPHERWorkspace\CIPHERPrototype\WebServer\bin\FSharp.Core.dll"
#if INTERACTIVE
#I @"../WebServer/bin"
module FSSGlobal   =
#else
namespace FSSGlobal
#endif

  # 1 @"(2)edbbf11e-4698-4e33-af0c-135d5b21799b F# Code.fsx"
  // Code to be evaluated using FSI: `Evaluate F#`
    # 1 @"(4)60bffe71-edde-4971-8327-70b9f5c578bb open WebSharper.fsx"
    //#define WEBSHARPER
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
    
  # 1 @"(2)7479dc9d-94cd-4762-a1b8-cf6e09436c3f WebSharper Code.fsx"
  (*
   Code to be Compiled to Javascript and run in the browser
   using `Compile WebSharper` or `Run WebSharper`
  *)
    # 1 @"(4)495bce0a-4fb6-48fa-9158-c242d5965baa HtmlNode.fsx"
    
    [<JavaScript>]
    module HtmlNode      =
    
      # 1 @"(6)0f5719f0-e95e-498d-ab88-f89ff1440e32 type Val'a =.fsx"
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
      
      # 1 @"(6)d9124644-0af6-4a7f-a711-ef76ca77f0de type HtmlNode =.fsx"
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
          
      # 1 @"(6)c3755c07-1385-495d-bad7-a5b0fa54ac9b let inline atr att v = Val.attrV  att (Val.fixit v).fsx"
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
      
      [< Inline """(!$v)""">]
      let isUndefined v = true
      
      let  findRootElement (e:Dom.Element) =
          let root = e.GetRootNode()
          if isUndefined root?body 
          then root.FirstChild :?> Dom.Element
          else root?body  |> unbox<Dom.Element>
      
    # 1 @"(4)3709b431-1507-48ed-9487-dd49ce7be748 open HtmlNode.fsx"
    open HtmlNode
    # 1 @"(4)e9ac2d66-474a-46a6-95fa-d369e6d703d1 Template.fsx"
    [<JavaScript>]
    module Template      =
      # 1 @"(6)5e1dd5fc-a27c-4b0d-821a-06cc8a27bb82 type Button = {.fsx"
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
      # 1 @"(6)0a11766b-f227-4b38-88a3-919d964387bf type Panel = {.fsx"
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
      # 1 @"(6)456562f7-0757-4431-9aeb-d58b050cecf7 RunHtmlPlusFree.fsx"
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
      # 1 @"(6)bf400a85-8264-4540-9381-f3be0c968c94 ShowHtmlResult.fsx"
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
      
      # 1 @"(6)c47adc01-4550-4830-8df5-e1ebedaee7d0 ShowResult.fsx"
        member inline this.ShowResult res = htmlText (sprintf "%A" res) |> this.ShowHtmlResult
      
    # 1 @"(4)0268626d-d502-4981-a917-df659db5c0b6 WebSharper Snippets.fsx"
    [< JavaScript >]
    module Snippets =
      # 1 @"(6)ff6bfed0-83ae-4497-b197-fea6432aa958 let (REGEX_) (expr string) (opt string) (value string) =.fsx"
      let (|REGEX|_|) (expr: string) (opt: string) (value: string) =
          if value = null then None else
          try 
              match String(value).Match(RegExp(expr, opt)) with
              | null         -> None
              | [| |]        -> None
              | m            -> Some m
          with e -> None
         
      let txt = """Compiling to JavaScript...
      Compiling to JavaScript...
      Compiled!
      0 errors, 1 warnings
      WarningFSharp
        "(6)47f7c0ba-35b0-466e-a759-4e4d9963e524 codeMirror (1,11) - (1,19) typecheck 1178: The struct, record or union type 'KeyMapF2' is not structurally comparable because the type 'obj' does not satisfy the 'comparison' constraint. Consider adding the 'NoComparison' attribute to the type 'KeyMapF2' to clarify that the type is not comparable"
        2 errors, 0 warnings
      ErrFSharp
        "F# Regex Pattern matching (47,39) - (47,40) parse 10: Unexpected symbol '<' in expression"
      ErrFSharp
        "F# Regex Pattern matching (47,49) - (47,50) parse 514: End of file in string begun at or before here" 
      WarningFSharp
        "F# Regex Pattern matching (16,0) - (16,1) typecheck 20: The result of this expression is implicitly ignored. Consider using 'ignore' to discard this value explicitly, e.g. 'expr |> ignore', or 'let' to bind the result to a name, e.g. 'let result = expr'."  
      Evaluating F# code...
      (6) F# 7k.fsx(1,7): error FS1156: This is not a valid numeric literal. Valid numeric literals include 1, 0x1, 0b0001 (int), 1u (uint32), 1L (int64), 1UL (uint64), 1s (int16), 1y (sbyte), 1uy (byte), 1.0 (float), 1.0f (float32), 1.0m (decimal), 1I (BigInteger).  
      Compiling to JavaScript...
      6 errors, 1 warnings
      WarningFSharp
        "F# Regex Pattern matching (16,0) - (16,1) typecheck 20: The result of this expression is implicitly ignored. Consider using 'ignore' to discard this value explicitly, e.g. 'expr |> ignore', or 'let' to bind the result to a name, e.g. 'let result = expr'."
      ErrWebSharper
        "(6) F# Regex Pattern matching.fsx (120, 19) - (120, 46) Type not found in JavaScript compilation: System.Text.RegularExpressions.Regex"
      ErrWebSharper
        "(6) F# Regex Pattern matching.fsx (121, 14) - (121, 23) Type not found in JavaScript compilation: System.Text.RegularExpressions.Group"
      ErrWebSharper
        "(6) F# Regex Pattern matching.fsx (121, 67) - (121, 74) Type not found in JavaScript compilation: System.Text.RegularExpressions.Capture"
      ErrWebSharper
        "(6) F# Regex Pattern matching.fsx (121, 55) - (121, 63) Type not found in JavaScript compilation: System.Text.RegularExpressions.Match"
      ErrWebSharper
        "(6) F# Regex Pattern matching.fsx (121, 55) - (121, 63) Method name not found in JavaScript compilation: (EnumerateFromFunctions<_,_> : (unit -> 'T0) * ('T0 -> System.Boolean) * ('T0 -> 'T1) -> System.Collections.Generic.IEnumerable`1<'T1>), Members: safeDispose, EnumerateThenFinally, EnumerateUsing, EnumerateWhile, CreateEvent"
      ErrWebSharper
        "(6) F# Regex Pattern matching.fsx (121, 55) - (121, 63) Type not found in JavaScript compilation: System.Text.RegularExpressions.GroupCollection"
      """
      let rex1 = """\((\d+)\) F# (.+).fsx\((\d+)\,(\d+)\): (error|warning) ((.|\b)+)\."""
      let rex2 = """(Err|Warning)(FSharp|WebSharper)\s+"(\((\d+)\) )?F# (.+?)(.fsx)? \((\d+)\,\s*(\d+)\) - \((\d+)\,\s*(\d+)\) ((.|\s)+?)""" + "\""
      let rex = rex1 + "|" + rex2
      
      match txt with
      | REGEX rex "g" m -> m
      | _               -> [||]
      |> Array.choose (fun v ->
          match v with
          | REGEX rex2 "" [| _ ; sev; from;  _; indent; file; _; fl; fc; tl; tc; msg; _ |] -> Some (file, int fl, int fc - int indent, int tl, int tc - int indent, sev, from , msg)
          | REGEX rex1 "" [| _ ;                indent; file   ; fl; fc;    sev; msg; _ |] -> Some (file, int fl, int fc - int indent, int fl, int fc - int indent, sev, "fsi", msg)
          | _ -> None
      )
      |> Array.map (fun (file, fl, fc, tl, tc, sev, from, msg) -> sprintf "%s (%d,%d)-(%d,%d) %s %s : %s" file fl fc tl tc sev from msg)
      |> Array.map (htmlText >> List.singleton >> List.append [ style "text-align: left" ] >> li)
      |> h5
      |> RunCode.RunNode().ShowHtmlResult
      