using System.Diagnostics.CodeAnalysis;
using System.Security;
using System.Security.Claims;

namespace D03_Emplyoee
{
    enum Gender
    {
        M, F
    }

    [Flags]
    enum Permissions
    {
        guest = 8, developer = 4, secretary = 2, dba = 1, securityofficer = 0x0F
    }

    struct HiringDate
    {
        private int year;
        private int month;
        private int day;

        private readonly static string oddmonths = "1, 3, 5, 7, 8, 10, 12";
        private readonly static string evenmonths = "4, 6, 9, 11";

        public int Year
        {
            set { year = value < 2000 ? throw new ArgumentOutOfRangeException("Year must be > 2000") :
                    (value > 2023 ? throw new ArgumentOutOfRangeException("Year must be < 2024") : value); }
            get { return year; }
        }
        public int Month
        {
            set { month = value < 1 ? throw new ArgumentOutOfRangeException("Month must be > 0") :
                    (value > 12 ? throw new ArgumentOutOfRangeException("Month be < 13") : value); }
            get { return month; }
        }
        public int Day
        {
            set => day = value < 1 ? throw new ArgumentOutOfRangeException("Day must be > 0") :
                    (value > 31 && oddmonths.Split(Month + "").Length >= 2 && Month != 2? throw new ArgumentOutOfRangeException("Day must be < 32 for odd months") :
                        (value > 30 && evenmonths.Split(Month + "").Length == 2 ? throw new ArgumentOutOfRangeException("Day must be < 31 for even months") :
                            (value > (Year % 4 == 0 ? 29 : 28) && Month == 2 ? throw new ArgumentOutOfRangeException("Day must be < 29/30 for February") : value)));
            get { return day; }
        }

        private HiringDate(int _year, int _month, int _day)
        {
            Year = _year;
            Month = _month;
            Day = _day;
        }

        public static bool TryHiringDate(string? date, out object? hiringDate)
        {            
            
            try
            {
                string[] dateFields = date!.Split('/');

                if (dateFields.Length == 3)
                {
                    hiringDate = new HiringDate(Int32.Parse(dateFields[2]), Int32.Parse(dateFields[1]), Int32.Parse(dateFields[0]));
                    return true;
                }
            }
            catch { }

            hiringDate = null;
            return false;
        }

        public override string ToString()
        {
            return $"{Day}/{Month}/{Year}";
        }

        public bool compare(HiringDate other)
        {
            return other.Year == Year && other.Month == Month && other.Day == Day;
        }
    }

    struct Employee
    {
        private long id;
        private Gender gender;
        private Permissions permissions;
        private decimal salary;
        private HiringDate hireDate;

        public long ID { get { return id; } }
        public Gender Gender { get { return gender; } }
        public Permissions Permissions { 
            get { return permissions; }
            set { permissions = value; }
        }
        public decimal Salary
        {
            get { return salary; }
            set { salary = value < 3000 ? 3000 : value; }
        }
        public HiringDate HireDate { get { return hireDate; } }

        public override string ToString()
        {
            return String.Format("{0} - {1} - {2} - {3:#.00} - {4}", ID, Gender, Permissions, Salary, HireDate);
        }

        public Employee(long _id, Gender _gender, Permissions _permissions, decimal _salary, HiringDate _hireDate)
        {
            id = _id;
            gender = _gender;
            Permissions = _permissions;
            Salary = salary;
            hireDate = _hireDate;
        }
    }
    class MyComparer : IComparer<Employee>
    {
        int IComparer<Employee>.Compare(Employee e1, Employee e2)
        {
            if (e1.HireDate.Year != e2.HireDate.Year) { return e1.HireDate.Year - e2.HireDate.Year; }
            if (e1.HireDate.Month != e2.HireDate.Month) { return e1.HireDate.Month - e2.HireDate.Month; }
            return e1.HireDate.Day - e2.HireDate.Day;
        }
    }

    class EmployeeSearch
    {
        private Employee[] employees;

        private long[] nationalIDs;
        private string[] names;
        private HiringDate[] hiringDates;

        readonly int capacity;
        private int size;

        public int Capacity { get { return capacity; } }
        public int Size { get { return size; } }

        public EmployeeSearch (int capacity)
        {
            this.capacity = capacity;
            this.size = 0;

            employees = new Employee[capacity];

            nationalIDs = new long[capacity];
            names = new string[capacity];
            hiringDates = new HiringDate[capacity];
        }
        public Employee? this[int index]
        {
            get
            {
                if (index < size)
                {
                    return employees[index];
                }

                return null;
            }
        }

        public Employee? this[long ID]
        {
            get
            {
                for (int i = 0; i < size; i++)
                {
                    if (nationalIDs[i] == ID)
                    {
                        return employees[i];
                    }
                }

                return null;
            }
        }

        public Employee? this[string name]
        {
            get
            {
                for (int i = 0; i < size; i++)
                {
                    if (names[i] == name)
                    {
                        return employees[i];
                    }
                }

                return null;
            }
        }

        public Employee? this[HiringDate hiringDate]
        {
            get
            {
                for (int i = 0; i < size; i++)
                {
                    if (hiringDates[i].compare(hiringDate))
                    {
                        return employees[i];
                    }
                }

                return null;
            }
        }

        public Employee this[int ID, string name, HiringDate hiringDate]
        {
            set
            {
                if (size != capacity)
                {
                    nationalIDs[size] = ID;
                    names[size] = name;
                    hiringDates[size] = hiringDate;

                    employees[size] = value;

                    size++;
                }
                else
                {
                    throw new InvalidOperationException("Capacity is full");
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeSearch employees = new(3);

            object? temp;
            Gender gender;
            Permissions permissions;
            decimal salary;
            HiringDate hiringDate;
            string? name;
            int nationalID;

            for (int i = 0; i < employees.Capacity; i++)
            {
                Console.WriteLine("==================================");

                do
                {
                    Console.WriteLine($"Enter name for employee #{i + 1}");
                }
                while ((name = Console.ReadLine()) == null);


                do
                {
                    Console.WriteLine($"Enter national ID for employee #{i + 1}");
                }
                while (!Int32.TryParse(Console.ReadLine(), out nationalID));

                do
                {
                    Console.WriteLine($"Enter salary for employee #{i + 1}");
                }
                while (!Decimal.TryParse(Console.ReadLine(), out salary));

                do
                {
                    Console.WriteLine($"Enter gender [M, F] for employee #{i + 1}");
                }
                while (!Enum.TryParse(typeof(Gender), Console.ReadLine(), out temp));
                gender = (Gender)temp;

                do
                {
                    Console.WriteLine($"Enter permission [guest,developer,secretary,DBA,securityofficer] for employee #{i + 1}");
                }
                while (!Enum.TryParse(typeof(Permissions), Console.ReadLine(), out temp));
                permissions = (Permissions)temp;

                do
                {
                    Console.WriteLine($"Entre hiring date for employee #{i + 1}");
                }
                while (!HiringDate.TryHiringDate(Console.ReadLine(), out temp));
                hiringDate = (HiringDate)temp!;

                employees[nationalID, name!, hiringDate] = new Employee(nationalID, gender, permissions, salary, hiringDate);
            }

            /*Array.Sort(employees, new MyComparer());*/

            Console.WriteLine();

            Console.WriteLine("Enter name");
            name = Console.ReadLine();

            Console.WriteLine(employees[name!]);

            /*for (int i = 0; i < employees.Capacity; i++)
            {
                Console.WriteLine(employees[i]);
            }*/
        }
    }
}