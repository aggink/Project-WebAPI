using Company.WebAPI.Infrastructure.Providers.ParserProviders;
using Company.WebAPI.Infrastructure.Providers.ParserProviders.Interfaces;

namespace Company.WebAPI.Infrastructure.DependencyInjection;

/// <summary>
/// Dependency Injection Registration
/// </summary>
public partial class DependencyContainer
{
    /// <summary>
    /// Registration Entity Managers
    /// </summary>
    /// <param name="services"></param>
    public static void EntityProviders(IServiceCollection services)
    {
        services.AddTransient<IFieldParserProvider, FieldParserProvider>();
        services.AddTransient<IPropertyParserProvider, PropertyParserProvider>();
        services.AddTransient<IWorkParserProvider, WorkParserProvider>();
    }
}