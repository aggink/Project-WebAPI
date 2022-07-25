using Calabonga.UnitOfWork;
using Company.Data.DbContexts;
using Company.Entity.Products;
using Company.WebAPI.Infrastructure.Providers.ProductProviders.Base;

namespace Company.WebAPI.Infrastructure.Providers.ProductProviders;

public class RamisProductProvider : BaseProductProvider<ProductDbContext, RamisProduct>
{
    

    public RamisProductProvider(
        IUnitOfWork<ProductDbContext> unitOfWork) : base(unitOfWork)
    {
        
    }

    
}