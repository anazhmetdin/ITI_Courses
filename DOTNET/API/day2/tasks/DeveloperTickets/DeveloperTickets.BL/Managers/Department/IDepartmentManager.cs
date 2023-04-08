using DeveloperTickets.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTickets.BL
{
    public interface IDepartmentManager
    {
        IEnumerable<DepartmentReadDto> GetAll();
    }
}
