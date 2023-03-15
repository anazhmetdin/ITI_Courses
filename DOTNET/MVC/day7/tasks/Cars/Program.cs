using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cars.Data;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cars
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<CarsContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CarsContext") ?? throw new InvalidOperationException("Connection string 'CarsContext' not found.")));

                /*services.AddTransient<ITagHelperComponent,
        AddressScriptTagHelperComponent>();
            services.AddTransient<ITagHelperComponent,
                AddressStyleTagHelperComponent>();*/

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}