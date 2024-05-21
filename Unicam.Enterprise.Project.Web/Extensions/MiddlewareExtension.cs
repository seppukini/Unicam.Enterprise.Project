
namespace Unicam.Enterprise.Project.Extensions;

/// <summary>
/// Extension method for adding middleware to the web application.
/// </summary>
public static class MiddlewareExtension
{
    /// <summary>
    /// Adds middleware to the web application.
    /// </summary>
    public static void AddWebMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
    }
}