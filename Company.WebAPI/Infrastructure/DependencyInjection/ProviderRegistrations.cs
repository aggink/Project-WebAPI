using Company.Entity.Products;
using Company.WebAPI.Infrastructure.Providers.ParserProviders;
using Company.WebAPI.Infrastructure.Providers.ParserProviders.Interfaces;
using Company.WebAPI.Infrastructure.Providers.ProductProviders;
using Company.WebAPI.Infrastructure.Providers.ProductProviders.Interfaces;

namespace Company.WebAPI.Infrastructure.DependencyInjection;

/// <summary>
/// Dependency Injection Registration
/// </summary>
public partial class DependencyContainer
{
    /// <summary>
    /// Registration TEntity Managers
    /// </summary>
    /// <param name="services"></param>
    public static void EntityProviders(IServiceCollection services)
    {
        services.AddTransient<IFieldParserProvider, FieldParserProvider>();
        services.AddTransient<IPropertyParserProvider, PropertyParserProvider>();
        services.AddTransient<IWorkParserProvider, WorkParserProvider>();

        services.AddTransient<IProductProvider<BulatProduct>, BulatProductProvider>();
        services.AddTransient<IProductProvider<RamisProduct>, RamisProductProvider>();
        services.AddTransient<IProductProvider<ZipZipProduct>, ZipZipProductProvider>(); 
        services.AddTransient<IProductProvider<ChipCartProduct>, ChipCartProductProvider>();

    }
}