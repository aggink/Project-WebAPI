using Calabonga.UnitOfWork;
using Company.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Company.Base.Infractructure.Repository;

/// <summary>
/// Реализация методов CRUD.
/// </summary>
/// <typeparam name="TDbContext">DbContext.</typeparam>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
public class BaseRepository<TDbContext, TEntity> : IBaseRepository<TDbContext, TEntity>
    where TDbContext : DbContext
    where TEntity : class, IPrimaryKey
{
    protected readonly IUnitOfWork<TDbContext> _unitOfWork;
    protected readonly IRepository<TEntity> _repository;
    protected readonly ILogger<BaseRepository<TDbContext, TEntity>> _logger;

    public BaseRepository(
        IUnitOfWork<TDbContext> unitOfWork,
        ILogger<BaseRepository<TDbContext, TEntity>> logger)
    {
        _unitOfWork = unitOfWork;
        _repository = unitOfWork.GetRepository<TEntity>();
        _logger = logger;
    }

    #region Create

    /// <summary>
    /// Добавление сущности.
    /// </summary>
    /// <param name="model">Сущность.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    public virtual async Task CreateAsync(TEntity model)
    {
        await _repository.InsertAsync(model);
        await _unitOfWork.SaveChangesAsync();
        if (!_unitOfWork.LastSaveChangesResult.IsOk)
        {
            throw _unitOfWork.LastSaveChangesResult.Exception!;
        }
    }

    /// <summary>
    /// Добавление группы сущностей.
    /// </summary>
    /// <param name="models">Список сущностей.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    public virtual async Task CreateAsync(IEnumerable<TEntity> models)
    {
        await _repository.InsertAsync(models);
        await _unitOfWork.SaveChangesAsync();
        if (!_unitOfWork.LastSaveChangesResult.IsOk)
        {
            throw _unitOfWork.LastSaveChangesResult.Exception!;
        }
    }

    #endregion

    #region Delete

    /// <summary>
    /// Удаление сущности по индентификатору.
    /// </summary>
    /// <param name="Id">Индентийикатор сущности.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    public virtual async Task DeleteAsync(Guid Id)
    {
        var entity = await _repository.GetFirstOrDefaultAsync(predicate: x => x.Id == Id);
        if (entity == null) throw new Exception($"Entity with ID {Id} not found.");

        _repository.Delete(entity);
        await _unitOfWork.SaveChangesAsync();
        if (!_unitOfWork.LastSaveChangesResult.IsOk)
        {
            throw _unitOfWork.LastSaveChangesResult.Exception!;
        }
    }

    /// <summary>
    /// Удаление сущности.
    /// </summary>
    /// <param name="model">Сущность.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    public virtual async Task DeleteAsync(TEntity model)
    {
        _repository.Delete(model);
        await _unitOfWork.SaveChangesAsync();
        if (!_unitOfWork.LastSaveChangesResult.IsOk)
        {
            throw _unitOfWork.LastSaveChangesResult.Exception!;
        }
    }

    /// <summary>
    /// Удаление группы сущностей.
    /// </summary>
    /// <param name="models">Список сущностей.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    public virtual async Task DeleteAsync(IEnumerable<TEntity> models)
    {
        _repository.Delete(models);
        await _unitOfWork.SaveChangesAsync();
        if (!_unitOfWork.LastSaveChangesResult.IsOk)
        {
            throw _unitOfWork.LastSaveChangesResult.Exception!;
        }
    }

    #endregion

    #region Update

    /// <summary>
    /// Обновление данных сущности.
    /// </summary>
    /// <param name="model">Сущность.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    public virtual async Task UpdateAsync(TEntity model)
    {
        _repository.Update(model);
        await _unitOfWork.SaveChangesAsync();
        if (!_unitOfWork.LastSaveChangesResult.IsOk)
        {
            throw _unitOfWork.LastSaveChangesResult.Exception!;
        }
    }

    /// <summary>
    /// Обновить группы сущностей.
    /// </summary>
    /// <param name="models">Список сущностей.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    public virtual async Task UpdateAsync(IEnumerable<TEntity> models)
    {
        _repository.Update(models);
        await _unitOfWork.SaveChangesAsync();
        if (!_unitOfWork.LastSaveChangesResult.IsOk)
        {
            throw _unitOfWork.LastSaveChangesResult.Exception!;
        }
    }

    #endregion

    #region Get

    /// <summary>
    /// Получить сущность по индентификатору.
    /// </summary>
    /// <param name="id">Индентификатор сущности.</param>
    /// <returns>Сущность или null.</returns>
    public virtual async Task<TEntity?> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetFirstOrDefaultAsync(predicate: x => x.Id == id);
        if (entity == null) _logger.EntityReadFailed(nameof(TEntity), null);
        return entity;
    }

    /// <summary>
    /// Получить страницу.
    /// </summary>
    /// <param name="predicate">Условия выборки.</param>
    /// <param name="orderBy">Условия сортировки.</param>
    /// <param name="include">Добавление.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Количество элементов на страницы.</param>
    /// <returns>Страница.</returns>
    public async Task<IPagedList<TEntity>> GetPageAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int pageIndex = 0, int pageSize = 50)
    {
        return await _unitOfWork.GetRepository<TEntity>().GetPagedListAsync(
                predicate: predicate,
                orderBy: orderBy,
                pageIndex: pageIndex,
                pageSize: pageSize,
                include: include);
    }

    #endregion
}