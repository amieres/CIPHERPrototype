namespace CIPHERPrototype

open Rop
open WebSharper
open WebSharper.JavaScript
open WebSharper.UI.Next
open WebSharper.UI.Next.Client
open WebSharper.UI.Next.Html
open WebSharper.UI.Next.Templating

type MyPage = Template<"MyPage.html">

[<JavaScript>]
module LoginUINext =

    let showForm goLink =
        let loader     = CIPHERHtml.BootstrapLoad()
        let email      = Var.Create ""
        let pwd        = Var.Create ""
        let msg        = Var.Create ""
        let processing = Var.Create false
        let viewMessage = View.Map2 (fun p m -> if p
                                                then MyPage.HourGlass().Doc()
                                                else if m = "" 
                                                then Doc.Empty 
                                                else MyPage.Alert().Text(msg.View).Doc())
                              processing.View msg.View
                          |> Doc.EmbedView
        let processAction action () = 
            Wrap.wrapper  {
                msg.Value        <- ""
                processing.Value <- true
                let! token       =  action() |> Wrap.WAsyncR
                JS.Window.Location.Href  <- goLink
            } |> Wrap.getResult (fun r -> processing.Value <- false
                                          r |> Result.withError (fun ms -> msg.Value <- ms.Head.ErrMsg))

        MyPage.LoginFormCipher()
            .varEmail(email)
            .varPassword(pwd)
            .htmlMessage(viewMessage)
            .attrDisabled(attr.disabledDynPred (View.Const "disabled") processing.View)
            .clickSubmit(processAction (fun () -> RemoteLogin.LoginAR_ email.Value pwd.Value))
            .clickGuest( processAction            RemoteLogin.guestLoginAR_                  )
            .Doc()
