using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocers.Models
{
    public class CurrentStock
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string brand_name { get; set; }
        public string category_name { get; set; }
        public string uom_name { get; set; }
        public int AllStock { get; set; }
        public int OrderedStock { get; set; }
        public int currentStock { get; set; }
    }
}