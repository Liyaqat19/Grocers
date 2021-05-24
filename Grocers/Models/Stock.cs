using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocers.Models
{
    public class Stock
    {
        public int store_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public string product_name { get; set; }
        public string store_name { get; set; }
        public DateTime date_created { get; set; }
        public decimal cost_price { get; set; }
    }
}