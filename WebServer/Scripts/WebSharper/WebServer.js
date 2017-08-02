(function()
{
 "use strict";
 var CIPHERPrototype,RemoteError,LoginForm,Model,Message,LoginUINext,CodeMirror,EditorRpc,TestFormModule,Button,WebServer,Client,WebServer_Templates,IntelliFactory,Runtime,WebSharper,PrintfHelpers,App,App$1,List,Rop,Result,Wrap,CIPHERHtml,Remoting,AjaxRemotingProvider,Seq,UI,Next,Var,Doc,View,AttrModule,Concurrency,Val,Html,AttrProxy,ListModel,$;
 CIPHERPrototype=window.CIPHERPrototype=window.CIPHERPrototype||{};
 RemoteError=CIPHERPrototype.RemoteError=CIPHERPrototype.RemoteError||{};
 LoginForm=CIPHERPrototype.LoginForm=CIPHERPrototype.LoginForm||{};
 Model=LoginForm.Model=LoginForm.Model||{};
 Message=LoginForm.Message=LoginForm.Message||{};
 LoginUINext=CIPHERPrototype.LoginUINext=CIPHERPrototype.LoginUINext||{};
 CodeMirror=CIPHERPrototype.CodeMirror=CIPHERPrototype.CodeMirror||{};
 EditorRpc=CIPHERPrototype.EditorRpc=CIPHERPrototype.EditorRpc||{};
 TestFormModule=CIPHERPrototype.TestFormModule=CIPHERPrototype.TestFormModule||{};
 Button=TestFormModule.Button=TestFormModule.Button||{};
 WebServer=CIPHERPrototype.WebServer=CIPHERPrototype.WebServer||{};
 Client=WebServer.Client=WebServer.Client||{};
 WebServer_Templates=window.WebServer_Templates=window.WebServer_Templates||{};
 IntelliFactory=window.IntelliFactory;
 Runtime=IntelliFactory&&IntelliFactory.Runtime;
 WebSharper=window.WebSharper;
 PrintfHelpers=WebSharper&&WebSharper.PrintfHelpers;
 App=CIPHERPrototype&&CIPHERPrototype.App;
 App$1=App&&App.App;
 List=WebSharper&&WebSharper.List;
 Rop=window.Rop;
 Result=Rop&&Rop.Result;
 Wrap=Rop&&Rop.Wrap;
 CIPHERHtml=CIPHERPrototype&&CIPHERPrototype.CIPHERHtml;
 Remoting=WebSharper&&WebSharper.Remoting;
 AjaxRemotingProvider=Remoting&&Remoting.AjaxRemotingProvider;
 Seq=WebSharper&&WebSharper.Seq;
 UI=WebSharper&&WebSharper.UI;
 Next=UI&&UI.Next;
 Var=Next&&Next.Var;
 Doc=Next&&Next.Doc;
 View=Next&&Next.View;
 AttrModule=Next&&Next.AttrModule;
 Concurrency=WebSharper&&WebSharper.Concurrency;
 Val=CIPHERPrototype&&CIPHERPrototype.Val;
 Html=Val&&Val.Html;
 AttrProxy=Next&&Next.AttrProxy;
 ListModel=Next&&Next.ListModel;
 $=window.jQuery;
 RemoteError=CIPHERPrototype.RemoteError=Runtime.Class({
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
     return $1("Login Failed "+PrintfHelpers.toSafe($2));
    };
   }(window.id))(this.$0);
  }
 },null,RemoteError);
 Model.New=function(userName,password,inProgress,goLink,error)
 {
  return{
   userName:userName,
   password:password,
   inProgress:inProgress,
   goLink:goLink,
   error:error
  };
 };
 Message.Submit={
  $:2
 };
 LoginForm.showForm=function(goLink,error)
 {
  return App.withContainerDo("",function(node)
  {
   (new App$1.New$1(LoginForm.init(goLink,error),LoginForm.update,Runtime.Curried3(LoginForm.view))).run(App.DummyNew(),node);
  });
 };
 LoginForm.view=function(props,model,processMessages)
 {
  var checkResult,c,f,disabledClass,form,x,x$1,f$1,f$2,f$3,g,g$1,x$2,f$4,f$5,f$6,g$2,g$3,x$3,m;
  checkResult=(c=(f=function(ms)
  {
   processMessages({
    $:3,
    $0:List.head(ms).Rop_ErrMsg$get_ErrMsg()
   });
  },function(a)
  {
   Result.withError(f,a);
  }),function(w)
  {
   Wrap.getResult(c,w);
  });
  disabledClass=model.inProgress?" disabled":"";
  form=(x=CIPHERHtml.Form([(x$1=CIPHERHtml.Input([CIPHERHtml.Type("text"),CIPHERHtml.Class("form-control"+disabledClass),CIPHERHtml.Placeholder("User Name"),CIPHERHtml.Value(model.userName),CIPHERHtml.Disabled(model.inProgress)]),(CIPHERHtml.OnChange((f$1=(f$2=(f$3=function(o)
  {
   return o.target;
  },(g=function(o)
  {
   return o.value;
  },function(x$4)
  {
   return g(f$3(x$4));
  })),(g$1=function(a)
  {
   return{
    $:0,
    $0:a
   };
  },function(x$4)
  {
   return g$1(f$2(x$4));
  })),function(x$4)
  {
   return processMessages(f$1(x$4));
  })))(x$1)),CIPHERHtml.Br([]),(x$2=CIPHERHtml.Input([CIPHERHtml.Type("password"),CIPHERHtml.Class("form-control"+disabledClass),CIPHERHtml.Placeholder("Password"),CIPHERHtml.Value(model.password),CIPHERHtml.Disabled(model.inProgress)]),(CIPHERHtml.OnChange((f$4=(f$5=(f$6=function(o)
  {
   return o.target;
  },(g$2=function(o)
  {
   return o.value;
  },function(x$4)
  {
   return g$2(f$6(x$4));
  })),(g$3=function(a)
  {
   return{
    $:1,
    $0:a
   };
  },function(x$4)
  {
   return g$3(f$5(x$4));
  })),function(x$4)
  {
   return processMessages(f$4(x$4));
  })))(x$2)),CIPHERHtml.Br([]),CIPHERHtml.Button([CIPHERHtml.Type("submit"),CIPHERHtml.Class("btn btn-primary btn-block"+disabledClass),{
   $:1,
   $0:"Login"
  }]),CIPHERHtml.Div([CIPHERHtml.Class("flex-row"),CIPHERHtml.Div([CIPHERHtml.Class("flexgrow"),CIPHERHtml.Hr([])]),CIPHERHtml.Div([CIPHERHtml.Class("flexgrow-1-5 text-center"),CIPHERHtml.H5([{
   $:1,
   $0:"or"
  }])]),CIPHERHtml.Div([CIPHERHtml.Class("flexgrow"),CIPHERHtml.Hr([])])]),(x$3=CIPHERHtml.Button([CIPHERHtml.Type("button"),CIPHERHtml.Class("btn btn-info btn-block"+disabledClass),{
   $:1,
   $0:"Enter as Guest"
  }]),(CIPHERHtml.OnClick(function()
  {
   var b;
   processMessages(Message.Submit);
   checkResult((b=Wrap.wrapper(),b.Delay(function()
   {
    return b.Bind$3({
     $:2,
     $0:(new AjaxRemotingProvider.New()).Async("WebServer:CIPHERPrototype.RemoteLogin.guestLoginAR_:1736357544",[])
    },function()
    {
     window.location.href=model.goLink;
     return b.Zero();
    });
   })));
  }))(x$3)),CIPHERHtml.Br([]),CIPHERHtml.Div(List.ofSeq(Seq.delay(function()
  {
   return Seq.append([CIPHERHtml.Class("text-center")],Seq.delay(function()
   {
    return model.inProgress?[CIPHERHtml.Img([CIPHERHtml.Src("/EPFileX/image/loader.gif")])]:[];
   }));
  }))),CIPHERHtml.Div((m=model.error,m==null?List.T.Empty:List.ofArray([CIPHERHtml.Class("alert alert-danger"),{
   $:1,
   $0:m.$0
  }])))]),(CIPHERHtml.OnSubmit(function(e)
  {
   var b;
   e.preventDefault();
   processMessages(Message.Submit);
   checkResult((b=Wrap.wrapper(),b.Delay(function()
   {
    return b.Bind$3({
     $:2,
     $0:(new AjaxRemotingProvider.New()).Async("WebServer:CIPHERPrototype.RemoteLogin.LoginAR_:479691151",[model.userName,model.password])
    },function()
    {
     window.location.href=model.goLink;
     return b.Zero();
    });
   })));
  }))(x));
  return CIPHERHtml.Div([CIPHERHtml.Class("flex-row flex-align-center flexgrow"),CIPHERHtml.Div([CIPHERHtml.Class("blur"),CIPHERHtml._Style([CIPHERHtml._position("absolute"),CIPHERHtml._top("0Px"),CIPHERHtml._left("0Px"),CIPHERHtml._bottom("0Px"),CIPHERHtml._right("0Px"),CIPHERHtml.newAttr("backgroundImage","url('/EPFileX/image/BI_CONSULTANCY.jpg')"),CIPHERHtml.newAttr("backgroundSize","cover"),CIPHERHtml.newAttr("backgroundPosition","center center")])]),CIPHERHtml.Div([CIPHERHtml.Class("container"),CIPHERHtml.Div([CIPHERHtml.Class("row"),CIPHERHtml.Div([CIPHERHtml.Class("col-xs-10 col-xs-offset-1 col-md-6 col-md-offset-3"),CIPHERHtml.Div([CIPHERHtml.Class("panel panel-default shadow"),CIPHERHtml.Div([CIPHERHtml.Class("panel-body"),CIPHERHtml.Div([CIPHERHtml._Style([CIPHERHtml._textAlign("center")]),CIPHERHtml.Img([{
   $:2,
   $0:"alt",
   $1:"Brand"
  },CIPHERHtml.Src("/EPFileX/image/LOGO_cipher2.png"),CIPHERHtml._Style([CIPHERHtml._width("200px")])]),form])])])])])])]);
 };
 LoginForm.update=function(props,msg,model)
 {
  return msg.$==1?Model.New(model.userName,msg.$0,model.inProgress,model.goLink,null):msg.$==2?Model.New(model.userName,model.password,true,model.goLink,model.error):msg.$==3?Model.New(model.userName,model.password,false,model.goLink,{
   $:1,
   $0:msg.$0
  }):Model.New(msg.$0,model.password,model.inProgress,model.goLink,null);
 };
 LoginForm.init=function(goLink,error)
 {
  return Model.New("","",false,goLink,error);
 };
 LoginUINext.showForm=function(goLink)
 {
  var email,pwd,msg,processing,processAction,f,$1,f$1,$2,t;
  email=Var.Create$1("");
  pwd=Var.Create$1("");
  msg=Var.Create$1("");
  processing=Var.Create$1(false);
  processAction=function(action)
  {
   var b;
   return Wrap.getResult(function(r)
   {
    Var.Set(processing,false);
    Result.withError(function(ms)
    {
     Var.Set(msg,List.head(ms).Rop_ErrMsg$get_ErrMsg());
    },r);
   },(b=Wrap.wrapper(),b.Delay(function()
   {
    Var.Set(msg,"");
    Var.Set(processing,true);
    return b.Bind$3({
     $:2,
     $0:action()
    },function()
    {
     window.location.href=goLink;
     return b.Zero();
    });
   })));
  };
  return WebServer_Templates.loginformcipher(new List.T({
   $:1,
   $0:{
    $:4,
    $0:"clickguest",
    $1:(f=($1=function()
    {
     return(new AjaxRemotingProvider.New()).Async("WebServer:CIPHERPrototype.RemoteLogin.guestLoginAR_:1736357544",[]);
    },function($3)
    {
     return processAction($1,$3);
    }),function()
    {
     return function()
     {
      return f();
     };
    })
   },
   $1:new List.T({
    $:1,
    $0:{
     $:4,
     $0:"clicksubmit",
     $1:(f$1=($2=function()
     {
      return(new AjaxRemotingProvider.New()).Async("WebServer:CIPHERPrototype.RemoteLogin.LoginAR_:479691151",[email.c,pwd.c]);
     },function($3)
     {
      return processAction($2,$3);
     }),function()
     {
      return function()
      {
       return f$1();
      };
     })
    },
    $1:(t=new List.T({
     $:1,
     $0:{
      $:0,
      $0:"htmlmessage",
      $1:Doc.EmbedView(View.Map2(function(p,m)
      {
       return p?WebServer_Templates.hourglass(List.T.Empty):m===""?Doc.Empty():WebServer_Templates.alert(new List.T({
        $:1,
        $0:{
         $:2,
         $0:"text",
         $1:msg.v
        },
        $1:List.T.Empty
       }));
      },processing.v,msg.v))
     },
     $1:new List.T({
      $:1,
      $0:{
       $:6,
       $0:"varpassword",
       $1:pwd
      },
      $1:new List.T({
       $:1,
       $0:{
        $:6,
        $0:"varemail",
        $1:email
       },
       $1:List.T.Empty
      })
     })
    }),new List.T({
     $:1,
     $0:{
      $:3,
      $0:"attrdisabled",
      $1:AttrModule.DynamicPred("disabled",processing.v,View.Const("disabled"))
     },
     $1:t
    }))
   })
  }));
 };
 CodeMirror=CIPHERPrototype.CodeMirror=Runtime.Class({},null,CodeMirror);
 CodeMirror.New=Runtime.Ctor(function()
 {
 },CodeMirror);
 EditorRpc.translateClient=function(source,minified,callback)
 {
  EditorRpc.callRPC((new AjaxRemotingProvider.New()).Async("ZafirTranspiler:CIPHERPrototype.Editor.translate:796244877",[source,minified]),callback);
 };
 EditorRpc.declarationsClient=function(source,line,col,callback)
 {
  EditorRpc.callRPC((new AjaxRemotingProvider.New()).Async("ZafirTranspiler:CIPHERPrototype.Editor.declarations:-2117802712",[source,line,col]),callback);
 };
 EditorRpc.methodsClient=function(source,line,col,callback)
 {
  EditorRpc.callRPC((new AjaxRemotingProvider.New()).Async("ZafirTranspiler:CIPHERPrototype.Editor.methods:-34435681",[source,line,col]),callback);
 };
 EditorRpc.checkSourceClient=function(source,callback)
 {
  EditorRpc.callRPC((new AjaxRemotingProvider.New()).Async("ZafirTranspiler:CIPHERPrototype.Editor.checkSource:2013062947",[source]),callback);
 };
 EditorRpc.callRPC=function(asy,callback)
 {
  var b;
  Concurrency.Start((b=null,Concurrency.Delay(function()
  {
   return Concurrency.Bind(asy,function(a)
   {
    callback(a);
    return Concurrency.Zero();
   });
  })),null);
 };
 Button=TestFormModule.Button=Runtime.Class({
  OnClick:function(f)
  {
   return Button.New(this._class,this._type,this.style,this.text,f,this.disabled);
  },
  Disabled:function(dis)
  {
   return Button.New(this._class,this._type,this.style,this.text,this.onClick,Val.fixit2(dis));
  },
  Text:function(txt)
  {
   return Button.New(this._class,this._type,this.style,Val.fixit2(txt),this.onClick,this.disabled);
  },
  Style:function(sty)
  {
   return Button.New(this._class,this._type,Val.fixit2(sty),this.text,this.onClick,this.disabled);
  },
  Type:function(typ)
  {
   return Button.New(this._class,Val.fixit2(typ),this.style,this.text,this.onClick,this.disabled);
  },
  Class:function(clas)
  {
   return Button.New(Val.fixit2(clas),this._type,this.style,this.text,this.onClick,this.disabled);
  },
  get_Render:function()
  {
   var view;
   return Html.button([Html.type(this._type),Html["class"](this._class),Html.style(this.style),{
    $:5,
    $0:(view=View.Const(""),AttrModule.DynamicPred("disabled",Val.toView(this.disabled),view))
   },{
    $:5,
    $0:AttrProxy.Handler("click",this.onClick)
   },{
    $:2,
    $0:this.text
   }]);
  }
 },null,Button);
 Button.New$1=function(txt)
 {
  return Button.New(Val.fixit2("btn"),Val.fixit2("button"),Val.fixit2(""),Val.fixit2(txt),function()
  {
   return function()
   {
    return null;
   };
  },Val.fixit2(false));
 };
 Button.New=function(_class,_type,style,text,onClick,disabled)
 {
  return new Button({
   _class:_class,
   _type:_type,
   style:style,
   text:text,
   onClick:onClick,
   disabled:disabled
  });
 };
 TestFormModule.showForm=function(staticHtml)
 {
  var t;
  return WebServer_Templates.t((t=new List.T({
   $:1,
   $0:{
    $:1,
    $0:"title",
    $1:"Test Form"
   },
   $1:List.T.Empty
  }),new List.T({
   $:1,
   $0:{
    $:0,
    $0:"body",
    $1:Doc.Concat(List.ofArray([Doc.Verbatim(staticHtml),Doc.Element("script",[AttrProxy.Create("src","/EPFileX/CIPHERSpaceLoadFiles.js")],[]),TestFormModule.dynamicSection()]))
   },
   $1:t
  })));
 };
 TestFormModule.dynamicSection=function()
 {
  var completeJS,compile,freeHtml,freeCSS,freeFS,freeJS,freeMsgs,sendMsg,runJS,runFS,x;
  completeJS=function(js)
  {
   return"\r\n            CIPHERSpaceLoadFileGlobalFileRef = null;\r\n            CIPHERSpaceLoadFile = function (filename, callback) {\r\n                if (filename.slice(-3) == \".js\" || filename.slice(-4) == \".fsx\" || filename.slice(-3) == \".fs\") { //if filename is a external JavaScript file\r\n                    var fileRef = null;\r\n                    var pre = document.querySelector('script[src=\"' + filename + '\"]')\r\n                    if (!pre) {\r\n                        fileRef = document.createElement('script')\r\n                        fileRef.setAttribute(\"type\", \"text/javascript\")\r\n                        fileRef.setAttribute(\"src\", filename)\r\n                    }\r\n                    else callback();\r\n                }\r\n                else if (filename.slice(-4) == \".css\") { //if filename is an external CSS file\r\n                    var pre = document.querySelector('script[src=\"' + filename + '\"]')\r\n                    if (!pre) {\r\n                        fileRef = document.createElement(\"link\")\r\n                        fileRef.setAttribute(\"rel\", \"stylesheet\")\r\n                        fileRef.setAttribute(\"type\", \"text/css\")\r\n                        fileRef.setAttribute(\"href\", filename)\r\n                    }\r\n                    else callback();\r\n                }\r\n                else if (filename.slice(-5) == \".html\") { //if filename is an external HTML file\r\n                    var pre = document.querySelector('script[src=\"' + filename + '\"]')\r\n                    if (!pre) {\r\n                        fileRef = document.createElement(\"link\")\r\n                        fileRef.setAttribute(\"rel\", \"import\")\r\n                        fileRef.setAttribute(\"type\", \"text/html\")\r\n                        fileRef.setAttribute(\"href\", filename)\r\n                    }\r\n                    else callback();\r\n                }\r\n                if (!!fileRef) {\r\n                    CIPHERSpaceLoadFileGlobalFileRef = fileRef;\r\n        \u0009\u0009\u0009fileRef.onload = function () { fileRef.onload = null;  callback(); }\r\n                    document.getElementsByTagName(\"head\")[0].appendChild(fileRef);\r\n                }\r\n            }\r\n            CIPHERSpaceLoadFiles = function (files, callback) {\r\n                var newCallback = callback\r\n                if (!!CIPHERSpaceLoadFileGlobalFileRef && !!(CIPHERSpaceLoadFileGlobalFileRef.onload)) {\r\n                    var oldCallback = CIPHERSpaceLoadFileGlobalFileRef.onload;\r\n                    CIPHERSpaceLoadFileGlobalFileRef.onload = null;\r\n                    newCallback = function () {\r\n                        callback();\r\n                        oldCallback();\r\n                    }\r\n                }\r\n                var i = 0;\r\n                loadNext = function () {\r\n                    if (i < files.length) {\r\n                        var file = files[i];\r\n                        i++;\r\n                        CIPHERSpaceLoadFile(file, loadNext);\r\n                    }\r\n                    else newCallback();\r\n                };\r\n                loadNext();\r\n        \u0009}\r\n            CIPHERSpaceLoadFiles(['https://code.jquery.com/jquery-3.1.1.min.js'], function() {}); \r\n        \u0009CIPHERSpaceLoadFilesDoAfter = function (callback) {\r\n        \u0009\u0009var newCallback = callback\r\n        \u0009\u0009if (!!CIPHERSpaceLoadFileGlobalFileRef) {\r\n        \u0009\u0009\u0009if (!!(CIPHERSpaceLoadFileGlobalFileRef.onload)) {\r\n        \u0009\u0009\u0009\u0009var oldCallback = CIPHERSpaceLoadFileGlobalFileRef.onload;\r\n        \u0009\u0009\u0009\u0009CIPHERSpaceLoadFileGlobalFileRef.onload = null;\r\n        \u0009\u0009\u0009\u0009newCallback = function () {\r\n        \u0009\u0009\u0009\u0009\u0009oldCallback();\r\n        \u0009\u0009\u0009\u0009\u0009callback();\r\n        \u0009\u0009\u0009\u0009}\r\n        \u0009\u0009\u0009}\r\n        \u0009\u0009}\r\n        \u0009\u0009else CIPHERSpaceLoadFileGlobalFileRef = {};\r\n        \u0009\u0009CIPHERSpaceLoadFileGlobalFileRef.onload = newCallback;\r\n        \u0009}\r\n        \r\n        CIPHERSpaceLoadFilesDoAfter(function() { \r\n          if (typeof IntelliFactory !=='undefined')\r\n            IntelliFactory.Runtime.Start();\r\n          for (key in window) { \r\n            if (key.startsWith(\"StartupCode$\")) \r\n              try { window[key].$cctor(); } catch (e) {} \r\n          } \r\n        })\r\n                         "+js;
  };
  compile=function(fThen,fFail,code)
  {
   var c;
   c=function($1,msgs)
   {
    var a;
    a=$1==null?null:{
     $:1,
     $0:completeJS($1.$0)
    };
    a==null?fFail(msgs):(fThen(msgs))(a.$0);
   };
   return EditorRpc.translateClient(code,false,function($1)
   {
    return c($1[0],$1[1]);
   });
  };
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
   compile(function(msgs)
   {
    return function(js)
    {
     sendMsg(msgs);
     Var.Set(freeJS,js);
     return runJS();
    };
   },sendMsg,freeFS.c);
  };
  x=Html.div([Html.style("height: 100%"),Button.New$1("Eval F#").Style("vertical-align:top").OnClick(function()
  {
   return function()
   {
    return runFS();
   };
  }).get_Render(),Html.someElt(Doc.InputArea([AttrProxy.Create("placeholder","F#:"),AttrProxy.Create("title","Add F# code and invoke with Eval F#"),AttrProxy.Create("spellcheck","false")],freeFS)),Html.someElt(Doc.InputArea([AttrProxy.Create("placeholder","HTML:"),AttrProxy.Create("title","Enter HTML tags and text"),AttrProxy.Create("spellcheck","false")],freeHtml)),Html.someElt(Doc.InputArea([AttrProxy.Create("placeholder","CSS:"),AttrProxy.Create("title","Test your CSS styles dynamically"),AttrProxy.Create("spellcheck","false")],freeCSS)),Html.someElt(Doc.InputArea([AttrProxy.Create("placeholder","JavaScript:"),AttrProxy.Create("title","Add JS code and invoke with Eval JS"),AttrProxy.Create("spellcheck","false")],freeJS)),Button.New$1("Eval JS").Style("vertical-align:top").OnClick(function()
  {
   return function()
   {
    Var.Set(freeMsgs,"");
    return runJS();
   };
  }).get_Render(),Html.someElt(Doc.InputArea([AttrProxy.Create("placeholder","Output:"),AttrProxy.Create("title","Messages")],freeMsgs)),{
   $:4,
   $0:Val.tag(Doc.Verbatim,Val.map2((Runtime.Curried3(function($1,$2,$3)
   {
    return $1(PrintfHelpers.toSafe($2)+"<style>"+PrintfHelpers.toSafe($3)+"</style>");
   }))(window.id),freeHtml,freeCSS))
  }]);
  return(Html.renderDoc())(x);
 };
 Client.myDocument=function()
 {
  var people,removeText,freeHtml,addPersonName,addPersonAge,viewAddPerson,t,a,a$1;
  people=ListModel.Create(function(t$1)
  {
   return t$1[0];
  },List.ofArray([["John",42],["Phil",37]]));
  removeText=Var.Create$1("delete");
  freeHtml=Var.Create$1("<h1>Hello</h1>");
  addPersonName=Var.Create$1("");
  addPersonAge=Var.Create$1(0);
  viewAddPerson=View.Map2(function(n,a$2)
  {
   return[n,a$2];
  },addPersonName.v,addPersonAge.v);
  return WebServer_Templates.t$1(new List.T({
   $:1,
   $0:{
    $:0,
    $0:"htmlfreehtml",
    $1:Doc.EmbedView(View.Map(Doc.Verbatim,freeHtml.v))
   },
   $1:new List.T({
    $:1,
    $0:{
     $:6,
     $0:"varfreehtml",
     $1:freeHtml
    },
    $1:new List.T({
     $:1,
     $0:{
      $:6,
      $0:"varremovetext",
      $1:removeText
     },
     $1:(t=new List.T({
      $:1,
      $0:{
       $:11,
       $0:"varaddpersonage",
       $1:addPersonAge
      },
      $1:new List.T({
       $:1,
       $0:{
        $:6,
        $0:"varaddpersonname",
        $1:addPersonName
       },
       $1:new List.T({
        $:1,
        $0:{
         $:0,
         $0:"tablebody",
         $1:(a=function(name,age)
         {
          var f;
          return WebServer_Templates.tablerow3(new List.T({
           $:1,
           $0:{
            $:4,
            $0:"onremove",
            $1:(f=function()
            {
             people.RemoveByKey(name);
            },function()
            {
             return function()
             {
              return f();
             };
            })
           },
           $1:new List.T({
            $:1,
            $0:{
             $:2,
             $0:"txtborrar",
             $1:removeText.v
            },
            $1:new List.T({
             $:1,
             $0:{
              $:1,
              $0:"txtage",
              $1:window.String(age)
             },
             $1:new List.T({
              $:1,
              $0:{
               $:1,
               $0:"txtname",
               $1:name
              },
              $1:List.T.Empty
             })
            })
           })
          }));
         },Doc.ConvertBy(people.key,function($1)
         {
          return a($1[0],$1[1]);
         },people.v))
        },
        $1:List.T.Empty
       })
      })
     }),new List.T({
      $:1,
      $0:{
       $:3,
       $0:"attraddpersonsubmit",
       $1:(a$1=function(a$2,a$3,person)
       {
        return people.Append(person);
       },AttrModule.HandlerView("click",viewAddPerson,Runtime.Curried3(a$1)))
      },
      $1:t
     }))
    })
   })
  }));
 };
 Client.test=function()
 {
  return Doc.Element("div",[],[Doc.EmbedView(View.Map(function(x)
  {
   return x?Doc.Concat([Doc.Element("hr",[],[]),Doc.TextNode("ok")]):Doc.Empty();
  },Var.Create$1(true).v))]);
 };
 WebServer_Templates.loginformcipher=function(h)
 {
  var n;
  n={
   $:1,
   $0:"loginformcipher"
  };
  WebServer_Templates.blurred();
  WebServer_Templates.button();
  WebServer_Templates.input2();
  WebServer_Templates.loginpane2();
  return h?Doc.GetOrLoadTemplate("mypage",n,function()
  {
   return $.parseHTML("<div style=\"position:relative; height:100ch\">\r\n    <ws-blurred>\r\n        <backimage>/EPFileX/image/BI_CONSULTANCY.jpg</backimage>\r\n        <content>\r\n            <div class=\"container\">\r\n                <div class=\"row\" style=\"height:25ch\"></div>\r\n                <ws-loginpane2 varemail=\"\" varpassword=\"\" htmlmessage=\"\" attrdisabled=\"\" clicksubmit=\"\" clickguest=\"\">\r\n                    <logo><img alt=\"Brand\" src=\"/EPFileX/image/LOGO_cipher2.png\" width=\"200px\"></logo>\r\n                </ws-loginpane2>\r\n            </div>\r\n        </content>\r\n    </ws-blurred>\r\n</div>");
  },h):Doc.PrepareTemplate("mypage",n,function()
  {
   return $.parseHTML("<div style=\"position:relative; height:100ch\">\r\n    <ws-blurred>\r\n        <backimage>/EPFileX/image/BI_CONSULTANCY.jpg</backimage>\r\n        <content>\r\n            <div class=\"container\">\r\n                <div class=\"row\" style=\"height:25ch\"></div>\r\n                <ws-loginpane2 varemail=\"\" varpassword=\"\" htmlmessage=\"\" attrdisabled=\"\" clicksubmit=\"\" clickguest=\"\">\r\n                    <logo><img alt=\"Brand\" src=\"/EPFileX/image/LOGO_cipher2.png\" width=\"200px\"></logo>\r\n                </ws-loginpane2>\r\n            </div>\r\n        </content>\r\n    </ws-blurred>\r\n</div>");
  });
 };
 WebServer_Templates.loginpane2=function(h)
 {
  return h?Doc.GetOrLoadTemplate("mypage",{
   $:1,
   $0:"loginpane2"
  },function()
  {
   return $.parseHTML("<div>\r\n    <form class=\"row\">\r\n        <div class=\"col-xs-10 col-xs-offset-1 col-md-6 col-md-offset-3\">\r\n            <div class=\"panel panel-default shadow\">\r\n                <div class=\"panel-body\" style=\"text-align:center\">\r\n                    <fieldset ws-attr=\"attrDisabled\">\r\n                        <div ws-replace=\"Logo\"></div>\r\n                        <ws-input2 varinput=\"varEmail\">\r\n                            <id>exampleInputEmail</id>\r\n                            <label>Email address</label>\r\n                            <type>email</type>\r\n                        </ws-input2>\r\n                        <ws-input2 varinput=\"varPassword\">\r\n                            <id>exampleInputPassword</id>\r\n                            <label>Password</label>\r\n                            <type>password</type>\r\n                        </ws-input2>\r\n                        <ws-button click=\"clickSubmit\">\r\n                            <type>Submit</type>\r\n                            <class>btn-primary</class>\r\n                            <text>Login</text>\r\n                        </ws-button>\r\n                        <div class=\"flex-row\"><div class=\"flexgrow\"><hr></div><div class=\"flexgrow-1-5 text-center\"><h5>or</h5></div><div class=\"flexgrow\"><hr></div></div>\r\n                        <ws-button click=\"clickGuest\">\r\n                            <type>Button</type>\r\n                            <class>btn-info</class>\r\n                            <text>Enter as Guest</text>\r\n                        </ws-button>\r\n                        <br>\r\n                        <div ws-replace=\"htmlMessage\"></div>\r\n                    </fieldset>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </form>\r\n</div>");
  },h):Doc.PrepareTemplate("mypage",{
   $:1,
   $0:"loginpane2"
  },function()
  {
   return $.parseHTML("<div>\r\n    <form class=\"row\">\r\n        <div class=\"col-xs-10 col-xs-offset-1 col-md-6 col-md-offset-3\">\r\n            <div class=\"panel panel-default shadow\">\r\n                <div class=\"panel-body\" style=\"text-align:center\">\r\n                    <fieldset ws-attr=\"attrDisabled\">\r\n                        <div ws-replace=\"Logo\"></div>\r\n                        <ws-input2 varinput=\"varEmail\">\r\n                            <id>exampleInputEmail</id>\r\n                            <label>Email address</label>\r\n                            <type>email</type>\r\n                        </ws-input2>\r\n                        <ws-input2 varinput=\"varPassword\">\r\n                            <id>exampleInputPassword</id>\r\n                            <label>Password</label>\r\n                            <type>password</type>\r\n                        </ws-input2>\r\n                        <ws-button click=\"clickSubmit\">\r\n                            <type>Submit</type>\r\n                            <class>btn-primary</class>\r\n                            <text>Login</text>\r\n                        </ws-button>\r\n                        <div class=\"flex-row\"><div class=\"flexgrow\"><hr></div><div class=\"flexgrow-1-5 text-center\"><h5>or</h5></div><div class=\"flexgrow\"><hr></div></div>\r\n                        <ws-button click=\"clickGuest\">\r\n                            <type>Button</type>\r\n                            <class>btn-info</class>\r\n                            <text>Enter as Guest</text>\r\n                        </ws-button>\r\n                        <br>\r\n                        <div ws-replace=\"htmlMessage\"></div>\r\n                    </fieldset>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </form>\r\n</div>");
  });
 };
 WebServer_Templates.input2=function(h)
 {
  return h?Doc.GetOrLoadTemplate("mypage",{
   $:1,
   $0:"input2"
  },function()
  {
   return $.parseHTML("<div>\r\n    <input type=\"${Type}\" class=\"form-control\" id=\"${Id}\" ws-var=\"varInput\" placeholder=\"${Label}\">\r\n    <br>\r\n</div>");
  },h):Doc.PrepareTemplate("mypage",{
   $:1,
   $0:"input2"
  },function()
  {
   return $.parseHTML("<div>\r\n    <input type=\"${Type}\" class=\"form-control\" id=\"${Id}\" ws-var=\"varInput\" placeholder=\"${Label}\">\r\n    <br>\r\n</div>");
  });
 };
 WebServer_Templates.button=function(h)
 {
  return h?Doc.GetOrLoadTemplate("mypage",{
   $:1,
   $0:"button"
  },function()
  {
   return $.parseHTML("<div>\r\n    <button type=\"${Type}\" class=\"btn ${Class} btn-block\" ws-onclick=\"Click\">${Text}</button>\r\n</div>");
  },h):Doc.PrepareTemplate("mypage",{
   $:1,
   $0:"button"
  },function()
  {
   return $.parseHTML("<div>\r\n    <button type=\"${Type}\" class=\"btn ${Class} btn-block\" ws-onclick=\"Click\">${Text}</button>\r\n</div>");
  });
 };
 WebServer_Templates.blurred=function(h)
 {
  return h?Doc.GetOrLoadTemplate("mypage",{
   $:1,
   $0:"blurred"
  },function()
  {
   return $.parseHTML("<div>\r\n    <div class=\"blur\" style=\"position:absolute; top:0Px; left:0Px; bottom:0Px; right:0Px;\r\n            background-image: url('${BackImage}');\r\n            background-size:cover;\r\n            background-position:center;\r\n            z-index:-1\" other=\"${Image}\"></div>\r\n    <div ws-replace=\"Content\"></div>\r\n</div>");
  },h):Doc.PrepareTemplate("mypage",{
   $:1,
   $0:"blurred"
  },function()
  {
   return $.parseHTML("<div>\r\n    <div class=\"blur\" style=\"position:absolute; top:0Px; left:0Px; bottom:0Px; right:0Px;\r\n            background-image: url('${BackImage}');\r\n            background-size:cover;\r\n            background-position:center;\r\n            z-index:-1\" other=\"${Image}\"></div>\r\n    <div ws-replace=\"Content\"></div>\r\n</div>");
  });
 };
 WebServer_Templates.alert=function(h)
 {
  return h?Doc.GetOrLoadTemplate("mypage",{
   $:1,
   $0:"alert"
  },function()
  {
   return $.parseHTML("<div>\r\n    <div class=\"alert alert-danger\">${Text}</div>\r\n</div>");
  },h):Doc.PrepareTemplate("mypage",{
   $:1,
   $0:"alert"
  },function()
  {
   return $.parseHTML("<div>\r\n    <div class=\"alert alert-danger\">${Text}</div>\r\n</div>");
  });
 };
 WebServer_Templates.hourglass=function(h)
 {
  return h?Doc.GetOrLoadTemplate("mypage",{
   $:1,
   $0:"hourglass"
  },function()
  {
   return $.parseHTML("<div>\r\n    <img src=\"/EPFileX/image/loader.gif\">\r\n</div>");
  },h):Doc.PrepareTemplate("mypage",{
   $:1,
   $0:"hourglass"
  },function()
  {
   return $.parseHTML("<div>\r\n    <img src=\"/EPFileX/image/loader.gif\">\r\n</div>");
  });
 };
 WebServer_Templates.t=function(h)
 {
  return h?Doc.GetOrLoadTemplate("main",null,function()
  {
   return $.parseHTML("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>${Title}</title>\r\n    <script ws-replace=\"TopScript\"></script>\r\n</head>\r\n<body>\r\n    <div ws-replace=\"Body\"></div>\r\n    <script ws-replace=\"scripts\"></script>\r\n</body>\r\n</html>\r\n");
  },h):Doc.PrepareTemplate("main",null,function()
  {
   return $.parseHTML("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>${Title}</title>\r\n    <script ws-replace=\"TopScript\"></script>\r\n</head>\r\n<body>\r\n    <div ws-replace=\"Body\"></div>\r\n    <script ws-replace=\"scripts\"></script>\r\n</body>\r\n</html>\r\n");
  });
 };
 WebServer_Templates.t$1=function(h)
 {
  var n;
  n=null;
  WebServer_Templates.blurred();
  WebServer_Templates.button();
  WebServer_Templates.input();
  WebServer_Templates.input2();
  WebServer_Templates.loginform();
  WebServer_Templates.loginformcipher();
  WebServer_Templates.loginpane();
  WebServer_Templates.loginpane2();
  return h?Doc.GetOrLoadTemplate("mypage",n,function()
  {
   return $.parseHTML("\r\n<h1>People</h1>v1.7\r\n<table>\r\n    <thead>\r\n        <tr>\r\n            <th>Name</th>\r\n            <th>Age</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody ws-hole=\"TableBody\">\r\n        <tr ws-template=\"TableRow1\">\r\n            <td>${txtName}</td>\r\n            <td>${txtAge}</td>\r\n            <td><button ws-onclick=\"onRemove\">Remove</button></td>\r\n        </tr>\r\n        <tr ws-template=\"TableRow2\">\r\n            <td>${txtName}</td>\r\n            <td>${txtAge}</td>\r\n            <td><button ws-onclick=\"onRemove\">Borrar</button></td>\r\n        </tr>\r\n        <tr ws-template=\"TableRow3\">\r\n            <td>${txtName}</td>\r\n            <td>${txtAge}</td>\r\n            <td><button ws-onclick=\"onRemove\">${txtBorrar}</button></td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n<h1>Add a person</h1>\r\n<p><label>Name: <input ws-var=\"varAddPersonName\"></label></p>\r\n<p><label>Age: <input ws-var=\"varAddPersonAge\" type=\"number\"></label></p>\r\n<p><button ws-attr=\"attrAddPersonSubmit\">Add person</button></p>\r\n<p><label>Remove button text: <input ws-var=\"varRemoveText\"></label></p>\r\n\r\n<div class=\"form-group\" ws-template=\"Input\">\r\n    <label for=\"${Id}\">${Label}</label>\r\n    <input type=\"${Type}\" class=\"form-control\" id=\"${Id}\" ws-var=\"varInput\" placeholder=\"${Label}\">\r\n</div>\r\n\r\n<div ws-template=\"LoginPane\">\r\n    <form class=\"row\">\r\n        <div class=\"col-xs-10 col-xs-offset-1 col-md-6 col-md-offset-3\">\r\n            <div class=\"panel panel-default shadow\">\r\n                <div class=\"panel-body\">\r\n                    <div ws-replace=\"Logo\"></div>\r\n                    <ws-input varinput=\"varEmail\">\r\n                        <id>exampleInputEmail</id>\r\n                        <label>Email address</label>\r\n                        <type>email</type>\r\n                    </ws-input>\r\n                    <ws-input varinput=\"varPassword\">\r\n                        <id>exampleInputPassword</id>\r\n                        <label>Password</label>\r\n                        <type>password</type>\r\n                    </ws-input>\r\n                    <button type=\"submit\" class=\"btn\">Submit</button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </form>\r\n</div>\r\n\r\n<div ws-template=\"Input2\">\r\n    <input type=\"${Type}\" class=\"form-control\" id=\"${Id}\" ws-var=\"varInput\" placeholder=\"${Label}\">\r\n    <br>\r\n</div>\r\n\r\n<div ws-template=\"Button\">\r\n    <button type=\"${Type}\" class=\"btn ${Class} btn-block\" ws-onclick=\"Click\">${Text}</button>\r\n</div>\r\n\r\n<div ws-template=\"LoginPane2\">\r\n    <form class=\"row\">\r\n        <div class=\"col-xs-10 col-xs-offset-1 col-md-6 col-md-offset-3\">\r\n            <div class=\"panel panel-default shadow\">\r\n                <div class=\"panel-body\" style=\"text-align:center\">\r\n                    <fieldset ws-attr=\"attrDisabled\">\r\n                        <div ws-replace=\"Logo\"></div>\r\n                        <ws-input2 varinput=\"varEmail\">\r\n                            <id>exampleInputEmail</id>\r\n                            <label>Email address</label>\r\n                            <type>email</type>\r\n                        </ws-input2>\r\n                        <ws-input2 varinput=\"varPassword\">\r\n                            <id>exampleInputPassword</id>\r\n                            <label>Password</label>\r\n                            <type>password</type>\r\n                        </ws-input2>\r\n                        <ws-button click=\"clickSubmit\">\r\n                            <type>Submit</type>\r\n                            <class>btn-primary</class>\r\n                            <text>Login</text>\r\n                        </ws-button>\r\n                        <div class=\"flex-row\"><div class=\"flexgrow\"><hr></div><div class=\"flexgrow-1-5 text-center\"><h5>or</h5></div><div class=\"flexgrow\"><hr></div></div>\r\n                        <ws-button click=\"clickGuest\">\r\n                            <type>Button</type>\r\n                            <class>btn-info</class>\r\n                            <text>Enter as Guest</text>\r\n                        </ws-button>\r\n                        <br>\r\n                        <div ws-replace=\"htmlMessage\"></div>\r\n                    </fieldset>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </form>\r\n</div>\r\n\r\n<div ws-template=\"Blurred\">\r\n    <div class=\"blur\" style=\"position:absolute; top:0Px; left:0Px; bottom:0Px; right:0Px;\r\n            background-image: url('${BackImage}');\r\n            background-size:cover;\r\n            background-position:center;\r\n            z-index:-1\" other=\"${Image}\"></div>\r\n    <div ws-replace=\"Content\"></div>\r\n</div>\r\n\r\n<div style=\"position:relative; height:100ch\" ws-template=\"LoginForm\">\r\n    <ws-blurred>\r\n        <backimage>/EPFileX/image/BI_CONSULTANCY.jpg</backimage>\r\n        <content>\r\n            <div class=\"row\" style=\"height:25ch\"></div>\r\n            <ws-loginpane varemail=\"\" varpassword=\"\">\r\n                <logo><img alt=\"Brand\" src=\"/EPFileX/image/LOGO_cipher2.png\" width=\"200px\"></logo>\r\n            </ws-loginpane>\r\n        </content>\r\n    </ws-blurred>\r\n</div>\r\n\r\n<ws-loginform></ws-loginform>\r\n\r\n<div style=\"position:relative; height:100ch\" ws-template=\"LoginFormCipher\">\r\n    <ws-blurred>\r\n        <backimage>/EPFileX/image/BI_CONSULTANCY.jpg</backimage>\r\n        <content>\r\n            <div class=\"container\">\r\n                <div class=\"row\" style=\"height:25ch\"></div>\r\n                <ws-loginpane2 varemail=\"\" varpassword=\"\" htmlmessage=\"\" attrdisabled=\"\" clicksubmit=\"\" clickguest=\"\">\r\n                    <logo><img alt=\"Brand\" src=\"/EPFileX/image/LOGO_cipher2.png\" width=\"200px\"></logo>\r\n                </ws-loginpane2>\r\n            </div>\r\n        </content>\r\n    </ws-blurred>\r\n</div>\r\n\r\n<div ws-template=\"Alert\">\r\n    <div class=\"alert alert-danger\">${Text}</div>\r\n</div>\r\n\r\n<div ws-template=\"HourGlass\">\r\n    <img src=\"/EPFileX/image/loader.gif\">\r\n</div>\r\n\r\n<ws-loginformcipher></ws-loginformcipher>\r\n\r\n<p>Enter HTML:</p>\r\n<p><textarea ws-var=\"varFreeHtml\" style=\"height:auto\"></textarea><textarea ws-var=\"varFreeHtml\"></textarea></p>\r\n<p><div ws-hole=\"htmlFreeHtml\"></div></p>\r\n");
  },h):Doc.PrepareTemplate("mypage",n,function()
  {
   return $.parseHTML("\r\n<h1>People</h1>v1.7\r\n<table>\r\n    <thead>\r\n        <tr>\r\n            <th>Name</th>\r\n            <th>Age</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody ws-hole=\"TableBody\">\r\n        <tr ws-template=\"TableRow1\">\r\n            <td>${txtName}</td>\r\n            <td>${txtAge}</td>\r\n            <td><button ws-onclick=\"onRemove\">Remove</button></td>\r\n        </tr>\r\n        <tr ws-template=\"TableRow2\">\r\n            <td>${txtName}</td>\r\n            <td>${txtAge}</td>\r\n            <td><button ws-onclick=\"onRemove\">Borrar</button></td>\r\n        </tr>\r\n        <tr ws-template=\"TableRow3\">\r\n            <td>${txtName}</td>\r\n            <td>${txtAge}</td>\r\n            <td><button ws-onclick=\"onRemove\">${txtBorrar}</button></td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n<h1>Add a person</h1>\r\n<p><label>Name: <input ws-var=\"varAddPersonName\"></label></p>\r\n<p><label>Age: <input ws-var=\"varAddPersonAge\" type=\"number\"></label></p>\r\n<p><button ws-attr=\"attrAddPersonSubmit\">Add person</button></p>\r\n<p><label>Remove button text: <input ws-var=\"varRemoveText\"></label></p>\r\n\r\n<div class=\"form-group\" ws-template=\"Input\">\r\n    <label for=\"${Id}\">${Label}</label>\r\n    <input type=\"${Type}\" class=\"form-control\" id=\"${Id}\" ws-var=\"varInput\" placeholder=\"${Label}\">\r\n</div>\r\n\r\n<div ws-template=\"LoginPane\">\r\n    <form class=\"row\">\r\n        <div class=\"col-xs-10 col-xs-offset-1 col-md-6 col-md-offset-3\">\r\n            <div class=\"panel panel-default shadow\">\r\n                <div class=\"panel-body\">\r\n                    <div ws-replace=\"Logo\"></div>\r\n                    <ws-input varinput=\"varEmail\">\r\n                        <id>exampleInputEmail</id>\r\n                        <label>Email address</label>\r\n                        <type>email</type>\r\n                    </ws-input>\r\n                    <ws-input varinput=\"varPassword\">\r\n                        <id>exampleInputPassword</id>\r\n                        <label>Password</label>\r\n                        <type>password</type>\r\n                    </ws-input>\r\n                    <button type=\"submit\" class=\"btn\">Submit</button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </form>\r\n</div>\r\n\r\n<div ws-template=\"Input2\">\r\n    <input type=\"${Type}\" class=\"form-control\" id=\"${Id}\" ws-var=\"varInput\" placeholder=\"${Label}\">\r\n    <br>\r\n</div>\r\n\r\n<div ws-template=\"Button\">\r\n    <button type=\"${Type}\" class=\"btn ${Class} btn-block\" ws-onclick=\"Click\">${Text}</button>\r\n</div>\r\n\r\n<div ws-template=\"LoginPane2\">\r\n    <form class=\"row\">\r\n        <div class=\"col-xs-10 col-xs-offset-1 col-md-6 col-md-offset-3\">\r\n            <div class=\"panel panel-default shadow\">\r\n                <div class=\"panel-body\" style=\"text-align:center\">\r\n                    <fieldset ws-attr=\"attrDisabled\">\r\n                        <div ws-replace=\"Logo\"></div>\r\n                        <ws-input2 varinput=\"varEmail\">\r\n                            <id>exampleInputEmail</id>\r\n                            <label>Email address</label>\r\n                            <type>email</type>\r\n                        </ws-input2>\r\n                        <ws-input2 varinput=\"varPassword\">\r\n                            <id>exampleInputPassword</id>\r\n                            <label>Password</label>\r\n                            <type>password</type>\r\n                        </ws-input2>\r\n                        <ws-button click=\"clickSubmit\">\r\n                            <type>Submit</type>\r\n                            <class>btn-primary</class>\r\n                            <text>Login</text>\r\n                        </ws-button>\r\n                        <div class=\"flex-row\"><div class=\"flexgrow\"><hr></div><div class=\"flexgrow-1-5 text-center\"><h5>or</h5></div><div class=\"flexgrow\"><hr></div></div>\r\n                        <ws-button click=\"clickGuest\">\r\n                            <type>Button</type>\r\n                            <class>btn-info</class>\r\n                            <text>Enter as Guest</text>\r\n                        </ws-button>\r\n                        <br>\r\n                        <div ws-replace=\"htmlMessage\"></div>\r\n                    </fieldset>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </form>\r\n</div>\r\n\r\n<div ws-template=\"Blurred\">\r\n    <div class=\"blur\" style=\"position:absolute; top:0Px; left:0Px; bottom:0Px; right:0Px;\r\n            background-image: url('${BackImage}');\r\n            background-size:cover;\r\n            background-position:center;\r\n            z-index:-1\" other=\"${Image}\"></div>\r\n    <div ws-replace=\"Content\"></div>\r\n</div>\r\n\r\n<div style=\"position:relative; height:100ch\" ws-template=\"LoginForm\">\r\n    <ws-blurred>\r\n        <backimage>/EPFileX/image/BI_CONSULTANCY.jpg</backimage>\r\n        <content>\r\n            <div class=\"row\" style=\"height:25ch\"></div>\r\n            <ws-loginpane varemail=\"\" varpassword=\"\">\r\n                <logo><img alt=\"Brand\" src=\"/EPFileX/image/LOGO_cipher2.png\" width=\"200px\"></logo>\r\n            </ws-loginpane>\r\n        </content>\r\n    </ws-blurred>\r\n</div>\r\n\r\n<ws-loginform></ws-loginform>\r\n\r\n<div style=\"position:relative; height:100ch\" ws-template=\"LoginFormCipher\">\r\n    <ws-blurred>\r\n        <backimage>/EPFileX/image/BI_CONSULTANCY.jpg</backimage>\r\n        <content>\r\n            <div class=\"container\">\r\n                <div class=\"row\" style=\"height:25ch\"></div>\r\n                <ws-loginpane2 varemail=\"\" varpassword=\"\" htmlmessage=\"\" attrdisabled=\"\" clicksubmit=\"\" clickguest=\"\">\r\n                    <logo><img alt=\"Brand\" src=\"/EPFileX/image/LOGO_cipher2.png\" width=\"200px\"></logo>\r\n                </ws-loginpane2>\r\n            </div>\r\n        </content>\r\n    </ws-blurred>\r\n</div>\r\n\r\n<div ws-template=\"Alert\">\r\n    <div class=\"alert alert-danger\">${Text}</div>\r\n</div>\r\n\r\n<div ws-template=\"HourGlass\">\r\n    <img src=\"/EPFileX/image/loader.gif\">\r\n</div>\r\n\r\n<ws-loginformcipher></ws-loginformcipher>\r\n\r\n<p>Enter HTML:</p>\r\n<p><textarea ws-var=\"varFreeHtml\" style=\"height:auto\"></textarea><textarea ws-var=\"varFreeHtml\"></textarea></p>\r\n<p><div ws-hole=\"htmlFreeHtml\"></div></p>\r\n");
  });
 };
 WebServer_Templates.loginpane=function(h)
 {
  return h?Doc.GetOrLoadTemplate("mypage",{
   $:1,
   $0:"loginpane"
  },function()
  {
   return $.parseHTML("<div>\r\n    <form class=\"row\">\r\n        <div class=\"col-xs-10 col-xs-offset-1 col-md-6 col-md-offset-3\">\r\n            <div class=\"panel panel-default shadow\">\r\n                <div class=\"panel-body\">\r\n                    <div ws-replace=\"Logo\"></div>\r\n                    <ws-input varinput=\"varEmail\">\r\n                        <id>exampleInputEmail</id>\r\n                        <label>Email address</label>\r\n                        <type>email</type>\r\n                    </ws-input>\r\n                    <ws-input varinput=\"varPassword\">\r\n                        <id>exampleInputPassword</id>\r\n                        <label>Password</label>\r\n                        <type>password</type>\r\n                    </ws-input>\r\n                    <button type=\"submit\" class=\"btn\">Submit</button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </form>\r\n</div>");
  },h):Doc.PrepareTemplate("mypage",{
   $:1,
   $0:"loginpane"
  },function()
  {
   return $.parseHTML("<div>\r\n    <form class=\"row\">\r\n        <div class=\"col-xs-10 col-xs-offset-1 col-md-6 col-md-offset-3\">\r\n            <div class=\"panel panel-default shadow\">\r\n                <div class=\"panel-body\">\r\n                    <div ws-replace=\"Logo\"></div>\r\n                    <ws-input varinput=\"varEmail\">\r\n                        <id>exampleInputEmail</id>\r\n                        <label>Email address</label>\r\n                        <type>email</type>\r\n                    </ws-input>\r\n                    <ws-input varinput=\"varPassword\">\r\n                        <id>exampleInputPassword</id>\r\n                        <label>Password</label>\r\n                        <type>password</type>\r\n                    </ws-input>\r\n                    <button type=\"submit\" class=\"btn\">Submit</button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </form>\r\n</div>");
  });
 };
 WebServer_Templates.input=function(h)
 {
  return h?Doc.GetOrLoadTemplate("mypage",{
   $:1,
   $0:"input"
  },function()
  {
   return $.parseHTML("<div class=\"form-group\">\r\n    <label for=\"${Id}\">${Label}</label>\r\n    <input type=\"${Type}\" class=\"form-control\" id=\"${Id}\" ws-var=\"varInput\" placeholder=\"${Label}\">\r\n</div>");
  },h):Doc.PrepareTemplate("mypage",{
   $:1,
   $0:"input"
  },function()
  {
   return $.parseHTML("<div class=\"form-group\">\r\n    <label for=\"${Id}\">${Label}</label>\r\n    <input type=\"${Type}\" class=\"form-control\" id=\"${Id}\" ws-var=\"varInput\" placeholder=\"${Label}\">\r\n</div>");
  });
 };
 WebServer_Templates.loginform=function(h)
 {
  return h?Doc.GetOrLoadTemplate("mypage",{
   $:1,
   $0:"loginform"
  },function()
  {
   return $.parseHTML("<div style=\"position:relative; height:100ch\">\r\n    <ws-blurred>\r\n        <backimage>/EPFileX/image/BI_CONSULTANCY.jpg</backimage>\r\n        <content>\r\n            <div class=\"row\" style=\"height:25ch\"></div>\r\n            <ws-loginpane varemail=\"\" varpassword=\"\">\r\n                <logo><img alt=\"Brand\" src=\"/EPFileX/image/LOGO_cipher2.png\" width=\"200px\"></logo>\r\n            </ws-loginpane>\r\n        </content>\r\n    </ws-blurred>\r\n</div>");
  },h):Doc.PrepareTemplate("mypage",{
   $:1,
   $0:"loginform"
  },function()
  {
   return $.parseHTML("<div style=\"position:relative; height:100ch\">\r\n    <ws-blurred>\r\n        <backimage>/EPFileX/image/BI_CONSULTANCY.jpg</backimage>\r\n        <content>\r\n            <div class=\"row\" style=\"height:25ch\"></div>\r\n            <ws-loginpane varemail=\"\" varpassword=\"\">\r\n                <logo><img alt=\"Brand\" src=\"/EPFileX/image/LOGO_cipher2.png\" width=\"200px\"></logo>\r\n            </ws-loginpane>\r\n        </content>\r\n    </ws-blurred>\r\n</div>");
  });
 };
 WebServer_Templates.tablerow3=function(h)
 {
  return h?Doc.GetOrLoadTemplate("mypage",{
   $:1,
   $0:"tablerow3"
  },function()
  {
   return $.parseHTML("<tr>\r\n            <td>${txtName}</td>\r\n            <td>${txtAge}</td>\r\n            <td><button ws-onclick=\"onRemove\">${txtBorrar}</button></td>\r\n        </tr>");
  },h):Doc.PrepareTemplate("mypage",{
   $:1,
   $0:"tablerow3"
  },function()
  {
   return $.parseHTML("<tr>\r\n            <td>${txtName}</td>\r\n            <td>${txtAge}</td>\r\n            <td><button ws-onclick=\"onRemove\">${txtBorrar}</button></td>\r\n        </tr>");
  });
 };
}());
