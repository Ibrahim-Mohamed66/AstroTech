using AstroTech.BLL.Contracts;
using AstroTech.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AstroTech.BLL.Extensions;
public static class ApplicationServicesExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}
