namespace CIPHERPrototype

open WebSharper
open WebSharper.JavaScript
open CIPHERHtml

/// creates App object
/// to run        use: app.run container props  
/// to integrate  use: app.node props
/// alternatively integrate into model
/// using: app.init, app.update and app.view
//    let app = App(init, update, view)
[<JavaScript>]
module App =
    type Dummy   = { dummy : bool }
    let DummyNew = { dummy = true } 

    let withContainerDo className f =
        let container = 
            WebSharper.UI.Next.Html.divAttr [ 
                WebSharper.UI.Next.Html.attr.``class`` className
                WebSharper.UI.Next.Client.Attr.OnAfterRender (fun container -> f container)
            ] []
        container

    type MailboxState<'M> = {
                            agent               : MailboxProcessor<'M -> 'M>
                            count               : int
                            mutable latestModel : 'M
                        }
      with
        member this.latest      : 'M  = this.latestModel
        member this.setLatest (l: 'M) = this.latestModel <- l
                                        this.latest?__ref <- this

    let mutable mailboxes = 0

    let mailbox (init:'M) () =
        mailboxes <- mailboxes + 1
        let mail =
            {
              agent       = MailboxProcessor.Start(fun inbox -> 
                                let rec messageLoop oldState : Async<unit> = async {
                                    let! doThis  = inbox.Receive()
                                    let newState = doThis oldState
                                    return! messageLoop newState 
                                }
                                let newInit = JQuery.JQuery.Extend(JS.Object, init :> obj) |> unbox<'M>
                                messageLoop newInit 
                            )
              count       = mailboxes
              latestModel = init
            }
        mail.agent.Post(fun initState -> mail.setLatest initState ; initState)
        mail

    type App<'P, 'M, 'msg> (init:'M, update: ('msg -> unit) -> 'P -> 'msg   -> 'M -> Choice<'M, 'M, bool> , view: 'P -> 'M -> ('msg -> unit) -> CipherNode) =
        let doMsg (mail:MailboxState<'M>) update msg forceUpdate oldState =
            let newState, refresh = 
                match  update (msg:'msg) oldState with
                | Choice1Of3(newState) -> newState, true
                | Choice2Of3(newState) -> newState, false
                | Choice3Of3(a:bool)   -> oldState, false
            mail.setLatest newState
            if refresh then forceUpdate()
            newState

        let rec processMessages_ (props:'P) (mail:MailboxState<'M>) forceUpdate (msg:'msg) =
            let processM = processMessages_ props mail forceUpdate
            mail.agent.Post(doMsg mail (update processM props) msg forceUpdate)

        let renderReact (this:obj) : R =
            //let setState_                       = this?setState    :> FuncWithArgs<obj * obj, obj>
            //let setState  (newStateF: 'M <<== not anymore)       = setState_.ApplyUnsafe (this, [| newStateF |]) |> ignore
            let forceUpdate_                    = this?forceUpdate :> FuncWithArgs<obj * obj, obj>
            let forceUpdate ()                  = forceUpdate_.ApplyUnsafe (this, [| |]) |> ignore
            let mail: MailboxState<'M>          = this?state
            let props                       :'P = this?props
            view props mail.latest (processMessages_ props mail forceUpdate)
            |> toReact
        let reactClass = R.createClass("rootClass", mailbox init, FuncWithOnlyThis(renderReact))

        /// incrementalDom section

        let rec renderIncDom (props:'P) (container:Dom.Element) =
            if isUndefined container?state then
                container?state <- mailbox init ()
            let mail: MailboxState<'M>  = container?state
            let forceUpdate ()          = renderIncDom props container
            let cipherNode = view props mail.latest (processMessages_ props mail forceUpdate)
            patchInner container (fun () -> toIncrementalDom cipherNode |> ignore)

        let renderNodeIncDom (props:'P) =
            let anchor = textIDom ""
            if isUndefined anchor?state then
                anchor?state <- mailbox init ()
            let mail: MailboxState<'M>  = anchor?state
            let rec forceUpdate () = patchOuter mail?element (fun () -> getCipherNode() |> toIncrementalDom |> ignore)
            and getCipherNode()    = view props mail.latest (processMessages_ props mail forceUpdate)
            mail?element <- toIncrementalDom <| getCipherNode()
            mail?element

        member app.init                           = init
        member app.update                         = update
        member app.view                           = view
        member app.nodeR     (props:'P)           = R.E(reactClass,  props)
        member app.nodeIncDom(props:'P)           = renderNodeIncDom props
        member app.node      (props:'P)           = UIApp (app :> IUIApp, props)
        member app.runIncDom (props:'P) container = renderIncDom props container
        member app.runReact  (props:'P) container = ReactDOM.render(app.nodeR props, container)
        member app.run       (props:'P) container = if isUndefined JS.Window?IncrementalDOM 
                                                    then app.runReact  props container
                                                    else app.runIncDom props container 
        new (init:'M, update3: 'P -> 'msg -> 'M -> 'M, view: 'P -> 'M -> ('msg -> unit) -> CipherNode) = App(init, (fun _  props msg model -> update3 props msg model |> Choice1Of3), view)
        new (init:'M, update2:       'msg -> 'M -> 'M, view: 'P -> 'M -> ('msg -> unit) -> CipherNode) = App(init, (fun _  _     msg model -> update2       msg model |> Choice1Of3), view)
        interface IUIApp with 
            member app.nodeR     (props:obj)           = props |> unbox |> app.nodeR
            member app.nodeIncDom(props:obj)           = props |> unbox |> app.nodeIncDom
            member app.run       (props:obj) container = props |> unbox |> app.run <| container

