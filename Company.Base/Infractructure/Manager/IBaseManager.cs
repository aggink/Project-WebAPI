using Calabonga.UnitOfWork;
using Company.Base.Entities;
using Company.Base.Enums;
using Microsoft.EntityFrameworkCore;

namespace Company.Base.Infractructure.Manager;

/// <summary>
/// Интерфейс предоставляющий реализацию базового менеджера для работы с нижними слоями сервиса.
/// </summary>
/// <typeparam name="CreateViewModel">Тип сущности для создания.</typeparam>
/// <typeparam name="UpdateViewModel">Тип сущности для обновления.</typeparam>
/// <typeparam name="ViewModel">Тип сущности для отображения пользователям.</typeparam>
public interface IBaseManager<CreateViewModel, UpdateViewModel, ViewModel>
    where CreateViewModel : class
    where UpdateViewModel : class, IPrimaryKey
    where ViewModel : class, IPrimaryKey
{
    /// <summary>
    /// Добавление сущности.
    /// </summary>
    /// <param name="entity">Сущность для добавления.</param>
    /// <param name="userName">Уникальное имя пользователя.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    Task CreateAsync(CreateViewModel entity, string userName);

    /// <summary>
    /// Обноваление сущности.
    /// </summary>
    /// <param name="entity">Сущность для обновления.</param>
    /// <param name="userName">Уникальное имя пользователя.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    Task UpdateAsync(UpdateViewModel entity, string userName);

    /// <summary>
    /// Удаление сущности.
    /// </summary>
    /// <param name="id">Индентификатор сущности.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// Добавление группы сущностей.
    /// </summary>
    /// <param name="entities">Список сущность для добавления.</param>
    /// <param name="userName">Уникальное имя пользователя.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    Task CreateAsync(IEnumerable<CreateViewModel> entities, string userName);

    /// <summary>
    /// Обноваление группы сущности.
    /// </summary>
    /// <param name="entities">Список сущностей для обновления.</param>
    /// <param name="userName">Уникальное имя пользователя.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    Task UpdateAsync(IEnumerable<UpdateViewModel> entities, string userName);

    /// <summary>
    /// Удаление группы сущностей.
    /// </summary>
    /// <param name="ids">Список индентификаторов сущностей.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    Task DeleteAsync(IEnumerable<Guid> ids);

    /// <summary>
    /// Получить сущность по индентификатору.
    /// </summary>
    /// <param name="id">Индентификатор сущности.</param>
    /// <returns>Сущность или null, если ничего не найдено.</returns>
    Task<ViewModel> GetByIdAsync(Guid id);

    /// <summary>
    /// Получить страницу.
    /// </summary>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Количество элементов на страницы.</param>
    /// <param name="typeSort">Тип сортировки.</param>
    /// <returns>Страница с данными.</returns>
    Task<IPagedList<ViewModel>> GetPageAsync(int pageIndex = 0, int pageSize = 50, SortEnum typeSort = 0);
}