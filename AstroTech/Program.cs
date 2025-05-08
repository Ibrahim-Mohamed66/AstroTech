using AstroTech.Infrastructure.Extensions;
using AstroTech.Application.Extensions;
using AstroTech.Infrastructure.Contracts;
namespace AstroTech;
public class Program
{
    public static void  Main(string[] args) // Make Main async
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDataAccessServices(builder.Configuration);
        builder.Services.AddApplicationServices();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Account}/{action=Login}/{id?}");

         app.Run(); 
    }
}