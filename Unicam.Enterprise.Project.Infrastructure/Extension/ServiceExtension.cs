using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unicam.Enterprise.Project.Infrastructure.Context;
using Unicam.Enterprise.Project.Infrastructure.Repositories;
using Unicam.Enterprise.Project.Infrastructure.Repositories.Abstractions;

namespace Unicam.Enterprise.Project.Infrastructure.Extension;

public static class ServiceExtension
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MyDbContext>(conf => 
            conf.UseSqlServer(configuration.GetConnectionString("MyDbContext")));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
    }
}