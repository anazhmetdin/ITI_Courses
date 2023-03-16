using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CodeFirst.Data;
namespace CodeFirst;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<CodeFirstContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("CodeFirstContext")));

        // Add services to the container.
        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.MapControllerRoute("student_course", "Student/{sid:int}/Courses/{action=Index}/{id:int?}",
                                new {controller = "StudentCourses", area = "StudentCoursesArea" });

        app.MapControllerRoute("default", "{controller}/{action=Index}/{id?}");

        app.Run();
    }
}
