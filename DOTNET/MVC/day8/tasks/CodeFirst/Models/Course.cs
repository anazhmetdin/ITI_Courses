using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Topic { get; set; }

    }
}
