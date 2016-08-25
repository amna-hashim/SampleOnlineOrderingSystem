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
    public class Product
    {
        #region Properties
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string ImageUrl { get; set; }

        private static List<Product> _lstProduct = null;
        public static List<Product> lstProduct
        {
            get
            {
                if(_lstProduct == null)
                {
                    ShoppingSiteDBContext productDbContext = new ShoppingSiteDBContext();
                    _lstProduct = productDbContext.GetProducts();
                }
                return _lstProduct;
            }
        }

        #endregion
    }
}