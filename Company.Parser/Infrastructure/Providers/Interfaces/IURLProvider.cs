using Calabonga.UnitOfWork;
using Company.Parser.Entities;
using Company.Parser.Models;

namespace Company.Parser.Infrastructure.Providers.Interfaces;

public interface IURLProvider
{
    /// <summary>
    /// Получить ссылки находящиеся в очереди на парсинг.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <returns>Страница с ссылками.</returns>
    Task<IPagedList<InfoURL>> GetPageLinksWaitingParsedAsync(Guid parserId, int pageIndex = 0, int pageSize = 50);

    /// <summary>
    /// Получить обработанные ссылки.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <returns>Страница с ссылками.</returns>
    Task<IPagedList<InfoURL>> GetPageProcessedLinksAsync(Guid parserId, int pageIndex = 0, int pageSize = 50);

    /// <summary>
    /// Получить ссылки в которых произошла ошибка при обработке.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <returns>Страница с ссылками.</returns>
    Task<IPagedList<InfoURL>> GetPageLinksWithProcessingErrorsAsync(Guid parserId, int pageIndex = 0, int pageSize = 50);

    /// <summary>
    /// Получить статистические данные об обработке ссылок.
    /// (кол-во ссылок, кол-во обработанных ссылок, кол-во ссылок в очереди, кол-во ошибок, среднее время обработки ссылки, макс. время обработки, мин. время обработки)
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <returns>Статистические данные об обработке ссылок.</returns>
    Task<LinkProcessingStatistics> GetStatisticsLinkProcessingAsync(Guid parserId);

    /// <summary>
    /// Найти ссылки по части url-адреса.
    /// </summary>
    /// <param name="partOfAddress">Часть url-адреса.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>>
    /// <returns>Страница с сылками.</returns>
    Task<IPagedList<InfoURL>> GetPageLinksByPartAddressAsync(string partOfAddress, int pageIndex = 0, int pageSize = 50);

    /// <summary>
    /// получить данные о ссылки с информацией о парсере.
    /// </summary>
    /// <param name="id">Индентификатор ссылки.</param>
    /// <returns>Данные о ссылки.</returns>
    Task<InfoURL?> GetByIdWithParserAsync(Guid id);
}