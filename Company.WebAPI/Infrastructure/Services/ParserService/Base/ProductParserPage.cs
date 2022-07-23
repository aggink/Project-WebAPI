using AngleSharp.Dom;
using Company.Data.Base;
using Company.Entity.Base;
using Company.Entity.Parser;
using Company.Entity.Products;
using Company.Parser;
using Company.Parser.Interfaces;
using Company.WebAPI.Infrastructure.EventLogging;
using Company.WebAPI.Infrastructure.Repositories.Base;

namespace Company.WebAPI.Infrastructure.Services.ParserService.Base;

/// <summary>
/// Парсинг веб-сайта
/// </summary>
public abstract class ProductParserPage<TDbContext, TProduct, TParserPage> : ParserPage<TParserPage, PropertyParser>
    where TParserPage : ParserPage<TParserPage, PropertyParser>
    where TDbContext : DbContextBase
    where TProduct : Auditable, IPropertyParserId
{
    #region Constructor

    private readonly IRepository<TDbContext, TProduct> _repository;
    private readonly IProperty<TProduct> _paramsProperty;
    private readonly ILogger<ProductParserPage<TDbContext, TProduct, TParserPage>> _logger;
    public ProductParserPage(
        IRepository<TDbContext, TProduct> repository,
        IProperty<TProduct> paramsProperty,
        ILogger<ProductParserPage<TDbContext, TProduct, TParserPage>> logger) : base()
    {
        _repository = repository;
        _paramsProperty = paramsProperty;
        _logger = logger;
    }

    #endregion

    protected abstract TProduct GetEntity();
    protected override async Task<IEnumerable<string?>> ParseAsync()
    {
        TProduct product = GetEntity();
        product.PropertyParserId = ParserProperty.Id;

        int SearchOk = 0;
        foreach (var property in ParserProperty.ParserParams)
        {
            if (!string.IsNullOrEmpty(property.StringParse))
            {
                IElement? element = HtmlDocument.QuerySelector(property.StringParse);
                if (element != null)
                {
                    SearchOk++;
                    var text = StripHTML(element.TextContent);
                    if (!string.IsNullOrEmpty(text))
                    {
                        _paramsProperty.SetValueInProperty(product, new Parser.Entities.Parameter(property.PropertyName, text));
                        continue;
                    }
                }
            }

            _paramsProperty.SetValueInProperty(product, new Parser.Entities.Parameter(property.PropertyName, property.DefaultValue));
        }

        if (SearchOk > 0)
        {
            var result = await _repository.CreateAsync(product);
            if (!result)
            {
                Events.EntitySaveFailed(_logger, nameof(TProduct), HtmlDocument.Url, null);
            }
        }

        return GetAllTagLinks();
    }
}