using AutoMapper;
using Calabonga.UnitOfWork;
using Company.Base.Infractructure.Manager;
using Company.Base.Infractructure.Repository;
using Company.Parser.Data;
using Company.Parser.Entities;
using Company.Parser.Infrastructure.Managers.Interfaces;
using Company.Parser.Infrastructure.Providers.Interfaces;
using Company.Parser.Models;
using Company.Parser.ViewModels.URLViewModels;

namespace Company.Parser.Infrastructure.Managers;

public class URLManager<TDbContext> : BaseManager<CreateURLViewModel, UpdateURLViewModel, URLViewModel, InfoURL, TDbContext>, 
    IURLManager<TDbContext>
    where TDbContext : ParserDbContext
{
    private readonly IURLProvider _provider;
    private readonly IParserProvider _parserProvider;
    public URLManager(
        IBaseRepository<TDbContext, InfoURL> repository,
        IURLProvider provider,
        IParserProvider parserProvider,
        IMapper mapper) : base(repository, mapper)
    {
        _provider = provider;
        _parserProvider = parserProvider;
    }

    private static string ActiveTaskMessageError(Guid id) => $"The task with the given parser ID ({id}) is active.Changes are not possible.";
    private static string EntityNotFoundMessageError(Guid id) => $"Entity with ID {id} not found.";
    private static string ParserNotFoundMessageError(Guid id) => $"Parser with ID {id} not found.";

    public override async Task UpdateAsync(UpdateURLViewModel entity, string userName)
    {
        if (await _parserProvider.IsActiveTaskOrNotFoundAsync(entity.ParserId))
            throw new Exception(ActiveTaskMessageError(entity.ParserId));
        
        var model = await _repository.GetByIdAsync(entity.Id);
        if (model == null) throw new Exception(EntityNotFoundMessageError(entity.Id));
        else if (model.Url != entity.Url)
        {

            model.Url = entity.Url;
            model.IsSuccess = false;
            model.HasBeenProcessed = false;
            model.ElapsedMilliseconds = 0;
            model.ExceptionMessage = null;
            model.UpdatedBy = userName;
        }

        await _repository.UpdateAsync(model);
    }

    public override async Task UpdateAsync(IEnumerable<UpdateURLViewModel> entities, string userName)
    {
        foreach(var entity in entities)
        {
            if (await _parserProvider.IsActiveTaskOrNotFoundAsync(entity.ParserId))
                throw new Exception(ActiveTaskMessageError(entity.ParserId));
        }

        List<InfoURL> models = new();
        foreach(var entity in entities)
        {
            var model = await _repository.GetByIdAsync(entity.Id);
            if (model == null) throw new Exception(EntityNotFoundMessageError(entity.Id));
            else if (model.Url != entity.Url)
            {

                model.Url = entity.Url;
                model.IsSuccess = false;
                model.HasBeenProcessed = false;
                model.ElapsedMilliseconds = 0;
                model.ExceptionMessage = null;
                model.UpdatedBy = userName;
            }

            models.Add(model);
        }

        await _repository.UpdateAsync(models);
    }

    /// <summary>
    /// Получить ссылки находящиеся в очереди на парсинг.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <returns>Страница с ссылками.</returns>
    public async Task<IPagedList<URLViewModel>> GetPageLinksWaitingParsedAsync(Guid parserId, int pageIndex = 0, int pageSize = 50)
    {
        var result = await _provider.GetPageLinksWaitingParsedAsync(parserId, pageIndex, pageSize);
        return _mapper.Map<PagedList<InfoURL>, PagedList<URLViewModel>>((PagedList<InfoURL>)result);
    }

    /// <summary>
    /// Получить обработанные ссылки.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <returns>Страница с ссылками.</returns>
    public async Task<IPagedList<URLViewModel>> GetPageProcessedLinksAsync(Guid parserId, int pageIndex = 0, int pageSize = 50)
    {
        var result = await _provider.GetPageProcessedLinksAsync(parserId, pageIndex, pageSize);
        return _mapper.Map<PagedList<InfoURL>, PagedList<URLViewModel>>((PagedList<InfoURL>)result);
    }

    /// <summary>
    /// Получить ссылки в которых произошла ошибка при обработке.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <returns>Страница с ссылками.</returns>
    public async Task<IPagedList<URLViewModel>> GetPageLinksWithProcessingErrorsAsync(Guid parserId, int pageIndex = 0, int pageSize = 50)
    {
        var result = await _provider.GetPageLinksWithProcessingErrorsAsync(parserId, pageIndex, pageSize);
        return _mapper.Map<PagedList<InfoURL>, PagedList<URLViewModel>>((PagedList<InfoURL>)result);
    }

    /// <summary>
    /// Получить статистические данные об обработке ссылок.
    /// (кол-во ссылок, кол-во обработанных ссылок, кол-во ссылок в очереди, кол-во ошибок, среднее время обработки ссылки, макс. время обработки, мин. время обработки)
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <returns>Статистические данные об обработке ссылок.</returns>
    public async Task<LinkProcessingStatistics> GetStatisticsLinkProcessingAsync(Guid parserId)
    {
        return await _provider.GetStatisticsLinkProcessingAsync(parserId);
    }

    /// <summary>
    /// Найти ссылки по части url-адреса.
    /// </summary>
    /// <param name="pageSize">Индентификатор парсера.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="partOfAddress">Часть url-адреса.</param>
    /// <returns>Страница с сылками.</returns>
    public async Task<IPagedList<URLViewModel>> GetPageLinksByPartAddressAsync(string partOfAddress, int pageIndex = 0, int pageSize = 50)
    {
        var result = await _provider.GetPageLinksByPartAddressAsync(partOfAddress, pageIndex, pageSize);
        return _mapper.Map<PagedList<InfoURL>, PagedList<URLViewModel>>((PagedList<InfoURL>)result);
    }

    /// <summary>
    /// Сбросить параметры ссылки к начальным.
    /// </summary>
    /// <param name="ids">Индентификаторы ссылок.</param>
    /// <param name="userName">Имя пользователя.</param>
    /// <returns>Task.</returns>
    public async Task ResetLinksAsync(IEnumerable<Guid> ids, string userName)
    {
        List<InfoURL> models = new();
        foreach (var id in ids)
        {
            var model = await _provider.GetByIdWithParserAsync(id);
            if (model == null) throw new Exception(EntityNotFoundMessageError(id));
            else if (model.Parser == null) throw new Exception(ParserNotFoundMessageError(model.ParserId));
            else if (model.Parser.IsStart) throw new Exception(ActiveTaskMessageError(model.ParserId));
            else
            {
                model.IsSuccess = false;
                model.HasBeenProcessed = false;
                model.ElapsedMilliseconds = 0;
                model.ExceptionMessage = null;
                model.UpdatedBy = userName;

                models.Add(model);
            }
        }

        await _repository.UpdateAsync(models);
    }
}