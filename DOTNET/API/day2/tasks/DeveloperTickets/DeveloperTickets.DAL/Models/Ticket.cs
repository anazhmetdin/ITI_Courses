using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTickets.DAL
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual Department? Department { get; set; }
        public int DepartmentId { get; set; }
        public virtual ICollection<DeveloperTicket> DeveloperTickets { get; set; } = new HashSet<DeveloperTicket>();
    }
}
