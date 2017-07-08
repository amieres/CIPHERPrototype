module CIPHERPrototype.Auth

open System
open System.Security
open System.Text
open WebSharper

type PasswordSettings =
    | PasswordV1 of int * int * int * int
    | PasswordV2 of int * int * int * int

type Password = {
    hash: string
    salt: string
    settings: PasswordSettings
}


type Key = class end

let Key = typeof<Key>.GUID.ToString()

[<JavaScript>]
type Token =
    {
        Name: System.Guid
        Hash: string
    }

let private sha1 = Cryptography.SHA1.Create()

let Generate (name: System.Guid) : Token =
    let hash = new StringBuilder()
    sprintf "%s:%s" (name.ToString()) Key
    |> Encoding.Unicode.GetBytes
    |> Cryptography.SHA1.Create().ComputeHash
    |> Array.iter (fun by -> hash.Append(by.ToString("X2")) |> ignore)
    {
        Name = name
        Hash = hash.ToString()
    }

let Validate (token: Token) : bool =
    Generate token.Name = token

let getSaltBytes () =
    use rng       = new System.Security.Cryptography.RNGCryptoServiceProvider()
    let saltBytes = Array.create 16 (new Byte())
    do              rng.GetBytes saltBytes
    saltBytes

let sCrypt (pwd:string) saltBytes cost blockSize paralleln derivedKeyLength =
    let keyBytes = Encoding.UTF8.GetBytes(pwd)
    let maxThreads = System.Nullable<int>()
    let bytes = CryptSharp.Utility.SCrypt.ComputeDerivedKey(keyBytes, saltBytes, cost, blockSize, paralleln, maxThreads, derivedKeyLength)
    Convert.ToBase64String bytes        

let pwdSettings =
    let cost             = 17
    let blockSize        = 8
    let paralleln        = 1
    let derivedKeyLength = 128
    PasswordV2       (cost, blockSize, paralleln, derivedKeyLength)

let calcHash (pwd: string) (salt: string) (settings: PasswordSettings) =
    let saltBytes        = Encoding.UTF8.GetBytes(salt)
    match pwdSettings with
        | PasswordV1         (cost, blockSize, paralleln, derivedKeyLength) ->
            sCrypt pwd saltBytes cost blockSize paralleln derivedKeyLength
        | PasswordV2         (cost, blockSize, paralleln, derivedKeyLength) ->
            let cost             = pown 2 cost
            sCrypt pwd saltBytes cost blockSize paralleln derivedKeyLength 

let getPwdHash (pwd:string) =
    let salt = Convert.ToBase64String  (getSaltBytes ())
    { 
        hash     = calcHash pwd salt pwdSettings
        salt     = salt
        settings = pwdSettings
    }

let checkPwd (password: Password) (pwd: string) =
    let hash2 = calcHash pwd password.salt password.settings
    CryptSharp.Utility.SecureComparison.Equals(hash2, password.hash)
            
let checkSettings (pwd: Password) =
    pwd.settings = pwdSettings

let jsonStrToPassword pwd =
    let  jsonVal      = WebSharper.Core.Json.Parse pwd
    let  jsonProvider = WebSharper.Core.Json.Provider.Create()
    let  decoder      = jsonProvider.GetDecoder<Password>()
    decoder.Decode jsonVal

let passwordToJsonStr pwd =
    let jsonProvider = WebSharper.Core.Json.Provider.Create()
    let encoder      = jsonProvider.GetEncoder<Password>()
    let jsonVal      = jsonProvider.Pack (encoder.Encode pwd)
    WebSharper.Core.Json.Stringify jsonVal
   
