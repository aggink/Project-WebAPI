namespace Company.WPF.Infrastructure.Common.VirtualizingCollection;

/// <summary>
/// Поставщик данных из БД
/// </summary>
public interface IVirtualizingCollection<T>
{
    /// <summary>
    /// Получает запрошенную страницу и количество элементов в БД.
    /// </summary>
    /// <param name="pageSize">Размер страницы.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <returns>Страница с запрошенными данными и количество всех элементов в БД</returns>
    Task<(IList<T>? page, int count)> FetchPage(int pageSize, int pageIndex);
}