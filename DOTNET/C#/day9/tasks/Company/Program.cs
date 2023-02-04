using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department department = new Department();
            Club club = new Club();

            SalesPerson s1 = new SalesPerson(12, DateTime.Now);
            SalesPerson s2 = new SalesPerson(16, DateTime.Now);
            BoardMember bm = new BoardMember(13, DateTime.Now);
            Employee    e1 = new Employee(14, DateTime.Now, 10);
            Employee    e2 = new Employee(15, DateTime.Now, 10);

            department.AddStaff(s1);
            department.AddStaff(s2);
            department.AddStaff(bm);
            department.AddStaff(e1);
            department.AddStaff(e2);

            club.AddMember(s1);
            club.AddMember(s2);
            club.AddMember(bm);
            club.AddMember(e1);
            club.AddMember(e2);

            Console.WriteLine("+++++++++++++++requesting vacation+++++++++++++++");

            s1.RequestVacation(DateTime.Parse("1/1/2023"), DateTime.Parse("1/1/2033"));
            bm.RequestVacation(DateTime.Parse("1/1/2023"), DateTime.Parse("1/1/2033"));
            e1.RequestVacation(DateTime.Parse("1/1/2023"), DateTime.Parse("1/12/2023"));
            e2.RequestVacation(DateTime.Parse("1/1/2023"), DateTime.Parse("1/11/2023"));
            e1.RequestVacation(DateTime.Parse("1/1/2023"), DateTime.Parse("1/12/2023"));

            Console.WriteLine("\n+++++++++++++++Checking target+++++++++++++++");
            s1.AchievedTarget = 1000;

            Console.WriteLine("------target 500------");
            s1.CheckTarget(500);
            Console.WriteLine("------target 2000------");
            s1.CheckTarget(2000);

            Console.WriteLine("\n+++++++++++++++Checking Age+++++++++++++++");
            s2.BirthDate = DateTime.Parse("1/1/1963");
            e2.BirthDate = DateTime.Parse("1/1/1963");
            bm.BirthDate = DateTime.Parse("1/1/1963");

            Console.WriteLine("\n+++++++++++++++Resign+++++++++++++++");
            bm.Resign();

            Console.WriteLine();
        }
    }
}
