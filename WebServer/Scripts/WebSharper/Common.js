(function()
{
 "use strict";
 var Global,Rop,Option,ExceptionThrown,ErrOptionIsNone,Result,ropBuilder,Wrap,Builder,SC$1,IntelliFactory,Runtime,WebSharper,PrintfHelpers,Operators,List,Strings,Seq,MatchFailureException,Concurrency;
 Global=window;
 Rop=Global.Rop=Global.Rop||{};
 Option=Rop.Option=Rop.Option||{};
 ExceptionThrown=Rop.ExceptionThrown=Rop.ExceptionThrown||{};
 ErrOptionIsNone=Rop.ErrOptionIsNone=Rop.ErrOptionIsNone||{};
 Result=Rop.Result=Rop.Result||{};
 ropBuilder=Result.ropBuilder=Result.ropBuilder||{};
 Wrap=Rop.Wrap=Rop.Wrap||{};
 Builder=Wrap.Builder=Wrap.Builder||{};
 SC$1=Global.StartupCode$Common$Result=Global.StartupCode$Common$Result||{};
 IntelliFactory=Global.IntelliFactory;
 Runtime=IntelliFactory&&IntelliFactory.Runtime;
 WebSharper=Global.WebSharper;
 PrintfHelpers=WebSharper&&WebSharper.PrintfHelpers;
 Operators=WebSharper&&WebSharper.Operators;
 List=WebSharper&&WebSharper.List;
 Strings=WebSharper&&WebSharper.Strings;
 Seq=WebSharper&&WebSharper.Seq;
 MatchFailureException=WebSharper&&WebSharper.MatchFailureException;
 Concurrency=WebSharper&&WebSharper.Concurrency;
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
  g=(v=Global.id,function(a)
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
  return((vO!=null?vO.$==1:false)?(fO!=null?fO.$==1:false)?($1=[fO.$0,vO.$0],true):false:false)?{
   $:1,
   $0:$1[0]($1[1])
  }:null;
 };
 Option.iterFO=function(vO,fO)
 {
  if(vO!=null?vO.$==1:false)
   if(fO!=null?fO.$==1:false)
    fO.$0(vO.$0);
 };
 Option.iterF=function(v,a)
 {
  if(a!=null?a.$==1:false)
   a.$0(v);
 };
 Option.call=function(v,a)
 {
  return(a!=null?a.$==1:false)?{
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
 ExceptionThrown=Rop.ExceptionThrown=Runtime.Class({
  Rop_ErrMsg$get_IsWarning:function()
  {
   return false;
  },
  Rop_ErrMsg$get_ErrMsg:function()
  {
   var f;
   f=function($1,$2)
   {
    return $1(PrintfHelpers.prettyPrint($2));
   };
   return(function($1)
   {
    return function($2)
    {
     return f($1,$2);
    };
   }(Global.id))(this.exn);
  }
 },null,ExceptionThrown);
 ExceptionThrown.New=Runtime.Ctor(function(exn)
 {
  this.exn=exn;
 },ExceptionThrown);
 ErrOptionIsNone=Rop.ErrOptionIsNone=Runtime.Class({
  Rop_ErrMsg$get_IsWarning:function()
  {
   return false;
  },
  Rop_ErrMsg$get_ErrMsg:function()
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
   return Operators.Using(disposable,restOfCExpr);
  },
  Bind:function(w,r)
  {
   return Result.bind(function(v)
   {
    return Result.tryCall(r,v);
   },w);
  },
  ReturnFrom:Global.id,
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
  var errors,p,warnings,p$1,f,s,m;
  return ms.$===0?"":(errors=(p=function(m$1)
  {
   return!m$1.Rop_ErrMsg$get_IsWarning();
  },function(l)
  {
   return List.filter(p,l);
  }(ms)),(warnings=(p$1=function(m$1)
  {
   return m$1.Rop_ErrMsg$get_IsWarning();
  },function(l)
  {
   return List.filter(p$1,l);
  }(ms)),(f=function($1,$2,$3,$4)
  {
   return $1(Global.String($2)+" errors, "+Global.String($3)+" warnings\n"+PrintfHelpers.toSafe($4));
  },((((Runtime.Curried(f,4))(Global.id))(errors.get_Length()))(warnings.get_Length()))((s=(m=function(m$1)
  {
   return m$1.Rop_ErrMsg$get_ErrMsg();
  },function(l)
  {
   return List.map(m,l);
  }(ms)),Strings.concat("\n",s))))));
 };
 Result.seqCheck=function(s)
 {
  var m,p,c,m$1;
  m=(p=function(a)
  {
   return Result.Success(a).$==1?true:false;
  },function(s$1)
  {
   return Seq.exists(p,s$1);
  }(s));
  return m?Result.failWithMsgs((c=function(a)
  {
   var a$1;
   a$1=Result.Success(a);
   return a$1.$==1?{
    $:1,
    $0:a$1.$0
   }:null;
  },function(s$1)
  {
   return Seq.pick(c,s$1);
  }(s))):Result.succeed((m$1=function(a)
  {
   var a$1;
   a$1=Result.Success(a);
   if(a$1.$==0)
    return a$1.$0[0];
   else
    throw new MatchFailureException.New("Result.fs",190,56);
  },function(s$1)
  {
   return Seq.map(m$1,s$1);
  }(s)));
 };
 Result.withError=function(f,a)
 {
  var o,ms,f$1;
  o=a.$0;
  ms=a.$1;
  f$1=function()
  {
   return f(ms);
  };
  return function(a$1)
  {
   return Option.defaultWith(f$1,a$1);
  }(o);
 };
 Result.ifError=function(def,a)
 {
  var o;
  o=a.$0;
  return Option.defaultValue(def,o);
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
  return(a!=null?a.$==1:false)?Result.succeed(a.$0):Result.fail(m);
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
  var fO,fMs,o,ms,$1,f,x;
  fO=a.$0;
  fMs=a.$1;
  o=a$1.$0;
  ms=a$1.$1;
  return((fO!=null?fO.$==1:false)?(o!=null?o.$==1:false)?($1=[fO.$0,o.$0],true):false:false)?(f=$1[0],(x=$1[1],{
   $:0,
   $0:{
    $:1,
    $0:f(x)
   },
   $1:List.append(fMs,ms)
  })):{
   $:0,
   $0:null,
   $1:List.append(fMs,ms)
  };
 };
 Result.bind=function(f,a)
 {
  var o,ms,x,m,o2,ms2;
  o=a.$0;
  ms=a.$1;
  return o==null?{
   $:0,
   $0:null,
   $1:ms
  }:(x=o.$0,(m=f(x),(o2=m.$0,(ms2=m.$1,{
   $:0,
   $0:o2,
   $1:List.append(ms,ms2)
  }))));
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
  var t,f;
  t=(f=function(l)
  {
   return List.append(ms,l);
  },function(a)
  {
   return Result.mapMsgs(f,a);
  }(r));
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
  var o,ms;
  o=a.$0;
  ms=a.$1;
  return[o,List.map(f,ms)];
 };
 Result.map=function(f,a)
 {
  var o,ms;
  o=a.$0;
  ms=a.$1;
  return{
   $:0,
   $0:o==null?null:{
    $:1,
    $0:f(o.$0)
   },
   $1:ms
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
  ReturnFrom:Global.id,
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
 Wrap.getAsyncWithDefault=function(f,wb)
 {
  return Concurrency.Delay(function()
  {
   var x;
   x=Wrap.getAsyncR(wb);
   return Concurrency.Bind(x,function(a)
   {
    return Concurrency.Return(Result.withError(f,a));
   });
  });
 };
 Wrap.getAsyncR=function(wb)
 {
  var v,v$1,va;
  return wb.$==3?(v=wb.$0,Concurrency.Return(Result.succeed(v))):wb.$==4?(v$1=wb.$0,Concurrency.Return(Result.fromOption(Wrap.errOptionIsNone(),v$1))):wb.$==0?Concurrency.Return(wb.$0):wb.$==2?wb.$0:(va=wb.$0,Concurrency.Delay(function()
  {
   return Concurrency.Bind(va,function(a)
   {
    return Concurrency.Return(Result.succeed(a));
   });
  }));
 };
 Wrap.getResult=function(callback,wb)
 {
  var s,ab,arb,s$1;
  if(wb.$==4)
  {
   if(wb.$0==null)
    callback(Result.fail(Wrap.errOptionIsNone()));
   else
    {
     s=wb.$0.$0;
     callback(Result.succeed(s));
    }
  }
  else
   if(wb.$==0)
    callback(wb.$0);
   else
    if(wb.$==1)
     {
      ab=wb.$0;
      Concurrency.StartWithContinuations(ab,function(v)
      {
       callback(Result.succeed(v));
      },function(exc)
      {
       callback(Result.fail(Result.failException(exc)));
      },function(can)
      {
       callback(Result.fail(Result.failException(can)));
      },null);
     }
    else
     if(wb.$==2)
      {
       arb=wb.$0;
       Concurrency.StartWithContinuations(arb,callback,function(exc)
       {
        callback(Result.fail(Result.failException(exc)));
       },function(can)
       {
        callback(Result.fail(Result.failException(can)));
       },null);
      }
     else
      {
       s$1=wb.$0;
       callback(Result.succeed(s$1));
      }
 };
 Wrap.wrapper=function()
 {
  SC$1.$cctor();
  return SC$1.wrapper;
 };
 Wrap.combine=function(errOptionIsNone,wa,wb)
 {
  var m,ms;
  return wa.$==4?wa.$0==null?(m=List.ofArray([errOptionIsNone]),function(w)
  {
   return Wrap.addMsgs(errOptionIsNone,m,w);
  }(wb)):wb:wa.$==0?wa.$0.$1.$==0?wb:(ms=wa.$0.$1,Wrap.addMsgs(errOptionIsNone,ms,wb)):wa.$==1?wb:wa.$==2?wb:wb;
 };
 Wrap.addMsgs=function(errOptionIsNone,ms,wb)
 {
  var $1,r;
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
      $0:(r=Result.fail(errOptionIsNone),Result.mergeMsgs(ms,r))
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
      $0:Concurrency.Delay(function()
      {
       return Concurrency.Bind($1,function(a)
       {
        return Concurrency.Return(Result.succeedWithMsgs(a,ms));
       });
      })
     };
     break;
    case 4:
     return{
      $:2,
      $0:Concurrency.Delay(function()
      {
       return Concurrency.Bind($1,function(a)
       {
        return Concurrency.Return(Result.mergeMsgs(ms,a));
       });
      })
     };
     break;
   }
 };
 Wrap.wrapper2Async=function(f,a)
 {
  var $1,wb,m,ms,ab;
  wb=Wrap.tryCall(f,a);
  switch(wb.$==4?0:wb.$==0?1:wb.$==1?2:wb.$==2?3:0)
  {
   case 0:
    m=List.T.Empty;
    return function(a$1)
    {
     return Wrap.wb2arb(m,a$1);
    }(wb);
    break;
   case 1:
    ms=wb.$0.$1;
    return Wrap.wb2arb(ms,wb);
    break;
   case 2:
    ab=wb.$0;
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
 Wrap.bind=function(f,wa)
 {
  var $1,a,a$1,ms;
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
    a$1=$1[0];
    ms=$1[1];
    return function(a$2)
    {
     var $2,a$3,b,m2;
     switch(a$2.$==3?($2=a$2.$0,0):a$2.$==0?(a$3=Result.Success(a$2.$0),a$3.$==1?($2=a$3.$0,2):a$3.$0[1].$==0?($2=a$3.$0[0],0):($2=[a$3.$0[0],a$3.$0[1]],1)):a$2.$==1?($2=a$2.$0,3):a$2.$==2?($2=a$2.$0,4):5)
     {
      case 0:
       return{
        $:0,
        $0:Result.succeedWithMsgs($2,ms)
       };
       break;
      case 1:
       b=$2[0];
       m2=$2[1];
       return{
        $:0,
        $0:Result.succeedWithMsgs(b,List.append(ms,m2))
       };
       break;
      case 2:
       return{
        $:0,
        $0:Result.failWithMsgs(List.append(ms,$2))
       };
       break;
      case 3:
       return{
        $:2,
        $0:Concurrency.Delay(function()
        {
         return Concurrency.Bind($2,function(a$4)
         {
          return Concurrency.Return(Result.succeedWithMsgs(a$4,ms));
         });
        })
       };
       break;
      case 4:
       return{
        $:2,
        $0:Concurrency.Delay(function()
        {
         return Concurrency.Bind($2,function(a$4)
         {
          return Concurrency.Return(Result.mergeMsgs(ms,a$4));
         });
        })
       };
       break;
      case 5:
       throw new MatchFailureException.New("Result.fs",238,40);
       return;
       break;
     }
    }(Wrap.tryCall(f,a$1));
    break;
   case 4:
    return{
     $:2,
     $0:Concurrency.Delay(function()
     {
      return Concurrency.Bind($1,function(a$2)
      {
       var x,m;
       x=Wrap.tryCall(f,a$2);
       m=List.T.Empty;
       return Wrap.wb2arb(m,x);
      });
     })
    };
    break;
   case 5:
    return{
     $:2,
     $0:Concurrency.Delay(function()
     {
      return Concurrency.Bind($1,function(a$2)
      {
       var a$3,ms$1,a$4,ms$2,a$5;
       a$3=Result.Success(a$2);
       return a$3.$==1?(ms$1=a$3.$0,Concurrency.Delay(function()
       {
        return Concurrency.Return(Result.failWithMsgs(ms$1));
       })):(a$4=a$3.$0[0],ms$2=a$3.$0[1],a$5=Wrap.tryCall(f,a$4),Wrap.wb2arb(ms$2,a$5));
      });
     })
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
  var $1;
  switch(a.$==2?($1=a.$0,1):a.$==0?($1=a.$0,2):a.$==3?($1=a.$0,3):a.$==4?a.$0==null?4:($1=a.$0.$0,3):($1=a.$0,0))
  {
   case 0:
    return Concurrency.Delay(function()
    {
     return Concurrency.Bind($1,function(a$1)
     {
      return Concurrency.Return(Result.succeedWithMsgs(a$1,ms));
     });
    });
    break;
   case 1:
    return Concurrency.Delay(function()
    {
     return Concurrency.Bind($1,function(a$1)
     {
      return Concurrency.Return(Result.mergeMsgs(ms,a$1));
     });
    });
    break;
   case 2:
    return Concurrency.Delay(function()
    {
     return Concurrency.Return(Result.mergeMsgs(ms,$1));
    });
    break;
   case 3:
    return Concurrency.Delay(function()
    {
     return Concurrency.Return(Result.succeedWithMsgs($1,ms));
    });
    break;
   case 4:
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
 SC$1.$cctor=Runtime.Cctor(function()
 {
  SC$1.result=new ropBuilder.New();
  SC$1.errOptionIsNone=new ErrOptionIsNone.New();
  SC$1.wrapper=new Builder.New();
  SC$1.$cctor=Global.ignore;
 });
}());
