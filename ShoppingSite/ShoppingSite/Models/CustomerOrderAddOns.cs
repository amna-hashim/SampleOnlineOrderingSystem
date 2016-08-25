using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingSite.Models
{
    /// <summary>
    /// Entity
    /// </summary>
    public class CustomerOrderAddOns
    {
        [Key]
        public int CustomerOrderAddOnID { get; set; }
        public int OrderID { get; set; }
        public int AddOnID { get; set; }
        public string AddOnName { get; set; }

        [ForeignKey("OrderID")]
        public Order Order { get; set; }
        [ForeignKey("AddOnID")]
        public AddOns AddOns { get; set; }
    }
}