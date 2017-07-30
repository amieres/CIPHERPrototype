#r "Common.dll"
#r @"D:\Abe\CIPHERWorkspace\Repos\packages\FSharp.Compiler.Service\lib\net45\FSharp.Compiler.Service.dll"
#r @"WebSharper.Core.dll"
#r @"WebSharper.Main.dll"
#r @"WebSharper.Web.dll"
#r @"Common.dll"
#r "remote.dll"
//@" F# FSSGlobal.fsx"
#if INTERACTIVE
#I @"../WebServer/bin"
#nowarn "40"
module FSSGlobal   =
#else
namespace FSSGlobal
#nowarn "1182"

#endif

//@" F# Evaluate F# Code.fsx"
// Code to be evaluated using FSI: `Evaluate F#`
//@"(4) F# FsStationShared.fsx"
#if WEBSHARPER
    [<WebSharper.JavaScript>]
#endif
    module FsStationShared =
//@"(6) F# CodeSnippet.fsx"
      
      open CIPHERPrototype.Messaging
      
      type CodeSnippetId = CodeSnippetId of System.Guid        
      with static member New = CodeSnippetId <| System.Guid.NewGuid()
      
      let snippetName name (content: string) =
          if name <> "" then name else 
          content.Split([| '\n' |], System.StringSplitOptions.RemoveEmptyEntries)
          |> Seq.map    (fun l -> l.Trim())
          |> Seq.filter (fun l -> not (l.StartsWith("#") || l.StartsWith("[<") || l.StartsWith("//")))
          |> Seq.tryHead
          |> Option.defaultValue "<empty>"
      
      let sanitize n =
          let illegal = [|'"'   ; '<'   ; '>'   ; '|'   ; '\000'; '\001'; '\002'; '\003'; '\004'; '\005'; '\006';
                          '\007'; '\b'  ; '\009'; '\010'; '\011'; '\012'; '\013'; '\014'; '\015';
                          '\016'; '\017'; '\018'; '\019'; '\020'; '\021'; '\022'; '\023'; '\024';
                          '\025'; '\026'; '\027'; '\028'; '\029'; '\030'; '\031'; ':'   ; '*'   ; '?';
                          '\\'  ; '/'|] //"
          n |> String.filter (fun c -> not <| Array.contains c illegal)
      
      
      type CodeSnippet = {
          name         : string
          content      : string
          parent       : CodeSnippetId option
          predecessors : CodeSnippetId list
          companions   : CodeSnippetId list
          id           : CodeSnippetId
          expanded     : bool
      } with
          member this.Name = snippetName this.name this.content
      
      
//@"(6) F# type FSMessage =.fsx"
      type FSMessage =
          | GetSnippetContentById of CodeSnippetId
          | GetSnippetCodeById    of CodeSnippetId
          | GetSnippetById        of CodeSnippetId
          | GetSnippetContent     of string []
          | GetSnippetCode        of string []
          | GetSnippet            of string []
          | GenericMessage        of string
          | GetIdentification
      
      type FSResponse =
          | SnippetResponse   of CodeSnippet option
          | StringResponse    of string option
          | IdResponse        of AddressId
      
      
//@"(6) F# FsStationClient.fsx"
      
      open WebSharper
      //open WebSharper.JavaScript
      open WebSharper.Remoting
      open CIPHERPrototype.Messaging
      open Rop
      
      type FsStationClientErr =
          | SnippetNotFound of string
      with interface ErrMsg with
              member this.ErrMsg    = 
                  match this with 
                  | msg                        -> sprintf "%A" msg
              member this.IsWarning = false     
      
      type FsStationClient(clientId, ?endPoint:string, ?fsStationId:string) =
          let fsId       = fsStationId |> Option.defaultValue "FSharpStation-52713eba-3d08-415a-9b0b-dd8ac766dea1"
          let wsEndPoint = endPoint    |> Option.defaultValue "http://localhost:9000/FSharpStation.html"
          let fromId     = AddressId clientId
          let toId       = AddressId fsId
          do WebSharper.Remoting.EndPoint <- wsEndPoint 
          let requestCode (snpName:string) = 
              Wrap.wrapper {
                  let! response = sendRequestRpc toId fromId (snpName.Split '/' |> GetSnippetCode |> Json.Serialize)
                  let! resp =
                      match response |> Json.Deserialize<FSResponse> with
                      | StringResponse (Some code)    -> Result.succeed code
                      | _                             -> Result.fail    (SnippetNotFound response) 
                  return resp
              } 
        with 
          member this.RequestCode(snpPath) = requestCode snpPath
          member this.FSStationId          = fsId
          member this.EndPoint             = wsEndPoint
          static member FSStationId_       = "FSharpStation-52713eba-3d08-415a-9b0b-dd8ac766dea1"
          static member EndPoint_          = "http://localhost:9000/FSharpStation.html"
          
      
      
//@"(6) F# Compile.fsx"
      open Rop
      open Microsoft.FSharp.Compiler.SourceCodeServices
      
      type PreproDirective =
      | PrepoR      of string
      | PrepoDefine of string
      | PrepoLoad   of string
      | PrepoLine   of string //* int
      | PrepoNoWarn of string
      | PrepoOther  of string
      | NoPrepo
      
      let prepareCode (code:string) =
          let  quoted (line:string) = line.Trim().Split([| "\""       |], System.StringSplitOptions.RemoveEmptyEntries) |> Seq.tryLast |> Option.defaultValue line
          let  define (line:string) = line.Trim().Split([| "#define " |], System.StringSplitOptions.RemoveEmptyEntries) |> Seq.tryHead |> Option.defaultValue ""
          let  prepro (line:string) = match true with 
                                      | true when line.StartsWith("#define") -> ("//" + line, line |> define |> PrepoDefine)
                                      | true when line.StartsWith("#r"     ) -> ("//" + line, line |> quoted |> PrepoR     )
                                      | true when line.StartsWith("#load"  ) -> ("//" + line, line |> quoted |> PrepoLoad  )
                                      | true when line.StartsWith("#nowarn") -> ("//" + line, line |> quoted |> PrepoNoWarn)
                                      | true when line.StartsWith("# "     ) -> (       line, line |> quoted |> PrepoLine  )
                                      | true when line.StartsWith("#line"  ) -> (       line, line |> quoted |> PrepoLine  )
                                      | true when line.StartsWith("#"      ) -> (       line, line           |> PrepoOther )
                                      | _                                    -> (       line,                   NoPrepo    ) 
          let  fsNass   = code.Split([| "\r\n"; "\n" ; "\r" |], System.StringSplitOptions.None) |> Seq.map prepro
          let  assembs  = fsNass |> Seq.choose (snd >> (function | PrepoR assemb -> Some assemb | _ -> None)) |> Seq.toArray
          let  defines  = fsNass |> Seq.choose (snd >> (function | PrepoDefine d -> Some d      | _ -> None)) |> Seq.toArray
          let  nowarns  = fsNass |> Seq.choose (snd >> (function | PrepoNoWarn d -> Some d      | _ -> None)) |> Seq.toArray
          let  nowarnsL = if nowarns |> Seq.isEmpty then [] else 
                          [ nowarns |> Seq.map (sprintf "\"%s\"") |> String.concat " " |> ((+) "#nowarn ") ]
          let  code     = fsNass |> Seq.map     fst |> Seq.append nowarnsL |> String.concat "\r\n"
          code, assembs, defines
      
      let compile options file code =
          let  code2, assembs, defines = prepareCode code
          do                             System.IO.File.WriteAllText(file, code2)
          let  options2 = [|
                             yield  "IGNOREDfsc.exe"
                             yield! assembs |> Array.map ((+) "-r:")
                             yield! defines |> Array.map ((+) "-d:")
                             yield! options
                             yield  file 
                         |]        
          let  checker  = FSharpChecker.Create()
          checker.Compile options2
      
      
//@"(6) F# CompileSnippet.fsx"
      type FsStationClient with
          member this.CompileSnippet(options, fileName, snpPath) =
              Wrap.wrapper {
                  let! code       = this.RequestCode snpPath
                  let  msgs, stat = compile options fileName code
                  return 
                      match msgs with
                      | [||] -> "Compiled " + snpPath
                      | _    -> msgs |> Seq.map (sprintf "%A") |> String.concat "\n"
              } 
              |> Wrap.getAsyncWithDefault Result.getMessages 
              |> Async.RunSynchronously
              |> printfn "%s"
          
//@" F# Compile Modules.fsx"
//#define COMPILING
    module Compile =
        let fsStation = FsStationShared.FsStationClient("CompileSnippet")
        [ [| "--target:winexe"  |],  @"Compiled\Calculate Primes.fs", "FSSGlobal/Evaluate F# Code/Snippets/Calculate primes"
          [| "--target:library" |],  @"Compiled\FSAutoComplete.fs"  , "FSSGlobal/Evaluate F# Code/FSAutoComplete/Commands"
        ] |> Seq.iter fsStation.CompileSnippet

