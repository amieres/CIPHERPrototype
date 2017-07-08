module CIPHERPrototype.TableCSClientUser

open Rop
open Model
open FSharp.Data
open FSharp.Data.SqlClient
open TableCSUser

type private SqlUserClients = SqlCommandProvider<"SELECT *, today = GETDATE()  FROM CS.Client_User WHERE user_code = @userCode ORDER BY current_client desc", designCS>
let  private getSqlUserClientsR (user: User) =
    Result.result {
        do!  Result.tryProtection()
        use  cmd     = new SqlUserClients(actualCS)
        let  records = cmd.Execute(user.userCode)
        return         records |> Seq.toArray
    }

type KUserClients = KUserClients of User

type User with
    member private this.UserClientsRecordR(dc:DataCache) = dc.getR (KUserClients this) (function () -> getSqlUserClientsR this)
    member         this.ClientsR           dc  = this.UserClientsRecordR dc 
                                                |> Result.map (Array.choose (fun record ->
                                                    if record.today < (record.effective_date  |> Option.defaultValue record.today) ||
                                                       record.today > (record.expiration_date |> Option.defaultValue record.today) 
                                                    then None
                                                    else Some (Client record.client_code)))
    member         this.CurrentClientR     dc = this.ClientsR dc
                                                |> Result.bind 
                                                    (fun clients ->
                                                        if clients.Length > 0 
                                                        then Result.succeed clients.[0] 
                                                        else Result.fail (ErrUserIsNotAssociatedToClient this))

