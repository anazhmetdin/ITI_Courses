using Microsoft.EntityFrameworkCore;
using TraineesITI.Areas.TrackCourses.Models;
using TraineesITI.Areas.TraineeCourses.Models;
using TraineesITI.Models;

namespace TraineesITI.Data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> dbContextOptions):
            base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trainee>().Navigation(e => e.Track).AutoInclude();
            modelBuilder.Entity<TrackCourse>().Navigation(e => e.Track).AutoInclude();
            modelBuilder.Entity<TrackCourse>().Navigation(e => e.Course).AutoInclude();
            modelBuilder.Entity<TraineeCourse>().Navigation(e => e.Course).AutoInclude();
            modelBuilder.Entity<TraineeCourse>().Navigation(e => e.Trainee).AutoInclude();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Track> Tracks { get; set; } = default!;
        public DbSet<Trainee> Trainees { get; set; } = default!;
        public DbSet<Course> Courses { get; set; } = default!;
        public DbSet<TrackCourse> TrackCourses { get; set; } = default!;
        public DbSet<TraineeCourse> TraineeCourses { get; set; } = default!;
    } 
}
