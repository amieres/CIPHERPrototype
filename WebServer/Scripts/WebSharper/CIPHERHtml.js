(function()
{
 "use strict";
 var CIPHERPrototype,Val,HelperType,Html,SC$1,Option,CIPHERHtml,R,ReactDOM$1,CipherNode,SC$2,App,Dummy,MailboxState,App$1,SC$3,DynNode,Props,Message,SC$4,DataTube,Tube,Cell,UI,Next,Doc,Seq,AttrModule,Arrays,Strings,List,Runtime,Collections,FSharpSet,BalancedTree,AttrProxy,View,Operators,Control,MailboxProcessor,Concurrency,FSharpMap,Map,Unchecked;
 CIPHERPrototype=window.CIPHERPrototype=window.CIPHERPrototype||{};
 Val=CIPHERPrototype.Val=CIPHERPrototype.Val||{};
 HelperType=Val.HelperType=Val.HelperType||{};
 Html=Val.Html=Val.Html||{};
 SC$1=window.StartupCode$CIPHERHtml$ClassVal=window.StartupCode$CIPHERHtml$ClassVal||{};
 Option=CIPHERPrototype.Option=CIPHERPrototype.Option||{};
 CIPHERHtml=CIPHERPrototype.CIPHERHtml=CIPHERPrototype.CIPHERHtml||{};
 R=CIPHERHtml.R=CIPHERHtml.R||{};
 ReactDOM$1=CIPHERHtml.ReactDOM=CIPHERHtml.ReactDOM||{};
 CipherNode=CIPHERHtml.CipherNode=CIPHERHtml.CipherNode||{};
 SC$2=window.StartupCode$CIPHERHtml$CIPHERHtml=window.StartupCode$CIPHERHtml$CIPHERHtml||{};
 App=CIPHERPrototype.App=CIPHERPrototype.App||{};
 Dummy=App.Dummy=App.Dummy||{};
 MailboxState=App.MailboxState=App.MailboxState||{};
 App$1=App.App=App.App||{};
 SC$3=window.StartupCode$CIPHERHtml$App=window.StartupCode$CIPHERHtml$App||{};
 DynNode=CIPHERPrototype.DynNode=CIPHERPrototype.DynNode||{};
 Props=DynNode.Props=DynNode.Props||{};
 Message=DynNode.Message=DynNode.Message||{};
 SC$4=window.StartupCode$CIPHERHtml$DynNode=window.StartupCode$CIPHERHtml$DynNode||{};
 DataTube=CIPHERPrototype.DataTube=CIPHERPrototype.DataTube||{};
 Tube=DataTube.Tube=DataTube.Tube||{};
 Cell=DataTube.Cell=DataTube.Cell||{};
 UI=WebSharper&&WebSharper.UI;
 Next=UI&&UI.Next;
 Doc=Next&&Next.Doc;
 Seq=WebSharper&&WebSharper.Seq;
 AttrModule=Next&&Next.AttrModule;
 Arrays=WebSharper&&WebSharper.Arrays;
 Strings=WebSharper&&WebSharper.Strings;
 List=WebSharper&&WebSharper.List;
 Runtime=IntelliFactory&&IntelliFactory.Runtime;
 Collections=WebSharper&&WebSharper.Collections;
 FSharpSet=Collections&&Collections.FSharpSet;
 BalancedTree=Collections&&Collections.BalancedTree;
 AttrProxy=Next&&Next.AttrProxy;
 View=Next&&Next.View;
 Operators=WebSharper&&WebSharper.Operators;
 Control=WebSharper&&WebSharper.Control;
 MailboxProcessor=Control&&Control.MailboxProcessor;
 Concurrency=WebSharper&&WebSharper.Concurrency;
 FSharpMap=Collections&&Collections.FSharpMap;
 Map=Collections&&Collections.Map;
 Unchecked=WebSharper&&WebSharper.Unchecked;
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
 Html.bindHElem=function(hElem,v)
 {
  var g;
  return{
   $:4,
   $0:Doc.BindView((g=Html.renderDoc(),function(x)
   {
    return g(hElem(x));
   }),Val.toView(Val.fixit2(v)))
  };
 };
 Html.composeDoc=function(elt,dtl,dtlVal)
 {
  var x,f,f$1,g;
  return{
   $:4,
   $0:(x=Val.toView(dtlVal),Doc.BindView((f=(f$1=function(s)
   {
    return Seq.append(dtl,s);
   },function(x$1)
   {
    return elt(f$1(x$1));
   }),(g=Html.renderDoc(),function(x$1)
   {
    return g(f(x$1));
   })),x))
  };
 };
 Html.style1=function(n,v)
 {
  return{
   $:5,
   $0:AttrModule.DynamicStyle(n,Val.toView(Val.fixit2(v)))
  };
 };
 Html.style=function(v)
 {
  return Html.htmlAttribute("style",v);
 };
 Html.string2Styles=function()
 {
  SC$1.$cctor();
  return SC$1.string2Styles;
 };
 Html.style2pairs=function(ss)
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
 Html.xclass=function(v)
 {
  var m,cv;
  return{
   $:5,
   $0:(m=Val.fixit2(v),m.$==2?AttrModule.DynamicClass("class_for_view_not_implemented",m.$0,function(y)
   {
    return""!==y;
   }):m.$==1?(cv=m.$0,AttrModule.DynamicClass(cv.RVal(),cv.RView(),function(y)
   {
    return""!==y;
   })):AttrModule.Class(m.$0))
  };
 };
 Html.Id=function(v)
 {
  return Html.htmlAttribute("id",v);
 };
 Html.width=function(v)
 {
  return Html.htmlAttribute("width",v);
 };
 Html.type=function(v)
 {
  return Html.htmlAttribute("type",v);
 };
 Html["class"]=function(v)
 {
  return Html.htmlAttribute("class",v);
 };
 Html.src=function(v)
 {
  return Html.htmlAttribute("src",v);
 };
 Html.rel=function(v)
 {
  return Html.htmlAttribute("rel",v);
 };
 Html.href=function(v)
 {
  return Html.htmlAttribute("href",v);
 };
 Html.link=function(sc)
 {
  return Html.htmlElement("link",sc);
 };
 Html.fieldset=function(ch)
 {
  return Html.htmlElement("fieldset",ch);
 };
 Html.styleH=function(st)
 {
  return Html.htmlElement("style",st);
 };
 Html.script=function(sc)
 {
  return Html.htmlElement("script",sc);
 };
 Html.button=function(ch)
 {
  return Html.htmlElement("button",ch);
 };
 Html.label=function(ch)
 {
  return Html.htmlElement("label",ch);
 };
 Html.tbody=function(ch)
 {
  return Html.htmlElement("tbody",ch);
 };
 Html.td=function(ch)
 {
  return Html.htmlElement("td",ch);
 };
 Html.tr=function(ch)
 {
  return Html.htmlElement("tr",ch);
 };
 Html.th=function(ch)
 {
  return Html.htmlElement("th",ch);
 };
 Html.thead=function(ch)
 {
  return Html.htmlElement("thead",ch);
 };
 Html.table=function(ch)
 {
  return Html.htmlElement("table",ch);
 };
 Html.form=function(ch)
 {
  return Html.htmlElement("form",ch);
 };
 Html.span=function(ch)
 {
  return Html.htmlElement("span",ch);
 };
 Html.img=function(ch)
 {
  return Html.htmlElement("img",ch);
 };
 Html.div=function(ch)
 {
  return Html.htmlElement("div",ch);
 };
 Html.h6=function(ch)
 {
  return Html.htmlElement("h6",ch);
 };
 Html.h5=function(ch)
 {
  return Html.htmlElement("h5",ch);
 };
 Html.h4=function(ch)
 {
  return Html.htmlElement("h4",ch);
 };
 Html.h3=function(ch)
 {
  return Html.htmlElement("h3",ch);
 };
 Html.h2=function(ch)
 {
  return Html.htmlElement("h2",ch);
 };
 Html.h1=function(ch)
 {
  return Html.htmlElement("h1",ch);
 };
 Html.hr=function(ch)
 {
  return Html.htmlElement("hr",ch);
 };
 Html.br=function(ch)
 {
  return Html.htmlElement("br",ch);
 };
 Html.someElt=function(elt)
 {
  return{
   $:4,
   $0:elt
  };
 };
 Html.htmlText=function(txt)
 {
  return{
   $:2,
   $0:Val.fixit2(txt)
  };
 };
 Html.htmlAttribute=function(name,v)
 {
  return{
   $:1,
   $0:name,
   $1:Val.fixit2(v)
  };
 };
 Html.htmlElement=function(name,ch)
 {
  return{
   $:0,
   $0:name,
   $1:ch
  };
 };
 Html.renderDoc=function()
 {
  SC$1.$cctor();
  return SC$1.renderDoc;
 };
 Html["HtmlNode.AddChildren"]=function(_this,add)
 {
  return Html.mapHtmlElement(function($1,$2)
  {
   return{
    $:0,
    $0:$1,
    $1:Seq.append(add,$2)
   };
  },_this);
 };
 Html["HtmlNode.Class"]=function(_this,clas)
 {
  return Html.replaceAtt("class",_this,Val.fixit2(clas));
 };
 Html["HtmlNode.get_toDoc"]=function(_this,u)
 {
  var $1,x;
  return _this.$==1||_this.$==3&&true?Doc.Empty():(x=Html.chooseNode(_this),Html.defaultValue(Doc.Empty(),x));
 };
 Html.replaceAtt=function(att,node,newVal)
 {
  return Html.mapHtmlElement(function($1,$2)
  {
   return{
    $:0,
    $0:$1,
    $1:Html.replaceAttribute(att,$2,newVal)
   };
  },node);
 };
 Html.replaceAttribute=function(att,children,newVal)
 {
  return new List.T({
   $:1,
   $0:{
    $:1,
    $0:att,
    $1:newVal
   },
   $1:List.ofSeq(Seq.filter(function(a)
   {
    return a.$==1?a.$0===att?false:true:true;
   },children))
  });
 };
 Html.getStyle=function()
 {
  SC$1.$cctor();
  return SC$1.getStyle;
 };
 Html.getClass=function()
 {
  SC$1.$cctor();
  return SC$1.getClass;
 };
 Html.getAttr=function(attr,element)
 {
  return(Html.getAttrChildren(attr))(element.$==0?element.$1:[]);
 };
 Html.mapHtmlElement=function(f,element)
 {
  return element.$==0?f(element.$0,element.$1):element;
 };
 Html.getAttrChildren=function(attr)
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
  },function(a)
  {
   return Html.defaultValue(v,a);
  });
  return function(x)
  {
   return g(f(x));
  };
 };
 Html.chooseNode=function(node)
 {
  var children;
  return node.$==0?(children=node.$1,{
   $:1,
   $0:Doc.Element(node.$0,Html.getAttrsFromSeq(children),Seq.choose(Html.chooseNode,children))
  }):node.$==2?{
   $:1,
   $0:Val.tagDoc(Doc.TextNode,node.$0)
  }:node.$==4?{
   $:1,
   $0:node.$0
  }:null;
 };
 Html.getAttrsFromSeq=function(children)
 {
  var x;
  x=Seq.choose(Html.chooseAttr,children);
  return Seq.append(List.choose(id,List.ofArray([Html.groupAttr("class"," ",children),Html.groupAttr("style","; ",children)])),x);
 };
 Html.groupAttr=function(name,sep,children)
 {
  var ss,r,f;
  ss=Seq.choose(function(n)
  {
   return Html.chooseThisAttr(name,n);
  },children);
  return Seq.isEmpty(ss)?null:{
   $:1,
   $0:Val.attrV(name,(r=(f=function(a,b)
   {
    return Html.concat(sep,a,b);
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
 Html.concat=function(s,a,b)
 {
  return a+s+b;
 };
 Html.chooseThisAttr=function(_this,node)
 {
  var $1;
  return node.$==1&&(node.$0===_this&&($1=[node.$0,node.$1],true))?{
   $:1,
   $0:$1[1]
  }:null;
 };
 Html.chooseAttr=function(node)
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
 Html.callAddClass=function()
 {
  SC$1.$cctor();
  return SC$1.callAddClass;
 };
 Html.removeClass=function(classes,rem)
 {
  return Strings.concat(" ",(new FSharpSet.New$1(BalancedTree.OfSeq(Strings.SplitChars(classes,[32],0)))).Remove(rem));
 };
 Html.addClass=function(classes,add)
 {
  var x;
  return Strings.concat(" ",(x=new FSharpSet.New$1(BalancedTree.OfSeq(Strings.SplitChars(classes,[32],0))),new FSharpSet.New$1(BalancedTree.OfSeq(Seq.append(new FSharpSet.New$1(BalancedTree.OfSeq(Strings.SplitChars(add,[32],0))),x)))));
 };
 Html.defaultValue=function(v,a)
 {
  return a==null?v:a.$0;
 };
 Val.map4=function(f,v1,v2,v3,v4)
 {
  return Val.map4V(f,Val.fixit2(v1),Val.fixit2(v2),Val.fixit2(v3),Val.fixit2(v4));
 };
 Val.map3=function(f,v1,v2,v3)
 {
  return Val.map3V(f,Val.fixit2(v1),Val.fixit2(v2),Val.fixit2(v3));
 };
 Val.map2=function(f,v1,v2)
 {
  return((Val.map2V(f))(Val.fixit2(v1)))(Val.fixit2(v2));
 };
 Val.map=function(f,v)
 {
  return Val.mapV(f,Val.fixit2(v));
 };
 Val.toDoc=function(v)
 {
  return Doc.EmbedView(Val.toView(Val.fixit2(v)));
 };
 Val.textV=function(v)
 {
  return Val.tag(Doc.TextNode,v);
 };
 Val._placeholder=function(v)
 {
  return Val.atr("placeholder",v);
 };
 Val._style=function(v)
 {
  return Val.atr("style",v);
 };
 Val._type=function(v)
 {
  return Val.atr("type",v);
 };
 Val._class=function(v)
 {
  return Val.atr("class",v);
 };
 Val.tag=function(tag,v)
 {
  return Val.tagDoc(tag,Val.fixit2(v));
 };
 Val.atr=function(att,v)
 {
  return Val.attrV(att,Val.fixit2(v));
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
 Val.iter=function(f,v)
 {
  View.Get(f,Val.toView(v));
 };
 Val.toView=function(v)
 {
  return v.$==2?v.$0:v.$==1?v.$0.RView():View.Const(v.$0);
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
 SC$1.$cctor=Runtime.Cctor(function()
 {
  var g,v,g$1,m;
  SC$1.callAddClass=Html.addClass("a","b");
  SC$1.getClass=function(e)
  {
   return Html.getAttr("class",e);
  };
  SC$1.getStyle=function(e)
  {
   return Html.getAttr("style",e);
  };
  SC$1.renderDoc=(g=(v=Doc.Empty(),function(a)
  {
   return Html.defaultValue(v,a);
  }),function(x)
  {
   return g(Html.chooseNode(x));
  });
  SC$1.string2Styles=(g$1=(m=function(n,v$1)
  {
   return{
    $:5,
    $0:AttrModule.Style(n,v$1)
   };
  },function(a)
  {
   return Arrays.map(function($1)
   {
    return m($1[0],$1[1]);
   },a);
  }),function(x)
  {
   return g$1(Html.style2pairs(x));
  });
  SC$1.$cctor=window.ignore;
 });
 Option.defaultValue=function(def,a)
 {
  return a==null?def:a.$0;
 };
 R=CIPHERHtml.R=Runtime.Class({},null,R);
 R.E00=function(elem,attrs,children)
 {
  return React.createElement.apply(null,[elem,Arrays.length(attrs)===0?{}:Arrays.reduce(function(a,b)
  {
   return $.extend(true,{},a,b);
  },attrs)].concat(children));
 };
 R.E0=function(elem,attrs,children)
 {
  var reduceAtt,a;
  reduceAtt=attrs.$==0?{}:Seq.reduce(function(a$1,b)
  {
   return $.extend(true,{},a$1,b);
  },attrs);
  a=new List.T({
   $:1,
   $0:elem,
   $1:new List.T({
    $:1,
    $0:reduceAtt,
    $1:List.ofSeq(children)
   })
  });
  return a.$==0?React.createElement.apply(null,[elem,reduceAtt]):React.createElement.apply(null,Arrays.ofList(a));
 };
 R.New=Runtime.Ctor(function()
 {
 },R);
 ReactDOM$1=CIPHERHtml.ReactDOM=Runtime.Class({},null,ReactDOM$1);
 ReactDOM$1.New=Runtime.Ctor(function()
 {
 },ReactDOM$1);
 CipherNode.NEmpty={
  $:8
 };
 CIPHERHtml.reactContainerClass=function(className,afterRender)
 {
  var r;
  return React.createClass((r={},r.displayName="containerClass",r.componentDidMount=function()
  {
   afterRender(this,ReactDOM.findDOMNode(this));
  },r.shouldComponentUpdate=function()
  {
   return false;
  },r.render=function()
  {
   return CIPHERHtml.toReact(CIPHERHtml.Div([CIPHERHtml.Class(className)]));
  },r));
 };
 CIPHERHtml.toIncrementalDom=function(node)
 {
  var attributeR;
  function elementR(a)
  {
   var $1,tag,children,attrs,a$1;
   switch(a.$==1?1:a.$==6?2:a.$==7?3:a.$==4?4:a.$==5?4:a.$==2?4:a.$==3?4:a.$==8?4:0)
   {
    case 0:
     tag=a.$0;
     children=a.$1;
     CIPHERHtml.elementOpen(tag,null,[],(attrs=(a$1=Arrays.collect(attributeR,children),Arrays.length(a$1)===0?{}:Seq.reduce(function(a$2,b)
     {
      return $.extend(true,{},a$2,b);
     },a$1)),Arrays.collect(function(name)
     {
      return[name==="className"?"class":Strings.StartsWith(name,"on")?name.toLowerCase():name,attrs[name]];
     },Object.keys(attrs))));
     Arrays.map(elementR,children);
     return CIPHERHtml.elementClose(tag);
     break;
    case 1:
     return CIPHERHtml.textIDom(a.$0);
     break;
    case 2:
     return elementR(a.$0.CIPHERPrototype_CIPHERHtml_IUIObject$view());
     break;
    case 3:
     return a.$0.CIPHERPrototype_CIPHERHtml_IUIApp$nodeIncDom(a.$1);
     break;
    case 4:
     return null;
     break;
   }
  }
  attributeR=function(a)
  {
   var $1;
   switch(a.$==3?1:a.$==0?2:a.$==1?2:a.$==4?2:a.$==5?2:a.$==6?2:a.$==7?2:a.$==8?2:0)
   {
    case 0:
     return[CIPHERHtml.newAttr(a.$0,a.$1)];
     break;
    case 1:
     return a.$0;
     break;
    case 2:
     return[];
     break;
   }
  };
  return elementR(node);
 };
 CIPHERHtml.textIDom=function(txt)
 {
  var x;
  x=window.IncrementalDOM;
  return x.text.apply(x,[txt]);
 };
 CIPHERHtml.elementClose=function(tag)
 {
  var x;
  x=window.IncrementalDOM;
  return x.elementClose.apply(x,[tag]);
 };
 CIPHERHtml.elementOpen=function(tag,key,statics,pairs)
 {
  var x,args;
  x=window.IncrementalDOM;
  args=[tag,key,statics].concat(pairs);
  return x.elementOpen.apply(x,args);
 };
 CIPHERHtml.patchInner=function(container,f)
 {
  var x;
  x=window.IncrementalDOM;
  x.patchInner.apply(x,[container,f]);
 };
 CIPHERHtml.patchOuter=function(container,f)
 {
  var x;
  x=window.IncrementalDOM;
  x.patchOuter.apply(x,[container,f]);
 };
 CIPHERHtml.toReact=function(node)
 {
  var attributeR;
  function elementR(a)
  {
   var $1,children,subNodes;
   switch(a.$==1?1:a.$==4?2:a.$==5?3:a.$==6?4:a.$==7?5:a.$==8?6:a.$==2?7:a.$==3?7:0)
   {
    case 0:
     children=a.$1;
     subNodes=Arrays.choose(elementR,children);
     return{
      $:1,
      $0:R.E00(a.$0,Arrays.collect(attributeR,children),subNodes)
     };
     break;
    case 1:
     return{
      $:1,
      $0:a.$0
     };
     break;
    case 2:
     return{
      $:1,
      $0:a.$0
     };
     break;
    case 3:
     return{
      $:1,
      $0:React.createElement.apply(null,[a.$0])
     };
     break;
    case 4:
     return elementR(a.$0.CIPHERPrototype_CIPHERHtml_IUIObject$view());
     break;
    case 5:
     return{
      $:1,
      $0:a.$0.CIPHERPrototype_CIPHERHtml_IUIApp$nodeR(a.$1)
     };
     break;
    case 6:
     return{
      $:1,
      $0:null
     };
     break;
    case 7:
     return null;
     break;
   }
  }
  attributeR=function(a)
  {
   var $1;
   switch(a.$==3?1:a.$==0?2:a.$==1?2:a.$==4?2:a.$==5?2:a.$==6?2:a.$==7?2:a.$==8?2:0)
   {
    case 0:
     return[CIPHERHtml.newAttr(a.$0,a.$1)];
     break;
    case 1:
     return a.$0;
     break;
    case 2:
     return[];
     break;
   }
  };
  return Option.defaultValue(null,elementR(node));
 };
 CIPHERHtml.__outerHtml=function(html)
 {
  var elem,tag,x,x$1;
  try
  {
   return html.indexOf(String.fromCharCode(62))>0?(elem=document.createElement("div"),elem.innerHTML=html,tag=elem.firstElementChild,x=(x$1=Seq.map(function(a)
   {
    return CIPHERHtml.outerAttrs(a.name,a.value);
   },Seq.map(function(i)
   {
    return tag.attributes.item(i);
   },List.ofSeq(Operators.range(0,tag.attributes.length-1)))),Seq.append(List.ofArray([CIPHERHtml.__innerHtml(tag.innerHTML)]),x$1)),CIPHERHtml.NewTag(tag.localName,x)):CipherNode.NEmpty;
  }
  catch(m)
  {
   return CipherNode.NEmpty;
  }
 };
 CIPHERHtml.outerAttrs=function(name,value)
 {
  return name==="class"?CIPHERHtml.NewAttr("className",value):CIPHERHtml.NewAttr(name,value);
 };
 CIPHERHtml.__innerHtml=function(html)
 {
  return{
   $:2,
   $0:"dangerouslySetInnerHTML",
   $1:{
    __html:html
   }
  };
 };
 CIPHERHtml._Style=function(styles)
 {
  return CIPHERHtml.Style(Seq.reduce(function(a,b)
  {
   return jQuery.extend(jQuery.extend({},a),b);
  },styles));
 };
 CIPHERHtml._border=function(brd)
 {
  return CIPHERHtml.newAttr("border",brd);
 };
 CIPHERHtml._textAlign=function(alg)
 {
  return CIPHERHtml.newAttr("textAlign",alg);
 };
 CIPHERHtml._textOverflow=function(tov)
 {
  return CIPHERHtml.newAttr("textOverflow",tov);
 };
 CIPHERHtml._whiteSpace=function(wsp)
 {
  return CIPHERHtml.newAttr("whiteSpace",wsp);
 };
 CIPHERHtml._fontFamily=function(fml)
 {
  return CIPHERHtml.newAttr("fontFamily",fml);
 };
 CIPHERHtml._background=function(clr)
 {
  return CIPHERHtml.newAttr("background",clr);
 };
 CIPHERHtml._overflow=function(ove)
 {
  return CIPHERHtml.newAttr("overflow",ove);
 };
 CIPHERHtml._marginBottom=function(mar)
 {
  return CIPHERHtml.newAttr("marginBottom",mar);
 };
 CIPHERHtml._borderWidth=function(wid)
 {
  return CIPHERHtml.newAttr("borderWidth",wid);
 };
 CIPHERHtml._borderStyle=function(sty)
 {
  return CIPHERHtml.newAttr("borderStyle",sty);
 };
 CIPHERHtml._paddingBottom=function(bot)
 {
  return CIPHERHtml.newAttr("paddingBottom",bot);
 };
 CIPHERHtml._paddingTop=function(top)
 {
  return CIPHERHtml.newAttr("paddingTop",top);
 };
 CIPHERHtml._paddingRight=function(rig)
 {
  return CIPHERHtml.newAttr("paddingRight",rig);
 };
 CIPHERHtml._paddingLeft=function(lef)
 {
  return CIPHERHtml.newAttr("paddingLeft",lef);
 };
 CIPHERHtml._padding=function(pad)
 {
  return CIPHERHtml.newAttr("padding",pad);
 };
 CIPHERHtml._flexShrink=function(gro)
 {
  return CIPHERHtml.newAttr("flexShrink",gro);
 };
 CIPHERHtml._flexGrow=function(gro)
 {
  return CIPHERHtml.newAttr("flexGrow",gro);
 };
 CIPHERHtml._flexBasis=function(bas)
 {
  return CIPHERHtml.newAttr("flexBasis",bas);
 };
 CIPHERHtml._flex=function(fle)
 {
  return CIPHERHtml.newAttr("flex",fle);
 };
 CIPHERHtml._flexFlow=function(flo)
 {
  return CIPHERHtml.newAttr("flexFlow",flo);
 };
 CIPHERHtml._display=function(dis)
 {
  return CIPHERHtml.newAttr("display",dis);
 };
 CIPHERHtml._position=function(pos)
 {
  return CIPHERHtml.newAttr("position",pos);
 };
 CIPHERHtml._zIndex=function(zid)
 {
  return CIPHERHtml.newAttr("zIndex",zid);
 };
 CIPHERHtml._maxWidth=function(wid)
 {
  return CIPHERHtml.newAttr("maxWidth",wid);
 };
 CIPHERHtml._minWidth=function(wid)
 {
  return CIPHERHtml.newAttr("minWidth",wid);
 };
 CIPHERHtml._width=function(wid)
 {
  return CIPHERHtml.newAttr("width",wid);
 };
 CIPHERHtml._maxHeight=function(hei)
 {
  return CIPHERHtml.newAttr("maxHeight",hei);
 };
 CIPHERHtml._minHeight=function(hei)
 {
  return CIPHERHtml.newAttr("minHeight",hei);
 };
 CIPHERHtml._height=function(hei)
 {
  return CIPHERHtml.newAttr("height",hei);
 };
 CIPHERHtml._right=function(rig)
 {
  return CIPHERHtml.newAttr("right",rig);
 };
 CIPHERHtml._left=function(lef)
 {
  return CIPHERHtml.newAttr("left",lef);
 };
 CIPHERHtml._bottom=function(bot)
 {
  return CIPHERHtml.newAttr("bottom",bot);
 };
 CIPHERHtml._top=function(top)
 {
  return CIPHERHtml.newAttr("top",top);
 };
 CIPHERHtml._alignSelf=function(alg)
 {
  return CIPHERHtml.newAttr("alignSelf",alg);
 };
 CIPHERHtml._fontWeight=function(wei)
 {
  return CIPHERHtml.newAttr("fontWeight",wei);
 };
 CIPHERHtml._fontStyle=function(stl)
 {
  return CIPHERHtml.newAttr("fontStyle",stl);
 };
 CIPHERHtml._fontSize=function(siz)
 {
  return CIPHERHtml.newAttr("fontSize",siz);
 };
 CIPHERHtml._margin=function(mar)
 {
  return CIPHERHtml.newAttr("margin",mar);
 };
 CIPHERHtml._cursor=function(cur)
 {
  return CIPHERHtml.newAttr("cursor",cur);
 };
 CIPHERHtml._color=function(col)
 {
  return CIPHERHtml.newAttr("color",col);
 };
 CIPHERHtml.newAttr=function(name,value)
 {
  var a;
  a={};
  a[name]=value;
  return a;
 };
 CIPHERHtml.OnAfterRender=function(f)
 {
  return CIPHERHtml.Ref(function(e)
  {
   if(!(!e))
    f(e);
  });
 };
 CIPHERHtml.Ref=function(f)
 {
  return(CIPHERHtml.addAttribute())({
   $:2,
   $0:"ref",
   $1:f
  });
 };
 CIPHERHtml.OnKeyDown=function(f)
 {
  return(CIPHERHtml.addAttribute())({
   $:2,
   $0:"onKeyDown",
   $1:f
  });
 };
 CIPHERHtml.OnDragOver=function(f)
 {
  return(CIPHERHtml.addAttribute())({
   $:2,
   $0:"onDragOver",
   $1:f
  });
 };
 CIPHERHtml.OnDragStart=function(f)
 {
  return(CIPHERHtml.addAttribute())({
   $:2,
   $0:"onDragStart",
   $1:f
  });
 };
 CIPHERHtml.OnDrop=function(f)
 {
  return(CIPHERHtml.addAttribute())({
   $:2,
   $0:"onDrop",
   $1:f
  });
 };
 CIPHERHtml.OnMouseUp=function(f)
 {
  return(CIPHERHtml.addAttribute())({
   $:2,
   $0:"onMouseUp",
   $1:f
  });
 };
 CIPHERHtml.OnMouseMove=function(f)
 {
  return(CIPHERHtml.addAttribute())({
   $:2,
   $0:"onMouseMove",
   $1:f
  });
 };
 CIPHERHtml.OnMouseDown=function(f)
 {
  return(CIPHERHtml.addAttribute())({
   $:2,
   $0:"onMouseDown",
   $1:f
  });
 };
 CIPHERHtml.OnMouseOut=function(f)
 {
  return(CIPHERHtml.addAttribute())({
   $:2,
   $0:"onMouseOut",
   $1:f
  });
 };
 CIPHERHtml.OnMouseOver=function(f)
 {
  return(CIPHERHtml.addAttribute())({
   $:2,
   $0:"onMouseOver",
   $1:f
  });
 };
 CIPHERHtml.OnMouseLeave=function(f)
 {
  return(CIPHERHtml.addAttribute())({
   $:2,
   $0:"onMouseLeave",
   $1:f
  });
 };
 CIPHERHtml.OnMouseEnter=function(f)
 {
  return(CIPHERHtml.addAttribute())({
   $:2,
   $0:"onMouseEnter",
   $1:f
  });
 };
 CIPHERHtml.OnChange=function(f)
 {
  return(CIPHERHtml.addAttribute())({
   $:2,
   $0:"onChange",
   $1:f
  });
 };
 CIPHERHtml.OnSubmit=function(f)
 {
  return(CIPHERHtml.addAttribute())({
   $:2,
   $0:"onSubmit",
   $1:f
  });
 };
 CIPHERHtml.OnClick=function(f)
 {
  return(CIPHERHtml.addAttribute())({
   $:2,
   $0:"onClick",
   $1:f
  });
 };
 CIPHERHtml.Draggable=function(drg)
 {
  return{
   $:2,
   $0:"draggable",
   $1:drg
  };
 };
 CIPHERHtml.Checked=function(chk)
 {
  return{
   $:2,
   $0:"checked",
   $1:chk
  };
 };
 CIPHERHtml.MaxLength=function(len)
 {
  return{
   $:2,
   $0:"maxLength",
   $1:len
  };
 };
 CIPHERHtml.Placeholder=function(txt)
 {
  return{
   $:2,
   $0:"placeholder",
   $1:txt
  };
 };
 CIPHERHtml.Disabled=function(dis)
 {
  return{
   $:2,
   $0:"disabled",
   $1:dis
  };
 };
 CIPHERHtml.AutoFocus=function(foc)
 {
  return{
   $:2,
   $0:"autoFocus",
   $1:foc
  };
 };
 CIPHERHtml.TabIndex=function(idx)
 {
  return{
   $:2,
   $0:"tabIndex",
   $1:idx
  };
 };
 CIPHERHtml.Value=function(value)
 {
  return{
   $:2,
   $0:"value",
   $1:value
  };
 };
 CIPHERHtml.Type=function(typ)
 {
  return{
   $:2,
   $0:"type",
   $1:typ
  };
 };
 CIPHERHtml.Class=function(clas)
 {
  return{
   $:2,
   $0:"className",
   $1:clas
  };
 };
 CIPHERHtml.Style=function(style)
 {
  return{
   $:2,
   $0:"style",
   $1:style
  };
 };
 CIPHERHtml.Href=function(href)
 {
  return{
   $:2,
   $0:"href",
   $1:href
  };
 };
 CIPHERHtml.Src=function(src)
 {
  return{
   $:2,
   $0:"src",
   $1:src
  };
 };
 CIPHERHtml.Role=function(role)
 {
  return{
   $:2,
   $0:"role",
   $1:role
  };
 };
 CIPHERHtml.Key=function(key)
 {
  return{
   $:2,
   $0:"key",
   $1:key
  };
 };
 CIPHERHtml.Id=function(id$1)
 {
  return{
   $:2,
   $0:"id",
   $1:id$1
  };
 };
 CIPHERHtml.NewAttr=function(name,value)
 {
  return{
   $:2,
   $0:name,
   $1:value
  };
 };
 CIPHERHtml.NewTag=function(tag,children)
 {
  return CIPHERHtml.NElement(tag,children);
 };
 CIPHERHtml.Button=function(children)
 {
  return CIPHERHtml.NElement("button",children);
 };
 CIPHERHtml.OptionA=function(children)
 {
  return CIPHERHtml.NElement("option",children);
 };
 CIPHERHtml.Select=function(children)
 {
  return CIPHERHtml.NElement("select",children);
 };
 CIPHERHtml.Input=function(children)
 {
  return CIPHERHtml.NElement("input",children);
 };
 CIPHERHtml.Label=function(children)
 {
  return CIPHERHtml.NElement("label",children);
 };
 CIPHERHtml.B=function(children)
 {
  return CIPHERHtml.NElement("b",children);
 };
 CIPHERHtml.A=function(children)
 {
  return CIPHERHtml.NElement("a",children);
 };
 CIPHERHtml.P=function(children)
 {
  return CIPHERHtml.NElement("p",children);
 };
 CIPHERHtml.Td=function(children)
 {
  return CIPHERHtml.NElement("td",children);
 };
 CIPHERHtml.Tr=function(children)
 {
  return CIPHERHtml.NElement("tr",children);
 };
 CIPHERHtml.TBody=function(children)
 {
  return CIPHERHtml.NElement("tbody",children);
 };
 CIPHERHtml.Th=function(children)
 {
  return CIPHERHtml.NElement("th",children);
 };
 CIPHERHtml.THead=function(children)
 {
  return CIPHERHtml.NElement("thead",children);
 };
 CIPHERHtml.Table=function(children)
 {
  return CIPHERHtml.NElement("table",children);
 };
 CIPHERHtml.Br=function(children)
 {
  return CIPHERHtml.NElement("br",children);
 };
 CIPHERHtml.Hr=function(children)
 {
  return CIPHERHtml.NElement("hr",children);
 };
 CIPHERHtml.H6=function(children)
 {
  return CIPHERHtml.NElement("h6",children);
 };
 CIPHERHtml.H5=function(children)
 {
  return CIPHERHtml.NElement("h5",children);
 };
 CIPHERHtml.H4=function(children)
 {
  return CIPHERHtml.NElement("h4",children);
 };
 CIPHERHtml.H3=function(children)
 {
  return CIPHERHtml.NElement("h3",children);
 };
 CIPHERHtml.H2=function(children)
 {
  return CIPHERHtml.NElement("h2",children);
 };
 CIPHERHtml.H1=function(children)
 {
  return CIPHERHtml.NElement("h1",children);
 };
 CIPHERHtml.Li=function(children)
 {
  return CIPHERHtml.NElement("li",children);
 };
 CIPHERHtml.Ul=function(children)
 {
  return CIPHERHtml.NElement("ul",children);
 };
 CIPHERHtml.Img=function(children)
 {
  return CIPHERHtml.NElement("img",children);
 };
 CIPHERHtml.Form=function(children)
 {
  return CIPHERHtml.NElement("form",children);
 };
 CIPHERHtml.Menu=function(children)
 {
  return CIPHERHtml.NElement("menu",children);
 };
 CIPHERHtml.Span=function(children)
 {
  return CIPHERHtml.NElement("span",children);
 };
 CIPHERHtml.Div=function(children)
 {
  return CIPHERHtml.NElement("div",children);
 };
 CIPHERHtml.addAttribute=function()
 {
  SC$2.$cctor();
  return SC$2.addAttribute;
 };
 CIPHERHtml.addAttributes=function()
 {
  SC$2.$cctor();
  return SC$2.addAttributes;
 };
 CIPHERHtml.addChild=function(child)
 {
  var n;
  n=List.ofArray([child]);
  return function(n$1)
  {
   return CIPHERHtml.addChildren(n,n$1);
  };
 };
 CIPHERHtml.addChildren=function(newChildren,node)
 {
  return node.$==1?CIPHERHtml.NElement("div",Seq.append([node],newChildren)):node.$==2?CIPHERHtml.NElement("div",Seq.append([node],newChildren)):node.$==3?CIPHERHtml.NElement("div",Seq.append([node],newChildren)):node.$==4?node:node.$==5?node:node.$==6?node:node.$==7?node:node.$==8?CIPHERHtml.NElement("div",newChildren):CIPHERHtml.NElement(node.$0,Seq.append(node.$1,newChildren));
 };
 CIPHERHtml.insertChildren=function(newChildren,node)
 {
  return node.$==1?CIPHERHtml.NElement("div",Seq.append(newChildren,[node])):node.$==2?CIPHERHtml.NElement("div",Seq.append(newChildren,[node])):node.$==3?CIPHERHtml.NElement("div",Seq.append(newChildren,[node])):node.$==4?node:node.$==5?node:node.$==6?node:node.$==7?node:node.$==8?CIPHERHtml.NElement("div",newChildren):CIPHERHtml.NElement(node.$0,Seq.append(newChildren,node.$1));
 };
 CIPHERHtml.NElement=function(name,children)
 {
  return{
   $:0,
   $0:name,
   $1:Arrays.ofSeq(children)
  };
 };
 CIPHERHtml.callF=function(f,p1,p2)
 {
  return Runtime.CreateFuncWithArgs(f).apply(null,[p1,p2]);
 };
 SC$2.$cctor=Runtime.Cctor(function()
 {
  SC$2.addAttributes=function(n)
  {
   return function(n$1)
   {
    return CIPHERHtml.addChildren(n,n$1);
   };
  };
  SC$2.addAttribute=CIPHERHtml.addChild;
  SC$2.$cctor=window.ignore;
 });
 Dummy.New=function(dummy)
 {
  return{
   dummy:dummy
  };
 };
 MailboxState=App.MailboxState=Runtime.Class({
  setLatest:function(l)
  {
   this.latestModel=l;
   this.get_latest().__ref=this;
  },
  get_latest:function()
  {
   return this.latestModel;
  }
 },null,MailboxState);
 MailboxState.New=function(agent,count,latestModel)
 {
  return new MailboxState({
   agent:agent,
   count:count,
   latestModel:latestModel
  });
 };
 App$1=App.App=Runtime.Class({
  renderNodeIncDom:function(props)
  {
   var $this,anchor,mail;
   function forceUpdate()
   {
    CIPHERHtml.patchOuter(mail.element,function()
    {
     CIPHERHtml.toIncrementalDom(getCipherNode());
    });
   }
   function getCipherNode()
   {
    return(($this.view(props))(mail.get_latest()))(function(m)
    {
     $this.processMessages_(props,mail,forceUpdate,m);
    });
   }
   $this=this;
   anchor=CIPHERHtml.textIDom("");
   !anchor.state?anchor.state=App.mailbox(this.init,null):void 0;
   mail=anchor.state;
   mail.element=CIPHERHtml.toIncrementalDom(getCipherNode());
   return mail.element;
  },
  renderIncDom:function(props,container)
  {
   var $this,mail,forceUpdate,cipherNode;
   $this=this;
   !container.state?container.state=App.mailbox(this.init,null):void 0;
   mail=container.state;
   forceUpdate=function()
   {
    $this.renderIncDom(props,container);
   };
   cipherNode=((this.view(props))(mail.get_latest()))(function(m)
   {
    $this.processMessages_(props,mail,forceUpdate,m);
   });
   CIPHERHtml.patchInner(container,function()
   {
    CIPHERHtml.toIncrementalDom(cipherNode);
   });
  },
  renderReact:function(_this)
  {
   var $this,forceUpdate_,forceUpdate,mail,props;
   $this=this;
   forceUpdate_=_this.forceUpdate;
   forceUpdate=function()
   {
    forceUpdate_.apply(_this,[]);
   };
   mail=_this.state;
   props=_this.props;
   return CIPHERHtml.toReact(((this.view(props))(mail.get_latest()))(function(m)
   {
    $this.processMessages_(props,mail,forceUpdate,m);
   }));
  },
  processMessages_:function(props,mail,forceUpdate,msg)
  {
   var $this,_this,u;
   $this=this;
   _this=mail.agent;
   _this.mailbox.AddLast((u=(this.update(function(m)
   {
    $this.processMessages_(props,mail,forceUpdate,m);
   }))(props),function(o)
   {
    return $this.doMsg(mail,function($1,$2)
    {
     return(u($1))($2);
    },msg,forceUpdate,o);
   }));
   _this.resume();
  },
  doMsg:function(mail,update,msg,forceUpdate,oldState)
  {
   var p,m,newState;
   p=(m=update(msg,oldState),m.$==1?[m.$0,false]:m.$==2?[oldState,false]:[m.$0,true]);
   newState=p[0];
   mail.setLatest(newState);
   p[1]?forceUpdate():void 0;
   return newState;
  },
  run:function(props,container)
  {
   if(!window.IncrementalDOM)
    this.runReact(props,container);
   else
    this.runIncDom(props,container);
  },
  runReact:function(props,container)
  {
   ReactDOM.render(this.nodeR(props),container);
  },
  runIncDom:function(props,container)
  {
   this.renderIncDom(props,container);
  },
  node:function(props)
  {
   return{
    $:7,
    $0:this,
    $1:props
   };
  },
  nodeIncDom:function(props)
  {
   return this.renderNodeIncDom(props);
  },
  nodeR:function(props)
  {
   return React.createElement.apply(null,[this.reactClass,props]);
  },
  get_view:function()
  {
   return this.view;
  },
  get_update:function()
  {
   return this.update;
  },
  get_init:function()
  {
   return this.init;
  },
  CIPHERPrototype_CIPHERHtml_IUIApp$run:function(props,container)
  {
   this.run(props,container);
  },
  CIPHERPrototype_CIPHERHtml_IUIApp$nodeIncDom:function(props)
  {
   return this.nodeIncDom(props);
  },
  CIPHERPrototype_CIPHERHtml_IUIApp$nodeR:function(props)
  {
   return this.nodeR(props);
  }
 },null,App$1);
 App$1.New=Runtime.Ctor(function(init,update2,view)
 {
  App$1.New$2.call(this,init,Runtime.Curried(function($1,$2,msg,model)
  {
   return{
    $:0,
    $0:update2(msg,model)
   };
  },4),view);
 },App$1);
 App$1.New$1=Runtime.Ctor(function(init,update3,view)
 {
  App$1.New$2.call(this,init,Runtime.Curried(function($1,props,msg,model)
  {
   return{
    $:0,
    $0:update3(props,msg,model)
   };
  },4),view);
 },App$1);
 App$1.New$2=Runtime.Ctor(function(init,update,view)
 {
  var $this,i;
  $this=this;
  this.init=init;
  this.update=update;
  this.view=view;
  this.reactClass=React.createClass({
   displayName:"rootClass",
   getInitialState:(i=this.init,function()
   {
    return App.mailbox(i,void 0);
   }),
   render:function()
   {
    return $this.renderReact(this);
   }
  });
 },App$1);
 App.mailbox=function(init,u)
 {
  var mail,_this;
  App.set_mailboxes(App.mailboxes()+1);
  mail=MailboxState.New(MailboxProcessor.Start(function(inbox)
  {
   function messageLoop(oldState)
   {
    var b;
    b=null;
    return Concurrency.Delay(function()
    {
     return Concurrency.Bind(inbox.Receive(null),function(a)
     {
      return messageLoop(a(oldState));
     });
    });
   }
   return messageLoop(jQuery.extend("object",init));
  },null),App.mailboxes(),init);
  _this=mail.agent;
  _this.mailbox.AddLast(function(initState)
  {
   mail.setLatest(initState);
   return initState;
  });
  _this.resume();
  return mail;
 };
 App.mailboxes=function()
 {
  SC$3.$cctor();
  return SC$3.mailboxes;
 };
 App.set_mailboxes=function($1)
 {
  SC$3.$cctor();
  SC$3.mailboxes=$1;
 };
 App.withContainerDo=function(className,f)
 {
  return Doc.Element("div",[AttrProxy.Create("class",className),AttrModule.OnAfterRender(function(container)
  {
   f(container);
  })],[]);
 };
 App.DummyNew=function()
 {
  SC$3.$cctor();
  return SC$3.DummyNew;
 };
 SC$3.$cctor=Runtime.Cctor(function()
 {
  SC$3.DummyNew=Dummy.New(true);
  SC$3.mailboxes=0;
  SC$3.$cctor=window.ignore;
 });
 Props.New=function(nodeF,subscribe)
 {
  return{
   nodeF:nodeF,
   subscribe:subscribe
  };
 };
 Message.Dummy={
  $:0
 };
 DynNode.node=function(nodeF,sub)
 {
  return DynNode.app().node(Props.New(nodeF,sub));
 };
 DynNode.app=function()
 {
  SC$4.$cctor();
  return SC$4.app;
 };
 DynNode.view=function(props,model,processMessages)
 {
  props.subscribe(function()
  {
   processMessages(Message.Dummy);
  });
  return props.nodeF();
 };
 DynNode.update=function(props,msg,model)
 {
  return model;
 };
 DynNode.init=function()
 {
  SC$4.$cctor();
  return SC$4.init;
 };
 SC$4.$cctor=Runtime.Cctor(function()
 {
  SC$4.init=App.DummyNew();
  SC$4.app=new App$1.New$1(DynNode.init(),DynNode.update,Runtime.Curried3(DynNode.view));
  SC$4.$cctor=window.ignore;
 });
 Tube=DataTube.Tube=Runtime.Class({
  subCell:function(subKey)
  {
   return new Cell({
    $:0,
    $0:this,
    $1:List.ofArray([subKey])
   });
  },
  subscribe:function(kd,kl,f)
  {
   this.listeners=this.listeners.Add(kd,Option.defaultValue(new FSharpMap.New([]),Map.TryFind(kd,this.listeners)).Add(kl,f));
  },
  setData:function(key,v)
  {
   if(!Unchecked.Equals(this.getDataO(key),{
    $:1,
    $0:v
   }))
    this.setAndTrigger(key,v);
  },
  setDataO:function(key,vO)
  {
   if(!Unchecked.Equals(this.getDataO(key),vO))
    this.setAndTriggerO(key,vO);
  },
  setAndTrigger:function(key,v)
  {
   this.setAndTriggerO(key,{
    $:1,
    $0:v
   });
  },
  setAndTriggerO:function(key,vO)
  {
   var o,a;
   this.setOnlyO(key,vO);
   o=Map.TryFind(key,this.listeners);
   o==null?void 0:(a=function(a$1,f)
   {
    f(vO);
   },Seq.iter(function($1)
   {
    return a($1[0],$1[1]);
   },Map.ToSeq(o.$0)));
  },
  setOnlyO:function(key,vO)
  {
   if(vO!=null&&vO.$==1)
    this.setOnly(key,vO.$0);
   else
    this.remove(key);
  },
  setOnly:function(key,v)
  {
   this.data=this.data.Add(key,v);
  },
  remove:function(key)
  {
   this.data=this.data.Remove(key);
  },
  getDataO:function(key)
  {
   return Map.TryFind(key,this.data);
  }
 },null,Tube);
 Tube.New$1=function(id$1)
 {
  return Tube.New(id$1,new FSharpMap.New([]),new FSharpMap.New([]));
 };
 Tube.New=function(id$1,data,listeners)
 {
  return new Tube({
   id:id$1,
   data:data,
   listeners:listeners
  });
 };
 Cell=DataTube.Cell=Runtime.Class({
  subCell:function(subKey)
  {
   return new Cell({
    $:0,
    $0:this.$0,
    $1:new List.T({
     $:1,
     $0:subKey,
     $1:this.$1
    })
   });
  },
  subscribe:function(listenKey,f)
  {
   this.$0.subscribe(this.$1,listenKey,function(oO)
   {
    f(oO==null?null:{
     $:1,
     $0:oO.$0
    });
   });
  },
  setDataO:function(vO)
  {
   this.$0.setDataO(this.$1,vO==null?null:{
    $:1,
    $0:vO.$0
   });
  },
  setData:function(v)
  {
   this.$0.setData(this.$1,v);
  },
  setAndTrigger:function(v)
  {
   this.$0.setAndTrigger(this.$1,v);
  },
  setOnly:function(v)
  {
   this.$0.setOnly(this.$1,v);
  },
  getDataO:function()
  {
   var o;
   o=this.$0.getDataO(this.$1);
   return o==null?null:{
    $:1,
    $0:o.$0
   };
  }
 },null,Cell);
 DataTube.generalCell=function()
 {
  return Tube.New$1("X").subCell("V");
 };
}());
