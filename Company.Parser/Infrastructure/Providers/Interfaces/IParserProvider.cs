using Company.Parser.Entities;

namespace Company.Parser.Infrastructure.Providers.Interfaces;

/// <summary>
/// Интерфейс для взаимодействия с БД
/// </summary>
public interface IParserProvider
{
    /// <summary>
    /// Получить парсер с настройками конфигурации
    /// </summary>
    /// <param name="id">Индентификатор парсера</param>
    /// <returns></returns>
    Task<InfoParser?> GetByIdWithConfigurationsWithFieldsAsync(Guid id);

    /// <summary>
    /// Получить список парсеров по id конфигурации
    /// </summary>
    /// <param name="configurationId">Индентификатор конфигурации</param>
    /// <returns>Список парсеров</returns>
    Task<IEnumerable<InfoParser>> GetByConfigurationIdAsync(Guid configurationId);

    /// <summary>
    /// Получить все сущности
    /// </summary>
    /// <returns>Список парсеров</returns>
    Task<IEnumerable<InfoParser>> GetAllAsync();

    /// <summary>
    /// Получить первый элемент в  отсортированном по возрастанию (по дате) списке удовлетворяющий условиям:
    /// 1. Находится в очереди (IsQueue = true)
    /// 2. Не назодится на выполнении (IsStart = false)
    /// </summary>
    /// <returns>Парсер</returns>
    Task<InfoParser?> GetOldEntityReadyExecuteAsync();

    /// <summary>
    /// Получить парсер, который в данный момент находится на выполнении
    /// </summary>
    /// <returns>Парсер</returns>
    Task<InfoParser?> GetActiveBackgroundTaskAsync();

    /// <summary>
    /// Находятся ли на выполнении указанный парсер или его не существует.
    /// </summary>
    /// <param name="id">Индетификатор парсера</param>
    /// <returns>True - парсер находятся на выполнении или не найден. False - парсер не активен.</returns>
    Task<bool> IsActiveTaskOrNotFoundAsync(Guid id);
}