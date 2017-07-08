module CIPHERPrototype.TableCSClient

open Rop
open Model
open FSharp.Data
open FSharp.Data.SqlClient
open TableCSUser

type private SqlClient = SqlCommandProvider<"Select * from CS.Client WHERE client_code = @clientCode", designCS, SingleRow = true>
let private getClientR (client: Client) = 
    Result.result {
        do! Result.tryProtection()
        use  cmd     = new SqlClient(actualCS)
        let  record  = cmd.Execute(client.clientCode)
        let! record  = record |> Result.fromOption (ErrClientNotFound client)
        return record
    }

//type ObjectHierarchy = XmlProvider<"SampleObjectHierarchy.Xml", Global=true>

type Client with
    member private this.ClientRecordR (dc:DataCache) = dc.getR this (fun () -> getClientR this)
    member         this.NameR            dc = this.ClientRecordR dc |> Result.map (fun record -> record.client_name)
    member         this.Name             dc = this.NameR         dc |> Result.ifError (sprintf "%A" (this.NameR dc))
    member         this.IndustryTypeRO   dc = this.ClientRecordR dc |> Result.map (fun record -> record.industry_type)
//    member         this.ObjectHierarchyR dc = 
//        Result.result {
//            let! record = this.ClientRecordR dc
//            let! hier   = record.object_hierarchy |> Result.fromOption (ErrValueIsNull ("object_hierarchy", "CS.Client"))
//            return ObjectHierarchy.Parse hier
//        }


