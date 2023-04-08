using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTickets.DAL
{
    public interface ITicketRepo
    {
        EntityEntry<Ticket>? AddTicket(Ticket ticket);
        IEnumerable<Ticket> GetAll();
        Ticket? GetTicket(int ticketId);
        void RemoveById(int ticketId);
        int SaveChanges();
        void UpdateTicket(Ticket ticket);
    }
}
