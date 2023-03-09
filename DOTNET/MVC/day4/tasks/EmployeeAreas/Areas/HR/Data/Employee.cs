using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeAreas.Areas.HR.Data
{
	public enum Gender
	{
		Male, Female
	}

	public class Employee
	{
		[Key]
		public int EmployeeID { get; set; }
		[Required(ErrorMessage = "Enter Employee Name")]
		public string Name { get; set; }
        [Required(ErrorMessage = "Enter Employee Username")]
		[MaxLength(16, ErrorMessage = "Username Length Must Be In Range [5 - 16]")]
		[MinLength(5, ErrorMessage = "Username Length Must Be In Range [5 - 16]")]
        public string Username { get; set; }
		[Required(ErrorMessage = "Enter Password")]
		[MinLength(8, ErrorMessage = "Password Minimum Length is 8 characters")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required(ErrorMessage = "Enter Employee Gender")]
		public Gender Gender { get; set; }
		[DataType(DataType.Currency)]
		public decimal Salary { get; set; } = 4000;
		[DataType(DataType.Date)]
		public DateTime JoinDate { get; set; } = DateTime.Now;
		[Required(ErrorMessage = "Enter Employee Email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required(ErrorMessage = "Enter Employee Phone Number")]
		[RegularExpression("[0-9]{13}", ErrorMessage = "Phone Number Not Valid")]
		public string Phone { get; set; }
	}
}