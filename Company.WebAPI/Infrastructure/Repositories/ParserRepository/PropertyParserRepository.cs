using Calabonga.UnitOfWork;
using Company.Data.DbContexts;
using Company.Entity.Parser;
using Company.WebAPI.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Company.WebAPI.Infrastructure.Repositories.ParserRepository;

public class PropertyParserRepository : BaseRepository<ProductDbContext, PropertyParser>
{
    public PropertyParserRepository(
        IUnitOfWork<ProductDbContext> unitOfWork, 
        ILogger<BaseRepository<ProductDbContext, PropertyParser>> logger) 
        : base(unitOfWork, logger)
    {
    }

    protected override PropertyParser CreateEntity(PropertyParser inputEntity)
    {
        return new PropertyParser()
        {
            Id = inputEntity.Id,
            UserId = inputEntity.UserId,
            CreatedBy = inputEntity.CreatedBy,
            UpdatedBy = inputEntity.UpdatedBy,
            URL = inputEntity.URL,
            NameSite = inputEntity.NameSite,
            CompanyName = inputEntity.CompanyName,
            CompanyDescription = inputEntity.CompanyDescription,
            TypeName = inputEntity.TypeName
        };
    }

    protected override async Task<PropertyParser?> DeleteEntityAsync(Guid id)
    {
        return await _repository.GetFirstOrDefaultAsync(
            predicate: x => x.Id == id,
            include: i => i.Include(x => x.ParserParams));
    }

    protected override PropertyParser UpdateEntity(PropertyParser entity, PropertyParser inputEntity)
    {
        entity.UpdatedBy = inputEntity.UpdatedBy;
        entity.URL = inputEntity.URL;
        entity.NameSite = inputEntity.NameSite;
        entity.CompanyName = inputEntity.CompanyName;
        entity.CompanyDescription = inputEntity.CompanyDescription;
        entity.TypeName = inputEntity.TypeName;

        return entity;
    }
}
