using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite.Models
{
    /// <summary>
    /// User Session
    /// </summary>
    public class UserSession
    {
        public List<AddOns> AddOns { get; set; }
        public int ProductQuantity { get; set; }
    }
}