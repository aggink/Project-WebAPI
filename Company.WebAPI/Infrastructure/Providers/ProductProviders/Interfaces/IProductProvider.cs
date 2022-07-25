using Calabonga.UnitOfWork;
using Company.WebAPI.Infrastructure.Enums;

namespace Company.WebAPI.Infrastructure.Providers.ProductProviders.Interfaces;

public interface IProductProvider<TEntity>
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
    Task<IPagedList<TEntity>> GetPageAsync(Guid parserId, int pageIndex = 0, int pageSize = 50, string? conditionSort = null, SortEnum typeSort = 0);
}