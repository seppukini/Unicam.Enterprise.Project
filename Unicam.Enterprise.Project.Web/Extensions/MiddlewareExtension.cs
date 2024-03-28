namespace Unicam.Paradigmi.Project.Extensions;

public static class MiddlewareExtension
{
    public static void AddWebMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseHttpsRedirection();
        // app.UseAuthentication();
        app.UseAuthorization();
        
        app.MapControllers();
    }
}