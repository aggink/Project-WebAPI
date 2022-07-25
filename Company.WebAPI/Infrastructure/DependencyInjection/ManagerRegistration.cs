using Company.WebAPI.Infrastructure.Managers.ParserManagers;
using Company.WebAPI.Infrastructure.Managers.ParserManagers.Interfaces;
using Company.WebAPI.Infrastructure.Managers.ProductManagers;
using Company.WebAPI.Infrastructure.Managers.ProductManagers.Base;
using Company.WebAPI.ViewModels.ProductViewModels.BulatProductViewModels;
using Company.WebAPI.ViewModels.ProductViewModels.ChipCartProductViewModels;
using Company.WebAPI.ViewModels.ProductViewModels.RamisProductViewModels;
using Company.WebAPI.ViewModels.ProductViewModels.ZipZipProductViewModels;

namespace Company.WebAPI.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Dependency Injection Registration
    /// </summary>
    public partial class DependencyContainer
    {
        /// <summary>
        /// Registration TEntity Managers
        /// </summary>
        /// <param name="services"></param>
        public static void EntityManagers(IServiceCollection services)
        {
            services.AddTransient<IFieldParserManager, FieldParserManager>();
            services.AddTransient<IPropertyParserManager, PropertyParserManager>();
            services.AddTransient<IWorkParserManager, WorkParserManager>();

            services.AddTransient<IProductManager<CreateBulatProductViewModel, UpdateBulatProductViewModel, BulatProductViewModel>, BulatProductManager>();
            services.AddTransient<IProductManager<CreateRamisProductViewModel, UpdateRamisProductViewModel, RamisProductViewModel>, RamisProductManager>();
            services.AddTransient<IProductManager<CreateZipZipProductViewModel, UpdateZipZipProductViewModel, ZipZipProductViewModel>, ZipZipProductManager>();
            services.AddTransient<IProductManager<CreateChipCartProductViewModel, UpdateChipCartProductViewModel, ChipCartProductViewModel>, ChipCartProductManager>();
        }
    }
}