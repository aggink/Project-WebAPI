using Calabonga.UnitOfWork;
using Company.WebAPI.Infrastructure.Enums;

namespace Company.WebAPI.Infrastructure.Managers.ProductManagers.Interfaces;

public interface IProductManager<CreateViewModel, UpdateViewModel, ViewModel>
    where CreateViewModel : class
    where UpdateViewModel : class
    where ViewModel : class
{
    /// <summary>
    /// Создание элемента
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="userName"></param>
    /// <returns></returns>
    Task<bool> CreateAsync(CreateViewModel entity, string userName);

    /// <summary>
    /// Обновление элемента
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="userName"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(UpdateViewModel entity, string userName);

    /// <summary>
    /// Удаление элемента
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(Guid id);

    /// <summary>
    /// Получить элемент
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ViewModel?> GetByIdAsync(Guid id);

    /// <summary>
    /// Получить страницу
    /// </summary>
    /// <param name="parserId">Id парсера</param>
    /// <param name="pageIndex">Номер страницы</param>
    /// <param name="pageSize">Количество элементов на страницы</param>
    /// <param name="conditionSort">Условие сортировки</param>
    /// <param name="typeSort">Тип сортировки</param>
    /// <returns></returns>
    Task<IPagedList<ViewModel>?> GetPageAsync(Guid parserId, int pageIndex = 0, int pageSize = 50, string? conditionSort = null, SortEnum typeSort = 0);
}