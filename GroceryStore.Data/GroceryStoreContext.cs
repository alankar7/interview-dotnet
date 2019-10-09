using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace GroceryStore.Data
{
    public class GroceryStoreContext : DbContext
    {
        // TODO: Use something other than DbContext to be able to read from the JSON database file instead of a SQLite database
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=GroceryStore.db");        
    }
}
