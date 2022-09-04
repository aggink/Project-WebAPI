using Calabonga.UnitOfWork;
using Company.Parser.Data;
using Company.Parser.Entities;
using Company.Parser.Infrastructure.Providers.Interfaces;
using Company.Parser.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Parser.Infrastructure.Providers;

public class URLProvider<TDbContext> : IURLProvider
    where TDbContext : ParserDbContext
{
    private readonly IUnitOfWork<TDbContext> _unitOfWork;

    public URLProvider(IUnitOfWork<TDbContext> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Получить ссылки находящиеся в очереди на парсинг.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <returns>Страница с ссылками.</returns>
    public async Task<IPagedList<InfoURL>> GetPageLinksWaitingParsedAsync(Guid parserId, int pageIndex = 0, int pageSize = 50)
    {
        return await _unitOfWork.GetRepository<InfoURL>().GetPagedListAsync(
            predicate: x => x.HasBeenProcessed == false,
            pageIndex: pageIndex,
            pageSize: pageSize);
    }

    /// <summary>
    /// Получить обработанные ссылки.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <returns>Страница с ссылками.</returns>
    public async Task<IPagedList<InfoURL>> GetPageLinksWithProcessingErrorsAsync(Guid parserId, int pageIndex = 0, int pageSize = 50)
    {
        return await _unitOfWork.GetRepository<InfoURL>().GetPagedListAsync(
            predicate: x => x.HasBeenProcessed == true,
            pageIndex: pageIndex,
            pageSize: pageSize);
    }

    /// <summary>
    /// Получить ссылки в которых произошла ошибка при обработке.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <returns>Страница с ссылками.</returns>
    public async Task<IPagedList<InfoURL>> GetPageProcessedLinksAsync(Guid parserId, int pageIndex = 0, int pageSize = 50)
    {
        return await _unitOfWork.GetRepository<InfoURL>().GetPagedListAsync(
            predicate: x => x.IsSuccess == false && x.HasBeenProcessed == true,
            pageIndex: pageIndex,
            pageSize: pageSize);
    }

    /// <summary>
    /// Получить статистические данные об обработке ссылок.
    /// (кол-во ссылок, кол-во обработанных ссылок, кол-во ссылок в очереди, кол-во ошибок, среднее время обработки ссылки, макс. время обработки, мин. время обработки)
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <returns>Статистические данные об обработке ссылок.</returns>
    public async Task<LinkProcessingStatistics> GetStatisticsLinkProcessingAsync(Guid parserId)
    {
        var repository = _unitOfWork.GetRepository<InfoURL>();

        var totalProcessedLinks = await repository.CountAsync(predicate: x => x.HasBeenProcessed == true);
        return new LinkProcessingStatistics()
        {
            TotalLinks = await repository.CountAsync(),
            TotalProcessedLinks = totalProcessedLinks,
            TotalLinkHandlingErrors = await repository.CountAsync(predicate: x => x.IsSuccess == false && x.HasBeenProcessed == true),
            AverageLinkProcessingMilliseconds = await repository.SumAsync(x => x.ElapsedMilliseconds) / (decimal)totalProcessedLinks,
            MinLinkProcessingMilliseconds = await repository.MinAsync(
                predicate: x => x.HasBeenProcessed == true, 
                selector: x => x.ElapsedMilliseconds),
            MaxLinkProcessingMilliseconds = await repository.MaxAsync(
                predicate: x => x.HasBeenProcessed == true, 
                selector: x => x.ElapsedMilliseconds)
        };
    }

    /// <summary>
    /// Найти ссылки по части url-адреса.
    /// </summary>
    /// <param name="pageSize">Индентификатор парсера.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="partOfAddress">Часть url-адреса.</param>
    /// <returns>Страница с сылками.</returns>
    public async Task<IPagedList<InfoURL>> GetPageLinksByPartAddressAsync(string partOfAddress, int pageIndex = 0, int pageSize = 50)
    {
        return await _unitOfWork.GetRepository<InfoURL>().GetPagedListAsync(
            predicate:x => x.Url.Contains(partOfAddress, StringComparison.OrdinalIgnoreCase),
            pageIndex: pageIndex,
            pageSize: pageSize);
    }

    /// <summary>
    /// получить данные о ссылки с информацией о парсере.
    /// </summary>
    /// <param name="id">Индентификатор ссылки.</param>
    /// <returns>Данные о ссылки.</returns>
    public async Task<InfoURL?> GetByIdWithParserAsync(Guid id)
    {
        return await _unitOfWork.GetRepository<InfoURL>().GetFirstOrDefaultAsync(
            predicate: x => x.Id == id,
            include: i => i.Include(x => x.Parser!));
    }
}