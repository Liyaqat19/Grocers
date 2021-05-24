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
    public class StoreController : Controller
    {
        StoreManager storeManager = new StoreManager();
        //
        // GET: /Store/

        public ActionResult Index()
        {
            List<Store> storeList = storeManager.GetStoreList();
            return View(storeList.AsEnumerable<Store>());
        }

        [HttpPost]
        public bool CreateOrUpdateStore(Store store)
        {
             return storeManager.CreateOrUpdateStore(store);
        }
    }
}
