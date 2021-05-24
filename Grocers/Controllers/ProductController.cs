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
    public class ProductController : Controller
    {
        CategoryManager categoryManager = new CategoryManager();
        ProductManager productManager = new ProductManager();
        BrandManager brandManager = new BrandManager();
        //
        // GET: /Product/

        public ActionResult Index()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.BrandList = brandManager.GetBrandDropDownList();
            productViewModel.CategoryList = categoryManager.GetCategoryDropDownList();
            productViewModel.ProductList = productManager.GetProductList();
            return View(productViewModel);
        }
        [HttpPost]
        public bool CreateOrUpdateProduct(Product product)
        {
            return productManager.CreateOrUpdateProduct(product);
        }
        [HttpGet]
        public ActionResult GetProductPriceByProductId(int product_id)
        {
            decimal price = productManager.GetProductPriceByProductId(product_id);
            return Json(price, JsonRequestBehavior.AllowGet);  
        }
    }
}
