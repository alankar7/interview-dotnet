using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore.Data
{
    public class Order
    {
        public int id { get; set; }
        public int customerId { get; set; }
        public DateTime orderDate { get; set; }
        public List<Item> items { get; set; }
    }
}
