using AutoMapper;
using Company.Base.Infractructure.Manager;
using Company.Base.Infractructure.Repository;
using Company.Data.DbContexts;
using Company.Entity;
using Company.WebAPI.Infrastructure.Providers.ParseValuesProductProvider;
using Company.WebAPI.ViewModels.ParseValuesProductViewModel;

namespace Company.WebAPI.Infrastructure.Managers.ParseValuesProductManager;

public class ParseValuesProductManager : BaseManager<CreateParseValuesProductViewModel, UpdateParseValuesProductViewModel, ParseValuesProductViewModel, ParseValuesProduct, CatalogDbContext>, IParseValuesProductManager
{
    private readonly IParseValuesProductProvider _productProvider;

    public ParseValuesProductManager(
        IBaseRepository<CatalogDbContext, ParseValuesProduct> repository,
        IParseValuesProductProvider productProvider,
        IMapper mapper) : base(repository, mapper)
    {
        _productProvider = productProvider;
    }
}