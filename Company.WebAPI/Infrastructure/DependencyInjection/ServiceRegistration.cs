using Company.Entity.Parser;
using Company.Entity.Products;
using Company.Parser;
using Company.Parser.Interfaces;
using Company.WebAPI.Infrastructure.Services.ParserService;
using System.Reflection;

namespace Company.WebAPI.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Dependency Injection Registration
    /// </summary>
    public partial class DependencyContainer
    {
        /// <summary>
        /// Registration EntityValidators
        /// </summary>
        /// <param name="services"></param>
        public static void EntityServices(IServiceCollection services)
        {
            #region Parser Service

            RegisterParserPage(services);

            services.AddTransient<IProperty<BulatProduct>, Property<BulatProduct>>();
            services.AddTransient<IProperty<RamisProduct>, Property<RamisProduct>>();
            services.AddTransient<IProperty<ChipCartProduct>, Property<ChipCartProduct>>();
            services.AddTransient<IProperty<ZipZipProduct>, Property<ZipZipProduct>>();

            services.AddTransient<IParserPage<BulatParserPage, PropertyParser>, BulatParserPage>();
            services.AddTransient<IParserPage<RamisParserPage, PropertyParser>, RamisParserPage>();
            services.AddTransient<IParserPage<ChipCartParserPage, PropertyParser>, ChipCartParserPage>();
            services.AddTransient<IParserPage<ZipZipParserPage, PropertyParser>, ZipZipParserPage>();


            #endregion
        }

        private static void RegisterParserPage(IServiceCollection services)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && !t.IsAbstract);
            foreach (var type in types)
            {
                foreach (var i in type.GetInterfaces())
                {
                    if (!i.IsGenericType || i.GetGenericTypeDefinition() != typeof(IParserPage<,>)) continue;

                    var interfaceType = typeof(IParserPage<,>).MakeGenericType(i.GetGenericArguments());
                    services.AddTransient(interfaceType, type);
                }
            }
        }
    }
}