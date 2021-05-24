using Grocers.DbHelper;
using Grocers.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Grocers.BO
{
    public class StockManager
    {
        DbManager dbmanager = new DbManager();
        public bool CreateStock(Stock stock)
        {

            bool isSuccess = false;
            try
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("store_id", stock.store_id);
                dic.Add("product_id", stock.product_id);
                dic.Add("quantity", stock.quantity);
                dic.Add("cost_price", stock.cost_price);
                isSuccess = dbmanager.SaveOrUpdateData("sp_CreateStock", dic);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSuccess;
        }

        public List<Stock> GetStockList()
        {
            List<Stock> stockList = new List<Stock>();
            DataSet ds = new DataSet();
            ds = dbmanager.GetData("sp_GetStockList");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Stock stock = new Stock();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    stock = new Stock();
                    stock.store_id = Convert.ToInt16(dr["store_id"]);
                    stock.product_id = Convert.ToInt16(dr["product_id"]);
                    stock.product_name = Convert.ToString(dr["product_name"]);
                    stock.store_name = Convert.ToString(dr["store_name"]);
                    stock.quantity = Convert.ToInt16(dr["quantity"]);
                    stock.date_created = Convert.ToDateTime(dr["date_created"]);
                    stock.cost_price = Convert.ToDecimal(dr["cost_price"]);
                    stockList.Add(stock);
                }
            }
            return stockList;
        }

        public List<CurrentStock> GetCurrentStockList()
        {
            List<CurrentStock> currentStockList = new List<CurrentStock>();
            DataSet ds = new DataSet();
            ds = dbmanager.GetData("sp_GetCurrentStock");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                CurrentStock currentStock = new CurrentStock();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    currentStock = new CurrentStock();
                    currentStock.product_id = Convert.ToInt16(dr["product_id"]);
                    currentStock.product_name = Convert.ToString(dr["product_name"]);
                    currentStock.brand_name = Convert.ToString(dr["brand_name"]);
                    currentStock.category_name = Convert.ToString(dr["category_name"]);
                    currentStock.uom_name = Convert.ToString(dr["uom_name"]);
                    currentStock.AllStock =dr["PreviousStock"]==DBNull.Value ? 0: Convert.ToInt16(dr["PreviousStock"]);
                    currentStock.OrderedStock = dr["OrderedStock"] == DBNull.Value ? 0 : Convert.ToInt16(dr["OrderedStock"]);
                    currentStock.currentStock = dr["CurrentStock"] == DBNull.Value ? 0 : Convert.ToInt16(dr["CurrentStock"]);
                    currentStockList.Add(currentStock);
                }
            }
            return currentStockList;
        }
    }
}