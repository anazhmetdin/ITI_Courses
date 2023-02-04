using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Club
    {
        public int ClubID { get; set; }
        public string ClubName { get; set; }
        List<Employee> Members = new List<Employee>();
        public void AddMember(Employee E)
        {
            Members.Add(E);
            E.EmployeeLayOff += RemoveMember;
        }
        ///CallBackMethod
        public void RemoveMember (object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is Employee emp && emp != null)
            {
                if (!Members.Contains(emp) || e.Cause == LayOffCause.AgeOver60 || e.Cause == LayOffCause.Resign)
                    return;

                Console.WriteLine($"Club, removing employee {emp.EmployeeID}");
                Members.Remove(emp);
                emp.EmployeeLayOff -= RemoveMember;
            }
        }
    }
}
