using Company.Parser.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Company.Parser.Infrastructure.Providers.Interfaces;

/// <summary>
/// Интерфейс для взаимодействия с БД.
/// </summary>
/// <typeparam name="TDbContext">DbContext.</typeparam>
public interface IEntityProvider<TDbContext>
    where TDbContext : DbContext
{
    /// <summary>
    /// Получить сущность по индентификатору ссылки.
    /// </summary>
    /// <typeparam name="TEntity">Сущность.</typeparam>
    /// <param name="urlId">Индентификатора ссылки.</param>
    /// <returns>Сущность или null.</returns>
    Task<TEntity?> GetEntityByURLIdAsync<TEntity>(Guid urlId) where TEntity : ParserAuditable;
}