using Grocers.BO;
using Grocers.DbHelper;
using Grocers.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grocers.Controllers
{
    [ExceptionLogging]
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        CustomerManager customerManager = new CustomerManager();
        Common common = new Common();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Login");
        }
        public bool CheckLogin(Customer customer)
        {
            bool isExist = false;
            Customer customerResult = customerManager.GetCustomerDetailsByCustomerCodePassword(customer.customer_code, customer.password);
            if (customerResult != null)
            {
                if (customerResult.is_active)
                {
                    isExist = true;
                    common.SetSession("customer_id", customerResult.customer_id.ToString());
                    if (customerResult.is_admin)
                    {
                        common.SetSession("is_admin", "1");
                    }
                }
            }
            return isExist;
        }
    }
}
