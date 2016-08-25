using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite.Models
{
    /// <summary>
    /// Model for the Order view
    /// </summary>
    public class CustomerOrder
    {
        #region Properties
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public List<AddOns> AddOns { get; set; }
        public Customer Customer { get; set; }
        public Order Order { get; set; }
        #endregion

        /// <summary>
        /// Computes total order price
        /// </summary>
        /// <param name="basePrice"></param>
        /// <param name="order"></param>
        /// <param name="VisitorSession"></param>
        /// <returns></returns>
        private decimal GetOrderTotal(decimal basePrice, Order order, UserSession VisitorSession)
        {
            decimal total = basePrice;

            foreach (var selectedAddOn in VisitorSession.AddOns)
            {
                if (selectedAddOn.IsChecked)
                    total += selectedAddOn.Price;
            }

            return total;
        }

        private string GenerateOCN()
        {
            return DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() +
                DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
        }

        /// <summary>
        /// Returns order object
        /// </summary>
        /// <param name="custOrder"></param>
        /// <param name="VisitorSession"></param>
        /// <returns></returns>
        public Order GetCustomerOrder(CustomerOrder custOrder, UserSession VisitorSession)
        {
            decimal basePrice = 0m;
            custOrder.Customer.Order = new  List<Order>();

            Order order = new Order();
            order.OrderDate = DateTime.Now;
            order.ProductID = custOrder.ProductID;
            order.ProductName = custOrder.ProductName;
            order.ProductQuantity = VisitorSession.ProductQuantity;
            if (Product.lstProduct.Where(x => x.ProductID == custOrder.ProductID).FirstOrDefault() != null)
                basePrice = Product.lstProduct.Where(x => x.ProductID == custOrder.ProductID).FirstOrDefault().Price * VisitorSession.ProductQuantity;
            order.Total = GetOrderTotal(basePrice, order, VisitorSession);
            order.OrderConfirmationNumber = GenerateOCN();

            custOrder.Customer.Order.Add(order);
            return custOrder.Customer.Order.FirstOrDefault();
        }

       /// <summary>
        /// Returns list of selected add-ons
       /// </summary>
       /// <param name="custOrder"></param>
       /// <param name="VisitorSession"></param>
       /// <returns></returns>
        public List<CustomerOrderAddOns> GetCustomerOrderAddOns(CustomerOrder custOrder, UserSession VisitorSession)
        {
            List<CustomerOrderAddOns> lstSelectedAddons = new List<CustomerOrderAddOns>();
            foreach (var selectedAddOn in VisitorSession.AddOns)
            {
                if (selectedAddOn.IsChecked)
                {
                    CustomerOrderAddOns coAddOns = new CustomerOrderAddOns();
                    coAddOns.AddOnID = selectedAddOn.AddOnID;
                    coAddOns.AddOnName = selectedAddOn.AddOnName;

                    lstSelectedAddons.Add(coAddOns);
                }
            }

            return lstSelectedAddons;
        }

       /// <summary>
       /// returns order summary
       /// </summary>
       /// <param name="customer"></param>
       /// <param name="order"></param>
       /// <param name="VisitorSession"></param>
       /// <returns></returns>
        public string GetOrderSummary(Customer customer, Order order, UserSession VisitorSession)
        {
            string addOns = "";
            if (VisitorSession.AddOns.Count > 0)
            {
                foreach (var addOn in VisitorSession.AddOns)
                {
                    addOns += addOn.Description + " (" + addOn.Price + ") <br>";
                }
            }

            string result = string.Format(@"{0}, {1}, {2}, {3}, {4}, {5}, 
                                           {6}, {7}, {8}, {9}, {10}"
                                         , order.OrderConfirmationNumber
                                         , customer.CustomerName
                                         , customer.Phone
                                         , customer.AddressLine1
                                         , customer.AddressLine2
                                         , customer.City
                                         , customer.PostalCode
                                         , order.ProductName
                                         , order.ProductQuantity
                                         , order.Total
                                         , addOns != "" ? addOns.Substring(0, addOns.Length - 1): ""
                                         );
            
            return result;
        }
    }
}