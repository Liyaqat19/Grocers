using Grocers.DbHelper;
using Grocers.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Grocers.BO
{
    public class OrderManager
    {
        DbManager dbmanager = new DbManager();
        public bool CreateOrder(Order order)
        {
            bool isSuccess = false;
            try
            {
                DataTable dt = new DataTable();
                dt = CreateOrderListItemFromList(order.orderItemList);

                List<SqlParameter> list = new List<SqlParameter>();
                SqlParameter sqlParameter = null;
                sqlParameter = new SqlParameter("customer_id", order.customer_id);
                list.Add(sqlParameter);

                sqlParameter = new SqlParameter("store_id", order.store_id);
                list.Add(sqlParameter);

                sqlParameter = new SqlParameter("order_status_id", order.order_status_id);
                list.Add(sqlParameter);

                sqlParameter = new SqlParameter("order_date", order.order_date);
                list.Add(sqlParameter);

                sqlParameter = new SqlParameter("OrderListItemTableType",dt);
                sqlParameter.SqlDbType = SqlDbType.Structured;
                sqlParameter.TypeName = "dbo.OrderListItemTableType";
                list.Add(sqlParameter);

               
                isSuccess = dbmanager.SaveOrUpdateDataWithDataTable("sp_createOrUpdateOrder",list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSuccess;
        }
        public DataTable CreateOrderListItemFromList(List<OrderItem> orderitemlist)
        {
            DataTable table = new DataTable();
            table.Columns.Add("product_id", typeof(int));
            table.Columns.Add("quantity", typeof(int));
            table.Columns.Add("selling_price", typeof(decimal));
            table.Columns.Add("discount", typeof(decimal));
            foreach (var item in orderitemlist)
            {
                DataRow dr = table.NewRow();
                dr["product_id"] = item.product_id;
                dr["quantity"] = item.quantity;
                dr["selling_price"] = item.selling_price;
                dr["discount"] = item.discount;
                table.Rows.Add(dr);
            }
            return table;
        }
        public List<Order> GetOrderList()
        {
            List<Order> orderList = new List<Order>();
            DataSet ds = new DataSet();
            ds = dbmanager.GetData("sp_GetOrderList");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Order order = new Order();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    order = new Order();
                    order.order_id = Convert.ToInt16(dr["order_id"]); ;
                    order.store_id = Convert.ToInt16(dr["store_id"]);
                    order.customer_id = Convert.ToInt16(dr["customer_id"]);
                    order.customer_name = Convert.ToString(dr["customer_name"]); ;
                    order.order_status =GetOrderStatus(Convert.ToInt16(dr["order_status_id"]));
                    order.store_name = Convert.ToString(dr["store_name"]);
                    order.order_date = Convert.ToDateTime(dr["order_date"]);
                    order.order_amount = Convert.ToDecimal(dr["orderAmount"]);
                    orderList.Add(order);
                }
            }
            return orderList;
        }

        private string GetOrderStatus(int order_status_id)
        {
            string OrderStatus = Grocers.Models.Order.OrderStatus.Completed.ToString();
            switch (order_status_id)
            {
                case 1:
                    OrderStatus = Grocers.Models.Order.OrderStatus.Pending.ToString();
                    break;
                case 2:
                    OrderStatus = Grocers.Models.Order.OrderStatus.Processing.ToString();
                    break;
                case 3:
                    OrderStatus = Grocers.Models.Order.OrderStatus.Rejected.ToString();
                    break;
                case 4:
                    OrderStatus = Grocers.Models.Order.OrderStatus.Completed.ToString();
                    break;
            }
            return OrderStatus;
        }

        public List<OrderItem> GetOrderDetails(int order_id)
        {
            List<OrderItem> orderItemList = new List<OrderItem>();
            DataSet ds = new DataSet();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("order_id", order_id);
            ds = dbmanager.GetData("sp_GetOrderDetails",dic);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                OrderItem orderItem = new OrderItem();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    orderItem = new OrderItem();
                    orderItem.order_id = Convert.ToInt16(dr["order_id"]); ;
                    orderItem.product_name = Convert.ToString(dr["product_name"]);
                    orderItem.quantity = Convert.ToInt16(dr["quantity"]);
                    orderItem.selling_price = Convert.ToDecimal(dr["selling_price"]); 
                    orderItem.discount = Convert.ToDecimal(dr["discount"]);
                    orderItem.productAmount = Convert.ToDecimal(dr["productAmount"]);
                    orderItemList.Add(orderItem);
                }
            }
            return orderItemList;
        }

        public int GetProductCurrentStock(int product_id)
        {
            DataSet ds = new DataSet();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("product_id", product_id);
            ds = dbmanager.GetData("sp_GetProductCurrentStock", dic);
            int productCurrentStock = 0;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                 productCurrentStock = Convert.ToInt16(ds.Tables[0].Rows[0]["CurrentProductStock"]);
            }
            return productCurrentStock;
        }


    }
}