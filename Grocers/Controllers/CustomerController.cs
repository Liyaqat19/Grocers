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
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        CustomerManager customerManager = new CustomerManager();
        Customer customer = new Customer();
        Common common = new Common();
        public ActionResult Index()
        {
            int sessionId=common.GetSession("customer_id");
            CustomerViewModel customerViewModel = customerManager.GetCustomerList(sessionId);
            
            return View(customerViewModel);
        }
        [HttpPost]
        public bool AddOrUpdateCustomer(Customer customer)
        {
            customer.created_by = common.GetSession("customer_id");
            return customerManager.AddOrUpdateCustomer(customer);
        }
        [HttpGet]
        public ActionResult GetCustomerDetailsById(int customer_id)
        {
            customer = new Customer();
            customer=customerManager.GetCustomerDetailsById(customer_id);
            return Json(new { success = true, data = customer },
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult CustomerPoints()
        {
            int sessionId = common.GetSession("customer_id");
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.IntroducerList = customerManager.GetCustomerListDropDown(sessionId);
            return View(customerViewModel);
        }
        [HttpGet]
        public ActionResult GetCustomerPoints(int customer_id)
        {
            CustomerPointDetails customerPointDetails = new CustomerPointDetails();
            customerPointDetails = customerManager.GetCustomerPointDetails(customer_id);
            return Json(new { success = true, data = customerPointDetails },
                JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public bool AddCustomerRedeemPoints(RedeemPoints redeemPoints)
        {
            return customerManager.AddRedeemPoints(redeemPoints);
        }
    }
}
