using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductNotification.Models;

namespace ProductNotification.Data
{
    public class ProductsContext : DbContext
    {
        public ProductsContext (DbContextOptions<ProductsContext> options)
            : base(options)
        {
        }

        public DbSet<ProductNotification.Models.Comment> Comment { get; set; } = default!;

        public DbSet<ProductNotification.Models.Product> Product { get; set; } = default!;
    }
}
