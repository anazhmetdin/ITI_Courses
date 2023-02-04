using System.Security;

namespace D03_Emplyoee
{
    enum Gender
    {
        M, F
    }

    [Flags]
    enum Permissions
    {
        Guest = 8, Developer = 4, Secretary = 2, DBA = 1, Security_Officer = 0x0F
    }

    struct HiringDate
    {
        private int year;
        private int month;
        private int day;

        public HiringDate(int _year, int _month, int _day)
        {
            setYear(_year);
            setMonth(_month);
            setDay(_day);
        }
        public override string ToString()
        {
            return $"{getDay()}/{getMonth()}/{getYear()}";
        }

        public int getYear() { return year; }
        public int getMonth() { return month; }
        public int getDay() { return day; }

        public void setYear(int _year) { year = _year;}
        public void setMonth(int _month) { month = _month;}
        public void setDay(int _day) { day = _day;}
    }

    struct Employee
    {
        private int id;
        private Gender gender;
        private Permissions permissions;
        private decimal salary;
        private HiringDate hireDate;

        public override string ToString()
        {
            return String.Format("{0} - {1} - {2} - {3:#.00} - {4}", id, gender, permissions, salary, hireDate);
        }

        public Employee(int _id, Gender _gender, Permissions _permissions, decimal _salary, HiringDate _hireDate)
        {
            setID(_id);
            setGender(_gender);
            setPermissions(_permissions);
            setSalary(_salary);
            setHiringDate(_hireDate);
        }

        public int getID() { return id; }
        public Gender getGender() { return gender; }
        public Permissions getPermissions() { return permissions; }
        public decimal getSalary() { return salary; }
        public HiringDate getHireDate() { return hireDate; }

        public void setID(int _id) { id = _id;}
        public void setGender(Gender _gender) { gender = _gender; }
        public void setPermissions(Permissions _permissions) { permissions = _permissions; }
        public void setSalary(decimal _salary) { salary = _salary;}
        public void setHiringDate(HiringDate _hiringDate) { hireDate = _hiringDate;}
    }
    public class MyComparer : IComparer<Employee>
    {
        int IComparer<Employee>.Compare(Employee e1, Employee e2)
        {
            if (e1.getHireDate().getYear() != e2.getHireDate().getYear()) { return e1.getHireDate().getYear() - e2.getHireDate().getYear(); }
            if (e1.getHireDate().getMonth() != e2.getHireDate().getMonth()) { return e1.getHireDate().getMonth() - e2.getHireDate().getMonth(); }
            return e1.getHireDate().getYear() - e2.getHireDate().getDay();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = new Employee[3];

            Gender? gender;
            Permissions? permissions;
            decimal salary = -1;
            int year = 0, month = 0, day = 0;
            HiringDate hiringDate;

            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine("==================================");
                do
                {
                    Console.WriteLine($"Entre salary for employee #{i + 1}");
                    try { 
                        salary = decimal.Parse(Console.ReadLine()!);
                        if (salary < 0)
                        {
                            throw new Exception("Invalid salary");
                        }
                    } 
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        salary = -1; 
                    }
                }
                while (salary == -1);

                do
                {
                    Console.WriteLine($"Entre gender [M, F] for employee #{i + 1}");
                    try { gender = (Gender) Enum.Parse(typeof(Gender), Console.ReadLine()!); } catch { gender = null; }
                }
                while (gender == null);

                do
                {
                    Console.WriteLine($"Entre permission [Guest,Developer,Secretary,DBA,Security_Officer] for employee #{i + 1}");
                    try { permissions = (Permissions) Enum.Parse(typeof(Permissions), Console.ReadLine()!); } catch { permissions = null; }
                }
                while (permissions == null);

                do
                {
                    Console.WriteLine($"Entre hiring year for employee #{i + 1}");
                    try { 
                        year = int.Parse(Console.ReadLine()!);
                        if ((year < 2000) || (year > 2023)) { throw new Exception("Invalid year"); }
                    } 
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        year = 0;
                    }
                }
                while (year == 0);

                do
                {
                    Console.WriteLine($"Entre hiring month for employee #{i + 1}");
                    try
                    {
                        month = int.Parse(Console.ReadLine()!);
                        if ((month < 1) || (month > 12)) { throw new Exception("Invalid month"); }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        month = 0;
                    }
                }
                while (month == 0);

                do
                {
                    Console.WriteLine($"Entre hiring day for employee #{i + 1}");
                    try
                    {
                        day = int.Parse(Console.ReadLine()!);
                        if (day < 1 || day > 31) { throw new Exception("Invalid day"); }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        day = 0;
                    }
                }
                while (day == 0);

                hiringDate = new HiringDate(year, month, day);

                employees[i] = new Employee(i+1, (Gender)gender, (Permissions)permissions, salary, hiringDate);
            }

            Array.Sort(employees, new MyComparer());

            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine(employees[i]);
            }
        }
    }
}