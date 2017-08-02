(function()
{
 "use strict";
 var Rop,Option,ExceptionThrown,ErrOptionIsNone,Result,ropBuilder,Wrap,Builder,SC$1,IntelliFactory,Runtime,WebSharper,PrintfHelpers,List,Strings,Seq,MatchFailureException,Concurrency;
 Rop=window.Rop=window.Rop||{};
 Option=Rop.Option=Rop.Option||{};
 ExceptionThrown=Rop.ExceptionThrown=Rop.ExceptionThrown||{};
 ErrOptionIsNone=Rop.ErrOptionIsNone=Rop.ErrOptionIsNone||{};
 Result=Rop.Result=Rop.Result||{};
 ropBuilder=Result.ropBuilder=Result.ropBuilder||{};
 Wrap=Rop.Wrap=Rop.Wrap||{};
 Builder=Wrap.Builder=Wrap.Builder||{};
 SC$1=window.StartupCode$Common$Result=window.StartupCode$Common$Result||{};
 IntelliFactory=window.IntelliFactory;
 Runtime=IntelliFactory&&IntelliFactory.Runtime;
 WebSharper=window.WebSharper;
 PrintfHelpers=WebSharper&&WebSharper.PrintfHelpers;
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
 ExceptionThrown=Rop.ExceptionThrown=Runtime.Class({
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
     return $1(PrintfHelpers.prettyPrint($2));
    };
   }(window.id))(this.exn);
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
   return!m.Rop_ErrMsg$get_IsWarning();
  },ms),(warnings=List.filter(function(m)
  {
   return m.Rop_ErrMsg$get_IsWarning();
  },ms),((((Runtime.Curried(function($1,$2,$3,$4)
  {
   return $1(window.String($2)+" errors, "+window.String($3)+" warnings\n"+PrintfHelpers.toSafe($4));
  },4))(window.id))(errors.get_Length()))(warnings.get_Length()))(Strings.concat("\n",List.map(function(m)
  {
   return m.Rop_ErrMsg$get_ErrMsg();
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
   var a$1;
   a$1=Result.Success(a);
   if(a$1.$==0)
    return a$1.$0[0];
   else
    throw new MatchFailureException.New("Result.fs",190,56);
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
     switch(a$1.$==3?($2=a$1.$0,0):a$1.$==0?(a$2=Result.Success(a$1.$0),a$2.$==1?($2=a$2.$0,2):a$2.$0[1].$==0?($2=a$2.$0[0],0):($2=[a$2.$0[0],a$2.$0[1]],1)):a$1.$==1?($2=a$1.$0,3):a$1.$==2?($2=a$1.$0,4):5)
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
        $0:Result.succeedWithMsgs($2[0],List.append(ms,$2[1]))
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
        $0:(b$2=null,Concurrency.Delay(function()
        {
         return Concurrency.Bind($2,function(a$3)
         {
          return Concurrency.Return(Result.succeedWithMsgs(a$3,ms));
         });
        }))
       };
       break;
      case 4:
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
      case 5:
       throw new MatchFailureException.New("Result.fs",238,40);
       return;
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
 SC$1.$cctor=Runtime.Cctor(function()
 {
  SC$1.result=new ropBuilder.New();
  SC$1.errOptionIsNone=new ErrOptionIsNone.New();
  SC$1.wrapper=new Builder.New();
  SC$1.$cctor=window.ignore;
 });
}());
