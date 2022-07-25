using Company.WebAPI.Infrastructure.Enums;
using Company.WebAPI.Infrastructure.Managers.ProductManagers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebAPI.Controllers.ProductControllers.Base;

[ApiController]
[Produces("application/json")]
public abstract class BaseProductController<CreateViewModel, UpdateViewModel, ViewModel> : Controller
    where CreateViewModel : class
    where UpdateViewModel : class
    where ViewModel : class
{
    private readonly IProductManager<CreateViewModel, UpdateViewModel, ViewModel> _manager;

    public BaseProductController(
        IProductManager<CreateViewModel, UpdateViewModel, ViewModel> manager)
    {
        _manager = manager;
    }

    private readonly string _userName = "admin";

    [HttpPost]
    public async Task<IActionResult> Create(CreateViewModel model)
    {
        var result = await _manager.CreateAsync(model, _userName);
        if (!result) return BadRequest();

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateViewModel model)
    {
        var result = await _manager.UpdateAsync(model, _userName);
        if (!result) return BadRequest();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _manager.DeleteAsync(id);
        if (!result) return BadRequest();

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _manager.GetByIdAsync(id);
        if (result == null) return BadRequest();

        return Json(result);
    }

    [HttpGet("{parserid}/{pageindex}/{pagesize}/{conditionsort}/{typesort}")]
    public async Task<IActionResult> GetPage(Guid parserId, int pageIndex, int pageSize, string conditionSort, string typeSort)
    {
        if (!Enum.TryParse(typeof(SortEnum), typeSort, out object? type)) return BadRequest();

        var result = await _manager.GetPageAsync(parserId, pageIndex, pageSize, conditionSort, (SortEnum)type!);
        if (result == null) return BadRequest();

        return Json(result);
    }
}