using Grocers.BO;
using Grocers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grocers.DbHelper
{
    public class ExceptionLogging : FilterAttribute, IExceptionFilter  
    {
        ExceptionManager exceptionManager = new ExceptionManager();
        public void OnException(ExceptionContext filterContext)
        {
            ExceptionDetails exceptionDetails = new ExceptionDetails();
            exceptionDetails.exception_message = filterContext.Exception.Message;
            exceptionDetails.stack_trace = filterContext.Exception.StackTrace;
            exceptionDetails.controller_name = filterContext.RouteData.Values["controller"].ToString();
            exceptionDetails.action_name = filterContext.RouteData.Values["action"].ToString();

            exceptionManager.LogError(exceptionDetails);

        }  
    }
}