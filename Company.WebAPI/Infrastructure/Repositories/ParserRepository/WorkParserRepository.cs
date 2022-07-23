using Calabonga.UnitOfWork;
using Company.Data.DbContexts;
using Company.Entity.Parser;
using Company.WebAPI.Infrastructure.Repositories.Base;

namespace Company.WebAPI.Infrastructure.Repositories.ParserRepository;

public class WorkParserRepository : BaseRepository<ProductDbContext, WorkParser>
{
    public WorkParserRepository(
        IUnitOfWork<ProductDbContext> unitOfWork, 
        ILogger<BaseRepository<ProductDbContext, WorkParser>> logger)
        : base(unitOfWork, logger)
    {
    }

    protected override WorkParser CreateEntity(WorkParser inputEntity)
    {
        return new WorkParser()
        {
            Id = inputEntity.Id,
            PropertyParserId = inputEntity.PropertyParserId,
            IsStart = inputEntity.IsStart,
            IsCompleted = inputEntity.IsCompleted,
            StartTime = inputEntity.StartTime,
            CompletionTime = inputEntity.CompletionTime
        };
    }

    protected override async Task<WorkParser?> DeleteEntityAsync(Guid id)
    {
        return await _repository.GetFirstOrDefaultAsync(predicate: x => x.Id == id);
    }

    protected override WorkParser UpdateEntity(WorkParser entity, WorkParser inputEntity)
    {
        entity.IsStart = inputEntity.IsStart;
        entity.IsCompleted = inputEntity.IsCompleted;
        entity.StartTime = inputEntity.StartTime;
        entity.CompletionTime = inputEntity.CompletionTime;

        return entity;
    }
}
