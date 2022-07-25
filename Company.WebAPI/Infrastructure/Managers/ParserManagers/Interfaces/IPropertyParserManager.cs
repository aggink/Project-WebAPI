using Company.WebAPI.Infrastructure.Managers.Base;
using Company.WebAPI.ViewModels.ParserViewModels.PropertyParserViewModels;

namespace Company.WebAPI.Infrastructure.Managers.ParserManagers.Interfaces;

/// <summary>
/// Интерфейс предоставляющий методы по работе с данными PropertyParser
/// </summary>
public interface IPropertyParserManager 
    : IBaseManager<CreatePropertyParserViewModel, UpdatePropertyParserViewModel, PropertyParserViewModel>
{
    /// <summary>
    /// Получение всех PropertyParser
    /// </summary>
    /// <returns></returns>
    Task<IList<PropertyParserViewModel>?> GetAllAsync();
}
