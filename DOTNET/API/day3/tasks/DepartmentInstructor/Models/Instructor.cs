using System.ComponentModel.DataAnnotations;

namespace DepartmentInstructor.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        [StringLength(14)]
        public string SSN { get; set; }
        [MaxLength(16)]
        public string Name { get; set; }
        [MaxLength(32)]
        public string Address { get; set; }
        [Range(24, 65)]
        public int Age { get; set; }
        [PhoneNumber]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Range(3000, 30000)]
        public int Salary { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
    }
}
