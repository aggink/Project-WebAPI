using Company.WebAPI.Infrastructure.Managers.ParserManagers;
using Company.WebAPI.Infrastructure.Managers.ParserManagers.Interfaces;

namespace Company.WebAPI.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Dependency Injection Registration
    /// </summary>
    public partial class DependencyContainer
    {
        /// <summary>
        /// Registration Entity Managers
        /// </summary>
        /// <param name="services"></param>
        public static void EntityManagers(IServiceCollection services)
        {
            services.AddTransient<IFieldParserManager, FieldParserManager>();
            services.AddTransient<IPropertyParserManager, PropertyParserManager>();
            services.AddTransient<IWorkParserManager, WorkParserManager>();
        }
    }
}