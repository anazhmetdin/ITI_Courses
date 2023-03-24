using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DepartmentInstructor.Models;

namespace DepartmentInstructor.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Instructor>().HasIndex(i => i.Email).IsUnique();
        }

        public DbSet<DepartmentInstructor.Models.Department> Department { get; set; } = default!;

        public DbSet<DepartmentInstructor.Models.Instructor> Instructor { get; set; } = default!;
    }
}
