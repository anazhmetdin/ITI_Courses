using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    public class Employee
    {
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;
        public int EmployeeID { get; }
        protected DateTime birthDate;
        protected int vacationStock;

        public Employee(int employeeID, DateTime _birthDate, int _vacationStock)
        {
            EmployeeID = employeeID;
            birthDate = _birthDate;
            VacationStock = _vacationStock;
        }

        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }

        public virtual DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                EndOfYearOperation();
            }
        }

        public virtual int VacationStock
        {
            get { return vacationStock; }
            set
            {
                if (vacationStock != value)
                {
                    vacationStock = value;
                    if (vacationStock < 0)
                    {
                        OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.NegativeVacationStock });
                    }
                }
            }
        }
        public bool RequestVacation(DateTime From, DateTime To)
        {
            VacationStock -= (To - From).Days;
            return true;
        }

        public virtual void EndOfYearOperation()
        {
            if ((DateTime.Now.Year - BirthDate.Year) >= 60)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.AgeOver60 });
            }
        }
    }

    public enum LayOffCause
    { 
        NegativeVacationStock, AgeOver60, NotAchievedTarget, Resign
    }

    public class EmployeeLayOffEventArgs: EventArgs
    {
        public LayOffCause Cause { get; set; }
    }
}
