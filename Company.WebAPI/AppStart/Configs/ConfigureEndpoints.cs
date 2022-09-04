namespace Company.WebAPI.AppStart.Configs;

/// <summary>
/// AddBaseConfigureServices pipeline
/// </summary>
public static class ConfigureEndpoints
{
    /// <summary>
    /// AddBaseConfigureServices Routing
    /// </summary>
    /// <param name="app">Интерфейс, предоставляющий механизмы настройки конвейера запросов приложения.</param>
    /// <returns>Интерфейс, предоставляющий механизмы настройки конвейера запросов приложения.</returns>
    public static IApplicationBuilder AddEndpointsConfigure(this IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        return app;
    }
}