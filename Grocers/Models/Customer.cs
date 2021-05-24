using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocers.Models
{
    public class Customer
    {
        public int customer_id { get; set; }
        public string customer_code { get; set; }
        public string customer_name { get; set; }
        public string mobile_number { get; set; }
        public DateTime? dob { get; set; }
        public int parent_id { get; set; }
        public string password { get; set; }
        public bool is_active { get; set; }
        public bool is_admin { get; set; }
        public int introducer_id { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_modified { get; set; }
        public int created_by { get; set; }
        public int modified_by { get; set; }
        public int position { get; set; }
        public int occupation { get; set; }
        public string IntroducerName { get; set; }
        public string ParentName { get; set; }
        public int ChildCount { get; set; }
        public string dobString { get; set; }

        public enum Occupation
        {
            Job=1,
            Bussiness=2,
            ZariWork=3,
            Mukaish=4,
            Other=5
        }
    }
}