using ShoppingSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingSite.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public UserSession VisitorSession
        {
            get
            {
                return this.Session["VisitorSession"] == null ?
                 null : ((UserSession)this.Session["VisitorSession"]);
            }
            set
            {
                if (Session["VisitorSession"] == null)
                {
                    Session["VisitorSession"] = new UserSession();
                }
            }
        }

        public ActionResult Index()
        {
            VisitorSession = new UserSession();
            return View();
        }

        public ActionResult Order()
        {
            CustomerOrder custOrder = new CustomerOrder();

            custOrder.AddOns = AddOns.lstAddOns;
            custOrder.Customer = new Customer();
            //custOrder.Order = new Order();


            return View(custOrder);
        }

        /// Persist Order details in database and return Order Summary
        [HttpPost]
        public ActionResult Order(CustomerOrder custOrder)
        {
            string result = "";
            CustomerOrder co = new CustomerOrder();
            Order order = co.GetCustomerOrder(custOrder, VisitorSession);
            List<CustomerOrderAddOns> lstAddOn = co.GetCustomerOrderAddOns(custOrder, VisitorSession);

            ShoppingSiteDBContext obj = new ShoppingSiteDBContext();
            if (obj.SaveCustomerOrder(custOrder.Customer, order, lstAddOn))
                result = co.GetOrderSummary(custOrder.Customer, order, VisitorSession);

            return Content(result);
        }

        /// This method is called asynchronously to save order details in session for later retrieval
        [HttpPost]
        public string SaveOrderDetails(string strAddOn, int ProductQuantity)
        {
            string addOnNames = "";
            VisitorSession.AddOns = new List<AddOns>();
            VisitorSession.ProductQuantity = ProductQuantity;

            if (!string.IsNullOrEmpty(strAddOn))
            {
                string[] arr = strAddOn.Split('|');
                foreach (var o in arr)
                {
                    if (!string.IsNullOrEmpty(o))
                    {
                        //AddOns_0__IsChecked
                        int i = Convert.ToInt32(Helpers.HelperClasses.Numbers(o).FirstOrDefault());
                        addOnNames += AddOns.lstAddOns.ToArray()[i].Description + " | ";

                        AddOns addOn = new AddOns();
                        addOn.AddOnID = AddOns.lstAddOns.ToArray()[i].AddOnID;
                        addOn.AddOnName = AddOns.lstAddOns.ToArray()[i].AddOnName;
                        addOn.Description = AddOns.lstAddOns.ToArray()[i].Description;
                        addOn.Price = AddOns.lstAddOns.ToArray()[i].Price;
                        addOn.IsChecked = true;
                        VisitorSession.AddOns.Add(addOn);
                    }
                }
            }

            return addOnNames != "" ? addOnNames.Substring(0, addOnNames.Length - 1) : addOnNames;
        }
    }
}
