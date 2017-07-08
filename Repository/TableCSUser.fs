namespace CIPHERPrototype

open System
open System.IO
open FSharp.Data
open FSharp.Data.SqlClient
open Rop
open Rop.Result
open Model

type RepositoryError =
    | ErrUserIsNotDefined            of string
    | ErrUserIsNotAssociatedToClient of User
    | ErrParameterMissing            of string
    | ErrValueIsNull                 of string * string
    | ErrClientNotFound              of Client
    | ErrRecordWasNotUpdated         of string
    | ExceptionThrown                of exn
    interface ErrMsg with
        member this.ErrMsg   : string = sprintf "%A" this
        member this.IsWarning: bool   = false

type Settings = FSharp.Configuration.AppSettings< "web.config">

module TableCSUser =
    
    [<Literal>]
    //let designCS = """Data Source=192.168.195.26;Initial Catalog=CIPHERSpaceDB;User ID=CIPHERSpaceUser;Password=cipher"""
    let designCS = """Data Source=192.168.5.4;Initial Catalog=CIPHERSpaceDB;User ID=sa;Password=memc52"""
    //let actualCS = Settings.ConnectionStrings.CipherSpaceDb
    let actualCS = designCS
    
    type private SqlUserCode = SqlCommandProvider<"DECLARE @email varchar(max)
                                                   SET     @email = @userEMail
                                                   SELECT user_code FROM CS.[User] WHERE user_email = @email AND @email <> ''", designCS, SingleRow = true>
    let private getUserFromEMail email =
        Result.result {
            do!  Result.tryProtection()
            use  cmd      = new SqlUserCode(actualCS)
            let  record   = cmd.Execute(email)
            let! userCode = record |> Result.fromOption (ErrUserIsNotDefined email)
            return          User userCode
        }
    
    type private SqlUser = SqlCommandProvider<"SELECT * FROM CS.[User] WHERE user_code = @userCode", designCS, SingleRow = true>
    let  private getSqlUserRecordR (user: User) =
        Result.result {
            do!  Result.tryProtection()
            use  cmd     = new SqlUser(actualCS)
            let  record  = cmd.Execute(user.userCode)
            return!        record |> Result.fromOption (ErrUserIsNotDefined (user.userCode.ToString()))
        }
    
    type User with
        member private this.UserRecordR     (dc:DataCache) = dc.getR this (function () -> getSqlUserRecordR this)
        member         this.PasswordRO       dc        = this.UserRecordR dc |> Result.map(fun record -> record.user_password)
        member         this.EmailR           dc        = this.UserRecordR dc |> Result.map(fun record -> record.user_email)
        member         this.LanguageRO       dc        = this.UserRecordR dc |> Result.map(fun record -> record.language_code |> Option.map Language)
        member         this.NameRO           dc        = this.UserRecordR dc |> Result.map(fun record -> record.user_name )
        member         this.NameO            dc        = this.NameRO      dc |> Result.ifError  None
        member         this.Name             dc        = this.NameO       dc |> Option.defaultValue "----"
        member         this.Language         dc        = this.LanguageRO  dc |> Result.ifError  None |> Option.defaultValue Language.defaultL
        member         this.Errors           dc        = this.UserRecordR dc |> Result.getMsgs
        member         this.ThemeTagsR       dc        = this.UserRecordR dc |> Result.map(fun record -> record.theme_tags |> Option.defaultValue "")
        static member GetUserFromEMailR email = getUserFromEMail email
    
    let passPhrase = "getSqlUserRecordR"
    
    type private SqlSetPassword = SqlCommandProvider<"
        DECLARE @pwd     varchar(max)
        DECLARE @phrase  nvarchar(max)
        DECLARE @authen  nvarchar(max)
        SET @pwd    = @password
        SET @phrase = @passPhrase
        UPDATE CS.[User] 
        SET user_password = EncryptByPassPhrase(@phrase, @pwd, 1, CONVERT(VARCHAR(MAX), user_code))
        WHERE user_code = @userCode", designCS, SingleRow = true>
    let  private setSqlPassword (user: User) pwd =
        Result.result {
            do!  Result.tryProtection()
            use  cmd     = new SqlSetPassword(actualCS)
            let  pwd     = Auth.getPwdHash pwd
            let  pwdJson = Auth.passwordToJsonStr pwd
            let  record  = cmd.Execute(pwdJson, passPhrase, user.userCode)
            do!  record  = 1 |> Result.failIfFalse (ErrRecordWasNotUpdated "setSqlUserPassword")
        }
    
    type private SqlCheckPassword = SqlCommandProvider<"
        DECLARE @phrase  nvarchar(max)
        DECLARE @authen  nvarchar(max)
        SET @phrase = @passPhrase
        SELECT password = CONVERT(VARCHAR(max), DecryptByPassPhrase(@phrase, user_password, 1, CONVERT(VARCHAR(MAX), user_code)))
        FROM CS.[User] 
        WHERE user_code = @userCode", designCS, SingleRow = true>
    let  private sqlCheckPassword (user: User) pwd =
        Result.result {
            do!  Result.tryProtection()
            let  pwdRO     = user.PasswordRO (DataCache())
            if match pwdRO with | Success(None, []) -> true | _ -> false
            then return true, false else
            use  cmd      = new SqlCheckPassword(actualCS)
            let  result   = cmd.Execute(passPhrase, user.userCode)
            let  jsonPwd  = result |> Option.defaultValue None
            let  password = match jsonPwd with 
                                | None       -> Auth.getPwdHash "impossibleToMatch"
                                | Some jsonP -> Auth.jsonStrToPassword jsonP
            return Auth.checkPwd password pwd, Auth.checkSettings password
        }
    
    type User with
        member         this.SetPasswordR     dc pwd    = setSqlPassword   this pwd
        member         this.CheckPasswordR      pwd    = sqlCheckPassword this pwd
    

(*

#I @"D:\Abe\CIPHERWorkspace\CIPHERPrototype\Repository\bin\Debug\"
#r "Repository.dll"
open CIPHERPrototype.Repository
open Rop

let user = User.GetUserFromEMailR "amieres@gmail.com" |> Result.getOption |> Option.get
let dc = DataCache<ReplicatorError>()
user.Name dc
user.Language dc

*)