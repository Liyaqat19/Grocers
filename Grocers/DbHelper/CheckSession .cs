using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Grocers.DbHelper
{
    public class CheckSession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ctx = filterContext.HttpContext;
            if ((ctx.Session["customer_id"] == null))
            {
                if (ctx.Request.IsAjaxRequest())
                {
                    ctx.Response.Clear();
                    ctx.Response.StatusCode = 500;


                    filterContext.Result = new RedirectToRouteResult(
                               new System.Web.Routing.RouteValueDictionary
                                {
                                    {"action", "Login"},
                                    {"controller", "Account"}
                                });
                }
                //if Session == null => Login page
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Login", controller = "Account" }));

                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}