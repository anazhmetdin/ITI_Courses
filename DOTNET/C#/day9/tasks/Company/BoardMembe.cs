using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class BoardMember : Employee
    {
        public BoardMember(int employeeID, DateTime _birthDate) 
            : base(employeeID, _birthDate, 0)
        {
        }

        public void Resign()
        {
            OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.Resign});
        }

        public override int VacationStock
        {
            set
            {
                vacationStock = value;
            }
        }

        public override DateTime BirthDate
        {
            set
            {
                birthDate = value;
            }
        }

        public override void EndOfYearOperation()
        {
        }
    }
}
