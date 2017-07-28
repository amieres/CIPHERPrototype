#r @"ZafirTranspiler.dll"
#r @"WebSharper.Core.dll"
#r @"WebSharper.Main.dll"
#r @"WebSharper.JavaScript.dll"
#r @"WebSharper.Web.dll"
#r @"WebSharper.UI.Next.dll"
#r @"WebSharper.Sitelets.dll"
      
//" F# module FSharpStationMD   =.fsx"
#if INTERACTIVE
#I @"../WebServer/bin"
#nowarn "40"
module FSharpStationMD   =
#else
namespace FSharpStationNS
#nowarn "1182"

#endif

//" F# Evaluate F# Code.fsx"
// Code to be evaluated using FSI: `Evaluate F#`
//"(4) F# module Snippets =.fsx"
    module Snippets =
//"(6) F# Form test.fsx"
      open System
      open System.ComponentModel
      open System.Windows.Forms
      
      let label1 = new Label (Text = "", Width = 300)
      let newButton txt =
          let btn = new Button(Text = txt)
          btn.Click.Add (fun args -> label1.Text <- txt)
          btn :> Control
              
      
      let spacing = 5
      let button1 = newButton "Start"
      let button2 = newButton "Start Invalid"
      let button3 = newButton "Cancel"
      
      let updown1 = new System.Windows.Forms.NumericUpDown(Value = 20m,
                                                           Minimum = 0m,
                                                           Maximum = 1000000m)
      
      let progressBar = new ProgressBar(Top = 6 * (button1.Height + spacing),
                                        Width = 300)
      let panel1 = new Panel(Dock = DockStyle.Fill)
      
      [| button1    
         button2    
         button3    
         updown1     :> Control
         label1      :> Control
         progressBar :> Control
      |]
      |> Array.mapi (fun i cts -> cts.Top <- i * 25 ; cts)
      |> panel1.Controls.AddRange
      panel1.DockPadding.All <- 10
      //button1.Click.Add(fun args -> async1 progressBar label1 (int updown1.Value))
      //button2.Click.Add(fun args -> async1 progressBar label1 (int (-updown1.Value)))
      //button3.Click.Add(fun args -> Async.CancelDefaultToken())
      let form = new Form(Text = "Select Actions", Width = 400, Height = 400)
      form.Controls.Add(panel1)
      form.Activated.AddHandler(System.EventHandler (fun _ _ -> form.TopMost <- true(*; form.TopMost <- false*) ))
      async {
        do Application.Run(form) 
      } |> Async.Start
      
      type FSMessage =
      //    | GetSnippetContentById of CodeSnippetId
      //    | GetSnippetCodeById    of CodeSnippetId
      //    | GetSnippetById        of CodeSnippetId
          | GetSnippetContent     of string []
          | GetSnippetCode        of string []
          | GetSnippet            of string []
          | GenericMessage        of string
          | GetIdentification
      
      type FSResponse =
      //    | SnippetResponse   of CodeSnippet option
          | StringResponse    of string option
          | IdResponse        of CIPHERPrototype.Editor.AddressId
      
      open CIPHERPrototype.Editor
      open WebSharper
      open WebSharper.JavaScript
      
      let toId   = AddressId "FSharpStation1"
      let fromId = AddressId "ButtonTest"
      
      WebSharper.Remoting.EndPoint <- "localhost:9000"
      
      button1.Click.Add (fun args ->                                                      
          async {
              let! response = sendRequest toId fromId ("Hello" |> GenericMessage |> Json.Serialize)
              let msg =
                  match response |> Json.Deserialize<FSResponse> with
                  | StringResponse(Some msg) -> msg
                  | _                        -> "<not a valid response>"
              label1.Text <- msg
          } |> Async.Start
      )
      
      
      