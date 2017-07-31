module CIPHERPrototype.Messaging

open System
open System.Net
open System.Text
open System.IO
open WebSharper
open WebSharper.Remoting
open WebSharper.JavaScript

type AddressId = AddressId of string

type Request = {
    toId              : AddressId
    fromId            : AddressId
    content           : string
    mutable messageId : Guid option
}

type MBMessage =
| Listener of AddressId * (Request->unit) * (exn->unit) * (OperationCanceledException->unit)
| Request  of Request   * (string ->unit) * (exn->unit) * (OperationCanceledException->unit)
| Reply    of Guid      *  string

type POMessage =
| POEcho   of string
| POListeners
| POPendingRequests
| POPendingReplys

type POResponse =
| POString  of string
| POStrings of string[]

type PostOffice() =
    let mutable listeners = [| |]
    let mutable requests  = [| |]
    let mutable sent      = [| |]
    let agent = MailboxProcessor.Start(fun mail ->
        async {
            while true do
                let! mbMsg = mail.Receive()
                match mbMsg with
                | Listener                    (listener, lfs, lfe, lfc)  ->
                    requests
                    |> Array.indexed
                    |> Array.tryPick (fun (i, (request , rfs, rfe, rfc)) -> 
                        if request.toId <> listener then None else
                        requests <- Array.append requests .[0..i-1]  requests .[i+1..requests .Length - 1]
                        Some(lfs, request, rfs))
                    |> (fun v -> (if v.IsNone then 
                                    listeners <- 
                                        listeners 
                                        |> Array.filter(fun (lnr, _, exn, cen) -> 
                                            if lnr = listener then
                                                exn <| TimeoutException()
                                                false
                                            else true) 
                                        |> Array.append [| listener, lfs, lfe, lfc |]); v)
                | Request                     (request , rfs, rfe, rfc)  ->
                    listeners
                    |> Array.indexed
                    |> Array.tryPick (fun (i, (listener, lfs, lfe, lfc)) -> 
                        if request.toId <> listener then None else 
                        listeners <- Array.append listeners.[0..i-1] listeners.[i+1..listeners.Length - 1]
                        Some(lfs, request, rfs))
                    |> (fun v -> (if v.IsNone then requests  <- requests  |> Array.append [| request , rfs, rfe, rfc |]); v)
                | Reply                       (reply   , response)  ->
                    sent
                    |> Array.indexed
                    |> Array.pick (fun (i, (request , rfs)) -> 
                        if request.messageId.Value <> reply then None else
                        sent      <- Array.append sent     .[0..i-1] sent     .[i+1..sent     .Length - 1]
                        rfs response
                        Some ())
                    None
                |> Option.iter (fun (lfs, request, rfs) -> 
                    request.messageId <- Some <| Guid.NewGuid()
                    sent <- sent |> Array.append [| request, rfs |]
                    lfs request
                )
        }
    )
    with
        member this.AwaitRequest    listener  fs fe fc = agent.Post <| Listener (listener, fs, fe, fc)
        member this.SendRequest     request   fs fe fc = agent.Post <| Request  (request , fs, fe, fc)
        member this.ReplyTo         request   response = agent.Post <| Reply    (request , response  )
        member this.Listeners       ()                 = listeners |> Array.map (function | AddressId id, _, _, _ -> id)
        member this.Requests        ()                 = requests  |> Array.map (sprintf "%A")
        member this.Sent            ()                 = sent      |> Array.map (sprintf "%A")

let postOffice = PostOffice()

[<Rpc>]
let awaitRequestFor (listener:AddressId) =
    let startAsync (fs, fe, fc) = postOffice.AwaitRequest listener fs fe fc
    Async.FromContinuations startAsync

[<Rpc>]
let replyTo    (reply:Guid) response =
    async {
        postOffice.ReplyTo reply response
    }

open FSharp.Data
open FSharp.Data.JsonExtensions

[<Rpc>]
let sendRequest  toId fromId content =
    if toId = AddressId "WebServer:PostOffice" then
        async {
            let msg = Json.Deserialize<POMessage> content
            return
                match msg with
                | POListeners       -> POStrings <| postOffice.Listeners()
                | POPendingRequests -> POStrings <| postOffice.Requests ()
                | POPendingReplys   -> POStrings <| postOffice.Sent     ()
                | POEcho        txt -> POString     txt
                |> Json.Serialize 
        }
    else
    let startAsync (fs, fe, fc) = postOffice.SendRequest   
                                    { toId      = toId   
                                      fromId    = fromId 
                                      content   = content 
                                      messageId = None }
                                    fs fe fc
    Async.FromContinuations startAsync

let RpcCall (url:string) method (data:string) =
    async {
        let req = WebRequest.Create(url) :?> HttpWebRequest 
        req.ProtocolVersion <- HttpVersion.Version10
        req.Method          <- "POST"
        req.ContentType     <-  "application/json"
        req.Headers.Add("x-websharper-rpc", method            )
        let postBytes = Encoding.ASCII.GetBytes(data)
        req.ContentLength <- int64 postBytes.Length
        let reqStream = req.GetRequestStream() 
        reqStream.Write(postBytes, 0, postBytes.Length);
        reqStream.Close()
        
        // Obtain response and download the resulting page 
        // (The sample contains the first & last name from POST data)
        let resp   = req.GetResponse() 
        use stream = resp.GetResponseStream() 
        use reader = new StreamReader(stream)
        let msg    = reader.ReadToEnd()
        let json   = JsonValue.Parse msg
        return       json.["$DATA"]
    }

let serializeAddressId aId =
    match aId with
    | AddressId v -> sprintf """{"$":0,"$0":"%s"}""" v

let sendRequestRpc (toId: AddressId) (fromId: AddressId) (content: string): Async<string> =
    async {
        let! msg =
            [| serializeAddressId toId ; serializeAddressId fromId ; Json.Serialize content |]
            |> String.concat ", "
            |> sprintf "[%s]"
            |> RpcCall WebSharper.Remoting.EndPoint "Remote:CIPHERPrototype.Messaging.sendRequest:1096816393"
        return msg.AsString()
    }

let awaitRequestForRpc (listener:AddressId) =
    async {
        let! msg =
            [| serializeAddressId listener |]
            |> String.concat ", "
            |> sprintf "[%s]"
            |> RpcCall WebSharper.Remoting.EndPoint "Remote:CIPHERPrototype.Messaging.awaitRequestFor:278590570"
        let  v = msg.["$V"]
        let req    =
            {
                toId      = AddressId <| v?toId  .["$V"].["$0"].AsString()
                fromId    = AddressId <| v?fromId.["$V"].["$0"].AsString()
                content   = v?content                          .AsString()
                messageId = Some <| v?messageId  .["$V"].["$0"].AsGuid  ()
            }
        return req
    }

let replyToRpc (reply:Guid) response =
    async {
        let! msg =
            [| sprintf "\"%s\"" <| reply.ToString() ; Json.Serialize response |]
            |> String.concat ", "
            |> sprintf "[%s]"
            |> RpcCall WebSharper.Remoting.EndPoint "Remote:CIPHERPrototype.Messaging.replyTo:-1092841374"
        return ()
    }

