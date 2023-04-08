using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTickets.DAL
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly DevelopmentContext _context;

        public DepartmentRepo(DevelopmentContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> ReadAll()
        {
            return _context.Set<Department>()
                .Include(d => d.Tickets)
                .ThenInclude(t => t.DeveloperTickets);
        }
    }
}
