using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MoviesActors.Models
{
    public enum MovieType
    {
        Horror, Comedy, Action, Drama
    }

    public class Movie
    {
        public int Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        [Required]
        public MovieType Type { get; set; }
        public Decimal? Duration { get; set; }
        public int? Rate { get; set; }
        public string? Producer { get; set; }
        public virtual HashSet<Actor> Actors { get; set; } = default!;
    }
}
