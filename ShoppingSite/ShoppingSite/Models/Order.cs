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
    public class Order
    {
        #region Properties
        [Key]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductQuantity { get; set; }
        public decimal Total { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string OrderConfirmationNumber { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }
        #endregion
    }
}