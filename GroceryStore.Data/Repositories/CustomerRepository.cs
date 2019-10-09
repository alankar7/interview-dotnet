using System.Collections.Generic;
using System.Linq;

namespace GroceryStore.Data.Repositories
{
    public class CustomerRepository
    {
        public static List<Customer> GetCustomers()
        {
            using (var dataContext = new GroceryStoreContext())
            {
                return dataContext.Customers
                        .OrderBy(c => c.name)
                        .ToList();
            }
        }

        public static Customer GetCustomerById(int id)
        {
            using (var dataContext = new GroceryStoreContext())
            {
                return dataContext.Customers
                    .Where(c => c.id == id)
                    .FirstOrDefault();
            }
        }

        public static int AddCustomer(string customerName)
        {
            var customer = new Customer();
            customer.name = customerName;
            using (var dataContext = new GroceryStoreContext())
            {
                dataContext.Customers.Add(customer);
                dataContext.SaveChanges();
                return customer.id;
            }
        }

        public static void UpdateCustomer(Customer customer)
        {
            using (var dataContext = new GroceryStoreContext())
            {
                dataContext.Customers.Update(customer);
                dataContext.SaveChanges();
            }
        }
    }
}
