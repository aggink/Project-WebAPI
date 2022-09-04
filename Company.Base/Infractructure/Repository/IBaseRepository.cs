using Calabonga.UnitOfWork;
using Company.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Company.Base.Infractructure.Repository;

/// <summary>
/// Интерфейс предоставляет доступ к методам CRUD.
/// </summary>
/// <typeparam name="TDbContext">DbContext.</typeparam>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
public interface IBaseRepository<TDbContext, TEntity>
    where TEntity : class, IPrimaryKey
    where TDbContext : DbContext
{
    /// <summary>
    /// Добавить сущность.
    /// </summary>
    /// <param name="model">Модель.</param>
    /// <returns>При успешном выполнении вернет true. В случае ошибки возвращается false.</returns>
    Task CreateAsync(TEntity model);

    /// <summary>
    /// Добавить сущности.
    /// </summary>
    /// <param name="models">Список моделей.</param>
    /// <returns>При успешном выполнении вернет true. В случае ошибки возвращается false.</returns>
    Task CreateAsync(IEnumerable<TEntity> models);

    /// <summary>
    /// Обновить сущность.
    /// </summary>
    /// <param name="model">Модель.</param>
    /// <returns>При успешном выполнении вернет true. В случае ошибки возвращается false.</returns>
    Task UpdateAsync(TEntity model);

    /// <summary>
    /// Обновить список сущностей.
    /// </summary>
    /// <param name="models">Список сущностей.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    Task UpdateAsync(IEnumerable<TEntity> models);

    /// <summary>
    /// Удалить сущность.
    /// </summary>
    /// <param name="Id">Индентификатор.</param>
    /// <returns>При успешном выполнении вернет true. В случае ошибки возвращается false.</returns>
    Task DeleteAsync(Guid Id);

    /// <summary>
    /// Удалить сущность.
    /// </summary>
    /// <param name="model">Сущность.</param>
    /// <returns>При успешном выполнении вернет true. В случае ошибки возвращается false.</returns>
    Task DeleteAsync(TEntity model);

    /// <summary>
    /// Удаление группы сущностей.
    /// </summary>
    /// <param name="models">Список сущностей.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    Task DeleteAsync(IEnumerable<TEntity> models);

    /// <summary>
    /// Получить сущность по id.
    /// </summary>
    /// <param name="Id">Индентификатор.</param>
    /// <returns>При успешном выполнении вернет сущность. В случае ошибке вернет null.</returns>
    Task<TEntity?> GetByIdAsync(Guid Id);

    /// <summary>
    /// Получить страницу.
    /// </summary>
    /// <param name="predicate">Условия выборки.</param>
    /// <param name="orderBy">Условия сортировки.</param>
    /// <param name="include">Добавление.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Количество элементов на страницы.</param>
    /// <returns>Страница.</returns>
    Task<IPagedList<TEntity>> GetPageAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int pageIndex = 0, int pageSize = 50);
}