using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocers.Models
{
    public class OrderItem
    {
        public int item_id { get; set; }
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public decimal selling_price { get; set; }
        public decimal discount { get; set; }
        public decimal total { get; set; }
        public string product_name { get; set; }
        public decimal productAmount { get; set; }
    }
}