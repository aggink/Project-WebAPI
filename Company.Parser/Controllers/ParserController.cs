using Company.Base.Enums;
using Company.Parser.Controllers.FactoryController;
using Company.Parser.Data;
using Company.Parser.Infrastructure.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Company.Parser.Controllers;

[ApiController]
[Route("parser")]
[Produces("application/json")]
[GenericRestControllerNameConvention]
public class ParserController<TDbContext> : Controller
    where TDbContext : ParserDbContext
{
    private readonly IParserManager<TDbContext> _manager;

    public ParserController(IParserManager<TDbContext> manager)
    {
        _manager = manager;
    }

    protected string UserName { get; set; } = "admin";

    [HttpPost]
    public async Task<IActionResult> CreateAsync()
    {
        try
        {
            await _manager.CreateAsync(UserName);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete]
    public virtual async Task<IActionResult> DeleteAsync([FromQuery][Required] Guid id)
    {
        try
        {
            await _manager.DeleteAsync(id);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpGet]
    public virtual async Task<IActionResult> GetByIdAsync([FromQuery][Required] Guid id)
    {
        try
        {
            var result = await _manager.GetByIdAsync(id);
            return Json(result);
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpGet("GetPage")]
    public async Task<IActionResult> GetPageAsync([FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 50, [FromQuery] SortEnum typeSort = 0)
    {
        var result = await _manager.GetPageAsync(pageIndex, pageSize, typeSort);
        if (result == null) return BadRequest();

        return Json(result);
    }

    [HttpPut("AddTaskQueueAsync")]
    public async Task<IActionResult> AddTaskQueueAsync([FromQuery][Required] Guid id)
    {
        try
        {
            await _manager.AddTaskQueueAsync(id, UserName);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPut("DeletTaskQueue")]
    public async Task<IActionResult> DeleteTaskQueueAsync([FromQuery][Required] Guid id)
    {
        try
        {
            await _manager.DeleteTaskQueueAsync(id, UserName);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPut("StopActiveTask")]
    public async Task<IActionResult> StopActiveTask()
    {
        try
        {
            await _manager.StopActiveTaskAsync(UserName);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}