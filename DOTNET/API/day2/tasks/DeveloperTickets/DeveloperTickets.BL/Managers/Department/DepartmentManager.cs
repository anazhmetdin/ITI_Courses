using DeveloperTickets.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTickets.BL
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartmentRepo _departmentRepo;

        public DepartmentManager(IDepartmentRepo departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }
        public IEnumerable<DepartmentReadDto> GetAll()
        {
            return _departmentRepo.ReadAll()
                .Select(d => new DepartmentReadDto(d.Id, d.Name, d.Tickets.Select(t => 
                    new TicketReadDto(t.Id, t.Description, t.Title, t.DeveloperTickets.Count)).ToList()
                ));
        }
    }
}
