using Company.Entity.Parser;

namespace Company.WebAPI.Infrastructure.Providers.ParserProviders.Interfaces;

public interface IPropertyParserProvider
{
    /// <summary>
    /// Получить сущность со всеми зависимыми полями
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<PropertyParser?> GetWithDependenciesById(Guid id);

    /// <summary>
    /// Получить все сущности со всеми зависимыми полями
    /// </summary>
    /// <returns></returns>
    Task<IList<PropertyParser>?> GetAllWithDependencies();
}
