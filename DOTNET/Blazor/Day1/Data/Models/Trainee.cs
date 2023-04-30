using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public enum Gender
    {
        Male, Female
    }
    public class Trainee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Mobile number is required.")]
        [Phone(ErrorMessage = "Invalid mobile number.")]
        public string MobileNo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Birthdate is required.")]
        public DateTime Birthdate { get; set; }
        public bool IsGraduated { get; set; }


        public int TrackId { get; set; }
    }
}
