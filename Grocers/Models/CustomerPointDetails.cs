using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocers.Models
{
    public class CustomerPointDetails
    {
        public int CustomerMatchedPoints { get; set; }
        public int CustomerOwnPoints { get; set; }
        public int LeftTotalPoints { get; set; }
        public int RightTotalPoints { get; set; }
        public int TotalPoints { get; set; }
        public int RedeemedPoints { get; set; }
        public List<string> LeftChildren { get; set; }
        public List<string> RightChildren { get; set; }
        public List<RedeemPoints> redeemDetails { get; set; }
    }
}