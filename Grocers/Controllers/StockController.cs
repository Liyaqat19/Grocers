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
    public class StockController : Controller
    {
        StockManager stockManager = new StockManager();
        ProductManager productManager = new ProductManager();
        StoreManager storeManager = new StoreManager();
        //
        // GET: /Stock/

        public ActionResult Index()
        {
            StockViewModel stockViewModel = new StockViewModel();
            stockViewModel.ProductList = productManager.GetProductDropDownList();
            stockViewModel.StoreList = storeManager.GetStoreDropDownList();
            stockViewModel.StockList = stockManager.GetStockList();
            return View(stockViewModel);
        }
        [HttpPost]
        public bool CreateStock(Stock stock)
        {
            return stockManager.CreateStock(stock);
        }
        public ActionResult CurrentStock()
        {
            List<CurrentStock> currentStockList = stockManager.GetCurrentStockList();
            return View(currentStockList);
        }
    }
}
