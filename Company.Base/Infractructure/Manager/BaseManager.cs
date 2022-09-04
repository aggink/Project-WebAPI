using AutoMapper;
using Calabonga.UnitOfWork;
using Company.Base.Entities;
using Company.Base.Enums;
using Company.Base.Infractructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Company.Base.Infractructure.Manager;

/// <summary>
/// Базовый менеджер для взаимодействия с нижними слоями сервиса.
/// </summary>
/// <typeparam name="CreateViewModel">Тип сущности для создания.</typeparam>
/// <typeparam name="UpdateViewModel">Тип сущности для обновления.</typeparam>
/// <typeparam name="ViewModel">Тип сущности для отображения пользователям.</typeparam>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
/// <typeparam name="TDbContext">DbContext.</typeparam>
public class BaseManager<CreateViewModel, UpdateViewModel, ViewModel, TEntity, TDbContext>
    : IBaseManager<CreateViewModel, UpdateViewModel, ViewModel>
    where TEntity : Auditable
    where CreateViewModel : class
    where UpdateViewModel : class, IPrimaryKey
    where ViewModel : class, IPrimaryKey
    where TDbContext : DbContext
{
    protected readonly IBaseRepository<TDbContext, TEntity> _repository;
    protected readonly IMapper _mapper;

    public BaseManager(
        IBaseRepository<TDbContext, TEntity> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Добавление сущности.
    /// </summary>
    /// <param name="entity">Сущность для добавления.</param>
    /// <param name="userName">Уникальное имя пользователя.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    public virtual async Task CreateAsync(CreateViewModel entity, string userName)
    {
        var model = _mapper.Map<CreateViewModel, TEntity>(entity);

        model.Id = Guid.NewGuid();
        model.CreatedBy = userName;
        model.UpdatedBy = userName;

        await _repository.CreateAsync(model);
    }

    /// <summary>
    /// Обноваление сущности.
    /// </summary>
    /// <param name="entity">Сущность для обновления.</param>
    /// <param name="userName">Уникальное имя пользователя.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    public virtual async Task UpdateAsync(UpdateViewModel entity, string userName)
    {
        var model = await _repository.GetByIdAsync(entity.Id);
        if (model == null) throw new Exception($"Entity with ID {entity.Id} not found.");

        var updateModel = _mapper.Map(entity, model);

        updateModel.UpdatedBy = userName;

        await _repository.UpdateAsync(updateModel);
    }

    /// <summary>
    /// Удаление сущности.
    /// </summary>
    /// <param name="id">Индентификатор сущности.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    public virtual async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    /// <summary>
    /// Добавление группы сущностей.
    /// </summary>
    /// <param name="entities">Список сущность для добавления.</param>
    /// <param name="userName">Уникальное имя пользователя.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    public virtual async Task CreateAsync(IEnumerable<CreateViewModel> entities, string userName)
    {
        var models = _mapper.Map<IEnumerable<CreateViewModel>, IEnumerable<TEntity>>(entities);

        foreach (var entity in models)
        {
            entity.CreatedBy = userName;
            entity.UpdatedBy = userName;
        }

        await _repository.CreateAsync(models);
    }

    /// <summary>
    /// Обноваление группы сущности.
    /// </summary>
    /// <param name="entities">Список сущностей для обновления.</param>
    /// <param name="userName">Уникальное имя пользователя.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    public virtual async Task UpdateAsync(IEnumerable<UpdateViewModel> entities, string userName)
    {
        List<TEntity> models = new();
        foreach (var entity in entities)
        {
            var model = await _repository.GetByIdAsync(entity.Id);
            if (model == null) throw new Exception($"Entity with ID {entity.Id} not found.");
            else
            {
                model.UpdatedBy = userName;
                models.Add(model);
            }
        }

        var updateModel = _mapper.Map(entities, models);

        await _repository.UpdateAsync(updateModel);
    }

    /// <summary>
    /// Удаление группы сущностей.
    /// </summary>
    /// <param name="ids">Список индентификаторов сущностей.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    public virtual async Task DeleteAsync(IEnumerable<Guid> ids)
    {
        List<TEntity> models = new();
        foreach (var id in ids)
        {
            var model = await _repository.GetByIdAsync(id);
            if (model == null) throw new Exception($"Entity with ID {id} not found.");
            else models.Add(model);
        }

        await _repository.DeleteAsync(models);
    }

    /// <summary>
    /// Получить сущность по индентификатору.
    /// </summary>
    /// <param name="id">Индентификатор сущности.</param>
    /// <returns>Сущность или null, если ничего не найдено.</returns>
    public virtual async Task<ViewModel> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) throw new Exception($"Entity with ID {id} not found.");

        return _mapper.Map<TEntity, ViewModel>(entity);
    }

    /// <summary>
    /// Получить страницу.
    /// </summary>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Количество элементов на страницы.</param>
    /// <param name="typeSort">Тип сортировки.</param>
    /// <returns>Страница с данными.</returns>
    public async Task<IPagedList<ViewModel>> GetPageAsync(int pageIndex = 0, int pageSize = 50, SortEnum typeSort = SortEnum.OrderBy)
    {
        IPagedList<TEntity> result = typeSort switch
        {
            SortEnum.OrderBy => await _repository.GetPageAsync(null, x => x.OrderBy(x => x.Id), null, pageIndex, pageSize),

            SortEnum.OrderByDescending => await _repository.GetPageAsync(null, x => x.OrderBy(x => x.Id), null, pageIndex, pageSize),

            _ => await _repository.GetPageAsync(null, null, null, pageIndex, pageSize)
        };

        return _mapper.Map<PagedList<TEntity>, PagedList<ViewModel>>((PagedList<TEntity>)result);
    }
}