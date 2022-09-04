using Calabonga.UnitOfWork;
using Company.Base.Infractructure.Manager;
using Company.Parser.Data;
using Company.Parser.Models;
using Company.Parser.ViewModels.URLViewModels;

namespace Company.Parser.Infrastructure.Managers.Interfaces;

public interface IURLManager<TDbContext>
    : IBaseManager<CreateURLViewModel, UpdateURLViewModel, URLViewModel>
    where TDbContext : ParserDbContext
{
    /// <summary>
    /// Получить ссылки находящиеся в очереди на парсинг.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <returns>Страница с ссылками.</returns>
    Task<IPagedList<URLViewModel>> GetPageLinksWaitingParsedAsync(Guid parserId, int pageIndex = 0, int pageSize = 50);

    /// <summary>
    /// Получить обработанные ссылки.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <returns>Страница с ссылками.</returns>
    Task<IPagedList<URLViewModel>> GetPageProcessedLinksAsync(Guid parserId, int pageIndex = 0, int pageSize = 50);

    /// <summary>
    /// Получить ссылки в которых произошла ошибка при обработке.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <returns>Страница с ссылками.</returns>
    Task<IPagedList<URLViewModel>> GetPageLinksWithProcessingErrorsAsync(Guid parserId, int pageIndex = 0, int pageSize = 50);

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
    /// <param name="pageSize">Размер страницы.</param>
    /// <returns>Страница с сылками.</returns>
    Task<IPagedList<URLViewModel>> GetPageLinksByPartAddressAsync(string partOfAddress, int pageIndex = 0, int pageSize = 50);

    /// <summary>
    /// Сбросить параметры ссылки к начальным.
    /// </summary>
    /// <param name="ids">Индентификаторы ссылок.</param>
    /// <param name="userName">Имя пользователя.</param>
    /// <returns>Task.</returns>
    Task ResetLinksAsync(IEnumerable<Guid> ids, string userName);
}