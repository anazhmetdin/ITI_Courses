using System.ComponentModel.DataAnnotations;

namespace DepartmentInstructor.Models
{
    public class Department
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Location { get; set; }
        [MaxLength(100)]
        public string Branches { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public virtual ICollection<Instructor>? Instructors { get; set; }
    }
}
