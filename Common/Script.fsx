﻿#r @"remote.dll"
#r @"WebSharper.Core.dll"
#r @"WebSharper.Main.dll"
#r @"WebSharper.Web.dll"
#r @"Common.dll"
#r @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.1\System.Web.dll"
#r @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.1\System.Core.dll"
#r @"WebSharper.Collections.dll"
#r @"WebSharper.UI.Next.dll"
#r @"WebSharper.JavaScript.dll"
#r @"WebSharper.Sitelets.dll"
#r @"ZafirTranspiler.dll"
#nowarn "1182" "40"
# 1 @"bf864f3c-1370-42f2-ac8a-565a604892e8 FSSGlobal.fsx"
#I @"../WebServer/bin"
//#nowarn "1182"
//#nowarn "40"

#if INTERACTIVE
module FSSGlobal   =
#else
namespace FSSGlobal
#endif

  # 1 @"(2)edbbf11e-4698-4e33-af0c-135d5b21799b Evaluate F# Code.fsx"
  // Code to be evaluated using FSI: `Evaluate F#`
    # 1 @"(4)63eca270-405a-4789-941a-e298bbd265bd FsStationShared.fsx"
    #if WEBSHARPER
    [<WebSharper.JavaScript>]
    #endif
    module FsStationShared =
    
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
                                      | true when line.StartsWith("#I"     ) -> (comment line, line |> quoted |> PrepoI     )
                                      | true when line.StartsWith("#if"    ) -> (        line, line           |> PrepoIf    )
                                      | true when line.StartsWith("#else"  ) -> (        line,                   PrepoElse  )
                                      | true when line.StartsWith("#endif" ) -> (        line,                   PrepoEndIf )
                                      | true when line.StartsWith("#light" ) -> (        line, false          |> PrepoLight )
                                      | true when line.StartsWith("#"      ) -> (comment line, line           |> PrepoOther )
                                      | _                                    -> (        line,                   NoPrepo    ) 
          code |> Array.map prepro
          
      let separateDirectives (fsNass:(string * PreproDirective) seq) =
          let  assembs  = fsNass |> Seq.choose (snd >> (function | PrepoR assemb -> Some assemb | _ -> None)) |> Seq.toArray
          let  defines  = fsNass |> Seq.choose (snd >> (function | PrepoDefine d -> Some d      | _ -> None)) |> Seq.toArray
          let  prepoIs  = fsNass |> Seq.choose (snd >> (function | PrepoI      d -> Some d      | _ -> None)) |> Seq.toArray
          let  nowarns  = fsNass |> Seq.choose (snd >> (function | PrepoNoWarn d -> Some d      | _ -> None)) |> Seq.toArray
          let  nowarnsL = if nowarns |> Seq.isEmpty then [] else 
                          [ nowarns |> Seq.map (sprintf "\"%s\"") |> String.concat " " |> ((+) "#nowarn ") ]
          let  code     = fsNass |> Seq.map     fst |> Seq.append nowarnsL |> String.concat "\r\n"
          code, assembs, defines, prepoIs
      
      
      # 1 @"(6)2deb54e7-009e-4297-b2bc-1c86d04203a4 CodeSnippet.fsx"
      let inline swap f a b = f b a
      
      type CodeSnippetId = CodeSnippetId of System.Guid        
      with static member New = CodeSnippetId <| System.Guid.NewGuid()
           member this.Text  = match this with CodeSnippetId guid -> guid.ToString()
      
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
          member this.Level (fetcher: CodeSnippetId -> CodeSnippet option) =
              let rec level snp out = 
                  snp.parent
                  |> Option.bind fetcher
                  |> Option.map (fun p -> level p <| out + 1) 
                  |> Option.defaultValue out
              level this 0
          member this.NameSanitized =
              this.Name
              |> sanitize
              |> (fun c -> this.id.Text + " " + c + ".fsx")
          member this.ContentIndented fetcher addLinePrepos =
              let lvl = this.Level fetcher * 2
              let indent, prfx = if lvl = 0 || lvl = 1 then (id, "") else (Array.map    (fun (l, pr) -> String.replicate lvl " " + l, pr), sprintf"(%d)" lvl)
              let addLinePs    = if not addLinePrepos  then  id      else  Array.append [| sprintf "# 1 @\"%s%s\"" prfx this.NameSanitized |] 
              this.content.Split('\n') 
              |> addLinePs
              |> separatePrepros (not addLinePrepos)
              |> indent
          member this.UniquePredecessors (fetcher: CodeSnippetId -> CodeSnippet option) =
              let rec preds (ins : CodeSnippetId list) outs : CodeSnippetId list =
                  match ins with
                  | []         -> outs
                  | hd :: rest -> List.collect id [ rest ; hd |> fetcher |> Option.toList |> List.collect (fun s -> s.parent |> Option.toList |> List.append <| s.predecessors) ]
                                  |> preds <| if outs |> Seq.contains hd then outs else hd::outs
              preds [ this.id ] []        
          static member TryFindByKey snps key = snps |> Seq.tryFind (fun snp -> snp.id = key)
          static member CodePrepos fetcher addLinePrepos (snippets: CodeSnippet seq) =
              snippets
              |> Seq.collect(fun snp -> snp.ContentIndented fetcher addLinePrepos)
          static member Code fetcher (snippets: CodeSnippet seq) =
              CodeSnippet.CodePrepos fetcher true snippets
              |> Seq.map fst
              |> String.concat "\n"
          static member CodeFsx fetcher (snippets: CodeSnippet seq) =
              let codePrepos = CodeSnippet.CodePrepos fetcher true snippets
              let  code, assembs, defines, prepIs = separateDirectives codePrepos
              assembs |> Seq.distinct |> Seq.map (sprintf "#r @\"%s\"") |> String.concat "\n" |> (fun s -> s + "\n" + code)
              
          
      
      
      
      # 1 @"(6)eb54ba64-3d11-4347-97c8-aeae9e3e3121 MessagingClient.fsx"
      //#r "remote.dll"
      
      open CIPHERPrototype.Messaging
      
      //#r @"WebSharper.Core.dll"
      //#r @"WebSharper.Main.dll"
      //#r @"WebSharper.Web.dll"
      //#r @"Common.dll"
      
      open WebSharper
      open WebSharper.Remoting
      open Rop
      
      type MessagingClient(clientId, ?timeout, ?endPoint:string) =
          let wsEndPoint = endPoint    |> Option.defaultValue "http://localhost:9000/FSharpStation.html"
          let tout       = timeout     |> Option.defaultValue 60_000
          let fromId     = AddressId clientId
          do WebSharper.Remoting.EndPoint <- wsEndPoint 
          let awaitMessage respond =
              async {
                  while true do
      #if WEBSHARPER
                      let! msgA  = Async.StartChild(awaitRequestFor    fromId, tout)
      #else
                      let! msgA  = Async.StartChild(awaitRequestForRpc fromId, tout)
      #endif          
                      try
                          let! msg   = msgA
                          let  resp  = respond clientId msg.content
      #if WEBSHARPER
                          do!          replyTo    msg.messageId.Value resp
      #else
                          do!          replyToRpc msg.messageId.Value resp
      #endif              
                      with e -> printfn "%A" e
              } |> Async.Start
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
          member this.AwaitMessage respond = awaitMessage respond
          member this.SendMessage toId msg = sendMessage toId msg
          member this.POMessage        msg = poMsg id        msg
          member this.POListeners      ()  = poMsg poStrings POListeners
          member this.EndPoint             = wsEndPoint
          member this.ClientId             = clientId
          static member EndPoint_          = "http://localhost:9000/FSharpStation.html"
          
          
      
      
      # 1 @"(6)f6ebdffc-049c-4493-8de8-e32072419479 type FSMessage =.fsx"
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
      
      type FSResponse =
          | IdResponse        of string
          | StringResponse    of string option
          | SnippetResponse   of CodeSnippet option
          | SnippetsResponse  of CodeSnippet []
      
      
      # 1 @"(6)5597a227-c983-46fc-87e2-cbe241faa279 FsStationClient.fsx"
      //#r @"WebSharper.Core.dll"
      //#r @"WebSharper.Main.dll"
      //#r @"WebSharper.Web.dll"
      //#r @"Common.dll"
      
      open WebSharper
      open WebSharper.JavaScript
      open WebSharper.Remoting
      open CIPHERPrototype.Messaging
      open Rop
      
      type FsStationClientErr =
          | ``Snippet Not Found`` of string
      with interface ErrMsg with
              member this.ErrMsg    = 
                  match this with 
                  | msg                        -> sprintf "%A" msg
              member this.IsWarning = false     
      
      type FsStationClient(clientId, ?fsStationId:string, ?timeout, ?endPoint) =
          let fsIds      = fsStationId |> Option.defaultValue "FSharpStation-2fbd4d3a-45f8-4cbf-930d-f86c5d844898"
          let msgClient  = MessagingClient(clientId, ?timeout= timeout, ?endPoint= endPoint)
          let toId       = AddressId fsIds
          let stringResponse response =
              match response with
              | StringResponse (Some code)    -> Result.succeed code
              | _                             -> Result.fail    (``Snippet Not Found`` <| response.ToString()) 
          let snippetsResponse response =
              match response with
              | SnippetsResponse snps         -> Result.succeed snps
              | _                             -> Result.fail    (``Snippet Not Found`` <| response.ToString()) 
          [< Inline >]
          let sendMsg toId wrapMsg (checkResponse: FSResponse -> Result<'a>) v =
              Wrap.wrapper {
                  let! response = msgClient.SendMessage toId (wrapMsg v |> Json.Serialize)
                  let! resp     = checkResponse (Json.Deserialize<FSResponse> response)
                  return resp
              } 
        with 
          member this.SendMessage     (toId2, msg:FSMessage) = sendMsg toId2 id                  Result.succeed    msg
          member this.SendMessage     (       msg:FSMessage) = sendMsg toId  id                  Result.succeed    msg
          member this.RequestCode     (   snpPath:string   ) = sendMsg toId  GetSnippetCode      stringResponse   (snpPath.Split '/')
          member this.RequestPreds    (   snpPath:string   ) = sendMsg toId  GetSnippetPreds     snippetsResponse (snpPath.Split '/')
          member this.RequestPredsById(     snpId          ) = sendMsg toId  GetSnippetPredsById snippetsResponse snpId
          member this.GenericMessage  (       txt:string   ) = sendMsg toId  GenericMessage      stringResponse    txt
          member this.FSStationId                            = fsIds
          member this.MessagingClient                        = msgClient    
          static member FSStationId_                         = "FSharpStation-2fbd4d3a-45f8-4cbf-930d-f86c5d844898"
      
      
  # 1 @"(2)7479dc9d-94cd-4762-a1b8-cf6e09436c3f WebSharper Code.fsx"
  (*
   Code to be Compiled to Javascript and run in the browser
   using `Compile WebSharper` or `Run WebSharper`
  *)
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
    
    # 1 @"(4)495bce0a-4fb6-48fa-9158-c242d5965baa module HtmlNode      =.fsx"
    
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
      
      # 1 @"(6)336d6f19-0c57-4af9-8716-1b3fbf6b112c let inline storeVar'T storeName (varIRef_) =.fsx"
      [< Inline >]
      let inline storeVar<'T> storeName (var:IRef<_>) =
          JS.Window.LocalStorage.GetItem storeName |> fun v -> if v <> null then           var.Value <- Json.Deserialize<'T> v
          Val.sink (fun v -> JS.Window.LocalStorage.SetItem (storeName, Json.Serialize v)) var
      
      [< Inline """(!$v)""">]
      let isUndefined v = true
      # 1 @"(6)1f1aa135-fd74-42cc-b9a5-87f380c113a9 LoadFiles.fsx"
      [< Inline "CIPHERSpaceLoadFiles($files, $cb)" >]
      let LoadFiles (files: string []) (cb: unit -> unit) : unit = X<_>
    # 1 @"(4)3709b431-1507-48ed-9487-dd49ce7be748 open HtmlNode.fsx"
    open HtmlNode
    # 1 @"(4)e9ac2d66-474a-46a6-95fa-d369e6d703d1 module Template      =.fsx"
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
      # 1 @"(6)29c4d6ae-2bb7-457a-ba64-fcb7cce96a30 type Input = {.fsx"
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
      # 1 @"(6)c7841be7-5cd5-40f3-b91c-c107b487bc0c type Hoverable = {.fsx"
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
      
      # 1 @"(6)3234a0bf-4541-4f2c-8bbf-b5ab3a0e415b type TextArea = {.fsx"
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
        
      # 1 @"(6)4180353c-9dc5-438d-862d-851539b02075 let codeMirrorIncludes =.fsx"
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
      //      "/EPFileX/codemirror/scripts/codemirror/mode/markdown.js"                 
         |]
      # 1 @"(6)b03ba35c-a03c-4bbe-a373-1ce551524e56 type CodeMirrorEditor() =.fsx"
      type CodeMirrorEditor() =
          let a = 1
        with
          [< Inline "CodeMirror($elt, {
      	    theme        : 'rubyblue'
      	  , lineNumbers  : true
      	  , matchBrackets: true
            , extraKeys    : {
      		    Tab  : function (cm) { cm.replaceSelection('    ', 'end'); }
      		  , 'F11': function (cm) { cm.setOption('fullScreen', !cm.getOption('fullScreen')); }
              }
      })"    >]
      //    [< Inline "setupEditor($elt)" >]
          static member SetupEditor elt                               : CodeMirrorEditor = X<_>
          [< Inline "$this.getValue()"              >]
          member this.GetValue()                                      : string     = X<_>
          [< Inline "$this.setValue($v)"            >]
          member this.SetValue (v:string)                             : unit       = X<_>
          [< Inline "$this.getDoc().markText({line:$fl, ch:$fc}, {line:$tl, ch:$tc}, {className: $className, title: $title})" >]
          member this.MarkText (fl:int, fc:int) (tl:int, tc:int) (className: string) (title: string): unit       = X<_>
          [< Inline "while($this.getAllMarks().length > 0) { $this.getAllMarks()[0].clear() }" >]
          member this.RemoveMarks() : unit       = X<_>
          [< Inline "$this.getDoc().clearHistory()" >]
          member this.ClearHistory()                                  : unit       = X<_>
          [< Inline "$this.on($event, $f)"          >]
          member this.On(event: string, f:(CodeMirrorEditor * obj) -> unit) : unit     = X<_>
      
      [<NoComparison ; NoEquality>]
      type CodeMirror = {
          _class          : Val<string>
          style           : Val<string>
          id              : string
          var             : IRef<string>
          onChange        : (unit -> unit)
          mutable editorO : CodeMirrorEditor option
      } with
      
        static member  New(var) = 
            { _class   = Val.fixit "" 
              style    = Val.fixit "" 
              id       = ""
              var      = var 
              onChange = ignore
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
                css  ".CodeMirror { height: 100% }"
           ]
        member inline this.Class    clas = { this with _class    = Val.fixit clas }
        member inline this.Id       id   = { this with id        =       id       }
        member inline this.SetVar   v    = { this with var       = v              }
        member inline this.Style    sty  = { this with style     = Val.fixit sty  }
        member inline this.OnChange f    = { this with onChange  = f              }
        member inline this.Var           = this.var
      
      # 1 @"(6)70030378-692d-431d-bed9-c839a7f95798 type SplitterBar = {.fsx"
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
          
      # 1 @"(6)0047d2f0-ec1d-43b1-b432-95462c318445 type Grid.fsx"
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
    # 1 @"(4)e2ca8cb1-fb1e-4793-855f-55e3ca07b8f5 module RunCode       =.fsx"
    [<JavaScript>]
    module RunCode       =
      # 1 @"(6)79f8f6c6-d1f5-4593-9775-60ba2863e94d module EditorRpc =.fsx"
      //#r @"ZafirTranspiler.dll"
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
    # 1 @"(4)c2188026-a06a-4963-a95a-93075e5f5b6e module FSharpStation =.fsx"
    [<JavaScript>]
    module FSharpStation =
    
      # 1 @"(6)987560b0-1fe6-4835-ad99-aed93db7da1a currentCodeSnippetId.fsx"
      open FsStationShared
      
      //let codeSnippetsStorage = WebSharper.UI.Next.Storage.LocalStorage "CodeSnippets" Serializer.Typed<CodeSnippet>
      //let codeSnippets        = ListModel.CreateWithStorage<CodeSnippetId, CodeSnippet> (fun s -> s.id) codeSnippetsStorage
      let codeSnippets        = ListModel.Create<CodeSnippetId, CodeSnippet> (fun s -> s.id) []
      let fsIds  = "FSharpStation-" + (System.Guid.NewGuid() |> string)
      
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
          member this.Predecessors() : CodeSnippet [] =
              let preds = this.UniquePredecessors CodeSnippet.FetchO |> Seq.toArray
              codeSnippets.Value
              |> Seq.filter (fun snp -> preds |> Array.contains snp.id)
              |> Seq.map    (fun snp -> { snp with content = snp.content.Replace("##" + "FSHARPSTATION_ID" + "##", fsIds).Replace("##" + "FSHARPSTATION_ENDPOINT" + "##", JS.Window.Location.Href) } )
              |> Seq.toArray
          member this.GetCode   () = this.Predecessors() |> CodeSnippet.Code    CodeSnippet.FetchO
          member this.GetCodeFsx() = this.Predecessors() |> CodeSnippet.CodeFsx CodeSnippet.FetchO
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
          
          
      # 1 @"(6)07e477d3-fb6e-4c83-bb89-b4b2cce55d7b CodeEditorMain.fsx"
      let noSelection cur = CodeSnippet.FetchO cur = None
      let noSelectionVal  = Val.map noSelection currentCodeSnippetId
      
      let dirty    = Var.Create false 
      let codeFS   = Var.Create ""
      let codeJS   = Var.Create ""
      let codeMsgs = Var.Create ""
      
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
      
      do Val.sink (fun m -> 
          JS.Window.Onbeforeunload <- 
              if m then System.Action<Dom.Event>(fun (e:Dom.Event) -> e?returnValue  <- "Changes you made may not be saved.")
              else null
          ) dirty 
      
      let setDirty() = dirty.Value <- true
      let setClean() = dirty.Value <- false
      
      let getFSCode () =
          CodeSnippet.FetchO currentCodeSnippetId.Value 
          |> Option.iter (fun snp -> codeFS.Value <- snp.GetCodeFsx() )
      
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
      
      let processSnippet msg processCode =
          CodeSnippet.FetchO currentCodeSnippetId.Value 
          |> Option.iter (fun snp -> 
              codeMsgs.Value <- msg
              codeJS.Value   <- ""
              let code = snp.GetCode()
              codeFS.Value   <- code
              processCode       code
          )
      
      let compileSnippet fThen fFail = 
          processSnippet "Compiling to JavaScript..." (RunCode.compile (fun msgs js -> codeJS.Value <- js ; fThen msgs js) fFail)
      
      let compileRun  () = compileSnippet runJS                                               sendMsg
      let justCompile () = compileSnippet (fun msgs _ -> sendMsg "Compiled!" ; sendMsg msgs)  sendMsg
      let evaluateFS  () = 
          processSnippet "Evaluating F# code..." 
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
      
      
      # 1 @"(6)93f32df7-da8b-472f-8bad-e82cc58ec52b let listEntry code =.fsx"
      let isDirectPredecessor pre curO =
          curO
          |> Option.map (fun snp -> snp.predecessors |> List.contains pre)
          |> Option.defaultValue false
      
      let curPredecessors =
          Val.map (   Option.map          (fun (snp:CodeSnippet) -> snp.UniquePredecessors CodeSnippet.FetchO)
                    >> Option.defaultValue [])  currentCodeSnippetO  
      
      let isIndirectPredecessor pre predecessors = predecessors |> List.contains pre
          
      let togglePredecessorForCur (pre:CodeSnippet) curO =
          curO |> Option.iter (fun cur ->
              if cur = pre || isIndirectPredecessor cur.id (pre.UniquePredecessors CodeSnippet.FetchO) then () else
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
                                    style1 "text-indent" (sprintf "%dem" <| code.Level CodeSnippet.FetchO)
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
      # 1 @"(6)60191ea0-da20-4fbf-96b8-3871338a66d8 let addCode   ()   =.fsx"
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
            let root = 
                e.GetRootNode()?body 
                |> unbox
                |> (fun (body:Dom.Element) -> if isUndefined(body) then e.GetRootNode().FirstChild :?> Dom.Element else body)
            loadTextFile (root.QuerySelector("#" + fileInputElementId))
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
      # 1 @"(6)fa5b4506-b26d-4387-8e04-ac7a5a90861a let styleEditor    =.fsx"
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
      .Warning { background-color: blue    } 
      .Error   { background-color: darkred } 
          """
      # 1 @"(6)47f7c0ba-35b0-466e-a759-4e4d9963e524 let (REGEX_) (expr string) (opt string) (value string) =.fsx"
      let (|REGEX|_|) (expr: string) (opt: string) (value: string) =
          if value = null then None else
          try 
              match String(value).Match(RegExp(expr, opt)) with
              | null         -> None
              | [| |]        -> None
              | m            -> Some m
          with e -> None
      
      let codeMirror = Template.CodeMirror.New(Val.bindIRef curSnippetCodeOf currentCodeSnippetId).OnChange(setDirty ).Style("height: 100%")
      
      let rex1 = """\((\d+)\) F# (.+).fsx\((\d+)\,(\d+)\): (error|warning) ((.|\b)+)"""
      let rex2 = """(Err|Warning)(FSharp|WebSharper)\s+"(\((\d+)\) )?F# (.+?)(.fsx)? \((\d+)\,\s*(\d+)\) - \((\d+)\,\s*(\d+)\) ((.|\s)+?)""" + "\""
      let rex = rex1 + "|" + rex2
      
      let mutable prior = "", ""
      
      Val.map2 (fun msgs curO -> msgs, curO) codeMsgs currentCodeSnippetO
      |> Val.sink (fun (msgs, curO) ->
          async {
              match codeMirror.editorO  with
              | None        -> () 
              | Some editor ->
                  match curO with 
                  | None -> () 
                  | Some cur ->
                  curSnippetNameOf cur.id
                  |> Val.iter (fun name ->
                      printfn "RemoveMarks: %s" name
                      if prior = (msgs, name) then () else
                      prior   <- (msgs, name)
                      editor.RemoveMarks()
                      match msgs with
                      | REGEX rex "g" m -> m
                      | _               -> [||]
                      |> Array.choose (fun v ->
                          match v with
                          | REGEX rex2 "" [| _ ; sev; from;  _; indent; file; _; fl; fc; tl; tc; msg; _ |] -> Some (file, int fl, int fc - int indent    , int tl, int tc - int indent, sev, from , msg)
                          | REGEX rex1 "" [| _ ;                indent; file   ; fl; fc;    sev; msg; _ |] -> Some (file, int fl, int fc - int indent - 1, int fl, int fc - int indent, sev, "fsi", msg)
                          | _ -> None
                      )
                      |> Array.iter (fun (file, fl, fc, tl, tc, sev, from, msg) ->
                          printfn "inside -%s-%s-" file (sanitize name)
                          if file = sanitize name then
                              100
                              |> JS.SetTimeout (fun () ->
                                  editor.MarkText (fl - 1, fc) (tl - 1, tc) (if sev.ToUpper().StartsWith("ERR") then "Error" else "Warning")  msg)
                              |> ignore
          
                      )
                  )
          } |> Async.Start
      )
      
      # 1 @"(6)95ca1e9f-4029-4fc1-8b1c-ab12db71c90b Messaging.fsx"
      //#r "remote.dll"
      open CIPHERPrototype.Messaging
      open FsStationShared
      
      let fsStationClient = FsStationClient(fsIds, fsIds)
      
      let respond fromId (msg:FSMessage) : FSResponse =
          match msg with
          | GetSnippetContentById sId  -> CodeSnippet.FetchO       sId  |> Option.map (fun snp -> snp.content       )                             |> StringResponse       
          | GetSnippetCodeById    sId  -> CodeSnippet.FetchO       sId  |> Option.map (fun snp -> snp.GetCode     ())                             |> StringResponse 
          | GetSnippetPredsById   sId  -> CodeSnippet.FetchO       sId  |> Option.map (fun snp -> snp.Predecessors()) |> Option.defaultValue [||] |> SnippetsResponse
          | GetSnippetById        sId  -> CodeSnippet.FetchO       sId                                                                            |> SnippetResponse 
          | GetSnippetContent     path -> CodeSnippet.FetchByPathO path |> Option.map (fun snp -> snp.content       )                             |> StringResponse
          | GetSnippetCode        path -> CodeSnippet.FetchByPathO path |> Option.map (fun snp -> snp.GetCode     ())                             |> StringResponse
          | GetSnippetPreds       path -> CodeSnippet.FetchByPathO path |> Option.map (fun snp -> snp.Predecessors()) |> Option.defaultValue [||] |> SnippetsResponse
          | GetSnippet            path -> CodeSnippet.FetchByPathO path                                                                           |> SnippetResponse 
          | GenericMessage        txt  -> (Some <| "Message received: " + txt)                                                                    |> StringResponse
          | GetIdentification          -> fromId                                                                                                  |> IdResponse  
      
      let respondMessage fromId txt =
          txt 
          |> Json.Deserialize
          |> respond fromId
          |> Json.Serialize
      
      1000 |> JS.SetTimeout (fun () -> fsStationClient.MessagingClient.AwaitMessage respondMessage) |> ignore
      
      
      # 1 @"(6)75c3d033-99b5-409f-8ecb-cd9bd8b101ab CodeEditor.fsx"
      let spl1         = Template.SplitterBar.New(20.0).Children([ style "grid-row: 2 / 4" ])
      storeVarCodeEditor "splitterV1" spl1.Var
      //storeVarCodeEditor "splitterV2" splitterV2.Var
      //storeVarCodeEditor "splitterH3" splitterH3.Var
      let CodeEditor() =
        Template.Grid.New
           .ColVariable(spl1).ColVariable(50.0).Max(Val.map ((-) 92.0) spl1.GetValue).Children([ style "grid-row: 3 / 5" ]).ColAuto(0.0)
           .RowFixedPx(34.0) .RowAuto(0.0).RowVariable(17.0).Children([ style "grid-column: 2 / 4" ]).Before.RowFixedPx(80.0)
           .Padding(1.0)
           .Content( style  """ 
                          grid-template-areas:
                              'header0 header   header  '
                              'sidebar content1 content1'
                              'sidebar content2 content3'
                              'footer  footer   footer2 ';
                          color      : #333;
                          height     : 100%;
                          font-size  : small;
                          font-family: monospace;
                          line-height: 1.2;
                      """)
           .Content("sidebar", 
              div [ style "overflow: auto"
                    codeSnippets.View
                    |> View.SnapshotOn codeSnippets.Value refresh.View
                    |> View.Map listEntries
                    |> Doc.BindView id |> SomeDoc
                  ])
           .Content("header"  , Template.Input     .New(Val.bindIRef curSnippetNameOf currentCodeSnippetId).Prefix(htmlText "name:")         .Render)
           .Content("content1", codeMirror                                                                                                   .Render)
           .Content("content2", Template.TextArea  .New(codeMsgs).Placeholder("Output:"    ).Title("Messages"                 )              .Render)
           .Content("content3", Template.TextArea  .New(codeJS  ).Placeholder("Javascript:").Title("JavaScript code generated")              .Render)
           .Content("footer2" , Template.TextArea  .New(codeFS  ).Placeholder("F# code:"   ).Title("F# code assembled"        )              .Render) 
           .Content("footer"  ,       
              div [ 
                    Template.Button.New("Add code"              ).Class("btn btn-xs"     ).OnClick(Do addCode      )                          .Render
                    Template.Button.New("<<"                    ).Class("btn btn-xs"     ).OnClick(Do indentCodeOut).Disabled(noSelectionVal) .Render
                    Template.Button.New(">>"                    ).Class("btn btn-xs"     ).OnClick(Do indentCodeIn ).Disabled(noSelectionVal) .Render
                    loadFileElement.Render.AddChildren([ style "grid-column: 4/6" ])
                    span []       
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
      
      # 1 @"(6)07f11803-2084-4a0a-9066-a43fd11be1c7 CodeEditor page.fsx"
      let splitterMain1 =
          Template.SplitterBar.New( 0.0).Vertical(directionVertical).Min( 0.0).Max(35.0)
      
      let splitterMain2 =
          Template.SplitterBar.New(24.0).Vertical(directionVertical).Min( 0.5).Max(Val.map (fun pos -> if pos = NewBrowser then 0.1 else 50.0) position).Before
      
      storeVarCodeEditor "splitterMain1" splitterMain1.Var
      storeVarCodeEditor "splitterMain2" splitterMain2.Var
      
      //RunCode.RunNode("CodeEditor").AddBootstrap.RunHtml <| CodeEditor()
      //addNodeById "pageStyle"                            <| styleH [ htmlText pageStyle ]
      //addNodeById "splitterMain1"                        <| splitterMain1.Render
      //addNodeById "splitterMain2"                        <| splitterMain2.Render
      
      let grid = 
          Template.Grid.New
             .Padding(0.0)
             .Content("editor", CodeEditor())
             .Content(style    "height: 100vh; margin: 0px; ")
             .Content(css """
                 #CodeEditor              { grid-area: editor  ; overflow: hidden; }
                 #TestNode                { grid-area: testNode; overflow: auto  ; }
                 body > div:first-of-type { grid-area: header  ; overflow: hidden; }
             """)
      
      directionVertical
      |> Val.map (fun dir ->
          (if dir
           then grid.ColVariable(splitterMain1).ColAuto(16.0).ColVariable(splitterMain2).Content(style """ grid-template-areas: 'header   editor   testNode'; """)
           else grid.RowVariable(splitterMain1).RowAuto(16.0).RowVariable(splitterMain2).Content(style """ grid-template-areas: 'header' 'editor' 'testNode'; """)
          ).GridTemplate())
      |> bindHElem body
      |> renderDoc
      |> Doc.RunReplace JS.Document.Body
      
      