using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocers.Models
{
    public class Order
    {
        public int order_id { get; set; }
        public int customer_id { get; set; }
        public byte order_status_id { get; set; }
        public DateTime order_date { get; set; }
        public DateTime date_required { get; set; }
        public DateTime shipped_date { get; set; }
        public int store_id { get; set; }
        public int staff_id { get; set; }
        public List<OrderItem> orderItemList { get; set; }
        public string customer_name { get; set; }
        public string store_name { get; set; }
        public string order_status { get; set; }
        public decimal order_amount { get; set; }
        public enum OrderStatus
        {
            Pending=1,
            Processing=2,
            Rejected=3,
            Completed=4
        }
    }
    
}