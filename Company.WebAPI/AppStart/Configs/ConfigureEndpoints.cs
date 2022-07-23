namespace Company.WebAPI.AppStart.Configs;

/// <summary>
/// Configure pipeline
/// </summary>
public static class ConfigureEndpoints
{
    /// <summary>
    /// Configure Routing
    /// </summary>
    /// <param name="app"></param>
    public static void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}