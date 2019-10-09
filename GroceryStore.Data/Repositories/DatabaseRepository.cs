using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GroceryStore.Data.Repositories
{
    public class DatabaseRepository
    {
        // Seed database through GroceryStoreAPI project's Startup class
        // TODO: Find a better way to seed database
        public static void SeedDatabase()
        {
            using (StreamReader r = new StreamReader("database.json"))
            {
                string json = r.ReadToEnd();
                var jsonData = JsonConvert.DeserializeObject<RootObject>(json);

                using (var dataContext = new GroceryStoreContext())
                {
                    foreach (Customer customer in jsonData.customers)
                    {
                        dataContext.Customers.Add(customer);
                    }
                    foreach (Order order in jsonData.orders)
                    {
                        dataContext.Orders.Add(order);
                    }
                    foreach (Product product in jsonData.products)
                    {
                        dataContext.Products.Add(product);
                    }
                    dataContext.SaveChanges();
                }
            }
        }
    }

    public class RootObject
    {
        public List<Customer> customers { get; set; }
        public List<Order> orders { get; set; }
        public List<Product> products { get; set; }
    }
}
