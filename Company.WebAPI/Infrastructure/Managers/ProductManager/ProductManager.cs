using AutoMapper;
using Company.Base.Infractructure.Manager;
using Company.Base.Infractructure.Repository;
using Company.Data.DbContexts;
using Company.Entity;
using Company.WebAPI.Infrastructure.Providers.ProductProviders;
using Company.WebAPI.ViewModels.ProductViewModels;

namespace Company.WebAPI.Infrastructure.Managers.ProductManagers;

public class ProductManager : BaseManager<CreateProductViewModel, UpdateProductViewModel, ProductViewModel, Product, CatalogDbContext>, IProductManager
{
    private readonly IProductProvider _productProvider;

    public ProductManager(
        IBaseRepository<CatalogDbContext, Product> repository,
        IProductProvider productProvider,
        IMapper mapper) : base(repository, mapper)
    {
        _productProvider = productProvider;
    }

    
}