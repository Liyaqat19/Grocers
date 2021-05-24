using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grocers.Models
{
    public class StockViewModel
    {
        public List<SelectListItem> StoreList { get; set; }
        public List<SelectListItem> ProductList { get; set; }
        public List<Stock> StockList { get; set; }
        public List<CurrentStock> CurrentStockList { get; set; }
    }
}