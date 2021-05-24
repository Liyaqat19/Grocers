using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocers.Models
{
    public class CustomerNode
    {
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public string ImgUrl { get; set; }
        public int Level { get; set; }
        public int parent_id { get; set; }

        public List<CustomerNode> children = new List<CustomerNode>();
    }
}