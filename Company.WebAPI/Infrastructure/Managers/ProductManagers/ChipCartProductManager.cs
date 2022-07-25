using AutoMapper;
using Company.Data.DbContexts;
using Company.Entity.Products;
using Company.WebAPI.Infrastructure.Managers.ProductManagers.Base;
using Company.WebAPI.Infrastructure.Providers.ProductProviders.Interfaces;
using Company.WebAPI.Infrastructure.Repositories.Base;
using Company.WebAPI.ViewModels.ProductViewModels.ChipCartProductViewModels;

namespace Company.WebAPI.Infrastructure.Managers.ProductManagers;

public class ChipCartProductManager : BaseProductManager
    <CreateChipCartProductViewModel, UpdateChipCartProductViewModel, ChipCartProductViewModel, ChipCartProduct, ProductDbContext>
{


    public ChipCartProductManager(
        IRepository<ProductDbContext, ChipCartProduct> repository,
        IProductProvider<ChipCartProduct> provider,
        IMapper mapper) : base(repository, provider, mapper)
    {
        
    }

    
}