using AutoMapper;
using Company.Data.DbContexts;
using Company.Entity.Products;
using Company.WebAPI.Infrastructure.Managers.ProductManagers.Base;
using Company.WebAPI.Infrastructure.Providers.ProductProviders.Interfaces;
using Company.WebAPI.Infrastructure.Repositories.Base;
using Company.WebAPI.ViewModels.ProductViewModels.BulatProductViewModels;

namespace Company.WebAPI.Infrastructure.Managers.ProductManagers;

public class BulatProductManager : BaseProductManager
    <CreateBulatProductViewModel, UpdateBulatProductViewModel, BulatProductViewModel, BulatProduct, ProductDbContext>
{
    

    public BulatProductManager(
        IRepository<ProductDbContext, BulatProduct> repository,
        IProductProvider<BulatProduct> provider,
        IMapper mapper) : base(repository, provider, mapper)
    {

    }

    
}