using Company.Parser.Entities;
using Company.Parser.Entities.Base;

namespace Company.Parser.Infrastructure.ParseService.Interfaces;

/// <summary>
/// Интерфейс для работы с парсером.
/// </summary>
public interface IParserWorker
{
    /// <summary>
    /// Парсинг веб-страниц
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// <param name="parser">Данные для парсинга.</param>
    /// <param name="token">CancellationToken.</param>
    Task RunParseAsync<TEntity>(InfoParser parser, CancellationToken token)
        where TEntity : ParserAuditable;

    /// <summary>
    /// Обновить значение результатов парсинга.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// <param name="parser">Данные для парсинга.</param>
    /// <param name="token">CancellationToken.</param>
    Task RunUpdateParseAsync<TEntity>(InfoParser parser, CancellationToken token)
        where TEntity : ParserAuditable;
}