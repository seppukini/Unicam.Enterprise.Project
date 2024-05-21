using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Unicam.Enterprise.Project.Application.Services;
using Unicam.Enterprise.Project.Application.Services.Abstractions;

namespace Unicam.Enterprise.Project.Application.Extensions;

/// <summary>
/// Extension class for adding application services to the service collection.
/// </summary>
public static class ServiceExtension
{
    /// <summary>
    /// Adds application services to the service collection.
    /// </summary>
    /// <param name="services"></param>
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IHistoryService, HistoryService>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}