using Microsoft.Extensions.DependencyInjection;
using Unicam.Enterpise.Project.Application.MappingProfiles;
using Unicam.Enterpise.Project.Application.Services;
using Unicam.Enterpise.Project.Application.Services.Abstractions;

namespace Unicam.Enterpise.Project.Application.Extensions;

public static class ServiceExtension
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddAutoMapper(typeof(UserProfile));
    }
}