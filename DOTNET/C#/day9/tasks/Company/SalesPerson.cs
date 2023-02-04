using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    public class SalesPerson: Employee
    {
        public SalesPerson(int employeeID, DateTime _birthDate) : 
            base(employeeID, _birthDate, 0) { }

        public int AchievedTarget { get; set; } = 0;
        public bool CheckTarget(int Quota)
        {
            if (AchievedTarget < Quota)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.NotAchievedTarget });
                return false;
            }

            return true;
        }
        public override int VacationStock
        {
            set
            {
                vacationStock = value;
            }
        }
    }
}
