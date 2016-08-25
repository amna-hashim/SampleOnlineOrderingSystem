using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ShoppingSite.Models
{
    /// <summary>
    /// Class to  feed setup infrormation in db
    /// </summary>
    public class ShoppingSiteDBContextSeeder : DropCreateDatabaseIfModelChanges<ShoppingSiteDBContext>
    {
        protected override void Seed(ShoppingSiteDBContext context)
        {
            #region Products
            Product product1 = new Product()
            {
                ProductName = "SUPREME DELUX",
                Description = "Our famouse combination of beef pepproni, smoked chicken, cabanossi, beef, onions, green papers, olives & Mushrooms with double the amount of topping.",
                Size = "Regular 9 inches",
                Price = 49.98m,
                ImageUrl = "../Content/images/super_supreme_img1.png"
            };

            Product product2 = new Product()
           {
               ProductName = "FAJITA SICILIAN",
               Description = "A delicious blend of fajita chicken, onions, green peppers, green chillies and lots of cheese.",
               Size = "Regular 9 inches",
               Price = 54.98m,
               ImageUrl = "../Content/images/behari_chicken_pizza_img1.png"
           };

            context.Products.Add(product1);
            context.Products.Add(product2);
            #endregion

            #region AddOns

            AddOns addon1 = new AddOns()
            {
                AddOnName = "Cheese & Meat",
                Description = "Cheese",
                Price = 8m
            };
            AddOns addon2 = new AddOns()
            {
                AddOnName = "Cheese & Meat",
                Description = "Meat",
                Price = 8m
            };
            AddOns addon3 = new AddOns()
            {
                AddOnName = "Veggies",
                Description = "Olives",
                Price = 3m
            };
            AddOns addon4 = new AddOns()
            {
                AddOnName = "Veggies",
                Description = "Mushrooms",
                Price = 3m
            };

            context.AddOns.Add(addon1);
            context.AddOns.Add(addon2);
            context.AddOns.Add(addon3);
            context.AddOns.Add(addon4);

            #endregion

            base.Seed(context);
        }
    }
}