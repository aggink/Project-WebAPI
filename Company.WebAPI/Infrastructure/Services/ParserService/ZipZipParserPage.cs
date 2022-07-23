using Company.Data.DbContexts;
using Company.Entity.Products;
using Company.Parser.Interfaces;
using Company.WebAPI.Infrastructure.Repositories.Base;
using Company.WebAPI.Infrastructure.Services.ParserService.Base;

namespace Company.WebAPI.Infrastructure.Services.ParserService;

public class ZipZipParserPage : ProductParserPage<ProductDbContext, ZipZipProduct, ZipZipParserPage>
{
    public ZipZipParserPage(
        IRepository<ProductDbContext, ZipZipProduct> repository, 
        IProperty<ZipZipProduct> paramsProperty,
        ILogger<ProductParserPage<ProductDbContext, ZipZipProduct, ZipZipParserPage>> logger) 
        : base(repository, paramsProperty,logger)
    {
    }

    protected override ZipZipProduct GetEntity()
    {
        return new ZipZipProduct();
    }
}
