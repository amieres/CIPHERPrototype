(function()
{
 "use strict";
 var CIPHERPrototype,RemoteError,IntelliFactory,Runtime,PrintfHelpers;
 CIPHERPrototype=window.CIPHERPrototype=window.CIPHERPrototype||{};
 RemoteError=CIPHERPrototype.RemoteError=CIPHERPrototype.RemoteError||{};
 IntelliFactory=window.IntelliFactory;
 Runtime=IntelliFactory&&IntelliFactory.Runtime;
 PrintfHelpers=WebSharper&&WebSharper.PrintfHelpers;
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
   }(id))(this.$0);
  }
 },null,RemoteError);
}());
