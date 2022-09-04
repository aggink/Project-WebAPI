using Calabonga.UnitOfWork;
using Company.Parser.Entities.Base;
using Company.Parser.Infrastructure.Providers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Company.Parser.Infrastructure.Providers;

/// <summary>
/// Провайдер для работы с сущностями.
/// </summary>
/// <typeparam name="TDbContext">DbContext.</typeparam>
public class EntityProvider<TDbContext> : IEntityProvider<TDbContext>
    where TDbContext : DbContext
{
    private readonly IUnitOfWork<TDbContext> _unitOfWork;

    public EntityProvider(IUnitOfWork<TDbContext> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Получить сущность по индентификатору ссылки.
    /// </summary>
    /// <typeparam name="TEntity">Сущность.</typeparam>
    /// <param name="urlId">Индентификатора ссылки.</param>
    /// <returns>Сущность или null.</returns>
    public async Task<TEntity?> GetEntityByURLIdAsync<TEntity>(Guid urlId) 
        where TEntity : ParserAuditable
    {
        return await _unitOfWork.GetRepository<TEntity>().GetFirstOrDefaultAsync(
            predicate: x => x.InfoURLId == urlId);
    }
}