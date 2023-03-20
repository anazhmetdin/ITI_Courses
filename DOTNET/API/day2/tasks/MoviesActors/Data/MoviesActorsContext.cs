using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesActors.Models;

namespace MoviesActors.Data
{
    public class MoviesActorsContext : DbContext
    {
        public MoviesActorsContext (DbContextOptions<MoviesActorsContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Movie>()
                .Property(m => m.Type)
                .HasConversion(new EnumToStringConverter<MovieType>());

            modelBuilder
                .Entity<Actor>()
                .Property(a => a.Gender)
                .HasConversion(new EnumToStringConverter<Gender>());
        }

        public DbSet<Movie> Movies { get; set; } = default!;
        public DbSet<Actor> Actors { get; set; } = default!;
    }
}
