//" F# module FSharpStationMD =.fsx"
#if INTERACTIVE
#I @"../WebServer/bin"
//module FSharpStationMD =
#else
namespace FSharpStationNS
#nowarn "1182"
#endif

//" F# WebSharper Code.fsx"
(*
 Code to be Compiled to Javascript and run in the browser
 using `Compile WebSharper` or `Run WebSharper`
*)
//"(4) F# open WebSharper.fsx"
//#define WEBSHARPER
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
    
    open WebSharper
    open WebSharper.JavaScript
    open WebSharper.UI.Next
    open WebSharper.UI.Next.Client
    type on   = WebSharper.UI.Next.Html.on
    type attr = WebSharper.UI.Next.Html.attr
    
//"(4) F# module HtmlNode =.fsx"
#nowarn "1182"
    [<JavaScript>]
    module HtmlNode =
    
//"(6) F# type Val'a =.fsx"
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
                         
          [< Direct "FSharpStationNS.HtmlNode.Val.fixit2($v)" >]
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
      
//"(6) F# type HtmlNode =.fsx"
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
          
//"(6) F# let inline atr att v = Val.attrV  att (Val.fixit v).fsx"
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
      
//"(4) F# open HtmlNode.fsx"
    open HtmlNode
//"(4) F# module Template =.fsx"
    [<JavaScript>]
    module Template =
//"(6) F# type SplitterBar = {.fsx"
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
                  min      = Val.fixit  10.0
                  max      = Val.fixit  75.0
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
          
//"(6) F# type Grid.fsx"
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
          width         : Var<float>
          height        : Var<float>
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
                  { this with lastSplitter = Some (this.cols.Length, col) ; cols = Array.append this.cols [| spl              |> Splitter |] }
              else 
                  { this with lastSplitter = Some (this.rows.Length, col) ; rows = Array.append this.rows [| spl.Horizontal() |> Splitter |] }
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
          member inline this.Before                = this.changeSplitter (fun spl -> spl.Before     )
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