namespace Company.WPF.Models.Products;

#nullable disable

public class DataProduct<T> where T : class
{
    /// <summary>
    /// Количество элементов в БД
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Номер страницы
    /// </summary>
    public int PageIndex { get; set; }

    /// <summary>
    /// Количество элементов на страницы
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Список продуктов
    /// </summary>
    public IEnumerable<T> Products { get; set; }
}

#nullable enable