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
    public class BrandController : Controller
    {
        BrandManager brandManager = new BrandManager();
        //
        // GET: /Brand/

        public ActionResult Index()
        {
            List<Brand> brandList = brandManager.GetBrandList();
            return View(brandList);
        }
        [HttpPost]
        public bool CreateOrUpdateBrand(Brand brand)
        {
            return brandManager.CreateOrUpdateBrand(brand);
        }

    }
}
