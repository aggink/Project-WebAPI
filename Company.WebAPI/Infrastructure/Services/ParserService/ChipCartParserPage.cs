using Company.Data.DbContexts;
using Company.Entity.Products;
using Company.Parser.Interfaces;
using Company.WebAPI.Infrastructure.Repositories.Base;
using Company.WebAPI.Infrastructure.Services.ParserService.Base;

namespace Company.WebAPI.Infrastructure.Services.ParserService;

public class ChipCartParserPage : ProductParserPage<ProductDbContext, ChipCartProduct, ChipCartParserPage>
{
    public ChipCartParserPage(
        IRepository<ProductDbContext, ChipCartProduct> repository, 
        IProperty<ChipCartProduct> paramsProperty,
        ILogger<ProductParserPage<ProductDbContext, ChipCartProduct, ChipCartParserPage>> logger) 
        : base(repository, paramsProperty, logger)
    {
    }

    protected override ChipCartProduct GetEntity()
    {
        return new ChipCartProduct();
    }
}
