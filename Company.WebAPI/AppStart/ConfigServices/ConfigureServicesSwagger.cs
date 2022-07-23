using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Company.WebAPI.AppStart.ConfigServices;

/// <summary>
/// Swagger configuration
/// </summary>
public static class ConfigureServicesSwagger
{
    private const string AppTitle = "Microservice API";
    private static readonly string AppVersion = $"0.0.0";
    private const string SwaggerConfig = "/swagger/v1/swagger.json";

    /// <summary>
    /// ConfigureServices Swagger services
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services!.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = AppTitle,
                Version = AppVersion,
                Description = "Microservice module API. This project based on .NET 6.0."
            });

            options.ResolveConflictingActions(x => x.First());
        });
    }

    /// <summary>
    /// Set up some properties for swagger UI
    /// </summary>
    /// <param name="settings"></param>
    public static void SwaggerSettings(SwaggerUIOptions settings)
    {
        settings.SwaggerEndpoint(SwaggerConfig, $"{AppTitle} v.{AppVersion}");
        settings.DocumentTitle = $"{AppTitle}";
        settings.DefaultModelExpandDepth(0);
        settings.DefaultModelRendering(ModelRendering.Model);
        settings.DefaultModelsExpandDepth(0);
        settings.DocExpansion(DocExpansion.None);
        settings.OAuthClientId("microservice1");
        settings.OAuthScopeSeparator(" ");
        settings.OAuthClientSecret("secret");
        settings.DisplayRequestDuration();
        settings.OAuthAppName("Microservice module API");
    }
}
