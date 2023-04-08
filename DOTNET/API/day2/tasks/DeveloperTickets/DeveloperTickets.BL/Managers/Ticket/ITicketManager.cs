using DeveloperTickets.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTickets.BL
{
    public interface ITicketManager
    {
        IEnumerable<TicketReadDto> ReadAllTickets();
        TicketReadDto? ReadTicket(int ticketId);
        bool UpdateTicket(TicketDto ticket);
        bool RemoveTicket(int ticketId);
        int CreateTicket(TicketCreateDto ticket);
        TicketReadDto? AssignDevelopers(int id, AssignedDevelopersDto developers);
    }
}
