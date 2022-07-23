using Calabonga.UnitOfWork;
using Company.Data.DbContexts;
using Company.Entity.Parser;
using Company.WebAPI.Infrastructure.Providers.ParserProviders.Interfaces;

namespace Company.WebAPI.Infrastructure.Providers.ParserProviders;

public class FieldParserProvider : IFieldParserProvider
{
    private readonly IUnitOfWork<ParserDbContext> _unitOfWork;

    public FieldParserProvider(
        IUnitOfWork<ParserDbContext> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IList<FieldParser>?> GetAllByPropertyIdAsync(Guid propertyParserId)
    {
        return await _unitOfWork.GetRepository<FieldParser>().GetAllAsync(predicate: x => x.PropertyParserId == propertyParserId);
    }
}