using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    public class StudentCourse
    {
        public int Id { get; set; }
        [Required]
        public virtual Student Student { get; set; }
        [Required]
        public virtual Course Course { get; set; }
        [Range(0, 100)]
        public int Grade { get; set; }
    }
}
