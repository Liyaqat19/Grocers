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
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager();
        //
        // GET: /Category/

        public ActionResult Index()
        {
            List<Category> categoryList = categoryManager.GetCategoryList();
            return View(categoryList);
        }
        public ActionResult CategoryUomMapping()
        {
            CategoryUomViewModel categoryUomViewModel = new CategoryUomViewModel();
            categoryUomViewModel.CategoryList = categoryManager.GetCategoryDropDownList();
            categoryUomViewModel.CategoryUomMappingList = categoryManager.GetCategoryUommappingList();
            return View(categoryUomViewModel);
        }
        [HttpPost]
        public bool CreateOrUpdateCategory(Category category)
        {
            return categoryManager.CreateOrUpdateCategory(category);
        }
        [HttpPost]
        public bool SaveUOMMapping(CategoryUomMapping categoryUomMapping)
        {
            return categoryManager.SaveUOMMapping(categoryUomMapping);
        }
        [HttpGet]
        public ActionResult GetUomDropDownList(int category_id)
        {
            List<SelectListItem> list=categoryManager.GetCategoryUommappingDropDownList(category_id);
            return Json(list, JsonRequestBehavior.AllowGet);  
        }
    }
}
