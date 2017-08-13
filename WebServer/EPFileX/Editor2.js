
          CIPHERSpaceLoadFileGlobalFileRef = null;
          CIPHERSpaceLoadFile = function (filename, callback) {
              if (filename.slice(-3) == ".js" || filename.slice(-4) == ".fsx" || filename.slice(-3) == ".fs") { //if filename is a external JavaScript file
                  var fileRef = null;
                  var pre = document.querySelector('script[src="' + filename + '"]')
                  if (!pre) {
                      fileRef = document.createElement('script')
                      fileRef.setAttribute("type", "text/javascript")
                      fileRef.setAttribute("src", filename)
                  }
                  else callback();
              }
              else if (filename.slice(-4) == ".css") { //if filename is an external CSS file
                  var pre = document.querySelector('script[src="' + filename + '"]')
                  if (!pre) {
                      fileRef = document.createElement("link")
                      fileRef.setAttribute("rel", "stylesheet")
                      fileRef.setAttribute("type", "text/css")
                      fileRef.setAttribute("href", filename)
                  }
                  else callback();
              }
              else if (filename.slice(-5) == ".html") { //if filename is an external HTML file
                  var pre = document.querySelector('script[src="' + filename + '"]')
                  if (!pre) {
                      fileRef = document.createElement("link")
                      fileRef.setAttribute("rel", "import")
                      fileRef.setAttribute("type", "text/html")
                      fileRef.setAttribute("href", filename)
                  }
                  else callback();
              }
              if (!!fileRef) {
                  CIPHERSpaceLoadFileGlobalFileRef = fileRef;
      			fileRef.onload = function () { fileRef.onload = null;  callback(); }
                  document.getElementsByTagName("head")[0].appendChild(fileRef);
              }
          }
          CIPHERSpaceLoadFiles = function (files, callback) {
              var newCallback = callback
              if (!!CIPHERSpaceLoadFileGlobalFileRef && !!(CIPHERSpaceLoadFileGlobalFileRef.onload)) {
                  var oldCallback = CIPHERSpaceLoadFileGlobalFileRef.onload;
                  CIPHERSpaceLoadFileGlobalFileRef.onload = null;
                  newCallback = function () {
                      callback();
                      oldCallback();
                  }
              }
              var i = 0;
              loadNext = function () {
                  if (i < files.length) {
                      var file = files[i];
                      i++;
                      CIPHERSpaceLoadFile(file, loadNext);
                  }
                  else newCallback();
              };
              loadNext();
      	}
          CIPHERSpaceLoadFiles(['https://code.jquery.com/jquery-3.1.1.min.js'], function() {}); 
      	CIPHERSpaceLoadFilesDoAfter = function (callback) {
      		var newCallback = callback
      		if (!!CIPHERSpaceLoadFileGlobalFileRef) {
      			if (!!(CIPHERSpaceLoadFileGlobalFileRef.onload)) {
      				var oldCallback = CIPHERSpaceLoadFileGlobalFileRef.onload;
      				CIPHERSpaceLoadFileGlobalFileRef.onload = null;
      				newCallback = function () {
      					oldCallback();
      					callback();
      				}
      			}
      		}
      		else CIPHERSpaceLoadFileGlobalFileRef = {};
      		CIPHERSpaceLoadFileGlobalFileRef.onload = newCallback;
      	}
      
      CIPHERSpaceLoadFilesDoAfter(function() { 
        if (typeof IntelliFactory !=='undefined')
          IntelliFactory.Runtime.Start();
        for (key in window) { 
          if (key.startsWith("StartupCode$")) 
            try { window[key].$cctor(); } catch (e) {} 
        } 
      })
                       CIPHERSpaceLoadFiles(["/Scripts/WebSharper/WebSharper.Core.JavaScript/Runtime.js", "/Scripts/WebSharper/WebSharper.Main.js", "/Scripts/WebSharper/WebSharper.Collections.js", "/Scripts/WebSharper/WebSharper.Control.js", "/Scripts/WebSharper/WebSharper.Web.js", "/Scripts/WebSharper/WebSharper.UI.Next.js", "/Scripts/WebSharper/Common.js"], function()
{
 "use strict";
 var FSSGlobal,Useful,Option,ExceptionThrown,ErrOptionIsNone,Result,ropBuilder,Wrap,Builder,Async,ResetableMemoize,PreproDirective,FsStationShared,CodeSnippetId,CodeSnippet,MessagingClient,FSMessage,FSSeverity,FsStationClientErr,FsStationClient,FSAutoComplete,Utils,Pos,Range,Document,CommandResponse,Location,CompletionResponse,OverloadDescription,OverloadParameter,Overload,MethodResponse,SymbolUseRange,SymbolUseResponse,HelpTextResponse,CompilerLocationResponse,FSharpErrorInfo,ErrorResponse,Colorization,Declaration,DeclarationResponse,OpenNamespace,QualifySymbol,ResolveNamespaceResponse,UnionCaseResponse,ACMessage,FSAutoCompleteClient,HtmlNode,Val,HelperType,HtmlNode$1,Template,Button,Input,Hoverable,TextArea,CodeMirrorPos,CodeMirrorEditor,CodeMirror,Hint,HintResponse,HintOptions,LintResponse,SplitterBar,Grid,TabStrip,SplitterNode,SplitterStructure,RunCode,EditorRpc,RunNode,FSharpStation,Position,KeyMapAutoComplete,CodeSnippet$1,SC$1,_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder,_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder,_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_GeneratedPrintf,GeneratedPrintf,IntelliFactory,Runtime,WebSharper,PrintfHelpers,List,Strings,Seq,Concurrency,console,Collections,Dictionary,Arrays,Unchecked,Guid,JSON,Remoting,AjaxRemotingProvider,Date,Option$1,UI,Next,View,Doc,AttrModule,AttrProxy,Var,Input$1,Mouse,FSharpSet,BalancedTree,Map,MatchFailureException,Slice,Json,Provider,FSharpMap,JavaScript,JSModule,HashSet,ListModel;
 FSSGlobal=window.FSSGlobal=window.FSSGlobal||{};
 Useful=FSSGlobal.Useful=FSSGlobal.Useful||{};
 Option=Useful.Option=Useful.Option||{};
 ExceptionThrown=Useful.ExceptionThrown=Useful.ExceptionThrown||{};
 ErrOptionIsNone=Useful.ErrOptionIsNone=Useful.ErrOptionIsNone||{};
 Result=Useful.Result=Useful.Result||{};
 ropBuilder=Result.ropBuilder=Result.ropBuilder||{};
 Wrap=Useful.Wrap=Useful.Wrap||{};
 Builder=Wrap.Builder=Wrap.Builder||{};
 Async=Useful.Async=Useful.Async||{};
 ResetableMemoize=Useful.ResetableMemoize=Useful.ResetableMemoize||{};
 PreproDirective=Useful.PreproDirective=Useful.PreproDirective||{};
 FsStationShared=FSSGlobal.FsStationShared=FSSGlobal.FsStationShared||{};
 CodeSnippetId=FsStationShared.CodeSnippetId=FsStationShared.CodeSnippetId||{};
 CodeSnippet=FsStationShared.CodeSnippet=FsStationShared.CodeSnippet||{};
 MessagingClient=FsStationShared.MessagingClient=FsStationShared.MessagingClient||{};
 FSMessage=FsStationShared.FSMessage=FsStationShared.FSMessage||{};
 FSSeverity=FsStationShared.FSSeverity=FsStationShared.FSSeverity||{};
 FsStationClientErr=FsStationShared.FsStationClientErr=FsStationShared.FsStationClientErr||{};
 FsStationClient=FsStationShared.FsStationClient=FsStationShared.FsStationClient||{};
 FSAutoComplete=FSSGlobal.FSAutoComplete=FSSGlobal.FSAutoComplete||{};
 Utils=FSAutoComplete.Utils=FSAutoComplete.Utils||{};
 Pos=Utils.Pos=Utils.Pos||{};
 Range=Utils.Range=Utils.Range||{};
 Document=Utils.Document=Utils.Document||{};
 CommandResponse=FSAutoComplete.CommandResponse=FSAutoComplete.CommandResponse||{};
 Location=CommandResponse.Location=CommandResponse.Location||{};
 CompletionResponse=CommandResponse.CompletionResponse=CommandResponse.CompletionResponse||{};
 OverloadDescription=CommandResponse.OverloadDescription=CommandResponse.OverloadDescription||{};
 OverloadParameter=CommandResponse.OverloadParameter=CommandResponse.OverloadParameter||{};
 Overload=CommandResponse.Overload=CommandResponse.Overload||{};
 MethodResponse=CommandResponse.MethodResponse=CommandResponse.MethodResponse||{};
 SymbolUseRange=CommandResponse.SymbolUseRange=CommandResponse.SymbolUseRange||{};
 SymbolUseResponse=CommandResponse.SymbolUseResponse=CommandResponse.SymbolUseResponse||{};
 HelpTextResponse=CommandResponse.HelpTextResponse=CommandResponse.HelpTextResponse||{};
 CompilerLocationResponse=CommandResponse.CompilerLocationResponse=CommandResponse.CompilerLocationResponse||{};
 FSharpErrorInfo=CommandResponse.FSharpErrorInfo=CommandResponse.FSharpErrorInfo||{};
 ErrorResponse=CommandResponse.ErrorResponse=CommandResponse.ErrorResponse||{};
 Colorization=CommandResponse.Colorization=CommandResponse.Colorization||{};
 Declaration=CommandResponse.Declaration=CommandResponse.Declaration||{};
 DeclarationResponse=CommandResponse.DeclarationResponse=CommandResponse.DeclarationResponse||{};
 OpenNamespace=CommandResponse.OpenNamespace=CommandResponse.OpenNamespace||{};
 QualifySymbol=CommandResponse.QualifySymbol=CommandResponse.QualifySymbol||{};
 ResolveNamespaceResponse=CommandResponse.ResolveNamespaceResponse=CommandResponse.ResolveNamespaceResponse||{};
 UnionCaseResponse=CommandResponse.UnionCaseResponse=CommandResponse.UnionCaseResponse||{};
 ACMessage=CommandResponse.ACMessage=CommandResponse.ACMessage||{};
 FSAutoCompleteClient=FSAutoComplete.FSAutoCompleteClient=FSAutoComplete.FSAutoCompleteClient||{};
 HtmlNode=FSSGlobal.HtmlNode=FSSGlobal.HtmlNode||{};
 Val=HtmlNode.Val=HtmlNode.Val||{};
 HelperType=Val.HelperType=Val.HelperType||{};
 HtmlNode$1=HtmlNode.HtmlNode=HtmlNode.HtmlNode||{};
 Template=FSSGlobal.Template=FSSGlobal.Template||{};
 Button=Template.Button=Template.Button||{};
 Input=Template.Input=Template.Input||{};
 Hoverable=Template.Hoverable=Template.Hoverable||{};
 TextArea=Template.TextArea=Template.TextArea||{};
 CodeMirrorPos=Template.CodeMirrorPos=Template.CodeMirrorPos||{};
 CodeMirrorEditor=Template.CodeMirrorEditor=Template.CodeMirrorEditor||{};
 CodeMirror=Template.CodeMirror=Template.CodeMirror||{};
 Hint=Template.Hint=Template.Hint||{};
 HintResponse=Template.HintResponse=Template.HintResponse||{};
 HintOptions=Template.HintOptions=Template.HintOptions||{};
 LintResponse=Template.LintResponse=Template.LintResponse||{};
 SplitterBar=Template.SplitterBar=Template.SplitterBar||{};
 Grid=Template.Grid=Template.Grid||{};
 TabStrip=Template.TabStrip=Template.TabStrip||{};
 SplitterNode=Template.SplitterNode=Template.SplitterNode||{};
 SplitterStructure=Template.SplitterStructure=Template.SplitterStructure||{};
 RunCode=FSSGlobal.RunCode=FSSGlobal.RunCode||{};
 EditorRpc=RunCode.EditorRpc=RunCode.EditorRpc||{};
 RunNode=RunCode.RunNode=RunCode.RunNode||{};
 FSharpStation=FSSGlobal.FSharpStation=FSSGlobal.FSharpStation||{};
 Position=FSharpStation.Position=FSharpStation.Position||{};
 KeyMapAutoComplete=FSharpStation.KeyMapAutoComplete=FSharpStation.KeyMapAutoComplete||{};
 CodeSnippet$1=FSharpStation.CodeSnippet=FSharpStation.CodeSnippet||{};
 SC$1=window["StartupCode$D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project_xxx$bf864f3c-1370-42f2-ac8a-565a604892e8 FSSGlobal"]=window["StartupCode$D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project_xxx$bf864f3c-1370-42f2-ac8a-565a604892e8 FSSGlobal"]||{};
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder=window["D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project$xxx_JsonDecoder"]=window["D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project$xxx_JsonDecoder"]||{};
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder=window["D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project$xxx_JsonEncoder"]=window["D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project$xxx_JsonEncoder"]||{};
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_GeneratedPrintf=window["D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project$xxx_GeneratedPrintf"]=window["D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project$xxx_GeneratedPrintf"]||{};
 GeneratedPrintf=window.GeneratedPrintf=window.GeneratedPrintf||{};
 IntelliFactory=window.IntelliFactory;
 Runtime=IntelliFactory&&IntelliFactory.Runtime;
 WebSharper=window.WebSharper;
 PrintfHelpers=WebSharper&&WebSharper.PrintfHelpers;
 List=WebSharper&&WebSharper.List;
 Strings=WebSharper&&WebSharper.Strings;
 Seq=WebSharper&&WebSharper.Seq;
 Concurrency=WebSharper&&WebSharper.Concurrency;
 console=window.console;
 Collections=WebSharper&&WebSharper.Collections;
 Dictionary=Collections&&Collections.Dictionary;
 Arrays=WebSharper&&WebSharper.Arrays;
 Unchecked=WebSharper&&WebSharper.Unchecked;
 Guid=WebSharper&&WebSharper.Guid;
 JSON=window.JSON;
 Remoting=WebSharper&&WebSharper.Remoting;
 AjaxRemotingProvider=Remoting&&Remoting.AjaxRemotingProvider;
 Date=window.Date;
 Option$1=WebSharper&&WebSharper.Option;
 UI=WebSharper&&WebSharper.UI;
 Next=UI&&UI.Next;
 View=Next&&Next.View;
 Doc=Next&&Next.Doc;
 AttrModule=Next&&Next.AttrModule;
 AttrProxy=Next&&Next.AttrProxy;
 Var=Next&&Next.Var;
 Input$1=Next&&Next.Input;
 Mouse=Input$1&&Input$1.Mouse;
 FSharpSet=Collections&&Collections.FSharpSet;
 BalancedTree=Collections&&Collections.BalancedTree;
 Map=Collections&&Collections.Map;
 MatchFailureException=WebSharper&&WebSharper.MatchFailureException;
 Slice=WebSharper&&WebSharper.Slice;
 Json=WebSharper&&WebSharper.Json;
 Provider=Json&&Json.Provider;
 FSharpMap=Collections&&Collections.FSharpMap;
 JavaScript=WebSharper&&WebSharper.JavaScript;
 JSModule=JavaScript&&JavaScript.JSModule;
 HashSet=Collections&&Collections.HashSet;
 ListModel=Next&&Next.ListModel;
 Option.modify=function(modifier)
 {
  var f,g,v;
  f=function(o)
  {
   return o==null?null:{
    $:1,
    $0:modifier(o.$0)
   };
  };
  g=(v=window.id,function(a)
  {
   return Option.defaultValue(v,a);
  });
  return function(x)
  {
   return g(f(x));
  };
 };
 Option.apply=function(vO,fO)
 {
  var $1;
  return vO!=null&&vO.$==1&&(fO!=null&&fO.$==1&&($1=[fO.$0,vO.$0],true))?{
   $:1,
   $0:$1[0]($1[1])
  }:null;
 };
 Option.iterFO=function(vO,fO)
 {
  if(vO!=null&&vO.$==1)
   if(fO!=null&&fO.$==1)
    fO.$0(vO.$0);
 };
 Option.iterF=function(v,a)
 {
  if(a!=null&&a.$==1)
   a.$0(v);
 };
 Option.call=function(v,a)
 {
  return a!=null&&a.$==1?{
   $:1,
   $0:a.$0(v)
  }:null;
 };
 Option.defaultWith=function(f,a)
 {
  return a==null?f():a.$0;
 };
 Option.defaultValue=function(v,a)
 {
  return a==null?v:a.$0;
 };
 ExceptionThrown=Useful.ExceptionThrown=Runtime.Class({
  FSSGlobal_Useful_ErrMsg$get_IsWarning:function()
  {
   return false;
  },
  FSSGlobal_Useful_ErrMsg$get_ErrMsg:function()
  {
   return(function($1)
   {
    return function($2)
    {
     return $1(PrintfHelpers.prettyPrint($2));
    };
   }(window.id))(this.exn);
  }
 },null,ExceptionThrown);
 ExceptionThrown.New=Runtime.Ctor(function(exn)
 {
  this.exn=exn;
 },ExceptionThrown);
 ErrOptionIsNone=Useful.ErrOptionIsNone=Runtime.Class({
  FSSGlobal_Useful_ErrMsg$get_IsWarning:function()
  {
   return false;
  },
  FSSGlobal_Useful_ErrMsg$get_ErrMsg:function()
  {
   return"Option is None";
  }
 },null,ErrOptionIsNone);
 ErrOptionIsNone.New=Runtime.Ctor(function()
 {
 },ErrOptionIsNone);
 ropBuilder=Result.ropBuilder=Runtime.Class({
  Combine:function(a,b)
  {
   return(Result.combine(a))(b);
  },
  Delay:function(f)
  {
   return f();
  },
  Zero:function()
  {
   return Result.succeed();
  },
  Using:function(disposable,restOfCExpr)
  {
   try
   {
    return restOfCExpr(disposable);
   }
   finally
   {
    disposable.Dispose();
   }
  },
  Bind:function(w,r)
  {
   return Result.bind(function(v)
   {
    return Result.tryCall(r,v);
   },w);
  },
  ReturnFrom:window.id,
  Return:function(x)
  {
   return Result.succeed(x);
  }
 },null,ropBuilder);
 ropBuilder.New=Runtime.Ctor(function()
 {
 },ropBuilder);
 Result.getMessages=function(ms)
 {
  var errors,warnings;
  return ms.$===0?"":(errors=List.filter(function(m)
  {
   return!m.FSSGlobal_Useful_ErrMsg$get_IsWarning();
  },ms),(warnings=List.filter(function(m)
  {
   return m.FSSGlobal_Useful_ErrMsg$get_IsWarning();
  },ms),((((Runtime.Curried(function($1,$2,$3,$4)
  {
   return $1(window.String($2)+" errors, "+window.String($3)+" warnings\n"+PrintfHelpers.toSafe($4));
  },4))(window.id))(errors.get_Length()))(warnings.get_Length()))(Strings.concat("\n",List.map(function(m)
  {
   return m.FSSGlobal_Useful_ErrMsg$get_ErrMsg();
  },ms)))));
 };
 Result.seqCheck=function(s)
 {
  return Seq.exists(function(a)
  {
   return Result.Success(a).$==1&&true;
  },s)?Result.failWithMsgs(Seq.pick(function(a)
  {
   var a$1;
   a$1=Result.Success(a);
   return a$1.$==1?{
    $:1,
    $0:a$1.$0
   }:null;
  },s)):Result.succeed(Seq.map(function(a)
  {
   return a.$0.$0;
  },s));
 };
 Result.withError=function(f,a)
 {
  var ms;
  ms=a.$1;
  return Option.defaultWith(function()
  {
   return f(ms);
  },a.$0);
 };
 Result.ifError=function(def,a)
 {
  return Option.defaultValue(def,a.$0);
 };
 Result.failIfTrue=function(m,v)
 {
  return v?Result.fail(m):Result.succeed();
 };
 Result.failIfFalse=function(m,v)
 {
  return v?Result.succeed():Result.fail(m);
 };
 Result.tryProtection=function()
 {
  return Result.succeed();
 };
 Result.toOption=function(a)
 {
  return a.$0;
 };
 Result.fromOption=function(m,a)
 {
  return a!=null&&a.$==1?Result.succeed(a.$0):Result.fail(m);
 };
 Result.fromChoice=function(context,c)
 {
  return c.$==1?Result.fail(c.$0):Result.succeed(c.$0);
 };
 Result.result=function()
 {
  SC$1.$cctor();
  return SC$1.result;
 };
 Result.tryCall=function(f,v)
 {
  try
  {
   return f(v);
  }
  catch(e)
  {
   return Result.fail(Result.failException(e));
  }
 };
 Result.failException=function(e)
 {
  return new ExceptionThrown.New(e);
 };
 Result.x=function(a)
 {
  return Result.Success(a).$==1?"No":"yes";
 };
 Result.Success=function(a)
 {
  return a.$0==null?{
   $:1,
   $0:a.$1
  }:{
   $:0,
   $0:[a.$0.$0,a.$1]
  };
 };
 Result.apply=function(a,a$1)
 {
  var fMs,ms,$1,$2,$3;
  fMs=a.$1;
  ms=a$1.$1;
  $1=a.$0;
  $2=a$1.$0;
  return $1!=null&&$1.$==1&&($2!=null&&$2.$==1&&($3=[$1.$0,$2.$0],true))?{
   $:0,
   $0:{
    $:1,
    $0:$3[0]($3[1])
   },
   $1:List.append(fMs,ms)
  }:{
   $:0,
   $0:null,
   $1:List.append(fMs,ms)
  };
 };
 Result.bind=function(f,a)
 {
  var o,ms,m;
  o=a.$0;
  ms=a.$1;
  return o==null?{
   $:0,
   $0:null,
   $1:ms
  }:(m=f(o.$0),{
   $:0,
   $0:m.$0,
   $1:List.append(ms,m.$1)
  });
 };
 Result.combine=function(a)
 {
  var ms;
  ms=a.$1;
  return function(r)
  {
   return Result.mergeMsgs(ms,r);
  };
 };
 Result.mergeMsgs=function(ms,r)
 {
  var t;
  t=Result.mapMsgs(function(l)
  {
   return List.append(ms,l);
  },r);
  return{
   $:0,
   $0:t[0],
   $1:t[1]
  };
 };
 Result.getMsgs=function(a)
 {
  return a.$1;
 };
 Result.getOption=function(a)
 {
  return a.$0;
 };
 Result.mapMsgs=function(f,a)
 {
  return[a.$0,f(a.$1)];
 };
 Result.mapMsg=function(f,a)
 {
  return[a.$0,List.map(f,a.$1)];
 };
 Result.map=function(f,a)
 {
  var o;
  return{
   $:0,
   $0:(o=a.$0,o==null?null:{
    $:1,
    $0:f(o.$0)
   }),
   $1:a.$1
  };
 };
 Result.failWithMsgs=function(ms)
 {
  return{
   $:0,
   $0:null,
   $1:ms
  };
 };
 Result.fail=function(m)
 {
  return{
   $:0,
   $0:null,
   $1:List.ofArray([m])
  };
 };
 Result.succeedWithMsgs=function(x,ms)
 {
  return{
   $:0,
   $0:{
    $:1,
    $0:x
   },
   $1:ms
  };
 };
 Result.succeedWithMsg=function(x,m)
 {
  return{
   $:0,
   $0:{
    $:1,
    $0:x
   },
   $1:List.ofArray([m])
  };
 };
 Result.succeed=function(x)
 {
  return{
   $:0,
   $0:{
    $:1,
    $0:x
   },
   $1:List.T.Empty
  };
 };
 Wrap.StartAsTask=function(w,options,cancToken)
 {
  return Concurrency.StartAsTask(Wrap.getAsyncR(w),cancToken);
 };
 Wrap.Start=function(w,cancToken)
 {
  Concurrency.Start(Wrap.getAsync(w),cancToken);
 };
 Builder=Wrap.Builder=Runtime.Class({
  Using:function(resource,body)
  {
   return{
    $:2,
    $0:Concurrency.Using(resource,function(a)
    {
     return Wrap.wrapper2Async(body,a);
    })
   };
  },
  Combine:function(a,b)
  {
   return Wrap.combine(Wrap.errOptionIsNone(),a,b);
  },
  Delay:function(f)
  {
   return f();
  },
  ReturnFrom:window.id,
  Return:function(x)
  {
   return{
    $:3,
    $0:x
   };
  },
  Zero:function()
  {
   return{
    $:3,
    $0:null
   };
  },
  Bind:function(wrapped,restOfCExpr)
  {
   return Wrap.bind(restOfCExpr,{
    $:4,
    $0:wrapped
   });
  },
  Bind$1:function(wrapped,restOfCExpr)
  {
   return Wrap.bind(restOfCExpr,{
    $:0,
    $0:wrapped
   });
  },
  Bind$2:function(wrapped,restOfCExpr)
  {
   return Wrap.bind(restOfCExpr,{
    $:1,
    $0:wrapped
   });
  },
  Bind$3:function(wrapped,restOfCExpr)
  {
   return Wrap.bind(restOfCExpr,wrapped);
  }
 },null,Builder);
 Builder.New=Runtime.Ctor(function()
 {
 },Builder);
 Wrap.start=function(printMsg,w)
 {
  var f,f$1,f$2,g,g$1,f$3,f$4;
  Concurrency.StartWithContinuations(Wrap.getAsyncR(w),(f=(f$1=(f$2=function(a)
  {
   return Result.mapMsgs(Result.getMessages,a);
  },(g=function($1,$2)
  {
   return $1==null?(function($3)
   {
    return $3("Failed!");
   }(function(s)
   {
    console.log(s);
   }),$2):$2;
  },function(x)
  {
   return g.apply(null,f$2(x));
  })),(g$1=function($1)
  {
   return function($2)
   {
    return $1(PrintfHelpers.toSafe($2));
   };
  }(window.id),function(x)
  {
   return g$1(f$1(x));
  })),function(x)
  {
   return printMsg(f(x));
  }),(f$3=function($1)
  {
   return function($2)
   {
    return $1(PrintfHelpers.prettyPrint($2));
   };
  }(window.id),function(x)
  {
   return printMsg(f$3(x));
  }),(f$4=function($1)
  {
   return function($2)
   {
    return $1(PrintfHelpers.prettyPrint($2));
   };
  }(window.id),function(x)
  {
   return printMsg(f$4(x));
  }),null);
 };
 Wrap.getAsync=function(w)
 {
  var vo,b,vr,b$1,vra,b$2;
  return w.$==3?Concurrency.Return(w.$0):w.$==4?(vo=w.$0,(b=null,Concurrency.Delay(function()
  {
   var $1,$2;
   if(vo==null)
    throw window.Error(Result.getMessages(List.ofArray([Wrap.errOptionIsNone()])));
   else
    $2=vo.$0;
   return Concurrency.Return($2);
  }))):w.$==0?(vr=w.$0,(b$1=null,Concurrency.Delay(function()
  {
   var $1,$2,a;
   a=Result.Success(vr);
   if(a.$==1)
    throw window.Error(Result.getMessages(a.$0));
   else
    $2=a.$0[0];
   return Concurrency.Return($2);
  }))):w.$==2?(vra=w.$0,(b$2=null,Concurrency.Delay(function()
  {
   return Concurrency.Bind(vra,function(a)
   {
    var $1,$2,a$1;
    a$1=Result.Success(a);
    if(a$1.$==1)
     throw window.Error(Result.getMessages(a$1.$0));
    else
     $2=a$1.$0[0];
    return Concurrency.Return($2);
   });
  }))):w.$0;
 };
 Wrap.getAsyncWithDefault=function(f,wb)
 {
  var b;
  b=null;
  return Concurrency.Delay(function()
  {
   return Concurrency.Bind(Wrap.getAsyncR(wb),function(a)
   {
    return Concurrency.Return(Result.withError(f,a));
   });
  });
 };
 Wrap.getAsyncR=function(wb)
 {
  var va,b;
  return wb.$==3?Concurrency.Return(Result.succeed(wb.$0)):wb.$==4?Concurrency.Return(Result.fromOption(Wrap.errOptionIsNone(),wb.$0)):wb.$==0?Concurrency.Return(wb.$0):wb.$==2?wb.$0:(va=wb.$0,(b=null,Concurrency.Delay(function()
  {
   return Concurrency.Bind(va,function(a)
   {
    return Concurrency.Return(Result.succeed(a));
   });
  })));
 };
 Wrap.getResult=function(callback,wb)
 {
  if(wb.$==4)
  {
   if(wb.$0==null)
    callback(Result.fail(Wrap.errOptionIsNone()));
   else
    callback(Result.succeed(wb.$0.$0));
  }
  else
   if(wb.$==0)
    callback(wb.$0);
   else
    if(wb.$==1)
     Concurrency.StartWithContinuations(wb.$0,function(v)
     {
      callback(Result.succeed(v));
     },function(exc)
     {
      callback(Result.fail(Result.failException(exc)));
     },function(can)
     {
      callback(Result.fail(Result.failException(can)));
     },null);
    else
     if(wb.$==2)
      Concurrency.StartWithContinuations(wb.$0,callback,function(exc)
      {
       callback(Result.fail(Result.failException(exc)));
      },function(can)
      {
       callback(Result.fail(Result.failException(can)));
      },null);
     else
      callback(Result.succeed(wb.$0));
 };
 Wrap.wrapper=function()
 {
  SC$1.$cctor();
  return SC$1.wrapper;
 };
 Wrap.combine=function(errOptionIsNone,wa,wb)
 {
  return wa.$==4?wa.$0==null?Wrap.addMsgs(errOptionIsNone,List.ofArray([errOptionIsNone]),wb):wb:wa.$==0?wa.$0.$1.$==0?wb:Wrap.addMsgs(errOptionIsNone,wa.$0.$1,wb):wa.$==1?wb:wa.$==2?wb:wb;
 };
 Wrap.addMsgs=function(errOptionIsNone,ms,wb)
 {
  var $1,b,b$1;
  if(ms.$===0)
   return wb;
  else
   switch(wb.$==4?wb.$0==null?1:($1=wb.$0.$0,0):wb.$==0?($1=wb.$0,2):wb.$==1?($1=wb.$0,3):wb.$==2?($1=wb.$0,4):($1=wb.$0,0))
   {
    case 0:
     return{
      $:0,
      $0:Result.succeedWithMsgs($1,ms)
     };
     break;
    case 1:
     return{
      $:0,
      $0:Result.mergeMsgs(ms,Result.fail(errOptionIsNone))
     };
     break;
    case 2:
     return{
      $:0,
      $0:Result.mergeMsgs(ms,$1)
     };
     break;
    case 3:
     return{
      $:2,
      $0:(b=null,Concurrency.Delay(function()
      {
       return Concurrency.Bind($1,function(a)
       {
        return Concurrency.Return(Result.succeedWithMsgs(a,ms));
       });
      }))
     };
     break;
    case 4:
     return{
      $:2,
      $0:(b$1=null,Concurrency.Delay(function()
      {
       return Concurrency.Bind($1,function(a)
       {
        return Concurrency.Return(Result.mergeMsgs(ms,a));
       });
      }))
     };
     break;
   }
 };
 Wrap.wrapper2Async=function(f,a)
 {
  var $1,wb,ab,b;
  wb=Wrap.tryCall(f,a);
  switch(wb.$==4?0:wb.$==0?1:wb.$==1?2:wb.$==2?3:0)
  {
   case 0:
    return Wrap.wb2arb(List.T.Empty,wb);
    break;
   case 1:
    return Wrap.wb2arb(wb.$0.$1,wb);
    break;
   case 2:
    ab=wb.$0;
    b=null;
    return Concurrency.Delay(function()
    {
     return Concurrency.Bind(ab,function(a$1)
     {
      return Concurrency.Return(Result.succeed(a$1));
     });
    });
    break;
   case 3:
    return wb.$0;
    break;
  }
 };
 Wrap.map=function(f)
 {
  var f$1;
  f$1=function(x)
  {
   return Wrap.Return(f(x));
  };
  return function(w)
  {
   return Wrap.bind(f$1,w);
  };
 };
 Wrap.Return=function(a)
 {
  return{
   $:3,
   $0:a
  };
 };
 Wrap.bind=function(f,wa)
 {
  var $1,a,ms,b,b$1;
  switch(wa.$==4?wa.$0==null?1:($1=wa.$0.$0,0):wa.$==0?(a=Result.Success(wa.$0),a.$==1?($1=a.$0,2):a.$0[1].$==0?($1=a.$0[0],0):($1=[a.$0[0],a.$0[1]],3)):wa.$==1?($1=wa.$0,4):wa.$==2?($1=wa.$0,5):($1=wa.$0,0))
  {
   case 0:
    return Wrap.tryCall(f,$1);
    break;
   case 1:
    return{
     $:4,
     $0:null
    };
    break;
   case 2:
    return{
     $:0,
     $0:Result.failWithMsgs($1)
    };
    break;
   case 3:
    ms=$1[1];
    return function(a$1)
    {
     var $2,a$2,b$2,b$3;
     switch(a$1.$==4?a$1.$0==null?1:($2=a$1.$0.$0,0):a$1.$==0?(a$2=Result.Success(a$1.$0),a$2.$==1?($2=a$2.$0,4):a$2.$0[1].$==0?($2=a$2.$0[0],2):($2=[a$2.$0[0],a$2.$0[1]],3)):a$1.$==1?($2=a$1.$0,5):a$1.$==2?($2=a$1.$0,6):($2=a$1.$0,0))
     {
      case 0:
       return{
        $:0,
        $0:Result.succeedWithMsgs($2,ms)
       };
       break;
      case 1:
       return{
        $:0,
        $0:Result.failWithMsgs(new List.T({
         $:1,
         $0:Wrap.errOptionIsNone(),
         $1:ms
        }))
       };
       break;
      case 2:
       return{
        $:0,
        $0:Result.succeedWithMsgs($2,ms)
       };
       break;
      case 3:
       return{
        $:0,
        $0:Result.succeedWithMsgs($2[0],List.append(ms,$2[1]))
       };
       break;
      case 4:
       return{
        $:0,
        $0:Result.failWithMsgs(List.append(ms,$2))
       };
       break;
      case 5:
       return{
        $:2,
        $0:(b$2=null,Concurrency.Delay(function()
        {
         return Concurrency.Bind($2,function(a$3)
         {
          return Concurrency.Return(Result.succeedWithMsgs(a$3,ms));
         });
        }))
       };
       break;
      case 6:
       return{
        $:2,
        $0:(b$3=null,Concurrency.Delay(function()
        {
         return Concurrency.Bind($2,function(a$3)
         {
          return Concurrency.Return(Result.mergeMsgs(ms,a$3));
         });
        }))
       };
       break;
     }
    }(Wrap.tryCall(f,$1[0]));
    break;
   case 4:
    return{
     $:2,
     $0:(b=null,Concurrency.Delay(function()
     {
      return Concurrency.Bind($1,function(a$1)
      {
       return Wrap.wb2arb(List.T.Empty,Wrap.tryCall(f,a$1));
      });
     }))
    };
    break;
   case 5:
    return{
     $:2,
     $0:(b$1=null,Concurrency.Delay(function()
     {
      return Concurrency.Bind($1,function(a$1)
      {
       var a$2,ms$1,b$2;
       a$2=Result.Success(a$1);
       return a$2.$==1?(ms$1=a$2.$0,b$2=null,Concurrency.Delay(function()
       {
        return Concurrency.Return(Result.failWithMsgs(ms$1));
       })):Wrap.wb2arb(a$2.$0[1],Wrap.tryCall(f,a$2.$0[0]));
      });
     }))
    };
    break;
  }
 };
 Wrap.tryCall=function(f,a)
 {
  try
  {
   return f(a);
  }
  catch(e)
  {
   return{
    $:0,
    $0:Result.fail(Result.failException(e))
   };
  }
 };
 Wrap.wb2arb=function(ms,a)
 {
  var $1,b,b$1,b$2,b$3,b$4;
  switch(a.$==2?($1=a.$0,1):a.$==0?($1=a.$0,2):a.$==3?($1=a.$0,3):a.$==4?a.$0==null?4:($1=a.$0.$0,3):($1=a.$0,0))
  {
   case 0:
    b=null;
    return Concurrency.Delay(function()
    {
     return Concurrency.Bind($1,function(a$1)
     {
      return Concurrency.Return(Result.succeedWithMsgs(a$1,ms));
     });
    });
    break;
   case 1:
    b$1=null;
    return Concurrency.Delay(function()
    {
     return Concurrency.Bind($1,function(a$1)
     {
      return Concurrency.Return(Result.mergeMsgs(ms,a$1));
     });
    });
    break;
   case 2:
    b$2=null;
    return Concurrency.Delay(function()
    {
     return Concurrency.Return(Result.mergeMsgs(ms,$1));
    });
    break;
   case 3:
    b$3=null;
    return Concurrency.Delay(function()
    {
     return Concurrency.Return(Result.succeedWithMsgs($1,ms));
    });
    break;
   case 4:
    b$4=null;
    return Concurrency.Delay(function()
    {
     return Concurrency.Return(Result.failWithMsgs(new List.T({
      $:1,
      $0:Wrap.errOptionIsNone(),
      $1:ms
     })));
    });
    break;
  }
 };
 Wrap.errOptionIsNone=function()
 {
  SC$1.$cctor();
  return SC$1.errOptionIsNone;
 };
 Async.map=function(f,va)
 {
  var b;
  b=null;
  return Concurrency.Delay(function()
  {
   return Concurrency.Bind(va,function(a)
   {
    return Concurrency.Return(f(a));
   });
  });
 };
 ResetableMemoize=Useful.ResetableMemoize=Runtime.Class({
  ClearCache:function()
  {
   this.cache.Clear();
  }
 },null,ResetableMemoize);
 ResetableMemoize.New=Runtime.Ctor(function(f)
 {
  this.f=f;
  this.cache=new Dictionary.New$5();
 },ResetableMemoize);
 PreproDirective.NoPrepo={
  $:11
 };
 PreproDirective.PrepoEndIf={
  $:8
 };
 PreproDirective.PrepoElse={
  $:7
 };
 Useful.separateDirectives=function(fsNass)
 {
  var assembs,f,g,defines,f$1,g$1,prepoIs,f$2,g$2,nowarns,f$3,g$3;
  assembs=Arrays.ofSeq(Seq.distinct(Seq.choose((f=function(t)
  {
   return t[1];
  },(g=function(a)
  {
   return a.$==0?{
    $:1,
    $0:a.$0
   }:null;
  },function(x)
  {
   return g(f(x));
  })),fsNass)));
  defines=Arrays.ofSeq(Seq.distinct(Seq.choose((f$1=function(t)
  {
   return t[1];
  },(g$1=function(a)
  {
   return a.$==1?{
    $:1,
    $0:a.$0
   }:null;
  },function(x)
  {
   return g$1(f$1(x));
  })),fsNass)));
  prepoIs=Arrays.ofSeq(Seq.distinct(Seq.choose((f$2=function(t)
  {
   return t[1];
  },(g$2=function(a)
  {
   return a.$==5?{
    $:1,
    $0:a.$0
   }:null;
  },function(x)
  {
   return g$2(f$2(x));
  })),fsNass)));
  nowarns=Arrays.ofSeq(Seq.distinct(Seq.choose((f$3=function(t)
  {
   return t[1];
  },(g$3=function(a)
  {
   return a.$==4?{
    $:1,
    $0:a.$0
   }:null;
  },function(x)
  {
   return g$3(f$3(x));
  })),fsNass)));
  return[Arrays.ofSeq(Seq.map(function(t)
  {
   return t[0];
  },fsNass)),assembs,defines,prepoIs,nowarns];
 };
 Useful.separatePrepros=function(removePrepoLine,code)
 {
  var quoted,define,comment,preL;
  quoted=function(line)
  {
   return Option.defaultValue(line,Seq.tryLast(Strings.SplitStrings(Strings.Trim(line),["\""],1)));
  };
  define=function(line)
  {
   return Option.defaultValue("",Seq.tryHead(Strings.SplitStrings(Strings.Trim(line),["#define "],1)));
  };
  comment=function(y)
  {
   return"//"+y;
  };
  preL=removePrepoLine?comment:window.id;
  return Arrays.map(function(line)
  {
   var m,$1,$2,$3,$4,$5,$6,$7,$8,$9,$10,$11,$12;
   m=true;
   return m&&(Strings.StartsWith(line,"#define")&&true)?[comment(line),{
    $:1,
    $0:define(line)
   }]:m&&(Strings.StartsWith(line,"#r")&&true)?[comment(line),{
    $:0,
    $0:quoted(line)
   }]:m&&(Strings.StartsWith(line,"#load")&&true)?[comment(line),{
    $:2,
    $0:quoted(line)
   }]:m&&(Strings.StartsWith(line,"#nowarn")&&true)?[comment(line),{
    $:4,
    $0:quoted(line)
   }]:m&&(Strings.StartsWith(line,"# ")&&true)?[preL(line),{
    $:3,
    $0:quoted(line)
   }]:m&&(Strings.StartsWith(line,"#line")&&true)?[preL(line),{
    $:3,
    $0:quoted(line)
   }]:m&&(Strings.StartsWith(line,"#I")&&true)?[comment(line),{
    $:5,
    $0:quoted(line)
   }]:m&&(Strings.StartsWith(line,"#if")&&true)?[line,{
    $:6,
    $0:line
   }]:m&&(Strings.StartsWith(line,"#else")&&true)?[line,PreproDirective.PrepoElse]:m&&(Strings.StartsWith(line,"#endif")&&true)?[line,PreproDirective.PrepoEndIf]:m&&(Strings.StartsWith(line,"#light")&&true)?[line,{
    $:9,
    $0:false
   }]:m&&(Strings.StartsWith(line,"#")&&true)?[comment(line),{
    $:10,
    $0:line
   }]:[line,PreproDirective.NoPrepo];
  },code);
 };
 Useful.REGEX=function(expr,opt,value)
 {
  var m;
  if(value===null)
   return null;
  else
   try
   {
    m=(new window.String(value)).match(new window.RegExp(expr,opt));
    return Unchecked.Equals(m,null)?null:m&&Arrays.length(m)===0?null:{
     $:1,
     $0:m
    };
   }
   catch(e)
   {
    return null;
   }
 };
 Useful.extract=function(n,s)
 {
  var b;
  return Strings.Substring(s,0,(b=s.length,Unchecked.Compare(n,b)===-1?n:b));
 };
 CodeSnippetId=FsStationShared.CodeSnippetId=Runtime.Class({
  get_Text:function()
  {
   return window.String(this.$0);
  }
 },null,CodeSnippetId);
 CodeSnippetId.get_New=function()
 {
  return new CodeSnippetId({
   $:0,
   $0:Guid.NewGuid()
  });
 };
 CodeSnippet=FsStationShared.CodeSnippet=Runtime.Class({
  SeparateCode:function(addLinePrepos)
  {
   var indent,p,m,p$1,a,code;
   indent=this.level*2;
   p=indent===0?[window.id,""]:[(m=function(l,pr)
   {
    return[Strings.replicate(indent," ")+l,pr];
   },function(a$1)
   {
    return Arrays.map(function($1)
    {
     return m($1[0],$1[1]);
    },a$1);
   }),(function($1)
   {
    return function($2)
    {
     return $1("("+window.String($2)+")");
    };
   }(window.id))(indent)];
   p$1=Useful.separateDirectives(p[0](Useful.separatePrepros(!addLinePrepos,(!addLinePrepos?window.id:(a=[(((Runtime.Curried3(function($1,$2,$3)
   {
    return $1("# 1 @\""+PrintfHelpers.toSafe($2)+PrintfHelpers.toSafe($3)+"\"");
   }))(window.id))(p[1]))(this.get_NameSanitized())],function(a$1)
   {
    return a.concat(a$1);
   }))(Strings.SplitChars(this.content,[10],0)))));
   code=p$1[0];
   return[[[this.get_NameSanitized(),Arrays.length(code),indent]],code,p$1[1],p$1[2],p$1[3],p$1[4]];
  },
  UniquePredecessors:function(fetcher)
  {
   return FsStationShared.predsL(fetcher,List.ofArray([this.id]));
  },
  get_NameSanitized:function()
  {
   return this.id.get_Text()+" "+FsStationShared.sanitize(this.get_Name())+".fsx";
  },
  get_Name:function()
  {
   return FsStationShared.snippetName(this.name,this.content);
  }
 },null,CodeSnippet);
 CodeSnippet.CodeFsx=function(addLinePrepos,snps)
 {
  return(CodeSnippet.CodeAndStarts(addLinePrepos,snps))[0];
 };
 CodeSnippet.CodeAndStarts=function(addLinePrepos,snippets)
 {
  var t;
  t=CodeSnippet.ReducedCode(addLinePrepos,snippets);
  return CodeSnippet.FinishCode(addLinePrepos,t[0],t[1],t[2],t[3],t[4],t[5]);
 };
 CodeSnippet.FinishCode=function(addLinePrepos,lines,code,assembs,defines,prepIs,nowarns)
 {
  var config,part1;
  config=Strings.concat(" ",Seq.map(function(y)
  {
   return"-d:"+y;
  },Seq.sort(defines)));
  part1=List.ofSeq(Seq.delay(function()
  {
   return Seq.append(config!==""?["////"+config]:[],Seq.delay(function()
   {
    return Seq.append(Seq.map(function($1)
    {
     return function($2)
     {
      return $1("#I @\""+PrintfHelpers.toSafe($2)+"\"");
     };
    }(window.id),prepIs),Seq.delay(function()
    {
     return Seq.append(Seq.map(function($1)
     {
      return function($2)
      {
       return $1("#r @\""+PrintfHelpers.toSafe($2)+"\"");
      };
     }(window.id),assembs),Seq.delay(function()
     {
      return Seq.append(addLinePrepos&&!Seq.isEmpty(nowarns)?["# 1 \"required for nowarns to work\""]:[],Seq.delay(function()
      {
       return Seq.map(function($1)
       {
        return function($2)
        {
         return $1("#nowarn \""+PrintfHelpers.toSafe($2)+"\"");
        };
       }(window.id),nowarns);
      }));
     }));
    }));
   }));
  }));
  return[Strings.concat("\n",Seq.append(part1,code)),Arrays.ofSeq((Seq.mapFold(function(firstLine,t)
  {
   var len;
   len=t[1];
   return[[t[0],[t[2],firstLine,firstLine+len]],firstLine+len];
  },part1.get_Length(),lines))[0])];
 };
 CodeSnippet.ReducedCode=function(addLinePrepos,snippets)
 {
  var t,r,snps;
  t=(r=function(a,a$1,a$2,a$3,a$4,a$5)
  {
   return function(t$1)
   {
    return CodeSnippet.AddSeps(a,a$1,a$2,a$3,a$4,a$5,t$1[0],t$1[1],t$1[2],t$1[3],t$1[4],t$1[5]);
   };
  },Seq.reduce(function($1,$2)
  {
   return(function($3)
   {
    return r($3[0],$3[1],$3[2],$3[3],$3[4],$3[5]);
   }($1))($2);
  },(snps=Seq.map(function(snp)
  {
   return snp.SeparateCode(addLinePrepos);
  },snippets),Seq.isEmpty(snps)?[[[],[],[],[],[],[]]]:snps)));
  return[t[0],[Strings.concat("\n",t[1])],t[2],t[3],t[4],t[5]];
 };
 CodeSnippet.AddSeps=function(lines1,code1,assembs1,defines1,prepIs1,nowarns1,lines2,code2,assembs2,defines2,prepIs2,nowarns2)
 {
  return[lines1.concat(lines2),code1.concat(code2),Arrays.ofSeq(Seq.distinct(Seq.append(assembs1,assembs2))),Arrays.ofSeq(Seq.distinct(Seq.append(defines1,defines2))),Arrays.ofSeq(Seq.distinct(Seq.append(prepIs1,prepIs2))),Arrays.ofSeq(Seq.distinct(Seq.append(nowarns1,nowarns2)))];
 };
 CodeSnippet.TryFindByKey=function(snps,key)
 {
  return Seq.tryFind(function(snp)
  {
   return Unchecked.Equals(snp.id,key);
  },snps);
 };
 CodeSnippet.New=function(name,content,parent,predecessors,id,expanded,level,properties)
 {
  return new CodeSnippet({
   name:name,
   content:content,
   parent:parent,
   predecessors:predecessors,
   id:id,
   expanded:expanded,
   level:level,
   properties:properties
  });
 };
 MessagingClient=FsStationShared.MessagingClient=Runtime.Class({
  poStrings:function(resp)
  {
   return resp.$==1?resp.$0:[(function($1)
   {
    return function($2)
    {
     return $1("unexpected response: "+PrintfHelpers.toSafe($2));
    };
   }(window.id))(resp.$0)];
  },
  poString:function(resp)
  {
   return resp.$==1?(function($1)
   {
    return function($2)
    {
     return $1(PrintfHelpers.printArray(PrintfHelpers.prettyPrint,$2));
    };
   }(window.id))(resp.$0):resp.$0;
  },
  poMsg:function(checkResponse,msg)
  {
   var $this,b;
   $this=this;
   b=null;
   return Concurrency.Delay(function()
   {
    return Concurrency.Bind($this.sendMessage({
     $:0,
     $0:"WebServer:PostOffice"
    },JSON.stringify((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$6())(msg))),function(a)
    {
     return Concurrency.Return(checkResponse((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$6())(JSON.parse(a))));
    });
   });
  },
  sendMessage:function(toId,msg)
  {
   return(new AjaxRemotingProvider.New()).Async("Remote:CIPHERPrototype.Messaging.sendRequest:1096816393",[toId,this.fromId,msg]);
  },
  awaitMessage:function(respond)
  {
   var $this,b;
   $this=this;
   Concurrency.StartWithContinuations((b=null,Concurrency.Delay(function()
   {
    return Concurrency.While(function()
    {
     return true;
    },Concurrency.Delay(function()
    {
     (((Runtime.Curried3(function($1,$2,$3)
     {
      return $1(PrintfHelpers.toSafe($2)+" awaitRequest "+PrintfHelpers.toSafe($3));
     }))(function(s)
     {
      console.log(s);
     }))(function(n)
     {
      return n.getFullYear()+"-"+(n.getMonth()+1)+"-"+n.getDate()+" "+n.getHours()+":"+n.getMinutes()+":"+n.getSeconds()+":"+n.getMilliseconds();
     }(new window.Date(Date.now()))))($this.clientId);
     return Concurrency.Bind(Concurrency.StartChild((new AjaxRemotingProvider.New()).Async("Remote:CIPHERPrototype.Messaging.awaitRequestFor:278590570",[$this.fromId]),{
      $:1,
      $0:$this.tout
     }),function(a)
     {
      return Concurrency.TryWith(Concurrency.Delay(function()
      {
       return Concurrency.Bind(a,function(a$1)
       {
        return Concurrency.Bind(respond($this.clientId,a$1.content),function(a$2)
        {
         return Concurrency.Bind((new AjaxRemotingProvider.New()).Async("Remote:CIPHERPrototype.Messaging.replyTo:-1092841374",[a$1.messageId.$0,a$2]),function()
         {
          return Concurrency.Return(null);
         });
        });
       });
      }),function(a$1)
      {
       return a$1 instanceof WebSharper.TimeoutException?Concurrency.Zero():((function($1)
       {
        return function($2)
        {
         return $1(PrintfHelpers.prettyPrint($2));
        };
       }(function(s)
       {
        console.log(s);
       }))(a$1),Concurrency.Zero());
      });
     });
    }));
   })),function()
   {
   },function(e)
   {
    window.alert(window.String(e));
   },function(c)
   {
    window.alert(window.String(c));
   },null);
  },
  get_ClientId:function()
  {
   return this.clientId;
  },
  get_EndPoint:function()
  {
   return this.wsEndPoint;
  },
  POListeners:function()
  {
   var $this;
   $this=this;
   return this.poMsg(function(r)
   {
    return $this.poStrings(r);
   },{
    $:2
   });
  },
  POMessage:function(msg)
  {
   return this.poMsg(window.id,msg);
  },
  SendMessage:function(toId,msg)
  {
   return this.sendMessage(toId,msg);
  },
  AwaitMessage:function(respondA)
  {
   this.awaitMessage(respondA);
  },
  AwaitMessage$1:function(respond)
  {
   this.awaitMessage(function(clientId,request)
   {
    var b;
    b=null;
    return Concurrency.Delay(function()
    {
     return Concurrency.Return(respond(clientId,request));
    });
   });
  }
 },null,MessagingClient);
 MessagingClient.get_EndPoint_=function()
 {
  return"http://localhost:9000/FSharpStation.html";
 };
 MessagingClient.New=Runtime.Ctor(function(clientId,timeout,endPoint)
 {
  this.clientId=clientId;
  this.wsEndPoint=Option.defaultValue("http://localhost:9000/FSharpStation.html",endPoint);
  this.tout=Option.defaultValue(100000,timeout);
  this.fromId={
   $:0,
   $0:this.clientId
  };
  Remoting.set_EndPoint(this.wsEndPoint);
 },MessagingClient);
 FSMessage.GetWholeFile={
  $:11
 };
 FSMessage.GetIdentification={
  $:0
 };
 FSSeverity.FSInfor={
  $:2
 };
 FSSeverity.FSWarning={
  $:1
 };
 FSSeverity.FSError={
  $:0
 };
 FsStationClientErr=FsStationShared.FsStationClientErr=Runtime.Class({
  FSSGlobal_Useful_ErrMsg$get_IsWarning:function()
  {
   return this.$==0&&(this.$1.$==0&&true);
  },
  FSSGlobal_Useful_ErrMsg$get_ErrMsg:function()
  {
   return this.$==0?(((Runtime.Curried3(function($1,$2,$3)
   {
    return $1(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_GeneratedPrintf.p($2)+" "+PrintfHelpers.toSafe($3));
   }))(window.id))(this.$1))(this.$0):(function($1)
   {
    return function($2)
    {
     return $1(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_GeneratedPrintf.p$1($2));
    };
   }(window.id))(this);
  }
 },null,FsStationClientErr);
 FsStationClient=FsStationShared.FsStationClient=Runtime.Class({
  snippetResponse:function(response)
  {
   return response.$==2?Result.succeed(response.$0):Result.fail(new FsStationClientErr({
    $:1,
    $0:window.String(response)
   }));
  },
  snippetsResponse:function(response)
  {
   return response.$==3?Result.succeed(response.$0):Result.fail(new FsStationClientErr({
    $:1,
    $0:window.String(response)
   }));
  },
  stringResponse:function(response)
  {
   var $1,$2;
   return response.$==1&&(($2=response.$0,$2!=null&&$2.$==1)&&($1=response.$0.$0,true))?Result.succeed($1):Result.fail(new FsStationClientErr({
    $:1,
    $0:window.String(response)
   }));
  },
  stringResponseR:function(response)
  {
   var $1,$2,m;
   return response.$==4&&(($2=response.$0,$2!=null&&$2.$==1)&&($1=[response.$0.$0,response.$1],true))?Result.succeedWithMsgs($1[0],List.ofSeq((m=function(a,a$1)
   {
    return new FsStationClientErr({
     $:0,
     $0:a,
     $1:a$1
    });
   },Seq.map(function($3)
   {
    return m($3[0],$3[1]);
   },$1[1])))):Result.fail(new FsStationClientErr({
    $:1,
    $0:window.String(response)
   }));
  },
  get_MessagingClient:function()
  {
   return this.msgClient;
  },
  get_FSStationId:function()
  {
   return this.fsIds;
  },
  GenericMessage:function(txt)
  {
   var $this,t,toId,msg,checkResponse,b;
   $this=this;
   t=this;
   toId=this.toId;
   msg={
    $:1,
    $0:txt
   };
   checkResponse=function(r)
   {
    return $this.stringResponse(r);
   };
   b=Wrap.wrapper();
   return b.Delay(function()
   {
    return b.Bind$2(t.msgClient.SendMessage(toId,JSON.stringify((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$2())(msg))),function(a)
    {
     return b.Bind$1(checkResponse((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$2())(JSON.parse(a))),function(a$1)
     {
      return b.Return(a$1);
     });
    });
   });
  },
  RequestWholeFile:function()
  {
   var $this,t,toId,msg,checkResponse,b;
   $this=this;
   t=this;
   toId=this.toId;
   msg=FSMessage.GetWholeFile;
   checkResponse=function(r)
   {
    return $this.stringResponse(r);
   };
   b=Wrap.wrapper();
   return b.Delay(function()
   {
    return b.Bind$2(t.msgClient.SendMessage(toId,JSON.stringify((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$2())(msg))),function(a)
    {
     return b.Bind$1(checkResponse((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$2())(JSON.parse(a))),function(a$1)
     {
      return b.Return(a$1);
     });
    });
   });
  },
  RequestPredsById:function(snpId)
  {
   var $this,t,toId,msg,checkResponse,b;
   $this=this;
   t=this;
   toId=this.toId;
   msg={
    $:4,
    $0:snpId
   };
   checkResponse=function(r)
   {
    return $this.snippetsResponse(r);
   };
   b=Wrap.wrapper();
   return b.Delay(function()
   {
    return b.Bind$2(t.msgClient.SendMessage(toId,JSON.stringify((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$2())(msg))),function(a)
    {
     return b.Bind$1(checkResponse((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$2())(JSON.parse(a))),function(a$1)
     {
      return b.Return(a$1);
     });
    });
   });
  },
  RequestPreds:function(snpPath)
  {
   var $this,m,t,toId,checkResponse,b;
   $this=this;
   m={
    $:8,
    $0:Strings.SplitChars(snpPath,[47],0)
   };
   t=this;
   toId=this.toId;
   checkResponse=function(r)
   {
    return $this.snippetsResponse(r);
   };
   b=Wrap.wrapper();
   return b.Delay(function()
   {
    return b.Bind$2(t.msgClient.SendMessage(toId,JSON.stringify((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$2())(m))),function(a)
    {
     return b.Bind$1(checkResponse((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$2())(JSON.parse(a))),function(a$1)
     {
      return b.Return(a$1);
     });
    });
   });
  },
  RequestJSCode:function(snpPath)
  {
   var $this,m,t,toId,checkResponse,b;
   $this=this;
   m={
    $:10,
    $0:Strings.SplitChars(snpPath,[47],0)
   };
   t=this;
   toId=this.toId;
   checkResponse=function(r)
   {
    return $this.stringResponseR(r);
   };
   b=Wrap.wrapper();
   return b.Delay(function()
   {
    return b.Bind$2(t.msgClient.SendMessage(toId,JSON.stringify((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$2())(m))),function(a)
    {
     return b.Bind$1(checkResponse((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$2())(JSON.parse(a))),function(a$1)
     {
      return b.Return(a$1);
     });
    });
   });
  },
  RequestCode:function(snpPath)
  {
   var $this,m,t,toId,checkResponse,b;
   $this=this;
   m={
    $:7,
    $0:Strings.SplitChars(snpPath,[47],0)
   };
   t=this;
   toId=this.toId;
   checkResponse=function(r)
   {
    return $this.stringResponse(r);
   };
   b=Wrap.wrapper();
   return b.Delay(function()
   {
    return b.Bind$2(t.msgClient.SendMessage(toId,JSON.stringify((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$2())(m))),function(a)
    {
     return b.Bind$1(checkResponse((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$2())(JSON.parse(a))),function(a$1)
     {
      return b.Return(a$1);
     });
    });
   });
  },
  RequestSnippet:function(snpPath)
  {
   var $this,m,t,toId,checkResponse,b;
   $this=this;
   m={
    $:9,
    $0:Strings.SplitChars(snpPath,[47],0)
   };
   t=this;
   toId=this.toId;
   checkResponse=function(r)
   {
    return $this.snippetResponse(r);
   };
   b=Wrap.wrapper();
   return b.Delay(function()
   {
    return b.Bind$2(t.msgClient.SendMessage(toId,JSON.stringify((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$2())(m))),function(a)
    {
     return b.Bind$1(checkResponse((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$2())(JSON.parse(a))),function(a$1)
     {
      return b.Return(a$1);
     });
    });
   });
  },
  SendMessage:function(msg)
  {
   var t,toId,b;
   t=this;
   toId=this.toId;
   b=Wrap.wrapper();
   return b.Delay(function()
   {
    return b.Bind$2(t.msgClient.SendMessage(toId,JSON.stringify((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$2())(msg))),function(a)
    {
     return b.Bind$1(Result.succeed((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$2())(JSON.parse(a))),function(a$1)
     {
      return b.Return(a$1);
     });
    });
   });
  },
  SendMessage$1:function(toId2,msg)
  {
   var t,b;
   t=this;
   b=Wrap.wrapper();
   return b.Delay(function()
   {
    return b.Bind$2(t.msgClient.SendMessage(toId2,JSON.stringify((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$2())(msg))),function(a)
    {
     return b.Bind$1(Result.succeed((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$2())(JSON.parse(a))),function(a$1)
     {
      return b.Return(a$1);
     });
    });
   });
  }
 },null,FsStationClient);
 FsStationClient.get_FSStationId_=function()
 {
  return"FSharpStation";
 };
 FsStationClient.New=Runtime.Ctor(function(clientId,fsStationId,timeout,endPoint)
 {
  this.fsIds=Option.defaultValue("FSharpStation",fsStationId);
  this.msgClient=new MessagingClient.New(clientId,timeout,endPoint);
  this.toId={
   $:0,
   $0:this.fsIds
  };
 },FsStationClient);
 FsStationShared.predsL=function(fetcher,ins)
 {
  var ins$1,outs;
  ins$1=ins;
  outs=List.T.Empty;
  while(!(ins$1.$==0))
   (function()
   {
    var rest,hd;
    return ins$1.$==1?(rest=ins$1.$1,(hd=ins$1.$0,Seq.contains(hd,outs)?void(ins$1=rest):(ins$1=List.collect(window.id,List.ofArray([rest,List.collect(function(s)
    {
     return List.append(Option$1.toList(s.parent),s.predecessors);
    },Option$1.toList(fetcher(hd)))])),void(outs=new List.T({
     $:1,
     $0:hd,
     $1:outs
    }))))):null;
   }());
  return outs;
 };
 FsStationShared.preds=function(fetcher,outs,ins)
 {
  var hd,x;
  return ins.$==1?(hd=ins.$0,(x=List.collect(window.id,List.ofArray([ins.$1,List.collect(function(s)
  {
   return List.append(Option$1.toList(s.parent),s.predecessors);
  },Option$1.toList(fetcher(hd)))])),FsStationShared.preds(fetcher,Seq.contains(hd,outs)?outs:new List.T({
   $:1,
   $0:hd,
   $1:outs
  }),x))):outs;
 };
 FsStationShared.sanitize=function(n)
 {
  var illegal;
  illegal=[34,60,62,124,0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,58,42,63,92,47];
  return Strings.Filter(function(c)
  {
   return!Arrays.contains(c,illegal);
  },n);
 };
 FsStationShared.snippetName=function(name,content)
 {
  return name!==""?name:Option.defaultValue("<empty>",Seq.tryHead(Seq.filter(function(l)
  {
   return!(Strings.StartsWith(l,"#")||Strings.StartsWith(l,"[<")||Strings.StartsWith(l,"//"));
  },Seq.map(Strings.Trim,Strings.SplitChars(content,[10],1)))));
 };
 FsStationShared.swap=function(f,a,b)
 {
  return f(b,a);
 };
 Pos.New=function(Line,Col)
 {
  return{
   Line:Line,
   Col:Col
  };
 };
 Range.New=function(StartLine,StartColumn,EndLine,EndColumn)
 {
  return{
   StartLine:StartLine,
   StartColumn:StartColumn,
   EndLine:EndLine,
   EndColumn:EndColumn
  };
 };
 Document.New=function(FullName,LineCount,GetText,GetLineText0,GetLineText1)
 {
  return{
   FullName:FullName,
   LineCount:LineCount,
   GetText:GetText,
   GetLineText0:GetLineText0,
   GetLineText1:GetLineText1
  };
 };
 Location.New=function(File,Line,Column)
 {
  return{
   File:File,
   Line:Line,
   Column:Column
  };
 };
 CompletionResponse.New=function(Name,ReplacementText,Glyph,GlyphChar)
 {
  return{
   Name:Name,
   ReplacementText:ReplacementText,
   Glyph:Glyph,
   GlyphChar:GlyphChar
  };
 };
 OverloadDescription.New=function(Signature,Comment)
 {
  return{
   Signature:Signature,
   Comment:Comment
  };
 };
 OverloadParameter.New=function(Name,CanonicalTypeTextForSorting,Display,Description)
 {
  return{
   Name:Name,
   CanonicalTypeTextForSorting:CanonicalTypeTextForSorting,
   Display:Display,
   Description:Description
  };
 };
 Overload.New=function(Tip,TypeText,Parameters,IsStaticArguments)
 {
  return{
   Tip:Tip,
   TypeText:TypeText,
   Parameters:Parameters,
   IsStaticArguments:IsStaticArguments
  };
 };
 MethodResponse.New=function(Name,CurrentParameter,Overloads)
 {
  return{
   Name:Name,
   CurrentParameter:CurrentParameter,
   Overloads:Overloads
  };
 };
 SymbolUseRange.New=function(FileName,StartLine,StartColumn,EndLine,EndColumn,IsFromDefinition,IsFromAttribute,IsFromComputationExpression,IsFromDispatchSlotImplementation,IsFromPattern,IsFromType)
 {
  return{
   FileName:FileName,
   StartLine:StartLine,
   StartColumn:StartColumn,
   EndLine:EndLine,
   EndColumn:EndColumn,
   IsFromDefinition:IsFromDefinition,
   IsFromAttribute:IsFromAttribute,
   IsFromComputationExpression:IsFromComputationExpression,
   IsFromDispatchSlotImplementation:IsFromDispatchSlotImplementation,
   IsFromPattern:IsFromPattern,
   IsFromType:IsFromType
  };
 };
 SymbolUseResponse.New=function(Name,Uses)
 {
  return{
   Name:Name,
   Uses:Uses
  };
 };
 HelpTextResponse.New=function(Name,Overloads)
 {
  return{
   Name:Name,
   Overloads:Overloads
  };
 };
 CompilerLocationResponse.New=function(Fsc,Fsi,MSBuild)
 {
  return{
   Fsc:Fsc,
   Fsi:Fsi,
   MSBuild:MSBuild
  };
 };
 FSharpErrorInfo.New=function(FileName,StartLine,EndLine,StartColumn,EndColumn,Message,Subcategory)
 {
  return{
   FileName:FileName,
   StartLine:StartLine,
   EndLine:EndLine,
   StartColumn:StartColumn,
   EndColumn:EndColumn,
   Message:Message,
   Subcategory:Subcategory
  };
 };
 ErrorResponse.New=function(File,Errors)
 {
  return{
   File:File,
   Errors:Errors
  };
 };
 Colorization.New=function(Range$1,Kind)
 {
  return{
   Range:Range$1,
   Kind:Kind
  };
 };
 Declaration.New=function(UniqueName,Name,Glyph,GlyphChar,IsTopLevel,Range$1,BodyRange,File,EnclosingEntity,IsAbstract)
 {
  return{
   UniqueName:UniqueName,
   Name:Name,
   Glyph:Glyph,
   GlyphChar:GlyphChar,
   IsTopLevel:IsTopLevel,
   Range:Range$1,
   BodyRange:BodyRange,
   File:File,
   EnclosingEntity:EnclosingEntity,
   IsAbstract:IsAbstract
  };
 };
 DeclarationResponse.New=function(Declaration$1,Nested)
 {
  return{
   Declaration:Declaration$1,
   Nested:Nested
  };
 };
 OpenNamespace.New=function(Namespace,Name,Type,Line,Column,MultipleNames)
 {
  return{
   Namespace:Namespace,
   Name:Name,
   Type:Type,
   Line:Line,
   Column:Column,
   MultipleNames:MultipleNames
  };
 };
 QualifySymbol.New=function(Name,Qualifier)
 {
  return{
   Name:Name,
   Qualifier:Qualifier
  };
 };
 ResolveNamespaceResponse.New=function(Opens,Qualifies,Word)
 {
  return{
   Opens:Opens,
   Qualifies:Qualifies,
   Word:Word
  };
 };
 UnionCaseResponse.New=function(Text,Position$1)
 {
  return{
   Text:Text,
   Position:Position$1
  };
 };
 ACMessage.ACMIdentification={
  $:0
 };
 FSAutoCompleteClient=FSAutoComplete.FSAutoCompleteClient=Runtime.Class({
  info2Bool:function(inf)
  {
   return inf.$==0&&(inf.$0==="true"&&true);
  },
  errors2String:function(errs)
  {
   return errs.$==7?Strings.concat("\n",Seq.map(function(er)
   {
    return((((((((Runtime.Curried(function($1,$2,$3,$4,$5,$6,$7,$8)
    {
     return $1("ErrFSharp \"F# "+PrintfHelpers.toSafe($2)+".fsx ("+window.String($3)+","+window.String($4)+") - ("+window.String($5)+","+window.String($6)+") "+PrintfHelpers.toSafe($7)+":"+PrintfHelpers.toSafe($8)+"\"");
    },8))(window.id))(er.FileName))(er.StartLine))(er.StartColumn))(er.EndLine))(er.EndColumn))(er.Subcategory))(er.Message);
   },errs.$0.Errors)):(function($1)
   {
    return function($2)
    {
     return $1(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_GeneratedPrintf.p$2($2));
    };
   }(window.id))(errs);
  },
  tip2String:function(tip)
  {
   return tip.$==11?Strings.concat("\n",Seq.collect(function(t)
   {
    return List.ofArray([t.Signature,t.Comment]);
   },tip.$0)):(function($1)
   {
    return function($2)
    {
     return $1(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_GeneratedPrintf.p$2($2));
    };
   }(window.id))(tip);
  },
  comp2Strings:function(comp)
  {
   var $this;
   $this=this;
   return comp.$==3?Arrays.map(function(cs)
   {
    return[cs.Name,cs.ReplacementText,cs.Glyph,cs.GlyphChar];
   },comp.$0):comp.$==2?[]:comp.$==16?Arrays.collect(function(c)
   {
    return $this.comp2Strings(c);
   },comp.$0):[[(function($1)
   {
    return function($2)
    {
     return $1(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_GeneratedPrintf.p$2($2));
    };
   }(window.id))(comp),"","ErrorMsg","E"]];
  },
  Async_map:function(f,aa)
  {
   var b;
   b=null;
   return Concurrency.Delay(function()
   {
    return Concurrency.Bind(aa,function(a)
    {
     return Concurrency.Return(f(a));
    });
   });
  },
  sendMessage:function(msg)
  {
   var $this,g,b;
   $this=this;
   return Wrap.getAsyncWithDefault((g=function(a)
   {
    return{
     $:1,
     $0:a
    };
   },function(x)
   {
    return g(Result.getMessages(x));
   }),(b=Wrap.wrapper(),b.Delay(function()
   {
    return b.Bind$2($this.msgClient.SendMessage($this.toId,JSON.stringify((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$7())(msg))),function(a)
    {
     return b.Return((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$7())(JSON.parse(a)));
    });
   })));
  },
  Complete:function(fname,line,col,sId)
  {
   var $this;
   $this=this;
   return $this.Async_map(function(c)
   {
    return $this.comp2Strings(c);
   },this.sendMessage({
    $:5,
    $0:fname,
    $1:line,
    $2:col,
    $3:sId
   }));
  },
  Complete$1:function(fname,line,col)
  {
   var $this;
   $this=this;
   return $this.Async_map(function(c)
   {
    return $this.comp2Strings(c);
   },this.sendMessage({
    $:4,
    $0:fname,
    $1:line,
    $2:col
   }));
  },
  ToolTip:function(fname,line,col,sId)
  {
   var $this;
   $this=this;
   return $this.Async_map(function(t)
   {
    return $this.tip2String(t);
   },this.sendMessage({
    $:3,
    $0:fname,
    $1:line,
    $2:col,
    $3:sId
   }));
  },
  ToolTip$1:function(fname,line,col)
  {
   var $this;
   $this=this;
   return $this.Async_map(function(t)
   {
    return $this.tip2String(t);
   },this.sendMessage({
    $:2,
    $0:fname,
    $1:line,
    $2:col
   }));
  },
  Parse:function(fname,txt)
  {
   var $this;
   $this=this;
   return $this.Async_map(function(e)
   {
    return $this.errors2String(e);
   },this.sendMessage({
    $:6,
    $0:fname,
    $1:txt,
    $2:[]
   }));
  },
  Parse$1:function(fname,txt,sts)
  {
   var $this;
   $this=this;
   return $this.Async_map(function(e)
   {
    return $this.errors2String(e);
   },this.sendMessage({
    $:6,
    $0:fname,
    $1:txt,
    $2:sts
   }));
  },
  MustParse:function(fname,sId)
  {
   var $this;
   $this=this;
   return $this.Async_map(function(i)
   {
    return $this.info2Bool(i);
   },this.sendMessage({
    $:7,
    $0:fname,
    $1:sId
   }));
  }
 },null,FSAutoCompleteClient);
 FSAutoCompleteClient.New=Runtime.Ctor(function(clientId)
 {
  this.msgClient=new MessagingClient.New(clientId,null,null);
  this.toId={
   $:0,
   $0:"FSAutoComplete"
  };
 },FSAutoCompleteClient);
 HelperType.HelperType={
  $:0
 };
 HelperType.op_AmpGreater=function(_arg13,vw)
 {
  return{
   $:2,
   $0:vw
  };
 };
 HelperType.op_AmpGreater$1=function(_arg12,vr)
 {
  return{
   $:1,
   $0:vr
  };
 };
 HelperType.op_AmpGreater$2=function(_arg11,va)
 {
  return va;
 };
 HelperType.op_AmpGreater$3=function(_arg10,va)
 {
  return va;
 };
 HelperType.op_AmpGreater$4=function(_arg9,va)
 {
  return va;
 };
 HelperType.op_AmpGreater$5=function(_arg8,va)
 {
  return va;
 };
 HelperType.op_AmpGreater$6=function(_arg7,va)
 {
  return va;
 };
 HelperType.op_AmpGreater$7=function(_arg6,va)
 {
  return va;
 };
 HelperType.op_AmpGreater$8=function(_arg5,a)
 {
  return{
   $:0,
   $0:a
  };
 };
 HelperType.op_AmpGreater$9=function(_arg4,a)
 {
  return{
   $:0,
   $0:a
  };
 };
 HelperType.op_AmpGreater$10=function(_arg3,a)
 {
  return{
   $:0,
   $0:a
  };
 };
 HelperType.op_AmpGreater$11=function(_arg2,a)
 {
  return{
   $:0,
   $0:a
  };
 };
 HelperType.op_AmpGreater$12=function(_arg1,a)
 {
  return{
   $:0,
   $0:a
  };
 };
 Val.fixit=function(v)
 {
  return Val.fixit2(v);
 };
 Val.iter4=function(f,v1,v2,v3,v4)
 {
  Val.iterV(function()
  {
  },Val.map4(f,v1,v2,v3,v4));
 };
 Val.iter3=function(f,v1,v2,v3)
 {
  Val.iterV(function()
  {
  },Val.map3(f,v1,v2,v3));
 };
 Val.iter2=function(f,v1,v2)
 {
  Val.iterV(function()
  {
  },Val.map2(f,v1,v2));
 };
 Val.sink=function(f,v)
 {
  View.Sink(f,Val.toView(Val.fixit(v)));
 };
 Val.map4=function(f,v1,v2,v3,v4)
 {
  return Val.map4V(f,Val.fixit(v1),Val.fixit(v2),Val.fixit(v3),Val.fixit(v4));
 };
 Val.map3=function(f,v1,v2,v3)
 {
  return Val.map3V(f,Val.fixit(v1),Val.fixit(v2),Val.fixit(v3));
 };
 Val.map2=function(f,v1,v2)
 {
  return((Val.map2V(f))(Val.fixit(v1)))(Val.fixit(v2));
 };
 Val.map=function(f,v)
 {
  return Val.mapV(f,Val.fixit(v));
 };
 Val.bind=function(f,v)
 {
  return Val.bindV(f,Val.fixit(v));
 };
 Val.iter=function(f,v)
 {
  Val.iterV(f,Val.fixit(v));
 };
 Val.toDoc=function(v)
 {
  return Doc.EmbedView(Val.toView(Val.fixit(v)));
 };
 Val.fixit2=function(v)
 {
  return typeof v=="function"?{
   $:2,
   $0:v
  }:typeof v=="object"?typeof v.$!="undefined"?v:typeof v.Id=="number"||typeof v.i=="number"||typeof(v.RView=="function")?{
   $:1,
   $0:v
  }:typeof v.docNode!="undefined"?{
   $:0,
   $0:v
  }:{
   $:2,
   $0:v
  }:{
   $:0,
   $0:v
  };
 };
 Val.attrV=function(att,va)
 {
  return va.$==2?AttrModule.Dynamic(att,va.$0):va.$==1?AttrModule.Dynamic(att,va.$0.RView()):AttrProxy.Create(att,va.$0);
 };
 Val.tagElt=function(tag,va)
 {
  return va.$==2?Doc.EmbedView(View.Map(tag,va.$0)):va.$==1?Doc.EmbedView(View.Map(tag,va.$0.RView())):tag(va.$0);
 };
 Val.tagDoc=function(tag,va)
 {
  return va.$==2?Doc.EmbedView(View.Map(tag,va.$0)):va.$==1?Doc.EmbedView(View.Map(tag,va.$0.RView())):tag(va.$0);
 };
 Val.map4V=function(f3,v1,v2,v3,v4)
 {
  var x;
  x=Val.map3V(f3,v1,v2,v3);
  return((Val.map2V(function(a)
  {
   return function(f)
   {
    return f(a);
   };
  }))(v4))(x);
 };
 Val.map3V=function(f3,v1,v2,v3)
 {
  var x;
  x=((Val.map2V(f3))(v1))(v2);
  return((Val.map2V(function(a)
  {
   return function(f)
   {
    return f(a);
   };
  }))(v3))(x);
 };
 Val.map2V=function(f)
 {
  var swap,$1;
  swap=function(f$1,a,b)
  {
   return(f$1(b))(a);
  };
  $1=function(vb)
  {
   var f$1,$2;
   f$1=($2=function(x)
   {
    var $3;
    $3=f(x);
    return function($4)
    {
     return Val.mapV($3,$4);
    };
   },function($3)
   {
    return swap($2,vb,$3);
   });
   return function(v)
   {
    return Val.bindV(f$1,v);
   };
  };
  return(Runtime.Curried3(swap))($1);
 };
 Val.bindV=function(f,v)
 {
  return v.$==2?{
   $:2,
   $0:View.Bind(function(x)
   {
    return Val.toView(f(x));
   },v.$0)
  }:v.$==1?{
   $:2,
   $0:View.Bind(function(x)
   {
    return Val.toView(f(x));
   },v.$0.RView())
  }:f(v.$0);
 };
 Val.toView=function(v)
 {
  return v.$==2?v.$0:v.$==1?v.$0.RView():View.Const(v.$0);
 };
 Val.iterV=function(f,va)
 {
  if(va.$==2)
   View.Get(f,va.$0);
  else
   if(va.$==1)
    f(va.$0.RVal());
   else
    f(va.$0);
 };
 Val.mapV=function(f,va)
 {
  return va.$==2?{
   $:2,
   $0:View.Map(f,va.$0)
  }:va.$==1?{
   $:2,
   $0:View.Map(f,va.$0.RView())
  }:{
   $:0,
   $0:f(va.$0)
  };
 };
 HtmlNode$1=HtmlNode.HtmlNode=Runtime.Class({
  Style:function(sty)
  {
   return this.AddChildren([HtmlNode.style(sty)]);
  },
  InsertChildren:function(add)
  {
   return HtmlNode.mapHtmlElement(function(n)
   {
    return function(ch)
    {
     return[n,Seq.append(add,ch)];
    };
   },this);
  },
  AddChildren:function(add)
  {
   return HtmlNode.mapHtmlElement(function(n)
   {
    return function(ch)
    {
     return[n,Seq.append(ch,add)];
    };
   },this);
  },
  get_toDoc:function()
  {
   var $1,x,v;
   return this.$==1||this.$==3&&true?Doc.Empty():(x=HtmlNode.chooseNode(this),(v=Doc.Empty(),x==null?v:x.$0));
  }
 },null,HtmlNode$1);
 HtmlNode$1.HtmlEmpty=new HtmlNode$1({
  $:3
 });
 HtmlNode.findRootElement=function(e)
 {
  var root;
  root=e.getRootNode();
  return!root.body?root.firstChild:root.body;
 };
 HtmlNode.createIFrame=function(f)
 {
  var cover;
  cover=Var.Create$1(true);
  return HtmlNode.div([HtmlNode.style("position: relative; overflow: hidden; height: 100%; width: 100%;"),HtmlNode.iframe([HtmlNode.style("position: absolute; width:100%; height:100%;"),HtmlNode.frameborder("0"),new HtmlNode$1({
   $:6,
   $0:AttrModule.OnAfterRender(f)
  }),new HtmlNode$1({
   $:6,
   $0:AttrModule.Handler("mouseleave",function()
   {
    return function()
    {
     return Var.Set(cover,true);
    };
   })
  })]),HtmlNode.div([HtmlNode.style("position: absolute;"),HtmlNode.classIf("iframe-cover",Val.map(window.id,cover)),new HtmlNode$1({
   $:6,
   $0:AttrModule.Handler("mouseenter",function()
   {
    return function()
    {
     return View.Get(function(pressed)
     {
      if(!pressed)
       Var.Set(cover,false);
     },Mouse.get_MousePressed());
    };
   })
  })]),HtmlNode.styleH([HtmlNode.htmlText(".iframe-cover { top:0; left:0; right:0; bottom:0; background: blue; opacity: 0.04; z-index: 2; }")])]);
 };
 HtmlNode.bindHElem=function(hElemF,v)
 {
  return new HtmlNode$1({
   $:4,
   $0:Val.map(hElemF,Val.fixit(v))
  });
 };
 HtmlNode.string2Styles=function()
 {
  SC$1.$cctor();
  return SC$1.string2Styles;
 };
 HtmlNode.style2pairs=function(ss)
 {
  return Arrays.map(function(d)
  {
   return[Strings.Trim(Arrays.get(d,0)),Strings.Trim(Arrays.get(d,1))];
  },Arrays.filter(function(d)
  {
   return Arrays.length(d)===2;
  },Arrays.map(function(s)
  {
   return Strings.SplitChars(s,[58],0);
  },Strings.SplitChars(ss,[59],0))));
 };
 HtmlNode.xclass=function(v)
 {
  var m,cv;
  return new HtmlNode$1({
   $:6,
   $0:(m=Val.fixit(v),m.$==2?AttrModule.DynamicClass("class_for_view_not_implemented",m.$0,function(y)
   {
    return""!==y;
   }):m.$==1?(cv=m.$0,AttrModule.DynamicClass(cv.RVal(),cv.RView(),function(y)
   {
    return""!==y;
   })):AttrModule.Class(m.$0))
  });
 };
 HtmlNode.classIf=function(cls,v)
 {
  return HtmlNode["class"](Val.map(function(b)
  {
   return b?cls:"";
  },Val.fixit(v)));
 };
 HtmlNode.css=function(v)
 {
  return HtmlNode.styleH([HtmlNode.htmlText(v)]);
 };
 HtmlNode.style1=function(n,v)
 {
  var x;
  return HtmlNode.style(Val.map((x=n+":",function(y)
  {
   return x+y;
  }),v));
 };
 HtmlNode.style=function(v)
 {
  return HtmlNode.htmlAttribute("style",v);
 };
 HtmlNode.draggable=function(v)
 {
  return HtmlNode.htmlAttribute("draggable",v);
 };
 HtmlNode.spellcheck=function(v)
 {
  return HtmlNode.htmlAttribute("spellcheck",v);
 };
 HtmlNode.frameborder=function(v)
 {
  return HtmlNode.htmlAttribute("frameborder",v);
 };
 HtmlNode.Id=function(v)
 {
  return HtmlNode.htmlAttribute("id",v);
 };
 HtmlNode.title=function(v)
 {
  return HtmlNode.htmlAttribute("title",v);
 };
 HtmlNode.width=function(v)
 {
  return HtmlNode.htmlAttribute("width",v);
 };
 HtmlNode.type=function(v)
 {
  return HtmlNode.htmlAttribute("type",v);
 };
 HtmlNode["class"]=function(v)
 {
  return HtmlNode.htmlAttribute("class",v);
 };
 HtmlNode.src=function(v)
 {
  return HtmlNode.htmlAttribute("src",v);
 };
 HtmlNode.rel=function(v)
 {
  return HtmlNode.htmlAttribute("rel",v);
 };
 HtmlNode.href=function(v)
 {
  return HtmlNode.htmlAttribute("href",v);
 };
 HtmlNode.body=function(ch)
 {
  return HtmlNode.htmlElement("body",ch);
 };
 HtmlNode.iframe=function(at)
 {
  return HtmlNode.htmlElement("iframe",at);
 };
 HtmlNode.link=function(sc)
 {
  return HtmlNode.htmlElement("link",sc);
 };
 HtmlNode.fieldset=function(ch)
 {
  return HtmlNode.htmlElement("fieldset",ch);
 };
 HtmlNode.styleH=function(st)
 {
  return HtmlNode.htmlElement("style",st);
 };
 HtmlNode.script=function(sc)
 {
  return HtmlNode.htmlElement("script",sc);
 };
 HtmlNode.button=function(ch)
 {
  return HtmlNode.htmlElement("button",ch);
 };
 HtmlNode.label=function(ch)
 {
  return HtmlNode.htmlElement("label",ch);
 };
 HtmlNode.tbody=function(ch)
 {
  return HtmlNode.htmlElement("tbody",ch);
 };
 HtmlNode.td=function(ch)
 {
  return HtmlNode.htmlElement("td",ch);
 };
 HtmlNode.tr=function(ch)
 {
  return HtmlNode.htmlElement("tr",ch);
 };
 HtmlNode.th=function(ch)
 {
  return HtmlNode.htmlElement("th",ch);
 };
 HtmlNode.thead=function(ch)
 {
  return HtmlNode.htmlElement("thead",ch);
 };
 HtmlNode.table=function(ch)
 {
  return HtmlNode.htmlElement("table",ch);
 };
 HtmlNode.form=function(ch)
 {
  return HtmlNode.htmlElement("form",ch);
 };
 HtmlNode.span=function(ch)
 {
  return HtmlNode.htmlElement("span",ch);
 };
 HtmlNode.img=function(ch)
 {
  return HtmlNode.htmlElement("img",ch);
 };
 HtmlNode.div=function(ch)
 {
  return HtmlNode.htmlElement("div",ch);
 };
 HtmlNode.h6=function(ch)
 {
  return HtmlNode.htmlElement("h6",ch);
 };
 HtmlNode.h5=function(ch)
 {
  return HtmlNode.htmlElement("h5",ch);
 };
 HtmlNode.h4=function(ch)
 {
  return HtmlNode.htmlElement("h4",ch);
 };
 HtmlNode.h3=function(ch)
 {
  return HtmlNode.htmlElement("h3",ch);
 };
 HtmlNode.h2=function(ch)
 {
  return HtmlNode.htmlElement("h2",ch);
 };
 HtmlNode.h1=function(ch)
 {
  return HtmlNode.htmlElement("h1",ch);
 };
 HtmlNode.hr=function(ch)
 {
  return HtmlNode.htmlElement("hr",ch);
 };
 HtmlNode.br=function(ch)
 {
  return HtmlNode.htmlElement("br",ch);
 };
 HtmlNode.li=function(ch)
 {
  return HtmlNode.htmlElement("li",ch);
 };
 HtmlNode.ul=function(ch)
 {
  return HtmlNode.htmlElement("ul",ch);
 };
 HtmlNode.someElt=function(elt)
 {
  return new HtmlNode$1({
   $:5,
   $0:elt
  });
 };
 HtmlNode.htmlText=function(txt)
 {
  return new HtmlNode$1({
   $:2,
   $0:Val.fixit(txt)
  });
 };
 HtmlNode.htmlAttribute=function(name,v)
 {
  return new HtmlNode$1({
   $:1,
   $0:name,
   $1:Val.fixit(v)
  });
 };
 HtmlNode.htmlElement=function(name,ch)
 {
  return new HtmlNode$1({
   $:0,
   $0:name,
   $1:ch
  });
 };
 HtmlNode.textV=function(v)
 {
  return HtmlNode.tag(Doc.TextNode,v);
 };
 HtmlNode._placeholder=function(v)
 {
  return HtmlNode.atr("placeholder",v);
 };
 HtmlNode._style=function(v)
 {
  return HtmlNode.atr("style",v);
 };
 HtmlNode._type=function(v)
 {
  return HtmlNode.atr("type",v);
 };
 HtmlNode._class=function(v)
 {
  return HtmlNode.atr("class",v);
 };
 HtmlNode.tag=function(tag,v)
 {
  return Val.tagDoc(tag,Val.fixit(v));
 };
 HtmlNode.atr=function(att,v)
 {
  return Val.attrV(att,Val.fixit(v));
 };
 HtmlNode.renderDoc=function()
 {
  SC$1.$cctor();
  return SC$1.renderDoc;
 };
 HtmlNode.replaceAtt=function(att,node,newVal)
 {
  return HtmlNode.mapHtmlElement(function(n)
  {
   return function(ch)
   {
    return[n,HtmlNode.replaceAttribute(att,ch,newVal)];
   };
  },node);
 };
 HtmlNode.replaceAttribute=function(att,children,newVal)
 {
  return new List.T({
   $:1,
   $0:new HtmlNode$1({
    $:1,
    $0:att,
    $1:newVal
   }),
   $1:List.ofSeq(Seq.filter(function(a)
   {
    return a.$==1?a.$0===att?false:true:true;
   },children))
  });
 };
 HtmlNode.mapHtmlElement=function(f,element)
 {
  var t;
  return element.$==0?(t=(f(element.$0))(element.$1),new HtmlNode$1({
   $:0,
   $0:t[0],
   $1:t[1]
  })):element.$==4?new HtmlNode$1({
   $:4,
   $0:Val.map(function(e)
   {
    return HtmlNode.mapHtmlElement(f,e);
   },element.$0)
  }):element;
 };
 HtmlNode.getAttrChildren=function(attr)
 {
  var f,c,g,v;
  f=(c=function(a)
  {
   var $1;
   return a.$==1&&(a.$0===attr&&($1=[a.$0,a.$1],true))?{
    $:1,
    $0:$1[1]
   }:null;
  },function(s)
  {
   return Seq.tryPick(c,s);
  });
  g=(v={
   $:0,
   $0:""
  },function(o)
  {
   return o==null?v:o.$0;
  });
  return function(x)
  {
   return g(f(x));
  };
 };
 HtmlNode.chooseNode=function(node)
 {
  var children,x,g,v;
  return node.$==0?(children=node.$1,{
   $:1,
   $0:Doc.Element(node.$0,HtmlNode.getAttrsFromSeq(children),Seq.choose(HtmlNode.chooseNode,children))
  }):node.$==2?{
   $:1,
   $0:Val.tagDoc(Doc.TextNode,node.$0)
  }:node.$==5?{
   $:1,
   $0:node.$0
  }:node.$==4?{
   $:1,
   $0:(x=Val.toView(node.$0),Doc.BindView((g=(v=Doc.Empty(),function(o)
   {
    return o==null?v:o.$0;
   }),function(x$1)
   {
    return g(HtmlNode.chooseNode(x$1));
   }),x))
  }:null;
 };
 HtmlNode.getAttrsFromSeq=function(children)
 {
  var x;
  x=Seq.choose(HtmlNode.chooseAttr,children);
  return Seq.append(List.choose(window.id,List.ofArray([HtmlNode.groupAttr("class"," ",children),HtmlNode.groupAttr("style","; ",children)])),x);
 };
 HtmlNode.groupAttr=function(name,sep,children)
 {
  var ss,r,f;
  ss=Seq.choose(function(n)
  {
   return HtmlNode.chooseThisAttr(name,n);
  },children);
  return Seq.isEmpty(ss)?null:{
   $:1,
   $0:Val.attrV(name,(r=(f=function(a,b)
   {
    return HtmlNode.concat(sep,a,b);
   },(Runtime.Curried3(Val.map2))(function($1)
   {
    return function($2)
    {
     return f($1,$2);
    };
   })),Seq.reduce(function($1,$2)
   {
    return(r($1))($2);
   },ss)))
  };
 };
 HtmlNode.concat=function(s,a,b)
 {
  return a+s+b;
 };
 HtmlNode.chooseThisAttr=function(_this,node)
 {
  var $1;
  return node.$==1&&(node.$0===_this&&($1=[node.$0,node.$1],true))?{
   $:1,
   $0:$1[1]
  }:null;
 };
 HtmlNode.chooseAttr=function(node)
 {
  var $1,name;
  return node.$==1&&((name=node.$0,name!=="class"&&name!=="style")&&($1=[node.$0,node.$1],true))?{
   $:1,
   $0:Val.attrV($1[0],$1[1])
  }:node.$==6?{
   $:1,
   $0:node.$0
  }:null;
 };
 HtmlNode.callAddClass=function()
 {
  SC$1.$cctor();
  return SC$1.callAddClass;
 };
 HtmlNode.removeClass=function(classes,rem)
 {
  return Strings.concat(" ",(new FSharpSet.New$1(BalancedTree.OfSeq(Strings.SplitChars(classes,[32],0)))).Remove(rem));
 };
 HtmlNode.addClass=function(classes,add)
 {
  var x;
  return Strings.concat(" ",(x=new FSharpSet.New$1(BalancedTree.OfSeq(Strings.SplitChars(classes,[32],0))),new FSharpSet.New$1(BalancedTree.OfSeq(Seq.append(new FSharpSet.New$1(BalancedTree.OfSeq(Strings.SplitChars(add,[32],0))),x)))));
 };
 Button=Template.Button=Runtime.Class({
  OnClick:function(f)
  {
   return Button.New(this._class,this._type,this.style,this.text,f,this.disabled,this.id);
  },
  Disabled:function(dis)
  {
   return Button.New(this._class,this._type,this.style,this.text,this.onClick,Val.fixit(dis),this.id);
  },
  Text:function(txt)
  {
   return Button.New(this._class,this._type,this.style,Val.fixit(txt),this.onClick,this.disabled,this.id);
  },
  Style:function(sty)
  {
   return Button.New(this._class,this._type,Val.fixit(sty),this.text,this.onClick,this.disabled,this.id);
  },
  Type:function(typ)
  {
   return Button.New(this._class,Val.fixit(typ),this.style,this.text,this.onClick,this.disabled,this.id);
  },
  Class:function(clas)
  {
   return Button.New(Val.fixit(clas),this._type,this.style,this.text,this.onClick,this.disabled,this.id);
  },
  Id:function(id)
  {
   return Button.New(this._class,this._type,this.style,this.text,this.onClick,this.disabled,id);
  },
  get_Render:function()
  {
   var view;
   return HtmlNode.button([HtmlNode.type(this._type),HtmlNode["class"](this._class),HtmlNode.Id(this.id),HtmlNode.style(this.style),new HtmlNode$1({
    $:6,
    $0:(view=View.Const(""),AttrModule.DynamicPred("disabled",Val.toView(this.disabled),view))
   }),new HtmlNode$1({
    $:6,
    $0:AttrProxy.Handler("click",this.onClick)
   }),new HtmlNode$1({
    $:2,
    $0:this.text
   })]);
  }
 },null,Button);
 Button.New$1=function(txt)
 {
  return Button.New(Val.fixit("btn"),Val.fixit("button"),Val.fixit(""),Val.fixit(txt),function()
  {
   return function()
   {
    return null;
   };
  },Val.fixit(false),"");
 };
 Button.New=function(_class,_type,style,text,onClick,disabled,id)
 {
  return new Button({
   _class:_class,
   _type:_type,
   style:style,
   text:text,
   onClick:onClick,
   disabled:disabled,
   id:id
  });
 };
 Input=Template.Input=Runtime.Class({
  get_Var:function()
  {
   return this["var"];
  },
  SetVar:function(v)
  {
   return Input.New(this._type,this._class,this.style,this.placeholder,this.id,v,this.prefix,this.suffix,this.content,this.prefixAdded,this.suffixAdded);
  },
  Suffix:function(s)
  {
   return Input.New(this._type,this._class,this.style,this.placeholder,this.id,this["var"],this.prefix,s,this.content,this.prefixAdded,true);
  },
  Prefix:function(p)
  {
   return Input.New(this._type,this._class,this.style,this.placeholder,this.id,this["var"],p,this.suffix,this.content,true,this.suffixAdded);
  },
  Content:function(c)
  {
   return Input.New(this._type,this._class,this.style,this.placeholder,this.id,this["var"],this.prefix,this.suffix,c,this.prefixAdded,this.suffixAdded);
  },
  Id:function(id)
  {
   return Input.New(this._type,this._class,this.style,this.placeholder,id,this["var"],this.prefix,this.suffix,this.content,this.prefixAdded,this.suffixAdded);
  },
  Placeholder:function(plc)
  {
   return Input.New(this._type,this._class,this.style,Val.fixit(plc),this.id,this["var"],this.prefix,this.suffix,this.content,this.prefixAdded,this.suffixAdded);
  },
  Style:function(sty)
  {
   return Input.New(this._type,this._class,Val.fixit(sty),this.placeholder,this.id,this["var"],this.prefix,this.suffix,this.content,this.prefixAdded,this.suffixAdded);
  },
  Type:function(typ)
  {
   return Input.New(Val.fixit(typ),this._class,this.style,this.placeholder,this.id,this["var"],this.prefix,this.suffix,this.content,this.prefixAdded,this.suffixAdded);
  },
  Class:function(clas)
  {
   return Input.New(this._type,Val.fixit(clas),this.style,this.placeholder,this.id,this["var"],this.prefix,this.suffix,this.content,this.prefixAdded,this.suffixAdded);
  },
  get_Render:function()
  {
   var $this,groupClass;
   $this=this;
   groupClass=function(det)
   {
    return det.$==2?"input-group-addon":"input-group-btn";
   };
   return HtmlNode.div(List.ofSeq(Seq.delay(function()
   {
    return Seq.append($this.prefixAdded||$this.suffixAdded?[HtmlNode["class"]("input-group")]:[],Seq.delay(function()
    {
     return Seq.append($this.prefixAdded?[HtmlNode.span([HtmlNode["class"](groupClass($this.prefix)),$this.prefix])]:[],Seq.delay(function()
     {
      return Seq.append([new HtmlNode$1({
       $:5,
       $0:Doc.Input(Seq.append($this.content,List.ofArray([HtmlNode._type($this._type),HtmlNode._class($this._class),HtmlNode._style($this.style),AttrProxy.Create("id",$this.id),HtmlNode._placeholder($this.placeholder)])),$this["var"])
      })],Seq.delay(function()
      {
       return $this.suffixAdded?[HtmlNode.span([HtmlNode["class"](groupClass($this.suffix)),$this.suffix])]:[];
      }));
     }));
    }));
   })));
  }
 },null,Input);
 Input.New$1=function(v)
 {
  return Input.New$2(Var.Create$1(v));
 };
 Input.New$2=function(_var)
 {
  var c;
  c=Val.fixit("form-control");
  return Input.New(Val.fixit("text"),c,Val.fixit(""),Val.fixit("Enter text:"),"",_var,HtmlNode$1.HtmlEmpty,HtmlNode$1.HtmlEmpty,List.T.Empty,false,false);
 };
 Input.New=function(_type,_class,style,placeholder,id,_var,prefix,suffix,content,prefixAdded,suffixAdded)
 {
  return new Input({
   _type:_type,
   _class:_class,
   style:style,
   placeholder:placeholder,
   id:id,
   "var":_var,
   prefix:prefix,
   suffix:suffix,
   content:content,
   prefixAdded:prefixAdded,
   suffixAdded:suffixAdded
  });
 };
 Hoverable=Template.Hoverable=Runtime.Class({
  Content:function(c)
  {
   var $this;
   $this=this;
   return c.AddChildren([HtmlNode.classIf("hovering",this.hover),new HtmlNode$1({
    $:6,
    $0:AttrModule.Handler("mouseenter",function()
    {
     return function()
     {
      return $this.hover.set_RVal(true);
     };
    })
   }),new HtmlNode$1({
    $:6,
    $0:AttrModule.Handler("mouseleave",function()
    {
     return function()
     {
      return $this.hover.set_RVal(false);
     };
    })
   })]);
  },
  Content$1:function(c)
  {
   var $this;
   $this=this;
   return HtmlNode.div(Seq.append(c,List.ofArray([HtmlNode.classIf("hovering",this.hover),new HtmlNode$1({
    $:6,
    $0:AttrModule.Handler("mouseenter",function()
    {
     return function()
     {
      return $this.hover.set_RVal(true);
     };
    })
   }),new HtmlNode$1({
    $:6,
    $0:AttrModule.Handler("mouseleave",function()
    {
     return function()
     {
      return $this.hover.set_RVal(false);
     };
    })
   })])));
  }
 },null,Hoverable);
 Hoverable.get_Demo=function()
 {
  return Hoverable.get_New().Content(HtmlNode.div([HtmlNode.style("flex-flow: column;")]));
 };
 Hoverable.get_New=function()
 {
  return Hoverable.New(Var.Create$1(false));
 };
 Hoverable.New=function(hover)
 {
  return new Hoverable({
   hover:hover
  });
 };
 TextArea=Template.TextArea=Runtime.Class({
  get_Var:function()
  {
   return this["var"];
  },
  SetVar:function(v)
  {
   return TextArea.New(this._class,this.placeholder,this.title,this.spellcheck,this.id,v);
  },
  Id:function(id)
  {
   return TextArea.New(this._class,this.placeholder,this.title,this.spellcheck,id,this["var"]);
  },
  Spellcheck:function(spl)
  {
   return TextArea.New(this._class,this.placeholder,this.title,spl,this.id,this["var"]);
  },
  Title:function(ttl)
  {
   return TextArea.New(this._class,this.placeholder,Val.fixit(ttl),this.spellcheck,this.id,this["var"]);
  },
  Placeholder:function(plc)
  {
   return TextArea.New(this._class,Val.fixit(plc),this.title,this.spellcheck,this.id,this["var"]);
  },
  Class:function(clas)
  {
   return TextArea.New(Val.fixit(clas),this.placeholder,this.title,this.spellcheck,this.id,this["var"]);
  },
  get_Render:function()
  {
   return HtmlNode.div([HtmlNode.someElt(Doc.InputArea([HtmlNode._class(this._class),AttrProxy.Create("id",this.id),HtmlNode.atr("spellcheck",Val.map(function(spl)
   {
    return spl?"true":"false";
   },this.spellcheck)),HtmlNode.atr("title",this.title),HtmlNode.atr("style","height: 100%;  width: 100%; box-sizing: border-box; "),HtmlNode._placeholder(this.placeholder)],this["var"]))]);
  }
 },null,TextArea);
 TextArea.New$1=function(v)
 {
  return TextArea.New$2(Var.Create$1(v));
 };
 TextArea.New$2=function(_var)
 {
  return TextArea.New(Val.fixit("form-control"),Val.fixit("Enter text:"),Val.fixit(""),Val.fixit(false),"",_var);
 };
 TextArea.New=function(_class,placeholder,title,spellcheck,id,_var)
 {
  return new TextArea({
   _class:_class,
   placeholder:placeholder,
   title:title,
   spellcheck:spellcheck,
   id:id,
   "var":_var
  });
 };
 CodeMirrorPos.New=function(line,ch)
 {
  return{
   line:line,
   ch:ch
  };
 };
 CodeMirrorEditor=Template.CodeMirrorEditor=Runtime.Class({},null,CodeMirrorEditor);
 CodeMirrorEditor.New=Runtime.Ctor(function()
 {
 },CodeMirrorEditor);
 CodeMirror=Template.CodeMirror=Runtime.Class({
  get_Var:function()
  {
   return this["var"];
  },
  OnRender:function(f)
  {
   return CodeMirror.New(this._class,this.style,this.id,this["var"],this.onChange,{
    $:1,
    $0:f
   },this.editorO);
  },
  OnChange:function(f)
  {
   return CodeMirror.New(this._class,this.style,this.id,this["var"],f,this.onRender,this.editorO);
  },
  Style:function(sty)
  {
   return CodeMirror.New(this._class,Val.fixit(sty),this.id,this["var"],this.onChange,this.onRender,this.editorO);
  },
  SetVar:function(v)
  {
   return CodeMirror.New(this._class,this.style,this.id,v,this.onChange,this.onRender,this.editorO);
  },
  Id:function(id)
  {
   return CodeMirror.New(this._class,this.style,id,this["var"],this.onChange,this.onRender,this.editorO);
  },
  Class:function(clas)
  {
   return CodeMirror.New(Val.fixit(clas),this.style,this.id,this["var"],this.onChange,this.onRender,this.editorO);
  },
  get_Render:function()
  {
   var $this;
   $this=this;
   return HtmlNode.div([HtmlNode["class"](this._class),new HtmlNode$1({
    $:6,
    $0:AttrProxy.Create("id",this.id)
   }),HtmlNode.style("position: relative; height: 300px"),HtmlNode.style(this.style),HtmlNode.div([HtmlNode.style("height: 100%; width: 100%; position: absolute;"),new HtmlNode$1({
    $:6,
    $0:AttrModule.OnAfterRender(function(el)
    {
     window.CIPHERSpaceLoadFiles(Template.codeMirrorIncludes(),function()
     {
      var editor,o,editorChanged,varChanged;
      editor=window.CodeMirror(el,{
       theme:"rubyblue",
       lineNumbers:true,
       matchBrackets:true,
       gutters:["CodeMirror-lint-markers"],
       extraKeys:{
        Tab:function(cm)
        {
         cm.replaceSelection("    ","end");
        },
        F11:function(cm)
        {
         cm.setOption("fullScreen",!cm.getOption("fullScreen"));
        }
       }
      });
      $this.editorO={
       $:1,
       $0:editor
      };
      o=$this.onRender;
      o==null?void 0:o.$0(editor);
      editorChanged=[0];
      varChanged=[0];
      editor.on("changes",function()
      {
       var v;
       v=editor.getValue();
       $this["var"].RVal()!==v?(editorChanged[0]=editorChanged[0]+1,$this["var"].set_RVal(v),$this.onChange()):void 0;
      });
      View.Sink(function()
      {
       if(editorChanged[0]>varChanged[0])
        varChanged[0]=editorChanged[0];
       else
        if(editor.getValue()!==$this["var"].RVal())
         {
          editor.setValue($this["var"].RVal());
          editor.getDoc().clearHistory();
         }
      },$this["var"].RView());
     });
    })
   })]),HtmlNode.link([HtmlNode.href("/EPFileX/codemirror/content/editor.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")]),HtmlNode.link([HtmlNode.href("/EPFileX/codemirror/content/codemirror.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")]),HtmlNode.link([HtmlNode.href("/EPFileX/codemirror/content/theme/rubyblue.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")]),HtmlNode.link([HtmlNode.href("/EPFileX/codemirror/scripts/addon/display/fullscreen.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")]),HtmlNode.link([HtmlNode.href("/EPFileX/codemirror/scripts/addon/dialog/dialog.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")]),HtmlNode.link([HtmlNode.href("/EPFileX/codemirror/scripts/addon/hint/show-hint.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")]),HtmlNode.link([HtmlNode.href("/EPFileX/codemirror/scripts/addon/lint/lint.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")]),HtmlNode.css(".CodeMirror { height: 100% }")]);
  }
 },null,CodeMirror);
 CodeMirror.New$1=function(v)
 {
  return CodeMirror.New$2(Var.Create$1(v));
 };
 CodeMirror.New$2=function(_var)
 {
  return CodeMirror.New(Val.fixit(""),Val.fixit(""),"",_var,function()
  {
  },null,null);
 };
 CodeMirror.New=function(_class,style,id,_var,onChange,onRender,editorO)
 {
  return new CodeMirror({
   _class:_class,
   style:style,
   id:id,
   "var":_var,
   onChange:onChange,
   onRender:onRender,
   editorO:editorO
  });
 };
 Hint.New=function(text,displayText,className)
 {
  return{
   text:text,
   displayText:displayText,
   className:className
  };
 };
 HintResponse.New=function(list,from,to)
 {
  return{
   list:list,
   from:from,
   to:to
  };
 };
 HintOptions.New=function(hint,completeSingle,container)
 {
  return{
   hint:hint,
   completeSingle:completeSingle,
   container:container
  };
 };
 LintResponse.New=function(message,severity,from,to)
 {
  return{
   message:message,
   severity:severity,
   from:from,
   to:to
  };
 };
 SplitterBar=Template.SplitterBar=Runtime.Class({
  Children:function(ch)
  {
   return SplitterBar.New(this.value,this.min,this.max,this.vertical,this.node,ch,this.after,this.dragging,this.startVer,this.startP,this.start,this.size,this.domElem);
  },
  get_After:function()
  {
   return SplitterBar.New(this.value,this.min,this.max,this.vertical,this.node,this.children,true,this.dragging,this.startVer,this.startP,this.start,this.size,this.domElem);
  },
  get_Before:function()
  {
   return SplitterBar.New(this.value,this.min,this.max,this.vertical,this.node,this.children,false,this.dragging,this.startVer,this.startP,this.start,this.size,this.domElem);
  },
  Horizontal:function()
  {
   return SplitterBar.New(this.value,this.min,this.max,Val.fixit(false),this.node,this.children,this.after,this.dragging,this.startVer,this.startP,this.start,this.size,this.domElem);
  },
  Vertical:function()
  {
   return SplitterBar.New(this.value,this.min,this.max,Val.fixit(true),this.node,this.children,this.after,this.dragging,this.startVer,this.startP,this.start,this.size,this.domElem);
  },
  Horizontal$1:function(v)
  {
   return SplitterBar.New(this.value,this.min,this.max,Val.map(function(v$1)
   {
    return!v$1;
   },Val.fixit(v)),this.node,this.children,this.after,this.dragging,this.startVer,this.startP,this.start,this.size,this.domElem);
  },
  Vertical$1:function(v)
  {
   return SplitterBar.New(this.value,this.min,this.max,Val.fixit(v),this.node,this.children,this.after,this.dragging,this.startVer,this.startP,this.start,this.size,this.domElem);
  },
  Max:function(v)
  {
   return SplitterBar.New(this.value,this.min,Val.fixit(v),this.vertical,this.node,this.children,this.after,this.dragging,this.startVer,this.startP,this.start,this.size,this.domElem);
  },
  Min:function(v)
  {
   return SplitterBar.New(this.value,Val.fixit(v),this.max,this.vertical,this.node,this.children,this.after,this.dragging,this.startVer,this.startP,this.start,this.size,this.domElem);
  },
  Node:function(node)
  {
   return SplitterBar.New(this.value,this.min,this.max,this.vertical,node,this.children,this.after,this.dragging,this.startVer,this.startP,this.start,this.size,this.domElem);
  },
  Value:function(v)
  {
   this.value.set_RVal(v);
   return this;
  },
  get_Render:function()
  {
   var $this,mouseCoord,size,drag,startDragging;
   function finishDragging()
   {
    if($this.dragging)
     {
      $this.dragging=false;
      window.removeEventListener("mousemove",drag,false);
      window.removeEventListener("mouseup",finishDragging,false);
     }
   }
   $this=this;
   mouseCoord=function(ev)
   {
    return $this.startVer?window.Number(ev.clientX):window.Number(ev.clientY);
   };
   size=function()
   {
    var m;
    m=$this.domElem;
    return m!=null&&m.$==1?$this.startVer?$this.after?m.$0.parentElement.getBoundingClientRect().width:-m.$0.parentElement.getBoundingClientRect().width:$this.after?m.$0.parentElement.getBoundingClientRect().height:-m.$0.parentElement.getBoundingClientRect().height:100;
   };
   drag=function(ev)
   {
    $this.value.set_RVal((mouseCoord(ev)-$this.start)*100/$this.size+$this.startP);
   };
   startDragging=function(a,ev)
   {
    return!$this.dragging?Val.iter(function()
    {
    },Val.map2(function(startP)
    {
     return function(dirV)
     {
      $this.dragging=true;
      $this.startVer=dirV;
      $this.startP=startP;
      $this.start=mouseCoord(ev);
      $this.size=size();
      window.addEventListener("mousemove",drag,false);
      window.addEventListener("mouseup",finishDragging,false);
      return ev.preventDefault();
     };
    },$this.get_GetValue(),$this.vertical)):null;
   };
   return this.node.AddChildren([HtmlNode["class"](Val.map(function(ver)
   {
    return ver?"Vertical":"Horizontal";
   },this.vertical)),new HtmlNode$1({
    $:6,
    $0:AttrModule.Handler("mousedown",function($1)
    {
     return function($2)
     {
      return startDragging($1,$2);
     };
    })
   }),new HtmlNode$1({
    $:6,
    $0:AttrModule.OnAfterRender(function(el)
    {
     $this.domElem={
      $:1,
      $0:el
     };
    })
   }),HtmlNode.css("\r\n                      .Splitter.Vertical   { cursor: col-resize; background-color: #eef ; width : 5px ; margin-left:-7px; }\r\n                      .Splitter.Horizontal { cursor: row-resize; background-color: #eef ; height: 5px ; margin-top :-7px; }\r\n                  ")]).AddChildren(this.children);
  },
  get_GetValue:function()
  {
   var f,f$1;
   f=function(e,e$1)
   {
    return Unchecked.Compare(e,e$1)===-1?e:e$1;
   };
   return Val.map2(function($1)
   {
    return function($2)
    {
     return f($1,$2);
    };
   },this.max,(f$1=function(e,e$1)
   {
    return Unchecked.Compare(e,e$1)===1?e:e$1;
   },Val.map2(function($1)
   {
    return function($2)
    {
     return f$1($1,$2);
    };
   },this.min,this.value)));
  },
  get_Var:function()
  {
   return this.value;
  }
 },null,SplitterBar);
 SplitterBar.New$1=function(value)
 {
  return SplitterBar.New$2(Var.Create$1(value));
 };
 SplitterBar.New$2=function(_var)
 {
  return SplitterBar.New(_var,Val.fixit(5),Val.fixit(95),Val.fixit(true),HtmlNode.div([HtmlNode["class"]("Splitter")]),List.T.Empty,true,false,true,0,0,0,null);
 };
 SplitterBar.New=function(value,min,max,vertical,node,children,after,dragging,startVer,startP,start,size,domElem)
 {
  return new SplitterBar({
   value:value,
   min:min,
   max:max,
   vertical:vertical,
   node:node,
   children:children,
   after:after,
   dragging:dragging,
   startVer:startVer,
   startP:startP,
   start:start,
   size:size,
   domElem:domElem
  });
 };
 Grid=Template.Grid=Runtime.Class({
  get_Render:function()
  {
   return HtmlNode.div(this.GridTemplate());
  },
  GridTemplate:function()
  {
   var $this;
   $this=this;
   return List.ofSeq(Seq.delay(function()
   {
    var m;
    return Seq.append((m=function(area,html)
    {
     return area!=null&&area.$==1?html.AddChildren([HtmlNode.style((function($1)
     {
      return function($2)
      {
       return $1("grid-area: "+PrintfHelpers.toSafe($2));
      };
     }(window.id))(area.$0))]):html;
    },Seq.map(function($1)
    {
     return m($1[0],$1[1]);
    },$this.content)),Seq.delay(function()
    {
     var c;
     return Seq.append((c=function($1,$2)
     {
      var spl;
      return $2.$==2?(spl=$2.$0,{
       $:1,
       $0:spl.get_Render().InsertChildren([HtmlNode.style1("grid-column",window.String($1+(spl.after?2:1))),HtmlNode.style1("grid-row",(function($3)
       {
        return function($4)
        {
         return $3("1 / "+window.String($4));
        };
       }(window.id))(Arrays.length($this.rows)+1))])
      }):$2.$==1?null:null;
     },Seq.choose(function($1)
     {
      return c($1[0],$1[1]);
     },Seq.indexed($this.cols))),Seq.delay(function()
     {
      var c$1;
      return Seq.append((c$1=function($1,$2)
      {
       var spl;
       return $2.$==2?(spl=$2.$0,{
        $:1,
        $0:spl.get_Render().InsertChildren([HtmlNode.style1("grid-row",window.String($1+(spl.after?2:1))),HtmlNode.style1("grid-column",(function($3)
        {
         return function($4)
         {
          return $3("1 / "+window.String($4));
         };
        }(window.id))(Arrays.length($this.cols)+1))])
       }):$2.$==1?null:null;
      },Seq.choose(function($1)
      {
       return c$1($1[0],$1[1]);
      },Seq.indexed($this.rows))),Seq.delay(function()
      {
       return Seq.append($this.styles(),Seq.delay(function()
       {
        return Seq.append([HtmlNode.style((((Runtime.Curried3(function($1,$2,$3)
        {
         return $1("display: grid; grid-gap: "+$2.toFixed(6)+"px; padding: "+$3.toFixed(6)+"px; box-sizing: border-box");
        }))(window.id))($this.gap))($this.padding))],Seq.delay(function()
        {
         return[new HtmlNode$1({
          $:6,
          $0:AttrModule.OnAfterRender(function(el)
          {
           function setDimensions()
           {
            $this.width.set_RVal(el.getBoundingClientRect().width);
            $this.height.set_RVal(el.getBoundingClientRect().height);
           }
           window.setTimeout(setDimensions,60);
           (new window.ResizeObserver(setDimensions)).observe(el);
          })
         })];
        }));
       }));
      }));
     }));
    }));
   }));
  },
  styles:function()
  {
   return List.ofArray([HtmlNode.style1("grid-template-columns",this.style(this.cols,this.width)),HtmlNode.style1("grid-template-rows",this.style(this.rows,this.height))]);
  },
  style:function(areas,size)
  {
   var $this,p,f,finalPerc,autoPct,perc,pixel;
   $this=this;
   return Arrays.length(areas)===0?{
    $:0,
    $0:"100%"
   }:(p=(f=function(pcs,pxs)
   {
    return function(a)
    {
     return a.$==2?[Val.map2(function(x)
     {
      return function(y)
      {
       return x+y;
      };
     },a.$0.get_GetValue(),pcs),pxs]:a.$==1?a.$0.$==1?[pcs,Val.map2(function(x)
     {
      return function(y)
      {
       return x+y;
      };
     },a.$0.$0,pxs)]:[Val.map2(function(x)
     {
      return function(y)
      {
       return x+y;
      };
     },a.$0.$0,pcs),pxs]:[pcs,pxs];
    };
   },Seq.fold(function($1,$2)
   {
    return(function($3)
    {
     return f($3[0],$3[1]);
    }($1))($2);
   },[{
    $:0,
    $0:0
   },{
    $:0,
    $0:0
   }],areas)),(finalPerc=Val.map2(function(v)
   {
    return function(size$1)
    {
     return(size$1-$this.padding*2-$this.gap*(window.Number(Arrays.length(areas))-1)-v)/(size$1-$this.padding*2);
    };
   },p[1],size),(autoPct=Val.map(function(y)
   {
    return 100-y;
   },p[0]),(perc=function(pc)
   {
    return Val.map2(function(finalPerc$1)
    {
     return function(pc$1)
     {
      var x,e,a;
      x=(e=finalPerc$1*pc$1,(a=0,Unchecked.Compare(a,e)===1?a:e));
      return(function($1)
      {
       return function($2)
       {
        return $1($2.toFixed(6)+"%");
       };
      }(window.id))(x);
     };
    },finalPerc,pc);
   },(pixel=function(px)
   {
    return Val.map(function(px$1)
    {
     var x,a;
     x=(a=0,Unchecked.Compare(a,px$1)===1?a:px$1);
     return(function($1)
     {
      return function($2)
      {
       return $1($2.toFixed(6)+"px");
      };
     }(window.id))(x);
    },px);
   },Val.map(function(s)
   {
    return Strings.concat(" ",s);
   },Seq.foldBack(function(a,state)
   {
    var f$1;
    f$1=function(state$1,v)
    {
     return new List.T({
      $:1,
      $0:v,
      $1:state$1
     });
    };
    return Val.map2(function($1)
    {
     return function($2)
     {
      return f$1($1,$2);
     };
    },state,a.$==2?perc(a.$0.get_GetValue()):a.$==1?a.$0.$==1?pixel(a.$0.$0):perc(a.$0.$0):perc(autoPct));
   },areas,{
    $:0,
    $0:List.T.Empty
   })))))));
  },
  Children:function(ch)
  {
   return this.changeSplitter(function(spl)
   {
    return spl.Children(ch);
   });
  },
  Min:function(v)
  {
   return this.changeSplitter(function(spl)
   {
    return spl.Min(v);
   });
  },
  Max:function(v)
  {
   return this.changeSplitter(function(spl)
   {
    return spl.Max(v);
   });
  },
  get_Before:function()
  {
   return this.changeSplitter(function(spl)
   {
    return spl.get_Before();
   });
  },
  changeSplitter:function(f)
  {
   var $this,o;
   $this=this;
   o=this.lastSplitter;
   o==null?void 0:(function(pos,col)
   {
    var m,m$1;
    if(col)
     {
      m=Arrays.get($this.cols,pos);
      m.$==2?Arrays.set($this.cols,pos,{
       $:2,
       $0:f(m.$0)
      }):void 0;
     }
    else
     {
      m$1=Arrays.get($this.rows,pos);
      m$1.$==2?Arrays.set($this.rows,pos,{
       $:2,
       $0:f(m$1.$0)
      }):void 0;
     }
   }).apply(null,o.$0);
   return this;
  },
  Gap:function(f)
  {
   return Grid.New(this.padding,f,this.content,this.cols,this.rows,this.width,this.height,this.lastSplitter);
  },
  Padding:function(f)
  {
   return Grid.New(f,this.gap,this.content,this.cols,this.rows,this.width,this.height,this.lastSplitter);
  },
  Content:function(html)
  {
   return Grid.New(this.padding,this.gap,this.content.concat([[null,html]]),this.cols,this.rows,this.width,this.height,this.lastSplitter);
  },
  Content$1:function(area,html)
  {
   return Grid.New(this.padding,this.gap,this.content.concat([[{
    $:1,
    $0:area
   },html]]),this.cols,this.rows,this.width,this.height,this.lastSplitter);
  },
  RowAuto:function(f)
  {
   return Grid.New(this.padding,this.gap,this.content,this.cols,this.rows.concat([{
    $:0,
    $0:SplitterBar.New$1(f).Horizontal()
   }]),this.width,this.height,this.lastSplitter);
  },
  RowVariable:function(f)
  {
   return this.NewSplitter(f,false);
  },
  RowVariable$1:function(s)
  {
   return Grid.New(this.padding,this.gap,this.content,this.cols,this.rows.concat([{
    $:2,
    $0:s
   }]),this.width,this.height,this.lastSplitter);
  },
  RowFixed:function(f)
  {
   return Grid.New(this.padding,this.gap,this.content,this.cols,this.rows.concat([{
    $:1,
    $0:{
     $:0,
     $0:Val.fixit(f)
    }
   }]),this.width,this.height,this.lastSplitter);
  },
  RowFixedPx:function(f)
  {
   return Grid.New(this.padding,this.gap,this.content,this.cols,this.rows.concat([{
    $:1,
    $0:{
     $:1,
     $0:Val.fixit(f)
    }
   }]),this.width,this.height,this.lastSplitter);
  },
  ColAuto:function(f)
  {
   return Grid.New(this.padding,this.gap,this.content,this.cols.concat([{
    $:0,
    $0:SplitterBar.New$1(f)
   }]),this.rows,this.width,this.height,this.lastSplitter);
  },
  ColVariable:function(f)
  {
   return this.NewSplitter(f,true);
  },
  ColVariable$1:function(s)
  {
   return Grid.New(this.padding,this.gap,this.content,this.cols.concat([{
    $:2,
    $0:s
   }]),this.rows,this.width,this.height,this.lastSplitter);
  },
  ColFixed:function(f)
  {
   return Grid.New(this.padding,this.gap,this.content,this.cols.concat([{
    $:1,
    $0:{
     $:0,
     $0:Val.fixit(f)
    }
   }]),this.rows,this.width,this.height,this.lastSplitter);
  },
  ColFixedPx:function(f)
  {
   return Grid.New(this.padding,this.gap,this.content,this.cols.concat([{
    $:1,
    $0:{
     $:1,
     $0:Val.fixit(f)
    }
   }]),this.rows,this.width,this.height,this.lastSplitter);
  },
  NewSplitter:function(f,col)
  {
   var spl,l,l$1;
   spl=SplitterBar.New$1(f);
   return col?(l={
    $:1,
    $0:[Arrays.length(this.cols),col]
   },Grid.New(this.padding,this.gap,this.content,this.cols.concat([{
    $:2,
    $0:spl
   }]),this.rows,this.width,this.height,l)):(l$1={
    $:1,
    $0:[Arrays.length(this.rows),col]
   },Grid.New(this.padding,this.gap,this.content,this.cols,this.rows.concat([{
    $:2,
    $0:spl.Horizontal()
   }]),this.width,this.height,l$1));
  }
 },null,Grid);
 Grid.get_New=function()
 {
  return Grid.New(9,9,[],[],[],Var.Create$1(1000),Var.Create$1(100),null);
 };
 Grid.New=function(padding,gap,content,cols,rows,width,height,lastSplitter)
 {
  return new Grid({
   padding:padding,
   gap:gap,
   content:content,
   cols:cols,
   rows:rows,
   width:width,
   height:height,
   lastSplitter:lastSplitter
  });
 };
 TabStrip=Template.TabStrip=Runtime.Class({
  get_Render:function()
  {
   var $this,strip,g,content;
   $this=this;
   strip=HtmlNode.bindHElem(function(tabs)
   {
    return HtmlNode.div(List.ofSeq(Seq.delay(function()
    {
     return Seq.append([HtmlNode["class"]((((Runtime.Curried3(function($1,$2,$3)
     {
      return $1("tab-strip "+PrintfHelpers.toSafe($2)+" "+PrintfHelpers.toSafe($3));
     }))(window.id))($this.top?"top":"bottom"))($this.horizontal?"horizontal":"vertical"))],Seq.delay(function()
     {
      return Seq.collect(function(m)
      {
       var i;
       i=m[0];
       return[Hoverable.get_New().Content(HtmlNode.div([HtmlNode.htmlText(m[1][1][0]),HtmlNode["class"](Val.map(function(sel)
       {
        return"tab"+(sel===i?" selected":"");
       },$this.selected)),HtmlNode.draggable("true"),new HtmlNode$1({
        $:6,
        $0:AttrModule.Handler("dragover",function()
        {
         return function(ev)
         {
          return ev.preventDefault();
         };
        })
       }),new HtmlNode$1({
        $:6,
        $0:AttrModule.Handler("drag",function()
        {
         return function()
         {
          (Template.draggedTab())[0]={
           $:1,
           $0:[$this,i]
          };
         };
        })
       }),new HtmlNode$1({
        $:6,
        $0:AttrModule.Handler("drop",function()
        {
         return function(ev)
         {
          ev.preventDefault();
          ev.stopPropagation();
          return $this.reorder(i);
         };
        })
       }),new HtmlNode$1({
        $:6,
        $0:AttrModule.Handler("click",function()
        {
         return function()
         {
          return $this.selected.set_RVal(i);
         };
        })
       })]))];
      },Seq.indexed(tabs));
     }));
    })));
   },this.tabs);
   Val.sink((g=this.id,function(p)
   {
    Template.setSelectedPanel(g,p);
   }),this.get_Selected());
   content=HtmlNode.bindHElem(function(tabs)
   {
    return HtmlNode.div(List.ofSeq(Seq.delay(function()
    {
     return Seq.append([HtmlNode["class"]("tab-children")],Seq.delay(function()
     {
      return Seq.append([HtmlNode.Id(Template.uid2s($this.id))],Seq.delay(function()
      {
       var m;
       m=function(uid,a)
       {
        return a[1].AddChildren([HtmlNode.style(Val.map(function(sels)
        {
         return Seq.contains(uid,Seq.map(function(t)
         {
          return t[1];
         },Map.ToSeq(sels)))?"":"display : none";
        },Template.selectedPanels())),HtmlNode.Id(Template.uid2s(uid))]);
       };
       return Seq.map(function($1)
       {
        return m($1[0],$1[1]);
       },tabs);
      }));
     }));
    })));
   },this.tabs);
   return HtmlNode.div([HtmlNode["class"]("tab-panel"),this.top?strip:HtmlNode$1.HtmlEmpty,HtmlNode.div([content,HtmlNode["class"]("tab-content")]),!this.top?strip:HtmlNode$1.HtmlEmpty,new HtmlNode$1({
    $:6,
    $0:AttrModule.Handler("dragover",function()
    {
     return function(ev)
     {
      return ev.preventDefault();
     };
    })
   }),new HtmlNode$1({
    $:6,
    $0:AttrModule.Handler("drop",function()
    {
     return function(ev)
     {
      ev.preventDefault();
      return $this.reorder(Arrays.length($this.tabs.RVal()));
     };
    })
   }),HtmlNode.css("\r\n      \r\n      .tab-panel {\r\n       overflow : hidden ;\r\n       display  : flex   ;\r\n       flex-flow: column ;\r\n       background: pink    ;\r\n      }\r\n      .tab-content {\r\n       flex      : 1 1     ;\r\n       overflow  : auto    ;\r\n       position  : relative;\r\n      }\r\n      .tab-children {\r\n       height    : 100%    ;\r\n       width     : 100%    ;\r\n       position  : absolute;\r\n       display   : grid    ;\r\n      }\r\n      .tab-strip {\r\n       padding   : 0pt     ;\r\n       flex      : 0 0     ;\r\n      }\r\n      .tab {\r\n       border     : 0.2pt solid transparent;\r\n       padding    : 0pt 4pt;\r\n       display    : inline-block;\r\n       font-family: sans-serif;\r\n       font-weight: 200;\r\n       font-size  : small;\r\n       color      : #666;\r\n       cursor     : pointer;\r\n      }\r\n      .top>.tab {\r\n       border-radius: 2pt 2pt 0pt 0pt;\r\n       border-bottom-width: 0pt;\r\n       vertical-align: bottom;\r\n      }\r\n      .bottom>.tab {\r\n       border-top-width: 0pt;\r\n       border-radius: 0pt 0pt 2pt 2pt;\r\n       vertical-align: top;\r\n      }\r\n      .horizontal>.tab:not(:first-child) {\r\n       border-left-width: 0pt;\r\n      }\r\n      .tab.hovering {\r\n       background: red;\r\n      }\r\n      .tab.selected {\r\n       background: white;\r\n       border-left-width: 0.2pt;\r\n       color: black;\r\n       font-weight: 500;\r\n       border-color: black;\r\n      }\r\n      .horizontal>.tab.selected {\r\n       border-left-width: 0.2pt;\r\n      }\r\n      ")]);
  },
  get_Selected:function()
  {
   return Val.map2(function(tabs)
   {
    return function(sel)
    {
     var o;
     o=Seq.tryItem(sel,tabs);
     return o==null?null:{
      $:1,
      $0:o.$0[0]
     };
    };
   },this.tabs,this.selected);
  },
  get_Vertical:function()
  {
   return TabStrip.New(this.selected,this.tabs,this.top,false,this.id);
  },
  get_Horizontal:function()
  {
   return TabStrip.New(this.selected,this.tabs,this.top,true,this.id);
  },
  get_Bottom:function()
  {
   return TabStrip.New(this.selected,this.tabs,false,this.horizontal,this.id);
  },
  get_Top:function()
  {
   return TabStrip.New(this.selected,this.tabs,true,this.horizontal,this.id);
  },
  reorder:function(drop)
  {
   var drag,sel,m;
   m=(Template.draggedTab())[0];
   if(m!=null&&m.$==1)
   {
    if(!Unchecked.Equals(m.$0[0].id,this.id))
     this.moveTab(m.$0[0],m.$0[1],drop);
    else
     if(m!=null&&m.$==1)
      {
       drag=m.$0[1];
       {
        this.tabs.set_RVal(Template.reorderArray(this.tabs.RVal(),drag,drop));
        sel=this.selected.RVal();
        this.selected.set_RVal(sel===drag?drop:sel<drag&&sel<drop||sel>drag&&sel>drop?sel:sel<drag?sel+1:sel-1);
       }
      }
     else
      throw new MatchFailureException.New("(6)cddabd38-7ecb-4692-99bd-13ca70e4232f TabStrip.fsx",79,20);
   }
   else
    void 0;
  },
  moveTab:function(from,drag,drop)
  {
   var ts,ft,newTabsT,newTabsF;
   ts=this.tabs.RVal();
   ft=from.tabs.RVal();
   newTabsT=Arrays.collect(window.id,[Slice.array(ts,{
    $:1,
    $0:0
   },{
    $:1,
    $0:drop-1
   }),[Arrays.get(ft,drag)],Slice.array(ts,{
    $:1,
    $0:drop
   },{
    $:1,
    $0:Arrays.length(ts)-1
   })]);
   newTabsF=Arrays.collect(window.id,[Slice.array(ft,{
    $:1,
    $0:0
   },{
    $:1,
    $0:drag-1
   }),Slice.array(ft,{
    $:1,
    $0:drag+1
   },{
    $:1,
    $0:Arrays.length(ft)-1
   })]);
   from.tabs.set_RVal(newTabsF);
   this.tabs.set_RVal(newTabsT);
   this.selected.set_RVal(drop);
   from.selected.RVal()>=Arrays.length(newTabsF)?from.selected.set_RVal(0):void 0;
   Template.RaiseTabMoved(from,this);
  }
 },null,TabStrip);
 TabStrip.New$1=function(tabs)
 {
  return TabStrip.New$2(Var.Create$1(Arrays.ofSeq(Seq.map(function(def)
  {
   return[Guid.NewGuid(),def];
  },tabs))));
 };
 TabStrip.New$2=function(tabs)
 {
  return TabStrip.New(Var.Create$1(0),tabs,false,true,Guid.NewGuid());
 };
 TabStrip.New=function(selected,tabs,top,horizontal,id)
 {
  return new TabStrip({
   selected:selected,
   tabs:tabs,
   top:top,
   horizontal:horizontal,
   id:id
  });
 };
 SplitterNode=Template.SplitterNode=Runtime.Class({
  UnSplitEmpties:function()
  {
   var m,ch2,ch1;
   if(this.get_IsEmpty())
    Var.Set(this.get_Var(),SplitterStructure.New$1(TabStrip.New$1([])));
   else
    {
     m=this.get_Value();
     m.$==2?(ch2=m.$1,ch1=m.$0,ch1.get_IsEmpty()?(ch2.UnSplitEmpties(),Var.Set(this.get_Var(),ch2.get_Value())):ch2.get_IsEmpty()?(ch1.UnSplitEmpties(),Var.Set(this.get_Var(),ch1.get_Value())):(ch1.UnSplitEmpties(),ch2.UnSplitEmpties())):void 0;
    }
  },
  get_IsEmpty:function()
  {
   var m;
   m=this.get_Value();
   return m.$==1?Arrays.length(m.$0.tabs.RVal())===0:m.$==2?m.$0.get_IsEmpty()&&m.$1.get_IsEmpty():m.$0.$==3&&true;
  },
  SplitMe:function(first,ver)
  {
   this.SplitMe$2(first,ver,TabStrip.New$1([]));
  },
  SplitMe$1:function(first,ver,node)
  {
   this.SplitMe$3(first,ver,{
    $:0,
    $0:node
   });
  },
  SplitMe$2:function(first,ver,node)
  {
   this.SplitMe$3(first,ver,{
    $:1,
    $0:node
   });
  },
  SplitMe$3:function(first,ver,node)
  {
   Var.Set(this.get_Var(),first?SplitterStructure.New$5(ver,node,this.get_Value()):SplitterStructure.New$5(ver,this.get_Value(),node));
  },
  get_Value:function()
  {
   return this.get_Var().c;
  },
  get_Var:function()
  {
   return this.$0;
  },
  get_Render:function()
  {
   return Template.renderSplitterNode(this);
  }
 },null,SplitterNode);
 SplitterNode.New=function(ss)
 {
  return new SplitterNode({
   $:0,
   $0:Var.Create$1(SplitterStructure.New$1(ss))
  });
 };
 SplitterNode.New$1=function(ss)
 {
  return new SplitterNode({
   $:0,
   $0:Var.Create$1(SplitterStructure.New(ss))
  });
 };
 SplitterNode.New$2=function(ss)
 {
  return new SplitterNode({
   $:0,
   $0:Var.Create$1(ss)
  });
 };
 SplitterStructure.New=function(node)
 {
  return{
   $:0,
   $0:node
  };
 };
 SplitterStructure.New$1=function(strip)
 {
  return{
   $:1,
   $0:strip
  };
 };
 SplitterStructure.New$2=function(ss1,ss2,f)
 {
  return{
   $:2,
   $0:new SplitterNode({
    $:0,
    $0:Var.Create$1(ss1)
   }),
   $1:new SplitterNode({
    $:0,
    $0:Var.Create$1(ss2)
   }),
   $2:f
  };
 };
 SplitterStructure.New$3=function(vertical,child1,child2,per)
 {
  return{
   $:2,
   $0:new SplitterNode({
    $:0,
    $0:Var.Create$1({
     $:1,
     $0:child1
    })
   }),
   $1:new SplitterNode({
    $:0,
    $0:Var.Create$1({
     $:1,
     $0:child2
    })
   }),
   $2:Runtime.Curried(Template.renderSplitter,2,[per,vertical])
  };
 };
 SplitterStructure.New$4=function(vertical,child1,child2,per)
 {
  return{
   $:2,
   $0:new SplitterNode({
    $:0,
    $0:Var.Create$1({
     $:0,
     $0:child1
    })
   }),
   $1:new SplitterNode({
    $:0,
    $0:Var.Create$1({
     $:0,
     $0:child2
    })
   }),
   $2:Runtime.Curried(Template.renderSplitter,2,[per,vertical])
  };
 };
 SplitterStructure.New$5=function(vertical,child1,child2)
 {
  return{
   $:2,
   $0:new SplitterNode({
    $:0,
    $0:Var.Create$1(child1)
   }),
   $1:new SplitterNode({
    $:0,
    $0:Var.Create$1(child2)
   }),
   $2:Runtime.Curried(Template.renderSplitter,2,[50,vertical])
  };
 };
 SplitterStructure.New$6=function(vertical,child1,child2,per)
 {
  return{
   $:2,
   $0:new SplitterNode({
    $:0,
    $0:Var.Create$1(child1)
   }),
   $1:new SplitterNode({
    $:0,
    $0:Var.Create$1(child2)
   }),
   $2:Runtime.Curried(Template.renderSplitter,2,[per,vertical])
  };
 };
 Template.renderSplitter=function(per,ver,ch1,ch2)
 {
  return ver?Grid.get_New().Content$1("one",Template.renderSplitterNode(ch1)).Content$1("two",Template.renderSplitterNode(ch2)).Padding(0).ColVariable(per).ColAuto(50).Content(HtmlNode.style("grid-template-areas: 'one   two' ")).get_Render():Grid.get_New().Content$1("one",Template.renderSplitterNode(ch1)).Content$1("two",Template.renderSplitterNode(ch2)).Padding(0).RowVariable(per).RowAuto(50).Content(HtmlNode.style("grid-template-areas: 'one' 'two' ")).get_Render();
 };
 Template.renderSplitterStructure=function(ss)
 {
  return ss.$==1?ss.$0.get_Render():ss.$==2?(ss.$2(ss.$0))(ss.$1):ss.$0;
 };
 Template.renderSplitterNode=function(sn)
 {
  return HtmlNode.bindHElem(Template.renderSplitterStructure,sn.$0);
 };
 Template.RaiseTabMoved=function(fromS,toS)
 {
  var o;
  o=Template.TabMoved();
  o==null?void 0:o.$0([fromS,toS]);
 };
 Template.TabMoved=function()
 {
  SC$1.$cctor();
  return SC$1.TabMoved;
 };
 Template.set_TabMoved=function($1)
 {
  SC$1.$cctor();
  SC$1.TabMoved=$1;
 };
 Template.setSelectedPanel=function(group,panelO)
 {
  Var.Set(Template.selectedPanels(),panelO==null?Template.selectedPanels().c.Remove(group):Template.selectedPanels().c.Add(group,panelO.$0));
 };
 Template.selectedPanels=function()
 {
  SC$1.$cctor();
  return SC$1.selectedPanels;
 };
 Template.uid2s=function(uid)
 {
  return"X"+Strings.Replace(window.String(uid),"-","");
 };
 Template.draggedTab=function()
 {
  SC$1.$cctor();
  return SC$1.draggedTab;
 };
 Template.reorderArray=function(ts,drag,drop)
 {
  return Arrays.collect(window.id,drop<drag?[Slice.array(ts,{
   $:1,
   $0:0
  },{
   $:1,
   $0:drop-1
  }),[Arrays.get(ts,drag)],Slice.array(ts,{
   $:1,
   $0:drop
  },{
   $:1,
   $0:drag-1
  }),Slice.array(ts,{
   $:1,
   $0:drag+1
  },{
   $:1,
   $0:Arrays.length(ts)-1
  })]:[Slice.array(ts,{
   $:1,
   $0:0
  },{
   $:1,
   $0:drag-1
  }),Slice.array(ts,{
   $:1,
   $0:drag+1
  },{
   $:1,
   $0:drop
  }),[Arrays.get(ts,drag)],Slice.array(ts,{
   $:1,
   $0:drop+1
  },{
   $:1,
   $0:Arrays.length(ts)-1
  })]);
 };
 Template.reorderList=function(ts,drag,drop)
 {
  return drop<drag?List.append(ts.GetSlice({
   $:1,
   $0:0
  },{
   $:1,
   $0:drop-1
  }),List.append(List.ofArray([ts.get_Item(drag)]),List.append(ts.GetSlice({
   $:1,
   $0:drop
  },{
   $:1,
   $0:drag-1
  }),ts.GetSlice({
   $:1,
   $0:drag+1
  },{
   $:1,
   $0:ts.get_Length()-1
  })))):List.append(ts.GetSlice({
   $:1,
   $0:0
  },{
   $:1,
   $0:drag-1
  }),List.append(ts.GetSlice({
   $:1,
   $0:drag+1
  },{
   $:1,
   $0:drop
  }),List.append(List.ofArray([ts.get_Item(drag)]),ts.GetSlice({
   $:1,
   $0:drop+1
  },{
   $:1,
   $0:ts.get_Length()-1
  }))));
 };
 Template.setLint=function(ed,getAnnotations)
 {
  ed.setOption("lint",{
   async:1,
   getAnnotations:Runtime.CreateFuncWithArgs(getAnnotations),
   container:HtmlNode.findRootElement(ed.getWrapperElement())
  });
 };
 Template.showHints=function(ed,getHints,completeSingle,a)
 {
  var v;
  v=HintOptions.New(Runtime.CreateFuncWithArgs(getHints),completeSingle,HtmlNode.findRootElement(ed.getWrapperElement()));
  v.hint.async=1;
  ed.showHint(v);
 };
 Template.cmPos=function(l,c)
 {
  return CodeMirrorPos.New(l,c);
 };
 Template.codeMirrorIncludes=function()
 {
  SC$1.$cctor();
  return SC$1.codeMirrorIncludes;
 };
 EditorRpc.evaluate=function(callback,source)
 {
  EditorRpc.callRPC((new AjaxRemotingProvider.New()).Async("ZafirTranspiler:CIPHERPrototype.Editor.evaluate:-1485533303",[source]),callback);
 };
 EditorRpc.translate=function(callback,minified,source)
 {
  EditorRpc.callRPC((new AjaxRemotingProvider.New()).Async("ZafirTranspiler:CIPHERPrototype.Editor.translate:796244877",[source,minified]),callback);
 };
 EditorRpc.callRPC=function(asy,callback)
 {
  Concurrency.StartWithContinuations(asy,callback,function(e)
  {
   window.alert(window.String(e));
  },function(c)
  {
   window.alert(window.String(c));
  },null);
 };
 RunNode=RunCode.RunNode=Runtime.Class({
  createBaseNode:function()
  {
   var el;
   el=window.document.createElement("div");
   el.setAttribute("id",this.nodeName);
   window.document.body.appendChild(el);
   return el;
  },
  RunHtml:function(node)
  {
   this.RunDoc((HtmlNode.renderDoc())(node));
  },
  RunDoc:function(doc)
  {
   Doc.Run(this.get_RunNode(),doc);
  },
  get_AddBootstrap:function()
  {
   var el;
   el=window.document.createElement("div");
   el.innerHTML="<script src='http://code.jquery.com/jquery-3.1.1.min.js' type='text/javascript' charset='UTF-8'></script>\r\n                  <script src='http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js' type='text/javascript' charset='UTF-8'></script>\r\n                  <link type='text/css' rel='stylesheet' href='http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css'>\r\n                  <link type='text/css' rel='stylesheet' href='/EPFileX/css/main.css'>\r\n                 ";
   this.runNode.appendChild(el);
   return this;
  },
  get_RunNode:function()
  {
   return this.runNode;
  }
 },null,RunNode);
 RunNode.New=Runtime.Ctor(function(clearNode)
 {
  RunNode.New$1.call(this,"TestNode",{
   $:1,
   $0:clearNode==null||clearNode.$0
  });
 },RunNode);
 RunNode.New$1=Runtime.Ctor(function(nodeName,clearNode)
 {
  var baseNode,m,m$1,e;
  this.nodeName=nodeName;
  baseNode=(m=window.document.getElementById(this.nodeName),Unchecked.Equals(m,null)?this.createBaseNode():m);
  this.runNode=(m$1=baseNode.shadowRoot,Unchecked.Equals(m$1,null)?(e=window.document.createElement("div"),(baseNode.attachShadow({
   mode:"open"
  }).appendChild(e),e.style="height: 100%; width: 100%;",e)):m$1.firstChild);
  clearNode==null||clearNode.$0?this.runNode.innerHTML="":void 0;
 },RunNode);
 RunCode.startRPC=function(asy)
 {
  Concurrency.StartWithContinuations(asy,function()
  {
  },function(e)
  {
   window.alert(window.String(e));
  },function(c)
  {
   window.alert(window.String(c));
  },null);
 };
 RunCode.compile=function(fThen,fFail,code)
 {
  var c;
  c=function($1,msgs)
  {
   var a;
   a=$1==null?null:{
    $:1,
    $0:RunCode.completeJS($1.$0)
   };
   a==null?fFail(msgs):fThen(msgs,a.$0);
  };
  EditorRpc.translate(function($1)
  {
   return c($1[0],$1[1]);
  },false,code);
 };
 RunCode.completeJS=function(js)
 {
  return"\r\n          CIPHERSpaceLoadFileGlobalFileRef = null;\r\n          CIPHERSpaceLoadFile = function (filename, callback) {\r\n              if (filename.slice(-3) == \".js\" || filename.slice(-4) == \".fsx\" || filename.slice(-3) == \".fs\") { //if filename is a external JavaScript file\r\n                  var fileRef = null;\r\n                  var pre = document.querySelector('script[src=\"' + filename + '\"]')\r\n                  if (!pre) {\r\n                      fileRef = document.createElement('script')\r\n                      fileRef.setAttribute(\"type\", \"text/javascript\")\r\n                      fileRef.setAttribute(\"src\", filename)\r\n                  }\r\n                  else callback();\r\n              }\r\n              else if (filename.slice(-4) == \".css\") { //if filename is an external CSS file\r\n                  var pre = document.querySelector('script[src=\"' + filename + '\"]')\r\n                  if (!pre) {\r\n                      fileRef = document.createElement(\"link\")\r\n                      fileRef.setAttribute(\"rel\", \"stylesheet\")\r\n                      fileRef.setAttribute(\"type\", \"text/css\")\r\n                      fileRef.setAttribute(\"href\", filename)\r\n                  }\r\n                  else callback();\r\n              }\r\n              else if (filename.slice(-5) == \".html\") { //if filename is an external HTML file\r\n                  var pre = document.querySelector('script[src=\"' + filename + '\"]')\r\n                  if (!pre) {\r\n                      fileRef = document.createElement(\"link\")\r\n                      fileRef.setAttribute(\"rel\", \"import\")\r\n                      fileRef.setAttribute(\"type\", \"text/html\")\r\n                      fileRef.setAttribute(\"href\", filename)\r\n                  }\r\n                  else callback();\r\n              }\r\n              if (!!fileRef) {\r\n                  CIPHERSpaceLoadFileGlobalFileRef = fileRef;\r\n      \u0009\u0009\u0009fileRef.onload = function () { fileRef.onload = null;  callback(); }\r\n                  document.getElementsByTagName(\"head\")[0].appendChild(fileRef);\r\n              }\r\n          }\r\n          CIPHERSpaceLoadFiles = function (files, callback) {\r\n              var newCallback = callback\r\n              if (!!CIPHERSpaceLoadFileGlobalFileRef && !!(CIPHERSpaceLoadFileGlobalFileRef.onload)) {\r\n                  var oldCallback = CIPHERSpaceLoadFileGlobalFileRef.onload;\r\n                  CIPHERSpaceLoadFileGlobalFileRef.onload = null;\r\n                  newCallback = function () {\r\n                      callback();\r\n                      oldCallback();\r\n                  }\r\n              }\r\n              var i = 0;\r\n              loadNext = function () {\r\n                  if (i < files.length) {\r\n                      var file = files[i];\r\n                      i++;\r\n                      CIPHERSpaceLoadFile(file, loadNext);\r\n                  }\r\n                  else newCallback();\r\n              };\r\n              loadNext();\r\n      \u0009}\r\n          CIPHERSpaceLoadFiles(['https://code.jquery.com/jquery-3.1.1.min.js'], function() {}); \r\n      \u0009CIPHERSpaceLoadFilesDoAfter = function (callback) {\r\n      \u0009\u0009var newCallback = callback\r\n      \u0009\u0009if (!!CIPHERSpaceLoadFileGlobalFileRef) {\r\n      \u0009\u0009\u0009if (!!(CIPHERSpaceLoadFileGlobalFileRef.onload)) {\r\n      \u0009\u0009\u0009\u0009var oldCallback = CIPHERSpaceLoadFileGlobalFileRef.onload;\r\n      \u0009\u0009\u0009\u0009CIPHERSpaceLoadFileGlobalFileRef.onload = null;\r\n      \u0009\u0009\u0009\u0009newCallback = function () {\r\n      \u0009\u0009\u0009\u0009\u0009oldCallback();\r\n      \u0009\u0009\u0009\u0009\u0009callback();\r\n      \u0009\u0009\u0009\u0009}\r\n      \u0009\u0009\u0009}\r\n      \u0009\u0009}\r\n      \u0009\u0009else CIPHERSpaceLoadFileGlobalFileRef = {};\r\n      \u0009\u0009CIPHERSpaceLoadFileGlobalFileRef.onload = newCallback;\r\n      \u0009}\r\n      \r\n      CIPHERSpaceLoadFilesDoAfter(function() { \r\n        if (typeof IntelliFactory !=='undefined')\r\n          IntelliFactory.Runtime.Start();\r\n        for (key in window) { \r\n          if (key.startsWith(\"StartupCode$\")) \r\n            try { window[key].$cctor(); } catch (e) {} \r\n        } \r\n      })\r\n                       "+js;
 };
 Position.NewBrowser={
  $:3
 };
 Position.Tab={
  $:2
 };
 Position.Right={
  $:1
 };
 Position.Below={
  $:0
 };
 KeyMapAutoComplete.New=function(F2,LeftDoubleClick,_CtrlSpace)
 {
  return{
   F2:F2,
   LeftDoubleClick:LeftDoubleClick,
   "Ctrl-Space":_CtrlSpace
  };
 };
 FSharpStation.rootSplitter=function()
 {
  SC$1.$cctor();
  return SC$1.rootSplitter;
 };
 FSharpStation.main_messages=function()
 {
  SC$1.$cctor();
  return SC$1.main_messages;
 };
 FSharpStation.snippets_code=function()
 {
  SC$1.$cctor();
  return SC$1.snippets_code;
 };
 FSharpStation.code_buttons=function()
 {
  SC$1.$cctor();
  return SC$1.code_buttons;
 };
 FSharpStation.title_code=function()
 {
  SC$1.$cctor();
  return SC$1.title_code;
 };
 FSharpStation.buttons=function()
 {
  SC$1.$cctor();
  return SC$1.buttons;
 };
 FSharpStation.snippets=function()
 {
  SC$1.$cctor();
  return SC$1.snippets;
 };
 FSharpStation.code=function()
 {
  SC$1.$cctor();
  return SC$1.code;
 };
 FSharpStation.messages=function()
 {
  SC$1.$cctor();
  return SC$1.messages;
 };
 FSharpStation.title=function()
 {
  SC$1.$cctor();
  return SC$1.title;
 };
 FSharpStation.fixedHorSplitter2=function(px,ch1,ch2)
 {
  return Grid.get_New().Content$1("one",Template.renderSplitterNode(ch1)).Content$1("two",Template.renderSplitterNode(ch2)).Padding(0).RowAuto(50).RowFixedPx(px).Content(HtmlNode.style("grid-template-areas: 'one' 'two' ")).get_Render();
 };
 FSharpStation.fixedHorSplitter1=function(px,ch1,ch2)
 {
  return Grid.get_New().Content$1("one",Template.renderSplitterNode(ch1)).Content$1("two",Template.renderSplitterNode(ch2)).Padding(0).RowFixedPx(px).RowAuto(50).Content(HtmlNode.style("grid-template-areas: 'one' 'two' ")).get_Render();
 };
 FSharpStation.buttonsH=function()
 {
  SC$1.$cctor();
  return SC$1.buttonsH;
 };
 FSharpStation.snippetList=function()
 {
  SC$1.$cctor();
  return SC$1.snippetList;
 };
 FSharpStation.CodeEditor=function()
 {
  var x,view,contentVar,changingIRefO,contentVarChanged,refVarChanged;
  return Grid.get_New().ColVariable$1(FSharpStation.spl1()).ColAuto(0).ColVariable(0).Min(0).Max(Val.map(function(y)
  {
   return 92-y;
  },FSharpStation.spl1().get_GetValue())).get_Before().Children([HtmlNode.style("grid-row   : 1 / 5")]).RowFixedPx(34).RowAuto(0).RowVariable(17).get_Before().Children([HtmlNode.style("grid-column: 2 / 3")]).RowFixedPx(80).Padding(1).Content$1("sidebar",HtmlNode.bindHElem(FSharpStation.listEntries,(x=FSharpStation.codeSnippets().v,View.SnapshotOn((FSharpStation.codeSnippets())["var"].RVal(),FSharpStation.refresh().v,x)))).Content$1("header",Input.New$2((view=Val.toView(Val.fixit(FSharpStation.currentCodeSnippetId())),(contentVar=Var.Create$1(null),(changingIRefO=[null],(contentVarChanged=[0],(refVarChanged=[0],(View.Sink(function()
  {
   var o,r;
   o=changingIRefO[0];
   o==null?void 0:(r=o.$0,contentVarChanged[0]>refVarChanged[0]?refVarChanged[0]=contentVarChanged[0]:!Unchecked.Equals(r.RVal(),contentVar.c)?(refVarChanged[0]=refVarChanged[0]+1,r.set_RVal(contentVar.c)):void 0);
  },contentVar.v),View.Sink(function()
  {
   var o,r;
   o=changingIRefO[0];
   o==null?void 0:(r=o.$0,refVarChanged[0]>contentVarChanged[0]?contentVarChanged[0]=refVarChanged[0]:!Unchecked.Equals(r.RVal(),contentVar.c)?(contentVarChanged[0]=contentVarChanged[0]+10,Var.Set(contentVar,r.RVal())):void 0);
  },View.Bind(function(cur)
  {
   var r;
   r=FSharpStation.curSnippetNameOf(cur);
   changingIRefO[0]={
    $:1,
    $0:r
   };
   refVarChanged[0]=contentVarChanged[0]+100;
   Var.Set(contentVar,r.RVal());
   return r.RView();
  },view)),contentVar))))))).Prefix(HtmlNode.htmlText("name:")).get_Render()).Content$1("content1",FSharpStation.codeMirror().get_Render()).Content$1("content2",TabStrip.New$1(FSharpStation.Messages()).get_Top().get_Render()).Content$1("footer",HtmlNode.div([Button.New$1("Add code").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.addCode();
  })).get_Render(),Button.New$1("<<").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.indentCodeOut();
  })).Disabled(FSharpStation.noSelectionVal()).get_Render(),Button.New$1(">>").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.indentCodeIn();
  })).Disabled(FSharpStation.noSelectionVal()).get_Render(),FSharpStation.loadFileElement().get_Render().AddChildren([HtmlNode.style("grid-column: 4/6")]),Button.New$1("Parse F#").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.parseFS();
  })).Disabled(FSharpStation.noSelectionVal()).get_Render(),Button.New$1("Evaluate F# (FSI)").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.evaluateFS();
  })).Disabled(FSharpStation.noSelectionVal()).get_Render(),Button.New$1("Get F# code ==>").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.getFSCode();
  })).Disabled(FSharpStation.noSelectionVal()).get_Render(),Button.New$1("Delete code").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.deleteCode();
  })).Disabled(FSharpStation.noSelectionVal()).get_Render(),HtmlNode.span([]),HtmlNode.span([]),Button.New$1("Save as...").Class("btn            ").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.downloadFile();
  })).get_Render().AddChildren([HtmlNode.classIf("btn-primary",FSharpStation.dirty())]),HtmlNode.span([]),Button.New$1("Compile WebSharper").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.justCompile();
  })).Disabled(FSharpStation.noSelectionVal()).get_Render(),Button.New$1("Run WebSharper in ...").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.compileRun();
  })).Disabled(FSharpStation.noSelectionVal()).get_Render(),HtmlNode.someElt(Doc.Select([AttrProxy.Create("id","Position")],FSharpStation.positionTxt,List.ofArray([Position.Below,Position.Right,Position.NewBrowser]),FSharpStation.position())),HtmlNode.style("\r\n                        overflow: hidden;\r\n                        display: grid;\r\n                        grid-template-columns: repeat(8, 12.1%);\r\n                        bxackground-color: #eee;\r\n                        padding : 5px;\r\n                        grid-gap: 5px;\r\n                    ")])).Content(HtmlNode.script([HtmlNode.src("/EPFileX/FileSaver/FileSaver.js"),HtmlNode.type("text/javascript")])).Content(HtmlNode.script([HtmlNode.src("http://code.jquery.com/jquery-3.1.1.min.js"),HtmlNode.type("text/javascript")])).Content(HtmlNode.script([HtmlNode.src("http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"),HtmlNode.type("text/javascript")])).Content(HtmlNode.link([HtmlNode.href("http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")])).Content(HtmlNode.link([HtmlNode.href("/EPFileX/css/main.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")])).Content(HtmlNode.css(FSharpStation.styleEditor())).get_Render().Style(" \r\n                  grid-template-areas:\r\n                      'header0 header   sidebar2'\r\n                      'sidebar content1 sidebar2'\r\n                      'sidebar content2 sidebar2'\r\n                      'footer  footer   sidebar2';\r\n                  color      : #333;\r\n                  height     : 100%;\r\n                  font-size  : small;\r\n                  font-family: monospace;\r\n                  line-height: 1.2;\r\n                      ");
 };
 FSharpStation.Messages=function()
 {
  SC$1.$cctor();
  return SC$1.Messages;
 };
 FSharpStation.spl1=function()
 {
  SC$1.$cctor();
  return SC$1.spl1;
 };
 FSharpStation.styleEditor=function()
 {
  SC$1.$cctor();
  return SC$1.styleEditor;
 };
 FSharpStation.codeMirror=function()
 {
  SC$1.$cctor();
  return SC$1.codeMirror;
 };
 FSharpStation.getAnnotations=function(txt,cb,a,ed)
 {
  var b;
  Concurrency.Start((b=null,Concurrency.Delay(function()
  {
   var m,cur;
   m=CodeSnippet$1.FetchO(FSharpStation.currentCodeSnippetId().c);
   return m!=null&&m.$==1?(cur=m.$0,Concurrency.Bind(FSharpStation.parseIfMustThen(cur,false),function()
   {
    var c,m$1,a$1;
    cb((c=function(file,fl,fc,tl,tc,sev,from,msg)
    {
     return Strings.StartsWith(file,cur.id.get_Text())||file===FsStationShared.sanitize(cur.name)?{
      $:1,
      $0:LintResponse.New(msg,Strings.StartsWith(sev.toUpperCase(),"ERR")?"error":Strings.StartsWith(sev.toUpperCase(),"INFO")?"info":"warning",Template.cmPos(fl-1,fc-1),Template.cmPos(tl-1,tc-1))
     }:null;
    },Arrays.choose(function($1)
    {
     return c($1[0],$1[1],$1[2],$1[3],$1[4],$1[5],$1[6],$1[7]);
    },Arrays.choose(function(v)
    {
     var $1,a$2,t,indent,$2,a$3,t$1,fc,fl,indent$1;
     return(a$2=Useful.REGEX(FSharpStation.rex2(),"",v),a$2!=null&&a$2.$==1&&((t=a$2.$0,t&&Arrays.length(t)===13)&&($1=[Arrays.get(a$2.$0,8),Arrays.get(a$2.$0,5),Arrays.get(a$2.$0,7),Arrays.get(a$2.$0,2),Arrays.get(a$2.$0,4),Arrays.get(a$2.$0,11),Arrays.get(a$2.$0,1),Arrays.get(a$2.$0,10),Arrays.get(a$2.$0,9)],true)))?(indent=$1[4],{
      $:1,
      $0:[$1[1],$1[2]<<0,($1[0]<<0)-(indent<<0),$1[8]<<0,($1[7]<<0)-(indent<<0),$1[6],$1[3],$1[5]]
     }):(a$3=Useful.REGEX(FSharpStation.rex1(),"",v),a$3!=null&&a$3.$==1&&((t$1=a$3.$0,t$1&&Arrays.length(t$1)===8)&&($2=[Arrays.get(a$3.$0,4),Arrays.get(a$3.$0,2),Arrays.get(a$3.$0,3),Arrays.get(a$3.$0,1),Arrays.get(a$3.$0,6),Arrays.get(a$3.$0,5)],true)))?(fc=$2[0],(fl=$2[2],(indent$1=$2[3],{
      $:1,
      $0:[$2[1],fl<<0,(fc<<0)-(indent$1<<0)-1,fl<<0,(fc<<0)-(indent$1<<0),$2[5],"fsi",$2[4]]
     }))):null;
    },(m$1=FSharpStation.codeMsgs().c,(a$1=Useful.REGEX(FSharpStation.rex(),"g",m$1),a$1!=null&&a$1.$==1?a$1.$0:[]))))));
    return Concurrency.Zero();
   })):Concurrency.Zero();
  })),null);
 };
 FSharpStation.rex=function()
 {
  SC$1.$cctor();
  return SC$1.rex;
 };
 FSharpStation.rex2=function()
 {
  SC$1.$cctor();
  return SC$1.rex2;
 };
 FSharpStation.rex1=function()
 {
  SC$1.$cctor();
  return SC$1.rex1;
 };
 FSharpStation.getHints=function(ed,cb,a)
 {
  var b;
  Concurrency.Start((b=null,Concurrency.Delay(function()
  {
   var m,cur;
   m=CodeSnippet$1.FetchO(FSharpStation.currentCodeSnippetId().c);
   return m!=null&&m.$==1?(cur=m.$0,Concurrency.Bind(FSharpStation.parseIfMustThen(cur,true),function()
   {
    var pos,word;
    pos=ed.getCursor();
    word=FSharpStation.getStartWord(ed.getLine(pos.line),pos.ch);
    return Concurrency.Bind(FSharpStation.autoCompleteClient().Complete(FSharpStation.parseFile(),pos.line+1,pos.ch+1,cur.get_NameSanitized()),function(a$1)
    {
     var m$1;
     cb(HintResponse.New((m$1=function(dis,rep,cls,chr)
     {
      return Hint.New(rep,chr+"| "+dis,cls);
     },Arrays.map(function($1)
     {
      return m$1($1[0],$1[1],$1[2],$1[3]);
     },a$1)),CodeMirrorPos.New(pos.line,pos.ch-word.length),pos));
     return Concurrency.Zero();
    });
   })):Concurrency.Zero();
  })),null);
 };
 FSharpStation.showToolTip=function(ed)
 {
  var b;
  Concurrency.Start((b=null,Concurrency.Delay(function()
  {
   var m,cur;
   m=CodeSnippet$1.FetchO(FSharpStation.currentCodeSnippetId().c);
   return m!=null&&m.$==1?(cur=m.$0,Concurrency.Bind(FSharpStation.parseIfMustThen(cur,false),function()
   {
    var pos,l,sub,add0,add;
    pos=ed.getCursor();
    l=ed.getLine(pos.line);
    sub=Strings.length(FSharpStation.getStartWord(l,pos.ch));
    add0=Strings.length(FSharpStation.getEndWord(l,pos.ch));
    add=sub===0&&add0===0?2:add0;
    return Concurrency.Bind(FSharpStation.autoCompleteClient().ToolTip(FSharpStation.parseFile(),pos.line+1,pos.ch+1,cur.get_NameSanitized()),function(a)
    {
     var c;
     FSharpStation.sendMsg(((((c=(Runtime.Curried(function($1,$2,$3,$4,$5)
     {
      return $1("InfoFSharp \""+PrintfHelpers.toSafe($2)+" "+("("+PrintfHelpers.prettyPrint($3[0])+", "+PrintfHelpers.prettyPrint($3[1])+")")+" - "+("("+PrintfHelpers.prettyPrint($4[0])+", "+PrintfHelpers.prettyPrint($4[1])+")")+" "+PrintfHelpers.toSafe($5)+" \"");
     },5))(window.id),function(a$1)
     {
      var c$1;
      c$1=c(a$1);
      return function(t)
      {
       var c$2;
       c$2=c$1([t[0],t[1]]);
       return function(t$1)
       {
        return c$2([t$1[0],t$1[1]]);
       };
      };
     })(cur.get_NameSanitized()))([pos.line+1,pos.ch-sub+1]))([pos.line+1,pos.ch+add+1]))(Strings.Replace(a,"\"","''")));
     return Concurrency.Zero();
    });
   })):Concurrency.Zero();
  })),null);
 };
 FSharpStation.getEndWord=function(line,ch)
 {
  var a,t;
  a=Useful.REGEX("^([a-zA-Z_]\\w*)","g",line.substring(ch));
  return a!=null&&a.$==1?(t=a.$0,t&&Arrays.length(t)===1)?Arrays.get(a.$0,0):"":"";
 };
 FSharpStation.getStartWord=function(line,ch)
 {
  var a,t;
  a=Useful.REGEX("([a-zA-Z_]\\w*)$","g",Strings.Substring(line,0,ch));
  return a!=null&&a.$==1?(t=a.$0,t&&Arrays.length(t)===1)?Arrays.get(a.$0,0):"":"";
 };
 FSharpStation.parseIfMustThen=function(cur,silent)
 {
  var b;
  b=null;
  return Concurrency.Delay(function()
  {
   return!FSharpStation.parsed()?Concurrency.Bind(FSharpStation.parseFSA(silent),function()
   {
    return Concurrency.Return(null);
   }):Concurrency.Bind(FSharpStation.autoCompleteClient().MustParse(FSharpStation.parseFile(),cur.get_NameSanitized()),function(a)
   {
    return a?Concurrency.Bind(FSharpStation.parseFSA(silent),function()
    {
     return Concurrency.Return(null);
    }):Concurrency.Zero();
   });
  });
 };
 FSharpStation.parseFS=function()
 {
  var b;
  Concurrency.Start((b=null,Concurrency.Delay(function()
  {
   FSharpStation.set_lastCodeAndStarts(null);
   return Concurrency.Bind(FSharpStation.parseFSA(false),function()
   {
    return Concurrency.Return(null);
   });
  })),null);
 };
 FSharpStation.parseFSA=function(silent)
 {
  var b;
  b=null;
  return Concurrency.Delay(function()
  {
   var m,runN,p;
   m=CodeSnippet$1.FetchO(FSharpStation.currentCodeSnippetId().c);
   return m!=null&&m.$==1?(runN=FSharpStation.parseRun()+1,(FSharpStation.set_parseRun(runN),p=FSharpStation.getCodeAndStartsFast(silent?function(v)
   {
   }:function(txt)
   {
    Var.Set(FSharpStation.codeMsgs(),txt);
   },m.$0,false),Concurrency.Bind(FSharpStation.autoCompleteClient().Parse$1(FSharpStation.parseFile(),p[0],p[1]),function(a)
   {
    FSharpStation.set_parsed(true);
    return!silent&&runN===FSharpStation.parseRun()?(FSharpStation.sendMsg(a),FSharpStation.sendMsg("Parsed!"),Concurrency.Zero()):Concurrency.Zero();
   }))):Concurrency.Zero();
  });
 };
 FSharpStation.parseRun=function()
 {
  SC$1.$cctor();
  return SC$1.parseRun;
 };
 FSharpStation.set_parseRun=function($1)
 {
  SC$1.$cctor();
  SC$1.parseRun=$1;
 };
 FSharpStation.getCodeAndStartsFast=function(msgF,snp,addLinePrepos)
 {
  var p,$1,$2,pId,alp,preds,red,cur,red1,t;
  p=($2=FSharpStation.lastCodeAndStarts(),$2!=null&&$2.$==1)&&((FSharpStation.lastCodeAndStarts(),pId=FSharpStation.lastCodeAndStarts().$0[0],alp=FSharpStation.lastCodeAndStarts().$0[1],Unchecked.Equals(pId,snp.id)&&Unchecked.Equals(alp,addLinePrepos))&&($1=[FSharpStation.lastCodeAndStarts().$0[1],FSharpStation.lastCodeAndStarts().$0[0],FSharpStation.lastCodeAndStarts().$0[2]],true))?(msgF("Reparsing..."),[$1[2],FSharpStation["CodeSnippet.get_PrepareSnippet"](snp)]):(msgF("Parsing..."),preds=FSharpStation["CodeSnippet.Predecessors"](snp),red=CodeSnippet.ReducedCode(addLinePrepos,Slice.array(preds,{
   $:1,
   $0:0
  },{
   $:1,
   $0:Arrays.length(preds)-2
  })),cur=Arrays.get(preds,Arrays.length(preds)-1),FSharpStation.set_lastCodeAndStarts({
   $:1,
   $0:[cur.id,addLinePrepos,red]
  }),[red,cur]);
  red1=CodeSnippet.ReducedCode(addLinePrepos,[p[1]]);
  t=(function(t$1)
  {
   var a,a$1,a$2,a$3,a$4,a$5;
   a=t$1[0];
   a$1=t$1[1];
   a$2=t$1[2];
   a$3=t$1[3];
   a$4=t$1[4];
   a$5=t$1[5];
   return function(t$2)
   {
    return CodeSnippet.AddSeps(a,a$1,a$2,a$3,a$4,a$5,t$2[0],t$2[1],t$2[2],t$2[3],t$2[4],t$2[5]);
   };
  }(p[0]))(red1);
  return CodeSnippet.FinishCode(addLinePrepos,t[0],t[1],t[2],t[3],t[4],t[5]);
 };
 FSharpStation.setDirtyCond=function()
 {
  var $1,$2;
  ($2=FSharpStation.lastCodeAndStarts(),$2!=null&&$2.$==1)&&((FSharpStation.lastCodeAndStarts(),Unchecked.Equals(FSharpStation.lastCodeAndStarts().$0[0],FSharpStation.currentCodeSnippetId().c))&&($1=[FSharpStation.lastCodeAndStarts().$0[0],FSharpStation.lastCodeAndStarts().$0[2]],true))?FSharpStation.setDirtyPart():FSharpStation.setDirty();
 };
 FSharpStation.parseFile=function()
 {
  SC$1.$cctor();
  return SC$1.parseFile;
 };
 FSharpStation.autoCompleteClient=function()
 {
  SC$1.$cctor();
  return SC$1.autoCompleteClient;
 };
 FSharpStation.Do=function(f,a,a$1)
 {
  return f();
 };
 FSharpStation.loadFileElement=function()
 {
  SC$1.$cctor();
  return SC$1.loadFileElement;
 };
 FSharpStation.downloadFile=function()
 {
  var x,m;
  window.saveAs(new window.Blob([(x=Arrays.ofSeq((FSharpStation.codeSnippets())["var"].RVal()),JSON.stringify(((Provider.EncodeArray(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$3))())(x)))],{
   type:"text/plain;charset=utf-8"
  }),(m=FSharpStation.justFileName(FSharpStation.fileName().c),m===""?"snippets.fsjson":m));
  FSharpStation.setClean();
 };
 FSharpStation.loadFile=function(e)
 {
  if(!FSharpStation.dirty().c||window.confirm("Changes have not been saved, do you really want to load?"))
   FSharpStation.loadTextFile(HtmlNode.findRootElement(e).querySelector("#"+FSharpStation.fileInputElementId()),function(txt)
   {
    var a;
    try
    {
     a=FSharpStation.deserializeCodeSnipets(txt);
     FSharpStation.codeSnippets().Set(a);
     FSharpStation.setClean();
     FSharpStation.refreshView();
    }
    catch(e$1)
    {
     window.alert(window.String(e$1));
    }
   });
 };
 FSharpStation.fileInputElementId=function()
 {
  SC$1.$cctor();
  return SC$1.fileInputElementId;
 };
 FSharpStation.loadTextFile=function(element,f)
 {
  var files,reader;
  files=element.files;
  files.length>0?(reader=new window.FileReader(),reader.onload=function(e)
  {
   return f(e.target.result);
  },reader.readAsText(files.item(0))):void 0;
 };
 FSharpStation.emptyFile=function()
 {
  SC$1.$cctor();
  return SC$1.emptyFile;
 };
 FSharpStation.fileName=function()
 {
  SC$1.$cctor();
  return SC$1.fileName;
 };
 FSharpStation.justFileName=function(f)
 {
  return Seq.last(Strings.SplitChars(f,[47,92],0));
 };
 FSharpStation.deleteCode=function()
 {
  var o,snp;
  o=CodeSnippet$1.FetchO(FSharpStation.currentCodeSnippetId().c);
  o==null?void 0:(snp=o.$0,window.confirm((function($1)
  {
   return function($2)
   {
    return $1("Do you want to delete "+PrintfHelpers.toSafe($2)+"?");
   };
  }(window.id))(snp.get_Name()))?(Var.Set(FSharpStation.currentCodeSnippetId(),CodeSnippetId.get_New()),FSharpStation.codeSnippets().Remove(snp),FSharpStation.setDirty(),FSharpStation.refreshView()):void 0);
 };
 FSharpStation.addCode=function()
 {
  var n,o,o$1;
  n=(o=(o$1=CodeSnippet$1.PickIO(FSharpStation.currentCodeSnippetId().c),o$1==null?null:{
   $:1,
   $0:CodeSnippet$1.New(o$1.$0[0]+1,"",o$1.$0[1].parent,List.T.Empty,List.T.Empty,"")
  }),o==null?CodeSnippet$1.New$2(""):o.$0);
  Var.Set(FSharpStation.currentCodeSnippetId(),n.id);
  FSharpStation.setDirty();
  FSharpStation.refreshView();
 };
 FSharpStation.deserializeCodeSnipets=function(v)
 {
  var objs;
  try
  {
   objs=JSON.parse(v);
   ((function($1)
   {
    return function($2)
    {
     return $1(PrintfHelpers.prettyPrint($2));
    };
   }(function(s)
   {
    console.log(s);
   }))(objs.length));
   return Arrays.choose(function(o)
   {
    return!o?null:{
     $:1,
     $0:CodeSnippet.New(FSharpStation.ifUndef("",o.name),FSharpStation.ifUndef("",o.content),FSharpStation.obj2CodeSnippetIdO(o.parent),List.ofSeq(Arrays.map(FSharpStation.obj2CodeSnippetId,FSharpStation.ifUndef([],o.predecessors))),FSharpStation.obj2CodeSnippetId(o.id),FSharpStation.ifUndef(false,o.expanded),FSharpStation.ifUndef(0,o.level),FSharpStation.obj2Map(o.properties))
    };
   },objs);
  }
  catch(m)
  {
   return[];
  }
 };
 FSharpStation.obj2Map=function(o)
 {
  var m;
  return!o?new FSharpMap.New([]):Map.OfArray(Arrays.ofSeq((m=function(f,v)
  {
   return[f,v];
  },Arrays.map(function($1)
  {
   return m($1[0],$1[1]);
  },JSModule.GetFields(o)))));
 };
 FSharpStation.obj2CodeSnippetIdO=function(o)
 {
  return!o?null:{
   $:1,
   $0:FSharpStation.obj2CodeSnippetId(o)
  };
 };
 FSharpStation.obj2CodeSnippetId=function(o)
 {
  return new CodeSnippetId({
   $:0,
   $0:!o?"00000000-0000-0000-0000-000000000000":o.Item
  });
 };
 FSharpStation.ifUndef=function(def,v)
 {
  return!v?def:v;
 };
 FSharpStation.listEntries=function(snps)
 {
  return HtmlNode.div(List.ofSeq(Seq.delay(function()
  {
   return Seq.append([HtmlNode.style("overflow: auto")],Seq.delay(function()
   {
    return Seq.choose(window.id,(Seq.mapFold(function(expanded,t)
    {
     var snp,o,o$1,isParent,o$2,o$3,isExpanded;
     snp=t[1];
     return(o=(o$1=snp.parent,o$1==null?null:{
      $:1,
      $0:expanded.Contains(o$1.$0)
     }),o==null||o.$0)?(isParent=(o$2=(o$3=Seq.tryItem(t[0]+1,FSharpStation.codeSnippets()),o$3==null?null:{
      $:1,
      $0:Unchecked.Equals(o$3.$0.parent,{
       $:1,
       $0:snp.id
      })
     }),o$2==null?false:o$2.$0),(isExpanded=isParent&&snp.expanded,[{
      $:1,
      $0:FSharpStation.listEntry(isParent,isExpanded,snp)
     },isExpanded?expanded.Add(snp.id):expanded])):[null,expanded];
    },new FSharpSet.New(List.T.Empty),Seq.indexed(snps)))[0]);
   }));
  })));
 };
 FSharpStation.listEntry=function(isParent,isExpanded,code)
 {
  var x,p,p$1;
  return Hoverable.get_New().Content$1([HtmlNode["class"]("code-editor-list-tile"),HtmlNode.classIf("selected",Val.map((x=code.id,function(y)
  {
   return Unchecked.Equals(x,y);
  }),FSharpStation.currentCodeSnippetId())),HtmlNode.classIf("direct-predecessor",Val.map((p=code.id,function(c)
  {
   return FSharpStation.isDirectPredecessor(p,c);
  }),FSharpStation.currentCodeSnippetO())),HtmlNode.classIf("indirect-predecessor",Val.map((p$1=code.id,function(p$2)
  {
   return FSharpStation.isIndirectPredecessor(p$1,p$2);
  }),FSharpStation.curPredecessors())),HtmlNode.draggable("true"),new HtmlNode$1({
   $:6,
   $0:AttrModule.Handler("dragover",function()
   {
    return function(ev)
    {
     return ev.preventDefault();
    };
   })
  }),new HtmlNode$1({
   $:6,
   $0:AttrModule.Handler("drag",function()
   {
    return function()
    {
     return FSharpStation.set_draggedId(code.id);
    };
   })
  }),new HtmlNode$1({
   $:6,
   $0:AttrModule.Handler("drop",function()
   {
    return function(ev)
    {
     ev.preventDefault();
     return FSharpStation.reorderSnippet(code.id,FSharpStation.draggedId());
    };
   })
  }),HtmlNode.span([HtmlNode["class"]("node"),HtmlNode.classIf("parent",isParent),HtmlNode.classIf("expanded",isExpanded),new HtmlNode$1({
   $:6,
   $0:AttrModule.Handler("click",function()
   {
    return function()
    {
     return isParent?FSharpStation.toggleExpanded(code):null;
    };
   })
  }),HtmlNode.title(isParent?isExpanded?"collapse":"expand":""),HtmlNode.htmlText(isParent?isExpanded?"-":"+":"")]),HtmlNode.div([HtmlNode["class"]("code-editor-list-text"),HtmlNode.style1("text-indent",(function($1)
  {
   return function($2)
   {
    return $1(window.String($2)+"em");
   };
  }(window.id))(FSharpStation["CodeSnippet.get_Level"](code))),HtmlNode.style("white-space: pre"),HtmlNode.htmlText(Val.map2(function(n)
  {
   return function(c)
   {
    return FsStationShared.snippetName(n,c);
   };
  },FSharpStation.curSnippetNameOf(code.id),FSharpStation.curSnippetCodeOf(code.id))),new HtmlNode$1({
   $:6,
   $0:AttrModule.Handler("click",function()
   {
    return function()
    {
     return Var.Set(FSharpStation.currentCodeSnippetId(),code.id);
    };
   })
  })]),HtmlNode.span([HtmlNode["class"]("predecessor"),HtmlNode.title("toggle predecessor"),new HtmlNode$1({
   $:6,
   $0:AttrModule.Handler("click",function()
   {
    return function()
    {
     return Val.iter(function(c)
     {
      FSharpStation.togglePredecessorForCur(code,c);
     },FSharpStation.currentCodeSnippetO());
    };
   })
  }),HtmlNode.htmlText("X")])]);
 };
 FSharpStation.toggleExpanded=function(snp)
 {
  FSharpStation.codeSnippets().UpdateBy(function(c)
  {
   return{
    $:1,
    $0:CodeSnippet.New(c.name,c.content,c.parent,c.predecessors,c.id,!c.expanded,c.level,c.properties)
   };
  },snp.id);
  FSharpStation.refreshView();
 };
 FSharpStation.togglePredecessorForCur=function(pre,curO)
 {
  var cur,preds,p,x;
  if(curO==null)
   ;
  else
   {
    cur=curO.$0;
    Unchecked.Equals(cur,pre)||FSharpStation.isIndirectPredecessor(cur.id,new HashSet.New$2(pre.UniquePredecessors(CodeSnippet$1.FetchO)))?void 0:(preds=(List.contains(pre.id,cur.predecessors)?(p=(x=pre.id,function(y)
    {
     return!Unchecked.Equals(x,y);
    }),function(l)
    {
     return List.filter(p,l);
    }):function(l)
    {
     return new List.T({
      $:1,
      $0:pre.id,
      $1:l
     });
    })(cur.predecessors),FSharpStation.codeSnippets().UpdateBy(function(c)
    {
     return{
      $:1,
      $0:CodeSnippet.New(c.name,c.content,c.parent,preds,c.id,c.expanded,c.level,c.properties)
     };
    },cur.id),FSharpStation.setDirtyPred());
   }
 };
 FSharpStation.isIndirectPredecessor=function(pre,predecessors)
 {
  return predecessors.Contains(pre);
 };
 FSharpStation.curPredecessors=function()
 {
  SC$1.$cctor();
  return SC$1.curPredecessors;
 };
 FSharpStation.isDirectPredecessor=function(pre,curO)
 {
  var o;
  o=curO==null?null:{
   $:1,
   $0:List.contains(pre,curO.$0.predecessors)
  };
  return o==null?false:o.$0;
 };
 FSharpStation.draggedId=function()
 {
  SC$1.$cctor();
  return SC$1.draggedId;
 };
 FSharpStation.set_draggedId=function($1)
 {
  SC$1.$cctor();
  SC$1.draggedId=$1;
 };
 FSharpStation.indentCodeOut=function()
 {
  var o,snp,newP,o$1,o$2;
  o=CodeSnippet$1.FetchO(FSharpStation.currentCodeSnippetId().c);
  o==null?void 0:(snp=o.$0,newP=(o$1=(o$2=snp.parent,o$2==null?null:CodeSnippet$1.FetchO(o$2.$0)),o$1==null?null:o$1.$0.parent),FSharpStation.codeSnippets().UpdateBy(function(c)
  {
   return{
    $:1,
    $0:CodeSnippet.New(c.name,c.content,newP,c.predecessors,c.id,c.expanded,c.level,c.properties)
   };
  },snp.id),FSharpStation.setDirtyPred());
 };
 FSharpStation.indentCodeIn=function()
 {
  var o;
  o=CodeSnippet$1.PickIO(FSharpStation.currentCodeSnippetId().c);
  o==null?void 0:(function(j,snp)
  {
   (function(f,i)
   {
    var x;
    while(true)
     {
      if(i<0)
       return null;
      else
       if(f((x=(FSharpStation.codeSnippets())["var"].RVal(),(function(i$1)
       {
        return function(s)
        {
         return Seq.nth(i$1,s);
        };
       }(i))(x))))
        return null;
       else
        i=i-1;
     }
   }(function(pri)
   {
    return Unchecked.Equals(pri.parent,snp.parent)&&(FSharpStation.codeSnippets().UpdateBy(function(c)
    {
     return{
      $:1,
      $0:CodeSnippet.New(c.name,c.content,{
       $:1,
       $0:pri.id
      },c.predecessors,c.id,c.expanded,c.level,c.properties)
     };
    },snp.id),true);
   },j-1));
   FSharpStation.setDirtyPred();
  }).apply(null,o.$0);
 };
 FSharpStation.reorderSnippet=function(toId,fromId)
 {
  var p,others,moving,$1,$2,ti,tsn,a;
  function trySnippet(id)
  {
   var f;
   f=function(a$1,snp)
   {
    return Unchecked.Equals(snp.id,id);
   };
   return function(s)
   {
    return FSharpStation.tryPickI(function($3)
    {
     return f($3[0],$3[1]);
    },s);
   };
  }
  p=Arrays.partition(function(snp)
  {
   return Unchecked.Equals(snp.id,fromId)||FSharpStation["CodeSnippet.IsDescendantOf"](snp,fromId);
  },Arrays.ofSeq((FSharpStation.codeSnippets())["var"].RVal()));
  others=p[1];
  moving=p[0];
  $1=(trySnippet(fromId))(moving);
  $2=(trySnippet(toId))(others);
  $1!=null&&$1.$==1?$2!=null&&$2.$==1?(ti=$2.$0[0],tsn=$2.$0[1],a=Arrays.collect(window.id,[Slice.array(others,{
   $:1,
   $0:0
  },{
   $:1,
   $0:ti-1
  }),moving,Slice.array(others,{
   $:1,
   $0:ti
  },null)]),FSharpStation.codeSnippets().Set(a),FSharpStation.codeSnippets().UpdateBy(function(c)
  {
   return{
    $:1,
    $0:CodeSnippet.New(c.name,c.content,tsn.parent,c.predecessors,c.id,c.expanded,c.level,c.properties)
   };
  },$1.$0[1].id)):void 0:void 0;
  FSharpStation.setDirtyPred();
 };
 FSharpStation.evaluateFS=function()
 {
  var c,f,g;
  FSharpStation.processSnippet(function(snp)
  {
   return FSharpStation["CodeSnippet.GetCodeFsx"](snp,true);
  },"Evaluating F# code...",(c=(f=function($1,$2)
  {
   var $3;
   switch($1!=null&&$1.$==1?$1.$0===""?$2===""?0:($3=[$2,$1.$0],3):$2===""?($3=$1.$0,2):($3=[$2,$1.$0],3):$2===""?0:($3=$2,1))
   {
    case 0:
     return"Done!";
     break;
    case 1:
     return $3;
     break;
    case 2:
     return $3;
     break;
    case 3:
     return $3[0]+"\n"+$3[1];
     break;
   }
  },(g=function(m)
  {
   FSharpStation.sendMsg(m);
  },function(x)
  {
   return g(f.apply(null,x));
  })),function(s)
  {
   EditorRpc.evaluate(c,s);
  }));
 };
 FSharpStation.justCompile=function()
 {
  FSharpStation.compileSnippet(function($1)
  {
   FSharpStation.sendMsg("Compiled!");
   return FSharpStation.sendMsg($1);
  },function(m)
  {
   FSharpStation.sendMsg(m);
  });
 };
 FSharpStation.compileRun=function()
 {
  FSharpStation.compileSnippet(FSharpStation.runJS,function(m)
  {
   FSharpStation.sendMsg(m);
  });
 };
 FSharpStation.compileSnippet=function(fThen,fFail)
 {
  var f;
  FSharpStation.processSnippet(function(snp)
  {
   return FSharpStation["CodeSnippet.GetCodeFsx"](snp,true);
  },"Compiling to JavaScript...",(f=function(msgs,js)
  {
   Var.Set(FSharpStation.codeJS(),js);
   return fThen(msgs,js);
  },function(c)
  {
   RunCode.compile(f,fFail,c);
  }));
 };
 FSharpStation.processSnippet=function(getCode,msg,processCode)
 {
  var o,code;
  o=CodeSnippet$1.FetchO(FSharpStation.currentCodeSnippetId().c);
  o==null?void 0:(Var.Set(FSharpStation.codeMsgs(),msg),Var.Set(FSharpStation.codeJS(),""),code=getCode(o.$0),Var.Set(FSharpStation.codeFS(),code),processCode(code));
 };
 FSharpStation.runJS=function(msgs,js)
 {
  FSharpStation.sendMsg("Running JavaScript...");
  (((FSharpStation.position().c.$==3?Runtime.Curried3(FSharpStation.evalWindowJS):Runtime.Curried3(FSharpStation.evalIFrameJS))(function(res)
  {
   FSharpStation.sendMsg("Done!");
   FSharpStation.sendMsg(res);
   FSharpStation.sendMsg(msgs);
  }))(function(res)
  {
   FSharpStation.sendMsg("Failed!");
   FSharpStation.sendMsg(res);
   FSharpStation.sendMsg(msgs);
  }))(js);
 };
 FSharpStation.evalWindowJS=function(success,failure,js)
 {
  var window$1,args;
  window$1=(args=[window.location.origin+"/Main.html"],window.open.apply(window,args));
  Unchecked.Equals(window$1,null)?failure("could not open new browser. Popup blocker may be active."):window.setTimeout(function()
  {
   try
   {
    window$1.focus.apply(window$1,[]);
    success(window$1["eval"].apply(window$1,[js]));
   }
   catch(e)
   {
    failure(window.String(e));
   }
  },600);
 };
 FSharpStation.evalIFrameJS=function(success,failure,js)
 {
  (new RunNode.New(null)).RunHtml(HtmlNode.createIFrame(function(frame)
  {
   var window$1;
   try
   {
    window$1=frame.contentWindow;
    success(window$1["eval"].apply(window$1,[js]));
   }
   catch(e)
   {
    failure(window.String(e));
   }
  }));
 };
 FSharpStation.getFSCode=function()
 {
  var o;
  o=CodeSnippet$1.FetchO(FSharpStation.currentCodeSnippetId().c);
  o==null?void 0:Var.Set(FSharpStation.codeFS(),FSharpStation["CodeSnippet.GetCodeFsx"](o.$0,true));
 };
 FSharpStation.sendMsg=function(msg)
 {
  var $1,$2;
  if(!msg)
   ;
  else
   {
    Var.Set(FSharpStation.codeMsgs(),($1=FSharpStation.codeMsgs().c,($2=window.String(msg),$1===null?$2:$1===""?$2:$2===null?$1:$2===""?$1:$1+"\n"+$2)));
   }
 };
 FSharpStation.setClean=function()
 {
  FSharpStation.getPredecessorsM().ClearCache();
  Var.Set(FSharpStation.dirty(),false);
  FSharpStation.set_lastCodeAndStarts(null);
 };
 FSharpStation.setDirtyPred=function()
 {
  FSharpStation.setDirty();
  FSharpStation.getPredecessorsM().ClearCache();
  FSharpStation.refreshView();
 };
 FSharpStation.setDirty=function()
 {
  FSharpStation.set_lastCodeAndStarts(null);
  FSharpStation.setDirtyPart();
 };
 FSharpStation.setDirtyPart=function()
 {
  FSharpStation.set_parsed(false);
  Var.Set(FSharpStation.dirty(),true);
 };
 FSharpStation.dirty=function()
 {
  SC$1.$cctor();
  return SC$1.dirty;
 };
 FSharpStation.parsed=function()
 {
  SC$1.$cctor();
  return SC$1.parsed;
 };
 FSharpStation.set_parsed=function($1)
 {
  SC$1.$cctor();
  SC$1.parsed=$1;
 };
 FSharpStation.codeMsgs=function()
 {
  SC$1.$cctor();
  return SC$1.codeMsgs;
 };
 FSharpStation.codeJS=function()
 {
  SC$1.$cctor();
  return SC$1.codeJS;
 };
 FSharpStation.codeFS=function()
 {
  SC$1.$cctor();
  return SC$1.codeFS;
 };
 FSharpStation.getPredecessorsM=function()
 {
  SC$1.$cctor();
  return SC$1.getPredecessorsM;
 };
 FSharpStation.getPredecessors=function(curO)
 {
  var v,o;
  v=new HashSet.New$3();
  o=curO==null?null:{
   $:1,
   $0:new HashSet.New$2(curO.$0.UniquePredecessors(CodeSnippet$1.FetchO))
  };
  return o==null?v:o.$0;
 };
 FSharpStation.lastCodeAndStarts=function()
 {
  SC$1.$cctor();
  return SC$1.lastCodeAndStarts;
 };
 FSharpStation.set_lastCodeAndStarts=function($1)
 {
  SC$1.$cctor();
  SC$1.lastCodeAndStarts=$1;
 };
 FSharpStation.noSelectionVal=function()
 {
  SC$1.$cctor();
  return SC$1.noSelectionVal;
 };
 FSharpStation.noSelection=function(cur)
 {
  return Unchecked.Equals(CodeSnippet$1.FetchO(cur),null);
 };
 FSharpStation.respondMessage=function(fromId,txt)
 {
  var b;
  b=null;
  return Concurrency.Delay(function()
  {
   return Concurrency.Bind(FSharpStation.respond(fromId,(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$5())(JSON.parse(txt))),function(a)
   {
    return Concurrency.Return(JSON.stringify((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$4())(a)));
   });
  });
 };
 FSharpStation.respond=function(fromId,msg)
 {
  var b;
  b=null;
  return Concurrency.Delay(function()
  {
   var o,o$1,o$2,o$3,o$4,o$5,m,o$6,o$7,x;
   return msg.$==2?Concurrency.Return({
    $:1,
    $0:(o=CodeSnippet$1.FetchO(msg.$0),o==null?null:{
     $:1,
     $0:o.$0.content
    })
   }):msg.$==3?Concurrency.Return({
    $:1,
    $0:(o$1=CodeSnippet$1.FetchO(msg.$0),o$1==null?null:{
     $:1,
     $0:FSharpStation["CodeSnippet.GetCodeFsx"](o$1.$0,true)
    })
   }):msg.$==4?Concurrency.Return({
    $:3,
    $0:(o$2=(o$3=CodeSnippet$1.FetchO(msg.$0),o$3==null?null:{
     $:1,
     $0:FSharpStation["CodeSnippet.Predecessors"](o$3.$0)
    }),o$2==null?[]:o$2.$0)
   }):msg.$==5?Concurrency.Return({
    $:2,
    $0:CodeSnippet$1.FetchO(msg.$0)
   }):msg.$==6?Concurrency.Return({
    $:1,
    $0:(o$4=CodeSnippet$1.FetchByPathO(msg.$0),o$4==null?null:{
     $:1,
     $0:o$4.$0.content
    })
   }):msg.$==7?Concurrency.Return({
    $:1,
    $0:(o$5=CodeSnippet$1.FetchByPathO(msg.$0),o$5==null?null:{
     $:1,
     $0:FSharpStation["CodeSnippet.GetCodeFsx"](o$5.$0,true)
    })
   }):msg.$==10?(m=CodeSnippet$1.FetchByPathO(msg.$0),m==null?Concurrency.Return({
    $:4,
    $0:null,
    $1:[["Snippet not found",FSSeverity.FSError]]
   }):Concurrency.Bind((new AjaxRemotingProvider.New()).Async("ZafirTranspiler:CIPHERPrototype.Transpiler.translate2:608897894",[FSharpStation["CodeSnippet.GetCodeFsx"](m.$0,true),false]),function(a)
   {
    var o$8;
    return Concurrency.Return({
     $:4,
     $0:(o$8=a[0],o$8==null?null:{
      $:1,
      $0:RunCode.completeJS(o$8.$0)
     }),
     $1:FSharpStation.transMsgs(a[1])
    });
   })):msg.$==8?Concurrency.Return({
    $:3,
    $0:(o$6=(o$7=CodeSnippet$1.FetchByPathO(msg.$0),o$7==null?null:{
     $:1,
     $0:FSharpStation["CodeSnippet.Predecessors"](o$7.$0)
    }),o$6==null?[]:o$6.$0)
   }):msg.$==9?Concurrency.Return({
    $:2,
    $0:CodeSnippet$1.FetchByPathO(msg.$0)
   }):msg.$==1?Concurrency.Return({
    $:1,
    $0:{
     $:1,
     $0:"Message received: "+msg.$0
    }
   }):msg.$==0?Concurrency.Return({
    $:0,
    $0:fromId
   }):Concurrency.Return({
    $:1,
    $0:{
     $:1,
     $0:(x=Arrays.ofSeq((FSharpStation.codeSnippets())["var"].RVal()),JSON.stringify(((Provider.EncodeArray(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$3))())(x)))
    }
   });
  });
 };
 FSharpStation.transMsgs=function(msgs)
 {
  var m;
  m=function(m$1,w)
  {
   return[m$1,w?FSSeverity.FSWarning:FSSeverity.FSError];
  };
  return Arrays.map(function($1)
  {
   return m($1[0],$1[1]);
  },msgs);
 };
 FSharpStation.fsStationClient=function()
 {
  SC$1.$cctor();
  return SC$1.fsStationClient;
 };
 FSharpStation.directionVertical=function()
 {
  SC$1.$cctor();
  return SC$1.directionVertical;
 };
 FSharpStation.position=function()
 {
  SC$1.$cctor();
  return SC$1.position;
 };
 FSharpStation.positionTxt=function(v)
 {
  return v.$==1?"Right":v.$==2?"In Tab":v.$==3?"New Browser":"Below";
 };
 FSharpStation.curSnippetCodeOf=function(k)
 {
  var a,a$1;
  return FSharpStation.missing(function(a$2)
  {
   return FSharpStation.codeSnippets().TryFindByKey(a$2);
  },(a=function(s)
  {
   return s.content;
  },(a$1=function(s,n)
  {
   return CodeSnippet.New(s.name,n,s.parent,s.predecessors,s.id,s.expanded,s.level,s.properties);
  },function(a$2)
  {
   return FSharpStation.codeSnippets().LensInto(a,a$1,a$2);
  })),k);
 };
 FSharpStation.curSnippetNameOf=function(k)
 {
  var a,a$1;
  return FSharpStation.missing(function(a$2)
  {
   return FSharpStation.codeSnippets().TryFindByKey(a$2);
  },(a=function(s)
  {
   return s.get_Name();
  },(a$1=function(s,n)
  {
   return CodeSnippet.New(n,s.content,s.parent,s.predecessors,s.id,s.expanded,s.level,s.properties);
  },function(a$2)
  {
   return FSharpStation.codeSnippets().LensInto(a,a$1,a$2);
  })),k);
 };
 FSharpStation.currentCodeSnippetO=function()
 {
  SC$1.$cctor();
  return SC$1.currentCodeSnippetO;
 };
 FSharpStation.refreshView=function()
 {
  Var.Set(FSharpStation.refresh(),null);
 };
 FSharpStation.refresh=function()
 {
  SC$1.$cctor();
  return SC$1.refresh;
 };
 FSharpStation.currentCodeSnippetId=function()
 {
  SC$1.$cctor();
  return SC$1.currentCodeSnippetId;
 };
 FSharpStation.missing=function(find,lens,k)
 {
  return find(k)==null?Var.Lens(FSharpStation.missingVar(),function()
  {
   return"";
  },function()
  {
   return"";
  }):lens(k);
 };
 FSharpStation.missingVar=function()
 {
  SC$1.$cctor();
  return SC$1.missingVar;
 };
 CodeSnippet$1.FetchByPathO=function(names)
 {
  var tryFindByName;
  function tryFindByPath(snps,names$1)
  {
   var first,x,f,x$1;
   first=(x=Seq.tryHead(names$1),x==null?null:tryFindByName(snps,x.$0));
   return Seq.length(names$1)<=1?first:first==null?null:(f=first.$0,(x$1=Seq.tail(names$1),tryFindByPath(Seq.filter(function(snp)
   {
    return Unchecked.Equals(snp.parent,{
     $:1,
     $0:f.id
    });
   },(FSharpStation.codeSnippets())["var"].RVal()),x$1)));
  }
  tryFindByName=function(snps,name)
  {
   return Seq.tryHead(Seq.filter(function(snp)
   {
    return snp.get_Name()===name;
   },snps));
  };
  return tryFindByPath(Seq.filter(function(snp)
  {
   return snp.parent==null;
  },(FSharpStation.codeSnippets())["var"].RVal()),names);
 };
 FSharpStation["CodeSnippet.IsDescendantOf"]=function(_this,antId)
 {
  function isDescendantOf(snp)
  {
   var m,parId,o,o$1;
   m=snp.parent;
   return m!=null&&m.$==1&&(parId=m.$0,Unchecked.Equals(parId,antId)||(o=(o$1=CodeSnippet$1.FetchO(parId),o$1==null?null:{
    $:1,
    $0:isDescendantOf(o$1.$0)
   }),o==null?false:o.$0));
  }
  return isDescendantOf(_this);
 };
 FSharpStation["CodeSnippet.GetCodeFsx"]=function(_this,addLinePrepos)
 {
  return(FSharpStation["CodeSnippet.GetCodeAndStarts"](_this,addLinePrepos))[0];
 };
 FSharpStation["CodeSnippet.GetCodeAndStarts"]=function(_this,addLinePrepos)
 {
  return CodeSnippet.CodeAndStarts(addLinePrepos,FSharpStation["CodeSnippet.Predecessors"](_this));
 };
 FSharpStation["CodeSnippet.Predecessors"]=function(_this,u)
 {
  var preds;
  preds=Arrays.ofSeq(_this.UniquePredecessors(CodeSnippet$1.FetchO));
  return Arrays.ofSeq(Seq.map(FSharpStation["CodeSnippet.get_PrepareSnippet"],Seq.filter(function(snp)
  {
   return Arrays.contains(snp.id,preds);
  },(FSharpStation.codeSnippets())["var"].RVal())));
 };
 FSharpStation["CodeSnippet.get_PrepareSnippet"]=function(_this,u)
 {
  var l;
  l=FSharpStation["CodeSnippet.get_Level"](_this);
  return CodeSnippet.New(_this.name,Strings.Replace(Strings.Replace(_this.content,"##"+"FSHARPSTATION_ID"+"##",FSharpStation.fsIds()),"##"+"FSHARPSTATION_ENDPOINT"+"##",window.location.href),_this.parent,_this.predecessors,_this.id,_this.expanded,l,_this.properties);
 };
 FSharpStation["CodeSnippet.get_Level"]=function(_this,u)
 {
  function level(out,snp)
  {
   var o,x,o$1;
   o=(x=(o$1=snp.parent,o$1==null?null:CodeSnippet$1.FetchO(o$1.$0)),x==null?null:{
    $:1,
    $0:level(out+1,x.$0)
   });
   return o==null?out:o.$0;
  }
  return level(0,_this);
 };
 CodeSnippet$1.New=function(od,nm,pa,pred,co,cnt)
 {
  var newS,$1,a,a$1,t;
  newS=CodeSnippet.New(nm,cnt,pa,pred,CodeSnippetId.get_New(),true,0,new FSharpMap.New([]));
  $1=FSharpStation.codeSnippets().get_Length();
  $1===0?FSharpStation.codeSnippets().Append(newS):od===0?(a=Seq.append([newS],(FSharpStation.codeSnippets())["var"].RVal()),FSharpStation.codeSnippets().Set(a)):od<$1?(a$1=(t=Arrays.splitAt(od,Arrays.ofSeq((FSharpStation.codeSnippets())["var"].RVal())),t[0].concat([newS].concat(t[1]))),FSharpStation.codeSnippets().Set(a$1)):FSharpStation.codeSnippets().Append(newS);
  return newS;
 };
 CodeSnippet$1.New$1=function(nm,pa,pred,co,cnt)
 {
  return CodeSnippet$1.New(FSharpStation.codeSnippets().get_Length(),nm,pa,pred,co,cnt);
 };
 CodeSnippet$1.New$2=function(cnt)
 {
  return CodeSnippet$1.New$1("",null,List.T.Empty,List.T.Empty,cnt);
 };
 CodeSnippet$1.New$3=function(pa,cnt)
 {
  return CodeSnippet$1.New$1("",{
   $:1,
   $0:pa
  },List.T.Empty,List.T.Empty,cnt);
 };
 CodeSnippet$1.New$4=function(pa,pred,cnt)
 {
  return CodeSnippet$1.New$1("",{
   $:1,
   $0:pa
  },pred,List.T.Empty,cnt);
 };
 CodeSnippet$1.New$5=function(pred,cnt)
 {
  return CodeSnippet$1.New$1("",null,pred,List.T.Empty,cnt);
 };
 CodeSnippet$1.FetchL=function(id)
 {
  return Option$1.toList(CodeSnippet$1.FetchO(id));
 };
 CodeSnippet$1.FetchO=function(id)
 {
  return FSharpStation.codeSnippets().TryFindByKey(id);
 };
 CodeSnippet$1.PickIO=function(id)
 {
  var f;
  f=function(a,snp)
  {
   return Unchecked.Equals(snp.id,id);
  };
  return FSharpStation.tryPickI(function($1)
  {
   return f($1[0],$1[1]);
  },(FSharpStation.codeSnippets())["var"].RVal());
 };
 FSharpStation.tryPickI=function(f,s)
 {
  return Seq.tryHead(Seq.filter(f,Seq.indexed(s)));
 };
 FSharpStation.fsIds=function()
 {
  SC$1.$cctor();
  return SC$1.fsIds;
 };
 FSharpStation.codeSnippets=function()
 {
  SC$1.$cctor();
  return SC$1.codeSnippets;
 };
 SC$1.$cctor=Runtime.Cctor(function()
 {
  var g,v,g$1,m,s,v$1,v$2,s$1,v$3,v$4,view,contentVar,changingIRefO,contentVarChanged,refVarChanged,s$2,v$5,v$6,x,view$1,contentVar$1,changingIRefO$1,contentVarChanged$1,refVarChanged$1,x$1,x$2;
  SC$1.result=new ropBuilder.New();
  SC$1.errOptionIsNone=new ErrOptionIsNone.New();
  SC$1.wrapper=new Builder.New();
  SC$1.callAddClass=HtmlNode.addClass("a","b");
  SC$1.renderDoc=(g=(v=Doc.Empty(),function(o)
  {
   return o==null?v:o.$0;
  }),function(x$3)
  {
   return g(HtmlNode.chooseNode(x$3));
  });
  SC$1.string2Styles=(g$1=(m=function(n,v$7)
  {
   return new HtmlNode$1({
    $:6,
    $0:AttrModule.Style(n,v$7)
   });
  },function(a)
  {
   return Arrays.map(function($1)
   {
    return m($1[0],$1[1]);
   },a);
  }),function(x$3)
  {
   return g$1(HtmlNode.style2pairs(x$3));
  });
  SC$1.codeMirrorIncludes=["/EPFileX/codemirror/scripts/codemirror/codemirror.js","/EPFileX/codemirror/scripts/intellisense.js","/EPFileX/codemirror/scripts/codemirror/codemirror-intellisense.js","/EPFileX/codemirror/scripts/codemirror/codemirror-compiler.js","/EPFileX/codemirror/scripts/codemirror/mode/fsharp.js","/EPFileX/codemirror/scripts/addon/search/searchcursor.js","/EPFileX/codemirror/scripts/addon/search/search.js","/EPFileX/codemirror/scripts/addon/search/jump-to-line.js","/EPFileX/codemirror/scripts/addon/dialog/dialog.js","/EPFileX/codemirror/scripts/addon/edit/matchbrackets.js","/EPFileX/codemirror/scripts/addon/selection/active-line.js","/EPFileX/codemirror/scripts/addon/display/fullscreen.js","/EPFileX/codemirror/scripts/addon/hint/show-hint.js","/EPFileX/codemirror/scripts/addon/lint/lint.js"];
  SC$1.draggedTab=[null];
  SC$1.selectedPanels=Var.Create$1(new FSharpMap.New([]));
  SC$1.TabMoved=null;
  SC$1.codeSnippets=ListModel.Create(function(s$3)
  {
   return s$3.id;
  },List.T.Empty);
  SC$1.fsIds="FSharpStation";
  SC$1.missingVar=Var.Create$1("");
  SC$1.currentCodeSnippetId=Var.Create$1(CodeSnippetId.get_New());
  s="CodeEditor."+"currentCodeSnippetId";
  v$1=FSharpStation.currentCodeSnippetId();
  v$2=window.localStorage.getItem(s);
  v$2!==null?v$1.set_RVal((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j())(JSON.parse(v$2))):void 0;
  Val.sink(function(v$7)
  {
   window.localStorage.setItem(s,JSON.stringify((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j())(v$7)));
  },v$1);
  SC$1.refresh=Var.Create$1();
  SC$1.currentCodeSnippetO=Val.map2(function(k)
  {
   return function()
   {
    return FSharpStation.codeSnippets().TryFindByKey(k);
   };
  },FSharpStation.currentCodeSnippetId(),FSharpStation.refresh());
  SC$1.position=Var.Create$1(Position.Below);
  s$1="CodeEditor."+"position";
  v$3=FSharpStation.position();
  v$4=window.localStorage.getItem(s$1);
  v$4!==null?v$3.set_RVal((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$1())(JSON.parse(v$4))):void 0;
  Val.sink(function(v$7)
  {
   window.localStorage.setItem(s$1,JSON.stringify((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$1())(v$7)));
  },v$3);
  SC$1.directionVertical=Val.map(function(pos)
  {
   return pos.$==1&&true;
  },FSharpStation.position());
  SC$1.fsStationClient=new FsStationClient.New(FSharpStation.fsIds(),{
   $:1,
   $0:FSharpStation.fsIds()
  },null,null);
  window.setTimeout(function()
  {
   FSharpStation.fsStationClient().get_MessagingClient().AwaitMessage(FSharpStation.respondMessage);
  },1000);
  SC$1.noSelectionVal=Val.map(FSharpStation.noSelection,FSharpStation.currentCodeSnippetId());
  SC$1.lastCodeAndStarts=null;
  SC$1.getPredecessorsM=new ResetableMemoize.New(FSharpStation.getPredecessors);
  SC$1.codeFS=Var.Create$1("");
  SC$1.codeJS=Var.Create$1("");
  SC$1.codeMsgs=Var.Create$1("");
  SC$1.parsed=false;
  SC$1.dirty=Var.Create$1(false);
  Val.sink(function(m$1)
  {
   window.onbeforeunload=m$1?function(e)
   {
    e.returnValue="Changes you made may not be saved.";
   }:null;
  },FSharpStation.dirty());
  SC$1.draggedId=CodeSnippetId.get_New();
  SC$1.curPredecessors=Val.map(function(a)
  {
   var _this,res,res$1;
   _this=FSharpStation.getPredecessorsM();
   res=null;
   return _this.cache.TryGetValue(a,{
    get:function()
    {
     return res;
    },
    set:function(v$7)
    {
     res=v$7;
    }
   })?res:(res$1=_this.f(a),(_this.cache.set_Item(a,res$1),res$1));
  },FSharpStation.currentCodeSnippetO());
  SC$1.fileName=Var.Create$1("");
  SC$1.emptyFile=Val.map(function(v$7)
  {
   return v$7==="";
  },FSharpStation.fileName());
  SC$1.fileInputElementId="CodeEditorFileSel";
  SC$1.loadFileElement=Input.New$2(Var.Lens(FSharpStation.fileName(),FSharpStation.justFileName,window.id)).Prefix(HtmlNode.label([HtmlNode["class"]("btn btn-primary"),HtmlNode.htmlText("Load File..."),Input.New$2(FSharpStation.fileName()).Type("file").Style("display: none").Content([AttrModule.Handler("change",function(el)
  {
   return function()
   {
    return FSharpStation.loadFile(el);
   };
  }),AttrModule.Handler("click",function(el)
  {
   return function()
   {
    el.value="";
   };
  })]).Id(FSharpStation.fileInputElementId()).get_Render()]));
  SC$1.autoCompleteClient=new FSAutoCompleteClient.New("FSharpStation");
  SC$1.parseFile="..\\F#.fsx";
  SC$1.parseRun=1;
  SC$1.rex1="\\((\\d+)\\) F# (.+).fsx\\((\\d+)\\,(\\d+)\\): (error|warning) ((.|\\b)+)";
  SC$1.rex2="(Err|Warning|Info)(FSharp|WebSharper)\\s+\"(\\((\\d+)\\) ?)?F?#? ?(.+?)(.fsx)? \\((\\d+)\\,\\s*(\\d+)\\) - \\((\\d+)\\,\\s*(\\d+)\\) ((.|\\s)+?)"+"\"";
  SC$1.rex=FSharpStation.rex1()+"|"+FSharpStation.rex2();
  SC$1.codeMirror=CodeMirror.New$2((view=Val.toView(Val.fixit(FSharpStation.currentCodeSnippetId())),(contentVar=Var.Create$1(null),(changingIRefO=[null],(contentVarChanged=[0],(refVarChanged=[0],(View.Sink(function()
  {
   var o,r;
   o=changingIRefO[0];
   o==null?void 0:(r=o.$0,contentVarChanged[0]>refVarChanged[0]?refVarChanged[0]=contentVarChanged[0]:!Unchecked.Equals(r.RVal(),contentVar.c)?(refVarChanged[0]=refVarChanged[0]+1,r.set_RVal(contentVar.c)):void 0);
  },contentVar.v),View.Sink(function()
  {
   var o,r;
   o=changingIRefO[0];
   o==null?void 0:(r=o.$0,refVarChanged[0]>contentVarChanged[0]?contentVarChanged[0]=refVarChanged[0]:!Unchecked.Equals(r.RVal(),contentVar.c)?(contentVarChanged[0]=contentVarChanged[0]+10,Var.Set(contentVar,r.RVal())):void 0);
  },View.Bind(function(cur)
  {
   var r;
   r=FSharpStation.curSnippetCodeOf(cur);
   changingIRefO[0]={
    $:1,
    $0:r
   };
   refVarChanged[0]=contentVarChanged[0]+100;
   Var.Set(contentVar,r.RVal());
   return r.RView();
  },view)),contentVar))))))).OnChange(function()
  {
   FSharpStation.setDirtyCond();
  }).OnRender(function(ed)
  {
   var g$2;
   ed.addKeyMap(KeyMapAutoComplete.New(function(e)
   {
    FSharpStation.showToolTip(e);
   },function(e)
   {
    FSharpStation.showToolTip(e);
   },(g$2=function(e,c,a)
   {
    FSharpStation.getHints(e,c,a);
   },function(a)
   {
    Template.showHints(ed,function($1)
    {
     return g$2($1[0],$1[1],$1[2]);
    },false,a);
   })));
   Template.setLint(ed,function(t)
   {
    FSharpStation.getAnnotations(t[0],t[1],t[2],t[3]);
   });
  }).Style("height: 100%");
  Val.sink(function()
  {
   var b;
   Concurrency.Start((b=null,Concurrency.Delay(function()
   {
    var m$1,ed,m$2;
    return!FSharpStation.parsed()?Concurrency.Zero():(m$1=FSharpStation.codeMirror().editorO,m$1!=null&&m$1.$==1?(ed=m$1.$0,(m$2=CodeSnippet$1.FetchO(FSharpStation.currentCodeSnippetId().c),m$2!=null&&m$2.$==1?Concurrency.Bind(FSharpStation.autoCompleteClient().MustParse(FSharpStation.parseFile(),m$2.$0.get_NameSanitized()),function(a)
    {
     return a?Concurrency.Zero():(ed.performLint(),Concurrency.Zero());
    }):Concurrency.Zero())):Concurrency.Zero());
   })),null);
  },FSharpStation.codeMsgs());
  SC$1.styleEditor="\r\n      div textarea {\r\n      font-family: monospace;\r\n      }\r\n      .code-editor-list-tile {\r\n      white-space: nowrap; \r\n      border-style: solid none none;\r\n      border-color: white;\r\n      border-width: 1px;\r\n      background-color: #D8D8D8;\r\n      display: flex;\r\n      }\r\n      .code-editor-list-text{\r\n      padding: 1px 10px 1px 5px;\r\n      overflow:hidden;\r\n      text-overflow: ellipsis;\r\n      white-space: nowrap;\r\n      flex: 1;\r\n      }\r\n      \r\n      .code-editor-list-tile.direct-predecessor {\r\n      font-weight: bold;\r\n      }\r\n      .code-editor-list-tile.indirect-predecessor {\r\n      color: blue;\r\n      }\r\n      .code-editor-list-tile.selected {\r\n      background-color: #77F;\r\n      color: white;\r\n      }\r\n      .code-editor-list-tile.hovering {\r\n      background: lightgray;\r\n      }\r\n      .code-editor-list-tile.hovering.selected {\r\n      background:  blue;\r\n      }\r\n      .code-editor-list-tile>.predecessor {\r\n      font-weight: bold;\r\n      border-style: inset;\r\n      border-width: 1px;\r\n      text-align: center;\r\n      color: transparent;\r\n      }\r\n      .code-editor-list-tile.direct-predecessor>.predecessor {\r\n      color: blue;\r\n      }\r\n      \r\n      .CodeMirror { height: 100%; }\r\n      \r\n      .node {\r\n          background-color:white; \r\n          width: 2ch; \r\n          color: #A03; \r\n          font-weight:bold; \r\n          text-align: center;\r\n          font-family: arial;\r\n      }\r\n      .Warning { text-decoration: underline lightblue } \r\n      .Error   { text-decoration: underline red       } \r\n      .body    { margin         : 0px                 }\r\n          ";
  SC$1.spl1=SplitterBar.New$1(20).Children([HtmlNode.style("grid-row: 2 / 4")]);
  s$2="CodeEditor."+"splitterV1";
  v$5=FSharpStation.spl1().get_Var();
  v$6=window.localStorage.getItem(s$2);
  v$6!==null?v$5.set_RVal(((Provider.Id())())(JSON.parse(v$6))):void 0;
  Val.sink(function(v$7)
  {
   window.localStorage.setItem(s$2,JSON.stringify(((Provider.Id())())(v$7)));
  },v$5);
  SC$1.Messages=List.ofArray([["Output",TextArea.New$2(FSharpStation.codeMsgs()).Placeholder("Output:").Title("Messages").get_Render()],["JavaScript",TextArea.New$2(FSharpStation.codeJS()).Placeholder("Javascript:").Title("JavaScript code generated").get_Render()],["F# code",TextArea.New$2(FSharpStation.codeFS()).Placeholder("F# code:").Title("F# code assembled").get_Render()],["WS Result",HtmlNode.div([HtmlNode.div([HtmlNode.Id("TestNode"),HtmlNode.style("background: white; height: 100%; width: 100%; ")])])]]);
  SC$1.snippetList=HtmlNode.bindHElem(FSharpStation.listEntries,(x=FSharpStation.codeSnippets().v,View.SnapshotOn((FSharpStation.codeSnippets())["var"].RVal(),FSharpStation.refresh().v,x)));
  SC$1.buttonsH=HtmlNode.div([Button.New$1("Add code").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.addCode();
  })).get_Render(),Button.New$1("<<").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.indentCodeOut();
  })).Disabled(FSharpStation.noSelectionVal()).get_Render(),Button.New$1(">>").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.indentCodeIn();
  })).Disabled(FSharpStation.noSelectionVal()).get_Render(),FSharpStation.loadFileElement().get_Render().Style("grid-column: 4/6"),Button.New$1("Parse F#").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.parseFS();
  })).Disabled(FSharpStation.noSelectionVal()).get_Render(),Button.New$1("Evaluate F# (FSI)").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.evaluateFS();
  })).Disabled(FSharpStation.noSelectionVal()).get_Render(),Button.New$1("Get F# code ==>").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.getFSCode();
  })).Disabled(FSharpStation.noSelectionVal()).get_Render(),Button.New$1("Delete code").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.deleteCode();
  })).Disabled(FSharpStation.noSelectionVal()).get_Render(),HtmlNode.span([]),HtmlNode.span([]),Button.New$1("Save as...").Class("btn            ").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.downloadFile();
  })).get_Render().AddChildren([HtmlNode.classIf("btn-primary",FSharpStation.dirty())]),HtmlNode.span([]),Button.New$1("Compile WebSharper").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.justCompile();
  })).Disabled(FSharpStation.noSelectionVal()).get_Render(),Button.New$1("Run WebSharper in ...").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.compileRun();
  })).Disabled(FSharpStation.noSelectionVal()).get_Render(),HtmlNode.someElt(Doc.Select([AttrProxy.Create("id","Position")],FSharpStation.positionTxt,List.ofArray([Position.Below,Position.Right,Position.NewBrowser]),FSharpStation.position())),HtmlNode.style("\r\n                    overflow: hidden;\r\n                    display: grid;\r\n                    grid-template-columns: repeat(8, 12.1%);\r\n                    bxackground-color: #eee;\r\n                    padding : 5px;\r\n                    grid-gap: 5px;\r\n                ")]);
  SC$1.title={
   $:0,
   $0:Input.New$2((view$1=Val.toView(Val.fixit(FSharpStation.currentCodeSnippetId())),(contentVar$1=Var.Create$1(null),(changingIRefO$1=[null],(contentVarChanged$1=[0],(refVarChanged$1=[0],(View.Sink(function()
   {
    var o,r;
    o=changingIRefO$1[0];
    o==null?void 0:(r=o.$0,contentVarChanged$1[0]>refVarChanged$1[0]?refVarChanged$1[0]=contentVarChanged$1[0]:!Unchecked.Equals(r.RVal(),contentVar$1.c)?(refVarChanged$1[0]=refVarChanged$1[0]+1,r.set_RVal(contentVar$1.c)):void 0);
   },contentVar$1.v),View.Sink(function()
   {
    var o,r;
    o=changingIRefO$1[0];
    o==null?void 0:(r=o.$0,refVarChanged$1[0]>contentVarChanged$1[0]?contentVarChanged$1[0]=refVarChanged$1[0]:!Unchecked.Equals(r.RVal(),contentVar$1.c)?(contentVarChanged$1[0]=contentVarChanged$1[0]+10,Var.Set(contentVar$1,r.RVal())):void 0);
   },View.Bind(function(cur)
   {
    var r;
    r=FSharpStation.curSnippetNameOf(cur);
    changingIRefO$1[0]={
     $:1,
     $0:r
    };
    refVarChanged$1[0]=contentVarChanged$1[0]+100;
    Var.Set(contentVar$1,r.RVal());
    return r.RView();
   },view$1)),contentVar$1))))))).Prefix(HtmlNode.htmlText("name:")).get_Render()
  };
  SC$1.messages={
   $:1,
   $0:TabStrip.New$1(FSharpStation.Messages()).get_Top()
  };
  SC$1.code={
   $:0,
   $0:FSharpStation.codeMirror().get_Render()
  };
  SC$1.snippets={
   $:0,
   $0:FSharpStation.snippetList()
  };
  SC$1.buttons={
   $:0,
   $0:FSharpStation.buttonsH()
  };
  SC$1.title_code=SplitterStructure.New$2(FSharpStation.title(),FSharpStation.code(),(Runtime.Curried3(FSharpStation.fixedHorSplitter1))(34));
  SC$1.code_buttons=SplitterStructure.New$2(FSharpStation.title_code(),FSharpStation.buttons(),(Runtime.Curried3(FSharpStation.fixedHorSplitter2))(80));
  SC$1.snippets_code=SplitterStructure.New$6(true,FSharpStation.snippets(),FSharpStation.code_buttons(),15);
  SC$1.main_messages=SplitterStructure.New$6(false,FSharpStation.snippets_code(),FSharpStation.messages(),82);
  SC$1.rootSplitter=SplitterNode.New$2(FSharpStation.main_messages());
  x$1=(x$2=HtmlNode.div([HtmlNode.style("height: 100vh; width: 100% "),FSharpStation.rootSplitter().get_Render().Style("height: 100%; width: 100% "),HtmlNode.script([HtmlNode.src("/EPFileX/FileSaver/FileSaver.js"),HtmlNode.type("text/javascript")]),HtmlNode.script([HtmlNode.src("http://code.jquery.com/jquery-3.1.1.min.js"),HtmlNode.type("text/javascript")]),HtmlNode.script([HtmlNode.src("http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"),HtmlNode.type("text/javascript")]),HtmlNode.link([HtmlNode.href("http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")]),HtmlNode.link([HtmlNode.href("/EPFileX/css/main.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")]),HtmlNode.css(FSharpStation.styleEditor()),HtmlNode.style(" \r\n                  color      : #333;\r\n                  font-size  : small;\r\n                  font-family: monospace;\r\n                  line-height: 1.2;\r\n                      ")]),(HtmlNode.renderDoc())(x$2));
  Doc.Run(window.document.body,x$1);
  SC$1.$cctor=window.ignore;
 });
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$2=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$2?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$2:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$2=(Provider.DecodeUnion(void 0,"$",[[0,[["$0","Item",Provider.Id(),0]]],[1,[["$0","Item",Provider.Id(),1]]],[2,[["$0","Item",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$4,1]]],[3,[["$0","Item",Provider.DecodeArray(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$4),0]]],[4,[["$0","Item1",Provider.Id(),1],["$1","Item2",Provider.DecodeArray(Provider.DecodeTuple([Provider.Id(),_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$3])),0]]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$4=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$4?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$4:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$4=(Provider.DecodeRecord(CodeSnippet,[["name",Provider.Id(),0],["content",Provider.Id(),0],["parent",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j,1],["predecessors",Provider.DecodeList(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j),0],["id",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j,0],["expanded",Provider.Id(),0],["level",Provider.Id(),0],["properties",Provider.DecodeStringMap(Provider.Id()),0]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$3=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$3?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$3:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$3=(Provider.DecodeUnion(void 0,"$",[[0,[]],[1,[]],[2,[]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$2=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$2?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$2:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$2=(Provider.EncodeUnion(void 0,"$",[[0,[]],[1,[["$0","Item",Provider.Id(),0]]],[2,[["$0","Item",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j,0]]],[3,[["$0","Item",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j,0]]],[4,[["$0","Item",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j,0]]],[5,[["$0","Item",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j,0]]],[6,[["$0","Item",Provider.EncodeArray(Provider.Id()),0]]],[7,[["$0","Item",Provider.EncodeArray(Provider.Id()),0]]],[8,[["$0","Item",Provider.EncodeArray(Provider.Id()),0]]],[9,[["$0","Item",Provider.EncodeArray(Provider.Id()),0]]],[10,[["$0","Item",Provider.EncodeArray(Provider.Id()),0]]],[11,[]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_GeneratedPrintf.p$1=function($1)
 {
  return $1.$==1?"Snippet Not Found "+PrintfHelpers.prettyPrint($1.$0):"FSMessage ("+PrintfHelpers.prettyPrint($1.$0)+", "+_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_GeneratedPrintf.p($1.$1)+")";
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_GeneratedPrintf.p=function($1)
 {
  return $1.$==2?"FSInfor":$1.$==1?"FSWarning":"FSError";
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v=(Provider.DecodeUnion(CodeSnippetId,"$",[[0,[["$0","Item",Provider.Id(),0]]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$3=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$3?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$3:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$3=(Provider.EncodeRecord(CodeSnippet,[["name",Provider.Id(),0],["content",Provider.Id(),0],["parent",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j,1],["predecessors",Provider.EncodeList(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j),0],["id",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j,0],["expanded",Provider.Id(),0],["level",Provider.Id(),0],["properties",Provider.EncodeStringMap(Provider.Id()),0]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$4=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$4?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$4:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$4=(Provider.EncodeUnion(void 0,"$",[[0,[["$0","Item",Provider.Id(),0]]],[1,[["$0","Item",Provider.Id(),1]]],[2,[["$0","Item",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$3,1]]],[3,[["$0","Item",Provider.EncodeArray(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$3),0]]],[4,[["$0","Item1",Provider.Id(),1],["$1","Item2",Provider.EncodeArray(Provider.EncodeTuple([Provider.Id(),_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$5])),0]]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$5=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$5?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$5:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$5=(Provider.EncodeUnion(void 0,"$",[[0,[]],[1,[]],[2,[]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$5=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$5?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$5:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$5=(Provider.DecodeUnion(void 0,"$",[[0,[]],[1,[["$0","Item",Provider.Id(),0]]],[2,[["$0","Item",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j,0]]],[3,[["$0","Item",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j,0]]],[4,[["$0","Item",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j,0]]],[5,[["$0","Item",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j,0]]],[6,[["$0","Item",Provider.DecodeArray(Provider.Id()),0]]],[7,[["$0","Item",Provider.DecodeArray(Provider.Id()),0]]],[8,[["$0","Item",Provider.DecodeArray(Provider.Id()),0]]],[9,[["$0","Item",Provider.DecodeArray(Provider.Id()),0]]],[10,[["$0","Item",Provider.DecodeArray(Provider.Id()),0]]],[11,[]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$6=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$6?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$6:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$6=(Provider.DecodeUnion(void 0,"$",[[0,[["$0","Item",Provider.Id(),0]]],[1,[["$0","Item",Provider.DecodeArray(Provider.Id()),0]]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$6=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$6?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$6:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$6=(Provider.EncodeUnion(void 0,"$",[[0,[]],[1,[["$0","Item",Provider.Id(),0]]],[2,[]],[3,[]],[4,[]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_GeneratedPrintf.p$2=function($1)
 {
  return $1.$==16?"KMultiple "+PrintfHelpers.printArray(function($2)
  {
   return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_GeneratedPrintf.p$2($2);
  },$1.$0):$1.$==15?"KUnionCase "+GeneratedPrintf.p$19($1.$0):$1.$==14?"KNamespaces "+GeneratedPrintf.p$16($1.$0):$1.$==13?"KCompilerLocation "+GeneratedPrintf.p$15($1.$0):$1.$==12?"KTypeSig "+PrintfHelpers.prettyPrint($1.$0):$1.$==11?"KToolTip "+PrintfHelpers.printArray(function($2)
  {
   return GeneratedPrintf.p$1($2);
  },$1.$0):$1.$==10?"KDeclarations "+PrintfHelpers.printArray(function($2)
  {
   return GeneratedPrintf.p$13($2);
  },$1.$0):$1.$==9?"KFindDecl "+GeneratedPrintf.p$12($1.$0):$1.$==8?"KColorizations "+PrintfHelpers.printList(function($2)
  {
   return GeneratedPrintf.p$10($2);
  },$1.$0):$1.$==7?"KErrors "+GeneratedPrintf.p$8($1.$0):$1.$==6?"KMethod "+GeneratedPrintf.p$5($1.$0):$1.$==5?"KHelp "+PrintfHelpers.prettyPrint($1.$0):$1.$==4?"KSymbolUse "+GeneratedPrintf.p$3($1.$0):$1.$==3?"KCompletion "+PrintfHelpers.printArray(function($2)
  {
   return GeneratedPrintf.p$2($2);
  },$1.$0):$1.$==2?"KHelpText "+GeneratedPrintf.p($1.$0):$1.$==1?"KError "+PrintfHelpers.prettyPrint($1.$0):"KInfo "+PrintfHelpers.prettyPrint($1.$0);
 };
 GeneratedPrintf.p$19=function($1)
 {
  return"{"+("Text = "+PrintfHelpers.prettyPrint($1.Text))+"; "+("Position = "+GeneratedPrintf.p$20($1.Position))+"}";
 };
 GeneratedPrintf.p$20=function($1)
 {
  return"{"+("Line = "+PrintfHelpers.prettyPrint($1.Line))+"; "+("Col = "+PrintfHelpers.prettyPrint($1.Col))+"}";
 };
 GeneratedPrintf.p$16=function($1)
 {
  return"{"+("Opens = "+PrintfHelpers.printArray(function($2)
  {
   return GeneratedPrintf.p$17($2);
  },$1.Opens))+"; "+("Qualifies = "+PrintfHelpers.printArray(function($2)
  {
   return GeneratedPrintf.p$18($2);
  },$1.Qualifies))+"; "+("Word = "+PrintfHelpers.prettyPrint($1.Word))+"}";
 };
 GeneratedPrintf.p$18=function($1)
 {
  return"{"+("Name = "+PrintfHelpers.prettyPrint($1.Name))+"; "+("Qualifier = "+PrintfHelpers.prettyPrint($1.Qualifier))+"}";
 };
 GeneratedPrintf.p$17=function($1)
 {
  return"{"+("Namespace = "+PrintfHelpers.prettyPrint($1.Namespace))+"; "+("Name = "+PrintfHelpers.prettyPrint($1.Name))+"; "+("Type = "+PrintfHelpers.prettyPrint($1.Type))+"; "+("Line = "+PrintfHelpers.prettyPrint($1.Line))+"; "+("Column = "+PrintfHelpers.prettyPrint($1.Column))+"; "+("MultipleNames = "+PrintfHelpers.prettyPrint($1.MultipleNames))+"}";
 };
 GeneratedPrintf.p$15=function($1)
 {
  return"{"+("Fsc = "+PrintfHelpers.prettyPrint($1.Fsc))+"; "+("Fsi = "+PrintfHelpers.prettyPrint($1.Fsi))+"; "+("MSBuild = "+PrintfHelpers.prettyPrint($1.MSBuild))+"}";
 };
 GeneratedPrintf.p$13=function($1)
 {
  return"{"+("Declaration = "+GeneratedPrintf.p$14($1.Declaration))+"; "+("Nested = "+PrintfHelpers.printArray(function($2)
  {
   return GeneratedPrintf.p$14($2);
  },$1.Nested))+"}";
 };
 GeneratedPrintf.p$14=function($1)
 {
  return"{"+("UniqueName = "+PrintfHelpers.prettyPrint($1.UniqueName))+"; "+("Name = "+PrintfHelpers.prettyPrint($1.Name))+"; "+("Glyph = "+PrintfHelpers.prettyPrint($1.Glyph))+"; "+("GlyphChar = "+PrintfHelpers.prettyPrint($1.GlyphChar))+"; "+("IsTopLevel = "+PrintfHelpers.prettyPrint($1.IsTopLevel))+"; "+("Range = "+GeneratedPrintf.p$11($1.Range))+"; "+("BodyRange = "+GeneratedPrintf.p$11($1.BodyRange))+"; "+("File = "+PrintfHelpers.prettyPrint($1.File))+"; "+("EnclosingEntity = "+PrintfHelpers.prettyPrint($1.EnclosingEntity))+"; "+("IsAbstract = "+PrintfHelpers.prettyPrint($1.IsAbstract))+"}";
 };
 GeneratedPrintf.p$12=function($1)
 {
  return"{"+("File = "+PrintfHelpers.prettyPrint($1.File))+"; "+("Line = "+PrintfHelpers.prettyPrint($1.Line))+"; "+("Column = "+PrintfHelpers.prettyPrint($1.Column))+"}";
 };
 GeneratedPrintf.p$10=function($1)
 {
  return"{"+("Range = "+GeneratedPrintf.p$11($1.Range))+"; "+("Kind = "+PrintfHelpers.prettyPrint($1.Kind))+"}";
 };
 GeneratedPrintf.p$11=function($1)
 {
  return"{"+("StartLine = "+PrintfHelpers.prettyPrint($1.StartLine))+"; "+("StartColumn = "+PrintfHelpers.prettyPrint($1.StartColumn))+"; "+("EndLine = "+PrintfHelpers.prettyPrint($1.EndLine))+"; "+("EndColumn = "+PrintfHelpers.prettyPrint($1.EndColumn))+"}";
 };
 GeneratedPrintf.p$8=function($1)
 {
  return"{"+("File = "+PrintfHelpers.prettyPrint($1.File))+"; "+("Errors = "+PrintfHelpers.printArray(function($2)
  {
   return GeneratedPrintf.p$9($2);
  },$1.Errors))+"}";
 };
 GeneratedPrintf.p$9=function($1)
 {
  return"{"+("FileName = "+PrintfHelpers.prettyPrint($1.FileName))+"; "+("StartLine = "+PrintfHelpers.prettyPrint($1.StartLine))+"; "+("EndLine = "+PrintfHelpers.prettyPrint($1.EndLine))+"; "+("StartColumn = "+PrintfHelpers.prettyPrint($1.StartColumn))+"; "+("EndColumn = "+PrintfHelpers.prettyPrint($1.EndColumn))+"; "+("Message = "+PrintfHelpers.prettyPrint($1.Message))+"; "+("Subcategory = "+PrintfHelpers.prettyPrint($1.Subcategory))+"}";
 };
 GeneratedPrintf.p$5=function($1)
 {
  return"{"+("Name = "+PrintfHelpers.prettyPrint($1.Name))+"; "+("CurrentParameter = "+PrintfHelpers.prettyPrint($1.CurrentParameter))+"; "+("Overloads = "+PrintfHelpers.printList(function($2)
  {
   return GeneratedPrintf.p$6($2);
  },$1.Overloads))+"}";
 };
 GeneratedPrintf.p$6=function($1)
 {
  return"{"+("Tip = "+PrintfHelpers.printList(function($2)
  {
   return PrintfHelpers.printList(function($3)
   {
    return GeneratedPrintf.p$1($3);
   },$2);
  },$1.Tip))+"; "+("TypeText = "+PrintfHelpers.prettyPrint($1.TypeText))+"; "+("Parameters = "+PrintfHelpers.printList(function($2)
  {
   return GeneratedPrintf.p$7($2);
  },$1.Parameters))+"; "+("IsStaticArguments = "+PrintfHelpers.prettyPrint($1.IsStaticArguments))+"}";
 };
 GeneratedPrintf.p$7=function($1)
 {
  return"{"+("Name = "+PrintfHelpers.prettyPrint($1.Name))+"; "+("CanonicalTypeTextForSorting = "+PrintfHelpers.prettyPrint($1.CanonicalTypeTextForSorting))+"; "+("Display = "+PrintfHelpers.prettyPrint($1.Display))+"; "+("Description = "+PrintfHelpers.prettyPrint($1.Description))+"}";
 };
 GeneratedPrintf.p$3=function($1)
 {
  return"{"+("Name = "+PrintfHelpers.prettyPrint($1.Name))+"; "+("Uses = "+PrintfHelpers.printList(function($2)
  {
   return GeneratedPrintf.p$4($2);
  },$1.Uses))+"}";
 };
 GeneratedPrintf.p$4=function($1)
 {
  return"{"+("FileName = "+PrintfHelpers.prettyPrint($1.FileName))+"; "+("StartLine = "+PrintfHelpers.prettyPrint($1.StartLine))+"; "+("StartColumn = "+PrintfHelpers.prettyPrint($1.StartColumn))+"; "+("EndLine = "+PrintfHelpers.prettyPrint($1.EndLine))+"; "+("EndColumn = "+PrintfHelpers.prettyPrint($1.EndColumn))+"; "+("IsFromDefinition = "+PrintfHelpers.prettyPrint($1.IsFromDefinition))+"; "+("IsFromAttribute = "+PrintfHelpers.prettyPrint($1.IsFromAttribute))+"; "+("IsFromComputationExpression = "+PrintfHelpers.prettyPrint($1.IsFromComputationExpression))+"; "+("IsFromDispatchSlotImplementation = "+PrintfHelpers.prettyPrint($1.IsFromDispatchSlotImplementation))+"; "+("IsFromPattern = "+PrintfHelpers.prettyPrint($1.IsFromPattern))+"; "+("IsFromType = "+PrintfHelpers.prettyPrint($1.IsFromType))+"}";
 };
 GeneratedPrintf.p$2=function($1)
 {
  return"{"+("Name = "+PrintfHelpers.prettyPrint($1.Name))+"; "+("ReplacementText = "+PrintfHelpers.prettyPrint($1.ReplacementText))+"; "+("Glyph = "+PrintfHelpers.prettyPrint($1.Glyph))+"; "+("GlyphChar = "+PrintfHelpers.prettyPrint($1.GlyphChar))+"}";
 };
 GeneratedPrintf.p=function($1)
 {
  return"{"+("Name = "+PrintfHelpers.prettyPrint($1.Name))+"; "+("Overloads = "+PrintfHelpers.printList(function($2)
  {
   return PrintfHelpers.printList(function($3)
   {
    return GeneratedPrintf.p$1($3);
   },$2);
  },$1.Overloads))+"}";
 };
 GeneratedPrintf.p$1=function($1)
 {
  return"{"+("Signature = "+PrintfHelpers.prettyPrint($1.Signature))+"; "+("Comment = "+PrintfHelpers.prettyPrint($1.Comment))+"}";
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$7=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$7?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$7:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$7=(Provider.DecodeUnion(void 0,"$",[[0,[["$0","Item",Provider.Id(),0]]],[1,[["$0","Item",Provider.Id(),0]]],[2,[[null,null,_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$28]]],[3,[["$0","Item",Provider.DecodeArray(Provider.Id()),0]]],[4,[[null,null,_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$25]]],[5,[["$0","Item",Provider.Id(),0]]],[6,[[null,null,_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$22]]],[7,[[null,null,_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$20]]],[8,[["$0","Item",Provider.DecodeList(Provider.Id()),0]]],[9,[[null,true,Provider.Id()]]],[10,[["$0","Item",Provider.DecodeArray(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$15),0]]],[11,[["$0","Item",Provider.DecodeArray(Provider.Id()),0]]],[12,[["$0","Item",Provider.Id(),0]]],[13,[[null,true,Provider.Id()]]],[14,[[null,null,_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$10]]],[15,[[null,true,Provider.Id()]]],[16,[["$0","Item",Provider.DecodeArray(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$7),0]]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$28=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$28?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$28:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$28=(Provider.DecodeRecord(void 0,[["Name",Provider.Id(),0],["Overloads",Provider.DecodeList(Provider.DecodeList(Provider.Id())),0]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$25=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$25?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$25:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$25=(Provider.DecodeRecord(void 0,[["Name",Provider.Id(),0],["Uses",Provider.DecodeList(Provider.Id()),0]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$22=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$22?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$22:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$22=(Provider.DecodeRecord(void 0,[["Name",Provider.Id(),0],["CurrentParameter",Provider.Id(),0],["Overloads",Provider.DecodeList(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$23),0]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$23=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$23?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$23:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$23=(Provider.DecodeRecord(void 0,[["Tip",Provider.DecodeList(Provider.DecodeList(Provider.Id())),0],["TypeText",Provider.Id(),0],["Parameters",Provider.DecodeList(Provider.Id()),0],["IsStaticArguments",Provider.Id(),0]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$20=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$20?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$20:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$20=(Provider.DecodeRecord(void 0,[["File",Provider.Id(),0],["Errors",Provider.DecodeArray(Provider.Id()),0]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$15=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$15?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$15:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$15=(Provider.DecodeRecord(void 0,[["Declaration",Provider.Id(),0],["Nested",Provider.DecodeArray(Provider.Id()),0]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$10=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$10?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$10:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$10=(Provider.DecodeRecord(void 0,[["Opens",Provider.DecodeArray(Provider.Id()),0],["Qualifies",Provider.DecodeArray(Provider.Id()),0],["Word",Provider.Id(),0]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$7=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$7?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$7:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$7=(Provider.EncodeUnion(void 0,"$",[[0,[]],[1,[["$0","Item",Provider.Id(),0]]],[2,[["$0","Item1",Provider.Id(),0],["$1","Item2",Provider.Id(),0],["$2","Item3",Provider.Id(),0]]],[3,[["$0","Item1",Provider.Id(),0],["$1","Item2",Provider.Id(),0],["$2","Item3",Provider.Id(),0],["$3","Item4",Provider.Id(),0]]],[4,[["$0","Item1",Provider.Id(),0],["$1","Item2",Provider.Id(),0],["$2","Item3",Provider.Id(),0]]],[5,[["$0","Item1",Provider.Id(),0],["$1","Item2",Provider.Id(),0],["$2","Item3",Provider.Id(),0],["$3","Item4",Provider.Id(),0]]],[6,[["$0","Item1",Provider.Id(),0],["$1","Item2",Provider.Id(),0],["$2","Item3",Provider.EncodeArray(Provider.EncodeTuple([Provider.Id(),Provider.EncodeTuple([Provider.Id(),Provider.Id(),Provider.Id()])])),0]]],[7,[["$0","Item1",Provider.Id(),0],["$1","Item2",Provider.Id(),0]]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v=(Provider.EncodeUnion(CodeSnippetId,"$",[[0,[["$0","Item",Provider.Id(),0]]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$1=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$1?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$1:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$1=(Provider.DecodeUnion(void 0,"$",[[0,[]],[1,[]],[2,[]],[3,[]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$1=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$1?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$1:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$1=(Provider.EncodeUnion(void 0,"$",[[0,[]],[1,[]],[2,[]],[3,[]]]))();
 };
});