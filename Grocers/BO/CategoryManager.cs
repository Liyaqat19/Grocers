using Grocers.DbHelper;
using Grocers.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grocers.BO
{
    public class CategoryManager
    {
        DbManager dbmanager = new DbManager();
        public bool CreateOrUpdateCategory(Category category)
        {

            bool isSuccess = false;
            try
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("category_id", category.category_id);
                dic.Add("category_name", category.category_name);
                dic.Add("category_point",category.category_point);
                isSuccess = dbmanager.SaveOrUpdateData("sp_CreateOrUpdateCategory", dic);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSuccess;
        }

        public List<Category> GetCategoryList()
        {
            List<Category> categoryList = new List<Category>();
            DataSet ds = new DataSet();
            ds = dbmanager.GetData("sp_GetCategoryList");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Category category = new Category();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    category = new Category();
                    category.category_id = Convert.ToInt16(dr["category_id"]);
                    category.category_name = Convert.ToString(dr["category_name"]);
                    category.category_point =dr["category_point"]==DBNull.Value? 0: Convert.ToInt16(dr["category_point"]);
                    categoryList.Add(category);
                }
            }
            return categoryList;
        }
        public List<SelectListItem> GetCategoryDropDownList()
        {
            List<SelectListItem> categoryList = new List<SelectListItem>();
            DataSet ds = new DataSet();
            ds = dbmanager.GetData("sp_GetCategoryList");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                SelectListItem category = new SelectListItem();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    category = new SelectListItem();
                    category.Value = Convert.ToString(dr["category_id"]);
                    category.Text = Convert.ToString(dr["category_name"]);
                    categoryList.Add(category);
                }
            }
            return categoryList;
        }

        public bool SaveUOMMapping(CategoryUomMapping categoryUomMapping)
        {

            bool isSuccess = false;
            try
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("category_id", categoryUomMapping.category_id);
                dic.Add("uom_name", categoryUomMapping.uom_name);
                isSuccess = dbmanager.SaveOrUpdateData("sp_SaveUOMMapping", dic);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSuccess;
        }
        public List<CategoryUomMapping> GetCategoryUommappingList()
        {
            List<CategoryUomMapping> CategoryUomMappingList = new List<CategoryUomMapping>();
            DataSet ds = new DataSet();
            ds = dbmanager.GetData("sp_GetCategoryUommappingList");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                CategoryUomMapping categoryUomMapping = new CategoryUomMapping();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    categoryUomMapping = new CategoryUomMapping();
                    categoryUomMapping.uom_id = Convert.ToInt16(dr["uom_id"]);
                    categoryUomMapping.category_id = Convert.ToInt16(dr["category_id"]);
                    categoryUomMapping.CategoryName = Convert.ToString(dr["category_name"]);
                    categoryUomMapping.uom_name = Convert.ToString(dr["uom_name"]);
                    CategoryUomMappingList.Add(categoryUomMapping);
                }
            }
            return CategoryUomMappingList;
        }
        public List<SelectListItem> GetCategoryUommappingDropDownList(int category_id)
        {
            List<SelectListItem> CategoryUomMappingList = new List<SelectListItem>();
            DataSet ds = new DataSet();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("category_id", category_id);
            ds = dbmanager.GetData("sp_GetUOMListByCategoryId", dic);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                SelectListItem categoryUomMapping = new SelectListItem();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    categoryUomMapping = new SelectListItem();
                    categoryUomMapping.Value = Convert.ToString(dr["uom_id"]);
                    categoryUomMapping.Text = Convert.ToString(dr["uom_name"]);
                    CategoryUomMappingList.Add(categoryUomMapping);
                }
            }
            return CategoryUomMappingList;
        }
    }
}