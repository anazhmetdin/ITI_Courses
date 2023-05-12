using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsData;
using Microsoft.EntityFrameworkCore;

namespace CarsAPI
{
    public class CarsAPIContext : DbContext
    {
        public CarsAPIContext (DbContextOptions<CarsAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Car { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>(b =>
            {
                b.HasKey(c => c.Num);
            });
        }
    }
}
