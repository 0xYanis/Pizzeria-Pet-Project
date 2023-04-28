using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PizzaProject.Models
{
    public class PizzaContext: DbContext
    {
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}