
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
                       CIPHERSpaceLoadFiles(["/Scripts/WebSharper/WebSharper.Core.JavaScript/Runtime.js", "/Scripts/WebSharper/WebSharper.Main.js", "/Scripts/WebSharper/WebSharper.Collections.js", "/Scripts/WebSharper/WebSharper.Control.js", "/Scripts/WebSharper/WebSharper.Web.js", "/Scripts/WebSharper/Common.js", "/Scripts/WebSharper/Remote.js", "/Scripts/WebSharper/WebSharper.UI.Next.js"], function()
{
 "use strict";
 var FSSGlobal,FsStationShared,CodeSnippetId,CodeSnippet,FSMessage,MessagingClient,FsStationClientErr,FsStationClient,HtmlNode,Val,HelperType,HtmlNode$1,Template,Button,Input,Hoverable,TextArea,CodeMirrorEditor,CodeMirror,SplitterBar,Grid,RunCode,EditorRpc,RunNode,FSharpStation,Position,CodeSnippet$1,SC$1,_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_GeneratedPrintf,_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder,_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder,WebSharper,Guid,IntelliFactory,Runtime,Concurrency,JSON,Remoting,AjaxRemotingProvider,Rop,Option,Wrap,Result,Strings,Arrays,Seq,UI,Next,View,Doc,AttrModule,AttrProxy,Var,Input$1,Mouse,List,Collections,FSharpSet,BalancedTree,Unchecked,PrintfHelpers,Json,Provider,Slice,Option$1,ListModel,console;
 FSSGlobal=window.FSSGlobal=window.FSSGlobal||{};
 FsStationShared=FSSGlobal.FsStationShared=FSSGlobal.FsStationShared||{};
 CodeSnippetId=FsStationShared.CodeSnippetId=FsStationShared.CodeSnippetId||{};
 CodeSnippet=FsStationShared.CodeSnippet=FsStationShared.CodeSnippet||{};
 FSMessage=FsStationShared.FSMessage=FsStationShared.FSMessage||{};
 MessagingClient=FsStationShared.MessagingClient=FsStationShared.MessagingClient||{};
 FsStationClientErr=FsStationShared.FsStationClientErr=FsStationShared.FsStationClientErr||{};
 FsStationClient=FsStationShared.FsStationClient=FsStationShared.FsStationClient||{};
 HtmlNode=FSSGlobal.HtmlNode=FSSGlobal.HtmlNode||{};
 Val=HtmlNode.Val=HtmlNode.Val||{};
 HelperType=Val.HelperType=Val.HelperType||{};
 HtmlNode$1=HtmlNode.HtmlNode=HtmlNode.HtmlNode||{};
 Template=FSSGlobal.Template=FSSGlobal.Template||{};
 Button=Template.Button=Template.Button||{};
 Input=Template.Input=Template.Input||{};
 Hoverable=Template.Hoverable=Template.Hoverable||{};
 TextArea=Template.TextArea=Template.TextArea||{};
 CodeMirrorEditor=Template.CodeMirrorEditor=Template.CodeMirrorEditor||{};
 CodeMirror=Template.CodeMirror=Template.CodeMirror||{};
 SplitterBar=Template.SplitterBar=Template.SplitterBar||{};
 Grid=Template.Grid=Template.Grid||{};
 RunCode=FSSGlobal.RunCode=FSSGlobal.RunCode||{};
 EditorRpc=RunCode.EditorRpc=RunCode.EditorRpc||{};
 RunNode=RunCode.RunNode=RunCode.RunNode||{};
 FSharpStation=FSSGlobal.FSharpStation=FSSGlobal.FSharpStation||{};
 Position=FSharpStation.Position=FSharpStation.Position||{};
 CodeSnippet$1=FSharpStation.CodeSnippet=FSharpStation.CodeSnippet||{};
 SC$1=window["StartupCode$D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project_xxx$ F# FSSGlobal"]=window["StartupCode$D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project_xxx$ F# FSSGlobal"]||{};
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_GeneratedPrintf=window["D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project$xxx_GeneratedPrintf"]=window["D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project$xxx_GeneratedPrintf"]||{};
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder=window["D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project$xxx_JsonDecoder"]=window["D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project$xxx_JsonDecoder"]||{};
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder=window["D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project$xxx_JsonEncoder"]=window["D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project$xxx_JsonEncoder"]||{};
 WebSharper=window.WebSharper;
 Guid=WebSharper&&WebSharper.Guid;
 IntelliFactory=window.IntelliFactory;
 Runtime=IntelliFactory&&IntelliFactory.Runtime;
 Concurrency=WebSharper&&WebSharper.Concurrency;
 JSON=window.JSON;
 Remoting=WebSharper&&WebSharper.Remoting;
 AjaxRemotingProvider=Remoting&&Remoting.AjaxRemotingProvider;
 Rop=window.Rop;
 Option=Rop&&Rop.Option;
 Wrap=Rop&&Rop.Wrap;
 Result=Rop&&Rop.Result;
 Strings=WebSharper&&WebSharper.Strings;
 Arrays=WebSharper&&WebSharper.Arrays;
 Seq=WebSharper&&WebSharper.Seq;
 UI=WebSharper&&WebSharper.UI;
 Next=UI&&UI.Next;
 View=Next&&Next.View;
 Doc=Next&&Next.Doc;
 AttrModule=Next&&Next.AttrModule;
 AttrProxy=Next&&Next.AttrProxy;
 Var=Next&&Next.Var;
 Input$1=Next&&Next.Input;
 Mouse=Input$1&&Input$1.Mouse;
 List=WebSharper&&WebSharper.List;
 Collections=WebSharper&&WebSharper.Collections;
 FSharpSet=Collections&&Collections.FSharpSet;
 BalancedTree=Collections&&Collections.BalancedTree;
 Unchecked=WebSharper&&WebSharper.Unchecked;
 PrintfHelpers=WebSharper&&WebSharper.PrintfHelpers;
 Json=WebSharper&&WebSharper.Json;
 Provider=Json&&Json.Provider;
 Slice=WebSharper&&WebSharper.Slice;
 Option$1=WebSharper&&WebSharper.Option;
 ListModel=Next&&Next.ListModel;
 console=window.console;
 CodeSnippetId.get_New=function()
 {
  return{
   $:0,
   $0:Guid.NewGuid()
  };
 };
 CodeSnippet=FsStationShared.CodeSnippet=Runtime.Class({
  get_Name:function()
  {
   return FsStationShared.snippetName(this.name,this.content);
  }
 },null,CodeSnippet);
 CodeSnippet.New=function(name,content,parent,predecessors,companions,id,expanded)
 {
  return new CodeSnippet({
   name:name,
   content:content,
   parent:parent,
   predecessors:predecessors,
   companions:companions,
   id:id,
   expanded:expanded
  });
 };
 FSMessage.GetIdentification={
  $:7
 };
 MessagingClient=FsStationShared.MessagingClient=Runtime.Class({
  poMessage:function(msg)
  {
   var $this,b;
   $this=this;
   b=null;
   return Concurrency.Delay(function()
   {
    return Concurrency.Bind($this.sendMessage({
     $:0,
     $0:"WebServer:PostOffice"
    },JSON.stringify((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$4())(msg))),function(a)
    {
     return Concurrency.Return((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$4())(JSON.parse(a)));
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
   Concurrency.Start((b=null,Concurrency.Delay(function()
   {
    return Concurrency.While(function()
    {
     return true;
    },Concurrency.Delay(function()
    {
     return Concurrency.Bind((new AjaxRemotingProvider.New()).Async("Remote:CIPHERPrototype.Messaging.awaitRequestFor:278590570",[$this.fromId]),function(a)
     {
      return Concurrency.Bind((new AjaxRemotingProvider.New()).Async("Remote:CIPHERPrototype.Messaging.replyTo:-1092841374",[a.messageId.$0,respond($this.clientId,a.content)]),function()
      {
       return Concurrency.Return(null);
      });
     });
    }));
   })),null);
  },
  get_EndPoint:function()
  {
   return this.wsEndPoint;
  },
  POListeners:function()
  {
   var $this,b;
   $this=this;
   b=null;
   return Concurrency.Delay(function()
   {
    return Concurrency.Bind($this.poMessage({
     $:1
    }),function(a)
    {
     return Concurrency.Return(a.$==1?a.$0:[a.$0]);
    });
   });
  },
  POMessage:function(msg)
  {
   return this.poMessage(msg);
  },
  SendMessage:function(toId,msg)
  {
   return this.sendMessage(toId,msg);
  },
  AwaitMessage:function(respond)
  {
   this.awaitMessage(respond);
  }
 },null,MessagingClient);
 MessagingClient.get_EndPoint_=function()
 {
  return"http://localhost:9000/FSharpStation.html";
 };
 MessagingClient.New=Runtime.Ctor(function(clientId,endPoint)
 {
  this.clientId=clientId;
  this.wsEndPoint=Option.defaultValue("http://localhost:9000/FSharpStation.html",endPoint);
  this.fromId={
   $:0,
   $0:this.clientId
  };
  Remoting.set_EndPoint(this.wsEndPoint);
 },MessagingClient);
 FsStationClientErr=FsStationShared.FsStationClientErr=Runtime.Class({
  Rop_ErrMsg$get_IsWarning:function()
  {
   return false;
  },
  Rop_ErrMsg$get_ErrMsg:function()
  {
   return(function($1)
   {
    return function($2)
    {
     return $1(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_GeneratedPrintf.p($2));
    };
   }(window.id))(this);
  }
 },null,FsStationClientErr);
 FsStationClient=FsStationShared.FsStationClient=Runtime.Class({
  genericMessage:function(txt)
  {
   var $this,b;
   $this=this;
   b=Wrap.wrapper();
   return b.Delay(function()
   {
    return b.Bind$3($this.sendMessage($this.toId,{
     $:6,
     $0:txt
    }),function(a)
    {
     var $1,$2;
     return b.Bind$1(a.$==1&&(($2=a.$0,$2!=null&&$2.$==1)&&($1=a.$0.$0,true))?Result.succeed($1):Result.fail(new FsStationClientErr({
      $:0,
      $0:window.String(a)
     })),function(a$1)
     {
      return b.Return(a$1);
     });
    });
   });
  },
  requestCode:function(snpName)
  {
   var $this,b;
   $this=this;
   b=Wrap.wrapper();
   return b.Delay(function()
   {
    return b.Bind$3($this.sendMessage($this.toId,{
     $:4,
     $0:Strings.SplitChars(snpName,[47],0)
    }),function(a)
    {
     var $1,$2;
     return b.Bind$1(a.$==1&&(($2=a.$0,$2!=null&&$2.$==1)&&($1=a.$0.$0,true))?Result.succeed($1):Result.fail(new FsStationClientErr({
      $:0,
      $0:window.String(a)
     })),function(a$1)
     {
      return b.Return(a$1);
     });
    });
   });
  },
  sendMessage:function(toId2,msg)
  {
   var $this,b;
   $this=this;
   b=Wrap.wrapper();
   return b.Delay(function()
   {
    return b.Bind$2($this.msgClient.SendMessage(toId2,JSON.stringify((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$5())(msg))),function(a)
    {
     return b.Return((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$5())(JSON.parse(a)));
    });
   });
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
   return this.genericMessage(txt);
  },
  RequestCode:function(snpPath)
  {
   return this.requestCode(snpPath);
  },
  SendMessage:function(toId2,msg)
  {
   return this.sendMessage(toId2,msg);
  },
  SendMessage$1:function(msg)
  {
   return this.sendMessage(this.toId,msg);
  }
 },null,FsStationClient);
 FsStationClient.get_FSStationId_=function()
 {
  return"FSharpStation-362703e5-e01a-4bac-a083-6fc6eefe0f26";
 };
 FsStationClient.New=Runtime.Ctor(function(clientId,fsStationId,endPoint)
 {
  this.fsIds=Option.defaultValue("FSharpStation-362703e5-e01a-4bac-a083-6fc6eefe0f26",fsStationId);
  this.msgClient=new MessagingClient.New(clientId,{
   $:1,
   $0:Option.defaultValue("http://localhost:9000/FSharpStation.html",endPoint)
  });
  this.toId={
   $:0,
   $0:this.fsIds
  };
 },FsStationClient);
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
  var o;
  return name!==""?name:(o=Seq.tryHead(Seq.filter(function(l)
  {
   return!(Strings.StartsWith(l,"#")||Strings.StartsWith(l,"[<")||Strings.StartsWith(l,"//"));
  },Seq.map(Strings.Trim,Strings.SplitChars(content,[10],1)))),o==null?"<empty>":o.$0);
 };
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
  InsertChildren:function(add)
  {
   return HtmlNode.mapHtmlElement(function($1,$2)
   {
    return new HtmlNode$1({
     $:0,
     $0:$1,
     $1:Seq.append(add,$2)
    });
   },this);
  },
  AddChildren:function(add)
  {
   return HtmlNode.mapHtmlElement(function($1,$2)
   {
    return new HtmlNode$1({
     $:0,
     $0:$1,
     $1:Seq.append($2,add)
    });
   },this);
  },
  Class:function(clas)
  {
   return HtmlNode.replaceAtt("class",this,Val.fixit(clas));
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
 HtmlNode.createIFrame=function(f)
 {
  var cover;
  cover=Var.Create$1(true);
  return HtmlNode.div([HtmlNode.style("position: relative; overflow: hidden; height: 100%; width: 100%;"),HtmlNode.iframe([HtmlNode.style("position: absolute; width:100%; height:100%;"),HtmlNode.frameborder("0"),new HtmlNode$1({
   $:5,
   $0:AttrModule.OnAfterRender(f)
  }),new HtmlNode$1({
   $:5,
   $0:AttrModule.Handler("mouseleave",function()
   {
    return function()
    {
     return Var.Set(cover,true);
    };
   })
  })]),HtmlNode.div([HtmlNode.style("position: absolute;"),HtmlNode.classIf("iframe-cover",Val.map(window.id,cover)),new HtmlNode$1({
   $:5,
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
 HtmlNode.bindHElem=function(hElem,v)
 {
  var g;
  return new HtmlNode$1({
   $:4,
   $0:Doc.BindView((g=HtmlNode.renderDoc(),function(x)
   {
    return g(hElem(x));
   }),Val.toView(Val.fixit(v)))
  });
 };
 HtmlNode.composeDoc=function(elt,dtl,dtlVal)
 {
  var x,f,f$1,g;
  return new HtmlNode$1({
   $:4,
   $0:(x=Val.toView(dtlVal),Doc.BindView((f=(f$1=function(s)
   {
    return Seq.append(dtl,s);
   },function(x$1)
   {
    return elt(f$1(x$1));
   }),(g=HtmlNode.renderDoc(),function(x$1)
   {
    return g(f(x$1));
   })),x))
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
   $:5,
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
   $:4,
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
  return HtmlNode.mapHtmlElement(function($1,$2)
  {
   return new HtmlNode$1({
    $:0,
    $0:$1,
    $1:HtmlNode.replaceAttribute(att,$2,newVal)
   });
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
 HtmlNode.getStyle=function()
 {
  SC$1.$cctor();
  return SC$1.getStyle;
 };
 HtmlNode.getClass=function()
 {
  SC$1.$cctor();
  return SC$1.getClass;
 };
 HtmlNode.getAttr=function(attr,element)
 {
  return(HtmlNode.getAttrChildren(attr))(element.$==0?element.$1:[]);
 };
 HtmlNode.mapHtmlElement=function(f,element)
 {
  return element.$==0?f(element.$0,element.$1):element;
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
  var children;
  return node.$==0?(children=node.$1,{
   $:1,
   $0:Doc.Element(node.$0,HtmlNode.getAttrsFromSeq(children),Seq.choose(HtmlNode.chooseNode,children))
  }):node.$==2?{
   $:1,
   $0:Val.tagDoc(Doc.TextNode,node.$0)
  }:node.$==4?{
   $:1,
   $0:node.$0
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
  }:node.$==5?{
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
    $:5,
    $0:(view=View.Const(""),AttrModule.DynamicPred("disabled",Val.toView(this.disabled),view))
   }),new HtmlNode$1({
    $:5,
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
       $:4,
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
   return Hoverable.New(this.hover,c);
  },
  get_Render:function()
  {
   var $this;
   $this=this;
   return HtmlNode.div(Seq.append(this.content,List.ofArray([HtmlNode.classIf("hovering",this.hover),new HtmlNode$1({
    $:5,
    $0:AttrModule.Handler("mouseenter",function()
    {
     return function()
     {
      return $this.hover.set_RVal(true);
     };
    })
   }),new HtmlNode$1({
    $:5,
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
  return Hoverable.New(Var.Create$1(false),List.ofArray([HtmlNode.style("flex-flow: column;")]));
 };
 Hoverable.get_New=function()
 {
  return Hoverable.New(Var.Create$1(false),List.T.Empty);
 };
 Hoverable.New=function(hover,content)
 {
  return new Hoverable({
   hover:hover,
   content:content
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
   return HtmlNode.span([HtmlNode.someElt(Doc.InputArea([HtmlNode._class(this._class),AttrProxy.Create("id",this.id),HtmlNode.atr("spellcheck",Val.map(function(spl)
   {
    return spl?"true":"false";
   },this.spellcheck)),HtmlNode.atr("title",this.title),HtmlNode.atr("style","height: 100%;  width: 100%"),HtmlNode._placeholder(this.placeholder)],this["var"]))]);
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
 CodeMirrorEditor=Template.CodeMirrorEditor=Runtime.Class({},null,CodeMirrorEditor);
 CodeMirrorEditor.New=Runtime.Ctor(function()
 {
 },CodeMirrorEditor);
 CodeMirror=Template.CodeMirror=Runtime.Class({
  get_Var:function()
  {
   return this["var"];
  },
  OnChange:function(f)
  {
   return CodeMirror.New(this._class,this.style,this.id,this["var"],f,this.editorO);
  },
  Style:function(sty)
  {
   return CodeMirror.New(this._class,Val.fixit(sty),this.id,this["var"],this.onChange,this.editorO);
  },
  SetVar:function(v)
  {
   return CodeMirror.New(this._class,this.style,this.id,v,this.onChange,this.editorO);
  },
  Id:function(id)
  {
   return CodeMirror.New(this._class,this.style,id,this["var"],this.onChange,this.editorO);
  },
  Class:function(clas)
  {
   return CodeMirror.New(Val.fixit(clas),this.style,this.id,this["var"],this.onChange,this.editorO);
  },
  get_Render:function()
  {
   var $this;
   $this=this;
   return HtmlNode.div([HtmlNode["class"](this._class),new HtmlNode$1({
    $:5,
    $0:AttrProxy.Create("id",this.id)
   }),HtmlNode.style("position: relative; height: 300px"),HtmlNode.style(this.style),HtmlNode.div([HtmlNode.style("height: 100%; width: 100%; position: absolute;"),new HtmlNode$1({
    $:5,
    $0:AttrModule.OnAfterRender(function(el)
    {
     window.CIPHERSpaceLoadFiles(Template.codeMirrorIncludes(),function()
     {
      var editor;
      editor=window.CodeMirror(el,{
       theme:"rubyblue",
       lineNumbers:true,
       matchBrackets:true,
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
      editor.on("change",function()
      {
       var v;
       v=editor.getValue();
       $this["var"].RVal()!==v?($this["var"].set_RVal(v),$this.onChange()):void 0;
      });
      View.Sink(function(v)
      {
       if(editor.getValue()!==v)
        {
         editor.setValue(v);
         editor.getDoc().clearHistory();
        }
      },$this["var"].RView());
     });
    })
   })]),HtmlNode.link([HtmlNode.href("/EPFileX/codemirror/content/editor.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")]),HtmlNode.link([HtmlNode.href("/EPFileX/codemirror/content/codemirror.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")]),HtmlNode.link([HtmlNode.href("/EPFileX/codemirror/content/theme/rubyblue.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")]),HtmlNode.link([HtmlNode.href("/EPFileX/codemirror/scripts/addon/display/fullscreen.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")]),HtmlNode.link([HtmlNode.href("/EPFileX/codemirror/scripts/addon/dialog/dialog.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")]),HtmlNode.css(".CodeMirror { height: 100% }")]);
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
  },null);
 };
 CodeMirror.New=function(_class,style,id,_var,onChange,editorO)
 {
  return new CodeMirror({
   _class:_class,
   style:style,
   id:id,
   "var":_var,
   onChange:onChange,
   editorO:editorO
  });
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
    $:5,
    $0:AttrModule.Handler("mousedown",function($1)
    {
     return function($2)
     {
      return startDragging($1,$2);
     };
    })
   }),new HtmlNode$1({
    $:5,
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
  return SplitterBar.New(_var,Val.fixit(10),Val.fixit(75),Val.fixit(true),HtmlNode.div([HtmlNode["class"]("Splitter")]),List.T.Empty,true,false,true,0,0,0,null);
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
          $:5,
          $0:AttrModule.OnAfterRender(function(el)
          {
           function setDimensions()
           {
            Var.Set($this.width,el.getBoundingClientRect().width);
            Var.Set($this.height,el.getBoundingClientRect().height);
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
 EditorRpc.declarations=function(callback,line,col,source)
 {
  EditorRpc.callRPC((new AjaxRemotingProvider.New()).Async("ZafirTranspiler:CIPHERPrototype.Editor.declarations:-2117802712",[source,line,col]),callback);
 };
 EditorRpc.methods=function(callback,line,col,source)
 {
  EditorRpc.callRPC((new AjaxRemotingProvider.New()).Async("ZafirTranspiler:CIPHERPrototype.Editor.methods:-34435681",[source,line,col]),callback);
 };
 EditorRpc.checkSource=function(callback,source)
 {
  EditorRpc.callRPC((new AjaxRemotingProvider.New()).Async("ZafirTranspiler:CIPHERPrototype.Editor.checkSource:2013062947",[source]),callback);
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
  RunHtmlPlusFree:function(node)
  {
   var freeHtml,freeCSS,freeFS,freeJS,freeMsgs,sendMsg,runJS,runFS;
   freeHtml=Var.Create$1("");
   freeCSS=Var.Create$1("");
   freeFS=Var.Create$1("");
   freeJS=Var.Create$1("");
   freeMsgs=Var.Create$1("");
   sendMsg=function(msg)
   {
    var $1;
    Var.Set(freeMsgs,($1=freeMsgs.c,$1===null?msg:$1===""?msg:msg===null?$1:msg===""?$1:$1+"\n"+msg));
   };
   runJS=function()
   {
    var $1,$2,v;
    sendMsg("Running JavaScript...");
    try
    {
     $2=(v=window["eval"](freeJS.c),(sendMsg("Done!"),window.String(v)));
    }
    catch(e)
    {
     $2=(sendMsg("Failed!"),window.String(e));
    }
    sendMsg($2);
   };
   runFS=function()
   {
    Var.Set(freeMsgs,"Compiling to JavaScript...");
    Var.Set(freeJS,"");
    RunCode.compile(function($1,$2)
    {
     Var.Set(freeJS,$2);
     return runJS();
    },sendMsg,freeFS.c);
   };
   this.RunHtml(HtmlNode.div([HtmlNode.style("height: 100%"),node,Button.New$1("Eval F#").Style("vertical-align:top").OnClick(function()
   {
    return function()
    {
     return runFS();
    };
   }).get_Render(),HtmlNode.someElt(Doc.InputArea([AttrProxy.Create("placeholder","F#:"),AttrProxy.Create("title","Add F# code and invoke with Eval F#")],freeFS)),HtmlNode.someElt(Doc.InputArea([AttrProxy.Create("placeholder","HTML:"),AttrProxy.Create("title","Enter HTML tags and text")],freeHtml)),HtmlNode.someElt(Doc.InputArea([AttrProxy.Create("placeholder","CSS:"),AttrProxy.Create("title","Test your CSS styles dynamically")],freeCSS)),HtmlNode.someElt(Doc.InputArea([AttrProxy.Create("placeholder","JavaScript:"),AttrProxy.Create("title","Add JS code and invoke with Eval JS")],freeJS)),Button.New$1("Eval JS").Style("vertical-align:top").OnClick(function()
   {
    return function()
    {
     Var.Set(freeMsgs,"");
     return runJS();
    };
   }).get_Render(),HtmlNode.someElt(Doc.InputArea([AttrProxy.Create("placeholder","Output:"),AttrProxy.Create("title","Messages")],freeMsgs)),new HtmlNode$1({
    $:4,
    $0:HtmlNode.tag(Doc.Verbatim,Val.map2((Runtime.Curried3(function($1,$2,$3)
    {
     return $1(PrintfHelpers.toSafe($2)+"<style>"+PrintfHelpers.toSafe($3)+"</style>");
    }))(window.id),freeHtml,freeCSS))
   })]));
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
 FSharpStation.grid=function()
 {
  SC$1.$cctor();
  return SC$1.grid;
 };
 FSharpStation.splitterMain2=function()
 {
  SC$1.$cctor();
  return SC$1.splitterMain2;
 };
 FSharpStation.splitterMain1=function()
 {
  SC$1.$cctor();
  return SC$1.splitterMain1;
 };
 FSharpStation.CodeEditor=function()
 {
  var x,view,contentVar,changingIRefO;
  return Grid.get_New().ColVariable$1(FSharpStation.spl1()).ColVariable(50).Max(Val.map(function(y)
  {
   return 92-y;
  },FSharpStation.spl1().get_GetValue())).Children([HtmlNode.style("grid-row: 3 / 5")]).ColAuto(0).RowFixedPx(34).RowAuto(0).RowVariable(17).Children([HtmlNode.style("grid-column: 2 / 4")]).get_Before().RowFixedPx(80).Padding(1).Content(HtmlNode.style(" \r\n                          grid-template-areas:\r\n                              'header0 header   header  '\r\n                              'sidebar content1 content1'\r\n                              'sidebar content2 content3'\r\n                              'footer  footer   footer2 ';\r\n                          color      : #333;\r\n                          height     : 100%;\r\n                          font-size  : small;\r\n                          font-family: monospace;\r\n                          line-height: 1.2;\r\n                      ")).Content$1("sidebar",HtmlNode.div([HtmlNode.style("overflow: auto"),new HtmlNode$1({
   $:4,
   $0:Doc.BindView(window.id,View.Map(FSharpStation.listEntries,(x=FSharpStation.codeSnippets().v,View.SnapshotOn((FSharpStation.codeSnippets())["var"].RVal(),FSharpStation.refresh().v,x))))
  })])).Content$1("header",Input.New$2((view=Val.toView(Val.fixit(FSharpStation.currentCodeSnippetId())),(contentVar=Var.Create$1(null),(changingIRefO=[null],(View.Sink(function(v)
  {
   var o,r;
   o=changingIRefO[0];
   o==null?void 0:(r=o.$0,!Unchecked.Equals(r.RVal(),v)?r.set_RVal(v):void 0);
  },contentVar.v),View.Sink(function(v)
  {
   Var.Set(contentVar,v);
  },View.Bind(function(cur)
  {
   var r;
   r=FSharpStation.curSnippetNameOf(cur);
   changingIRefO[0]={
    $:1,
    $0:r
   };
   Var.Set(contentVar,r.RVal());
   return r.RView();
  },view)),contentVar))))).Prefix(HtmlNode.htmlText("name:")).get_Render()).Content$1("content1",FSharpStation.codeMirror().get_Render()).Content$1("content2",TextArea.New$2(FSharpStation.codeMsgs()).Placeholder("Output:").Title("Messages").get_Render()).Content$1("content3",TextArea.New$2(FSharpStation.codeJS()).Placeholder("Javascript:").Title("JavaScript code generated").get_Render()).Content$1("footer2",TextArea.New$2(FSharpStation.codeFS()).Placeholder("F# code:").Title("F# code assembled").get_Render()).Content$1("footer",HtmlNode.div([Button.New$1("Add code").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.addCode();
  })).get_Render(),Button.New$1("<<").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.indentCodeOut();
  })).Disabled(FSharpStation.noSelectionVal()).get_Render(),Button.New$1(">>").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
  {
   FSharpStation.indentCodeIn();
  })).Disabled(FSharpStation.noSelectionVal()).get_Render(),FSharpStation.loadFileElement().get_Render().AddChildren([HtmlNode.style("grid-column: 4/6")]),HtmlNode.span([]),Button.New$1("Evaluate F# (FSI)").Class("btn btn-xs").OnClick((Runtime.Curried3(FSharpStation.Do))(function()
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
  })).Disabled(FSharpStation.noSelectionVal()).get_Render(),HtmlNode.someElt(Doc.Select([AttrProxy.Create("id","Position")],FSharpStation.positionTxt,List.ofArray([Position.Below,Position.Right,Position.NewBrowser]),FSharpStation.position())),HtmlNode.style("\r\n                        overflow: hidden;\r\n                        display: grid;\r\n                        grid-template-columns: repeat(8, 12.1%);\r\n                        bxackground-color: #eee;\r\n                        padding : 5px;\r\n                        grid-gap: 5px;\r\n                    ")])).Content(HtmlNode.script([HtmlNode.src("/EPFileX/FileSaver/FileSaver.js"),HtmlNode.type("text/javascript")])).Content(HtmlNode.script([HtmlNode.src("http://code.jquery.com/jquery-3.1.1.min.js"),HtmlNode.type("text/javascript")])).Content(HtmlNode.script([HtmlNode.src("http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"),HtmlNode.type("text/javascript")])).Content(HtmlNode.link([HtmlNode.href("http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")])).Content(HtmlNode.link([HtmlNode.href("/EPFileX/css/main.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")])).Content(HtmlNode.css(FSharpStation.styleEditor())).get_Render();
 };
 FSharpStation.spl1=function()
 {
  SC$1.$cctor();
  return SC$1.spl1;
 };
 FSharpStation.respondMessage=function(fromId,txt)
 {
  var m,o,o$1,o$2,o$3;
  return JSON.stringify((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$2())((m=(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$2())(JSON.parse(txt)),m.$==1?{
   $:1,
   $0:(o=CodeSnippet$1.FetchO(m.$0),o==null?null:{
    $:1,
    $0:FSharpStation["CodeSnippet.Code"](o.$0)
   })
  }:m.$==2?{
   $:0,
   $0:CodeSnippet$1.FetchO(m.$0)
  }:m.$==3?{
   $:1,
   $0:(o$1=CodeSnippet$1.FetchByPathO(m.$0),o$1==null?null:{
    $:1,
    $0:o$1.$0.content
   })
  }:m.$==4?{
   $:1,
   $0:(o$2=CodeSnippet$1.FetchByPathO(m.$0),o$2==null?null:{
    $:1,
    $0:FSharpStation["CodeSnippet.Code"](o$2.$0)
   })
  }:m.$==5?{
   $:0,
   $0:CodeSnippet$1.FetchByPathO(m.$0)
  }:m.$==6?{
   $:1,
   $0:{
    $:1,
    $0:"Message received: "+m.$0
   }
  }:m.$==7?{
   $:2,
   $0:fromId
  }:{
   $:1,
   $0:(o$3=CodeSnippet$1.FetchO(m.$0),o$3==null?null:{
    $:1,
    $0:o$3.$0.content
   })
  })));
 };
 FSharpStation.fsStationClient=function()
 {
  SC$1.$cctor();
  return SC$1.fsStationClient;
 };
 FSharpStation.prior=function()
 {
  SC$1.$cctor();
  return SC$1.prior;
 };
 FSharpStation.set_prior=function($1)
 {
  SC$1.$cctor();
  SC$1.prior=$1;
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
 FSharpStation.codeMirror=function()
 {
  SC$1.$cctor();
  return SC$1.codeMirror;
 };
 FSharpStation.REGEX=function(expr,opt,value)
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
 FSharpStation.styleEditor=function()
 {
  SC$1.$cctor();
  return SC$1.styleEditor;
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
  var body;
  if(!FSharpStation.dirty().c||window.confirm("Changes have not been saved, do you really want to load?"))
   {
    FSharpStation.loadTextFile((body=e.getRootNode().body,!body?e.getRootNode().firstChild:body).querySelector("#"+FSharpStation.fileInputElementId()),function(txt)
    {
     var a;
     try
     {
      a=((Provider.DecodeArray(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$3))())(JSON.parse(txt));
      FSharpStation.codeSnippets().Set(a);
      FSharpStation.setClean();
      FSharpStation.refreshView();
     }
     catch(e$1)
     {
      window.alert(window.String(e$1));
     }
    });
   }
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
 FSharpStation.listEntries=function(snps)
 {
  return Doc.Concat(Seq.choose(function(o)
  {
   var f;
   f=HtmlNode.renderDoc();
   return o==null?null:{
    $:1,
    $0:f(o.$0)
   };
  },(Seq.mapFold(function(expanded,t)
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
  },new FSharpSet.New(List.T.Empty),Seq.indexed(snps)))[0]));
 };
 FSharpStation.listEntry=function(isParent,isExpanded,code)
 {
  var x,p,p$1;
  return Hoverable.get_New().Content([HtmlNode["class"]("code-editor-list-tile"),HtmlNode.classIf("selected",Val.map((x=code.id,function(y)
  {
   return Unchecked.Equals(x,y);
  }),FSharpStation.currentCodeSnippetId())),HtmlNode.classIf("direct-predecessor",Val.map((p=code.id,function(c)
  {
   return FSharpStation.isDirectPredecessor(p,c);
  }),FSharpStation.currentCodeSnippetO())),HtmlNode.classIf("indirect-predecessor",Val.map((p$1=code.id,function(p$2)
  {
   return FSharpStation.isIndirectPredecessor(p$1,p$2);
  }),FSharpStation.curPredecessors())),HtmlNode.draggable("true"),new HtmlNode$1({
   $:5,
   $0:AttrModule.Handler("dragover",function()
   {
    return function(ev)
    {
     return ev.preventDefault();
    };
   })
  }),new HtmlNode$1({
   $:5,
   $0:AttrModule.Handler("drag",function()
   {
    return function()
    {
     return FSharpStation.set_draggedId(code.id);
    };
   })
  }),new HtmlNode$1({
   $:5,
   $0:AttrModule.Handler("drop",function()
   {
    return function(ev)
    {
     ev.preventDefault();
     return FSharpStation.reorderSnippet(code.id,FSharpStation.draggedId());
    };
   })
  }),HtmlNode.span([HtmlNode["class"]("node"),HtmlNode.classIf("parent",isParent),HtmlNode.classIf("expanded",isExpanded),new HtmlNode$1({
   $:5,
   $0:AttrModule.Handler("click",function()
   {
    return function()
    {
     return isParent?FSharpStation.toggleExpanded(code):null;
    };
   })
  }),HtmlNode.title(isParent?isExpanded?"collapse":"expand":""),HtmlNode.htmlText(isParent?isExpanded?"v":">":"")]),HtmlNode.div([HtmlNode["class"]("code-editor-list-text"),HtmlNode.style1("text-indent",(function($1)
  {
   return function($2)
   {
    return $1(window.String($2)+"em");
   };
  }(window.id))(FSharpStation["CodeSnippet.Level"](code))),HtmlNode.style("white-space: pre"),HtmlNode.htmlText(Val.map2(function(n)
  {
   return function(c)
   {
    return FsStationShared.snippetName(n,c);
   };
  },FSharpStation.curSnippetNameOf(code.id),FSharpStation.curSnippetCodeOf(code.id))),new HtmlNode$1({
   $:5,
   $0:AttrModule.Handler("click",function()
   {
    return function()
    {
     return Var.Set(FSharpStation.currentCodeSnippetId(),code.id);
    };
   })
  })]),HtmlNode.span([HtmlNode["class"]("predecessor"),HtmlNode.title("toggle predecessor"),new HtmlNode$1({
   $:5,
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
  }),HtmlNode.htmlText("X")])]).get_Render();
 };
 FSharpStation.toggleExpanded=function(snp)
 {
  FSharpStation.codeSnippets().UpdateBy(function(c)
  {
   return{
    $:1,
    $0:CodeSnippet.New(c.name,c.content,c.parent,c.predecessors,c.companions,c.id,!c.expanded)
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
    Unchecked.Equals(cur,pre)||FSharpStation.isIndirectPredecessor(cur.id,FSharpStation["CodeSnippet.UniquePredecesors"](pre))?void 0:(preds=(List.contains(pre.id,cur.predecessors)?(p=(x=pre.id,function(y)
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
      $0:CodeSnippet.New(c.name,c.content,c.parent,preds,c.companions,c.id,c.expanded)
     };
    },cur.id),FSharpStation.setDirty(),FSharpStation.refreshView());
   }
 };
 FSharpStation.isIndirectPredecessor=function(pre,predecessors)
 {
  return List.contains(pre,predecessors);
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
    $0:CodeSnippet.New(c.name,c.content,newP,c.predecessors,c.companions,c.id,c.expanded)
   };
  },snp.id),FSharpStation.setDirty(),FSharpStation.refreshView());
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
      },c.predecessors,c.companions,c.id,c.expanded)
     };
    },snp.id),true);
   },j-1));
   FSharpStation.setDirty();
   FSharpStation.refreshView();
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
    $0:CodeSnippet.New(c.name,c.content,tsn.parent,c.predecessors,c.companions,c.id,c.expanded)
   };
  },$1.$0[1].id)):void 0:void 0;
  FSharpStation.setDirty();
  FSharpStation.refreshView();
 };
 FSharpStation.evaluateFS=function()
 {
  var c,f,g;
  FSharpStation.processSnippet("Evaluating F# code...",(c=(f=function($1,$2)
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
  FSharpStation.processSnippet("Compiling to JavaScript...",(f=function(msgs,js)
  {
   Var.Set(FSharpStation.codeJS(),js);
   return fThen(msgs,js);
  },function(c)
  {
   RunCode.compile(f,fFail,c);
  }));
 };
 FSharpStation.processSnippet=function(msg,processCode)
 {
  var o,code;
  o=CodeSnippet$1.FetchO(FSharpStation.currentCodeSnippetId().c);
  o==null?void 0:(Var.Set(FSharpStation.codeMsgs(),msg),Var.Set(FSharpStation.codeJS(),""),code=FSharpStation["CodeSnippet.Code"](o.$0),Var.Set(FSharpStation.codeFS(),code),processCode(code));
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
  o==null?void 0:Var.Set(FSharpStation.codeFS(),FSharpStation["CodeSnippet.Code"](o.$0));
 };
 FSharpStation.setClean=function()
 {
  Var.Set(FSharpStation.dirty(),false);
 };
 FSharpStation.setDirty=function()
 {
  Var.Set(FSharpStation.dirty(),true);
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
 FSharpStation.dirty=function()
 {
  SC$1.$cctor();
  return SC$1.dirty;
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
   return CodeSnippet.New(s.name,n,s.parent,s.predecessors,s.companions,s.id,s.expanded);
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
   return CodeSnippet.New(n,s.content,s.parent,s.predecessors,s.companions,s.id,s.expanded);
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
 FSharpStation["CodeSnippet.Code"]=function(_this,u)
 {
  var preds;
  preds=Arrays.ofSeq(FSharpStation["CodeSnippet.UniquePredecesors"](_this));
  return Strings.concat("\n",Seq.map(FSharpStation["CodeSnippet.ContentIndented"],Seq.filter(function(snp)
  {
   return Arrays.contains(snp.id,preds);
  },(FSharpStation.codeSnippets())["var"].RVal())));
 };
 FSharpStation["CodeSnippet.ContentIndented"]=function(_this,u)
 {
  var lvl,x;
  lvl=FSharpStation["CodeSnippet.Level"](_this);
  x=Strings.Replace(Strings.Replace(lvl===0||lvl===1?_this.content:Strings.concat("\n",Arrays.map(function(l)
  {
   return Strings.StartsWith(l,"#")?l:Strings.replicate(lvl,"  ")+l;
  },Strings.SplitChars(_this.content,[10],0))),"##"+"FSHARPSTATION_ID"+"##",FSharpStation.fsIds()),"##"+"FSHARPSTATION_ENDPOINT"+"##",window.location.href);
  return((((Runtime.Curried(function($1,$2,$3,$4)
  {
   return $1("# 1 @\""+PrintfHelpers.toSafe($2)+" "+PrintfHelpers.toSafe($3)+"\"\n"+PrintfHelpers.toSafe($4));
  },4))(window.id))(lvl===0||lvl===1?"":(function($1)
  {
   return function($2)
   {
    return $1("("+window.String($2)+")");
   };
  }(window.id))(lvl*2)))(FSharpStation["CodeSnippet.get_NameSanitized"](_this)))(x);
 };
 FSharpStation["CodeSnippet.get_NameSanitized"]=function(_this,u)
 {
  return"F# "+FsStationShared.sanitize(_this.get_Name())+".fsx";
 };
 FSharpStation["CodeSnippet.Level"]=function(_this,u)
 {
  function level(snp,out)
  {
   var o,o$1,o$2;
   o=(o$1=(o$2=snp.parent,o$2==null?null:CodeSnippet$1.FetchO(o$2.$0)),o$1==null?null:{
    $:1,
    $0:level(o$1.$0,out+1)
   });
   return o==null?out:o.$0;
  }
  return level(_this,0);
 };
 FSharpStation["CodeSnippet.UniquePredecesors"]=function(_this,u)
 {
  function preds(ins,outs)
  {
   var hd;
   return ins.$==1?(hd=ins.$0,preds(List.collect(window.id,List.ofArray([ins.$1,List.collect(function(s)
   {
    return List.append(Option$1.toList(s.parent),s.predecessors);
   },CodeSnippet$1.FetchL(hd))])),Seq.contains(hd,outs)?outs:new List.T({
    $:1,
    $0:hd,
    $1:outs
   }))):outs;
  }
  return preds(List.ofArray([_this.id]),List.T.Empty);
 };
 CodeSnippet$1.New=function(od,nm,pa,pred,co,cnt)
 {
  var newS,$1,a,a$1,t;
  newS=CodeSnippet.New(nm,cnt,pa,pred,co,CodeSnippetId.get_New(),true);
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
  var g,v,g$1,m,s,v$1,v$2,s$1,v$3,v$4,f,g$2,v$5,view,contentVar,changingIRefO,f$1,s$2,v$6,v$7,s$3,v$8,v$9,s$4,v$10,v$11,x;
  SC$1.callAddClass=HtmlNode.addClass("a","b");
  SC$1.getClass=function(e)
  {
   return HtmlNode.getAttr("class",e);
  };
  SC$1.getStyle=function(e)
  {
   return HtmlNode.getAttr("style",e);
  };
  SC$1.renderDoc=(g=(v=Doc.Empty(),function(o)
  {
   return o==null?v:o.$0;
  }),function(x$1)
  {
   return g(HtmlNode.chooseNode(x$1));
  });
  SC$1.string2Styles=(g$1=(m=function(n,v$12)
  {
   return new HtmlNode$1({
    $:5,
    $0:AttrModule.Style(n,v$12)
   });
  },function(a)
  {
   return Arrays.map(function($1)
   {
    return m($1[0],$1[1]);
   },a);
  }),function(x$1)
  {
   return g$1(HtmlNode.style2pairs(x$1));
  });
  SC$1.codeMirrorIncludes=["/EPFileX/codemirror/scripts/codemirror/codemirror.js","/EPFileX/codemirror/scripts/intellisense.js","/EPFileX/codemirror/scripts/codemirror/codemirror-intellisense.js","/EPFileX/codemirror/scripts/codemirror/codemirror-compiler.js","/EPFileX/codemirror/scripts/codemirror/mode/fsharp.js","/EPFileX/codemirror/scripts/addon/search/searchcursor.js","/EPFileX/codemirror/scripts/addon/search/search.js","/EPFileX/codemirror/scripts/addon/search/jump-to-line.js","/EPFileX/codemirror/scripts/addon/dialog/dialog.js","/EPFileX/codemirror/scripts/addon/edit/matchbrackets.js","/EPFileX/codemirror/scripts/addon/selection/active-line.js","/EPFileX/codemirror/scripts/addon/display/fullscreen.js"];
  SC$1.codeSnippets=ListModel.Create(function(s$5)
  {
   return s$5.id;
  },List.T.Empty);
  SC$1.fsIds="FSharpStation-"+window.String(Guid.NewGuid());
  SC$1.missingVar=Var.Create$1("");
  SC$1.currentCodeSnippetId=Var.Create$1(CodeSnippetId.get_New());
  s="CodeEditor."+"currentCodeSnippetId";
  v$1=FSharpStation.currentCodeSnippetId();
  v$2=window.localStorage.getItem(s);
  v$2!==null?v$1.set_RVal((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j())(JSON.parse(v$2))):void 0;
  Val.sink(function(v$12)
  {
   window.localStorage.setItem(s,JSON.stringify((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j())(v$12)));
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
  Val.sink(function(v$12)
  {
   window.localStorage.setItem(s$1,JSON.stringify((_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$1())(v$12)));
  },v$3);
  SC$1.directionVertical=Val.map(function(pos)
  {
   return pos.$==1&&true;
  },FSharpStation.position());
  SC$1.noSelectionVal=Val.map(FSharpStation.noSelection,FSharpStation.currentCodeSnippetId());
  SC$1.dirty=Var.Create$1(false);
  SC$1.codeFS=Var.Create$1("");
  SC$1.codeJS=Var.Create$1("");
  SC$1.codeMsgs=Var.Create$1("");
  Val.sink(function(m$1)
  {
   window.onbeforeunload=m$1?function(e)
   {
    e.returnValue="Changes you made may not be saved.";
   }:null;
  },FSharpStation.dirty());
  SC$1.draggedId=CodeSnippetId.get_New();
  SC$1.curPredecessors=Val.map((f=function(o)
  {
   return o==null?null:{
    $:1,
    $0:FSharpStation["CodeSnippet.UniquePredecesors"](o.$0)
   };
  },(g$2=(v$5=List.T.Empty,function(o)
  {
   return o==null?v$5:o.$0;
  }),function(x$1)
  {
   return g$2(f(x$1));
  })),FSharpStation.currentCodeSnippetO());
  SC$1.fileName=Var.Create$1("");
  SC$1.emptyFile=Val.map(function(v$12)
  {
   return v$12==="";
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
  SC$1.styleEditor="\r\n      div textarea {\r\n      font-family: monospace;\r\n      }\r\n      .code-editor-list-tile {\r\n      white-space: nowrap; \r\n      border-style: solid none none;\r\n      border-color: white;\r\n      border-width: 1px;\r\n      background-color: #D8D8D8;\r\n      display: flex;\r\n      }\r\n      .code-editor-list-text{\r\n      padding: 1px 10px 1px 5px;\r\n      overflow:hidden;\r\n      text-overflow: ellipsis;\r\n      white-space: nowrap;\r\n      flex: 1;\r\n      }\r\n      \r\n      .code-editor-list-tile.direct-predecessor {\r\n      font-weight: bold;\r\n      }\r\n      .code-editor-list-tile.indirect-predecessor {\r\n      color: blue;\r\n      }\r\n      .code-editor-list-tile.selected {\r\n      background-color: #77F;\r\n      color: white;\r\n      }\r\n      .code-editor-list-tile.hovering {\r\n      background: lightgray;\r\n      }\r\n      .code-editor-list-tile.hovering.selected {\r\n      background:  blue;\r\n      }\r\n      .code-editor-list-tile>.predecessor {\r\n      font-weight: bold;\r\n      border-style: inset;\r\n      border-width: 1px;\r\n      text-align: center;\r\n      color: transparent;\r\n      }\r\n      .code-editor-list-tile.direct-predecessor>.predecessor {\r\n      color: blue;\r\n      }\r\n      \r\n      .CodeMirror { height: 100%; }\r\n      \r\n      .node {\r\n          background-color:white; \r\n          width: 2ch; \r\n          color: #A03; \r\n          font-weight:bold; \r\n          text-align: center;\r\n          font-family: arial;\r\n      }\r\n      .Warning { background-color: blue    } \r\n      .Error   { background-color: darkred } \r\n          ";
  SC$1.codeMirror=CodeMirror.New$2((view=Val.toView(Val.fixit(FSharpStation.currentCodeSnippetId())),(contentVar=Var.Create$1(null),(changingIRefO=[null],(View.Sink(function(v$12)
  {
   var o,r;
   o=changingIRefO[0];
   o==null?void 0:(r=o.$0,!Unchecked.Equals(r.RVal(),v$12)?r.set_RVal(v$12):void 0);
  },contentVar.v),View.Sink(function(v$12)
  {
   Var.Set(contentVar,v$12);
  },View.Bind(function(cur)
  {
   var r;
   r=FSharpStation.curSnippetCodeOf(cur);
   changingIRefO[0]={
    $:1,
    $0:r
   };
   Var.Set(contentVar,r.RVal());
   return r.RView();
  },view)),contentVar))))).OnChange(function()
  {
   FSharpStation.setDirty();
  }).Style("height: 100%");
  SC$1.rex1="\\((\\d+)\\) F# (.+).fsx\\((\\d+)\\,(\\d+)\\): (error|warning) ((.|\\b)+)";
  SC$1.rex2="(Err|Warning)(FSharp|WebSharper)\\s+\"(\\((\\d+)\\) )?F# (.+?)(.fsx)? \\((\\d+)\\,\\s*(\\d+)\\) - \\((\\d+)\\,\\s*(\\d+)\\) ((.|\\s)+?)"+"\"";
  SC$1.rex=FSharpStation.rex1()+"|"+FSharpStation.rex2();
  SC$1.prior=["",""];
  f$1=function(msgs,curO)
  {
   var b;
   Concurrency.Start((b=null,Concurrency.Delay(function()
   {
    var m$1,editor;
    m$1=FSharpStation.codeMirror().editorO;
    return m$1!=null&&m$1.$==1?(editor=m$1.$0,curO!=null&&curO.$==1?(Val.iter(function(name)
    {
     var a,a$1;
     ((function($1)
     {
      return function($2)
      {
       return $1("RemoveMarks: "+PrintfHelpers.toSafe($2));
      };
     }(function(s$5)
     {
      console.log(s$5);
     }))(name));
     if(Unchecked.Equals(FSharpStation.prior(),[msgs,name]))
      void 0;
     else
      {
       FSharpStation.set_prior([msgs,name]);
       while(editor.getAllMarks().length>0)
        (editor.getAllMarks())[0].clear();
       a=function(file,fl,fc,tl,tc,sev,from,msg)
       {
        (((Runtime.Curried3(function($1,$2,$3)
        {
         return $1("inside -"+PrintfHelpers.toSafe($2)+"-"+PrintfHelpers.toSafe($3)+"-");
        }))(function(s$5)
        {
         console.log(s$5);
        }))(file))(FsStationShared.sanitize(name));
        file===FsStationShared.sanitize(name)?window.setTimeout(function()
        {
         ((((function(t)
         {
          var a$2,a$3;
          a$2=t[0];
          a$3=t[1];
          return function(t$1)
          {
           var a$4,a$5;
           a$4=t$1[0];
           a$5=t$1[1];
           return function(a$6)
           {
            return function(a$7)
            {
             return editor.getDoc().markText({
              line:a$2,
              ch:a$3
             },{
              line:a$4,
              ch:a$5
             },{
              className:a$6,
              title:a$7
             });
            };
           };
          };
         }([fl-1,fc]))([tl-1,tc]))(Strings.StartsWith(sev.toUpperCase(),"ERR")?"Error":"Warning"))(msg));
        },100):void 0;
       };
       Arrays.iter(function($1)
       {
        return a($1[0],$1[1],$1[2],$1[3],$1[4],$1[5],$1[6],$1[7]);
       },Arrays.choose(function(v$12)
       {
        var $1,a$2,t,indent,$2,a$3,t$1,fc,fl,indent$1;
        return(a$2=FSharpStation.REGEX(FSharpStation.rex2(),"",v$12),a$2!=null&&a$2.$==1&&((t=a$2.$0,t&&Arrays.length(t)===13)&&($1=[Arrays.get(a$2.$0,8),Arrays.get(a$2.$0,5),Arrays.get(a$2.$0,7),Arrays.get(a$2.$0,2),Arrays.get(a$2.$0,4),Arrays.get(a$2.$0,11),Arrays.get(a$2.$0,1),Arrays.get(a$2.$0,10),Arrays.get(a$2.$0,9)],true)))?(indent=$1[4],{
         $:1,
         $0:[$1[1],$1[2]<<0,($1[0]<<0)-(indent<<0),$1[8]<<0,($1[7]<<0)-(indent<<0),$1[6],$1[3],$1[5]]
        }):(a$3=FSharpStation.REGEX(FSharpStation.rex1(),"",v$12),a$3!=null&&a$3.$==1&&((t$1=a$3.$0,t$1&&Arrays.length(t$1)===8)&&($2=[Arrays.get(a$3.$0,4),Arrays.get(a$3.$0,2),Arrays.get(a$3.$0,3),Arrays.get(a$3.$0,1),Arrays.get(a$3.$0,6),Arrays.get(a$3.$0,5)],true)))?(fc=$2[0],(fl=$2[2],(indent$1=$2[3],{
         $:1,
         $0:[$2[1],fl<<0,(fc<<0)-(indent$1<<0)-1,fl<<0,(fc<<0)-(indent$1<<0),$2[5],"fsi",$2[4]]
        }))):null;
       },(a$1=FSharpStation.REGEX(FSharpStation.rex(),"g",msgs),a$1!=null&&a$1.$==1?a$1.$0:[])));
      }
    },FSharpStation.curSnippetNameOf(curO.$0.id)),Concurrency.Zero()):Concurrency.Zero()):Concurrency.Zero();
   })),null);
  };
  Val.sink(function($1)
  {
   return f$1($1[0],$1[1]);
  },Val.map2(function(msgs)
  {
   return function(curO)
   {
    return[msgs,curO];
   };
  },FSharpStation.codeMsgs(),FSharpStation.currentCodeSnippetO()));
  SC$1.fsStationClient=new FsStationClient.New(FSharpStation.fsIds(),{
   $:1,
   $0:FSharpStation.fsIds()
  },null);
  window.setTimeout(function()
  {
   FSharpStation.fsStationClient().get_MessagingClient().AwaitMessage(FSharpStation.respondMessage);
  },1000);
  SC$1.spl1=SplitterBar.New$1(20).Children([HtmlNode.style("grid-row: 2 / 4")]);
  s$2="CodeEditor."+"splitterV1";
  v$6=FSharpStation.spl1().get_Var();
  v$7=window.localStorage.getItem(s$2);
  v$7!==null?v$6.set_RVal(((Provider.Id())())(JSON.parse(v$7))):void 0;
  Val.sink(function(v$12)
  {
   window.localStorage.setItem(s$2,JSON.stringify(((Provider.Id())())(v$12)));
  },v$6);
  SC$1.splitterMain1=SplitterBar.New$1(0).Vertical$1(FSharpStation.directionVertical()).Min(0).Max(35);
  SC$1.splitterMain2=SplitterBar.New$1(24).Vertical$1(FSharpStation.directionVertical()).Min(0.5).Max(Val.map(function(pos)
  {
   return pos.$===3?0.1:50;
  },FSharpStation.position())).get_Before();
  s$3="CodeEditor."+"splitterMain1";
  v$8=FSharpStation.splitterMain1().get_Var();
  v$9=window.localStorage.getItem(s$3);
  v$9!==null?v$8.set_RVal(((Provider.Id())())(JSON.parse(v$9))):void 0;
  Val.sink(function(v$12)
  {
   window.localStorage.setItem(s$3,JSON.stringify(((Provider.Id())())(v$12)));
  },v$8);
  s$4="CodeEditor."+"splitterMain2";
  v$10=FSharpStation.splitterMain2().get_Var();
  v$11=window.localStorage.getItem(s$4);
  v$11!==null?v$10.set_RVal(((Provider.Id())())(JSON.parse(v$11))):void 0;
  Val.sink(function(v$12)
  {
   window.localStorage.setItem(s$4,JSON.stringify(((Provider.Id())())(v$12)));
  },v$10);
  SC$1.grid=Grid.get_New().Padding(0).Content$1("editor",FSharpStation.CodeEditor()).Content(HtmlNode.style("height: 100vh; margin: 0px; ")).Content(HtmlNode.css("\r\n                 #CodeEditor              { grid-area: editor  ; overflow: hidden; }\r\n                 #TestNode                { grid-area: testNode; overflow: auto  ; }\r\n                 body > div:first-of-type { grid-area: header  ; overflow: hidden; }\r\n             "));
  (x=HtmlNode.bindHElem(HtmlNode.body,Val.map(function(dir)
  {
   return(dir?FSharpStation.grid().ColVariable$1(FSharpStation.splitterMain1()).ColAuto(16).ColVariable$1(FSharpStation.splitterMain2()).Content(HtmlNode.style(" grid-template-areas: 'header   editor   testNode'; ")):FSharpStation.grid().RowVariable$1(FSharpStation.splitterMain1()).RowAuto(16).RowVariable$1(FSharpStation.splitterMain2()).Content(HtmlNode.style(" grid-template-areas: 'header' 'editor' 'testNode'; "))).GridTemplate();
  },FSharpStation.directionVertical())),(HtmlNode.renderDoc())(x)).ReplaceInDom(window.document.body);
  SC$1.$cctor=window.ignore;
 });
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_GeneratedPrintf.p=function($1)
 {
  return"SnippetNotFound "+PrintfHelpers.prettyPrint($1.$0);
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v=(Provider.DecodeUnion(void 0,"$",[[0,[["$0","Item",Provider.Id(),0]]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$2=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$2?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$2:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$2=(Provider.EncodeUnion(void 0,"$",[[0,[["$0","Item",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$3,1]]],[1,[["$0","Item",Provider.Id(),1]]],[2,[["$0","Item",Provider.Id(),0]]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$3=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$3?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$3:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$3=(Provider.EncodeRecord(CodeSnippet,[["name",Provider.Id(),0],["content",Provider.Id(),0],["parent",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j,1],["predecessors",Provider.EncodeList(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j),0],["companions",Provider.EncodeList(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j),0],["id",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j,0],["expanded",Provider.Id(),0]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$2=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$2?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$2:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$2=(Provider.DecodeUnion(void 0,"$",[[0,[["$0","Item",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j,0]]],[1,[["$0","Item",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j,0]]],[2,[["$0","Item",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j,0]]],[3,[["$0","Item",Provider.DecodeArray(Provider.Id()),0]]],[4,[["$0","Item",Provider.DecodeArray(Provider.Id()),0]]],[5,[["$0","Item",Provider.DecodeArray(Provider.Id()),0]]],[6,[["$0","Item",Provider.Id(),0]]],[7,[]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$3=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$3?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$3:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$3=(Provider.DecodeRecord(CodeSnippet,[["name",Provider.Id(),0],["content",Provider.Id(),0],["parent",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j,1],["predecessors",Provider.DecodeList(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j),0],["companions",Provider.DecodeList(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j),0],["id",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j,0],["expanded",Provider.Id(),0]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$4=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$4?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$4:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$4=(Provider.DecodeUnion(void 0,"$",[[0,[["$0","Item",Provider.Id(),0]]],[1,[["$0","Item",Provider.DecodeArray(Provider.Id()),0]]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$4=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$4?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$4:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$4=(Provider.EncodeUnion(void 0,"$",[[0,[["$0","Item",Provider.Id(),0]]],[1,[]],[2,[]],[3,[]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$5=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$5?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$5:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$5=(Provider.DecodeUnion(void 0,"$",[[0,[["$0","Item",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$3,1]]],[1,[["$0","Item",Provider.Id(),1]]],[2,[["$0","Item",Provider.Id(),0]]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$5=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$5?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$5:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$5=(Provider.EncodeUnion(void 0,"$",[[0,[["$0","Item",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j,0]]],[1,[["$0","Item",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j,0]]],[2,[["$0","Item",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j,0]]],[3,[["$0","Item",Provider.EncodeArray(Provider.Id()),0]]],[4,[["$0","Item",Provider.EncodeArray(Provider.Id()),0]]],[5,[["$0","Item",Provider.EncodeArray(Provider.Id()),0]]],[6,[["$0","Item",Provider.Id(),0]]],[7,[]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v=(Provider.EncodeUnion(void 0,"$",[[0,[["$0","Item",Provider.Id(),0]]]]))();
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