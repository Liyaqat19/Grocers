using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocers.DbHelper
{
    public class Common
    {
        public void SetSession(string key, string value)
        {
            HttpContext.Current.Session[key] = value;
        }
        public int GetSession(string key)
        {
            int res = 0;
            if (HttpContext.Current.Session[key] != null)
            {
                res = Convert.ToInt16(HttpContext.Current.Session[key]);
            }
            return res;
        }
    }
}