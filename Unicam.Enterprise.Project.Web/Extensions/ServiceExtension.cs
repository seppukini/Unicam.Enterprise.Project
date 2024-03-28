
namespace Unicam.Paradigmi.Project.Extensions;

public static class ServiceExtension
{
    public static void AddWebServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}