using Company.Entity.Parser;

namespace Company.WebAPI.Infrastructure.Providers.ParserProviders.Interfaces;

public interface IWorkParserProvider
{
    /// <summary>
    /// Получить сущность по id парсера
    /// </summary>
    /// <param name="propertyParserId"></param>
    /// <returns></returns>
    Task<WorkParser?> GetByPropertyParserAsync(Guid propertyParserId);

    /// <summary>
    /// Получить все сущности со всеми зависимыми полями
    /// </summary>
    /// <returns></returns>
    Task<IList<WorkParser>?> GetAllWithDependencies();
}
