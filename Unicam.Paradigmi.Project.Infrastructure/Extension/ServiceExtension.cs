using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unicam.Paradigmi.Project.Infrastructure.Context;
using Unicam.Paradigmi.Project.Infrastructure.Repositories;

namespace Unicam.Paradigmi.Project.Infrastructure.Extension;

public static class ServiceExtension
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<MyDbContext>(conf => 
            conf.UseSqlServer(configuration.GetConnectionString("MyDbContext")));
        
        services.AddScoped<UserRepository>();
        services.AddScoped<OrderRepository>();
        services.AddScoped<CourseRepository>();
        
        return services;
    }
}