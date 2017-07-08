namespace CIPHERPrototype

open WebSharper
open WebSharper.JavaScript

[<JavaScript>]
module Option =
    let defaultValue def = function |Some v -> v | None -> def

[<JavaScript>]
module CIPHERHtml =

    [< JavaScript ; Sealed >]
    type JQueryLoader() =
        inherit WebSharper.Core.Resources.BaseResource("http://code.jquery.com"
            ,  "jquery-3.1.1.min.js")
    
    [< JavaScript ; Sealed >]
    type ReactLoader() =
        inherit WebSharper.Core.Resources.BaseResource("/EPFileX/react"
            ,  "react.js"
            ,  "react-dom.js"
            ,  "remarkable.min.js")
    
    [< JavaScript ; Sealed >]
    type MainCssLoader()   = inherit WebSharper.Core.Resources.BaseResource("/EPFileX/css/", "main.css")
    
    [< Require(typeof<JQueryLoader>) ; JavaScript >]
    type BootstrapLoader() = 
        inherit WebSharper.Core.Resources.BaseResource("http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/"
                                                                         ,  "css/bootstrap.min.css"
                                                                         ,  "js/bootstrap.min.js")
    
    
    [< JavaScript ; Require(typeof<BootstrapLoader>) ; Require(typeof<MainCssLoader>) >]
    type BootstrapLoad [< JavaScript ; Inline "{}" >]  () =
        [< DefaultValue                               >]          val mutable xx                      : string
                                    
    [< JavaScript ; Require(typeof<ReactLoader>) ; AllowNullLiteral >]
    type Attrs [< JavaScript ; Inline "{}" >]  () =
        [< DefaultValue                               >]          val mutable xx                      : string
        [< JavaScript; Inline "$0.preventDefault()"   >]        member   this.preventDefault()                    = ()
        [< Inline "$.extend(true, {}, $this, $a)"     >]        member   this.ExtendDeep (a:obj)      : Attrs    = X<_>
        [< Inline "Object.keys($this)"                >]        member   this.keys()                  : string[] = X<_>
        
    
    [< JavaScript >]
    type ReactClass [< JavaScript ; Inline "{}" >]  () = // do not use: use R.createClass instead
        [< DefaultValue                               >]          val mutable dummy                   : unit
    
    [< JavaScript ; Require(typeof<ReactLoader>) ; AllowNullLiteral >]
    type R() =
        [< Inline "React.createClass($options)"                                   >] static member createClass  (options: ClassOptions): ReactClass = X<_>
        [< Inline "React.createClass({displayName: $name, getInitialState: $init, render:$render})" >] 
                                                                                     static member createClass  (name: string, init: obj, render: obj): ReactClass = X<_>
        [< Inline "React.createClass({displayName: $name, render:$render})"       >]                                                       
                                                                                     static member createClass  (name: string,            render: obj): ReactClass = X<_>
        [< Inline "$text"                                                         >] static member t(text: string                                                    ): R = X<_>
        [< Inline "React.createElement.apply(null, $args)"                        >] static member E([<System.ParamArray>] args:obj[]                                ): R = X<_>
        [< Inline "React.createElement.apply(null, $args)"                        >] static member E_(args:obj[]                                                     ): R = X<_>
        static member E0 (elem: string) (attrs: Attrs list) (children: R list) = 
                            let reduceAtt = 
                                match attrs with
                                | [] -> Attrs()
                                | _  -> attrs |> List.reduce (fun a b -> a.ExtendDeep b)
                            elem :> obj
                            :: (reduceAtt :> obj)
                            :: (children |> Seq.cast<obj> |> Seq.toList)
                            |> function
                               | [] -> R.E(elem, reduceAtt)
                               | l  -> l |> List.toArray |> R.E_
    
        static member E00 (elem: string) (attrs: Attrs []) (children: R []) = 
                            let reduceAtt = 
                                match attrs.Length = 0 with
                                | true  -> Attrs()
                                | false -> attrs |> Array.reduce (fun a b -> a.ExtendDeep b)
                            children |> unbox<obj []>
                            |> Array.append [| elem :> obj ; reduceAtt :> obj |] 
                            |> R.E_  
    
    and ClassOptions [< JavaScript ; Inline "{}" >]  () =
        [< DefaultValue                               >]          val mutable displayName             : string
        [< DefaultValue                               >]          val mutable getInitialState         : obj
        [< DefaultValue                               >]          val mutable render                  : FuncWithOnlyThis<obj, R   >
        [< DefaultValue                               >]          val mutable componentDidMount       : FuncWithOnlyThis<obj, unit>
        [< DefaultValue                               >]          val mutable shouldComponentUpdate   : FuncWithOnlyThis<obj, bool>
    
    
    
    [< JavaScript >]
    type ReactDOM() =
        [< JavaScript; Inline "ReactDOM.render($elem, $dom)" >] static member render  (elem: obj, dom: Dom.Element): unit = X<_>
        [< JavaScript; Inline "ReactDOM.findDOMNode($elem)"  >] static member findDOMNode  (elem: obj): Dom.Element = X<_>
    
    
    [< JavaScript >]
    type FileReader [< JavaScript ; Inline "new FileReader()" >]  () =
        [< JavaScript; Inline "$0.onload = $callback" >] member this.onload    (callback: obj) = ()
        [< JavaScript; Inline "$0.readAsText($file) " >] member this.readAsText(file    : obj) = ()

    [< Inline """(!$v)""">]
    let isUndefined v = true   
        
    [< Inline """($o[$p])""">]
    let prop p o            = null
//    let getJVSProp obj prop = null
        
    [< Inline """($obj[$prop] = $v)""">]
    let setJVSProp obj prop v = ()

    [< JavaScript >]
    let callF f p1 p2 = f |> FuncWithArgs<(obj * obj), _> |> fun f -> f.Call(p1, p2)
        
    [< Inline "$f.call($this, $p1)" >]
    let call f this p1 = Interop.X<_>
    
    type CipherNode =
    | NElement   of name:string * children: CipherNode []
    | NText      of string
    | NAttribute of name:string * value:obj
    | NAttrR     of Attrs []
    | ReactR     of R
    | ReactObj   of obj
    | UIObject   of IUIObject
    | UIApp      of IUIApp * props:obj
    | NEmpty
    and IUIObject =
        abstract member view : unit -> CipherNode
    and IUIApp =
        abstract member nodeR                 : obj -> R
        abstract member nodeIncDom            : obj -> Dom.Element 
        abstract member run                   : obj -> Dom.Element -> unit

    let NElement (name:string, children: seq<CipherNode>) = NElement (name, children |> Seq.toArray)

    let insertChildren   newChildren node =
        match node with
        | NElement  (name, children) -> NElement (name , Seq.append newChildren children)
        | NText     text             -> NElement ("div", Seq.append newChildren [node]  )
        | NAttribute(_   , _       ) -> NElement ("div", Seq.append newChildren [node]  )
        | NAttrR    attrs            -> NElement ("div", Seq.append newChildren [node]  )
        | ReactR    _ 
        | ReactObj  _ 
        | UIObject  _ 
        | UIApp     _                -> node
        | NEmpty                     -> NElement ("div",            newChildren         )

    let addChildren   newChildren node =
        match node with
        | NElement  (name, children) -> NElement (name , Seq.append children newChildren)
        | NText     text             -> NElement ("div", Seq.append [node]   newChildren)
        | NAttribute(_   , _       ) -> NElement ("div", Seq.append [node]   newChildren)
        | NAttrR    attrs            -> NElement ("div", Seq.append [node]   newChildren)
        | ReactR    _ 
        | ReactObj  _ 
        | UIObject  _ 
        | UIApp     _                -> node
        | NEmpty                     -> NElement ("div",                     newChildren)

    let addChild  child = addChildren [child]

    let addAttributes = addChildren
    let addAttribute  = addChild

    let Div         children   = NElement   ("div"         , children)
    let Span        children   = NElement   ("span"        , children)
    let Menu        children   = NElement   ("menu"        , children)
    let Form        children   = NElement   ("form"        , children)
    let Img         children   = NElement   ("img"         , children)
    let Ul          children   = NElement   ("ul"          , children)
    let Li          children   = NElement   ("li"          , children)
    let H1          children   = NElement   ("h1"          , children)
    let H2          children   = NElement   ("h2"          , children)
    let H3          children   = NElement   ("h3"          , children)
    let H4          children   = NElement   ("h4"          , children)
    let H5          children   = NElement   ("h5"          , children)
    let H6          children   = NElement   ("h6"          , children)
    let Hr          children   = NElement   ("hr"          , children)
    let Br          children   = NElement   ("br"          , children)
    let Table       children   = NElement   ("table"       , children)
    let THead       children   = NElement   ("thead"       , children)
    let Th          children   = NElement   ("th"          , children)
    let TBody       children   = NElement   ("tbody"       , children)
    let Tr          children   = NElement   ("tr"          , children)
    let Td          children   = NElement   ("td"          , children)
    let P           children   = NElement   ("p"           , children)
    let A           children   = NElement   ("a"           , children)
    let B           children   = NElement   ("b"           , children)
    let Label       children   = NElement   ("label"       , children)
    let Input       children   = NElement   ("input"       , children)
    let Select      children   = NElement   ("select"      , children)
    let OptionA     children   = NElement   ("option"      , children)
    let Button      children   = NElement   ("button"      , children)
    let NewTag tag  children   = NElement   (tag           , children)
                                                           
    let NewAttr     name value = NAttribute (name          , value   )
    let Id          id         = NAttribute ("id"          , id      )
    let Key         key        = NAttribute ("key"         , key     )
    let Role        role       = NAttribute ("role"        , role    )
    let Src         src        = NAttribute ("src"         , src     )
    let Href        href       = NAttribute ("href"        , href    )
    let Style       style      = NAttribute ("style"       , style   )
    let Class       clas       = NAttribute ("className"   , clas    )
    let Type        typ        = NAttribute ("type"        , typ     )
    let Value       value      = NAttribute ("value"       , value   )
    let TabIndex    idx        = NAttribute ("tabIndex"    , idx     )
    let AutoFocus   foc        = NAttribute ("autoFocus"   , foc     )
    let Disabled    dis        = NAttribute ("disabled"    , dis     )
    let Placeholder txt        = NAttribute ("placeholder" , txt     )
    let MaxLength   len        = NAttribute ("maxLength"   , len     )
    let Checked     chk        = NAttribute ("checked"     , chk     )
    let Draggable   drg        = NAttribute ("draggable"   , drg     )

    //let OnShow      (f:obj)    = NAttribute ("onShow"      , f       ) |> addAttribute
    let OnClick      (f:obj)    = NAttribute ("onClick"     , f       ) |> addAttribute
    let OnSubmit     (f:obj)    = NAttribute ("onSubmit"    , f       ) |> addAttribute
    let OnChange     (f:obj)    = NAttribute ("onChange"    , f       ) |> addAttribute
    let OnMouseEnter (f:obj)    = NAttribute ("onMouseEnter", f       ) |> addAttribute
    let OnMouseLeave (f:obj)    = NAttribute ("onMouseLeave", f       ) |> addAttribute
    let OnMouseOver  (f:obj)    = NAttribute ("onMouseOver" , f       ) |> addAttribute
    let OnMouseOut   (f:obj)    = NAttribute ("onMouseOut"  , f       ) |> addAttribute
    let OnMouseDown  (f:obj)    = NAttribute ("onMouseDown" , f       ) |> addAttribute
    let OnMouseMove  (f:obj)    = NAttribute ("onMouseMove" , f       ) |> addAttribute
    let OnMouseUp    (f:obj)    = NAttribute ("onMouseUp"   , f       ) |> addAttribute
    let OnDrop       (f:obj)    = NAttribute ("onDrop"      , f       ) |> addAttribute
    let OnDragStart  (f:obj)    = NAttribute ("onDragStart" , f       ) |> addAttribute
    let OnDragOver   (f:obj)    = NAttribute ("onDragOver"  , f       ) |> addAttribute
    let OnKeyDown    (f:obj)    = NAttribute ("onKeyDown"   , f       ) |> addAttribute
    let Ref          (f:obj)    = NAttribute ("ref"         , f       ) |> addAttribute

    let OnAfterRender(f: obj->unit) = Ref (fun e -> if not (isUndefined e) then f e)

    let newAttr name value =
        let a = Attrs()
        setJVSProp a name value
        a

    let _color         col        = newAttr     "color"         col
    let _cursor        cur        = newAttr     "cursor"        cur
    let _margin        mar        = newAttr     "margin"        mar
    let _fontSize      siz        = newAttr     "fontSize"      siz
    let _fontStyle     stl        = newAttr     "fontStyle"     stl
    let _fontWeight    wei        = newAttr     "fontWeight"    wei
    let _alignSelf     alg        = newAttr     "alignSelf"     alg
    let _top           top        = newAttr     "top"           top 
    let _bottom        bot        = newAttr     "bottom"        bot 
    let _left          lef        = newAttr     "left"          lef 
    let _right         rig        = newAttr     "right"         rig 
    let _height        hei        = newAttr     "height"        hei 
    let _minHeight     hei        = newAttr     "minHeight"     hei 
    let _maxHeight     hei        = newAttr     "maxHeight"     hei 
    let _width         wid        = newAttr     "width"         wid 
    let _minWidth      wid        = newAttr     "minWidth"      wid 
    let _maxWidth      wid        = newAttr     "maxWidth"      wid 
    let _zIndex        zid        = newAttr     "zIndex"        zid 
    let _position      pos        = newAttr     "position"      pos 
    let _display       dis        = newAttr     "display"       dis 
    let _flexFlow      flo        = newAttr     "flexFlow"      flo 
    let _flex          fle        = newAttr     "flex"          fle 
    let _flexBasis     bas        = newAttr     "flexBasis"     bas 
    let _flexGrow      gro        = newAttr     "flexGrow"      gro 
    let _flexShrink    gro        = newAttr     "flexShrink"    gro 
    let _padding       pad        = newAttr     "padding"       pad 
    let _paddingLeft   lef        = newAttr     "paddingLeft"   lef 
    let _paddingRight  rig        = newAttr     "paddingRight"  rig
    let _paddingTop    top        = newAttr     "paddingTop"    top
    let _paddingBottom bot        = newAttr     "paddingBottom" bot
    let _borderStyle   sty        = newAttr     "borderStyle"   sty
    let _borderWidth   wid        = newAttr     "borderWidth"   wid
    let _marginBottom  mar        = newAttr     "marginBottom"  mar
    let _overflow      ove        = newAttr     "overflow"      ove
    let _background    clr        = newAttr     "background"    clr
    let _fontFamily    fml        = newAttr     "fontFamily"    fml
    let _whiteSpace    wsp        = newAttr     "whiteSpace"    wsp 
    let _textOverflow  tov        = newAttr     "textOverflow"  tov
    let _textAlign     alg        = newAttr     "textAlign"     alg
    let _border        brd        = newAttr     "border"        brd

    let _Style (styles: Attrs seq) =
        styles 
        |> Seq.reduce (fun a b -> JQuery.JQuery.Extend(JQuery.JQuery.Extend(Attrs(), a), b) :?> Attrs )
        |> Style

    [< Inline "{ __html: $v }" >]
    let __html v =  X<_>
    let __innerHtml (html:string) = NAttribute("dangerouslySetInnerHTML", __html html)
                                                           
    let outerAttrs name value =
        match name with
        | "class" -> NewAttr "className" value
        | _       -> NewAttr name        value

    let __outerHtml (html:string) =
        try
            let n = html.IndexOf('>') 
            if n > 0 then
                let elem = JS.Document.CreateElement "div"
                elem.InnerHTML <- html
                let tag : Dom.Element = elem?firstElementChild
                [0..tag.Attributes.Length-1] 
                |> Seq.map (fun i -> tag.Attributes.[i]) 
                |> Seq.map (fun a -> outerAttrs a.Name a.Value)
                |> Seq.append [ __innerHtml tag.InnerHTML ]
                |> NewTag tag.LocalName
            else
                  NEmpty
        with _ -> NEmpty

    let toReact (node:CipherNode) : R =
        let attributeR =
            function
            | NAttribute (name, value) -> [| newAttr name value |]
            | NAttrR     attrs         -> attrs
            | NElement   _
            | NText      _
            | ReactR     _             
            | ReactObj   _             
            | UIObject   _
            | UIApp      _
            | NEmpty                   -> [||]
        let rec elementR =
            function
            | NElement (tag, children) -> let subNodes   = children |> Array.choose  elementR  
                                          let attributes = children |> Array.collect attributeR
                                          Some <| R.E00 tag attributes subNodes
            | NText      text          -> Some <| R.t text
            | ReactR     r             -> Some <| r
            | ReactObj   o             -> Some <| R.E(o)
            | UIObject   o             -> o.view() |> elementR 
            | UIApp     (app, props)   -> Some <| (app.nodeR props)
            | NEmpty                   -> Some null
            | NAttribute _
            | NAttrR     _             -> None
        elementR node |> Option.defaultValue null
                                
    let patchOuter  (container:Dom.Element) (f:unit->unit) : unit        = JS.Apply JS.Window?IncrementalDOM "patchOuter"   [| container ; f |]
    let patchInner  (container:Dom.Element) (f:unit->unit) : unit        = JS.Apply JS.Window?IncrementalDOM "patchInner"   [| container ; f |]
    let elementOpen  (tag:string) key statics pairs        : Dom.Element = JS.Apply JS.Window?IncrementalDOM "elementOpen"  (Array.append [| tag ; key ; statics |] pairs)
    let elementClose (tag:string)                          : Dom.Element = JS.Apply JS.Window?IncrementalDOM "elementClose" [| tag |]
    let textIDom     (txt:string)                          : Dom.Element = JS.Apply JS.Window?IncrementalDOM "text"         [| txt |]

    let toIncrementalDom (node:CipherNode) : Dom.Element =
        let attributeR =
            function
            | NAttribute (name, value) -> [| newAttr name value |]
            | NAttrR     attrs         -> attrs
            | NElement   _
            | NText      _
            | ReactR     _             
            | ReactObj   _             
            | UIObject   _
            | UIApp      _
            | NEmpty                   -> [||]
        let rec elementR : CipherNode -> Dom.Element =
            function
            | NElement (tag, children) -> children 
                                          |> Array.collect attributeR
                                          |> function
                                             | attrs when attrs.Length = 0 -> Attrs()
                                             | attrs -> attrs |> Seq.cast<Attrs> |> Seq.reduce (fun a b -> a.ExtendDeep b)
                                          |> (fun attrs -> 
                                                 attrs.keys() 
                                                 |> Array.collect(fun name -> 
                                                       [| match name with
                                                          | "className"                 -> "class"
                                                          | _ when name.StartsWith "on" -> name.ToLower()
                                                          | _                           -> name
                                                          :> obj ; prop name attrs |]))
                                          |> elementOpen tag null [||]   |> ignore
                                          children |> Array.map elementR |> ignore
                                          elementClose tag
            | NText      text          -> textIDom text
            | UIObject   o             -> o.view() |> elementR 
            | UIApp     (app, props)   -> app.nodeIncDom props
            | ReactR     _
            | ReactObj   _
            | NAttribute _
            | NAttrR     _
            | NEmpty                   -> null             
        elementR node
                
    type VirtualDomRenderer<'P, 'M> = 'P -> 'M -> (('M -> 'M) -> unit) -> R

     /// this is where non-react children can be added
    let reactContainerClass className (afterRender: obj -> Dom.Element -> unit) =
        R.createClass(ClassOptions(
                         displayName           = "containerClass"
                       , componentDidMount     = FuncWithOnlyThis(fun this -> afterRender this (ReactDOM.findDOMNode(this)))
                       , shouldComponentUpdate = FuncWithOnlyThis(fun _    -> false)
                       , render                = FuncWithOnlyThis(fun this ->
                            Div [Class className]
                            |> toReact
        )))
