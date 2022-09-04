using Company.Parser.Entities;

namespace Company.Parser.Infrastructure.Providers.Interfaces;

/// <summary>
/// Интерфейс для взаимодействия с БД
/// </summary>
public interface IConfigurationParserProvider
{
    /// <summary>
    /// Получить сущность с добавленными парсерами
    /// </summary>
    /// <param name="id">Индентификатор конфигурации</param>
    /// <returns></returns>
    Task<ConfigurationParser?> GetByIdWithParsersAsync(Guid id);

    /// <summary>
    /// Получить сущность со всеми зависимыми полями
    /// </summary>
    /// <param name="id">Индентификатор конфигурации</param>
    /// <returns>Конфигурация парсера</returns>
    Task<ConfigurationParser?> GetByIdWithFieldsAsync(Guid id);

    // <summary>
    /// Получить список конфигураций по индетификатору парсера
    /// </summary>
    /// <param name="parserId">Индентификатор парсера</param>
    /// <returns>Список конфигураций</returns>
    Task<IEnumerable<ConfigurationParser>> GetByParserIdWithFieldsAsync(Guid parserId);

    /// <summary>
    /// Получить все сущности со всеми зависимыми полями
    /// </summary>
    /// <returns>Список конфигураций</returns>
    Task<IEnumerable<ConfigurationParser>> GetAllAsync();

    /// <summary>
    /// Находятся ли на выполнении фоновые задачи с заданным индетификатором конфигурации.
    /// </summary>
    /// <param name="id">Индетификатор конфигурации.</param>
    /// <returns>True - с данным id находятся на выполнении фоновые задачи или значение не найдено. False - с данным id нет выполняемых фоновых задач.</returns>
    Task<bool> IsActiveTaskOrNotFoundAsync(Guid id);
}