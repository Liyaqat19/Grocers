using Grocers.BO;
using Grocers.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grocers.Controllers
{
    [CheckSession]
    [ExceptionLogging]
    public class HomeController : Controller
    {
        CustomerManager customerManager = new CustomerManager();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetGenealogy()
        {
            string customers = customerManager.GetGenealogyAll();
            return Json(customers, JsonRequestBehavior.AllowGet);  
        }
    }
}
