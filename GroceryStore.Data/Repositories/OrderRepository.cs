using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GroceryStore.Data.Repositories
{
    public class OrderRepository
    {
        public static List<Order> GetOrders()
        {
            using (var dataContext = new GroceryStoreContext())
            {
                return dataContext.Orders
                        .OrderByDescending(o => o.orderDate)
                        .ToList();
            }
        }

        public static List<Order> GetOrdersByDate(string orderDate)
        {
            using (var dataContext = new GroceryStoreContext())
            {
                return dataContext.Orders
                        .Where(o => o.orderDate != null && o.orderDate == DateTime.ParseExact(orderDate, "d", CultureInfo.InvariantCulture))
                        .ToList();
            }
        }

        public static Order GetOrderById(int id)
        {
            using (var dataContext = new GroceryStoreContext())
            {
                return dataContext.Orders
                    .Where(o => o.id == id)
                    .FirstOrDefault();
            }
        }

        public static List<Order> GetOrdersByCustomer(string customerName)
        {
            using (var dataContext = new GroceryStoreContext())
            {
                return (from o in dataContext.Orders
                        join c in dataContext.Customers on o.customerId equals c.id
                        where c.name.Contains(customerName)
                        select o)
                        .OrderByDescending(o => o.orderDate)
                        .ToList();
                             
            }
        }
    }
}
