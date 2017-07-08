module CIPHERPrototype.WebServer

open Model
open Rop
open Rop.Result
open WebSharper
open WebSharper.Sitelets
open WebSharper.UI.Next

type WebServerError =
    | ErrUserIsNotLoggedIn
    | ExceptionThrown      of exn
    | ErrOptionIsNone
    interface ErrMsg with
        member this.ErrMsg   : string = sprintf "%A" this
        member this.IsWarning: bool   = false

type EndPoint =
    | [< EndPoint "/" >] EPEntry
    | EPHome
    | EPItem    of name:string
//    | EPContent of ContentPage
    | EPLogout
    | [< Wildcard      >] EPFile       of filename:string
    | [< Wildcard      >] EPJavaScript of filename:string        
    | [< Wildcard      >] EPTest       of wsHtml  :string

type MainTemplate = Templating.Template<"Main.html">

[<JavaScript>]
module Client = 
    open WebSharper.UI.Next
    open WebSharper.UI.Next.Client
    open WebSharper.UI.Next.Html
    open WebSharper.UI.Next.Templating

    type MyPage = Template<"MyPage.html">
    
    let test () =
        let model = Var.Create true
        let view =
          model.View
          |> View.Map (fun x ->
            if x then
              Doc.Concat [
                hr []
                text "ok"
              ]
            else
              Doc.Empty)
          |> Doc.EmbedView
        div [ view ]

    let myDocument () =
        let loader = CIPHERHtml.BootstrapLoad()
        let people =
            ListModel.Create fst [
                "John", 42.
                "Phil", 37.
            ]
    
        let removeText    = Var.Create "delete"
        let freeHtml      = Var.Create "<h1>Hello</h1>"
        let addPersonName = Var.Create ""
        let addPersonAge  = Var.Create 0.

        let viewAddPerson = View.Map2 (fun n a -> (n, a)) addPersonName.View addPersonAge.View
        let viewFreeHtml  = freeHtml.View |> View.Map Doc.Verbatim |> Doc.EmbedView

        MyPage()
            .TableBody(
                people.View |> Doc.BindSeqCachedBy people.Key (fun (name, age) ->
                    MyPage.TableRow3()
                        .txtName(  name                             )
                        .txtAge(   string age                       )
                        .txtBorrar(removeText.View                  )
                        .onRemove( fun () -> people.RemoveByKey name)
                        .Doc()
                )
            )
            .varAddPersonName(   addPersonName                                                   )
            .varAddPersonAge(    addPersonAge                                                    )
            .attrAddPersonSubmit(on.clickView viewAddPerson (fun _ _ person -> people.Add person))
            .varRemoveText(      removeText                                                      )
            .varFreeHtml(        freeHtml                                                        )
            .htmlFreeHtml(       viewFreeHtml                                                    )
            .Doc()

open WebSharper.UI.Next.Server
module Templating =
    open WebSharper.UI.Next.Html

    let topScript = """
        // <![CDATA[
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
                fileRef.onload = function () { fileRef.onload = null; callback(); }
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
                    i++;r
                    CIPHERSpaceLoadFile(file, loadNext);
                }
                else newCallback();
            };
            loadNext();
        }
        // ]]>
    """

    let Main (title: string) (body: Doc) =
        let content = 
            MainTemplate()
                .TopScript(script [Doc.Verbatim topScript])
                .Title(title)
                .Body(body)
                .Doc()
        Content.Page(content)

module Site =
    open WebSharper.UI.Next.Html

//    let mainPage title body : Async<Content<EndPoint>> = Templating.Main title body

    let clientContent title quote = Templating.Main title (client quote)

    let getUserR (ctx: Context<EndPoint>) =
        ctx.UserSession.GetLoggedInUser()
        |> Async.RunSynchronously
        |> Option.map (fun userCodeS -> User (new System.Guid(userCodeS)))
        |> Result.fromOption ErrUserIsNotLoggedIn

    let Main = 
        let site (ctx: Context<EndPoint>) (endpoint: EndPoint) =
            result {
                do! tryProtection()
                let test =
                    match endpoint with 
                    | EPTest html -> TestForm.showForm html |> Content.Page |> Some
                    | _ -> None
                if test.IsSome then return test.Value
                else
                let! user      = getUserR                ctx
                let  dc        = DataCache()
//                let! client    = user.CurrentClientR     dc
//                let  stx       = SessionCtx(ctx, endpoint, user, client, lazy Navigation(ctx, user, dc), dc)
//                let  mainPageL = lazy (getTitle stx |> mainPage)
                return!
                    match endpoint with
//                  | EPFile               filename -> HttpUtility.UrlDecode filename |> produceFile      stx 
//                  | EPJavaScript         filename -> HttpUtility.UrlDecode filename |> javaScriptFile   stx 
//                  | EPItem               item     -> HttpUtility.UrlDecode item     |> itemContentPageR stx  |> Result.map mainPageL.Value
               //   | EPContent            content  -> content                        |> contentPageR     stx  |> Result.map mainPageL.Value
                    | EPEntry            | EPHome   -> div [ text "Hello" ] |> Templating.Main "Home" |> Result.succeed
                    | EPLogout                      -> ctx.UserSession.Logout()       |> Async.RunSynchronously ; Result.fail ErrUserIsNotLoggedIn
            } |> function 
                    | Success (v, _)                -> v
                    | Failure ms                    -> let msg        = if ms = [ErrUserIsNotLoggedIn] then None else Some (sprintf "%A" ms)
                                                       let goHomeLink = ctx.Link EPHome
                                                       clientContent "Login" <@ LoginForm.showForm goHomeLink msg  @>
//                                                       clientContent "Login" <@ Client.myDocument()  @>
//                                                       clientContent "Login" <@ LoginUINext.showForm goHomeLink @>
//                                                       clientContent "Login" <@ TestForm.showLogin goHomeLink @>

        Application.MultiPage site

module SelfHostedServer =

    open global.Owin
    open Microsoft.Owin.Hosting
    open Microsoft.Owin.StaticFiles
    open Microsoft.Owin.FileSystems
    open WebSharper.Owin

    [<EntryPoint>]
    let Main args =
        let rootDirectory, url =
            match args with
            | [| rootDirectory; url |] -> rootDirectory, url
            | [| url                |] -> ".."         , url
            | [|                    |] -> ".."         , "http://localhost:9000/"
            | _ -> eprintfn "Usage: WebServer ROOT_DIRECTORY URL"; exit 1
        use server = 
            WebApp.Start(url, fun appB ->
                appB.UseStaticFiles(StaticFileOptions(FileSystem = PhysicalFileSystem(rootDirectory)))
                    .UseWebSharper(WebSharperOptions(ServerRootDirectory = rootDirectory
                                                   , Sitelet             = Some Site.Main
                                                   , BinDirectory        = "."
                                                   , Debug               = true))
                |> ignore)
        stdout.WriteLine("Serving {0}", url)
        stdin.ReadLine() |> ignore
        0