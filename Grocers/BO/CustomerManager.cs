using Grocers.DbHelper;
using Grocers.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Grocers.BO
{
    public class CustomerManager
    {
        DbManager dbmanager = new DbManager();
        Common common = new Common();
        public CustomerViewModel GetCustomerList(int customer_id)
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            List<SelectListItem> introducerList = new List<SelectListItem>();
            List<Customer> customerList = new List<Customer>();
            List<SelectListItem> parentList = new List<SelectListItem>();
            DataSet ds = new DataSet();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("customer_id",customer_id);
            ds = dbmanager.GetData("usp_GetAllCustomers", dic);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                SelectListItem customerItem = new SelectListItem();
                Customer customer = new Customer();
                int session_id = common.GetSession("customer_id");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int childCount = Convert.ToInt16(dr["ChildCount"]);
                    customerItem = new SelectListItem();
                    customerItem.Value = Convert.ToString(dr["customer_id"]);
                    customerItem.Text = Convert.ToString(dr["customer_name"]) + " (" + Convert.ToString(dr["customer_code"]) + ")";
                    introducerList.Add(customerItem);
                    if (childCount < 5)
                    {
                        customerItem = new SelectListItem();
                        customerItem.Value = Convert.ToString(dr["customer_id"]);
                        customerItem.Text = Convert.ToString(dr["customer_name"]) +" ("+Convert.ToString(dr["customer_code"])+")";
                        parentList.Add(customerItem);
                    }
                    customer = new Customer();
                    customer.customer_id = Convert.ToInt16(dr["customer_id"]);
                    customer.customer_code = Convert.ToString(dr["customer_code"]);
                    customer.customer_name = Convert.ToString(dr["customer_name"]);
                    customer.mobile_number = Convert.ToString(dr["mobile_number"]);
                    if(dr["dob"]!=DBNull.Value)
                    {
                        Convert.ToDateTime(dr["dob"]);
                    }
                    //customer.dob =dr["dob"]!=DBNull.Value?Convert.ToDateTime(dr["dob"]);
                    customer.parent_id = Convert.ToInt16(dr["parent_id"]);
                    customer.is_active = Convert.ToBoolean(dr["is_active"]);
                    customer.is_admin = Convert.ToBoolean(dr["is_admin"]);
                    customer.introducer_id = Convert.ToInt16(dr["introducer_id"]);
                    customer.IntroducerName = Convert.ToString(dr["IntroducerName"]);
                    customer.ChildCount = childCount;
                    if (customer.customer_id != session_id)
                    customerList.Add(customer);
                }
                customerViewModel.IntroducerList = introducerList;
                customerViewModel.CustomerList = customerList;
                customerViewModel.ParentList = parentList;
            }
            return customerViewModel;
        }

        public Customer GetCustomerDetailsById(int customer_id)
        {
            Customer customer = new Customer();
            DataSet ds = new DataSet();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("customer_id", customer_id);
            ds = dbmanager.GetData("sp_GetCustomerDetailsById", dic);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    customer.customer_name = Convert.ToString(dr["customer_name"]);
                    customer.password = Convert.ToString(dr["password"]);
                    customer.mobile_number = Convert.ToString(dr["mobile_number"]);
                    if (dr["dob"] != DBNull.Value)
                    {
                        customer.dobString = Convert.ToDateTime(dr["dob"]).ToString("dd/MM/yyyy");
                    }
                    //customer.dob = Convert.ToDateTime(dr["dob"]);
                    customer.occupation = Convert.ToInt16(dr["occupation"]);
                    customer.introducer_id = Convert.ToInt16(dr["introducer_id"]);
                    customer.parent_id = Convert.ToInt16(dr["parent_id"]);
                    customer.is_active = Convert.ToBoolean(dr["is_active"]);
                    customer.ParentName = Convert.ToString(dr["ParentName"]);
                    customer.IntroducerName = Convert.ToString(dr["IntroducerName"]);
                }
            }
            return customer;
        }

        public Customer GetCustomerDetailsByCustomerCodePassword(string customer_code,string password)
        {
            Customer customer = new Customer();
            DataSet ds = new DataSet();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("customer_code", customer_code);
            dic.Add("password", password);
            ds = dbmanager.GetData("sp_Checklogin", dic);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                customer.customer_id = Convert.ToInt16(ds.Tables[0].Rows[0]["customer_id"]);
                customer.customer_code = Convert.ToString(ds.Tables[0].Rows[0]["customer_code"]);
                customer.is_active = Convert.ToBoolean(ds.Tables[0].Rows[0]["is_active"]);
                customer.is_admin = Convert.ToBoolean(ds.Tables[0].Rows[0]["is_admin"]);
            }
            return customer;
        }

        public List<SelectListItem> GetCustomerListDropDown(int customer_id)
        {
            List<SelectListItem> introducerList = new List<SelectListItem>();
            DataSet ds = new DataSet();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("customer_id", customer_id);
            ds = dbmanager.GetData("[usp_GetAllCustomers]", dic);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                SelectListItem customerItem = new SelectListItem();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    customerItem = new SelectListItem();
                    customerItem.Value = Convert.ToString(dr["customer_id"]);
                    customerItem.Text = Convert.ToString(dr["customer_name"]) + " (" + Convert.ToString(dr["customer_code"])+ ")";
                    introducerList.Add(customerItem);
                }
            }
            return introducerList;
        }

        public bool AddOrUpdateCustomer(Customer customer)
        {

            bool isSuccess = false;
            try
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("customer_id", customer.customer_id);
                dic.Add("customer_name", customer.customer_name);
                dic.Add("mobile_number", customer.mobile_number);
                dic.Add("dob", customer.dob ?? null);
                dic.Add("password", customer.password);
                dic.Add("is_active", customer.is_active);
                dic.Add("is_admin", customer.is_admin);
                dic.Add("introducer_id", customer.introducer_id);
                dic.Add("created_by", customer.created_by);
                dic.Add("parent_id", customer.parent_id);
                dic.Add("occupation", customer.occupation);
                isSuccess = dbmanager.SaveOrUpdateData("usp_AddOrUpdateCustomer", dic);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSuccess;
        }

        public string GetGenealogyAll()
        {
            string json = "";
            try
            {
                int introducer_id=common.GetSession("customer_id");
                Dictionary<string, object> _parameters = new Dictionary<string, object>();
                DataSet ds = new DataSet();

                _parameters.Add("IntroducerId", introducer_id);
                ds = dbmanager.GetData("usp_GetGenealogy", _parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    List<CustomerNode> customerNodeList = new List<CustomerNode>();
                    customerNodeList = ConvertDataTable<CustomerNode>(ds.Tables[0]);

                    json = JsonConvert.SerializeObject(customerNodeList).ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return json;
        }

        public List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        public CustomerPointDetails GetCustomerPointDetails(int customer_id)
        {
            CustomerPointDetails customerPointDetails = new CustomerPointDetails();
            List<RedeemPoints> redeemPointsList = new List<RedeemPoints>();
            List<string> leftChildren = new List<string>();
            List<string> rightChildren = new List<string>();
            DataSet ds = new DataSet();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("customer_id", customer_id);
            ds = dbmanager.GetData("usp_GetCustomerPoints", dic);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        leftChildren.Add(Convert.ToString(dr["customer_name"]));
                    }
                    customerPointDetails.LeftChildren = leftChildren;
                }
                
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        rightChildren.Add(Convert.ToString(dr["customer_name"]));
                    }
                    customerPointDetails.RightChildren = rightChildren;
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    customerPointDetails.LeftTotalPoints = ds.Tables[2].Rows[0]["LeftTotalPoints"] == DBNull.Value ? 0 : Convert.ToInt16(ds.Tables[2].Rows[0]["LeftTotalPoints"]);
                    customerPointDetails.RightTotalPoints =ds.Tables[2].Rows[0]["RightTotalPoints"]==DBNull.Value? 0: Convert.ToInt16(ds.Tables[2].Rows[0]["RightTotalPoints"]);
                    customerPointDetails.CustomerMatchedPoints =ds.Tables[2].Rows[0]["CustomerMatchedPoints"]==DBNull.Value? 0: Convert.ToInt16(ds.Tables[2].Rows[0]["CustomerMatchedPoints"]);
                    customerPointDetails.CustomerOwnPoints = ds.Tables[2].Rows[0]["CustomerOwnPoints"]==DBNull.Value? 0: Convert.ToInt16(ds.Tables[2].Rows[0]["CustomerOwnPoints"]);
                    customerPointDetails.TotalPoints = ds.Tables[2].Rows[0]["TotalPoints"] == DBNull.Value ? 0 : Convert.ToInt16(ds.Tables[2].Rows[0]["TotalPoints"]);
                    customerPointDetails.RedeemedPoints = ds.Tables[2].Rows[0]["sum_redeem_point"] == DBNull.Value ? 0 : Convert.ToInt16(ds.Tables[2].Rows[0]["sum_redeem_point"]);
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[3].Rows)
                    {
                        RedeemPoints redeemPoints = new RedeemPoints();
                        redeemPoints.redeem_points = Convert.ToInt16(dr["redeem_points"]);
                        redeemPoints.redeem_date = Convert.ToDateTime(dr["redeem_date"]).ToString("dd/MM/yyyy");
                        redeemPointsList.Add(redeemPoints);
                    }
                    customerPointDetails.redeemDetails = redeemPointsList;
                }
            }
            return customerPointDetails;
        }
        public bool AddRedeemPoints(RedeemPoints redeemPoints)
        {
            bool is_success = false;
            try
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("customer_id", redeemPoints.customer_id);
                dic.Add("redeem_points", redeemPoints.redeem_points);
                dic.Add("redeem_date", DateTime.Now );
                is_success = dbmanager.SaveOrUpdateData("sp_AddRedeemPoints", dic);
            }
             catch (Exception ex)
            {
                throw ex;
            }
            return is_success;
        }
    }
}