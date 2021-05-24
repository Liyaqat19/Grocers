using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocers.Models
{
    public class Staff
    {
        public int staff_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public bool active { get; set; }
        public int store_id { get; set; }
        public int manager_id { get; set; }
    }
}