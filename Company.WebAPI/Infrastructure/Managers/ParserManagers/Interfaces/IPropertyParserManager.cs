using Company.WebAPI.ViewModels.ParserViewModels.PropertyParserViewModels;

namespace Company.WebAPI.Infrastructure.Managers.ParserManagers.Interfaces;

/// <summary>
/// Интерфейс предоставляющий методы по работе с данными PropertyParser
/// </summary>
public interface IPropertyParserManager
{
    /// <summary>
    /// Создание PropertyParser
    /// </summary>
    /// <param name="model"></param>
    /// <param name="userName"></param>
    /// <returns></returns>
    Task<bool> CreateAsync(CreatePropertyParserViewModel model, string userName);

    /// <summary>
    /// Обновление PropertyParser
    /// </summary>
    /// <param name="model"></param>
    /// <param name="userName"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(UpdatePropertyParserViewModel model, string userName);

    /// <summary>
    /// Удаление PropertyParser
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(Guid id);

    /// <summary>
    /// Получение PropertyParser по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<PropertyParserViewModel?> GetByIdAsync(Guid id);

    /// <summary>
    /// Получение всех PropertyParser
    /// </summary>
    /// <returns></returns>
    Task<IList<PropertyParserViewModel>?> GetAllAsync();
}
