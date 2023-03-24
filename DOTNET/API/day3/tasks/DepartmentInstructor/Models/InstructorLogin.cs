using System.ComponentModel.DataAnnotations.Schema;

namespace DepartmentInstructor.Models
{
    [NotMapped]
    public class InstructorLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
