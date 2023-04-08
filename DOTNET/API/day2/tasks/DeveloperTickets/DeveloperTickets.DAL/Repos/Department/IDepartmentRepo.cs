using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTickets.DAL
{
    public interface IDepartmentRepo
    {
        IEnumerable<Department> ReadAll();
    }
}
