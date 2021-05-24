using Grocers.BO;
using Grocers.DbHelper;
using Grocers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grocers.Controllers
{
    [CheckSession]
    [ExceptionLogging]
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        StoreManager storeManager = new StoreManager();
        OrderManager orderManager = new OrderManager();
        ProductManager productManager = new ProductManager();
        CustomerManager customerManager = new CustomerManager();
        Common common = new Common();

        public ActionResult Index()
        {
            int customer_id = common.GetSession("customer_id");
            OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.OrderList = orderManager.GetOrderList();
            orderViewModel.StoreList = storeManager.GetStoreDropDownList();
            orderViewModel.CostumerList = customerManager.GetCustomerListDropDown(customer_id);
            orderViewModel.ProductList = productManager.GetProductDropDownList();
            List<OrderItem> orderItemList = new List<OrderItem>();
            OrderItem orderitem= new OrderItem();
            orderItemList.Add(orderitem);
            orderViewModel.orderItemList = orderItemList;
            return View(orderViewModel);
        }
        [HttpPost]
        public bool CreateOrder(Order order)
        {
            return orderManager.CreateOrder(order);
        }
        [HttpGet]
        public ActionResult _orderDetails(int order_id)
        {
            List<OrderItem> orderItemlist =orderManager.GetOrderDetails(order_id);
            return PartialView("_orderDetails",orderItemlist.AsEnumerable<OrderItem>());
        }
        [HttpGet]
        public int GetProductCurrentStock(int product_id)
        {
            int r = orderManager.GetProductCurrentStock(product_id);
            return r;
        }
    }
}
