namespace CIPHERPrototype

open WebSharper
open WebSharper.UI.Next
open WebSharper.UI.Next.Client
open WebSharper.UI.Next.Html

[<NoComparison>]
type Val<'a> =
    | Constant  of 'a
    | DynamicV  of IRef<'a>
    | Dynamic   of View<'a>

[<NoComparison ; NoEquality>]
type HtmlNode =
    | HtmlElement   of name: string * children: HtmlNode seq
    | HtmlAttribute of name: string * value:    Val<string>
    | HtmlText      of Val<string>
    | HtmlEmpty
    | SomeDoc       of Doc
    | SomeAttr      of Attr

[<JavaScript>]
module Val =
    
    let mapV : ('a -> 'b) -> Val<'a> -> Val<'b> =
        fun      f                  va      ->
            match va with
            | Constant  a -> f  a                  |> Constant
            | Dynamic  wa -> wa      |> View.Map f |> Dynamic 
            | DynamicV va -> va.View |> View.Map f |> Dynamic 

    let toView v =
        match v with
        | Constant  a -> View.Const a
        | Dynamic  wa -> wa
        | DynamicV va -> va.View

    let iter f v = toView v |> View.Get f

    let bindV : ('a -> Val<'b>) -> Val<'a> -> Val<'b> =
        fun      f                v       -> 
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
        static member (&>) (HelperType, a : string      ) = Constant  a
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

    [< Inline "CIPHERPrototype.Val.fixit2($v)" >]
    let inline fixit v = HelperType &> v

    let inline atr att v = attrV  att (fixit v)
    let inline tag tag v = tagDoc tag (fixit v)

    let inline _class       v = atr "class"       v
    let inline _type        v = atr "type"        v
    let inline _style       v = atr "style"       v
    let inline _placeholder v = atr "placeholder" v
    let inline textV        v = tag  text         v

//    let inline toView  v     = toView  (fixit v )
    let inline toDoc   v     = toView    (fixit v ) |> Doc.EmbedView
    let inline map  f  v           = mapV  f   (fixit v )
    let inline map2 f  v1 v2       = map2V f   (fixit v1) (fixit v2)
    let inline map3 f  v1 v2 v3    = map3V f   (fixit v1) (fixit v2) (fixit v3)
    let inline map4 f  v1 v2 v3 v4 = map4V f   (fixit v1) (fixit v2) (fixit v3) (fixit v4)

    module Html =
        let defaultValue v =
            function
            | Some x -> x
            | None   -> v

        let addClass    (classes:string) (add:string) = classes.Split ' ' |> Set.ofSeq |> Set.union  (Set.ofSeq <| add.Split ' ') |> String.concat " "
        let removeClass (classes:string) (rem:string) = classes.Split ' ' |> Set.ofSeq |> Set.remove               rem            |> String.concat " "
        
        let callAddClass = addClass "a" "b" // so that WebSharper.Collections.js is included
        
        let inline chooseAttr node = 
            match node with
            | HtmlAttribute (name, value   ) when name <> "class" && name <> "style" 
                                             -> Some <| attrV name value
            | SomeAttr             value     -> Some <|            value
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
                          else ss |> Seq.reduce (map2 <| concat sep ) |> attrV name |> Some)

        let inline getAttrsFromSeq children =
            children 
            |> Seq.choose chooseAttr
            |> Seq.append (List.choose id [ children |> groupAttr "class" " " ; children |> groupAttr "style" "; " ])
        
        let rec chooseNode node =
            match node with
            | HtmlElement(name, children) -> Some <| (Doc.Element name (getAttrsFromSeq children) (children |> Seq.choose chooseNode) :> Doc)
            | HtmlText    vtext           -> Some <| tagDoc WebSharper.UI.Next.Html.text vtext
            | SomeDoc     doc             -> Some <| doc
            | _                           -> None
        
        let getAttrChildren attr =
            Seq.tryPick (function 
                        | HtmlAttribute(a, v) when a = attr -> Some v 
                        | _                                 -> None)
            >> defaultValue (Constant "")
        
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
                | _               -> chooseNode this |> defaultValue Doc.Empty
            member inline   this.Class       clas = fixit clas                                     |> replaceAtt "class" this
            member inline   this.AddChildren add  = mapHtmlElement (fun n ch -> HtmlElement(n, Seq.append add ch )) this

        let renderDoc = chooseNode >> defaultValue Doc.Empty

        let inline htmlElement   name ch = HtmlElement  (name, ch       )
        let inline htmlAttribute name v  = HtmlAttribute(name, fixit v  )
        let inline htmlText      txt     = HtmlText     (      fixit txt)
        let inline someElt       elt     = SomeDoc      (elt :> Doc     )    

        let inline br        ch = htmlElement   "br"       ch
        let inline hr        ch = htmlElement   "hr"       ch
        let inline h1        ch = htmlElement   "h1"       ch
        let inline h2        ch = htmlElement   "h2"       ch
        let inline h3        ch = htmlElement   "h3"       ch
        let inline h4        ch = htmlElement   "h4"       ch
        let inline h5        ch = htmlElement   "h5"       ch
        let inline h6        ch = htmlElement   "h6"       ch
        let inline div       ch = htmlElement   "div"      ch
        let inline img       ch = htmlElement   "img"      ch
        let inline span      ch = htmlElement   "span"     ch
        let inline form      ch = htmlElement   "form"     ch
        let inline table     ch = htmlElement   "table"    ch
        let inline thead     ch = htmlElement   "thead"    ch
        let inline th        ch = htmlElement   "th"       ch
        let inline tr        ch = htmlElement   "tr"       ch
        let inline td        ch = htmlElement   "td"       ch
        let inline tbody     ch = htmlElement   "tbody"    ch
        let inline label     ch = htmlElement   "label"    ch
        let inline button    ch = htmlElement   "button"   ch
        let inline script    sc = htmlElement   "script"   sc
        let inline styleH    st = htmlElement   "style"    st
        let inline fieldset  ch = htmlElement   "fieldset" ch
        let inline link      sc = htmlElement   "link"     sc

        let inline href      v  = htmlAttribute "href"     v
        let inline rel       v  = htmlAttribute "rel"      v
        let inline src       v  = htmlAttribute "src"      v
        let inline ``class`` v  = htmlAttribute "class"    v
        let inline ``type``  v  = htmlAttribute "type"     v
        let inline width     v  = htmlAttribute "width"    v
        let inline Id        v  = htmlAttribute "id"       v
    
        let inline ``xclass`` v  = 
            match fixit v with
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
        let inline style1  n v  = fixit v |> toView |> Attr.DynamicStyle n |> SomeAttr
    
        let composeDoc elt dtl dtlVal = dtlVal |> toView |> Doc.BindView (Seq.append dtl >> elt >> renderDoc) |> SomeDoc
        
        let inline bindHElem hElem v =  Doc.BindView (hElem >> renderDoc)  (toView <| fixit v)|> SomeDoc

    