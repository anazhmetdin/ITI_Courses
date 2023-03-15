using System.ComponentModel.DataAnnotations;

namespace Cars.Model
{
    public class Car
    {
        [Key]
        public int Num { get; set; }
        [Required]
        [MaxLength(16)]
        public string Color { get; set; }
        [Required]
        [MaxLength(32)]
        public string Manufacture { get; set; }
        [Required]
        [MaxLength(32)]
        public string Model { get; set; }
    }
}
