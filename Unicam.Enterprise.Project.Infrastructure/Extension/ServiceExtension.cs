using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unicam.Enterprise.Project.Infrastructure.Context;
using Unicam.Enterprise.Project.Infrastructure.Repositories;
using Unicam.Enterprise.Project.Infrastructure.Repositories.Abstractions;

namespace Unicam.Enterprise.Project.Infrastructure.Extension;

/// <summary>
/// Extension class for adding infrastructure services.
/// </summary>
public static class ServiceExtension
{
    /// <summary>
    /// Adds infrastructure services to the DI container.
    /// </summary>
    /// <param name="services">The DI container.</param>
    /// <param name="configuration">The configuration.</param>
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure the MyDbContext to use SQL Server
        services.AddDbContext<MyDbContext>(conf => 
            conf.UseSqlServer(configuration.GetConnectionString("MyDbContext")));

        // Register the repositories as scoped dependencies
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
    }
}