module CIPHERPrototype.TableCSClientParameter

open Rop
open Model
open FSharp.Data
open FSharp.Data.SqlClient
open TableCSUser

type private SqlClientParameters = SqlCommandProvider<"SELECT parameter_code, parameter_value FROM CS.Client_Parameter WHERE Client_Code = @ClientCode", designCS>
let private getClientParametersR (client: Client) = 
    Result.result {
        do! Result.tryProtection()
        use  cmd  = new SqlClientParameters(actualCS)
        let records = cmd.Execute(client.clientCode)
        return records |> Seq.toArray
    }

type KClientParameters = KClientParameters of Client

type Client with
    member private this.parametersR_ (dc:DataCache) = dc.getR (KClientParameters this) (fun () -> getClientParametersR this)
    member         this.parameterR_   dc parm       = Result.result { 
                                                            let! parameters = this.parametersR_ dc
                                                            let  parameterO = parameters |> Array.tryFind (fun record -> record.parameter_code = parm)
                                                            let! parameter  = parameterO |> Result.fromOption (ErrParameterMissing parm)
                                                            let! value      = parameter.parameter_value |> Result.fromOption (ErrValueIsNull ("parameter_value", parm))
                                                            return value
                                                        }
//    member         this.designerConnStrR_ dc        = this.parameterR_ dc EnumClientParameter.``Designer Connection String``



