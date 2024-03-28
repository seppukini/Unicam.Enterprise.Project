using Microsoft.Extensions.DependencyInjection;
using Unicam.Paradigmi.Project.Application.Services;
using Unicam.Paradigmi.Project.Application.Services.Abstractions;

namespace Unicam.Paradigmi.Project.Application.Extensions;

public static class ServiceExtension
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }
}