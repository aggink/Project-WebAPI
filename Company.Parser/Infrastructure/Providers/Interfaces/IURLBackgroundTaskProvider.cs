using Company.Parser.Entities;

namespace Company.Parser.Infrastructure.Providers.Interfaces;

/// <summary>
/// Интерфейс для получения данных о ссылках
/// </summary>
public interface IURLBackgroundTaskProvider
{
    /// <summary>
    /// Получить необработанную ссылку.
    /// </summary>
    /// <param name="parserId">Индентификатора парсера.</param>
    /// <returns>Ссылка.</returns>
    Task<InfoURL?> GetFollowLinkAsync(Guid parserId);

    /// <summary>
    /// Вернуть те ссылки, которых нет в базе данных.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <param name="links"></param>
    /// <returns>Список ссылок, которых нет в базе данных.</returns>
    /// <exception cref="ArgumentException">Ошибка при получение dbContext.</exception>
    Task<IEnumerable<string>> GetLinksNotStoredByDBAsync(Guid parserId, IEnumerable<string> links);

    /// <summary>
    /// Получить все ссылки по заданному индентификатору парсера.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <returns>Список ссылок.</returns>
    Task<IEnumerable<InfoURL>> GetByParserIdAsync(Guid parserId);

    /// <summary>
    /// Получить список ссылок по индентификатору парсера.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <returns>Список ссылок относящийхся к одному парсеру.</returns>
    Task<IEnumerable<InfoURL>> GetLinksByParserIdAsync(Guid parserId);
}