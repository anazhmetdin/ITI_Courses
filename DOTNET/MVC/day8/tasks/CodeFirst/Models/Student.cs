using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public enum Gender
    {
        Male, Female
    }

    public class Student
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
