using DeveloperTickets.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTickets.DAL
{
    public class DevelopmentContext: DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DeveloperTicket> DeveloperTickets { get; set; }

        public DevelopmentContext(DbContextOptions<DevelopmentContext> options):
            base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Departments
            var departments = new Department[]
            {
                new Department { Id = 1, Name = "Dept 1"},
                new Department { Id = 2, Name = "Dept 2"},
                new Department { Id = 3, Name = "Dept 3"}
            };
            #endregion
            #region Developers
            var developers = new Developer[]
            {
                new Developer { Id = 1, Name = "Dev 1"},
                new Developer { Id = 2, Name = "Dev 2"},
                new Developer { Id = 3, Name = "Dev 3"},
            };
            #endregion
            #region Tickets
            var tickets = new Ticket[]
            {
                new Ticket { Id = 1, DepartmentId = 1, Title = "Ticket 1", Description = "Ticket 1 of some bug"},
                new Ticket { Id = 2, DepartmentId = 2, Title = "Ticket 2", Description = "Ticket 2 of some bug"},
                new Ticket { Id = 3, DepartmentId = 3, Title = "Ticket 3", Description = "Ticket 3 of some bug"},
            };
            #endregion
            #region DeveloperTickets
            var developerTickets = new DeveloperTicket[]
            {
                new DeveloperTicket {TicketId = 1, DeveloperId = 1},
                new DeveloperTicket {TicketId = 1, DeveloperId = 3},
                new DeveloperTicket {TicketId = 2, DeveloperId = 2},
                new DeveloperTicket {TicketId = 2, DeveloperId = 1},
                new DeveloperTicket {TicketId = 3, DeveloperId = 1},
                new DeveloperTicket {TicketId = 3, DeveloperId = 2},
                new DeveloperTicket {TicketId = 3, DeveloperId = 3},
            };
            #endregion

            modelBuilder.Entity<Department>()
                .HasData(departments);
            modelBuilder.Entity<Developer>()
                .HasData(developers);
            modelBuilder.Entity<Ticket>()
                .HasData(tickets);
            modelBuilder.Entity<DeveloperTicket>()
                .HasData(developerTickets);

            modelBuilder.Entity<DeveloperTicket>()
                .HasKey(dt => new {dt.TicketId, dt.DeveloperId});
        }
    }
}
