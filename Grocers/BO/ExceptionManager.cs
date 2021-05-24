using Grocers.DbHelper;
using Grocers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocers.BO
{
    public class ExceptionManager
    {
        DbManager dbmanager = new DbManager();
        public bool LogError(ExceptionDetails exceptionDetails)
        {
            bool isSuccess = false;
            try
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("exception_message", exceptionDetails.exception_message);
                dic.Add("stack_trace", exceptionDetails.stack_trace);
                dic.Add("controller_name", exceptionDetails.controller_name);
                dic.Add("action_name", exceptionDetails.action_name);
                dic.Add("exception_date", DateTime.Now);
                isSuccess = dbmanager.SaveOrUpdateData("sp_LogError", dic);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSuccess;
        }
    }
}