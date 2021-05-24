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
    public class StoreManager
    {
        DbManager dbmanager = new DbManager();
        public bool CreateOrUpdateStore(Store store)
        {

            bool isSuccess = false;
            try
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("store_id", store.store_id);
                dic.Add("store_name", store.store_name);
                dic.Add("phone", store.phone);
                dic.Add("email", store.email);
                dic.Add("store_address", store.store_address);
                isSuccess = dbmanager.SaveOrUpdateData("sp_CreateOrUpdateStore", dic);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSuccess;
        }

        public List<Store> GetStoreList()
        {
            List<Store> storeList = new List<Store>();
            DataSet ds = new DataSet();
            ds = dbmanager.GetData("sp_GetStoreList");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Store store = new Store();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    store = new Store();
                    store.store_id = Convert.ToInt16(dr["store_id"]);
                    store.store_name = Convert.ToString(dr["store_name"]);
                    store.phone = Convert.ToString(dr["phone"]);
                    store.email = Convert.ToString(dr["email"]);
                    store.store_address = Convert.ToString(dr["store_address"]);
                    storeList.Add(store);
                }
            }
            return storeList;
        }
        public List<SelectListItem> GetStoreDropDownList()
        {
            List<SelectListItem> storeList = new List<SelectListItem>();
            DataSet ds = new DataSet();
            ds = dbmanager.GetData("sp_GetStoreList");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                SelectListItem store = new SelectListItem();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    store = new SelectListItem();
                    store.Value = Convert.ToString(dr["store_id"]);
                    store.Text = Convert.ToString(dr["store_name"]);
                    storeList.Add(store);
                }
            }
            return storeList;
        }
    }
}