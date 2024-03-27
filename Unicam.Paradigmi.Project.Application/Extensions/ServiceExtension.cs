using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unicam.Paradigmi.Project.Application.Abstractions.Services;
using Unicam.Paradigmi.Project.Application.Services;

namespace Unicam.Paradigmi.Project.Application.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddScoped<IUserService, UserService>();
        
        return services;
    }
}