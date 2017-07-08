module CIPHERPrototype.Model

open System
open Rop



type   User       = User       of Guid         with member   this.userCode      = match this with User      (userCode      ) -> userCode
type   Client     = Client     of Guid         with member   this.clientCode    = match this with Client    (clientCode    ) -> clientCode
type   Language   = Language   of string       with member   this.languageCode  = match this with Language  (languageCode  ) -> languageCode
                                                    static member defaultL = Language "en"

type DataCache() = 
    let mutable dict = Map.empty<System.IComparable, obj>
    let setR_ (key: System.IComparable) (vR: Result<'v>) =
        if dict.ContainsKey key then ()
        else
            dict <- dict.Add(key, vR :> obj)
    let getR_ (key: System.IComparable) (getter: unit -> Result<'v>) : Result<'v> =
        dict.TryFind key
        |> function
            | Some v -> unbox v
            | None   ->
                let vR = getter ()
                dict <- dict.Add(key, box vR)
                vR
    member this.getR key getter = getR_ key getter
    member this.setR key vR     = setR_ key vR
    member this.reset           = dict <- Map.empty<System.IComparable, obj>



