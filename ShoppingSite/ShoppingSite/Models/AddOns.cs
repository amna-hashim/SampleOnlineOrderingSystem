using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ShoppingSite.Models
{
   /// <summary>
   /// Entity
   /// </summary>
    public class AddOns 
    {
        #region Properties
        [Key]
        public int AddOnID { get; set; }
        public string AddOnName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsChecked { get; set; }

        private static List<AddOns> _lstAddOn = null;
        public static List<AddOns> lstAddOns
        {
            get
            {
                if (_lstAddOn == null)
                {
                    ShoppingSiteDBContext productDbContext = new ShoppingSiteDBContext();
                    _lstAddOn = productDbContext.GetAddOns();
                }
                return _lstAddOn;
            }
        }

        #endregion
    }
}