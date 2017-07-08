
#r @"D:\Abe\CIPHERWorkspace\CIPHERPrototype\ZafirTranspiler\bin\Debug\Common.dll"
#r @"D:\Abe\CIPHERWorkspace\CIPHERPrototype\ZafirTranspiler\bin\Debug\ZafirTranspiler.dll"
open CIPHERPrototype.Transpiler

Transpiler("""
namespace Test
#if INTERACTIVE
#r @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.1\System.Web.dll"
#r @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.1\System.Core.dll"
#r @"D:\Abe\CIPHERWorkspace\CIPHERPrototype\WebServer\bin\WebSharper.Core.dll"
#r @"D:\Abe\CIPHERWorkspace\CIPHERPrototype\WebServer\bin\WebSharper.Collections.dll"
#r @"D:\Abe\CIPHERWorkspace\CIPHERPrototype\WebServer\bin\WebSharper.Sitelets.dll"
#r @"D:\Abe\CIPHERWorkspace\CIPHERPrototype\WebServer\bin\WebSharper.Main.dll"
#r @"D:\Abe\CIPHERWorkspace\CIPHERPrototype\WebServer\bin\WebSharper.Web.dll"
#r @"D:\Abe\CIPHERWorkspace\CIPHERPrototype\WebServer\bin\WebSharper.UI.Next.dll"
#r @"D:\Abe\CIPHERWorkspace\CIPHERPrototype\WebServer\bin\WebSharper.JavaScript.dll"

#r @"D:\Abe\CIPHERWorkspace\CIPHERPrototype\WebServer\bin\Common.dll"
#r @"D:\Abe\CIPHERWorkspace\CIPHERPrototype\WebServer\bin\CIPHERHtml.dll"
#r @"D:\Abe\CIPHERWorkspace\CIPHERPrototype\WebServer\bin\Auth.dll"
#r @"D:\Abe\CIPHERWorkspace\CIPHERPrototype\WebServer\bin\Remote.dll"

#endif

open WebSharper
open WebSharper.UI.Next
open WebSharper.UI.Next.Client
open WebSharper.JavaScript
open CIPHERPrototype.Val

[<JavaScript>]
module html =

    type on   = WebSharper.UI.Next.Html.on
    type attr = WebSharper.UI.Next.Html.attr

    [<NoComparison ; NoEquality>]
    type InputTemplate = {
        _type       : Val<string>
        _class      : Val<string>
        placeholder : Val<string>
        var         : Var<string>
        button      : HtmlNode
        content     : HtmlNode
        buttonAdded : bool
    } with
      static member  New(var) = { _class      = fixit "form-control" 
                                  _type       = fixit "text" 
                                  placeholder = fixit "Enter text:"
                                  content     = br []
                                  button      = HtmlEmpty
                                  buttonAdded = false
                                  var         = var   
                                }
      member        this.Render    =         
        div [
              div 
                [ ``class`` (if this.buttonAdded then "input-group" else "")
                  Doc.Input [ _type        this._type
                              _class       this._class
                              _placeholder this.placeholder ]
                              this.var
                     :> Doc |> SomeDoc
                  span     [ ``class`` "input-group-btn"
                             this.button       ]
                ]
              this.content
            ]
      member inline this.AddClass    clas = { this with _class      = map2 addClass this._class (fixit clas) }
      member inline this.Class       clas = { this with _class      = fixit clas                             }
      member inline this.Type        typ  = { this with _type       = fixit typ                              }
      member inline this.Placeholder plc  = { this with placeholder = fixit plc                              }
      member inline this.Content     c    = { this with content     =       c                                }
      member inline this.Button      b    = { this with button      =       b    ; buttonAdded = true        }
      member inline this.SetVar      v    = { this with var         = v                                      }
      member inline this.Var              = this.var

    [<NoComparison ; NoEquality>]
    type ButtonTemplate = {
        _type   : Val<string>
        _class  : Val<string>
        text    : Val<string>
        onClick : unit -> unit
    } with
      static member  New   = { _class  = fixit "btn" 
                               _type   = fixit "button" 
                               text    = fixit "Button"
                               onClick = fun () -> ()
                             }
      member        this.Render     =         
        button [ ``type``  <| this._type
                 ``class`` <| this._class
                 SomeAttr  <| on.click <@ fun _ _ -> this.onClick() @>
                 HtmlText  <| this.text 
               ]
      member inline this.AddClass    clas = { this with _class  = map2 addClass    this._class (fixit clas) }
      member inline this.RemoveClass clas = { this with _class  = map2 removeClass this._class (fixit clas) }
      member inline this.Class       clas = { this with _class  = fixit clas                                }
      member inline this.Type        typ  = { this with _type   = fixit typ                                 }
      member inline this.Text        txt  = { this with text    = fixit txt                                 }
      member inline this.OnClick     f    = { this with onClick = f                                         }

    let container content = div <| [ ``class`` "container" ] @ content

    [<NoComparison ; NoEquality>]
    type TableTemplate = {
        header : HtmlNode
        items  : HtmlNode
        _class : Val<string>
        _style : Val<string>
    } with
      static member  New   = { header = thead [      th [ htmlText "Items" ]]
                               items  = tbody [ tr [ td [ htmlText "Item1" ]]
                                                tr [ td [ htmlText "Item2" ]]
                                              ]
                               _class = fixit "table table-striped table-hover table-condensed" 
                               _style = fixit ""
                             }
      member        this.Render          =         
        table [ ``class`` this._class 
                style     this._style
                this.header
                this.items 
              ] 
      member inline this.AddClass    clas  = { this with _class = map2 addClass this._class (fixit clas)               }
      member inline this.RemoveClass clas  = { this with _class = map2 removeClass this._class (fixit clas)            }
      member inline this.Class       clas  = { this with _class = fixit clas                                           }
      member inline this.Style       sty   = { this with _style = fixit sty                                            }
      member inline this.Header      heads = { this with header = thead <| Seq.map (fun h -> th [ h          ] ) heads }
      member inline this.Header      heads = { this with header = thead <| Seq.map (fun h -> th [ htmlText h ] ) heads }
      member inline this.Header      head  = { this with header = head                                                 }
      member inline this.Items       item  = { this with items  = item                                                 }
      member inline this.Items       heads = { this with items  = tbody <| Seq.map (fun r -> tr [ r          ] ) heads }
      member inline this.Items       heads = { this with items  = tbody <| Seq.map (fun r -> tr [ htmlText r ] ) heads }

    [<NoComparison ; NoEquality>]
    type PanelTemplate = {
        _class   : Val<string>
        _style   : Val<string>
        title    : Val<string>
        header   : HtmlNode seq
        content  : HtmlNode seq
        disabled : Var<bool>
    } with
      static member  New   = { _class   = fixit <| "panel panel-default shadow"
                               _style   = fixit <| "text-align:center" 
                               title    = fixit <| "Panel"        
                               header   =          [ htmlText "Some text"    ] 
                               content  =          [ htmlText "Some Content" ] 
                               disabled =          Var.Create false
                             }
      member        this.Render          =  
        fieldset [ SomeAttr <| attr.disabledDynPred (View.Const "")  (toView this.disabled)
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
      member inline this.AddClass    clas = { this with _class   = map2 addClass    this._class (fixit clas) }
      member inline this.RemoveClass clas = { this with _class   = map2 removeClass this._class (fixit clas) }
      member inline this.Class       clas = { this with _class   = fixit clas                                }
      member inline this.Style       sty  = { this with _style   = fixit sty                                 }
      member inline this.Title       txt  = { this with title    = fixit txt                                 }
      member inline this.Header      h    = { this with header   =       h                                   }
      member inline this.Content     c    = { this with content  =       c                                   }
      member inline this.Disabled    dis  = { this with disabled =       dis                                 }

    let inline loginPane attrDisabled logo htmlMessage varEmail varPassword clickSubmit clickGuest =
        form [ ``class``                   "row"
               div [ ``class``             "col-xs-10 col-xs-offset-1 col-md-6 col-md-offset-3"
                     div [ ``class``       "panel panel-default shadow"                        
                           div [ ``class`` "panel-body"    
                                 style     "text-align:center"   
                                 fieldset [ SomeAttr <| attr.disabledDynPred (View.Const "")  (toView attrDisabled)
                                            logo
                                            InputTemplate.New(varEmail   ).Type("email"   ).Placeholder("Email address...").Render
                                            InputTemplate.New(varPassword).Type("password").Placeholder("Password..."     ).Render
                                            ButtonTemplate.New.AddClass("btn-info btn-block").Text("Login").OnClick(clickSubmit).Render
                                            div [ ``class``         "flex-row"   
                                                  div [ ``class`` "flexgrow"                 ; hr [               ] ]
                                                  div [ ``class`` "flexgrow-1-5 text-center" ; h5 [ htmlText "or" ] ]
                                                  div [ ``class`` "flexgrow"                 ; hr [               ] ]
                                                ]
                                            ButtonTemplate.New.AddClass("btn-primary btn-block").Text("Enter as Guest").OnClick(clickGuest).Render
                                            br []
                                            htmlMessage
                                          ]
                               ]
                         ]
                   ]
             ]

    let inline blurred backImage content =
        div [
                div [ ``class`` <| "blur"
                      style     <| map (sprintf @"position:absolute; top:0Px; left:0Px; bottom:0Px; right:0Px; 
                                                  background-image: url('%s');
                                                  background-size:cover;
                                                  background-position:center;
                                                  z-index:-1") backImage 
                    ]
                content
            ]

    let inline loginFormCipher varEmail varPassword htmlMessage attrDisabled clickSubmit clickGuest =
        div [ style                   "position:relative; height:100ch"
              blurred                 "/EPFileX/image/BI_CONSULTANCY.jpg"
              <| container [
                      div [ ``class`` "row"        
                            style     "height:25ch" 
                          ]
                      loginPane attrDisabled (img [ src "/EPFileX/image/LOGO_cipher2.png" ; width "200px" ]) htmlMessage varEmail varPassword clickSubmit clickGuest
                 ]
            ]

    let inline alert msg = div [ ``class`` "alert alert-danger"        ; htmlText msg ]
    let        hourGlass = img [ src       "/EPFileX/image/loader.gif"                ]


[<JavaScript>]
module TestForm =
    open Rop
    open html

    let showLogin goLink =
        let email       = Var.Create ""
        let pwd         = Var.Create ""
        let msg         = Var.Create ""
        let processing  = Var.Create false
        let viewMessage = map2 (fun p m -> if p
                                           then hourGlass
                                           else if m = "" 
                                           then HtmlEmpty 
                                           else alert m
                                           |> renderDoc) 
                                processing msg
                          |> toDoc
        let processAction action () = 
            Wrap.wrapper  {
                msg.Value                <- ""
                processing.Value         <- true
                let! _                   =  action() |> Wrap.WAsyncR
                JS.Window.Location.Href  <- goLink
            } |> Wrap.getResult (fun r -> processing.Value <- false
                                          r |> Result.withError (fun ms -> msg.Value <- ms.Head.ErrMsg))

        loginFormCipher
            email
            pwd
            (SomeDoc viewMessage)
            processing
            (processAction (fun () -> CIPHERPrototype.RemoteLogin.LoginAR_ email.Value pwd.Value))
            (processAction            CIPHERPrototype.RemoteLogin.guestLoginAR_                  )
        |> renderDoc
        
    [<NoComparison>]
    type Activity = { 
        activity : string
        pending  : Var<bool>
      }
      with
      member this.IsPending = this.pending.Value

    type ShowActivities = 
        | All
        | Pending
        | Finished
        
    let showToDo () =
        let newActivity = Var.Create ""
        let filter      = Var.Create All

        let activities = 
            ListModel.Create (fun {activity = act} -> act)
                [
                  { activity = "hello there"  ; pending = Var.Create true  }
                  { activity = "how are you"  ; pending = Var.Create false }
                  { activity = "hello there1" ; pending = Var.Create true  }
                  { activity = "hello there2" ; pending = Var.Create true  }
                  { activity = "hello there3" ; pending = Var.Create true  }
                  { activity = "hello there4" ; pending = Var.Create true  }
                  { activity = "hello there6" ; pending = Var.Create true  }
                  { activity = "hello there8" ; pending = Var.Create true  }
                  { activity = "hello there9" ; pending = Var.Create true  }
                  { activity = "hello there0" ; pending = Var.Create true  }
                  { activity = "hello therea" ; pending = Var.Create true  }
                  { activity = "hello thereb" ; pending = Var.Create true  }
                  { activity = "hello therec" ; pending = Var.Create true  }
                  { activity = "hello thered" ; pending = Var.Create true  }
                  { activity = "hello theree" ; pending = Var.Create true  }
                  { activity = "hello theref" ; pending = Var.Create true  }
                  { activity = "hello thereg" ; pending = Var.Create true  }
                ]

        let inline activity { activity = text ; pending = pending } =
            tr[ td [ style    <| map (fun pen -> if pen then "" else "text-decoration: line-through") pending 
                     SomeAttr <| on.click <@ fun _ _ -> pending.Value <- not pending.Value @>
                     div [ ``class`` "input-group"
                           span [ ``class`` "input-group-addon"
                                  InputTemplate.New(Var.Create "").Type("checkbox").Class("").Content(HtmlEmpty).Render
                                ]
                           label [ ``class`` "form-control"    ; htmlText text ]
                           span  [ ``class`` "input-group-btn"
                                   ButtonTemplate.New
                                      .Text("Remove")
                                      .AddClass("pull-right")
                                      .OnClick(fun () -> fixit text |> map activities.RemoveByKey |> ignore).Render
                                 ]
                         ]
                   ]
              ]

        let acts = 
            activities.View 
            |> Doc.BindSeqCachedBy (fun act -> act.activity ) (
                fun act ->
                    map2 (fun f _ ->
                            if f = All || (f = Pending)  = act.IsPending
                                then activity act 
                                else HtmlEmpty
                            |> renderDoc
                    ) filter act.pending
                    |> toDoc
            )

        let filterButton v = 
            ButtonTemplate.New
                .Text(sprintf "%A" v)
                .AddClass(map (fun f -> if f = v then "btn-primary" else "") filter)
                .OnClick(fun () -> filter.Value <- v).Render

        let activityList  =
            [
              InputTemplate
                  .New(newActivity)
                  .Placeholder("Enter new activity:")
                  .Button(
                      ButtonTemplate.New
                        .Text("Add activity")
                        .AddClass(map (fun newAct -> if newAct            =  "" then "disabled" else "") newActivity                          )
                        .OnClick(      fun ()     -> if newActivity.Value <> "" then activities.Append { activity = newActivity.Value.Trim()
                                                                                                         pending = Var.Create true           } 
                                                                                     newActivity.Value <- ""                                  )
                        .Render
                  )
                  .Render
              TableTemplate.New
                .Header(["Activity"]   )
                .Items( tbody [ SomeDoc acts ] )
                .Style("width: 100%")
                .Class("")
                .Render
            ] 

        container [ PanelTemplate.New
                      .Title("To Dos")
                      .Style("")
                      .Header([div [ ``class``  "btn-group pull-right"
                                     filterButton All     
                                     filterButton Pending 
                                     filterButton Finished
                                   ]])
                      .Content(activityList)
                      .Render
                  ]
        |> renderDoc

    do (JS.Document.GetElementById "TestResult").InnerHTML <- 
         @"<script src='http://code.jquery.com/jquery-3.1.1.min.js' type='text/javascript' charset='UTF-8'></script>
           <script src='http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js' type='text/javascript' charset='UTF-8'></script>
           <link type='text/css' rel='stylesheet' href='http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css'>
           <link type='text/css' rel='stylesheet' href='/EPFileX/css/main.css'>
          "
    do showToDo  ()  |> Doc.RunById "TestResult"
    do showLogin "#" |> Doc.RunById "TestResult"


    """).GetJS(false, fun js -> printfn "%s" js)
System.Console.WriteLine "wait for iiiiiiittt! ... then press <Enter> to finish"
System.Console.ReadLine() |> ignore