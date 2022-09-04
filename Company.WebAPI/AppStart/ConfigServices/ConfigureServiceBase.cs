using Calabonga.UnitOfWork;
using Company.Data.DbContexts;
using Company.Parser;
using Company.Parser.Data;
using Company.WebAPI.Infrastructure.Working;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.WebAPI.AppStart.ConfigServices;

/// <summary>
/// Начальные настройки приложения
/// </summary>
public static class ConfigureServiceBase
{
    /// <summary>
    /// AddBaseConfigureServices Services
    /// </summary>
    /// <param name="services">Контракт для коллекции дескрипторов служб</param>
    /// <param name="configuration">Набор свойств конфигурации приложения</param>
    /// <returns>Контракт для коллекции дескрипторов служб</returns>
    public static IServiceCollection AddBaseConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region AddDbContext

        services.AddDbContext<CatalogDbContext>(options => 
        {
            options.UseSqlServer(configuration.GetConnectionString("CatalogDbConnection"));
        });

        #endregion

        #region AddWork

        services.AddUnitOfWork<CatalogDbContext>();
        services.AddParser<CatalogDbContext, ParserBackgroundWorker>();

        #endregion
        
        services.AddAutoMapper(typeof(Startup));

        services.AddControllers();

        services.AddMemoryCache();
        services.AddRouting();
        services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
        services.AddOptions();
        services.AddLocalization();
        services.AddHttpContextAccessor();
        services.AddResponseCaching();
        services.AddAntiforgery();

        return services;
    }
}
