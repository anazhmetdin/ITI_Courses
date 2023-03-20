using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace MoviesActors.Models
{
    public enum Gender
    {
        Male, Female
    }
    public class Actor
    {
        public int Id { get; set; }
        [MaxLength(64)]
        [Required]
        public string Name { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        [Range(12,120)]
        public int Age { get; set; }
        [MaxLength(256)]
        public string? Address { get; set; }
        [Required]
        public int MovieId { get; set; }
        public virtual Movie? Movie { get; set; } = default!;
    }
}