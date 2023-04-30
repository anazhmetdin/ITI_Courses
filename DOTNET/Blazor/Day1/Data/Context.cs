using Data.Models;

namespace Data
{
    public class Context
    {
        public static List<Track> Tracks { get; set; } = new()
        {
            new Track { Id = 1, Name = "C# Programming", Description = "Learn how to program with C#" },
            new Track { Id = 2, Name = "ASP.NET Core", Description = "Build web applications with ASP.NET Core" },
            new Track { Id = 3, Name = "JavaScript", Description = "Master JavaScript and front-end web development" },
            new Track { Id = 4, Name = "Python", Description = "Get started with Python programming" },
            new Track { Id = 5, Name = "Machine Learning", Description = "Learn how to build intelligent applications" },
        };

        public static List<Trainee> Trainees { get; set; } = new()
        {
            new Trainee { Id = 1, Name = "John Doe", Gender = Gender.Male, Email = "john.doe@example.com", MobileNo = "555-1234", Birthdate = new DateTime(1995, 10, 5), IsGraduated = true, TrackId = 1 },
            new Trainee { Id = 2, Name = "Jane Smith", Gender = Gender.Female, Email = "jane.smith@example.com", MobileNo = "555-5678", Birthdate = new DateTime(1998, 4, 12), IsGraduated = false, TrackId = 2 },
            new Trainee { Id = 3, Name = "Bob Johnson", Gender = Gender.Male, Email = "bob.johnson@example.com", MobileNo = "555-9012", Birthdate = new DateTime(2000, 8, 27), IsGraduated = true, TrackId = 3 },
            new Trainee { Id = 4, Name = "Alice Lee", Gender = Gender.Female, Email = "alice.lee@example.com", MobileNo = "555-3456", Birthdate = new DateTime(1997, 1, 3), IsGraduated = false, TrackId = 4 },
            new Trainee { Id = 5, Name = "Tom Wilson", Gender = Gender.Male, Email = "tom.wilson@example.com", MobileNo = "555-7890", Birthdate = new DateTime(1999, 6, 20), IsGraduated = true, TrackId = 5 }
        };
    }
}