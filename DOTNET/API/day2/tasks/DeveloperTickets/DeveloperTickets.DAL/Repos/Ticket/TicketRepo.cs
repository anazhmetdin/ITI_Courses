using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTickets.DAL
{
    public class TicketRepo : ITicketRepo
    {
        private readonly DevelopmentContext _context;

        public TicketRepo(DevelopmentContext context)
        {
            _context = context;
        }

        public EntityEntry<Ticket>? AddTicket(Ticket ticket)
        {
            return _context.Set<Ticket>().Add(ticket);
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _context.Set<Ticket>()
                .Include(t => t.DeveloperTickets);
        }

        public Ticket? GetTicket(int ticketId)
        {
            return _context.Set<Ticket>().Include(t => t.DeveloperTickets).FirstOrDefault(t=> t.Id == ticketId);
        }

        public void RemoveById(int ticketId)
        {
            var ticket = GetTicket(ticketId);
            if (ticket == null)
            {
                return;
            }
            _context.Set<Ticket>().Remove(ticket);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void UpdateTicket(Ticket newticket)
        {
            var ticket = GetTicket(newticket.Id);
            if (ticket == null)
            {
                return;
            }
            
            ticket.Title = newticket.Title;
            ticket.Description = newticket.Description;
            ticket.DepartmentId = newticket.DepartmentId;
        }
    }
}
