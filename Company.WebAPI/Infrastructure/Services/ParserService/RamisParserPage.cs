using Company.Data.DbContexts;
using Company.Entity.Products;
using Company.Parser.Interfaces;
using Company.WebAPI.Infrastructure.Repositories.Base;
using Company.WebAPI.Infrastructure.Services.ParserService.Base;

namespace Company.WebAPI.Infrastructure.Services.ParserService;

public class RamisParserPage : ProductParserPage<ProductDbContext, RamisProduct, RamisParserPage>
{
    public RamisParserPage(
        IRepository<ProductDbContext, RamisProduct> repository, 
        IProperty<RamisProduct> paramsProperty,
        ILogger<ProductParserPage<ProductDbContext, RamisProduct, RamisParserPage>> logger) 
        : base(repository, paramsProperty, logger)
    {
    }

    protected override RamisProduct GetEntity()
    {
        return new RamisProduct();
    }
}
