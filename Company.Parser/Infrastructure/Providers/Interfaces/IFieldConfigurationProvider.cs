using Company.Parser.Entities;

namespace Company.Parser.Infrastructure.Providers.Interfaces;

/// <summary>
/// Интерфейс для взаимодействия с БД.
/// </summary>
public interface IFieldConfigurationProvider
{
    /// <summary>
    /// Получить все поля относящиеся к одной настройке парсера.
    /// </summary>
    /// <param name="configurationId">Индетификатор конфигурации.</param>
    /// <returns>Список полей.</returns>
    Task<IEnumerable<FieldConfiguration>> GetAllByPropertyIdAsync(Guid configurationId);

    /// <summary>
    /// Находятся ли на выполнении фоновые задачи с заданным индетификатором поля конфигурации.
    /// </summary>
    /// <param name="id">Индетификатор конфигурации.</param>
    /// <returns>True - с данным id находятся на выполнении фоновые задачи или значение не найдено. False - с данным id нет выполняемых фоновых задач.</returns>
    Task<bool> IsActiveTaskOrNotFoundAsync(Guid id);
}