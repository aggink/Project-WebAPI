using Company.WebAPI.Infrastructure.Managers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebAPI.Controllers.Base;

[ApiController]
[Produces("application/json")]
public abstract class BaseController<CreateViewModel, UpdateViewModel, ViewModel> : Controller
    where CreateViewModel : class
    where UpdateViewModel : class
    where ViewModel : class
{
    private readonly IBaseManager<CreateViewModel, UpdateViewModel, ViewModel> _baseManager;

    public BaseController(
        IBaseManager<CreateViewModel, UpdateViewModel, ViewModel> manager)
    {
        _baseManager = manager;
    }

    protected readonly string _userName = "admin";

    [HttpPost]
    public async Task<IActionResult> Create(CreateViewModel model)
    {
        var result = await _baseManager.CreateAsync(model, _userName);
        if (!result) return BadRequest();

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateViewModel model)
    {
        var result = await _baseManager.UpdateAsync(model, _userName);
        if (!result) return BadRequest();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _baseManager.DeleteAsync(id);
        if (!result) return BadRequest();

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _baseManager.GetByIdAsync(id);
        if (result == null) return BadRequest();

        return Json(result);
    }
}