using TraineesITI.Data;
using Microsoft.EntityFrameworkCore;
using TraineesITI.Repositories.Tracks;
using TraineesITI.Repositories.Courses;
using TraineesITI.Repositories.Trainees;
using TraineesITI.Repositories;
using TraineesITI.Models;
using TraineesITI.Areas.TrackCourses.Models;
using TraineesITI.Areas.TraineeCourses.Models;
using Microsoft.AspNetCore.Identity;
using TraineesITI.Areas.Identity.Data;

namespace TraineesITI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<TraineesITIContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("TraineesITIContextConnection"));
            });
            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("TraineesITI"));
            });
            builder.Services.AddDefaultIdentity<TraineesITIUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<TraineesITIContext>();

            builder.Services.AddScoped<IModelRepo<Track>, TracksRepo>();
            builder.Services.AddScoped<IModelRepo<Course>, CoursesRepo>();
            builder.Services.AddScoped<IModelRepo<Trainee>, TraineesRepo>();
            builder.Services.AddScoped<IModelRepo<TrackCourse>, TrackCoursesRepo>();
            builder.Services.AddScoped<IModelRepo<TraineeCourse>, TraineeCoursesRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapAreaControllerRoute("TrackCourses", "TrackCourses",
                "Track/{tid:int}/Courses/{action=Index}/{id?}",
                new { controller = "TrackCourses" });

            app.MapAreaControllerRoute("TraineeCourses", "TraineeCourses",
                "Trainee/{tid:int}/Courses/{action=Index}/{id?}",
                new { controller = "TraineeCourses" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}