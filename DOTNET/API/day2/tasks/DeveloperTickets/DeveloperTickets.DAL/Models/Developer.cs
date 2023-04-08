using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTickets.DAL
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<DeveloperTicket> DeveloperTickets { get; set; } = new HashSet<DeveloperTicket>();
    }
}
