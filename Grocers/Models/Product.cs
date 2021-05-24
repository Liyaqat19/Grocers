using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocers.Models
{
    public class Product
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public int brand_id { get; set; }
        public int category_id { get; set; }
        public int uom_id { get; set; }
        public decimal cost_price { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_modified { get; set; }
        public int created_by { get; set; }
        public int modified_by { get; set; }

        public string category_name { get; set; }

        public string brand_name { get; set; }

        public string uom_name { get; set; }
    }
}