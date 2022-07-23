using Company.WebAPI.ViewModel.ParserViewModels;

namespace Company.WebAPI.Infrastructure.Managers.ParserManagers.Interfaces;

/// <summary>
/// Интерфейс предоставляющий методы по работе с данными WorkParser
/// </summary>
public interface IWorkParserManager
{
    /// <summary>
    /// Получить список всех задач
    /// </summary>
    /// <returns></returns>
    Task<IList<WorkParserViewModel>?> GetAllAsync();

    /// <summary>
    /// Создать задачу
    /// </summary>
    /// <param name="propertyParserId"></param>
    /// <param name="userName"></param>
    /// <returns></returns>
    Task<bool> CreateAsync(Guid propertyParserId, string userName);
}
