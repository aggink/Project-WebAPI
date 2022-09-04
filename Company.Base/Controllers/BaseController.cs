using Company.Base.Entities;
using Company.Base.Enums;
using Company.Base.Infractructure.Manager;
using Company.Base.ValidateModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Company.Base.Controllers;

[ApiController]
[Produces("application/json")]
public abstract class BaseController<CreateViewModel, UpdateViewModel, ViewModel, TEntity, TDbContext> : Controller, IBaseController<CreateViewModel, UpdateViewModel, ViewModel>
    where CreateViewModel : class
    where UpdateViewModel : class, IPrimaryKey
    where ViewModel : class, IPrimaryKey
    where TEntity : class, IPrimaryKey
    where TDbContext : DbContext
{
    protected readonly IBaseManager<CreateViewModel, UpdateViewModel, ViewModel> _manager;

    public BaseController(
        IBaseManager<CreateViewModel, UpdateViewModel, ViewModel> manager)
    {
        _manager = manager;
    }

    protected string UserName { get; set; } = "admin";
    protected const string GetPageMethodName = "GetPage";

    [HttpPost]
    [ValidateModel]
    public virtual async Task<IActionResult> CreateAsync([FromBody][Required] CreateViewModel model)
    {
        try
        {
            await _manager.CreateAsync(model, UserName);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPut]
    [ValidateModel]
    public virtual async Task<IActionResult> UpdateAsync([FromBody][Required] UpdateViewModel model)
    {
        try
        {
            await _manager.UpdateAsync(model, UserName);
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

    [HttpGet(GetPageMethodName)]
    public async Task<IActionResult> GetPageAsync([FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 50, [FromQuery] SortEnum typeSort = 0)
    {
        try
        {
            var result = await _manager.GetPageAsync(pageIndex, pageSize, typeSort);
            return Json(result);
        }
        catch
        {
            return BadRequest();
        }
    }
}