using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cars.Model;

namespace Cars.Data
{
    public class CarsContext : DbContext
    {
        public CarsContext (DbContextOptions<CarsContext> options)
            : base(options)
        {
        }

        public DbSet<Cars.Model.Car> Car { get; set; } = default!;
    }
}
