using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTickets.DAL
{
    public class DeveloperTicket
    {
        public virtual Developer? Developer { get; set; }
        public int DeveloperId { get; set; }
        public virtual Ticket? Ticket { get; set; }
        public int TicketId { get; set; }
    }
}
