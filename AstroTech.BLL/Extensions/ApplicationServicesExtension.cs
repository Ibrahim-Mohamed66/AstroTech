using AstroTech.Application.Contracts;
using AstroTech.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AstroTech.Application.Extensions;
public static class ApplicationServicesExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}
