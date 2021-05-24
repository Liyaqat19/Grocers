using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grocers.Models
{
    public class CustomerViewModel
    {
        public List<Customer> CustomerList{ get; set; }
        public List<SelectListItem> IntroducerList { get; set; }
        public List<SelectListItem> ParentList { get; set; }
    }
}