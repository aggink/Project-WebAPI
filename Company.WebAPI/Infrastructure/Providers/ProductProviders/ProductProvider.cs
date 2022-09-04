using Calabonga.UnitOfWork;
using Company.Data.DbContexts;

namespace Company.WebAPI.Infrastructure.Providers.ProductProviders;

public class ProductProvider : IProductProvider
{
    private readonly IUnitOfWork<CatalogDbContext> _unotOfWork;

    public ProductProvider(
        IUnitOfWork<CatalogDbContext> unitOfWork) 
    {
        _unotOfWork = unitOfWork;
    }
    
}