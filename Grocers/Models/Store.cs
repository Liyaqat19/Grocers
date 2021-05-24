using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocers.Models
{
    public class Store
    {
        public int store_id { get; set; }
        public string store_name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string store_address { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_modified { get; set; }
        public int created_by { get; set; }
        public int modified_by { get; set; }
        public bool isActive { get; set; }
    }
}