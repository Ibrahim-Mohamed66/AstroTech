using AstroTech.DAL.Models;
using Microsoft.AspNetCore.Identity;
using AstroTech.BLL.Extensions;
using AstroTech.DAL.Extensions;
namespace AstroTech;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        builder.Services.AddDataAccessServices(builder.Configuration);
        builder.Services.AddApplicationServices();

        // Build the app
        var app = builder.Build();

        // Seed roles and admin user
        await SeedRolesAndAdminUser(app);

        // HTTP request pipeline
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        // Authentication and authorization middleware
        app.UseAuthentication();
        app.UseAuthorization();

        // Define default route
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Account}/{action=Login}/{id?}");

        // Run the app
        app.Run();
    }

    // Seed roles and admin user
    public static async Task SeedRolesAndAdminUser(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Create roles if they don't exist
            string[] roles = { "Admin", "User" };
            foreach (var roleName in roles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole<int>(roleName));
                }
            }

            // Seed the admin user
            await SeedAdminUser(userManager);
        }
    }

    // Seed admin user if it doesn't already exist
    public static async Task SeedAdminUser(UserManager<ApplicationUser> userManager)
    {
        var email = "admin@astrotech.com";
        var password = "Admin12345";

        var user = await userManager.FindByEmailAsync(email);

        // Check if user already exists
        if (user != null)
        {
            Console.WriteLine("ℹ️ Admin user already exists. Skipping creation.");
            return;
        }

        user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            FirstName = "Admin",
            LastName = "Astrotech",
            PhoneNumber = "12345678901",
            EmailConfirmed = true // ✅ Ensure this is true if your login requires confirmed email
        };

        var result = await userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            Console.WriteLine("✅ Admin user created successfully.");
            await userManager.AddToRoleAsync(user, "Admin");
        }
        else
        {
            Console.WriteLine("❌ Admin user creation failed:");
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"- {error.Description}");
            }
        }
    }
}
