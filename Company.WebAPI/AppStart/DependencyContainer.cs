using Company.Base.Infractructure.Repository;
using Company.Data.DbContexts;
using Company.Entity;
using Company.WebAPI.Infrastructure.Managers.ParseValuesProductManager;
using Company.WebAPI.Infrastructure.Managers.ProductManagers;
using Company.WebAPI.Infrastructure.Providers.ParseValuesProductProvider;
using Company.WebAPI.Infrastructure.Providers.ProductProviders;

namespace Company.WebAPI.AppStart;

/// <summary>
/// Dependency Injection Registration
/// </summary>
public static class DependencyContainer
{
    /// <summary>
    /// Регистрация базовых служб.
    /// </summary>
    /// <param name="services">Контракт для коллекции дескрипторов служб.</param>
    /// <returns>Контракт для коллекции дескрипторов служб.</returns>
    public static IServiceCollection AddCommonConfigureServices(this IServiceCollection services)
    { 

        return services;
    }

    /// <summary>
    /// Registration  Managers
    /// </summary>
    /// <param name="services">Контракт для коллекции дескрипторов служб</param>
    /// <returns>Контракт для коллекции дескрипторов служб</returns>
    public static IServiceCollection AddManagersConfigureServices(this IServiceCollection services)
    {
        services.AddTransient<IProductManager, ProductManager>();
        services.AddTransient<IParseValuesProductManager, ParseValuesProductManager>();

        return services;
    }

    /// <summary>
    /// Registration Providers
    /// </summary>
    /// <param name="services">Контракт для коллекции дескрипторов служб</param>
    /// <returns>Контракт для коллекции дескрипторов служб</returns>
    public static IServiceCollection AddProvidersConfigureServices(this IServiceCollection services)
    {
        services.AddTransient<IProductProvider, ProductProvider>();
        services.AddTransient<IParseValuesProductProvider, ParseValuesProductProvider>();

        return services;
    }

    /// <summary>
    /// Registration Services
    /// </summary>
    /// <param name="services">Контракт для коллекции дескрипторов служб</param>
    /// <returns>Контракт для коллекции дескрипторов служб</returns>
    public static IServiceCollection AddRepositoriesConfigureServices(this IServiceCollection services)
    {
        services.AddTransient<IBaseRepository<CatalogDbContext, Product>, BaseRepository<CatalogDbContext, Product>>();
        services.AddTransient<IBaseRepository<CatalogDbContext, ParseValuesProduct>, BaseRepository<CatalogDbContext, ParseValuesProduct>>();

        return services;
    }

    /// <summary>
    /// Registration Services
    /// </summary>
    /// <param name="services">Контракт для коллекции дескрипторов служб</param>
    /// <returns>Контракт для коллекции дескрипторов служб</returns>
    public static IServiceCollection AddServicesConfigureServices(this IServiceCollection services)
    {

        return services;
    }
}