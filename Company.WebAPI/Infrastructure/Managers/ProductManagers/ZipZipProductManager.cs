using AutoMapper;
using Company.Data.DbContexts;
using Company.Entity.Products;
using Company.WebAPI.Infrastructure.Managers.ProductManagers.Base;
using Company.WebAPI.Infrastructure.Providers.ProductProviders.Interfaces;
using Company.WebAPI.Infrastructure.Repositories.Base;
using Company.WebAPI.ViewModels.ProductViewModels.ZipZipProductViewModels;

namespace Company.WebAPI.Infrastructure.Managers.ProductManagers;

public class ZipZipProductManager : BaseProductManager
    <CreateZipZipProductViewModel, UpdateZipZipProductViewModel, ZipZipProductViewModel, ZipZipProduct, ProductDbContext>
{
    

    public ZipZipProductManager(
        IRepository<ProductDbContext, ZipZipProduct> repository,
        IProductProvider<ZipZipProduct> provider,
        IMapper mapper) : base(repository, provider, mapper)
    {
        
    }

    
}