using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingSite.Models
{
    /// <summary>
    /// Entity
    /// </summary>
    public class Customer
    {
        #region Properties
        [Key]
        public int CustomerID { get; set; }
        [RegularExpression("^[a-zA-Z\\s]{1,50}$", ErrorMessage = "Invalid")]
        [Required(ErrorMessage = "Required")]
        public string CustomerName { get; set; }
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Invalid (xxxxxxxxxx)")]
        [Required(ErrorMessage = "Required")]
        public string Phone { get; set; }
        [RegularExpression("^[a-zA-Z0-9-_/#'\\s]{1,150}$", ErrorMessage = "Invalid")]
        [Required(ErrorMessage = "Required")]
        public string AddressLine1 { get; set; }
        [RegularExpression("^[a-zA-Z0-9-_/#'\\s]{1,50}$", ErrorMessage = "Invalid")]
        public string AddressLine2 { get; set; }
        [RegularExpression("^[a-zA-Z\\s]{1,50}$", ErrorMessage = "Invalid")]
        [Required(ErrorMessage = "Required")]
        public string City { get; set; }
        [RegularExpression("^[a-zA-Z0-9\\s]{7}$", ErrorMessage = "Invalid. Ex.(T2G 4K8)")]
        [Required(ErrorMessage = "Required")]
        public string PostalCode { get; set; }
        public string Comments { get; set; }

        public List<Order> Order { get; set; }
        #endregion
    }
}