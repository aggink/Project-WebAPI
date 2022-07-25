using Calabonga.UnitOfWork;
using Company.Data.DbContexts;
using Company.Entity.Products;
using Company.WebAPI.Infrastructure.Providers.ProductProviders.Base;

namespace Company.WebAPI.Infrastructure.Providers.ProductProviders;

public class ChipCartProductProvider : BaseProductProvider<ProductDbContext, ChipCartProduct>
{
    

    public ChipCartProductProvider(
        IUnitOfWork<ProductDbContext> unitOfWork) : base(unitOfWork)
    {
        
    }

    
}