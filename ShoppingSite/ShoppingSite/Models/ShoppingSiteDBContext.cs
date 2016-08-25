using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppingSite.Models
{
    /// <summary>
    /// Main class interacting with the DB
    /// </summary>
    public class ShoppingSiteDBContext : DbContext
    {
        #region Entities
        public DbSet<Product> Products { get; set; }
        public DbSet<AddOns> AddOns { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CustomerOrderAddOns> CustomerOrderAddOns { get; set; }
        #endregion

        #region Get Methods
        public List<AddOns> GetAddOns()
        {
            ShoppingSiteDBContext productDbContext = new ShoppingSiteDBContext();
            return productDbContext.AddOns.ToList();
        }

        public List<Product> GetProducts()
        {
            ShoppingSiteDBContext productDbContext = new ShoppingSiteDBContext();
            return productDbContext.Products.ToList();
        }
        #endregion

        #region Operational Methods
        public void SaveCustomer(Customer customer)
        {
            ShoppingSiteDBContext dbContext = new ShoppingSiteDBContext();
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
        }

        public void SaveOrder(Order order)
        {
            ShoppingSiteDBContext dbContext = new ShoppingSiteDBContext();
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
        }

        public void SaveAddOns( Order order, List<CustomerOrderAddOns> addOns)
        {
            ShoppingSiteDBContext dbContext = new ShoppingSiteDBContext();

            foreach (var item in addOns)
            {
                item.OrderID = order.OrderID;
                dbContext.CustomerOrderAddOns.Add(item);
                dbContext.SaveChanges();
            }
        }

        public bool SaveCustomerOrder(Customer customer, Order order, List<CustomerOrderAddOns> addOns)
        {
            bool res = true;

            SaveCustomer(customer);
            SaveOrder(order);
            SaveAddOns(order, addOns);

            return res;
        }
        #endregion
    }

}