using Calabonga.UnitOfWork;
using Company.Data.DbContexts;
using Company.Entity.Parser;
using Company.WebAPI.Infrastructure.Providers.ParserProviders.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Company.WebAPI.Infrastructure.Providers.ParserProviders;

public class PropertyParserProvider : IPropertyParserProvider
{
    private readonly IUnitOfWork<ParserDbContext> _unitOfWork;

    public PropertyParserProvider(
        IUnitOfWork<ParserDbContext> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PropertyParser?> GetWithDependenciesById(Guid id)
    {
        return await _unitOfWork.GetRepository<PropertyParser>().GetFirstOrDefaultAsync(
            predicate: x => x.Id == id,
            include: i => i.Include(x => x.ParserParams));
    }

    public async Task<IList<PropertyParser>?> GetAllWithDependencies()
    {
        return await _unitOfWork.GetRepository<PropertyParser>().GetAllAsync(
            include: i => i.Include(x => x.ParserParams));
    }
}