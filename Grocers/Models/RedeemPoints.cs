using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocers.Models
{
    public class RedeemPoints
    {
        public int customer_id { get; set; }
        public int redeem_points { get; set; }
        public string redeem_date { get; set; }
    }
}