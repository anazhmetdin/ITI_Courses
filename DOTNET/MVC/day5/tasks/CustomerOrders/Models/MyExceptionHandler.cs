using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerOrders.Models
{
    public class UserNotFoundException: Exception
    {
    }
    public class MyExceptionHandler: HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is UserNotFoundException)
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result = new ViewResult()
                {
                    ViewName = "UserNotFound",
                };
            }

            base.OnException(filterContext);
        }
    }
}