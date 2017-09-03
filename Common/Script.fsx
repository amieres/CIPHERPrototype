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
#r @"Owin.dll"
#r @"Microsoft.Owin.dll"
#r @"Microsoft.Owin.Hosting.dll"
#r @"Microsoft.Owin.Host.HttpListener.dll"
#r @"Microsoft.Owin.StaticFiles.dll"
#r @"Microsoft.Owin.FileSystems.dll"
#r @"WebSharper.Owin.dll"
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
      
          let attrVO att       vao     =
                  match vao with
                  | Constant (Some a)-> Attr.Create      att   a
                  | Constant  None   -> Attr.DynamicPred att  (View.Const false              ) (View.Const                      ""         )
                  | Dynamic       wa -> Attr.DynamicPred att  (View.Map Option.isSome wa     ) (View.Map   (Option.defaultValue "") wa     )
                  | DynamicV      va -> Attr.DynamicPred att  (View.Map Option.isSome va.View) (View.Map   (Option.defaultValue "") va.View)
      
          let attrV att       va      =
                  match va with
                  | Constant  a -> Attr.Create  att   a
                  | Dynamic  wa -> Attr.Dynamic att  wa
                  | DynamicV va -> Attr.Dynamic att  va.View
      
      
          type HelperType = HelperType with
              static member (&>) (HelperType, a :     string option   ) = Constant  a
              static member (&>) (HelperType, a :     string          ) = Constant  a
              static member (&>) (HelperType, a :     bool            ) = Constant  a
              static member (&>) (HelperType, a :     int             ) = Constant  a
              static member (&>) (HelperType, a :     float           ) = Constant  a
              static member (&>) (HelperType, a :     Doc             ) = Constant  a
              static member (&>) (HelperType, va: Val<string option>  ) =          va
              static member (&>) (HelperType, va: Val<string       >  ) =          va
              static member (&>) (HelperType, va: Val<bool         >  ) =          va
              static member (&>) (HelperType, va: Val<int          >  ) =          va
              static member (&>) (HelperType, va: Val<float        >  ) =          va
              static member (&>) (HelperType, va: Val<Doc          >  ) =          va
              static member (&>) (HelperType, va: Val<_            >  ) =          va
              static member (&>) (HelperType, vr: IRef<_           >  ) = DynamicV vr
              static member (&>) (HelperType, vw: View<_           >  ) = Dynamic  vw
      
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
      
          let inline mapAsync f  v           = View.MapAsync f (fixit v |> toView) 
      
      
      # 1 @"(6)d9124644-0af6-4a7f-a711-ef76ca77f0de HtmlNode.fsx"
      [<NoComparison ; NoEquality>]
      type HtmlNode =
          | HtmlElement    of name: string * children: HtmlNode seq
          | HtmlAttribute  of name: string * value:    Val<string>
          | HtmlAttributeO of name: string * value:    Val<string option>
          | HtmlText       of Val<string>
          | HtmlEmpty
          | HtmlElementV   of Val<HtmlNode>
          | SomeDoc        of Doc
          | SomeAttr       of Attr
          
      let addClassX    (classes:string) (add:string) = classes.Split ' ' |> Set.ofSeq |> Set.union  (Set.ofSeq <| add.Split ' ') |> String.concat " "
      //let removeClass (classes:string) (rem:string) = classes.Split ' ' |> Set.ofSeq |> Set.remove               rem            |> String.concat " "
      
      //let callAddClassX = addClassX "a" "b" // so that WebSharper.Collections.js is included
      
      let inline chooseAttr node = 
          match node with
          | HtmlAttribute (name, value   ) when name <> "class" && name <> "style" 
                                           -> Some <| Val.attrV    name value
          | HtmlAttributeO(name, valueO  ) when name <> "class" && name <> "style" 
                                           -> Some <| Val.attrVO   name valueO
          | SomeAttr             attr      -> Some <| attr
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
      
      //let replaceAttribute att (children: HtmlNode seq) newVal =
      //    HtmlAttribute(att, newVal)
      //    :: (children
      //        |> Seq.filter (function HtmlAttribute(old, _) when old = att -> false | _ -> true)
      //        |> Seq.toList
      //       )
      //
      //let replaceAtt att node newVal = mapHtmlElement (fun n ch -> n, replaceAttribute att ch newVal |> Seq.ofList) node
      
      let inline htmlElement    name ch = HtmlElement   (name, ch           )
      let inline htmlAttribute  name v  = HtmlAttribute (name, Val.fixit v  )
      let inline htmlAttributeO name v  = HtmlAttributeO(name, Val.fixit v  )
      let inline htmlText       txt     = HtmlText      (      Val.fixit txt)
      let inline someElt        elt     = SomeDoc       (elt :> Doc         )    
        
      let inline addChildren    add (h:HtmlNode) = h |> mapHtmlElement (fun n ch -> n, Seq.append ch   add)
      let inline insertChildren add (h:HtmlNode) = h |> mapHtmlElement (fun n ch -> n, Seq.append add  ch )
      let inline addClass       c    h           = h |> addChildren [ htmlAttribute  "class" c ] 
      let inline addClassIf     c v              = addClass <| Val.map (fun b -> if b then c else "") (Val.fixit v)
      
      type HtmlNode with
          member inline this.toDoc = 
              match this with
              | HtmlAttribute _
              | HtmlEmpty       -> Doc.Empty
              | _               -> chooseNode this |> Option.defaultValue Doc.Empty
          // member inline   this.Class          clas = Val.fixit clas |> replaceAtt "class" this
          member          this.AddChildren    add  = this |> addChildren    add
          member          this.InsertChildren add  = this |> insertChildren add
          member inline   this.AddClass       c    = this |> addClass       c
      
      let renderDoc = chooseNode >> Option.defaultValue Doc.Empty
          
      # 1 @"(6)c3755c07-1385-495d-bad7-a5b0fa54ac9b HTML Elements & Attributes.fsx"
      let inline atr att v = Val.attrV  att (Val.fixit v)
      let inline tag tag v = Val.tagDoc tag (Val.fixit v)
      
      let inline _class       v = atr "class"       v
      let inline _type        v = atr "type"        v
      let inline _style       v = atr "style"       v
      let inline _placeholder v = atr "placeholder" v
      let inline textV        v = tag  Html.text    v
      
      let inline a           ch = htmlElement   "a"           ch
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
      
      
      let inline href        v  = htmlAttribute  "href"        v
      let inline hrefO       vO = htmlAttributeO "href"        vO
      let inline rel         v  = htmlAttribute  "rel"         v
      let inline src         v  = htmlAttribute  "src"         v
      let inline ``class``   v  = htmlAttribute  "class"       v
      let inline ``type``    v  = htmlAttribute  "type"        v
      let inline width       v  = htmlAttribute  "width"       v
      let inline title       v  = htmlAttribute  "title"       v
      let inline Id          v  = htmlAttribute  "id"          v
      let inline frameborder v  = htmlAttribute  "frameborder" v
      let inline spellcheck  v  = htmlAttribute  "spellcheck"  v
      let inline draggable   v  = htmlAttribute  "draggable"   v
      let inline style       v  = htmlAttribute  "style"       v
      
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
      
    # 1 @"(4)3709b431-1507-48ed-9487-dd49ce7be748 open HtmlNode.fsx"
    open HtmlNode
    # 1 @"(4)e9ac2d66-474a-46a6-95fa-d369e6d703d1 Template.fsx"
    [<JavaScript>]
    module Template      =
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
      # 1 @"(6)0a11766b-f227-4b38-88a3-919d964387bf Panel.fsx"
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
      
    # 1 @"(4)57a30378-4a52-4122-b297-fe5cec1bd067 WebSharper Snippets2.fsx"
    [< JavaScript >]
    module Snippets2 = 
      # 1 @"(6)0dabc34f-673d-4f79-ae00-3960ca196392 Client-Server.fsx"
      let invert (txt: string) : string = txt |> Seq.rev |> Seq.map string |> String.concat ""
      
      [< Rpc >]
      let invertA txt = async { return invert txt }
      
      #if COMPILING
      #else
      let inp = Template.Input.New("Type something...")
      
      let inline h1 ch = htmlElement "h1" ch
      
      h3 [
        inp.Render
        htmlText inp.Var
        htmlElement "h2" [ htmlText inp.Var ]
        h1 [ htmlText <| Val.mapAsync invertA inp.Var ]
      ]
      |> RunCode.RunNode().ShowHtmlResult
      
      #endif
      # 1 @"(6)92837099-e4e4-4c7f-ac52-6c922824304f Server.fsx"
      //#r @"Owin.dll"
      //#r @"Microsoft.Owin.dll"
      //#r @"Microsoft.Owin.Hosting.dll"
      //#r @"Microsoft.Owin.Host.HttpListener.dll"
      //#r @"Microsoft.Owin.StaticFiles.dll"
      //#r @"Microsoft.Owin.FileSystems.dll"
      //#r @"WebSharper.Owin.dll"
      
      WebSharper.Web.Remoting.AddAllowedOrigin "http://localhost"
      WebSharper.Web.Remoting.AddAllowedOrigin "http://*"
      WebSharper.Web.Remoting.AddAllowedOrigin "file://"
      WebSharper.Web.Remoting.DisableCsrfProtection()
      
      //#define WEBSHARPER
      open WebSharper.Sitelets
      open WebSharper.UI.Next.Server
      
      type EndPoint = EP
      
      let content (ctx:Context<EndPoint>) (endpoint:EndPoint) : Async<Content<EndPoint>> =
          Content.Page( Html.html [ Html.body [ Html.h1 [ Html.text "Hello Dolly" ] ]])
      
      let site = Application.MultiPage content
      
      module SelfHostedServer =
      
          open global.Owin
          open Microsoft.Owin.Hosting
          open Microsoft.Owin.StaticFiles
          open Microsoft.Owin.FileSystems
          open WebSharper.Owin
      
          //[<EntryPoint>]
          let Main args =
              let rootDirectory, url =
                  match args with
                  | [| rootDirectory; url |] -> rootDirectory, url
                  | [| url                |] -> ".."         , url
                  | [|                    |] -> ".."         , "http://localhost:9001/"
                  | _ -> eprintfn "Usage: WebServer ROOT_DIRECTORY URL"; exit 1
              use server = 
                  WebApp.Start(url, fun appB ->
                      appB.UseStaticFiles(StaticFileOptions(FileSystem = PhysicalFileSystem(rootDirectory)))
                          .UseWebSharper(WebSharperOptions(ServerRootDirectory = rootDirectory
                                                         , Sitelet             = Some site
                                                         , BinDirectory        = "."
                                                         , Debug               = true))
                      |> ignore
                      let listener = appB.Properties.["Microsoft.Owin.Host.HttpListener.OwinHttpListener"] |> unbox<Microsoft.Owin.Host.HttpListener.OwinHttpListener>
                      let maxA = ref 0
                      let maxB = ref 0
                      listener.SetRequestProcessingLimits(1000, 1000)
                      listener.GetRequestProcessingLimits(maxA, maxB)
                      printfn "Accepts: %d Requests:%d" !maxA !maxB
                      )
              stdout.WriteLine("Serving {0}", url)
              stdin.ReadLine() |> ignore
              0
          Main [||] |> ignore