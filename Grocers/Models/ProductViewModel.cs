using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grocers.Models
{
    public class ProductViewModel
    {
        public List<SelectListItem> CategoryList { get; set; }
        public List<SelectListItem> BrandList { get; set; }
        public List<Product> ProductList { get; set; }
    }
}