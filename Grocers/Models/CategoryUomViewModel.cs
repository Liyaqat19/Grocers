using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grocers.Models
{
    public class CategoryUomViewModel
    {
        public List<SelectListItem> CategoryList { get; set; }
        public List<CategoryUomMapping> CategoryUomMappingList { get; set; }
    }
}