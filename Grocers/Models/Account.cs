using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocers.Models
{
    public class Account
    {
        public string customer_code { get; set; }
        public string password { get; set; }
        public int IsExists { get; set; }
    }
}