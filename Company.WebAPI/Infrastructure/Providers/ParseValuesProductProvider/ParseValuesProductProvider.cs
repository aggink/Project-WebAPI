using Calabonga.UnitOfWork;
using Company.Data.DbContexts;

namespace Company.WebAPI.Infrastructure.Providers.ParseValuesProductProvider;

public class ParseValuesProductProvider : IParseValuesProductProvider
{
    private readonly IUnitOfWork<CatalogDbContext> _unotOfWork;

    public ParseValuesProductProvider(
        IUnitOfWork<CatalogDbContext> unitOfWork)
    {
        _unotOfWork = unitOfWork;
    }
}