using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocers.Models
{
    public class ExceptionDetails
    {
        public string exception_message { get; set; }
        public string stack_trace { get; set; }
        public string controller_name { get; set; }
        public string action_name { get; set; }
        public DateTime exception_date { get; set; }
    }
}