using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomerOrders.Data
{
    public class CustomerOrdersContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CustomerOrdersContext() : base("name=CustomerOrdersContext")
        {
        }

        public System.Data.Entity.DbSet<CustomerOrders.Areas.Customers.Data.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<CustomerOrders.Areas.Orders.Data.Order> Orders { get; set; }
    }
}
