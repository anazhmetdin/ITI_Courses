using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeFirst.Models;

namespace CodeFirst.Data
{
    public class CodeFirstContext : DbContext
    {
        public CodeFirstContext (DbContextOptions<CodeFirstContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Course { get; set; } = default!;
        public DbSet<Student> Students { get; set; } = default!;
        public DbSet<StudentCourse> StudentCourse { get; set; } = default!;
    }
}
