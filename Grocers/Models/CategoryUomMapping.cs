using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grocers.Models
{
    public class CategoryUomMapping
    {
        public int uom_id { get; set; }
        public int category_id { get; set; }
        public string uom_name { get; set; }
        public string CategoryName { get; set; }
    }
}