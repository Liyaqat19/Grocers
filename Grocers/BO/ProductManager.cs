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
    public class ProductManager
    {
        DbManager dbmanager = new DbManager();
        public bool CreateOrUpdateProduct(Product product)
        {

            bool isSuccess = false;
            try
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("product_id", product.product_id);
                dic.Add("product_name", product.product_name);
                dic.Add("brand_id", product.brand_id);
                dic.Add("category_id", product.category_id);
                dic.Add("uom_id", product.uom_id);
                dic.Add("cost_price", product.cost_price);
                isSuccess = dbmanager.SaveOrUpdateData("sp_CreateOrUpdateProduct", dic);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSuccess;
        }
        public List<Product> GetProductList()
        {
            List<Product> productList = new List<Product>();
            DataSet ds = new DataSet();
            ds = dbmanager.GetData("sp_GetProductList");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Product product = new Product();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    product = new Product();
                    product.product_id = Convert.ToInt16(dr["product_id"]);
                    product.product_name = Convert.ToString(dr["product_name"]);
                    product.category_id = Convert.ToInt16(dr["category_id"]);
                    product.category_name = Convert.ToString(dr["category_name"]);
                    product.brand_id = Convert.ToInt16(dr["brand_id"]);
                    product.brand_name = Convert.ToString(dr["brand_name"]);
                    product.uom_id = Convert.ToInt16(dr["uom_id"]);
                    product.uom_name = Convert.ToString(dr["uom_name"]);
                    product.cost_price = Convert.ToDecimal(dr["cost_price"]);
                    productList.Add(product);
                }
            }
            return productList;
        }
        public List<SelectListItem> GetProductDropDownList()
        {
            List<SelectListItem> productList = new List<SelectListItem>();
            DataSet ds = new DataSet();
            ds = dbmanager.GetData("sp_GetProductList");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                SelectListItem product = new SelectListItem();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    product = new SelectListItem();
                    product.Value = Convert.ToString(dr["product_id"]);
                    product.Text = Convert.ToString(dr["FullProductName"]);
                    productList.Add(product);
                }
            }
            return productList;
        }
        public decimal GetProductPriceByProductId(int product_id)
        {
            decimal cost_price = 0;
            DataSet ds = new DataSet();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("product_id", product_id);
            ds = dbmanager.GetData("sp_GetProductPriceByProductId", dic);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                cost_price = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
            }
            return cost_price;
        }
    }

}