(function()
{
 "use strict";
 var Global,CIPHERPrototype,RemoteError,IntelliFactory,Runtime,WebSharper,PrintfHelpers;
 Global=window;
 CIPHERPrototype=Global.CIPHERPrototype=Global.CIPHERPrototype||{};
 RemoteError=CIPHERPrototype.RemoteError=CIPHERPrototype.RemoteError||{};
 IntelliFactory=Global.IntelliFactory;
 Runtime=IntelliFactory&&IntelliFactory.Runtime;
 WebSharper=Global.WebSharper;
 PrintfHelpers=WebSharper&&WebSharper.PrintfHelpers;
 RemoteError=CIPHERPrototype.RemoteError=Runtime.Class({
  Rop_ErrMsg$get_IsWarning:function()
  {
   return false;
  },
  Rop_ErrMsg$get_ErrMsg:function()
  {
   var s,f;
   s=this.$0;
   f=function($1,$2)
   {
    return $1("Login Failed "+PrintfHelpers.toSafe($2));
   };
   return(function($1)
   {
    return function($2)
    {
     return f($1,$2);
    };
   }(Global.id))(s);
  }
 },null,RemoteError);
}());
