using Calabonga.UnitOfWork;
using Company.Data.DbContexts;
using Company.Entity.Parser;
using Company.WebAPI.Infrastructure.Repositories.Base;

namespace Company.WebAPI.Infrastructure.Repositories.ParserRepository;

public class FieldParserRepository : BaseRepository<ProductDbContext, FieldParser>
{
    public FieldParserRepository(
        IUnitOfWork<ProductDbContext> unitOfWork, 
        ILogger<BaseRepository<ProductDbContext, FieldParser>> logger) 
        : base(unitOfWork, logger)
    {
    }

    protected override FieldParser CreateEntity(FieldParser inputEntity)
    {
        return new FieldParser()
        {
            Id = Guid.NewGuid(),
            CreatedBy = inputEntity.CreatedBy,
            UpdatedBy = inputEntity.UpdatedBy,
            PropertyParserId = inputEntity.PropertyParserId,
            PropertyName = inputEntity.PropertyName,
            DefaultValue = inputEntity.DefaultValue,
            StringParse = inputEntity.StringParse,
        };

    }

    protected override async Task<FieldParser?> DeleteEntityAsync(Guid id)
    {
        return await _repository.GetFirstOrDefaultAsync(predicate: x => x.Id == id);
    }

    protected override FieldParser UpdateEntity(FieldParser entity, FieldParser inputEntity)
    {
        entity.UpdatedBy = inputEntity.UpdatedBy;
        entity.PropertyName = inputEntity.PropertyName;
        entity.DefaultValue = inputEntity.DefaultValue;
        entity.StringParse = inputEntity.StringParse;

        return entity;
    }
}