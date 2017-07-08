namespace CIPHERPrototype

open WebSharper
open WebSharper.JavaScript
open WebSharper.UI.Next
open WebSharper.UI.Next.Client
open WebSharper.UI.Next.Html
open WebSharper.UI.Next.Templating

type TestForm = Template<"Main.html, MyPage.html">

[< JavaScript ; Sealed >]
type CodeMirrorLoader () = 
    inherit WebSharper.Core.Resources.BaseResource("/EPFileX/codemirror"
            ,  "content/editor.css"
            ,  "content/codemirror.css"
            ,  "content/theme/rubyblue.css"
            ,  "scripts/intellisense.js"
            ,  "scripts/codemirror/codemirror.js"
            ,  "scripts/codemirror/codemirror-intellisense.js"
            ,  "scripts/codemirror/codemirror-compiler.js"
            ,  "scripts/codemirror/mode/fsharp.js"
            ,  "scripts/addon/edit/matchbrackets.js"
            ,  "scripts/addon/selection/active-line.js"
            ,  "scripts/addon/display/fullscreen.css"
            ,  "scripts/addon/display/fullscreen.js"
            ,  "scripts/codemirror/mode/markdown.js"
            )

[<JavaScript ; Require(typeof<CodeMirrorLoader>) >]
type CodeMirror () = 
    [< Inline "setupEditor($elt)" >]
    static member setupEditor elt : CodeMirror = X<_>
    [< Inline "$this.getValue()" >]
    member this.getValue() : string = X<_>

open WebSharper

module EditorRpc =
    open Editor

    [< JavaScript >]
    let callRPC asy callback =
        async {
            let! res = asy
            callback res
        } |> Async.Start

    [< JavaScript >]
    let checkSourceClient  source          callback = checkSource  source          |> callRPC <| callback
    [< JavaScript >]
    let methodsClient      source line col callback = methods      source line col |> callRPC <| callback
    [< JavaScript >]
    let declarationsClient source line col callback = declarations source line col |> callRPC <| callback
    [< JavaScript >]
    let translateClient    source minified callback = translate    source minified |> callRPC <| callback

open Val
open Val.Html
[<JavaScript>]
module TestForm =

    [<NoComparison ; NoEquality>]
    type Button = {
        _class  : Val<string>
        _type   : Val<string>
        style   : Val<string>
        text    : Val<string>
        onClick : Dom.Element -> Dom.MouseEvent -> unit
        disabled: Val<bool>
    } with
      static member inline New txt = 
          { _class   = Val.fixit "btn" 
            _type    = Val.fixit "button" 
            style    = Val.fixit "" 
            text     = Val.fixit txt
            onClick  = fun _ _ -> ()
            disabled = Val.fixit false
          }
      member        this.Render     =         
        button [ ``type``  <| this._type
                 ``class`` <| this._class
                 style     <| this.style
                 SomeAttr  <| attr.disabledDynPred (View.Const "") (this.disabled |> Val.toView)
                 SomeAttr  <| on.click <@ this.onClick @>
                 HtmlText  <| this.text 
               ]
      member inline this.Class       clas = { this with _class   = Val.fixit clas }
      member inline this.Type        typ  = { this with _type    = Val.fixit typ  }
      member inline this.Style       sty  = { this with style    = Val.fixit sty  }
      member inline this.Text        txt  = { this with text     = Val.fixit txt  }
      member inline this.Disabled    dis  = { this with disabled = Val.fixit dis  }
      member inline this.OnClick     f    = { this with onClick  = f              }

    let dynamicSection () =
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
            EditorRpc.translateClient code false <|
                 (fun (jsO, msgs) ->
                     jsO
                     |> Option.map completeJS
                     |> function
                     | Some js -> fThen  msgs   js
                     | None    -> fFail  msgs
                  )        

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
              Button.New("Eval F#").Style("vertical-align:top").OnClick(fun _ _ -> runFS()                                 ).Render  
              someElt <| Doc.InputArea [ attr.placeholder "F#:"         ; attr.title "Add F# code and invoke with Eval F#" ] freeFS
              someElt <| Doc.InputArea [ attr.placeholder "HTML:"       ; attr.title "Enter HTML tags and text"            ] freeHtml 
              someElt <| Doc.InputArea [ attr.placeholder "CSS:"        ; attr.title "Test your CSS styles dynamically"    ] freeCSS 
              someElt <| Doc.InputArea [ attr.placeholder "JavaScript:" ; attr.title "Add JS code and invoke with Eval JS" ] freeJS
              Button.New("Eval JS").Style("vertical-align:top").OnClick(fun _ _ -> freeMsgs.Value <- "" ; runJS()          ).Render  
              someElt <| Doc.InputArea [ attr.placeholder "Output:"     ; attr.title "Messages"                            ] freeMsgs
              SomeDoc <| tag Doc.Verbatim (Val.map2 (sprintf "%s<style>%s</style>") freeHtml freeCSS)
        ] |> renderDoc
(*        let varDynamicHtml = Var.Create "How are you?"
        let varMessages    = Var.Create "" 
        let varCode        = Var.Create ""
        let processJSCode (jsO, msgs) =
            varMessages.Value <- 
                match jsO with
                | None    -> msgs
                | Some js -> 
                    try 
                       JS.Eval """CIPHERSpaceLoadFilesDoAfter(function() { for (key in window) { if (key.startsWith("StartupCode$")) try { window[key].$cctor(); } catch (e) {} } })""" |> ignore
                       JS.Eval js |> ignore
                       "Done!\n" + msgs
                    with e -> e.ToString()
        let runFSharp () =
            varMessages.Value <- "Processing..."
            varCode.Value 
            |> EditorRpc.translateClient 
               <| false 
               <| processJSCode

        div [ 
              someElt <| Doc.InputArea [ attr.placeholder "F# code here:"   ] varCode
              div [ button 
                      [ ``class`` "btn btn-block"
                        SomeAttr  <|  on.click <@ fun _ _ -> runFSharp() @>                                           
                        htmlText "Run F#" 
                      ]
                  ]
              someElt <| Doc.InputArea [ attr.placeholder "Messages here."   ] varMessages   
              someElt <| Doc.InputArea [ attr.placeholder "Enter HTML here:" ] varDynamicHtml
              br []
              SomeDoc <| tag Doc.Verbatim                                      varDynamicHtml       
        ]
        |> renderDoc                                                                                 *)


    let showForm staticHtml =
        TestForm.Main()
            .Title("Test Form")
            .Body(
                [
                    staticHtml |> Doc.Verbatim
                    scriptAttr [ attr.src "/EPFileX/CIPHERSpaceLoadFiles.js" ] [] :> Doc
                    client <@ dynamicSection() @>
                ]
            )
            .Doc()
