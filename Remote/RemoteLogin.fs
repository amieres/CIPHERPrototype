namespace CIPHERPrototype

open WebSharper
open WebSharper.Web.Remoting
open Model
open Rop
open System
open TableCSUser
open TableCSClientUser

 
[< JavaScript >]
type RemoteError =
    | ErrLoginFailed            of string
    interface ErrMsg with
        member this.ErrMsg   : string = match this with |ErrLoginFailed s -> sprintf "Login Failed %s" s
        member this.IsWarning: bool   = false

module RemoteLogin =

    [<Rpc>]
    let LoginAR_ (userEmail: string) (pwd:string) =
        let context = GetContext()
        Wrap.wrapper {
            let! priorUserCodeOS = context.UserSession.GetLoggedInUser()
            let  user            = User.GetUserFromEMailR userEmail |> Result.ifError (User Guid.Empty)
            let  dc              = DataCache()
            let! check, settings = user.CheckPasswordR pwd
            do!                    check |> Result.failIfFalse (ErrLoginFailed userEmail)
            if not settings then
                do!                user.SetPasswordR dc pwd
            let! client          = user.CurrentClientR dc
            context.UserSession.LoginUser (user.userCode.ToString()) |> Async.RunSynchronously
            return Auth.Generate user.userCode
        } |> Wrap.getAsyncR

    [<Rpc>]
    let guestLoginAR_() =
        let context = GetContext()
        Wrap.wrapper {
            let! priorUserCodeO  = context.UserSession.GetLoggedInUser()
            let  user            = User (new Guid("ef047959-15b4-43dc-b131-39646009a706"))
            let  dc              = DataCache()
            let! client          = user.CurrentClientR dc
            context.UserSession.LoginUser (user.userCode.ToString()) |> Async.RunSynchronously
            return user.userCode |> Auth.Generate
        } |> Wrap.getAsyncR


