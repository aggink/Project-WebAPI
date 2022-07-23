using Calabonga.UnitOfWork;
using Company.Data.DbContexts;
using Company.Entity.Parser;
using Company.WebAPI.Infrastructure.Providers.ParserProviders.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Company.WebAPI.Infrastructure.Providers.ParserProviders;

public class WorkParserProvider : IWorkParserProvider
{
    private readonly IUnitOfWork<ParserDbContext> _unitOfWork;

    public WorkParserProvider(
        IUnitOfWork<ParserDbContext> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<WorkParser?> GetByPropertyParserAsync(Guid propertyParserId)
    {
        return await _unitOfWork.GetRepository<WorkParser>().GetFirstOrDefaultAsync(
            predicate: x => x.PropertyParserId == propertyParserId);
    }

    public async Task<IList<WorkParser>?> GetAllWithDependencies()
    {
        return await _unitOfWork.GetRepository<WorkParser>().GetAllAsync(
            include: i => i.Include(x => x.PropertyParser));
    }
}