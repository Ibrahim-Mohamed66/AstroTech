using AstroTech.BLL.Contracts;
using AstroTech.BLL.Services;
using AstroTech.DAL.Contracts;  // For repository interfaces
using AstroTech.DAL.Repository; // For repository implementations
using Microsoft.Extensions.DependencyInjection;

namespace AstroTech.BLL.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register Services (BLL)
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
