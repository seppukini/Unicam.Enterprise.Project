using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Unicam.Enterprise.Project.Application.Services;
using Unicam.Enterprise.Project.Application.Services.Abstractions;

namespace Unicam.Enterprise.Project.Application.Extensions;

public static class ServiceExtension
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}