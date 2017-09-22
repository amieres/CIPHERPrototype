start /max http:\\localhost:9010
PATH=%PATH%;C:\Program Files (x86)\Microsoft SDKs\F#\4.1\Framework\v4.0;..\..\Common\packages\Zafir.FSharp\tools
cd bin
start cmd.exe @cmd /k Compiled\FSharpStation\FSharpStation.exe "website" "http://localhost:9010/"
