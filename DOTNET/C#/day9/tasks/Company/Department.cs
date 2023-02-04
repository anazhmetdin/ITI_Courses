using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    public class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        List<Employee> Staff = new List<Employee>();
        public void AddStaff(Employee E)
        {
            Staff.Add(E);
            E.EmployeeLayOff += RemoveStaff;
        }
        ///CallBackMethod
        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is Employee emp && emp != null)
            {
                if (!Staff.Contains(emp))
                    return;

                Console.WriteLine($"Department, removing employee {emp.EmployeeID}");
                Staff.Remove(emp);
                emp.EmployeeLayOff -= RemoveStaff;
            }
        }
    }
}
