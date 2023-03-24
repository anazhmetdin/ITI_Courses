using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DepartmentInstructor.Models
{
    public class PhoneNumber : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
                return false;

            if (value is string phone && new Regex("[0-9]{13}").IsMatch(phone))
                return true;

            return false;
        }
    }
}
