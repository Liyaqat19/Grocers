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
    public class BrandManager
    {
        DbManager dbmanager = new DbManager();
        public bool CreateOrUpdateBrand(Brand brand)
        {

            bool isSuccess = false;
            try
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("brand_id", brand.brand_id);
                dic.Add("brand_name", brand.brand_name);
                isSuccess = dbmanager.SaveOrUpdateData("sp_CreateOrUpdateBrand", dic);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSuccess;
        }

        public List<Brand> GetBrandList()
        {
            List<Brand> brandList = new List<Brand>();
            DataSet ds = new DataSet();
            ds = dbmanager.GetData("sp_GetBrandList");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Brand brand = new Brand();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    brand = new Brand();
                    brand.brand_id = Convert.ToInt16(dr["brand_id"]);
                    brand.brand_name = Convert.ToString(dr["brand_name"]);
                    brandList.Add(brand);
                }
            }
            return brandList;
        }
        public List<SelectListItem> GetBrandDropDownList()
        {
            List<SelectListItem> brandList = new List<SelectListItem>();
            DataSet ds = new DataSet();
            ds = dbmanager.GetData("sp_GetBrandList");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                SelectListItem brand = new SelectListItem();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    brand = new SelectListItem();
                    brand.Value = Convert.ToString(dr["brand_id"]);
                    brand.Text = Convert.ToString(dr["brand_name"]);
                    brandList.Add(brand);
                }
            }
            return brandList;
        }
    }
}