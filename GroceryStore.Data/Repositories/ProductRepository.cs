using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GroceryStore.Data.Repositories
{
    public class ProductRepository
    {
        public static List<Product> GetProducts()
        {
            using (var dataContext = new GroceryStoreContext())
            {
                return dataContext.Products
                        .OrderBy(p => p.description)
                        .ToList();
            }
        }

        public static Product GetProductById(int id)
        {
            using (var dataContext = new GroceryStoreContext())
            {
                return dataContext.Products
                    .Where(p => p.id == id)
                    .FirstOrDefault();
            }
        }

        public static int AddProduct(Product product)
        {
            using (var dataContext = new GroceryStoreContext())
            {
                dataContext.Products.Add(product);
                dataContext.SaveChanges();
                return product.id;
            }
        }

        public static void UpdateProduct(Product product)
        {
            using (var dataContext = new GroceryStoreContext())
            {
                dataContext.Products.Update(product);
                dataContext.SaveChanges();
            }
        }
    }
}
