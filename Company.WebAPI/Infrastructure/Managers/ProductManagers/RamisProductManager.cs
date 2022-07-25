using AutoMapper;
using Company.Data.DbContexts;
using Company.Entity.Products;
using Company.WebAPI.Infrastructure.Managers.ProductManagers.Base;
using Company.WebAPI.Infrastructure.Providers.ProductProviders.Interfaces;
using Company.WebAPI.Infrastructure.Repositories.Base;
using Company.WebAPI.ViewModels.ProductViewModels.RamisProductViewModels;

namespace Company.WebAPI.Infrastructure.Managers.ProductManagers;

public class RamisProductManager : BaseProductManager
    <CreateRamisProductViewModel, UpdateRamisProductViewModel, RamisProductViewModel, RamisProduct, ProductDbContext>
{
    

    public RamisProductManager(
        IRepository<ProductDbContext, RamisProduct> repository,
        IProductProvider<RamisProduct> provider,
        IMapper mapper) : base(repository, provider, mapper)
    {
        
    }

    
}