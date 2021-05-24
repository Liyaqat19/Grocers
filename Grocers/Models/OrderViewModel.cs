using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grocers.Models
{
    public class OrderViewModel
    {
        public List<SelectListItem> StoreList { get; set; }
        public List<SelectListItem> CostumerList { get; set; }
        public List<Order> OrderList { get; set; }
        public List<SelectListItem> ProductList { get; set; }
        public List<OrderItem> orderItemList { get; set; }
    }
}