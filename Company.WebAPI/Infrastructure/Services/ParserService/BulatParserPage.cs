using Company.Data.DbContexts;
using Company.Entity.Products;
using Company.Parser.Interfaces;
using Company.WebAPI.Infrastructure.Repositories.Base;
using Company.WebAPI.Infrastructure.Services.ParserService.Base;

namespace Company.WebAPI.Infrastructure.Services.ParserService;

public class BulatParserPage : ProductParserPage<ProductDbContext, BulatProduct, BulatParserPage>
{
    public BulatParserPage(
        IRepository<ProductDbContext, BulatProduct> repository, 
        IProperty<BulatProduct> paramsProperty,
        ILogger<ProductParserPage<ProductDbContext, BulatProduct, BulatParserPage>> logger) 
        : base(repository, paramsProperty, logger)
    {
    }

    protected override BulatProduct GetEntity()
    {
        return new BulatProduct();
    }
}
