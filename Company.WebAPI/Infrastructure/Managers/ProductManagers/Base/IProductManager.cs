using Calabonga.UnitOfWork;
using Company.WebAPI.Infrastructure.Enums;
using Company.WebAPI.Infrastructure.Managers.Base;

namespace Company.WebAPI.Infrastructure.Managers.ProductManagers.Base;

public interface IProductManager<CreateViewModel, UpdateViewModel, ViewModel> : IBaseManager<CreateViewModel, UpdateViewModel, ViewModel>
    where CreateViewModel : class
    where UpdateViewModel : class
    where ViewModel : class
{
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