using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineesITI.Models
{
    public enum Gender
    {
        Male, Female
    }

    public class Trainee : BaseModel
    {
        [Required]
        [MaxLength(64)]
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
        public DateTime Birthdate { get; set; }
        public int TrackId { get; set; }
        public virtual Track Track { get; set; }
    }
}
