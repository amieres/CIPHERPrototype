[{"indents":{"$":1},"order":1,"name":"#if INTERACTIVE x","content":"#if INTERACTIVE ","predecessors":[{"$":0,"Item":"106ad00d-ee7e-4948-a022-bf02041d60a7"}],"companions":[],"id":{"$":0,"Item":"0de17a9a-b61d-4bf2-a475-06ad980404ff"}},{"indents":{"$":1},"order":5,"name":"System dlls","content":"//#r @\"C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.6.1\\System.Web.dll\"\n//#r @\"C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.6.1\\System.Core.dll\"\n","predecessors":[{"$":0,"Item":"0de17a9a-b61d-4bf2-a475-06ad980404ff"}],"companions":[],"id":{"$":0,"Item":"4d91e739-77fc-495e-8e01-cda6f26c7835"}},{"indents":{"$":1},"order":7,"name":"WebSharper dlls","content":"#r @\"D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\WebSharper.Core.dll\"\n#r @\"D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\WebSharper.Collections.dll\"\n#r @\"D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\WebSharper.Main.dll\"\n#r @\"D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\WebSharper.UI.Next.dll\"\n#r @\"D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\WebSharper.JavaScript.dll\"\n","predecessors":[{"$":0,"Item":"0de17a9a-b61d-4bf2-a475-06ad980404ff"}],"companions":[],"id":{"$":0,"Item":"e7094a13-7915-4e4a-9eac-b2a225e34a94"}},{"indents":{"$":1},"order":8,"name":"WebSharper UI dlls","content":"#r @\"D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\WebSharper.Web.dll\"\n#r @\"D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\WebSharper.UI.Next.dll\"\n","predecessors":[{"$":0,"Item":"0de17a9a-b61d-4bf2-a475-06ad980404ff"},{"$":0,"Item":"e7094a13-7915-4e4a-9eac-b2a225e34a94"}],"companions":[],"id":{"$":0,"Item":"6ccdcf8b-134a-4689-9785-5bdcb20a8c92"}},{"indents":{"$":1},"order":4,"name":"CIPHERHtml dll","content":"#r @\"D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\CIPHERHtml.dll\" ","predecessors":[{"$":0,"Item":"0de17a9a-b61d-4bf2-a475-06ad980404ff"}],"companions":[],"id":{"$":0,"Item":"9c69b4ba-0bdf-431a-a5cd-db58b9dddd8a"}},{"indents":{"$":1},"order":6,"name":"CIPHERPrototype WebServer dlls","content":"//#r @\"D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\Common.dll\"\n//#r @\"D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\Auth.dll\"\n//#r @\"D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\Remote.dll\"\n","predecessors":[{"$":0,"Item":"0de17a9a-b61d-4bf2-a475-06ad980404ff"}],"companions":[],"id":{"$":0,"Item":"a28fe808-236e-4b7e-9509-51ebe21e35fc"}},{"indents":{"$":1},"order":9,"name":"","content":"#else","predecessors":[{"$":0,"Item":"0de17a9a-b61d-4bf2-a475-06ad980404ff"}],"companions":[],"id":{"$":0,"Item":"66ab3e22-f5ed-4e75-966d-28394d24f3d7"}},{"indents":{"$":1},"order":10,"name":"","content":"namespace Test","predecessors":[{"$":0,"Item":"66ab3e22-f5ed-4e75-966d-28394d24f3d7"}],"companions":[],"id":{"$":0,"Item":"7479dc9d-94cd-4762-a1b8-cf6e09436c3f"}},{"indents":{"$":1},"order":11,"name":"","content":"#endif ","predecessors":[],"companions":[],"id":{"$":0,"Item":"106ad00d-ee7e-4948-a022-bf02041d60a7"}},{"indents":{"$":1},"order":12,"name":"","content":"open WebSharper\nopen WebSharper.JavaScript\n","parent":{"$":0,"Item":"7479dc9d-94cd-4762-a1b8-cf6e09436c3f"},"predecessors":[{"$":0,"Item":"e7094a13-7915-4e4a-9eac-b2a225e34a94"}],"companions":[],"id":{"$":0,"Item":"60bffe71-edde-4971-8327-70b9f5c578bb"}},{"indents":{"$":1},"order":13,"name":"open WebSharper.JavaScript ","content":"open WebSharper.JavaScript ","parent":{"$":0,"Item":"7479dc9d-94cd-4762-a1b8-cf6e09436c3f"},"predecessors":[{"$":0,"Item":"e7094a13-7915-4e4a-9eac-b2a225e34a94"}],"companions":[],"id":{"$":0,"Item":"17e3c5b3-3602-4b39-b80a-6ee1c0cef740"}},{"indents":{"$":1},"order":15,"name":"","content":"open WebSharper.UI.Next\nopen WebSharper.UI.Next.Client\n","parent":{"$":0,"Item":"7479dc9d-94cd-4762-a1b8-cf6e09436c3f"},"predecessors":[{"$":0,"Item":"6ccdcf8b-134a-4689-9785-5bdcb20a8c92"}],"companions":[],"id":{"$":0,"Item":"bcd0b4ef-b3c3-4fc7-93e9-afb8981420aa"}},{"indents":{"$":1},"order":14,"name":"","content":"open CIPHERPrototype\nopen CIPHERPrototype.Val.Html\n","parent":{"$":0,"Item":"7479dc9d-94cd-4762-a1b8-cf6e09436c3f"},"predecessors":[{"$":0,"Item":"9c69b4ba-0bdf-431a-a5cd-db58b9dddd8a"}],"companions":[],"id":{"$":0,"Item":"02d3bc50-4aa0-41ce-a37e-5b90a943481f"}},{"indents":{"$":1},"order":17,"name":"module Template","content":"[<JavaScript>]\nmodule Template =","parent":{"$":0,"Item":"7479dc9d-94cd-4762-a1b8-cf6e09436c3f"},"predecessors":[{"$":0,"Item":"60bffe71-edde-4971-8327-70b9f5c578bb"},{"$":0,"Item":"11ecbe45-3d0c-4121-a8fd-7c126b96f4a3"}],"companions":[],"id":{"$":0,"Item":"e9ac2d66-474a-46a6-95fa-d369e6d703d1"}},{"indents":{"$":1},"order":18,"name":"type on, type attr  (UI.Next)","content":"type on   = WebSharper.UI.Next.Html.on\ntype attr = WebSharper.UI.Next.Html.attr\n","parent":{"$":0,"Item":"e9ac2d66-474a-46a6-95fa-d369e6d703d1"},"predecessors":[{"$":0,"Item":"6ccdcf8b-134a-4689-9785-5bdcb20a8c92"}],"companions":[],"id":{"$":0,"Item":"12fb5bda-7dcc-4389-9978-3bbe6f40f447"}},{"indents":{"$":1},"order":19,"name":"","content":"let container content = div <| [ ``class`` \"container\" ] @ content","parent":{"$":0,"Item":"e9ac2d66-474a-46a6-95fa-d369e6d703d1"},"predecessors":[{"$":0,"Item":"02d3bc50-4aa0-41ce-a37e-5b90a943481f"},{"$":0,"Item":"081bac32-e739-4124-87eb-eb7d6f2220bc"}],"companions":[],"id":{"$":0,"Item":"8fb54777-3046-4aae-9282-33401a45c280"}},{"indents":{"$":1},"order":21,"name":"Template.Button","content":"[<NoComparison ; NoEquality>]\ntype Button = {\n    _type   : Val<string>\n    _class  : Val<string>\n    text    : Val<string>\n    onClick : unit -> unit\n} with\n  static member  New   = { _class  = Val.fixit \"btn\" \n                           _type   = Val.fixit \"button\" \n                           text    = Val.fixit \"Button\"\n                           onClick = fun () -> ()\n                         }\n  static member Demo = Button.New\n  member        this.Render     =         \n    button [ ``type``  <| this._type\n             ``class`` <| this._class\n             SomeAttr  <| on.click <@ fun _ _ -> this.onClick() @>\n             HtmlText  <| this.text \n           ]\n  member inline this.Class       clas = { this with _class  = Val.fixit clas                                        }\n  member inline this.Type        typ  = { this with _type   = Val.fixit typ                                         }\n  member inline this.Text        txt  = { this with text    = Val.fixit txt                                         }\n  member inline this.OnClick     f    = { this with onClick = f                                                 }\n","parent":{"$":0,"Item":"e9ac2d66-474a-46a6-95fa-d369e6d703d1"},"predecessors":[{"$":0,"Item":"12fb5bda-7dcc-4389-9978-3bbe6f40f447"},{"$":0,"Item":"02d3bc50-4aa0-41ce-a37e-5b90a943481f"},{"$":0,"Item":"bcd0b4ef-b3c3-4fc7-93e9-afb8981420aa"}],"companions":[],"id":{"$":0,"Item":"5e1dd5fc-a27c-4b0d-821a-06cc8a27bb82"}},{"indents":{"$":1},"order":20,"name":"Template.Input","content":"[<NoComparison ; NoEquality>]\ntype Input = {\n    _type       : Val<string>\n    _class      : Val<string>\n    placeholder : Val<string>\n    var         : IRef<string>\n    prefix      : HtmlNode\n    suffix      : HtmlNode\n    content     : HtmlNode\n    prefixAdded : bool\n    suffixAdded : bool\n} with\n  static member  New(var) = { _class      = Val.fixit \"form-control\" \n                              _type       = Val.fixit \"text\" \n                              placeholder = Val.fixit \"Enter text:\"\n                              content     = br []\n                              prefix      = HtmlEmpty\n                              prefixAdded = false\n                              suffix      = HtmlEmpty\n                              suffixAdded = false\n                              var         = var   \n                            }\n  static member  New(v)   = Input.New(Var.Create v)\n  static member Demo   =  Input.New(\"HELLO!\")\n  member        this.Render    =         \n    let groupClass det = match det with HtmlText _  -> \"input-group-addon\" | _ -> \"input-group-btn\"\n    div [\n          div [\n              if this.prefixAdded || this.suffixAdded then\n                  yield ``class`` \"input-group\"\n              if this.prefixAdded then\n                  yield  span     [ ``class`` <| groupClass this.prefix \n                                    this.prefix       ]\n              yield Doc.Input [ Val._type        this._type\n                                Val._class       this._class\n                                Val._placeholder this.placeholder ]\n                                this.var\n                    :> Doc |> SomeDoc\n              if this.suffixAdded then\n                  yield  span     [ ``class`` <| groupClass this.suffix \n                                    this.suffix       ]\n            ]\n          this.content\n        ]\n  member inline this.Class       clas = { this with _class      = Val.fixit clas                  }\n  member inline this.Type        typ  = { this with _type       = Val.fixit typ                   }\n  member inline this.Placeholder plc  = { this with placeholder = Val.fixit plc                   }\n  member inline this.Content     c    = { this with content     =       c                         }\n  member inline this.Prefix      p    = { this with prefix      =       p    ; prefixAdded = true }\n  member inline this.Suffix      s    = { this with suffix      =       s    ; suffixAdded = true }\n  member inline this.SetVar      v    = { this with var         = v                               }\n  member inline this.Var              = this.var\n","parent":{"$":0,"Item":"e9ac2d66-474a-46a6-95fa-d369e6d703d1"},"predecessors":[{"$":0,"Item":"bcd0b4ef-b3c3-4fc7-93e9-afb8981420aa"},{"$":0,"Item":"02d3bc50-4aa0-41ce-a37e-5b90a943481f"}],"companions":[],"id":{"$":0,"Item":"29c4d6ae-2bb7-457a-ba64-fcb7cce96a30"}},{"indents":{"$":1},"order":22,"name":"Template.Panel","content":"[<NoComparison ; NoEquality>]\ntype Panel = {\n    _class   : Val<string>\n    _style   : Val<string>\n    title    : Val<string>\n    header   : HtmlNode seq\n    content  : HtmlNode seq\n    disabled : Val<bool>\n} with\n  static member  New   = { _class   = Val.fixit <| \"panel panel-default shadow\"\n                           _style   = Val.fixit <| \"text-align:center\" \n                           title    = Val.fixit <| \"Panel\"        \n                           header   =          [ htmlText \"Some text\"    ] \n                           content  =          [ htmlText \"Some Content\" ] \n                           disabled = Val.fixit <| Var.Create false\n                         }\n  member        this.Render          =  \n    fieldset [ SomeAttr <| attr.disabledDynPred (View.Const \"\")  (this.disabled |> Val.toView)\n               div [ ``class`` this._class\n                     div (Seq.append\n                              [ ``class`` \"panel-heading\"\n                                label [ ``class``  \"panel-title text-center\" ; htmlText this.title ]\n                              ]\n                              this.header)\n\n                     div (Seq.append\n                              [ ``class`` \"panel-body\"\n                                style     this._style \n                              ]\n                              this.content)\n                   ] \n             ]\n  member inline this.Class       clas = { this with _class   = Val.fixit clas                                        }\n  member inline this.Style       sty  = { this with _style   = Val.fixit sty                                         }\n  member inline this.Title       txt  = { this with title    = Val.fixit txt                                         }\n  member inline this.Header      h    = { this with header   =       h                                           }\n  member inline this.Content     c    = { this with content  =       c                                           }\n  member inline this.Disabled    dis  = { this with disabled =       dis                                         }\n","parent":{"$":0,"Item":"e9ac2d66-474a-46a6-95fa-d369e6d703d1"},"predecessors":[{"$":0,"Item":"12fb5bda-7dcc-4389-9978-3bbe6f40f447"},{"$":0,"Item":"02d3bc50-4aa0-41ce-a37e-5b90a943481f"},{"$":0,"Item":"bcd0b4ef-b3c3-4fc7-93e9-afb8981420aa"},{"$":0,"Item":"081bac32-e739-4124-87eb-eb7d6f2220bc"}],"companions":[],"id":{"$":0,"Item":"0a11766b-f227-4b38-88a3-919d964387bf"}},{"indents":{"$":1},"order":25,"name":"module TestCode","content":"[<JavaScript>]\nmodule TestForm =","parent":{"$":0,"Item":"7479dc9d-94cd-4762-a1b8-cf6e09436c3f"},"predecessors":[{"$":0,"Item":"60bffe71-edde-4971-8327-70b9f5c578bb"},{"$":0,"Item":"1095ae38-19fc-4195-840c-c368a3a486c4"}],"companions":[],"id":{"$":0,"Item":"e2ca8cb1-fb1e-4793-855f-55e3ca07b8f5"}},{"indents":{"$":1},"order":27,"name":"testNodeId","content":"let testNodeId = \"CodeResult\"","parent":{"$":0,"Item":"e2ca8cb1-fb1e-4793-855f-55e3ca07b8f5"},"predecessors":[],"companions":[],"id":{"$":0,"Item":"f2571ac9-37ec-4d7c-9ead-9e5f79ae1be1"}},{"indents":{"$":1},"order":28,"name":"clear CodeResult","content":"do (JS.Document.GetElementById testNodeId).InnerHTML <- \"\"","parent":{"$":0,"Item":"e2ca8cb1-fb1e-4793-855f-55e3ca07b8f5"},"predecessors":[{"$":0,"Item":"f2571ac9-37ec-4d7c-9ead-9e5f79ae1be1"},{"$":0,"Item":"17e3c5b3-3602-4b39-b80a-6ee1c0cef740"}],"companions":[],"id":{"$":0,"Item":"aba6c516-0ac9-4abe-95a2-7257d077e338"}},{"indents":{"$":1},"order":41,"name":"bootstrap","content":"do JS.Document.CreateElement \"div\"\n    |> fun el -> \n        el.InnerHTML <- \n            @\"<script src='http://code.jquery.com/jquery-3.1.1.min.js' type='text/javascript' charset='UTF-8'></script>\n            <script src='http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js' type='text/javascript' charset='UTF-8'></script>\n            <link type='text/css' rel='stylesheet' href='http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css'>\n            <link type='text/css' rel='stylesheet' href='/EPFileX/css/main.css'>\n            \"\n        (JS.Document.GetElementById testNodeId).AppendChild el |> ignore\n","parent":{"$":0,"Item":"e2ca8cb1-fb1e-4793-855f-55e3ca07b8f5"},"predecessors":[{"$":0,"Item":"f2571ac9-37ec-4d7c-9ead-9e5f79ae1be1"},{"$":0,"Item":"e7094a13-7915-4e4a-9eac-b2a225e34a94"}],"companions":[],"id":{"$":0,"Item":"081bac32-e739-4124-87eb-eb7d6f2220bc"}},{"indents":{"$":1},"order":42,"name":"testDoc (UI.Next)","content":"let inline testDoc doc  = doc  :> Doc |> Doc.RunById testNodeId","parent":{"$":0,"Item":"e2ca8cb1-fb1e-4793-855f-55e3ca07b8f5"},"predecessors":[{"$":0,"Item":"f2571ac9-37ec-4d7c-9ead-9e5f79ae1be1"},{"$":0,"Item":"aba6c516-0ac9-4abe-95a2-7257d077e338"},{"$":0,"Item":"bcd0b4ef-b3c3-4fc7-93e9-afb8981420aa"},{"$":0,"Item":"6ccdcf8b-134a-4689-9785-5bdcb20a8c92"}],"companions":[],"id":{"$":0,"Item":"c110a9c9-bc3b-4be7-8e5d-f43cc75f93ed"}},{"indents":{"$":1},"order":48,"name":"testHtmlNode (CIPHER)","content":"let inline testHtmlNode node = node |> renderDoc |> testDoc ","parent":{"$":0,"Item":"e2ca8cb1-fb1e-4793-855f-55e3ca07b8f5"},"predecessors":[{"$":0,"Item":"02d3bc50-4aa0-41ce-a37e-5b90a943481f"},{"$":0,"Item":"c110a9c9-bc3b-4be7-8e5d-f43cc75f93ed"}],"companions":[],"id":{"$":0,"Item":"3038cd62-093c-4385-aa9b-799297bd379c"}},{"indents":{"$":1},"order":49,"name":"testResult","content":"let inline testResult   res  = \n    div [ ``class`` \"container\"\n          Template.Panel.New\n            .Title(\"Result:\")\n            .Header([])\n            .Content([ h3 [ htmlText <| sprintf \"%A\" res ; style \"font-family:monospace;\"] ])\n            .Render\n     ] |> testHtmlNode\n","parent":{"$":0,"Item":"e2ca8cb1-fb1e-4793-855f-55e3ca07b8f5"},"predecessors":[{"$":0,"Item":"3038cd62-093c-4385-aa9b-799297bd379c"},{"$":0,"Item":"081bac32-e739-4124-87eb-eb7d6f2220bc"},{"$":0,"Item":"8fb54777-3046-4aae-9282-33401a45c280"},{"$":0,"Item":"0a11766b-f227-4b38-88a3-919d964387bf"}],"companions":[],"id":{"$":0,"Item":"c47adc01-4550-4830-8df5-e1ebedaee7d0"}},{"indents":{"$":1},"order":50,"name":"","content":"[1..10] |> Seq.splitInto 8 |> Seq.toArray\n|> testResult","parent":{"$":0,"Item":"e2ca8cb1-fb1e-4793-855f-55e3ca07b8f5"},"predecessors":[{"$":0,"Item":"c47adc01-4550-4830-8df5-e1ebedaee7d0"}],"companions":[],"id":{"$":0,"Item":"74b8570e-dcd4-4dff-87a5-cd7ec96b8527"}},{"indents":{"$":1},"order":63,"name":"Template.Button.Demo","content":"do Template.Button.Demo.Render \n|> testHtmlNode","parent":{"$":0,"Item":"e2ca8cb1-fb1e-4793-855f-55e3ca07b8f5"},"predecessors":[{"$":0,"Item":"3038cd62-093c-4385-aa9b-799297bd379c"},{"$":0,"Item":"5e1dd5fc-a27c-4b0d-821a-06cc8a27bb82"}],"companions":[],"id":{"$":0,"Item":"0a1fa320-b731-473a-93e2-dae49cc296f7"}},{"indents":{"$":1},"order":61,"name":"Template.Input.Demo","content":"let inp = Template.Input.Demo\n\nlet inline h1 ch = htmlElement \"h1\" ch\n\ndiv [\n  inp.Render\n  htmlText inp.Var\n  htmlElement \"h1\" [ htmlText inp.Var ]\n  h1 [ htmlText inp.Var ]\n]\n|> testHtmlNode","parent":{"$":0,"Item":"e2ca8cb1-fb1e-4793-855f-55e3ca07b8f5"},"predecessors":[{"$":0,"Item":"29c4d6ae-2bb7-457a-ba64-fcb7cce96a30"},{"$":0,"Item":"3038cd62-093c-4385-aa9b-799297bd379c"}],"companions":[],"id":{"$":0,"Item":"f3a7ead2-49e1-4ff4-b96e-6fe699a1c8a9"}}]