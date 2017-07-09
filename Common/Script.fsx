# 1 @" F# namespace TestWebSharper.fsx"
#if INTERACTIVE
#I @"../WebServer/bin"
#else
namespace TestWebSharper
#endif
#nowarn "1182"

# 1 @" F# open WebSharper.fsx"
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

# 1 @" F# module HtmlNode =.fsx"
#nowarn "1182"
[<JavaScript>]
module HtmlNode =

# 1 @"(4) F# type Val'a =.fsx"
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
                       
        [< Direct "TestWebSharper.HtmlNode.Val.fixit2($v)" >]
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
    
# 1 @"(4) F# type HtmlNode =.fsx"
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
        member inline   this.Class       clas = Val.fixit clas |> replaceAtt "class" this
        member inline   this.AddChildren add  = mapHtmlElement (fun n ch -> HtmlElement(n, Seq.append add ch )) this
    
    let renderDoc = chooseNode >> Option.defaultValue Doc.Empty
        
# 1 @"(4) F# let inline atr att v = Val.attrV  att (Val.fixit v).fsx"
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
    
    let inline style     v  = htmlAttribute "style"    v
    let inline style1  n v  = Val.fixit v |> Val.toView |> Attr.DynamicStyle n |> SomeAttr
    
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
    
# 1 @"(4) F# LoadFiles.fsx"
    [< Inline "CIPHERSpaceLoadFiles($files, $cb)" >]
    let LoadFiles (files: string []) (cb: unit -> unit) : unit = X<_>
# 1 @" F# open HtmlNode.fsx"
open HtmlNode
# 1 @" F# module Template =.fsx"
[<JavaScript>]
module Template =
# 1 @"(4) F# type Button = {.fsx"
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
# 1 @"(4) F# type Input = {.fsx"
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
# 1 @"(4) F# type Hoverable = {.fsx"
    [<NoComparison ; NoEquality>]
    type Hoverable = {
        hover      : IRef<bool>
        content    : HtmlNode seq
    } with
      static member  New   = 
        let hover      = Var.Create false
        { 
            hover      = hover     
            content    = []
        }
      static member  Demo  = 
        let hover      = Var.Create false
        { 
            hover      = hover     
            content    = [ style "flex-flow: column;"
                         ]
        }
      member        this.Render          =
        [ classIf "hovering" this.hover
          SomeAttr <| on.mouseEnter (fun _ _ -> this.hover.Value <- true )
          SomeAttr <| on.mouseLeave (fun _ _ -> this.hover.Value <- false)
        ] 
        |> Seq.append  this.content
        |> div
      member inline this.Content    c = { this with content    =       c }
    
# 1 @"(4) F# type TextArea = {.fsx"
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
              _placeholder        this.placeholder 
            ]
            this.var
      member inline this.Class       clas = { this with _class      = Val.fixit clas }
      member inline this.Placeholder plc  = { this with placeholder = Val.fixit plc  }
      member inline this.Title       ttl  = { this with title       = Val.fixit ttl  }
      member inline this.Spellcheck  spl  = { this with spellcheck  = spl            }
      member inline this.Id          id   = { this with id          = id             }
      member inline this.SetVar      v    = { this with var         = v              }
      member inline this.Var              = this.var
      
# 1 @"(4) F# let codeMirrorIncludes =.fsx"
    let codeMirrorIncludes =
       [| "/EPFileX/codemirror/scripts/codemirror/codemirror.js"             
    //      "/EPFileX/codemirror/scripts/intellisense.js"                      
    //      "/EPFileX/codemirror/scripts/codemirror/codemirror-intellisense.js"
    //      "/EPFileX/codemirror/scripts/codemirror/codemirror-compiler.js"    
          "/EPFileX/codemirror/scripts/codemirror/mode/fsharp.js"            
          "/EPFileX/codemirror/scripts/addon/search/searchcursor.js"          
          "/EPFileX/codemirror/scripts/addon/search/search.js"          
          "/EPFileX/codemirror/scripts/addon/search/jump-to-line.js"          
          "/EPFileX/codemirror/scripts/addon/dialog/dialog.js"          
          "/EPFileX/codemirror/scripts/addon/edit/matchbrackets.js"          
          "/EPFileX/codemirror/scripts/addon/selection/active-line.js"       
          "/EPFileX/codemirror/scripts/addon/display/fullscreen.js"          
    //      "/EPFileX/codemirror/scripts/codemirror/mode/markdown.js"                 
       |]
# 1 @"(4) F# type CodeMirror = {.fsx"
    [<NoComparison ; NoEquality>]
    type CodeMirror = {
        _class      : Val<string>
        id          : string
        var         : IRef<string>
        onChange    : (unit -> unit)
    } with
    
      [< Inline "CodeMirror($elt, {
    	    theme        : 'rubyblue'
    	  , lineNumbers  : true
    	  , matchBrackets: true
          , extraKeys    : {
    		    Tab  : function (cm) { cm.replaceSelection('    ', 'end'); }
    		  , 'F11': function (cm) { cm.setOption('fullScreen', !cm.getOption('fullScreen')); }
            }
    })"    >]
      static member SetupEditor elt                               : CodeMirror = X<_>
      [< Inline "$this.getValue()"              >]
      member this.GetValue()                                      : string     = X<_>
      [< Inline "$this.setValue($v)"            >]
      member this.SetValue (v:string)                             : unit       = X<_>
      [< Inline "$this.getDoc().clearHistory()" >]
      member this.ClearHistory()                                  : unit       = X<_>
      [< Inline "$this.on($event, $f)"          >]
      member this.On(event: string, f:(CodeMirror * obj) -> unit) : unit     = X<_>
    
      static member  New(var) = 
          { _class   = Val.fixit "" 
            id       = ""
            var      = var 
            onChange = ignore
          }
      static member  New(v)   = CodeMirror.New(Var.Create v)
      member        this.Render    =
        div [ 
              ``class``            this._class
              SomeAttr <| attr.id  this.id 
              style "position: relative; height: 300px"
              div [
                    style "height: 100%; width: 100%; position: absolute;"
                    SomeAttr <| on.afterRender (fun el ->
                      LoadFiles codeMirrorIncludes
                        (fun () ->                       
                           let editor = CodeMirror.SetupEditor el
                           editor.On("change", fun (cm, change) -> 
                               let v = editor.GetValue() 
                               if this.var.Value <> v then this.var.Value <- v; this.onChange() )
                           this.var.View |> View.Sink (fun v -> if editor.GetValue() <> v then editor.SetValue v ; editor.ClearHistory())
                        )
                    )    
                  ]
              link [ href "/EPFileX/codemirror/content/editor.css"                   ; ``type`` "text/css" ; rel "stylesheet" ]
              link [ href "/EPFileX/codemirror/content/codemirror.css"               ; ``type`` "text/css" ; rel "stylesheet" ]
              link [ href "/EPFileX/codemirror/content/theme/rubyblue.css"           ; ``type`` "text/css" ; rel "stylesheet" ]
              link [ href "/EPFileX/codemirror/scripts/addon/display/fullscreen.css" ; ``type`` "text/css" ; rel "stylesheet" ]
              link [ href "/EPFileX/codemirror/scripts/addon/dialog/dialog.css"      ; ``type`` "text/css" ; rel "stylesheet" ]
         ]
      member inline this.Class    clas = { this with _class    = Val.fixit clas }
      member inline this.Id       id   = { this with id        =       id       }
      member inline this.SetVar   v    = { this with var       = v              }
      member inline this.OnChange f    = { this with onChange  = f              }
      member inline this.Var           = this.var
    
# 1 @"(4) F# type SplitterBar = {.fsx"
    [<NoComparison ; NoEquality>]
    type SplitterBar = {
        value            : IRef<float>
        min              : Val<float>
        max              : Val<float>
        vertical         : Val<bool>
        node             : HtmlNode
        after            : bool
        mutable dragging : bool
        mutable startVer : bool 
        mutable startP   : float 
        mutable start    : float 
        mutable size     : float 
        mutable domElem  : Dom.Element option
    }
    with
        static member New = 
            {
                value    = Var.Create 30.0
                min      = Val.fixit  10.0
                max      = Val.fixit  75.0
                vertical = Val.fixit  true  
                node     = div [ ``class`` "Splitter" ]
                after    = true
                dragging = false
                startVer = true
                startP   = 0.0
                start    = 0.0
                size     = 0.0
                domElem  = None
            }
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
              .AddChildren [
                SomeAttr <| on.mouseDown startDragging
                SomeAttr <| on.afterRender (fun el -> this.domElem <- Some el)
              ]  
        member inline this.Value       v = this.value.Value    <- v    ; this
        member inline this.Node     node = { this with node         = node                        }
        member inline this.Min         v = { this with min          = Val.fixit v                 }
        member inline this.Max         v = { this with max          = Val.fixit v                 }
        member inline this.Vertical    v = { this with vertical     = Val.fixit v                 }
        member inline this.Horizontal  v = { this with vertical     = Val.fixit v |> Val.map not  }
        member inline this.Var         v = { this with value        =           v                 }
        member inline this.Vertical   () = { this with vertical     = Val.fixit true              }
        member inline this.Horizontal () = { this with vertical     = Val.fixit false             }
        member inline this.Before        = { this with after        =           false             }
        member inline this.After         = { this with after        =           true              }
# 1 @" F# module RunCode =.fsx"
[<JavaScript>]
module RunCode =
# 1 @"(4) F# module EditorRpc =.fsx"
#r @"ZafirTranspiler.dll"
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
    
# 1 @"(4) F# type RunNode(nodeName, clearNode bool) =.fsx"
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
# 1 @"(4) F# AddBootstrap.fsx"
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
# 1 @"(4) F# RunDoc.fsx"
      member inline this.RunDoc  doc  = doc  :> Doc       |> Doc.Run this.RunNode
# 1 @"(4) F# RunHtml.fsx"
      member inline this.RunHtml node = node |> renderDoc |> this.RunDoc
# 1 @"(4) F# RunHtmlPlusFree.fsx"
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
# 1 @" F# module CodeEditor =.fsx"
[<JavaScript>]
module CodeEditor =

# 1 @"(4) F# type CodeSnippetId = CodeSnippetId of System.Guid.fsx"
    type CodeSnippetId = CodeSnippetId of System.Guid        
    with static member New = CodeSnippetId <| System.Guid.NewGuid()
    
    let snippetName name (content: string) =
        if name <> "" then name else 
        content.Split([| '\n' |], System.StringSplitOptions.RemoveEmptyEntries)
        |> Seq.map    (fun l -> l.Trim())
        |> Seq.filter (fun l -> not (l.StartsWith("#") || l.StartsWith("[<") || l.StartsWith("//")))
        |> Seq.tryHead
        |> Option.defaultValue "<empty>"
    
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
    
    let codeSnippetsStorage = WebSharper.UI.Next.Storage.LocalStorage "CodeSnippets" Serializer.Typed<CodeSnippet>
    let codeSnippets        = ListModel.CreateWithStorage<CodeSnippetId, CodeSnippet> (fun s -> s.id) codeSnippetsStorage
    //    let codeSnippets        = ListModel.Create<CodeSnippetId, CodeSnippet> (fun s -> s.id) []
    
    let tryPickI f s = s |> Seq.indexed |> Seq.filter f |> Seq.tryHead
    
    type CodeSnippet 
        with
        static member PickIO id = codeSnippets.Value |> tryPickI (fun (_, snp) -> snp.id = id)
        static member FetchO id = codeSnippets.TryFindByKey id
        static member FetchL id = CodeSnippet.FetchO id |> Option.toList
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
                    companions   = co
                    id           = CodeSnippetId.New
                    expanded     = true
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
        member this.UniquePredecesors() =
            let rec preds (ins : CodeSnippetId list) outs : CodeSnippetId list =
                match ins with
                | []         -> outs
                | hd :: rest -> List.collect id [ rest ; hd |> CodeSnippet.FetchL |> List.collect (fun s -> s.parent |> Option.toList |> List.append <| s.predecessors) ]
                                |> preds <| if outs |> Seq.contains hd then outs else hd::outs
            preds [ this.id ] []
        member this.Level() =
            let rec level snp out = 
                snp.parent
                |> Option.bind CodeSnippet.FetchO
                |> Option.map (fun p -> level p <| out + 1) 
                |> Option.defaultValue out
            level this 0
        member this.NameSanitized =
            //let illegal = System.IO.Path.GetInvalidFileNameChars()
            let illegal = [|'"'   ; '<'   ; '>'   ; '|'   ; '\000'; '\001'; '\002'; '\003'; '\004'; '\005'; '\006';
                            '\007'; '\b'  ; '\009'; '\010'; '\011'; '\012'; '\013'; '\014'; '\015';
                            '\016'; '\017'; '\018'; '\019'; '\020'; '\021'; '\022'; '\023'; '\024';
                            '\025'; '\026'; '\027'; '\028'; '\029'; '\030'; '\031'; ':'   ; '*'   ; '?';
                            '\\'  ; '/'|]
            this.Name
            |> String.filter (fun c -> not <| Array.contains c illegal)
            |> (fun c -> "F# " + c + ".fsx")
        member this.ContentIndented() =
            let lvl = this.Level()
            if lvl = 0 || lvl = 1 then this.content 
            else this.content.Split('\n')
                    |> Array.map (fun l -> if l.StartsWith "#" then l else  (String.replicate lvl "  ") + l)
                    |> String.concat "\n"
            |> sprintf "# 1 @\"%s %s\"\n%s" (if lvl = 0 || lvl = 1 then "" else sprintf"(%d)" (lvl * 2)) this.NameSanitized
        member this.Code() =
            let preds = this.UniquePredecesors() |> Seq.toArray
            codeSnippets.Value
            |> Seq.filter (fun snp -> preds |> Array.contains snp.id)
            |> Seq.map    (fun snp -> snp.ContentIndented()         )
            |> String.concat "\n"
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
    
# 1 @"(4) F# currentCodeSnippetId.fsx"
    let missingVar  = Var.Create ""
    let missing find lens k =
        match find k with
        | Some _ -> lens k
        | None   -> missingVar.Lens (fun _ -> "") (fun _ _ -> "")
        
    let currentCodeSnippetId  = Var.Create <| CodeSnippetId.New
    
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
    
    let directionVertical    = 
        Val.map (fun pos -> 
            match pos with
            | Right -> true
            | _     -> false
        ) position
        
        
# 1 @"(4) F# CodeEditorMain.fsx"
    let noSelection cur = CodeSnippet.FetchO cur = None
    let noSelectionVal  = Val.map noSelection currentCodeSnippetId
    
    let dirty    = Var.Create false 
    let codeFS   = Var.Create ""
    let codeJS   = Var.Create ""
    let codeMsgs = Var.Create ""
    let sendMsg msg = 
        codeMsgs.Value  <- 
            match codeMsgs.Value, msg with
            | null, m 
            | ""  , m
            | m   , null
            | m   , ""   -> m
            | m1  , m2   -> m1 + "\n" + m2
    
    do Val.sink (fun m -> 
        JS.Window.Onbeforeunload <- 
            if m then System.Action<Dom.Event>(fun (e:Dom.Event) -> e?returnValue  <- "Changes you made may not be saved.")
            else null
        ) dirty 
    
    let setDirty() = dirty.Value <- true
    let setClean() = dirty.Value <- false
    
    let getFSCode () =
        CodeSnippet.FetchO currentCodeSnippetId.Value 
        |> Option.iter (fun snp -> codeFS.Value <- snp.Code())
    
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
                 printfn "Evaluating..."
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
    
    let processSnippet msg processCode =
        CodeSnippet.FetchO currentCodeSnippetId.Value 
        |> Option.iter (fun snp -> 
            codeMsgs.Value <- msg
            codeJS.Value   <- ""
            let code = snp.Code()
            codeFS.Value   <- code
            processCode       code
        )
    
    let compileSnippet fThen fFail = 
        processSnippet "Compiling to JavaScript..." (RunCode.compile (fun msgs js -> codeJS.Value <- js ; fThen msgs js) fFail)
    
    let compileRun  () = compileSnippet runJS                                               sendMsg
    let justCompile () = compileSnippet (fun msgs _ -> sendMsg "Compiled!" ; sendMsg msgs)  sendMsg
    let evaluateFS  () = 
        processSnippet "Evaluating F# code..." (RunCode.EditorRpc.evaluate (fun (vO, msgs) -> vO |> Option.defaultValue "" |> ((+) (msgs + "\n")) |> sendMsg))
    
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
        setDirty()
        refreshView()
    
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
            setDirty()
            refreshView()
        )
    
    let indentCodeOut () =
        CodeSnippet.FetchO currentCodeSnippetId.Value
        |> Option.iter (fun snp ->
            let newP = snp.parent
                       |> Option.bind CodeSnippet.FetchO
                       |> Option.bind (fun p -> p.parent)
            codeSnippets.UpdateBy (fun c -> Some { c with parent = newP }) snp.id
            setDirty()
            refreshView()
        )
    
    let mutable draggedId   = CodeSnippetId.New
    let inline  draggable v = htmlAttribute "draggable"    v
    
    
# 1 @"(4) F# let listEntry code =.fsx"
    let isDirectPredecessor pre curO =
        curO
        |> Option.map (fun snp -> snp.predecessors |> List.contains pre)
        |> Option.defaultValue false
    
    let curPredecessors =
        Val.map (   Option.map          (fun (snp:CodeSnippet) -> snp.UniquePredecesors())
                  >> Option.defaultValue [])  currentCodeSnippetO  
    
    let isIndirectPredecessor pre predecessors = predecessors |> List.contains pre
        
    let togglePredecessorForCur (pre:CodeSnippet) curO =
        curO |> Option.iter (fun cur ->
            if cur = pre || isIndirectPredecessor cur.id (pre.UniquePredecesors()) then () else
            let preds = 
                if cur.predecessors |> List.contains pre.id
                then List.filter ((<>) pre.id)
                else fun l -> pre.id :: l
                <| cur.predecessors
            codeSnippets.UpdateBy  (fun c -> Some { c with predecessors = preds }) cur.id
            setDirty()
            refreshView()
        )
    
    let toggleExpanded snp =
        codeSnippets.UpdateBy  (fun c -> Some { c with expanded = not c.expanded }) snp.id
        refreshView()
    
    let listEntry isParent isExpanded code =
        Template.Hoverable.New
            .Content( [ 
                        ``class`` "code-editor-list-tile"
                        classIf   "selected"              <| Val.map ((=)                   code.id) currentCodeSnippetId
                        classIf   "direct-predecessor"    <| Val.map (isDirectPredecessor   code.id) currentCodeSnippetO
                        classIf   "indirect-predecessor"  <| Val.map (isIndirectPredecessor code.id) curPredecessors
                        draggable "true"
                        SomeAttr <| on.dragOver(fun _ ev -> ev.PreventDefault()                                              )
                        SomeAttr <| on.drag    (fun _ _  ->                                              draggedId <- code.id)
                        SomeAttr <| on.drop    (fun _ ev -> ev.PreventDefault() ; reorderSnippet code.id draggedId           )
                        span    [ ``class`` "node"
                                  classIf   "parent"   isParent
                                  classIf   "expanded" isExpanded
                                  SomeAttr <| on.click(fun _ _ -> if isParent then toggleExpanded code)
                                  title    <| if isParent then (if isExpanded then "collapse" else "expand") else ""
                                  htmlText <| if isParent then (if isExpanded then "v"        else ">"     ) else ""
                                ]
                        div     [ ``class`` "code-editor-list-text"
                                  style1 "text-indent" (sprintf "%dem" <| code.Level())
                                  htmlText <| Val.map2 snippetName (curSnippetNameOf code.id) (curSnippetCodeOf code.id)
                                  SomeAttr <| on.click (fun _ _ -> currentCodeSnippetId.Value <- code.id)
                                ]
                        span    [ ``class``   "predecessor"
                                  title       "toggle predecessor"
                                  SomeAttr <| on.click(fun _ _ -> Val.iter (togglePredecessorForCur code) currentCodeSnippetO)
                                  htmlText    "X"
                                ]
                        ])
            .Render
    
    let listEntries snps =
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
        |> Seq.choose (Option.map renderDoc)
        |> Doc.Concat
# 1 @"(4) F# let addCode () =.fsx"
    let addCode () =
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
          loadTextFile ((e.GetRootNode().FirstChild :?> Dom.Element).QuerySelector("#" + fileInputElementId))
            (fun txt ->
                try
                    txt
                    |> Json.Deserialize<CodeSnippet[]>
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
# 1 @"(4) F# let styleEditor =.fsx"
    let splitterV1 =
        Template.SplitterBar.New.Value(20.0)
          .Node(div [ ``class`` "sliderv"
                      style "width : 5px; grid-column: 2  ; grid-row: 2/4; margin-left: -7px; border: 0px; padding: 0px;" ])
    
    let splitterV2 =
        Template.SplitterBar.New.Value(50.0).Max(Val.map ((-) 92.0) splitterV1.GetValue)
          .Node(div [ ``class`` "sliderv"
                      style "width : 5px; grid-column: 3  ; grid-row: 3  ; margin-left: -7px; border: 0px; padding: 0px;" ])
          
    let splitterH3 =
        Template.SplitterBar.New.Value(17.0).Horizontal().Before
          .Node(div [ ``class`` "sliderh"
                      style "height: 5px; grid-column: 2/4; grid-row: 3  ; margin-top : -7px; border: 0px; padding: 0px;" ])
    
    let styleEditorF sp1 sp2 sp3 =
        sprintf """
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
    
    
    .CodeEditor {
        display: grid;
        grid-template-columns: %f%% %f%% minmax(0px, 97%%);
        grid-template-rows: 4%% minmax(0px, 96%%) %f%% 10%%;
        grid-template-areas:
        "header0 header   header"
        "sidebar content1 content1"
        "sidebar content2 content3"
        "footer  footer   footer2";
        color: #333;
        height: 100%%;
        grid-gap: 9px;
        padding : 9px;
    }
    
    .CodeEditor > :nth-child(2){  grid-area: header  ; overflow: hidden;               }
#Snippets                  {  grid-area: sidebar ; overflow: auto  ;               }
#Code                      {  grid-area: content1; overflow: auto  ;               }
#Output                    {  grid-area: content2; overflow: auto  ; resize: none; }
#JScript                   {  grid-area: content3; overflow: auto  ; resize: none; }
#AllCode                   {  grid-area: footer2 ; overflow: auto                  }
#Buttons                   {  grid-area: footer  ;                                 }
    
    
#Buttons { 
            display: grid;
            grid-template-columns: repeat(8, 12.1%%);
            bxackground-color: #eee;
            padding : 5px;
            grid-gap: 5px;
    }
    
#Buttons > div       { grid-column: 4/6 }
    
    .CodeMirror {
        height: 100%%;
    }
    
    .sliderv {
        background-color: #eef;
        cursor: col-resize;
    }
    .sliderh {
        background-color: #eef;
        cursor: row-resize;   
    }
    .node {
        background-color:white; 
        width: 2ch; 
        color: #A03; 
        font-weight:bold; 
        text-align: center;
        font-family: arial;
    }
    
        """ sp1 sp2 sp3
            
    let styleEditor = htmlText <| Val.map3 styleEditorF splitterV1.GetValue splitterV2.GetValue splitterH3.GetValue
    
# 1 @"(4) F# let CodeEditor() =.fsx"
    let CodeEditor() =
      div [ ``class`` "CodeEditor"
            div [ Id "Snippets"
                  codeSnippets.View
                  |> View.SnapshotOn codeSnippets.Value refresh.View
                  |> View.Map listEntries
                  |> Doc.BindView id |> SomeDoc
                ]                     
            Template.Input     .New(Val.bindIRef curSnippetNameOf currentCodeSnippetId).Prefix(htmlText "name:")                     .Render
            Template.CodeMirror.New(Val.bindIRef curSnippetCodeOf currentCodeSnippetId).OnChange(setDirty ).Id("Code"   )            .Render.AddChildren([style1 "height" "100%"])
            Template.TextArea  .New(codeMsgs).Placeholder("Output:"    ).Title("Messages"                 ).Id("Output" )            .Render
            Template.TextArea  .New(codeFS  ).Placeholder("F# code:"   ).Title("F# code assembled"        ).Id("AllCode")            .Render
            Template.TextArea  .New(codeJS  ).Placeholder("Javascript:").Title("JavaScript code generated").Id("JScript")            .Render
            div [ Id "Buttons"
                  Template.Button.New("Add code"              ).Class("btn btn-xs"     ).OnClick(Do addCode      )                          .Render
                  Template.Button.New("<<"                    ).Class("btn btn-xs"     ).OnClick(Do indentCodeOut).Disabled(noSelectionVal) .Render
                  Template.Button.New(">>"                    ).Class("btn btn-xs"     ).OnClick(Do indentCodeIn ).Disabled(noSelectionVal) .Render
                  loadFileElement                                                                                                           .Render
                  span []       
                  Template.Button.New("Evaluate FS"           ).Class("btn btn-xs"     ).OnClick(Do evaluateFS   ).Disabled(noSelectionVal) .Render
                  Template.Button.New("Get F# code ==>"       ).Class("btn btn-xs"     ).OnClick(Do getFSCode    ).Disabled(noSelectionVal) .Render
           
                  Template.Button.New("Delete code"           ).Class("btn btn-xs"     ).OnClick(Do deleteCode   ).Disabled(noSelectionVal) .Render
                  span []       
                  span []       
                  Template.Button.New("Save as..."            ).Class("btn            ").OnClick(Do downloadFile )                          .Render.AddChildren([classIf "btn-primary" dirty])
                  span []
                  Template.Button.New("Compile WebSharper"    ).Class("btn btn-xs"     ).OnClick(Do justCompile  ).Disabled(noSelectionVal) .Render
                  Template.Button.New("Run WebSharper in ..." ).Class("btn btn-xs").OnClick(Do compileRun ).Disabled(noSelectionVal) .Render
                  Doc.Select [ attr.id "Position" ] positionTxt [ Below ; Right ; NewBrowser ] position |> someElt
                ]
            script [ src "/EPFileX/FileSaver/FileSaver.js" ; ``type`` "text/javascript" ] 
            styleH [ styleEditor                                                        ]
            splitterV1                                                                                                               .Render
            splitterV2                                                                                                               .Render
            splitterH3                                                                                                               .Render
         ]
    
# 1 @"(4) F# CodeEditor page.fsx"
    
    
    let style1h = "height : 5px; grid-column: 1/2  ; grid-row   : 2/3; margin-top : -7px; border: 0px; padding: 0px; background-color: #eef; cursor: row-resize"
    let style2h = "height : 5px; grid-column: 1/2  ; grid-row   : 3/4; margin-top : -7px; border: 0px; padding: 0px; background-color: #eef; cursor: row-resize"
    let style1v = "width  : 5px; grid-row   : 1/2  ; grid-column: 2/3; margin-left: -7px; border: 0px; padding: 0px; background-color: #eef; cursor: col-resize"
    let style2v = "width  : 5px; grid-row   : 1/2  ; grid-column: 3/4; margin-left: -7px; border: 0px; padding: 0px; background-color: #eef; cursor: col-resize"
    
    let horizontalSplit : Printf.StringFormat<_> = """
    body {
        display              : grid;
        grid-template-rows   : %f%% %f%% %f%%;
        grid-template-columns: 100%%;
        grid-gap             :   9px;   
        height               : 100vh;
        overflow             : hidden;
    }
    
#CodeEditor              { grid-row   : 2; overflow: hidden; }
#TestNode                { grid-row   : 3; overflow: auto  ; }
    body > div:first-of-type { grid-row   : 1; overflow: hidden; }
    body > div               { grid-column: 1;                   }
                                   """
    let verticalSplit : Printf.StringFormat<_> = """
    body {
        display              : grid;
        grid-template-columns: %f%% %f%% %f%%;
        grid-template-rows   : 100%%;
        grid-gap             :   9px;   
        height               : 100vh;
        overflow             : hidden;
    }
    
#CodeEditor              { grid-column: 2; overflow: hidden; }
#TestNode                { grid-column: 3; overflow: auto  ; }
    body > div:first-of-type { grid-column: 1; overflow: hidden; }
    body > div               { grid-row   : 1;                   }
                                   """
    
    let style1 =
        directionVertical
        |> Val.map (fun dir ->
            if dir then style1v
            else        style1h)
    
    let style2 = 
        directionVertical
        |> Val.map (fun dir ->
            if dir then style2v
            else        style2h)
    
    let styleSplit  = 
        directionVertical
        |> Val.map (fun dir ->
            if dir then verticalSplit
            else        horizontalSplit)
    
    let splitterMain1 =
        Template.SplitterBar.New.Value( 0.0).Vertical(directionVertical).Min( 0.0).Max(35.0)
          .Node(div [ style style1 ])
    
    let splitterMain2 =
        Template.SplitterBar.New.Value(24.0).Vertical(directionVertical).Min( 0.5).Max(Val.map (fun pos -> if pos = NewBrowser then 0.1 else 50.0) position).Before
          .Node(div [ style style2 ])
    
    let pageStyle =
        Val.map3 (fun fmt v1 v2 -> 
            sprintf fmt v1 (98.0 - v1 - v2) v2) 
            styleSplit splitterMain1.GetValue splitterMain2.GetValue
            
    let addNodeById name (node:HtmlNode) =
        match JS       .Document.GetElementById   name with
        | null -> JS   .Document.CreateElement    "div"
                  |> JS.Document.Body.AppendChild :?> Dom.Element
        | node -> node
        |> fun el -> 
            Doc.RunReplace el (node.AddChildren [ Id name ] |> renderDoc)  
            
    RunCode.RunNode("CodeEditor").AddBootstrap.RunHtml <| CodeEditor()
    addNodeById "pageStyle"                            <| styleH [ htmlText pageStyle ]
    addNodeById "splitterMain1"                        <| splitterMain1.Render
    addNodeById "splitterMain2"                        <| splitterMain2.Render
              