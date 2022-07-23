using Company.Entity.Parser;

namespace Company.WebAPI.Infrastructure.Providers.ParserProviders.Interfaces;

public interface IFieldParserProvider
{
    /// <summary>
    /// Получить все поля относящиеся к одной настройке парсера
    /// </summary>
    /// <param name="propertyParserId"></param>
    /// <returns></returns>
    Task<IList<FieldParser>?> GetAllByPropertyIdAsync(Guid propertyParserId);
}
