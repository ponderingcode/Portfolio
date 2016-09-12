using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio
{
    public class UserActionFilter : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.IsAuthenticated = null != HttpContext.Current.User && HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
}