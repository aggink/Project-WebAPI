using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

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
    /// AddSwaggerConfigureServices Swagger services
    /// </summary>
    /// <param name="services">Контракт для коллекции дескрипторов служб</param>
    /// <param name="configuration">Набор свойств конфигурации приложения</param>
    /// <returns>Контракт для коллекции дескрипторов служб</returns>
    public static IServiceCollection AddSwaggerConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services!.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = AppTitle,
                Version = AppVersion,
                Description = "Microservice module API. This project based on .NET 6.0."
            });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

            options.ResolveConflictingActions(x => x.First());
        });

        return services;
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
