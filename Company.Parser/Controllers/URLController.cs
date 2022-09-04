using Company.Base.Controllers;
using Company.Base.ValidateModels;
using Company.Parser.Controllers.FactoryController;
using Company.Parser.Data;
using Company.Parser.Entities;
using Company.Parser.Infrastructure.Managers.Interfaces;
using Company.Parser.ViewModels.URLViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Company.Parser.Controllers;

[Route("parser/url")]
[GenericRestControllerNameConvention]
public class URLController<TDbContext>
    : BaseController<CreateURLViewModel, UpdateURLViewModel, URLViewModel, InfoURL, TDbContext>
    where TDbContext : ParserDbContext
{
    protected new readonly IURLManager<TDbContext> _manager;

    public URLController(IURLManager<TDbContext> manager) : base(manager)
    {
        _manager = manager;
    }

    [NonAction]
    public override Task<IActionResult> UpdateAsync([FromBody, Required] UpdateURLViewModel model)
    {
        return base.UpdateAsync(model);
    }

    /// <summary>
    /// Получить ссылки находящиеся в очереди на парсинг.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <returns>Страница с ссылками.</returns>
    [HttpGet("GetPageLinksWaitingParsed")]
    public async Task<IActionResult> GetPageLinksWaitingParsedAsync([FromQuery][Required] Guid parserId, [FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 50)
    {
        try
        {
            var result = await _manager.GetPageLinksWaitingParsedAsync(parserId, pageIndex, pageSize);
            return Json(result);
        }
        catch
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Получить обработанные ссылки.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <returns>Страница с ссылками.</returns>
    [HttpGet("GetPageProcessedLinks")]
    public async Task<IActionResult> GetPageProcessedLinksAsync([FromQuery][Required] Guid parserId, [FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 50)
    {
        try
        {
            var result = await _manager.GetPageProcessedLinksAsync(parserId, pageIndex, pageSize);
            return Json(result);
        }
        catch
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Получить ссылки в которых произошла ошибка при обработке.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <returns>Страница с ссылками.</returns>
    [HttpGet("GetPageLinksWithProcessingErrors")]
    public async Task<IActionResult> GetPageLinksWithProcessingErrorsAsync([FromQuery][Required] Guid parserId, [FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 50)
    {
        try
        {
            var result = await _manager.GetPageLinksWithProcessingErrorsAsync(parserId, pageIndex, pageSize);
            return Json(result);
        }
        catch
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Получить статистические данные об обработке ссылок.
    /// (кол-во ссылок, кол-во обработанных ссылок, кол-во ссылок в очереди, кол-во ошибок, среднее время обработки ссылки, макс. время обработки, мин. время обработки)
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <returns>Статистические данные об обработке ссылок.</returns>
    [HttpGet("GetStatisticsLinkProcessing")]
    public async Task<IActionResult> GetStatisticsLinkProcessingAsync([FromQuery][Required] Guid parserId)
    {
        try
        {
            var result = await _manager.GetStatisticsLinkProcessingAsync(parserId);
            return Json(result);
        }
        catch
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Найти ссылки по части url-адреса.
    /// </summary>
    /// <param name="pageSize">Индентификатор парсера.</param>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="partOfAddress">Часть url-адреса.</param>
    /// <returns>Страница с сылками.</returns>
    [HttpGet("GetPageLinksByPartAddress")]
    public async Task<IActionResult> GetPageLinksByPartAddressAsync([FromQuery][Required] string partOfAddress, [FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 50)
    {
        try
        {
            var result = await _manager.GetPageLinksByPartAddressAsync(partOfAddress, pageIndex, pageSize);
            return Json(result);
        }
        catch
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Сбросить параметры ссылки к начальным.
    /// </summary>
    /// <param name="ids">Индентификаторы ссылок.</param>
    /// <returns>Task.</returns>
    [HttpPut("ResetLinks")]
    [ValidateModel]
    public async Task<IActionResult> ResetLinksAsync([FromBody][Required] IEnumerable<Guid> ids)
    {
        try
        {
            await _manager.ResetLinksAsync(ids, UserName);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}