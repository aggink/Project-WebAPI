using Company.WebAPI.Infrastructure.Managers.Base;
using Company.WebAPI.ViewModels.ParserViewModels.FieldParserViewModels;

namespace Company.WebAPI.Infrastructure.Managers.ParserManagers.Interfaces;

/// <summary>
/// Интерфейс предоставляющий методы по работе с данными FieldParser
/// </summary>
public interface IFieldParserManager 
    : IBaseManager<CreateFieldParserViewModel, UpdateFieldParserViewModel, FieldParserViewModel>
{
    /// <summary>
    /// Создание FieldParser
    /// </summary>
    /// <param name="models"></param>
    /// <param name="userName"></param>
    /// <returns></returns>
    Task<bool> CreateAsync(IList<CreateFieldParserViewModel> models, string userName);

    /// <summary>
    /// Обновление FieldParser
    /// </summary>
    /// <param name="models"></param>
    /// <param name="userName"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(IList<UpdateFieldParserViewModel> models, string userName);

    /// <summary>
    /// Получение всех FieldParser по запрошенному propertyParser
    /// </summary>
    /// <param name="propertyParserId"></param>
    /// <returns></returns>
    Task<IList<FieldParserViewModel>?> GetByPropertyIdAsync(Guid propertyParserId);
}
