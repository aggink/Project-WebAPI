using Company.Base.Infractructure.Manager;
using Company.Parser.Data;
using Company.Parser.ViewModels.FieldConfigurationViewModels;

namespace Company.Parser.Infrastructure.Managers.Interfaces;

/// <summary>
/// Интерфейс предоставляющий методы по работе с данными FieldParser
/// </summary>
public interface IFieldParserManager<TDbContext>
    : IBaseManager<CreateFieldConfigurationViewModel, UpdateFieldConfigurationViewModel, FieldConfigurationViewModel>
    where TDbContext : ParserDbContext
{
    /// <summary>
    /// Получение всех FieldParser по запрошенному propertyParser
    /// </summary>
    /// <param name="propertyParserId"></param>
    /// <returns></returns>
    Task<IEnumerable<FieldConfigurationViewModel>> GetByPropertyIdAsync(Guid propertyParserId);
}
