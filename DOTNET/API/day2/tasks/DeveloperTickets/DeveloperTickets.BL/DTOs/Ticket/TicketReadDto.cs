using DeveloperTickets.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTickets.BL
{
    public record TicketReadDto (int Id, string Description, string Title, int DevelopersCount);
}
