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
    mutable messageId : Guid option
    content           : string
}

type MBMessage =
| Listener of AddressId * (Request->unit) * (exn->unit) * (OperationCanceledException->unit)
| Request  of Request   * (string ->unit) * (exn->unit) * (OperationCanceledException->unit)
| Reply    of Guid      *  string

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
                    |> (fun v -> (if v.IsNone then listeners <- listeners |> Array.append [| listener, lfs, lfe, lfc |]); v)
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

[<Rpc>]
let sendRequest  toId fromId content =
    let startAsync (fs, fe, fc) = postOffice.SendRequest   
                                    { toId      = toId   
                                      fromId    = fromId 
                                      content   = content 
                                      messageId = None }
                                    fs fe fc
    Async.FromContinuations startAsync

type RpcResponse = {
    ``$TYPES`` : string[]
    ``$DATA``  : string
}

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
        let resp = req.GetResponse() 
        let stream = resp.GetResponseStream() 
        let reader = new StreamReader(stream) 
        return 
            reader.ReadToEnd()
            |> Json.Deserialize<RpcResponse>
            |> fun r -> r.``$DATA``
    }



let sendRequestRpc (toId: AddressId) (fromId: AddressId) (content: string): Async<string> =
    let serialize aId =
        match aId with
        | AddressId v -> sprintf """{"$":0,"$0":"%s"}""" v
    async {
        let! res =
            [| serialize toId ; serialize fromId ; Json.Serialize content |]
            |> String.concat ", "
            |> sprintf "[%s]"
            |> RpcCall WebSharper.Remoting.EndPoint "Remote:CIPHERPrototype.Messaging.sendRequest:1096816393"
        return res
    }