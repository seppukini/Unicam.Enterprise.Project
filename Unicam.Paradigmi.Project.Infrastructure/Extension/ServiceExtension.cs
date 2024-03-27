using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unicam.Paradigmi.Project.Infrastructure.Context;

namespace Unicam.Paradigmi.Project.Infrastructure.Extension;

public static class ServiceExtension
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<MyDbContext>(conf => 
            conf.UseSqlServer(configuration.GetConnectionString("MyDbContext")));
        
        // TODO: Add repositories .AddScoped<Repository>();
        
        return services;
    }
}