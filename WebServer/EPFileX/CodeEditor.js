
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
                     CIPHERSpaceLoadFiles(["/Scripts/WebSharper/WebSharper.Core.JavaScript/Runtime.js", "/Scripts/WebSharper/WebSharper.Main.js", "/Scripts/WebSharper/WebSharper.Collections.js", "/Scripts/WebSharper/WebSharper.Control.js", "/Scripts/WebSharper/WebSharper.Web.js", "/Scripts/WebSharper/WebSharper.UI.Next.js", "/Scripts/WebSharper/Common.js", "/Scripts/WebSharper/ZafirTranspiler.js"], function()
{
 "use strict";
 var Global,TestWebSharper,HtmlNode,Val,HelperType,HtmlNode$1,Template,Button,Input,Hoverable,TextArea,CodeMirror,SplitterBar,RunCode,EditorRpc,RunNode,CodeEditor,CodeSnippetId,CodeSnippet,Position,SC$1,_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder,_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder,WebSharper,UI,Next,View,Doc,AttrModule,AttrProxy,IntelliFactory,Runtime,Seq,Var,Input$1,Mouse,Strings,Arrays,List,Collections,FSharpSet,BalancedTree,Operators,Remoting,AjaxRemotingProvider,Concurrency,PrintfHelpers,Unchecked,Guid,Option,Json,Provider,Slice,Storage,ListModel;
 Global=window;
 TestWebSharper=Global.TestWebSharper=Global.TestWebSharper||{};
 HtmlNode=TestWebSharper.HtmlNode=TestWebSharper.HtmlNode||{};
 Val=HtmlNode.Val=HtmlNode.Val||{};
 HelperType=Val.HelperType=Val.HelperType||{};
 HtmlNode$1=HtmlNode.HtmlNode=HtmlNode.HtmlNode||{};
 Template=TestWebSharper.Template=TestWebSharper.Template||{};
 Button=Template.Button=Template.Button||{};
 Input=Template.Input=Template.Input||{};
 Hoverable=Template.Hoverable=Template.Hoverable||{};
 TextArea=Template.TextArea=Template.TextArea||{};
 CodeMirror=Template.CodeMirror=Template.CodeMirror||{};
 SplitterBar=Template.SplitterBar=Template.SplitterBar||{};
 RunCode=TestWebSharper.RunCode=TestWebSharper.RunCode||{};
 EditorRpc=RunCode.EditorRpc=RunCode.EditorRpc||{};
 RunNode=RunCode.RunNode=RunCode.RunNode||{};
 CodeEditor=TestWebSharper.CodeEditor=TestWebSharper.CodeEditor||{};
 CodeSnippetId=CodeEditor.CodeSnippetId=CodeEditor.CodeSnippetId||{};
 CodeSnippet=CodeEditor.CodeSnippet=CodeEditor.CodeSnippet||{};
 Position=CodeEditor.Position=CodeEditor.Position||{};
 SC$1=Global["StartupCode$D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project_xxx$ F# namespace TestWebSharper"]=Global["StartupCode$D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project_xxx$ F# namespace TestWebSharper"]||{};
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder=Global["D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project$xxx_JsonEncoder"]=Global["D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project$xxx_JsonEncoder"]||{};
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder=Global["D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project$xxx_JsonDecoder"]=Global["D:\\Abe\\CIPHERWorkspace\\CIPHERPrototype\\WebServer\\bin\\project$xxx_JsonDecoder"]||{};
 WebSharper=Global.WebSharper;
 UI=WebSharper&&WebSharper.UI;
 Next=UI&&UI.Next;
 View=Next&&Next.View;
 Doc=Next&&Next.Doc;
 AttrModule=Next&&Next.AttrModule;
 AttrProxy=Next&&Next.AttrProxy;
 IntelliFactory=Global.IntelliFactory;
 Runtime=IntelliFactory&&IntelliFactory.Runtime;
 Seq=WebSharper&&WebSharper.Seq;
 Var=Next&&Next.Var;
 Input$1=Next&&Next.Input;
 Mouse=Input$1&&Input$1.Mouse;
 Strings=WebSharper&&WebSharper.Strings;
 Arrays=WebSharper&&WebSharper.Arrays;
 List=WebSharper&&WebSharper.List;
 Collections=WebSharper&&WebSharper.Collections;
 FSharpSet=Collections&&Collections.FSharpSet;
 BalancedTree=Collections&&Collections.BalancedTree;
 Operators=WebSharper&&WebSharper.Operators;
 Remoting=WebSharper&&WebSharper.Remoting;
 AjaxRemotingProvider=Remoting&&Remoting.AjaxRemotingProvider;
 Concurrency=WebSharper&&WebSharper.Concurrency;
 PrintfHelpers=WebSharper&&WebSharper.PrintfHelpers;
 Unchecked=WebSharper&&WebSharper.Unchecked;
 Guid=WebSharper&&WebSharper.Guid;
 Option=WebSharper&&WebSharper.Option;
 Json=WebSharper&&WebSharper.Json;
 Provider=Json&&Json.Provider;
 Slice=WebSharper&&WebSharper.Slice;
 Storage=Next&&Next.Storage;
 ListModel=Next&&Next.ListModel;
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
  return Global.TestWebSharper.HtmlNode.Val.fixit2(v);
 };
 Val.sink=function(f,v)
 {
  var a;
  a=Val.toView(Val.fixit(v));
  View.Sink(f,a);
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
  }:typeof v=="object"?typeof v.$!="undefined"?v:((typeof v.Id=="number"?true:typeof v.i=="number")?true:typeof(v.RView=="function"))?{
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
  var wa,va$1,a;
  return va.$==2?(wa=va.$0,AttrModule.Dynamic(att,wa)):va.$==1?(va$1=va.$0,AttrModule.Dynamic(att,va$1.RView())):(a=va.$0,AttrProxy.Create(att,a));
 };
 Val.tagElt=function(tag,va)
 {
  var wa,va$1,a;
  return va.$==2?(wa=va.$0,Doc.EmbedView(View.Map(tag,wa))):va.$==1?(va$1=va.$0,Doc.EmbedView((a=va$1.RView(),View.Map(tag,a)))):tag(va.$0);
 };
 Val.tagDoc=function(tag,va)
 {
  var wa,va$1,a;
  return va.$==2?(wa=va.$0,Doc.EmbedView(View.Map(tag,wa))):va.$==1?(va$1=va.$0,Doc.EmbedView((a=va$1.RView(),View.Map(tag,a)))):tag(va.$0);
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
   var f$1,$2,g;
   f$1=($2=(g=function(f$2,v)
   {
    return Val.mapV(f$2,v);
   },function(x)
   {
    var $3;
    $3=f(x);
    return function($4)
    {
     return g($3,$4);
    };
   }),function($3)
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
  var wa,a,va,a$1;
  return v.$==2?(wa=v.$0,{
   $:2,
   $0:(a=function(x)
   {
    return Val.toView(f(x));
   },function(a$2)
   {
    return View.Bind(a,a$2);
   }(wa))
  }):v.$==1?(va=v.$0,{
   $:2,
   $0:(a$1=function(x)
   {
    return Val.toView(f(x));
   },function(a$2)
   {
    return View.Bind(a$1,a$2);
   }(va.RView()))
  }):f(v.$0);
 };
 Val.toView=function(v)
 {
  return v.$==2?v.$0:v.$==1?v.$0.RView():View.Const(v.$0);
 };
 Val.iterV=function(f,va)
 {
  var wa;
  if(va.$==2)
   {
    wa=va.$0;
    View.Get(f,wa);
   }
  else
   if(va.$==1)
    f(va.$0.RVal());
   else
    f(va.$0);
 };
 Val.mapV=function(f,va)
 {
  var wa,va$1,a;
  return va.$==2?(wa=va.$0,{
   $:2,
   $0:View.Map(f,wa)
  }):va.$==1?(va$1=va.$0,{
   $:2,
   $0:(a=va$1.RView(),View.Map(f,a))
  }):{
   $:0,
   $0:f(va.$0)
  };
 };
 HtmlNode$1=HtmlNode.HtmlNode=Runtime.Class({
  AddChildren:function(add)
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
  Class:function(clas)
  {
   var n;
   n=Val.fixit(clas);
   return HtmlNode.replaceAtt("class",this,n);
  },
  get_toDoc:function()
  {
   var $1,x,v;
   return(this.$==1?true:this.$==3?true:false)?Doc.Empty():(x=HtmlNode.chooseNode(this),(v=Doc.Empty(),x==null?v:x.$0));
  }
 },null,HtmlNode$1);
 HtmlNode$1.HtmlEmpty=new HtmlNode$1({
  $:3
 });
 HtmlNode.createIFrame=function(f)
 {
  var cover,a,a$1,a$2;
  cover=Var.Create$1(true);
  return HtmlNode.div([HtmlNode.style("position: relative; overflow: hidden; height: 100%; width: 100%;"),HtmlNode.iframe([HtmlNode.style("position: absolute; width:100%; height:100%;"),HtmlNode.frameborder("0"),(a=AttrModule.OnAfterRender(f),new HtmlNode$1({
   $:5,
   $0:a
  })),(a$1=AttrModule.Handler("mouseleave",function()
  {
   return function()
   {
    return Var.Set(cover,true);
   };
  }),new HtmlNode$1({
   $:5,
   $0:a$1
  }))]),HtmlNode.div([HtmlNode.style("position: absolute;"),HtmlNode.classIf("iframe-cover",Val.map(Global.id,cover)),(a$2=AttrModule.Handler("mouseenter",function()
  {
   return function()
   {
    var a$3;
    a$3=function(pressed)
    {
     if(!pressed)
      Var.Set(cover,false);
    };
    return function(a$4)
    {
     View.Get(a$3,a$4);
    }(Mouse.get_MousePressed());
   };
  }),new HtmlNode$1({
   $:5,
   $0:a$2
  }))]),HtmlNode.styleH([HtmlNode.htmlText(".iframe-cover { top:0; left:0; right:0; bottom:0; background: blue; opacity: 0.04; z-index: 2; }")])]);
 };
 HtmlNode.bindHElem=function(hElem,v)
 {
  var a,f,g,view;
  a=(f=(g=HtmlNode.renderDoc(),function(x)
  {
   return g(hElem(x));
  }),(view=Val.toView(Val.fixit(v)),Doc.BindView(f,view)));
  return new HtmlNode$1({
   $:4,
   $0:a
  });
 };
 HtmlNode.composeDoc=function(elt,dtl,dtlVal)
 {
  var a,x,a$1,f,f$1,g;
  a=(x=Val.toView(dtlVal),(a$1=(f=(f$1=function(s)
  {
   return Seq.append(dtl,s);
  },function(x$1)
  {
   return elt(f$1(x$1));
  }),(g=HtmlNode.renderDoc(),function(x$1)
  {
   return g(f(x$1));
  })),Doc.BindView(a$1,x)));
  return new HtmlNode$1({
   $:4,
   $0:a
  });
 };
 HtmlNode.style1=function(n,v)
 {
  var a,v$1;
  a=(v$1=Val.toView(Val.fixit(v)),AttrModule.DynamicStyle(n,v$1));
  return new HtmlNode$1({
   $:5,
   $0:a
  });
 };
 HtmlNode.style=function(v)
 {
  return HtmlNode.htmlAttribute("style",v);
 };
 HtmlNode.string2Styles=function()
 {
  SC$1.$cctor();
  return SC$1.string2Styles;
 };
 HtmlNode.style2pairs=function(ss)
 {
  var m,p,m$1;
  m=function(d)
  {
   return[Strings.Trim(Arrays.get(d,0)),Strings.Trim(Arrays.get(d,1))];
  };
  return function(a)
  {
   return Arrays.map(m,a);
  }((p=function(d)
  {
   return Arrays.length(d)===2;
  },function(a)
  {
   return Arrays.filter(p,a);
  }((m$1=function(s)
  {
   return Strings.SplitChars(s,[58],0);
  },function(a)
  {
   return Arrays.map(m$1,a);
  }(Strings.SplitChars(ss,[59],0))))));
 };
 HtmlNode.xclass=function(v)
 {
  var a,m,cw,cv;
  a=(m=Val.fixit(v),m.$==2?(cw=m.$0,AttrModule.DynamicClass("class_for_view_not_implemented",cw,function(y)
  {
   return""!==y;
  })):m.$==1?(cv=m.$0,AttrModule.DynamicClass(cv.RVal(),cv.RView(),function(y)
  {
   return""!==y;
  })):AttrModule.Class(m.$0));
  return new HtmlNode$1({
   $:5,
   $0:a
  });
 };
 HtmlNode.classIf=function(cls,v)
 {
  return HtmlNode["class"](Val.map(function(b)
  {
   return b?cls:"";
  },Val.fixit(v)));
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
  var p;
  return new List.T({
   $:1,
   $0:new HtmlNode$1({
    $:1,
    $0:att,
    $1:newVal
   }),
   $1:List.ofSeq((p=function(a)
   {
    return a.$==1?a.$0===att?false:true:true;
   },function(s)
   {
    return Seq.filter(p,s);
   }(children)))
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
  var x;
  x=element.$==0?element.$1:[];
  return(HtmlNode.getAttrChildren(attr))(x);
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
   return(a.$==1?a.$0===attr?($1=[a.$0,a.$1],true):false:false)?{
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
  var name,children,a,a$1,vtext;
  return node.$==0?(name=node.$0,(children=node.$1,{
   $:1,
   $0:(a=HtmlNode.getAttrsFromSeq(children),(a$1=Seq.choose(HtmlNode.chooseNode,children),Doc.Element(name,a,a$1)))
  })):node.$==2?(vtext=node.$0,{
   $:1,
   $0:Val.tagDoc(Doc.TextNode,vtext)
  }):node.$==4?{
   $:1,
   $0:node.$0
  }:null;
 };
 HtmlNode.getAttrsFromSeq=function(children)
 {
  var x,s;
  x=Seq.choose(HtmlNode.chooseAttr,children);
  s=List.choose(Global.id,List.ofArray([HtmlNode.groupAttr("class"," ",children),HtmlNode.groupAttr("style","; ",children)]));
  return Seq.append(s,x);
 };
 HtmlNode.groupAttr=function(name,sep,children)
 {
  var ss,c,v,r,f;
  ss=(c=function(n)
  {
   return HtmlNode.chooseThisAttr(name,n);
  },function(s)
  {
   return Seq.choose(c,s);
  }(children));
  return Seq.isEmpty(ss)?null:{
   $:1,
   $0:(v=(r=(f=function(a,b)
   {
    return HtmlNode.concat(sep,a,b);
   },(Runtime.Curried3(Val.map2))(function($1)
   {
    return function($2)
    {
     return f($1,$2);
    };
   })),function(s)
   {
    return Seq.reduce(function($1,$2)
    {
     return(r($1))($2);
    },s);
   }(ss)),Val.attrV(name,v))
  };
 };
 HtmlNode.concat=function(s,a,b)
 {
  return a+s+b;
 };
 HtmlNode.chooseThisAttr=function(_this,node)
 {
  var $1;
  return(node.$==1?node.$0===_this?($1=[node.$0,node.$1],true):false:false)?{
   $:1,
   $0:$1[1]
  }:null;
 };
 HtmlNode.chooseAttr=function(node)
 {
  var $1,name,name$1,value;
  return(node.$==1?(name=node.$0,name!=="class"?name!=="style":false)?($1=[node.$0,node.$1],true):false:false)?(name$1=$1[0],(value=$1[1],{
   $:1,
   $0:Val.attrV(name$1,value)
  })):node.$==5?{
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
  var s,e;
  s=(e=Strings.SplitChars(classes,[32],0),new FSharpSet.New$1(BalancedTree.OfSeq(e))).Remove(rem);
  return Strings.concat(" ",s);
 };
 HtmlNode.addClass=function(classes,add)
 {
  var s,x,e,s$1,e$1;
  s=(x=(e=Strings.SplitChars(classes,[32],0),new FSharpSet.New$1(BalancedTree.OfSeq(e))),(s$1=(e$1=Strings.SplitChars(add,[32],0),new FSharpSet.New$1(BalancedTree.OfSeq(e$1))),new FSharpSet.New$1(BalancedTree.OfSeq(Seq.append(s$1,x)))));
  return Strings.concat(" ",s);
 };
 Button=Template.Button=Runtime.Class({
  OnClick:function(f)
  {
   return Button.New(this._class,this._type,this.style,this.text,f,this.disabled,this.id);
  },
  Disabled:function(dis)
  {
   var d;
   d=Val.fixit(dis);
   return Button.New(this._class,this._type,this.style,this.text,this.onClick,d,this.id);
  },
  Text:function(txt)
  {
   var t;
   t=Val.fixit(txt);
   return Button.New(this._class,this._type,this.style,t,this.onClick,this.disabled,this.id);
  },
  Style:function(sty)
  {
   var s;
   s=Val.fixit(sty);
   return Button.New(this._class,this._type,s,this.text,this.onClick,this.disabled,this.id);
  },
  Type:function(typ)
  {
   var t;
   t=Val.fixit(typ);
   return Button.New(this._class,t,this.style,this.text,this.onClick,this.disabled,this.id);
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
   var a,a$1,a$2,a$3,a$4,a$5;
   return HtmlNode.button([HtmlNode.type(this._type),HtmlNode["class"](this._class),HtmlNode.Id(this.id),HtmlNode.style(this.style),(a=(a$1=View.Const(""),(a$2=Val.toView(this.disabled),AttrModule.DynamicPred("disabled",a$2,a$1))),new HtmlNode$1({
    $:5,
    $0:a
   })),(a$3=(a$4=this.onClick,AttrProxy.Handler("click",a$4)),new HtmlNode$1({
    $:5,
    $0:a$3
   })),(a$5=this.text,new HtmlNode$1({
    $:2,
    $0:a$5
   }))]);
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
   var p;
   p=Val.fixit(plc);
   return Input.New(this._type,this._class,this.style,p,this.id,this["var"],this.prefix,this.suffix,this.content,this.prefixAdded,this.suffixAdded);
  },
  Style:function(sty)
  {
   var s;
   s=Val.fixit(sty);
   return Input.New(this._type,this._class,s,this.placeholder,this.id,this["var"],this.prefix,this.suffix,this.content,this.prefixAdded,this.suffixAdded);
  },
  Type:function(typ)
  {
   return Input.New(Val.fixit(typ),this._class,this.style,this.placeholder,this.id,this["var"],this.prefix,this.suffix,this.content,this.prefixAdded,this.suffixAdded);
  },
  Class:function(clas)
  {
   var c;
   c=Val.fixit(clas);
   return Input.New(this._type,c,this.style,this.placeholder,this.id,this["var"],this.prefix,this.suffix,this.content,this.prefixAdded,this.suffixAdded);
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
    return Seq.append(($this.prefixAdded?true:$this.suffixAdded)?[HtmlNode["class"]("input-group")]:[],Seq.delay(function()
    {
     return Seq.append($this.prefixAdded?[HtmlNode.span([HtmlNode["class"](groupClass($this.prefix)),$this.prefix])]:[],Seq.delay(function()
     {
      var a,a$1,x,a$2,s,a$3;
      return Seq.append([(a=(a$1=(x=List.ofArray([HtmlNode._type($this._type),HtmlNode._class($this._class),HtmlNode._style($this.style),(a$2=$this.id,AttrProxy.Create("id",a$2)),HtmlNode._placeholder($this.placeholder)]),(s=$this.content,Seq.append(s,x))),(a$3=$this["var"],Doc.Input(a$1,a$3))),new HtmlNode$1({
       $:4,
       $0:a
      }))],Seq.delay(function()
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
  var c,t,s,p,c$1,p$1,s$1;
  c=Val.fixit("form-control");
  t=Val.fixit("text");
  s=Val.fixit("");
  p=Val.fixit("Enter text:");
  c$1=List.T.Empty;
  p$1=HtmlNode$1.HtmlEmpty;
  s$1=HtmlNode$1.HtmlEmpty;
  return Input.New(t,c,s,p,"",_var,p$1,s$1,c$1,false,false);
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
   var $this,x,a,a$1,s;
   $this=this;
   return HtmlNode.div((x=List.ofArray([HtmlNode.classIf("hovering",this.hover),(a=AttrModule.Handler("mouseenter",function()
   {
    return function()
    {
     return $this.hover.set_RVal(true);
    };
   }),new HtmlNode$1({
    $:5,
    $0:a
   })),(a$1=AttrModule.Handler("mouseleave",function()
   {
    return function()
    {
     return $this.hover.set_RVal(false);
    };
   }),new HtmlNode$1({
    $:5,
    $0:a$1
   }))]),(s=this.content,Seq.append(s,x))));
  }
 },null,Hoverable);
 Hoverable.get_Demo=function()
 {
  var hover;
  hover=Var.Create$1(false);
  return Hoverable.New(hover,List.ofArray([HtmlNode.style("flex-flow: column;")]));
 };
 Hoverable.get_New=function()
 {
  var hover;
  hover=Var.Create$1(false);
  return Hoverable.New(hover,List.T.Empty);
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
   return TextArea.New(this._class,this.placeholder,this.title,this.id,v);
  },
  Id:function(id)
  {
   return TextArea.New(this._class,this.placeholder,this.title,id,this["var"]);
  },
  Title:function(ttl)
  {
   var t;
   t=Val.fixit(ttl);
   return TextArea.New(this._class,this.placeholder,t,this.id,this["var"]);
  },
  Placeholder:function(plc)
  {
   var p;
   p=Val.fixit(plc);
   return TextArea.New(this._class,p,this.title,this.id,this["var"]);
  },
  Class:function(clas)
  {
   return TextArea.New(Val.fixit(clas),this.placeholder,this.title,this.id,this["var"]);
  },
  get_Render:function()
  {
   var a,a$1,a$2;
   return HtmlNode.someElt((a=[HtmlNode._class(this._class),(a$1=this.id,AttrProxy.Create("id",a$1)),HtmlNode.atr("title",this.title),HtmlNode._placeholder(this.placeholder)],(a$2=this["var"],Doc.InputArea(a,a$2))));
  }
 },null,TextArea);
 TextArea.New$1=function(v)
 {
  return TextArea.New$2(Var.Create$1(v));
 };
 TextArea.New$2=function(_var)
 {
  return TextArea.New(Val.fixit("form-control"),Val.fixit("Enter text:"),Val.fixit(""),"",_var);
 };
 TextArea.New=function(_class,placeholder,title,id,_var)
 {
  return new TextArea({
   _class:_class,
   placeholder:placeholder,
   title:title,
   id:id,
   "var":_var
  });
 };
 CodeMirror=Template.CodeMirror=Runtime.Class({
  get_Var:function()
  {
   return this["var"];
  },
  OnChange:function(f)
  {
   return CodeMirror.New(this._class,this.id,this["var"],f);
  },
  SetVar:function(v)
  {
   return CodeMirror.New(this._class,this.id,v,this.onChange);
  },
  Id:function(id)
  {
   return CodeMirror.New(this._class,id,this["var"],this.onChange);
  },
  Class:function(clas)
  {
   return CodeMirror.New(Val.fixit(clas),this.id,this["var"],this.onChange);
  },
  get_Render:function()
  {
   var $this,a,a$1,a$2;
   $this=this;
   return HtmlNode.div([HtmlNode["class"](this._class),(a=(a$1=this.id,AttrProxy.Create("id",a$1)),new HtmlNode$1({
    $:5,
    $0:a
   })),HtmlNode.style("position: relative; height: 300px"),HtmlNode.div([HtmlNode.style("height: 100%; width: 100%; position: absolute;"),(a$2=AttrModule.OnAfterRender(function(el)
   {
    var files;
    files=Template.codeMirrorIncludes();
    Global.CIPHERSpaceLoadFiles(files,function()
    {
     var editor,a$3;
     editor=Global.CodeMirror(el,{
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
     editor.on("change",function()
     {
      var v;
      v=editor.getValue();
      $this["var"].RVal()!==v?($this["var"].set_RVal(v),$this.onChange()):void 0;
     });
     a$3=function(v)
     {
      if(editor.getValue()!==v)
       {
        editor.setValue(v);
        editor.getDoc().clearHistory();
       }
     };
     (function(a$4)
     {
      View.Sink(a$3,a$4);
     }($this["var"].RView()));
    });
   }),new HtmlNode$1({
    $:5,
    $0:a$2
   }))]),HtmlNode.link([HtmlNode.href("/EPFileX/codemirror/content/editor.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")]),HtmlNode.link([HtmlNode.href("/EPFileX/codemirror/content/codemirror.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")]),HtmlNode.link([HtmlNode.href("/EPFileX/codemirror/content/theme/rubyblue.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")]),HtmlNode.link([HtmlNode.href("/EPFileX/codemirror/scripts/addon/display/fullscreen.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")]),HtmlNode.link([HtmlNode.href("/EPFileX/codemirror/scripts/addon/dialog/dialog.css"),HtmlNode.type("text/css"),HtmlNode.rel("stylesheet")])]);
  }
 },null,CodeMirror);
 CodeMirror.New$1=function(v)
 {
  return CodeMirror.New$2(Var.Create$1(v));
 };
 CodeMirror.New$2=function(_var)
 {
  return CodeMirror.New(Val.fixit(""),"",_var,function()
  {
  });
 };
 CodeMirror.New=function(_class,id,_var,onChange)
 {
  return new CodeMirror({
   _class:_class,
   id:id,
   "var":_var,
   onChange:onChange
  });
 };
 SplitterBar=Template.SplitterBar=Runtime.Class({
  get_After:function()
  {
   return SplitterBar.New(this.value,this.min,this.max,this.vertical,this.node,true,this.dragging,this.startVer,this.startP,this.start,this.size,this.domElem);
  },
  get_Before:function()
  {
   return SplitterBar.New(this.value,this.min,this.max,this.vertical,this.node,false,this.dragging,this.startVer,this.startP,this.start,this.size,this.domElem);
  },
  Horizontal:function()
  {
   var v;
   v=Val.fixit(false);
   return SplitterBar.New(this.value,this.min,this.max,v,this.node,this.after,this.dragging,this.startVer,this.startP,this.start,this.size,this.domElem);
  },
  Vertical:function()
  {
   var v;
   v=Val.fixit(true);
   return SplitterBar.New(this.value,this.min,this.max,v,this.node,this.after,this.dragging,this.startVer,this.startP,this.start,this.size,this.domElem);
  },
  Var:function(v)
  {
   return SplitterBar.New(v,this.min,this.max,this.vertical,this.node,this.after,this.dragging,this.startVer,this.startP,this.start,this.size,this.domElem);
  },
  Horizontal$1:function(v)
  {
   var v$1,v$2;
   v$1=(v$2=Val.fixit(v),Val.map(function(v$3)
   {
    return!v$3;
   },v$2));
   return SplitterBar.New(this.value,this.min,this.max,v$1,this.node,this.after,this.dragging,this.startVer,this.startP,this.start,this.size,this.domElem);
  },
  Vertical$1:function(v)
  {
   var v$1;
   v$1=Val.fixit(v);
   return SplitterBar.New(this.value,this.min,this.max,v$1,this.node,this.after,this.dragging,this.startVer,this.startP,this.start,this.size,this.domElem);
  },
  Max:function(v)
  {
   var m;
   m=Val.fixit(v);
   return SplitterBar.New(this.value,this.min,m,this.vertical,this.node,this.after,this.dragging,this.startVer,this.startP,this.start,this.size,this.domElem);
  },
  Min:function(v)
  {
   var m;
   m=Val.fixit(v);
   return SplitterBar.New(this.value,m,this.max,this.vertical,this.node,this.after,this.dragging,this.startVer,this.startP,this.start,this.size,this.domElem);
  },
  Node:function(node)
  {
   return SplitterBar.New(this.value,this.min,this.max,this.vertical,node,this.after,this.dragging,this.startVer,this.startP,this.start,this.size,this.domElem);
  },
  Value:function(v)
  {
   this.value.set_RVal(v);
   return this;
  },
  get_Render:function()
  {
   var $this,mouseCoord,size,drag,startDragging,a,a$1;
   function finishDragging()
   {
    if($this.dragging)
     {
      $this.dragging=false;
      Global.window.removeEventListener("mousemove",drag,false);
      Global.window.removeEventListener("mouseup",finishDragging,false);
     }
   }
   $this=this;
   mouseCoord=function(ev)
   {
    var x,x$1;
    return $this.startVer?(x=ev.clientX,Global.Number(x)):(x$1=ev.clientY,Global.Number(x$1));
   };
   size=function()
   {
    var m;
    m=$this.domElem;
    return(m!=null?m.$==1:false)?$this.startVer?$this.after?m.$0.parentElement.getBoundingClientRect().width:-m.$0.parentElement.getBoundingClientRect().width:$this.after?m.$0.parentElement.getBoundingClientRect().height:-m.$0.parentElement.getBoundingClientRect().height:100;
   };
   drag=function(ev)
   {
    $this.value.set_RVal((mouseCoord(ev)-$this.start)*100/$this.size+$this.startP);
   };
   startDragging=function(a$2,ev)
   {
    var f;
    return!$this.dragging?(f=function()
    {
    },function(v)
    {
     Val.iter(f,v);
    }(Val.map2(function(startP)
    {
     return function(dirV)
     {
      $this.dragging=true;
      $this.startVer=dirV;
      $this.startP=startP;
      $this.start=mouseCoord(ev);
      $this.size=size();
      Global.window.addEventListener("mousemove",drag,false);
      Global.window.addEventListener("mouseup",finishDragging,false);
      return ev.preventDefault();
     };
    },$this.get_GetValue(),$this.vertical))):null;
   };
   return this.node.AddChildren([(a=AttrModule.Handler("mousedown",function($1)
   {
    return function($2)
    {
     return startDragging($1,$2);
    };
   }),new HtmlNode$1({
    $:5,
    $0:a
   })),(a$1=AttrModule.OnAfterRender(function(el)
   {
    $this.domElem={
     $:1,
     $0:el
    };
   }),new HtmlNode$1({
    $:5,
    $0:a$1
   }))]);
  },
  get_GetValue:function()
  {
   var x,x$1,v,v$1;
   x=(x$1=this.value,(v=this.min,Val.map2(function($1)
   {
    return function($2)
    {
     return Operators.Max($1,$2);
    };
   },v,x$1)));
   v$1=this.max;
   return Val.map2(function($1)
   {
    return function($2)
    {
     return Operators.Min($1,$2);
    };
   },v$1,x);
  }
 },null,SplitterBar);
 SplitterBar.get_New=function()
 {
  return SplitterBar.New(Var.Create$1(30),Val.fixit(10),Val.fixit(75),Val.fixit(true),HtmlNode.div([HtmlNode["class"]("Splitter")]),true,false,true,0,0,0,null);
 };
 SplitterBar.New=function(value,min,max,vertical,node,after,dragging,startVer,startP,start,size,domElem)
 {
  return new SplitterBar({
   value:value,
   min:min,
   max:max,
   vertical:vertical,
   node:node,
   after:after,
   dragging:dragging,
   startVer:startVer,
   startP:startP,
   start:start,
   size:size,
   domElem:domElem
  });
 };
 Template.codeMirrorIncludes=function()
 {
  SC$1.$cctor();
  return SC$1.codeMirrorIncludes;
 };
 EditorRpc.evaluate=function(callback,source)
 {
  var x;
  x=(new AjaxRemotingProvider.New()).Async("ZafirTranspiler:CIPHERPrototype.Editor.evaluate:-1485533303",[source]);
  EditorRpc.callRPC(x,callback);
 };
 EditorRpc.translate=function(callback,minified,source)
 {
  var x;
  x=(new AjaxRemotingProvider.New()).Async("ZafirTranspiler:CIPHERPrototype.Editor.translate:796244877",[source,minified]);
  EditorRpc.callRPC(x,callback);
 };
 EditorRpc.declarations=function(callback,line,col,source)
 {
  var x;
  x=(new AjaxRemotingProvider.New()).Async("ZafirTranspiler:CIPHERPrototype.Editor.declarations:-2117802712",[source,line,col]);
  EditorRpc.callRPC(x,callback);
 };
 EditorRpc.methods=function(callback,line,col,source)
 {
  var x;
  x=(new AjaxRemotingProvider.New()).Async("ZafirTranspiler:CIPHERPrototype.Editor.methods:-34435681",[source,line,col]);
  EditorRpc.callRPC(x,callback);
 };
 EditorRpc.checkSource=function(callback,source)
 {
  var x;
  x=(new AjaxRemotingProvider.New()).Async("ZafirTranspiler:CIPHERPrototype.Editor.checkSource:2013062947",[source]);
  EditorRpc.callRPC(x,callback);
 };
 EditorRpc.callRPC=function(asy,callback)
 {
  Concurrency.StartWithContinuations(asy,callback,function(e)
  {
   Global.alert(Global.String(e));
  },function(c)
  {
   Global.alert(Global.String(c));
  },null);
 };
 RunNode=RunCode.RunNode=Runtime.Class({
  createBaseNode:function()
  {
   var el,v;
   el=Global.document.createElement("div");
   el.setAttribute("id",this.nodeName);
   v=Global.document.body.appendChild(el);
   return el;
  },
  RunHtmlPlusFree:function(node)
  {
   var freeHtml,freeCSS,freeFS,freeJS,freeMsgs,sendMsg,runJS,runFS,a,a$1,a$2,a$3,a$4,a$5,f;
   freeHtml=Var.Create$1("");
   freeCSS=Var.Create$1("");
   freeFS=Var.Create$1("");
   freeJS=Var.Create$1("");
   freeMsgs=Var.Create$1("");
   sendMsg=function(msg)
   {
    var a$6,$1;
    a$6=($1=freeMsgs.c,$1===null?msg:$1===""?msg:msg===null?$1:msg===""?$1:$1+"\n"+msg);
    Var.Set(freeMsgs,a$6);
   };
   runJS=function()
   {
    var $1,$2,v,x;
    sendMsg("Running JavaScript...");
    try
    {
     $2=(v=(x=freeJS.c,Global["eval"](x)),(sendMsg("Done!"),Global.String(v)));
    }
    catch(e)
    {
     $2=(sendMsg("Failed!"),Global.String(e));
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
   }).get_Render(),HtmlNode.someElt((a=[AttrProxy.Create("placeholder","F#:"),AttrProxy.Create("title","Add F# code and invoke with Eval F#")],Doc.InputArea(a,freeFS))),HtmlNode.someElt((a$1=[AttrProxy.Create("placeholder","HTML:"),AttrProxy.Create("title","Enter HTML tags and text")],Doc.InputArea(a$1,freeHtml))),HtmlNode.someElt((a$2=[AttrProxy.Create("placeholder","CSS:"),AttrProxy.Create("title","Test your CSS styles dynamically")],Doc.InputArea(a$2,freeCSS))),HtmlNode.someElt((a$3=[AttrProxy.Create("placeholder","JavaScript:"),AttrProxy.Create("title","Add JS code and invoke with Eval JS")],Doc.InputArea(a$3,freeJS))),Button.New$1("Eval JS").Style("vertical-align:top").OnClick(function()
   {
    return function()
    {
     Var.Set(freeMsgs,"");
     return runJS();
    };
   }).get_Render(),HtmlNode.someElt((a$4=[AttrProxy.Create("placeholder","Output:"),AttrProxy.Create("title","Messages")],Doc.InputArea(a$4,freeMsgs))),(a$5=HtmlNode.tag(Doc.Verbatim,Val.map2((f=function($1,$2,$3)
   {
    return $1(PrintfHelpers.toSafe($2)+"<style>"+PrintfHelpers.toSafe($3)+"</style>");
   },(Runtime.Curried3(f))(Global.id)),freeHtml,freeCSS)),new HtmlNode$1({
    $:4,
    $0:a$5
   }))]));
  },
  RunHtml:function(node)
  {
   this.RunDoc((HtmlNode.renderDoc())(node));
  },
  RunDoc:function(doc)
  {
   var a;
   a=this.get_RunNode();
   (function(a$1)
   {
    Doc.Run(a,a$1);
   }(doc));
  },
  get_AddBootstrap:function()
  {
   var el,v;
   el=Global.document.createElement("div");
   el.innerHTML="<script src='http://code.jquery.com/jquery-3.1.1.min.js' type='text/javascript' charset='UTF-8'></script>\r\n                <script src='http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js' type='text/javascript' charset='UTF-8'></script>\r\n                <link type='text/css' rel='stylesheet' href='http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css'>\r\n                <link type='text/css' rel='stylesheet' href='/EPFileX/css/main.css'>\r\n                ";
   v=this.runNode.appendChild(el);
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
   $0:Operators.DefaultArg(clearNode,true)
  });
 },RunNode);
 RunNode.New$1=Runtime.Ctor(function(nodeName,clearNode)
 {
  var baseNode,m,m$1,e,v;
  this.nodeName=nodeName;
  baseNode=(m=Global.document.getElementById(this.nodeName),Unchecked.Equals(m,null)?this.createBaseNode():m);
  this.runNode=(m$1=baseNode.shadowRoot,Unchecked.Equals(m$1,null)?(e=Global.document.createElement("div"),(v=baseNode.attachShadow({
   mode:"open"
  }).appendChild(e),e.style="height: 100%; width: 100%;",e)):m$1.firstChild);
  Operators.DefaultArg(clearNode,true)?this.runNode.innerHTML="":void 0;
 },RunNode);
 RunCode.compile=function(fThen,fFail,code)
 {
  var c;
  c=function(jsO,msgs)
  {
   var a,x;
   a=jsO==null?null:(x=jsO.$0,{
    $:1,
    $0:RunCode.completeJS(x)
   });
   a==null?fFail(msgs):fThen(msgs,a.$0);
  };
  (((Runtime.Curried3(EditorRpc.translate))(function($1)
  {
   return c($1[0],$1[1]);
  }))(false))(code);
 };
 RunCode.completeJS=function(js)
 {
  return"\r\n        CIPHERSpaceLoadFileGlobalFileRef = null;\r\n        CIPHERSpaceLoadFile = function (filename, callback) {\r\n            if (filename.slice(-3) == \".js\" || filename.slice(-4) == \".fsx\" || filename.slice(-3) == \".fs\") { //if filename is a external JavaScript file\r\n                var fileRef = null;\r\n                var pre = document.querySelector('script[src=\"' + filename + '\"]')\r\n                if (!pre) {\r\n                    fileRef = document.createElement('script')\r\n                    fileRef.setAttribute(\"type\", \"text/javascript\")\r\n                    fileRef.setAttribute(\"src\", filename)\r\n                }\r\n                else callback();\r\n            }\r\n            else if (filename.slice(-4) == \".css\") { //if filename is an external CSS file\r\n                var pre = document.querySelector('script[src=\"' + filename + '\"]')\r\n                if (!pre) {\r\n                    fileRef = document.createElement(\"link\")\r\n                    fileRef.setAttribute(\"rel\", \"stylesheet\")\r\n                    fileRef.setAttribute(\"type\", \"text/css\")\r\n                    fileRef.setAttribute(\"href\", filename)\r\n                }\r\n                else callback();\r\n            }\r\n            else if (filename.slice(-5) == \".html\") { //if filename is an external HTML file\r\n                var pre = document.querySelector('script[src=\"' + filename + '\"]')\r\n                if (!pre) {\r\n                    fileRef = document.createElement(\"link\")\r\n                    fileRef.setAttribute(\"rel\", \"import\")\r\n                    fileRef.setAttribute(\"type\", \"text/html\")\r\n                    fileRef.setAttribute(\"href\", filename)\r\n                }\r\n                else callback();\r\n            }\r\n            if (!!fileRef) {\r\n                CIPHERSpaceLoadFileGlobalFileRef = fileRef;\r\n    \u0009\u0009\u0009fileRef.onload = function () { fileRef.onload = null;  callback(); }\r\n                document.getElementsByTagName(\"head\")[0].appendChild(fileRef);\r\n            }\r\n        }\r\n        CIPHERSpaceLoadFiles = function (files, callback) {\r\n            var newCallback = callback\r\n            if (!!CIPHERSpaceLoadFileGlobalFileRef && !!(CIPHERSpaceLoadFileGlobalFileRef.onload)) {\r\n                var oldCallback = CIPHERSpaceLoadFileGlobalFileRef.onload;\r\n                CIPHERSpaceLoadFileGlobalFileRef.onload = null;\r\n                newCallback = function () {\r\n                    callback();\r\n                    oldCallback();\r\n                }\r\n            }\r\n            var i = 0;\r\n            loadNext = function () {\r\n                if (i < files.length) {\r\n                    var file = files[i];\r\n                    i++;\r\n                    CIPHERSpaceLoadFile(file, loadNext);\r\n                }\r\n                else newCallback();\r\n            };\r\n            loadNext();\r\n    \u0009}\r\n        CIPHERSpaceLoadFiles(['https://code.jquery.com/jquery-3.1.1.min.js'], function() {}); \r\n    \u0009CIPHERSpaceLoadFilesDoAfter = function (callback) {\r\n    \u0009\u0009var newCallback = callback\r\n    \u0009\u0009if (!!CIPHERSpaceLoadFileGlobalFileRef) {\r\n    \u0009\u0009\u0009if (!!(CIPHERSpaceLoadFileGlobalFileRef.onload)) {\r\n    \u0009\u0009\u0009\u0009var oldCallback = CIPHERSpaceLoadFileGlobalFileRef.onload;\r\n    \u0009\u0009\u0009\u0009CIPHERSpaceLoadFileGlobalFileRef.onload = null;\r\n    \u0009\u0009\u0009\u0009newCallback = function () {\r\n    \u0009\u0009\u0009\u0009\u0009oldCallback();\r\n    \u0009\u0009\u0009\u0009\u0009callback();\r\n    \u0009\u0009\u0009\u0009}\r\n    \u0009\u0009\u0009}\r\n    \u0009\u0009}\r\n    \u0009\u0009else CIPHERSpaceLoadFileGlobalFileRef = {};\r\n    \u0009\u0009CIPHERSpaceLoadFileGlobalFileRef.onload = newCallback;\r\n    \u0009}\r\n    \r\n    CIPHERSpaceLoadFilesDoAfter(function() { \r\n      if (typeof IntelliFactory !=='undefined')\r\n        IntelliFactory.Runtime.Start();\r\n      for (key in window) { \r\n        if (key.startsWith(\"StartupCode$\")) \r\n          try { window[key].$cctor(); } catch (e) {} \r\n      } \r\n    })\r\n                     "+js;
 };
 CodeSnippetId.get_New=function()
 {
  return{
   $:0,
   $0:Guid.NewGuid()
  };
 };
 CodeSnippet=CodeEditor.CodeSnippet=Runtime.Class({
  IsDescendantOf:function(antId)
  {
   function isDescendantOf(snp)
   {
    var m,parId,o,o$1;
    m=snp.parent;
    return(m!=null?m.$==1:false)?(parId=m.$0,Unchecked.Equals(parId,antId)?true:(o=(o$1=CodeSnippet.FetchO(parId),o$1==null?null:{
     $:1,
     $0:isDescendantOf(o$1.$0)
    }),o==null?false:o.$0)):false;
   }
   return isDescendantOf(this);
  },
  Code:function()
  {
   var preds,s,m,p;
   preds=Arrays.ofSeq(this.UniquePredecesors());
   s=(m=function(snp)
   {
    return snp.ContentIndented();
   },function(s$1)
   {
    return Seq.map(m,s$1);
   }((p=function(snp)
   {
    var v;
    v=snp.id;
    return function(a)
    {
     return Arrays.contains(v,a);
    }(preds);
   },function(s$1)
   {
    return Seq.filter(p,s$1);
   }((CodeEditor.codeSnippets())["var"].RVal()))));
   return Strings.concat("\n",s);
  },
  ContentIndented:function()
  {
   var lvl,x,s,m,_this,f,f$1;
   lvl=this.Level();
   x=(lvl===0?true:lvl===1)?this.content:(s=(m=function(l)
   {
    return Strings.StartsWith(l,"#")?l:Strings.replicate(lvl,"  ")+l;
   },function(a)
   {
    return Arrays.map(m,a);
   }((_this=this.content,Strings.SplitChars(_this,[10],0)))),Strings.concat("\n",s));
   return(((f=function($1,$2,$3,$4)
   {
    return $1("# 1 @\""+PrintfHelpers.toSafe($2)+" "+PrintfHelpers.toSafe($3)+"\"\n"+PrintfHelpers.toSafe($4));
   },(Runtime.Curried(f,4))(Global.id))((lvl===0?true:lvl===1)?"":(f$1=function($1,$2)
   {
    return $1("("+Global.String($2)+")");
   },(function($1)
   {
    return function($2)
    {
     return f$1($1,$2);
    };
   }(Global.id))(lvl*2))))(this.get_NameSanitized()))(x);
  },
  get_NameSanitized:function()
  {
   var illegal,p;
   illegal=[34,60,62,124,0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,58,42,63,92,47];
   return"F# "+(p=function(c)
   {
    return!Arrays.contains(c,illegal);
   },function(s)
   {
    return Strings.Filter(p,s);
   }(this.get_Name()))+".fsx";
  },
  Level:function()
  {
   function level(snp,out)
   {
    var o,m,o$1;
    o=(m=function(p)
    {
     return level(p,out+1);
    },function(o$2)
    {
     return o$2==null?null:{
      $:1,
      $0:m(o$2.$0)
     };
    }((o$1=snp.parent,o$1==null?null:CodeSnippet.FetchO(o$1.$0))));
    return o==null?out:o.$0;
   }
   return level(this,0);
  },
  UniquePredecesors:function()
  {
   function preds(ins,outs)
   {
    var rest,hd,x,m;
    return ins.$==1?(rest=ins.$1,(hd=ins.$0,(x=List.collect(Global.id,List.ofArray([rest,(m=function(s)
    {
     var x$1,l;
     x$1=Option.toList(s.parent);
     l=s.predecessors;
     return List.append(x$1,l);
    },function(l)
    {
     return List.collect(m,l);
    }(CodeSnippet.FetchL(hd)))])),preds(x,Seq.contains(hd,outs)?outs:new List.T({
     $:1,
     $0:hd,
     $1:outs
    }))))):outs;
   }
   return preds(List.ofArray([this.id]),List.T.Empty);
  },
  get_Name:function()
  {
   return CodeEditor.snippetName(this.name,this.content);
  }
 },null,CodeSnippet);
 CodeSnippet.New$1=function(od,nm,pa,pred,co,cnt)
 {
  var newS,$1,a,a$1,t,a$2;
  newS=CodeSnippet.New(nm,cnt,pa,pred,co,CodeSnippetId.get_New(),true);
  $1=CodeEditor.codeSnippets().get_Length();
  $1===0?CodeEditor.codeSnippets().Append(newS):od===0?(a=Seq.append([newS],(CodeEditor.codeSnippets())["var"].RVal()),CodeEditor.codeSnippets().Set(a)):od<$1?(a$1=(t=(a$2=Arrays.ofSeq((CodeEditor.codeSnippets())["var"].RVal()),Arrays.splitAt(od,a$2)),t[0].concat([newS].concat(t[1]))),CodeEditor.codeSnippets().Set(a$1)):CodeEditor.codeSnippets().Append(newS);
  return newS;
 };
 CodeSnippet.New$2=function(nm,pa,pred,co,cnt)
 {
  return CodeSnippet.New$1(CodeEditor.codeSnippets().get_Length(),nm,pa,pred,co,cnt);
 };
 CodeSnippet.New$3=function(cnt)
 {
  return CodeSnippet.New$2("",null,List.T.Empty,List.T.Empty,cnt);
 };
 CodeSnippet.New$4=function(pa,cnt)
 {
  return CodeSnippet.New$2("",{
   $:1,
   $0:pa
  },List.T.Empty,List.T.Empty,cnt);
 };
 CodeSnippet.New$5=function(pa,pred,cnt)
 {
  return CodeSnippet.New$2("",{
   $:1,
   $0:pa
  },pred,List.T.Empty,cnt);
 };
 CodeSnippet.New$6=function(pred,cnt)
 {
  return CodeSnippet.New$2("",null,pred,List.T.Empty,cnt);
 };
 CodeSnippet.FetchL=function(id)
 {
  return Option.toList(CodeSnippet.FetchO(id));
 };
 CodeSnippet.FetchO=function(id)
 {
  return CodeEditor.codeSnippets().TryFindByKey(id);
 };
 CodeSnippet.PickIO=function(id)
 {
  var f;
  f=function(a,snp)
  {
   return Unchecked.Equals(snp.id,id);
  };
  return function(s)
  {
   return CodeEditor.tryPickI(function($1)
   {
    return f($1[0],$1[1]);
   },s);
  }((CodeEditor.codeSnippets())["var"].RVal());
 };
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
 CodeEditor.addNodeById=function(name,node)
 {
  var el,m,x,x$1;
  el=(m=Global.document.getElementById(name),Unchecked.Equals(m,null)?(x=Global.document.createElement("div"),Global.document.body.appendChild(x)):m);
  (x$1=node.AddChildren([HtmlNode.Id(name)]),(HtmlNode.renderDoc())(x$1)).ReplaceInDom(el);
 };
 CodeEditor.pageStyle=function()
 {
  SC$1.$cctor();
  return SC$1.pageStyle;
 };
 CodeEditor.splitterMain2=function()
 {
  SC$1.$cctor();
  return SC$1.splitterMain2;
 };
 CodeEditor.splitterMain1=function()
 {
  SC$1.$cctor();
  return SC$1.splitterMain1;
 };
 CodeEditor.styleSplit=function()
 {
  SC$1.$cctor();
  return SC$1.styleSplit;
 };
 CodeEditor.style2=function()
 {
  SC$1.$cctor();
  return SC$1.style2;
 };
 CodeEditor.style1=function()
 {
  SC$1.$cctor();
  return SC$1.style1;
 };
 CodeEditor.verticalSplit=function()
 {
  SC$1.$cctor();
  return SC$1.verticalSplit;
 };
 CodeEditor.horizontalSplit=function()
 {
  SC$1.$cctor();
  return SC$1.horizontalSplit;
 };
 CodeEditor.style2v=function()
 {
  SC$1.$cctor();
  return SC$1.style2v;
 };
 CodeEditor.style1v=function()
 {
  SC$1.$cctor();
  return SC$1.style1v;
 };
 CodeEditor.style2h=function()
 {
  SC$1.$cctor();
  return SC$1.style2h;
 };
 CodeEditor.style1h=function()
 {
  SC$1.$cctor();
  return SC$1.style1h;
 };
 CodeEditor.CodeEditor=function()
 {
  var a,a$1,a$2,x,a$3,a$4,v,view,contentVar,changingIRefO,a$5,a$6,v$1,view$1,contentVar$1,changingIRefO$1,a$7,a$8,a$9,a$10,a$11;
  return HtmlNode.div([HtmlNode["class"]("CodeEditor"),HtmlNode.div([HtmlNode.Id("Snippets"),(a=(a$1=Global.id,function(a$12)
  {
   return Doc.BindView(a$1,a$12);
  }((a$2=(x=CodeEditor.codeSnippets().v,(a$3=(CodeEditor.codeSnippets())["var"].RVal(),(a$4=CodeEditor.refresh().v,View.SnapshotOn(a$3,a$4,x)))),View.Map(CodeEditor.listEntries,a$2)))),new HtmlNode$1({
   $:4,
   $0:a
  }))]),Input.New$2((v=CodeEditor.currentCodeSnippetId(),(view=Val.toView(Val.fixit(v)),(contentVar=Var.Create$1(null),(changingIRefO=[null],(a$5=contentVar.v,View.Sink(function(v$2)
  {
   var o,r;
   o=changingIRefO[0];
   o==null?void 0:(r=o.$0,!Unchecked.Equals(r.RVal(),v$2)?r.set_RVal(v$2):void 0);
  },a$5),a$6=View.Bind(function(cur)
  {
   var r,a$12;
   r=CodeEditor.curSnippetNameOf(cur);
   changingIRefO[0]={
    $:1,
    $0:r
   };
   a$12=r.RVal();
   Var.Set(contentVar,a$12);
   return r.RView();
  },view),View.Sink(function(v$2)
  {
   Var.Set(contentVar,v$2);
  },a$6),contentVar)))))).Prefix(HtmlNode.htmlText("name:")).get_Render(),CodeMirror.New$2((v$1=CodeEditor.currentCodeSnippetId(),(view$1=Val.toView(Val.fixit(v$1)),(contentVar$1=Var.Create$1(null),(changingIRefO$1=[null],(a$7=contentVar$1.v,View.Sink(function(v$2)
  {
   var o,r;
   o=changingIRefO$1[0];
   o==null?void 0:(r=o.$0,!Unchecked.Equals(r.RVal(),v$2)?r.set_RVal(v$2):void 0);
  },a$7),a$8=View.Bind(function(cur)
  {
   var r,a$12;
   r=CodeEditor.curSnippetCodeOf(cur);
   changingIRefO$1[0]={
    $:1,
    $0:r
   };
   a$12=r.RVal();
   Var.Set(contentVar$1,a$12);
   return r.RView();
  },view$1),View.Sink(function(v$2)
  {
   Var.Set(contentVar$1,v$2);
  },a$8),contentVar$1)))))).OnChange(function()
  {
   CodeEditor.setDirty();
  }).Id("Code").get_Render().AddChildren([HtmlNode.style1("height","100%")]),TextArea.New$2(CodeEditor.codeMsgs()).Placeholder("Output:").Title("Messages").Id("Output").get_Render(),TextArea.New$2(CodeEditor.codeFS()).Placeholder("F# code:").Title("F# code assembled").Id("AllCode").get_Render(),TextArea.New$2(CodeEditor.codeJS()).Placeholder("Javascript:").Title("JavaScript code generated").Id("JScript").get_Render(),HtmlNode.div([HtmlNode.Id("Buttons"),Button.New$1("Add code").Class("btn btn-xs").OnClick((Runtime.Curried3(CodeEditor.Do))(function()
  {
   CodeEditor.addCode();
  })).get_Render(),Button.New$1("<<").Class("btn btn-xs").OnClick((Runtime.Curried3(CodeEditor.Do))(function()
  {
   CodeEditor.indentCodeOut();
  })).Disabled(CodeEditor.noSelectionVal()).get_Render(),Button.New$1(">>").Class("btn btn-xs").OnClick((Runtime.Curried3(CodeEditor.Do))(function()
  {
   CodeEditor.indentCodeIn();
  })).Disabled(CodeEditor.noSelectionVal()).get_Render(),CodeEditor.loadFileElement().get_Render(),HtmlNode.span([]),Button.New$1("Evaluate FS").Class("btn btn-xs").OnClick((Runtime.Curried3(CodeEditor.Do))(function()
  {
   CodeEditor.evaluateFS();
  })).Disabled(CodeEditor.noSelectionVal()).get_Render(),Button.New$1("Get F# code ==>").Class("btn btn-xs").OnClick((Runtime.Curried3(CodeEditor.Do))(function()
  {
   CodeEditor.getFSCode();
  })).Disabled(CodeEditor.noSelectionVal()).get_Render(),Button.New$1("Delete code").Class("btn btn-xs").OnClick((Runtime.Curried3(CodeEditor.Do))(function()
  {
   CodeEditor.deleteCode();
  })).Disabled(CodeEditor.noSelectionVal()).get_Render(),HtmlNode.span([]),HtmlNode.span([]),Button.New$1("Save as...").Class("btn            ").OnClick((Runtime.Curried3(CodeEditor.Do))(function()
  {
   CodeEditor.downloadFile();
  })).get_Render().AddChildren([HtmlNode.classIf("btn-primary",CodeEditor.dirty())]),HtmlNode.span([]),Button.New$1("Compile WebSharper").Class("btn btn-xs").OnClick((Runtime.Curried3(CodeEditor.Do))(function()
  {
   CodeEditor.justCompile();
  })).Disabled(CodeEditor.noSelectionVal()).get_Render(),Button.New$1("Run WebSharper in ...").Class("btn btn-xs").OnClick((Runtime.Curried3(CodeEditor.Do))(function()
  {
   CodeEditor.compileRun();
  })).Disabled(CodeEditor.noSelectionVal()).get_Render(),HtmlNode.someElt((a$9=[AttrProxy.Create("id","Position")],(a$10=List.ofArray([Position.Below,Position.Right,Position.NewBrowser]),(a$11=CodeEditor.position(),Doc.Select(a$9,CodeEditor.positionTxt,a$10,a$11)))))]),HtmlNode.script([HtmlNode.src("/EPFileX/FileSaver/FileSaver.js"),HtmlNode.type("text/javascript")]),HtmlNode.styleH([CodeEditor.styleEditor()]),CodeEditor.splitterV1().get_Render(),CodeEditor.splitterV2().get_Render(),CodeEditor.splitterH3().get_Render()]);
 };
 CodeEditor.styleEditor=function()
 {
  SC$1.$cctor();
  return SC$1.styleEditor;
 };
 CodeEditor.styleEditorF=function(sp1,sp2,sp3)
 {
  var f;
  return(((f=function($1,$2,$3,$4)
  {
   return $1("\r\n    div textarea {\r\n    font-family: monospace;\r\n    }\r\n    .code-editor-list-tile {\r\n    white-space: nowrap; \r\n    border-style: solid none none;\r\n    border-color: white;\r\n    border-width: 1px;\r\n    background-color: #D8D8D8;\r\n    display: flex;\r\n    }\r\n    .code-editor-list-text{\r\n    padding: 1px 10px 1px 5px;\r\n    overflow:hidden;\r\n    text-overflow: ellipsis;\r\n    white-space: nowrap;\r\n    flex: 1;\r\n    }\r\n    \r\n    .code-editor-list-tile.direct-predecessor {\r\n    font-weight: bold;\r\n    }\r\n    .code-editor-list-tile.indirect-predecessor {\r\n    color: blue;\r\n    }\r\n    .code-editor-list-tile.selected {\r\n    background-color: #77F;\r\n    color: white;\r\n    }\r\n    .code-editor-list-tile.hovering {\r\n    background: lightgray;\r\n    }\r\n    .code-editor-list-tile.hovering.selected {\r\n    background:  blue;\r\n    }\r\n    .code-editor-list-tile>.predecessor {\r\n    font-weight: bold;\r\n    border-style: inset;\r\n    border-width: 1px;\r\n    text-align: center;\r\n    color: transparent;\r\n    }\r\n    .code-editor-list-tile.direct-predecessor>.predecessor {\r\n    color: blue;\r\n    }\r\n    \r\n    \r\n    .CodeEditor {\r\n        display: grid;\r\n        grid-template-columns: "+$2.toFixed(6)+"% "+$3.toFixed(6)+"% minmax(0px, 97%);\r\n        grid-template-rows: 4% minmax(0px, 96%) "+$4.toFixed(6)+"% 10%;\r\n        grid-template-areas:\r\n        \"header0 header   header\"\r\n        \"sidebar content1 content1\"\r\n        \"sidebar content2 content3\"\r\n        \"footer  footer   footer2\";\r\n        color: #333;\r\n        height: 100%;\r\n        grid-gap: 9px;\r\n        padding : 9px;\r\n    }\r\n    \r\n    .CodeEditor > :nth-child(2){  grid-area: header  ; overflow: hidden;               }\r\n#Snippets                  {  grid-area: sidebar ; overflow: auto  ;               }\r\n#Code                      {  grid-area: content1; overflow: auto  ;               }\r\n#Output                    {  grid-area: content2; overflow: auto  ; resize: none; }\r\n#JScript                   {  grid-area: content3; overflow: auto  ; resize: none; }\r\n#AllCode                   {  grid-area: footer2 ; overflow: auto                  }\r\n#Buttons                   {  grid-area: footer  ;                                 }\r\n    \r\n    \r\n#Buttons { \r\n            display: grid;\r\n            grid-template-columns: repeat(8, 12.1%);\r\n            bxackground-color: #eee;\r\n            padding : 5px;\r\n            grid-gap: 5px;\r\n    }\r\n    \r\n#Buttons > div       { grid-column: 4/6 }\r\n    \r\n    .CodeMirror {\r\n        height: 100%;\r\n    }\r\n    \r\n    .sliderv {\r\n        background-color: #eef;\r\n        cursor: col-resize;\r\n    }\r\n    .sliderh {\r\n        background-color: #eef;\r\n        cursor: row-resize;   \r\n    }\r\n    .node {\r\n        background-color:white; \r\n        width: 2ch; \r\n        color: #A03; \r\n        font-weight:bold; \r\n        text-align: center;\r\n        font-family: arial;\r\n    }\r\n    \r\n        ");
  },(Runtime.Curried(f,4))(Global.id))(sp1))(sp2))(sp3);
 };
 CodeEditor.splitterH3=function()
 {
  SC$1.$cctor();
  return SC$1.splitterH3;
 };
 CodeEditor.splitterV2=function()
 {
  SC$1.$cctor();
  return SC$1.splitterV2;
 };
 CodeEditor.splitterV1=function()
 {
  SC$1.$cctor();
  return SC$1.splitterV1;
 };
 CodeEditor.Do=function(f,a,a$1)
 {
  return f();
 };
 CodeEditor.loadFileElement=function()
 {
  SC$1.$cctor();
  return SC$1.loadFileElement;
 };
 CodeEditor.downloadFile=function()
 {
  var x,x$1,obj,n,m;
  x=(x$1=Arrays.ofSeq((CodeEditor.codeSnippets())["var"].RVal()),(obj=((Provider.EncodeArray(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j))())(x$1),Global.JSON.stringify(obj)));
  n=(m=CodeEditor.justFileName(CodeEditor.fileName().c),m===""?"snippets.fsjson":m);
  Global.saveAs(new Global.Blob([x],{
   type:"text/plain;charset=utf-8"
  }),n);
  CodeEditor.setClean();
 };
 CodeEditor.loadFile=function(e)
 {
  if(!CodeEditor.dirty().c?true:Global.confirm("Changes have not been saved, do you really want to load?"))
   CodeEditor.loadTextFile(e.getRootNode().firstChild.querySelector("#"+CodeEditor.fileInputElementId()),function(txt)
   {
    var a;
    try
    {
     a=((Provider.DecodeArray(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j))())(Global.JSON.parse(txt));
     CodeEditor.codeSnippets().Set(a);
     CodeEditor.setClean();
     CodeEditor.refreshView();
    }
    catch(e$1)
    {
     Global.alert(Global.String(e$1));
    }
   });
 };
 CodeEditor.fileInputElementId=function()
 {
  SC$1.$cctor();
  return SC$1.fileInputElementId;
 };
 CodeEditor.loadTextFile=function(element,f)
 {
  var files,reader;
  files=element.files;
  files.length>0?(reader=new Global.FileReader(),reader.onload=function(e)
  {
   return f(e.target.result);
  },reader.readAsText(files.item(0))):void 0;
 };
 CodeEditor.emptyFile=function()
 {
  SC$1.$cctor();
  return SC$1.emptyFile;
 };
 CodeEditor.fileName=function()
 {
  SC$1.$cctor();
  return SC$1.fileName;
 };
 CodeEditor.justFileName=function(f)
 {
  return Seq.last(Strings.SplitChars(f,[47,92],0));
 };
 CodeEditor.deleteCode=function()
 {
  var a;
  a=function(snp)
  {
   var message,f,a$1,a$2;
   if(message=(f=function($1,$2)
   {
    return $1("Do you want to delete "+PrintfHelpers.toSafe($2)+"?");
   },(function($1)
   {
    return function($2)
    {
     return f($1,$2);
    };
   }(Global.id))(snp.get_Name())),Global.confirm(message))
    {
     a$1=CodeEditor.currentCodeSnippetId();
     a$2=CodeSnippetId.get_New();
     Var.Set(a$1,a$2);
     CodeEditor.codeSnippets().Remove(snp);
     CodeEditor.setDirty();
     CodeEditor.refreshView();
    }
  };
  (function(o)
  {
   if(o==null)
    ;
   else
    a(o.$0);
  }(CodeSnippet.FetchO(CodeEditor.currentCodeSnippetId().c)));
 };
 CodeEditor.addCode=function()
 {
  var n,d,m,a,a$1;
  n=(d=function()
  {
   return CodeSnippet.New$3("");
  },function(o)
  {
   return o==null?d():o.$0;
  }((m=function(i,snp)
  {
   return CodeSnippet.New$1(i+1,"",snp.parent,List.T.Empty,List.T.Empty,"");
  },function(o)
  {
   return o==null?null:{
    $:1,
    $0:m.apply(null,o.$0)
   };
  }(CodeSnippet.PickIO(CodeEditor.currentCodeSnippetId().c)))));
  a=CodeEditor.currentCodeSnippetId();
  a$1=n.id;
  Var.Set(a,a$1);
  CodeEditor.setDirty();
  CodeEditor.refreshView();
 };
 CodeEditor.listEntries=function(snps)
 {
  var c,x,s;
  return Doc.Concat((c=function(o)
  {
   var f;
   f=HtmlNode.renderDoc();
   return o==null?null:{
    $:1,
    $0:f(o.$0)
   };
  },function(s$1)
  {
   return Seq.choose(c,s$1);
  }((x=Seq.indexed(snps),(s=new FSharpSet.New(List.T.Empty),Seq.mapFold(function(expanded,t)
  {
   var i,snp,o,m,isParent,o$1,m$1,i$1,isExpanded;
   i=t[0];
   snp=t[1];
   return(o=(m=function(p)
   {
    return expanded.Contains(p);
   },function(o$2)
   {
    return o$2==null?null:{
     $:1,
     $0:m(o$2.$0)
    };
   }(snp.parent)),o==null?true:o.$0)?(isParent=(o$1=(m$1=function(nxt)
   {
    return Unchecked.Equals(nxt.parent,{
     $:1,
     $0:snp.id
    });
   },function(o$2)
   {
    return o$2==null?null:{
     $:1,
     $0:m$1(o$2.$0)
    };
   }((i$1=i+1,function(s$1)
   {
    return Seq.tryItem(i$1,s$1);
   }(CodeEditor.codeSnippets())))),o$1==null?false:o$1.$0),(isExpanded=isParent?snp.expanded:false,[{
    $:1,
    $0:CodeEditor.listEntry(isParent,isExpanded,snp)
   },isExpanded?expanded.Add(snp.id):expanded])):[null,expanded];
  },s,x)))[0])));
 };
 CodeEditor.listEntry=function(isParent,isExpanded,code)
 {
  var v,x,v$1,p,v$2,p$1,a,a$1,a$2,a$3,f,a$4,a$5;
  return Hoverable.get_New().Content([HtmlNode["class"]("code-editor-list-tile"),(v=Val.map((x=code.id,function(y)
  {
   return Unchecked.Equals(x,y);
  }),CodeEditor.currentCodeSnippetId()),HtmlNode.classIf("selected",v)),(v$1=Val.map((p=code.id,function(c)
  {
   return CodeEditor.isDirectPredecessor(p,c);
  }),CodeEditor.currentCodeSnippetO()),HtmlNode.classIf("direct-predecessor",v$1)),(v$2=Val.map((p$1=code.id,function(p$2)
  {
   return CodeEditor.isIndirectPredecessor(p$1,p$2);
  }),CodeEditor.curPredecessors()),HtmlNode.classIf("indirect-predecessor",v$2)),CodeEditor.draggable("true"),(a=AttrModule.Handler("dragover",function()
  {
   return function(ev)
   {
    return ev.preventDefault();
   };
  }),new HtmlNode$1({
   $:5,
   $0:a
  })),(a$1=AttrModule.Handler("drag",function()
  {
   return function()
   {
    return CodeEditor.set_draggedId(code.id);
   };
  }),new HtmlNode$1({
   $:5,
   $0:a$1
  })),(a$2=AttrModule.Handler("drop",function()
  {
   return function(ev)
   {
    ev.preventDefault();
    return CodeEditor.reorderSnippet(code.id,CodeEditor.draggedId());
   };
  }),new HtmlNode$1({
   $:5,
   $0:a$2
  })),HtmlNode.span([HtmlNode["class"]("node"),HtmlNode.classIf("parent",isParent),HtmlNode.classIf("expanded",isExpanded),(a$3=AttrModule.Handler("click",function()
  {
   return function()
   {
    return isParent?CodeEditor.toggleExpanded(code):null;
   };
  }),new HtmlNode$1({
   $:5,
   $0:a$3
  })),HtmlNode.title(isParent?isExpanded?"collapse":"expand":""),HtmlNode.htmlText(isParent?isExpanded?"v":">":"")]),HtmlNode.div([HtmlNode["class"]("code-editor-list-text"),HtmlNode.style1("text-indent",(f=function($1,$2)
  {
   return $1(Global.String($2)+"em");
  },(function($1)
  {
   return function($2)
   {
    return f($1,$2);
   };
  }(Global.id))(code.Level()))),HtmlNode.htmlText(Val.map2(function(n)
  {
   return function(c)
   {
    return CodeEditor.snippetName(n,c);
   };
  },CodeEditor.curSnippetNameOf(code.id),CodeEditor.curSnippetCodeOf(code.id))),(a$4=AttrModule.Handler("click",function()
  {
   return function()
   {
    var a$6,a$7;
    a$6=CodeEditor.currentCodeSnippetId();
    a$7=code.id;
    return Var.Set(a$6,a$7);
   };
  }),new HtmlNode$1({
   $:5,
   $0:a$4
  }))]),HtmlNode.span([HtmlNode["class"]("predecessor"),HtmlNode.title("toggle predecessor"),(a$5=AttrModule.Handler("click",function()
  {
   return function()
   {
    return Val.iter(function(c)
    {
     CodeEditor.togglePredecessorForCur(code,c);
    },CodeEditor.currentCodeSnippetO());
   };
  }),new HtmlNode$1({
   $:5,
   $0:a$5
  })),HtmlNode.htmlText("X")])]).get_Render();
 };
 CodeEditor.toggleExpanded=function(snp)
 {
  var a;
  a=snp.id;
  CodeEditor.codeSnippets().UpdateBy(function(c)
  {
   var e;
   return{
    $:1,
    $0:(e=!c.expanded,CodeSnippet.New(c.name,c.content,c.parent,c.predecessors,c.companions,c.id,e))
   };
  },a);
  CodeEditor.refreshView();
 };
 CodeEditor.togglePredecessorForCur=function(pre,curO)
 {
  var a;
  a=function(cur)
  {
   var preds,x,v,p,x$1,a$1;
   if(Unchecked.Equals(cur,pre)?true:CodeEditor.isIndirectPredecessor(cur.id,pre.UniquePredecesors()))
    ;
   else
    {
     preds=((x=cur.predecessors,(v=pre.id,List.contains(v,x)))?(p=(x$1=pre.id,function(y)
     {
      return!Unchecked.Equals(x$1,y);
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
     })(cur.predecessors);
     a$1=cur.id;
     CodeEditor.codeSnippets().UpdateBy(function(c)
     {
      return{
       $:1,
       $0:CodeSnippet.New(c.name,c.content,c.parent,preds,c.companions,c.id,c.expanded)
      };
     },a$1);
     CodeEditor.setDirty();
     CodeEditor.refreshView();
    }
  };
  (function(o)
  {
   if(o==null)
    ;
   else
    a(o.$0);
  }(curO));
 };
 CodeEditor.isIndirectPredecessor=function(pre,predecessors)
 {
  return List.contains(pre,predecessors);
 };
 CodeEditor.curPredecessors=function()
 {
  SC$1.$cctor();
  return SC$1.curPredecessors;
 };
 CodeEditor.isDirectPredecessor=function(pre,curO)
 {
  var o,m;
  o=(m=function(snp)
  {
   var s;
   s=snp.predecessors;
   return List.contains(pre,s);
  },function(o$1)
  {
   return o$1==null?null:{
    $:1,
    $0:m(o$1.$0)
   };
  }(curO));
  return o==null?false:o.$0;
 };
 CodeEditor.draggable=function(v)
 {
  return HtmlNode.htmlAttribute("draggable",v);
 };
 CodeEditor.draggedId=function()
 {
  SC$1.$cctor();
  return SC$1.draggedId;
 };
 CodeEditor.set_draggedId=function($1)
 {
  SC$1.$cctor();
  SC$1.draggedId=$1;
 };
 CodeEditor.indentCodeOut=function()
 {
  var a;
  a=function(snp)
  {
   var newP,b,o,a$1;
   newP=(b=function(p)
   {
    return p.parent;
   },function(o$1)
   {
    return o$1==null?null:b(o$1.$0);
   }((o=snp.parent,o==null?null:CodeSnippet.FetchO(o.$0))));
   a$1=snp.id;
   CodeEditor.codeSnippets().UpdateBy(function(c)
   {
    return{
     $:1,
     $0:CodeSnippet.New(c.name,c.content,newP,c.predecessors,c.companions,c.id,c.expanded)
    };
   },a$1);
   CodeEditor.setDirty();
   CodeEditor.refreshView();
  };
  (function(o)
  {
   if(o==null)
    ;
   else
    a(o.$0);
  }(CodeSnippet.FetchO(CodeEditor.currentCodeSnippetId().c)));
 };
 CodeEditor.indentCodeIn=function()
 {
  var a;
  a=function(j,snp)
  {
   var doPriorUntil,$1;
   doPriorUntil=function(f,i)
   {
    var x;
    while(true)
     {
      if(i<0)
       return null;
      else
       if(f((x=(CodeEditor.codeSnippets())["var"].RVal(),(function(i$1)
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
   };
   $1=function(pri)
   {
    var a$1;
    return Unchecked.Equals(pri.parent,snp.parent)?(a$1=snp.id,CodeEditor.codeSnippets().UpdateBy(function(c)
    {
     var p;
     return{
      $:1,
      $0:(p={
       $:1,
       $0:pri.id
      },CodeSnippet.New(c.name,c.content,p,c.predecessors,c.companions,c.id,c.expanded))
     };
    },a$1),true):false;
   };
   (function($2)
   {
    return doPriorUntil($1,$2);
   }(j-1));
   CodeEditor.setDirty();
   CodeEditor.refreshView();
  };
  (function(o)
  {
   if(o==null)
    ;
   else
    a.apply(null,o.$0);
  }(CodeSnippet.PickIO(CodeEditor.currentCodeSnippetId().c)));
 };
 CodeEditor.reorderSnippet=function(toId,fromId)
 {
  var p,p$1,others,moving,$1,$2,snp,ti,tsn,a,m,a$1;
  function trySnippet(id)
  {
   var f;
   f=function(a$2,snp$1)
   {
    return Unchecked.Equals(snp$1.id,id);
   };
   return function(s)
   {
    return CodeEditor.tryPickI(function($3)
    {
     return f($3[0],$3[1]);
    },s);
   };
  }
  p=(p$1=function(snp$1)
  {
   return Unchecked.Equals(snp$1.id,fromId)?true:snp$1.IsDescendantOf(fromId);
  },function(a$2)
  {
   return Arrays.partition(p$1,a$2);
  }(Arrays.ofSeq((CodeEditor.codeSnippets())["var"].RVal())));
  others=p[1];
  moving=p[0];
  $1=(trySnippet(fromId))(moving);
  $2=(trySnippet(toId))(others);
  ($1!=null?$1.$==1:false)?($2!=null?$2.$==1:false)?(snp=$1.$0[1],ti=$2.$0[0],tsn=$2.$0[1],a=(m=Global.id,function(a$2)
  {
   return Arrays.collect(m,a$2);
  }([Slice.array(others,{
   $:1,
   $0:0
  },{
   $:1,
   $0:ti-1
  }),moving,Slice.array(others,{
   $:1,
   $0:ti
  },null)])),CodeEditor.codeSnippets().Set(a),a$1=snp.id,CodeEditor.codeSnippets().UpdateBy(function(c)
  {
   var p$2;
   return{
    $:1,
    $0:(p$2=tsn.parent,CodeSnippet.New(c.name,c.content,p$2,c.predecessors,c.companions,c.id,c.expanded))
   };
  },a$1)):void 0:void 0;
  CodeEditor.setDirty();
  CodeEditor.refreshView();
 };
 CodeEditor.evaluateFS=function()
 {
  var c;
  CodeEditor.processSnippet("Evaluating F# code...",(c=function(vO,msgs)
  {
   var x;
   CodeEditor.sendMsg((x=msgs+"\n",function(y)
   {
    return x+y;
   }(vO==null?"":vO.$0)));
  },function(s)
  {
   EditorRpc.evaluate(function($1)
   {
    return c($1[0],$1[1]);
   },s);
  }));
 };
 CodeEditor.justCompile=function()
 {
  CodeEditor.compileSnippet(function($1)
  {
   CodeEditor.sendMsg("Compiled!");
   return CodeEditor.sendMsg($1);
  },function(m)
  {
   CodeEditor.sendMsg(m);
  });
 };
 CodeEditor.compileRun=function()
 {
  CodeEditor.compileSnippet(CodeEditor.runJS,function(m)
  {
   CodeEditor.sendMsg(m);
  });
 };
 CodeEditor.compileSnippet=function(fThen,fFail)
 {
  var f;
  CodeEditor.processSnippet("Compiling to JavaScript...",(f=function(msgs,js)
  {
   var a;
   a=CodeEditor.codeJS();
   Var.Set(a,js);
   return fThen(msgs,js);
  },function(c)
  {
   RunCode.compile(f,fFail,c);
  }));
 };
 CodeEditor.processSnippet=function(msg,processCode)
 {
  var a;
  a=function(snp)
  {
   var a$1,a$2,code,a$3;
   a$1=CodeEditor.codeMsgs();
   Var.Set(a$1,msg);
   a$2=CodeEditor.codeJS();
   Var.Set(a$2,"");
   code=snp.Code();
   a$3=CodeEditor.codeFS();
   Var.Set(a$3,code);
   processCode(code);
  };
  (function(o)
  {
   if(o==null)
    ;
   else
    a(o.$0);
  }(CodeSnippet.FetchO(CodeEditor.currentCodeSnippetId().c)));
 };
 CodeEditor.runJS=function(msgs,js)
 {
  var m;
  CodeEditor.sendMsg("Running JavaScript...");
  m=CodeEditor.position().c;
  (((m.$==3?Runtime.Curried3(CodeEditor.evalWindowJS):Runtime.Curried3(CodeEditor.evalIFrameJS))(function(res)
  {
   CodeEditor.sendMsg("Done!");
   CodeEditor.sendMsg(res);
   CodeEditor.sendMsg(msgs);
  }))(function(res)
  {
   CodeEditor.sendMsg("Failed!");
   CodeEditor.sendMsg(res);
   CodeEditor.sendMsg(msgs);
  }))(js);
 };
 CodeEditor.evalWindowJS=function(success,failure,js)
 {
  var window$1,x,v,f;
  window$1=(x=Global.window,x.open.apply(x,[Global.window.location.origin+"/Main.html"]));
  Unchecked.Equals(window$1,null)?failure("could not open new browser. Popup blocker may be active."):v=(f=function()
  {
   try
   {
    (function($1)
    {
     return $1("Evaluating...");
    }(function(s)
    {
     Global.console.log(s);
    }));
    window$1.focus.apply(window$1,[]);
    success(window$1["eval"].apply(window$1,[js]));
   }
   catch(e)
   {
    failure(Global.String(e));
   }
  },function(m)
  {
   return Global.setTimeout(f,m);
  }(600));
 };
 CodeEditor.evalIFrameJS=function(success,failure,js)
 {
  var x;
  x=HtmlNode.createIFrame(function(frame)
  {
   var window$1;
   try
   {
    window$1=frame.contentWindow;
    success(window$1["eval"].apply(window$1,[js]));
   }
   catch(e)
   {
    failure(Global.String(e));
   }
  });
  (new RunNode.New(null)).RunHtml(x);
 };
 CodeEditor.getFSCode=function()
 {
  var a;
  a=function(snp)
  {
   var a$1,a$2;
   a$1=CodeEditor.codeFS();
   a$2=snp.Code();
   Var.Set(a$1,a$2);
  };
  (function(o)
  {
   if(o==null)
    ;
   else
    a(o.$0);
  }(CodeSnippet.FetchO(CodeEditor.currentCodeSnippetId().c)));
 };
 CodeEditor.setClean=function()
 {
  var a;
  a=CodeEditor.dirty();
  Var.Set(a,false);
 };
 CodeEditor.setDirty=function()
 {
  var a;
  a=CodeEditor.dirty();
  Var.Set(a,true);
 };
 CodeEditor.sendMsg=function(msg)
 {
  var a,a$1,$1;
  a=CodeEditor.codeMsgs();
  a$1=($1=CodeEditor.codeMsgs().c,$1===null?msg:$1===""?msg:msg===null?$1:msg===""?$1:$1+"\n"+msg);
  Var.Set(a,a$1);
 };
 CodeEditor.codeMsgs=function()
 {
  SC$1.$cctor();
  return SC$1.codeMsgs;
 };
 CodeEditor.codeJS=function()
 {
  SC$1.$cctor();
  return SC$1.codeJS;
 };
 CodeEditor.codeFS=function()
 {
  SC$1.$cctor();
  return SC$1.codeFS;
 };
 CodeEditor.dirty=function()
 {
  SC$1.$cctor();
  return SC$1.dirty;
 };
 CodeEditor.noSelectionVal=function()
 {
  SC$1.$cctor();
  return SC$1.noSelectionVal;
 };
 CodeEditor.noSelection=function(cur)
 {
  return Unchecked.Equals(CodeSnippet.FetchO(cur),null);
 };
 CodeEditor.directionVertical=function()
 {
  SC$1.$cctor();
  return SC$1.directionVertical;
 };
 CodeEditor.position=function()
 {
  SC$1.$cctor();
  return SC$1.position;
 };
 CodeEditor.positionTxt=function(v)
 {
  return v.$==1?"Right":v.$==2?"In Tab":v.$==3?"New Browser":"Below";
 };
 CodeEditor.curSnippetCodeOf=function(k)
 {
  var f,l,a,a$1;
  f=function(a$2)
  {
   return CodeEditor.codeSnippets().TryFindByKey(a$2);
  };
  return(l=(a=function(s)
  {
   return s.content;
  },(a$1=function(s,n)
  {
   return CodeSnippet.New(s.name,n,s.parent,s.predecessors,s.companions,s.id,s.expanded);
  },function(a$2)
  {
   return CodeEditor.codeSnippets().LensInto(a,a$1,a$2);
  })),function(k$1)
  {
   return CodeEditor.missing(f,l,k$1);
  })(k);
 };
 CodeEditor.curSnippetNameOf=function(k)
 {
  var f,l,a,a$1;
  f=function(a$2)
  {
   return CodeEditor.codeSnippets().TryFindByKey(a$2);
  };
  return(l=(a=function(s)
  {
   return s.get_Name();
  },(a$1=function(s,n)
  {
   return CodeSnippet.New(n,s.content,s.parent,s.predecessors,s.companions,s.id,s.expanded);
  },function(a$2)
  {
   return CodeEditor.codeSnippets().LensInto(a,a$1,a$2);
  })),function(k$1)
  {
   return CodeEditor.missing(f,l,k$1);
  })(k);
 };
 CodeEditor.currentCodeSnippetO=function()
 {
  SC$1.$cctor();
  return SC$1.currentCodeSnippetO;
 };
 CodeEditor.refreshView=function()
 {
  var a;
  a=CodeEditor.refresh();
  Var.Set(a,null);
 };
 CodeEditor.refresh=function()
 {
  SC$1.$cctor();
  return SC$1.refresh;
 };
 CodeEditor.currentCodeSnippetId=function()
 {
  SC$1.$cctor();
  return SC$1.currentCodeSnippetId;
 };
 CodeEditor.missing=function(find,lens,k)
 {
  var m,a,a$1;
  m=find(k);
  return m==null?(a=function()
  {
   return"";
  },(a$1=CodeEditor.missingVar(),Var.Lens(a$1,function()
  {
   return"";
  },function($1,$2)
  {
   return a($1,$2);
  }))):lens(k);
 };
 CodeEditor.missingVar=function()
 {
  SC$1.$cctor();
  return SC$1.missingVar;
 };
 CodeEditor.tryPickI=function(f,s)
 {
  var s$1;
  return Seq.tryHead((s$1=Seq.indexed(s),Seq.filter(f,s$1)));
 };
 CodeEditor.codeSnippets=function()
 {
  SC$1.$cctor();
  return SC$1.codeSnippets;
 };
 CodeEditor.codeSnippetsStorage=function()
 {
  SC$1.$cctor();
  return SC$1.codeSnippetsStorage;
 };
 CodeEditor.snippetName=function(name,content)
 {
  var o,p,s;
  return name!==""?name:(o=Seq.tryHead((p=function(l)
  {
   return!((Strings.StartsWith(l,"#")?true:Strings.StartsWith(l,"[<"))?true:Strings.StartsWith(l,"//"));
  },function(s$1)
  {
   return Seq.filter(p,s$1);
  }((s=Strings.SplitChars(content,[10],1),Seq.map(Strings.Trim,s))))),o==null?"<empty>":o.$0);
 };
 SC$1.$cctor=Runtime.Cctor(function()
 {
  var g,v,g$1,m,a,f,m$1,g$2,v$1,a$1,a$2,f$1,f$2,f$3,o,n,n$1,n$2;
  SC$1.callAddClass=HtmlNode.addClass("a","b");
  SC$1.getClass=function(e)
  {
   return HtmlNode.getAttr("class",e);
  };
  SC$1.getStyle=function(e)
  {
   return HtmlNode.getAttr("style",e);
  };
  SC$1.renderDoc=(g=(v=Doc.Empty(),function(o$1)
  {
   return o$1==null?v:o$1.$0;
  }),function(x)
  {
   return g(HtmlNode.chooseNode(x));
  });
  SC$1.string2Styles=(g$1=(m=function(n$3,v$2)
  {
   var a$3;
   a$3=AttrModule.Style(n$3,v$2);
   return new HtmlNode$1({
    $:5,
    $0:a$3
   });
  },function(a$3)
  {
   return Arrays.map(function($1)
   {
    return m($1[0],$1[1]);
   },a$3);
  }),function(x)
  {
   return g$1(HtmlNode.style2pairs(x));
  });
  SC$1.codeMirrorIncludes=["/EPFileX/codemirror/scripts/codemirror/codemirror.js","/EPFileX/codemirror/scripts/codemirror/mode/fsharp.js","/EPFileX/codemirror/scripts/addon/search/searchcursor.js","/EPFileX/codemirror/scripts/addon/search/search.js","/EPFileX/codemirror/scripts/addon/search/jump-to-line.js","/EPFileX/codemirror/scripts/addon/dialog/dialog.js","/EPFileX/codemirror/scripts/addon/edit/matchbrackets.js","/EPFileX/codemirror/scripts/addon/selection/active-line.js","/EPFileX/codemirror/scripts/addon/display/fullscreen.js"];
  SC$1.codeSnippetsStorage=Storage.LocalStorage("CodeSnippets",{
   Encode:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j(),
   Decode:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j()
  });
  SC$1.codeSnippets=(a=CodeEditor.codeSnippetsStorage(),ListModel.CreateWithStorage(function(s)
  {
   return s.id;
  },a));
  SC$1.missingVar=Var.Create$1("");
  SC$1.currentCodeSnippetId=Var.Create$1(CodeSnippetId.get_New());
  SC$1.refresh=Var.Create$1();
  SC$1.currentCodeSnippetO=Val.map2(function(k)
  {
   return function()
   {
    return CodeEditor.codeSnippets().TryFindByKey(k);
   };
  },CodeEditor.currentCodeSnippetId(),CodeEditor.refresh());
  SC$1.position=Var.Create$1(Position.Below);
  SC$1.directionVertical=Val.map(function(pos)
  {
   return pos.$==1?true:false;
  },CodeEditor.position());
  SC$1.noSelectionVal=Val.map(CodeEditor.noSelection,CodeEditor.currentCodeSnippetId());
  SC$1.dirty=Var.Create$1(false);
  SC$1.codeFS=Var.Create$1("");
  SC$1.codeJS=Var.Create$1("");
  SC$1.codeMsgs=Var.Create$1("");
  Val.sink(function(m$2)
  {
   Global.window.onbeforeunload=m$2?function(e)
   {
    e.returnValue="Changes you made may not be saved.";
   }:null;
  },CodeEditor.dirty());
  SC$1.draggedId=CodeSnippetId.get_New();
  SC$1.curPredecessors=Val.map((f=(m$1=function(snp)
  {
   return snp.UniquePredecesors();
  },function(o$1)
  {
   return o$1==null?null:{
    $:1,
    $0:m$1(o$1.$0)
   };
  }),(g$2=(v$1=List.T.Empty,function(o$1)
  {
   return o$1==null?v$1:o$1.$0;
  }),function(x)
  {
   return g$2(f(x));
  })),CodeEditor.currentCodeSnippetO());
  SC$1.fileName=Var.Create$1("");
  SC$1.emptyFile=Val.map(function(v$2)
  {
   return v$2==="";
  },CodeEditor.fileName());
  SC$1.fileInputElementId="CodeEditorFileSel";
  SC$1.loadFileElement=Input.New$2((a$1=Global.id,(a$2=CodeEditor.fileName(),Var.Lens(a$2,CodeEditor.justFileName,function($1,$2)
  {
   return a$1($1,$2);
  })))).Prefix(HtmlNode.label([HtmlNode["class"]("btn btn-primary"),HtmlNode.htmlText("Load File..."),Input.New$2(CodeEditor.fileName()).Type("file").Style("display: none").Content([AttrModule.Handler("change",function(el)
  {
   return function()
   {
    return CodeEditor.loadFile(el);
   };
  }),AttrModule.Handler("click",function(el)
  {
   return function()
   {
    el.value="";
   };
  })]).Id(CodeEditor.fileInputElementId()).get_Render()]));
  SC$1.splitterV1=SplitterBar.get_New().Value(20).Node(HtmlNode.div([HtmlNode["class"]("sliderv"),HtmlNode.style("width : 5px; grid-column: 2  ; grid-row: 2/4; margin-left: -7px; border: 0px; padding: 0px;")]));
  SC$1.splitterV2=SplitterBar.get_New().Value(50).Max(Val.map(function(y)
  {
   return 92-y;
  },CodeEditor.splitterV1().get_GetValue())).Node(HtmlNode.div([HtmlNode["class"]("sliderv"),HtmlNode.style("width : 5px; grid-column: 3  ; grid-row: 3  ; margin-left: -7px; border: 0px; padding: 0px;")]));
  SC$1.splitterH3=SplitterBar.get_New().Value(17).Horizontal().get_Before().Node(HtmlNode.div([HtmlNode["class"]("sliderh"),HtmlNode.style("height: 5px; grid-column: 2/4; grid-row: 3  ; margin-top : -7px; border: 0px; padding: 0px;")]));
  SC$1.styleEditor=HtmlNode.htmlText(Val.map3(Runtime.Curried3(CodeEditor.styleEditorF),CodeEditor.splitterV1().get_GetValue(),CodeEditor.splitterV2().get_GetValue(),CodeEditor.splitterH3().get_GetValue()));
  SC$1.style1h="height : 5px; grid-column: 1/2  ; grid-row   : 2/3; margin-top : -7px; border: 0px; padding: 0px; background-color: #eef; cursor: row-resize";
  SC$1.style2h="height : 5px; grid-column: 1/2  ; grid-row   : 3/4; margin-top : -7px; border: 0px; padding: 0px; background-color: #eef; cursor: row-resize";
  SC$1.style1v="width  : 5px; grid-row   : 1/2  ; grid-column: 2/3; margin-left: -7px; border: 0px; padding: 0px; background-color: #eef; cursor: col-resize";
  SC$1.style2v="width  : 5px; grid-row   : 1/2  ; grid-column: 3/4; margin-left: -7px; border: 0px; padding: 0px; background-color: #eef; cursor: col-resize";
  SC$1.horizontalSplit=Runtime.Curried(function($1,$2,$3,$4)
  {
   return $1("\r\n    body {\r\n        display              : grid;\r\n        grid-template-rows   : "+$2.toFixed(6)+"% "+$3.toFixed(6)+"% "+$4.toFixed(6)+"%;\r\n        grid-template-columns: 100%;\r\n        grid-gap             :   9px;   \r\n        height               : 100vh;\r\n        overflow             : hidden;\r\n    }\r\n    \r\n#CodeEditor              { grid-row   : 2; overflow: hidden; }\r\n#TestNode                { grid-row   : 3; overflow: auto  ; }\r\n    body > div:first-of-type { grid-row   : 1; overflow: hidden; }\r\n    body > div               { grid-column: 1;                   }\r\n                                   ");
  },4);
  SC$1.verticalSplit=Runtime.Curried(function($1,$2,$3,$4)
  {
   return $1("\r\n    body {\r\n        display              : grid;\r\n        grid-template-columns: "+$2.toFixed(6)+"% "+$3.toFixed(6)+"% "+$4.toFixed(6)+"%;\r\n        grid-template-rows   : 100%;\r\n        grid-gap             :   9px;   \r\n        height               : 100vh;\r\n        overflow             : hidden;\r\n    }\r\n    \r\n#CodeEditor              { grid-column: 2; overflow: hidden; }\r\n#TestNode                { grid-column: 3; overflow: auto  ; }\r\n    body > div:first-of-type { grid-column: 1; overflow: hidden; }\r\n    body > div               { grid-row   : 1;                   }\r\n                                   ");
  },4);
  SC$1.style1=(f$1=function(dir)
  {
   return dir?CodeEditor.style1v():CodeEditor.style1h();
  },function(v$2)
  {
   return Val.map(f$1,v$2);
  }(CodeEditor.directionVertical()));
  SC$1.style2=(f$2=function(dir)
  {
   return dir?CodeEditor.style2v():CodeEditor.style2h();
  },function(v$2)
  {
   return Val.map(f$2,v$2);
  }(CodeEditor.directionVertical()));
  SC$1.styleSplit=(f$3=function(dir)
  {
   return dir?CodeEditor.verticalSplit():CodeEditor.horizontalSplit();
  },function(v$2)
  {
   return Val.map(f$3,v$2);
  }(CodeEditor.directionVertical()));
  SC$1.splitterMain1=SplitterBar.get_New().Value(0).Vertical$1(CodeEditor.directionVertical()).Min(0).Max(35).Node(HtmlNode.div([HtmlNode.style(CodeEditor.style1())]));
  SC$1.splitterMain2=SplitterBar.get_New().Value(24).Vertical$1(CodeEditor.directionVertical()).Min(0.5).Max(Val.map(function(pos)
  {
   return pos.$===3?0.1:50;
  },CodeEditor.position())).get_Before().Node(HtmlNode.div([HtmlNode.style(CodeEditor.style2())]));
  SC$1.pageStyle=Val.map3(Runtime.Curried3(function(fmt,v1,v2)
  {
   return(((fmt(Global.id))(v1))(98-v1-v2))(v2);
  }),CodeEditor.styleSplit(),CodeEditor.splitterMain1().get_GetValue(),CodeEditor.splitterMain2().get_GetValue());
  o=(new RunNode.New$1("CodeEditor",null)).get_AddBootstrap();
  o.RunHtml(CodeEditor.CodeEditor());
  n=HtmlNode.styleH([HtmlNode.htmlText(CodeEditor.pageStyle())]);
  CodeEditor.addNodeById("pageStyle",n);
  n$1=CodeEditor.splitterMain1().get_Render();
  CodeEditor.addNodeById("splitterMain1",n$1);
  n$2=CodeEditor.splitterMain2().get_Render();
  CodeEditor.addNodeById("splitterMain2",n$2);
  SC$1.$cctor=Global.ignore;
 });
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$1=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$1?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$1:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v$1=(Provider.EncodeUnion(void 0,"$",[[0,[["$0","Item",Provider.Id(),0]]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder._v=(Provider.EncodeRecord(CodeSnippet,[["name",Provider.Id(),0],["content",Provider.Id(),0],["parent",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$1,1],["predecessors",Provider.EncodeList(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$1),0],["companions",Provider.EncodeList(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$1),0],["id",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonEncoder.j$1,0],["expanded",Provider.Id(),0]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$1=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$1?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$1:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v$1=(Provider.DecodeUnion(void 0,"$",[[0,[["$0","Item",Provider.Id(),0]]]]))();
 };
 _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j=function()
 {
  return _DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v?_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v:_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder._v=(Provider.DecodeRecord(CodeSnippet,[["name",Provider.Id(),0],["content",Provider.Id(),0],["parent",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$1,1],["predecessors",Provider.DecodeList(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$1),0],["companions",Provider.DecodeList(_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$1),0],["id",_DAbeCIPHERWorkspaceCIPHERPrototypeWebServerbinproject$xxx_JsonDecoder.j$1,0],["expanded",Provider.Id(),0]]))();
 };
});