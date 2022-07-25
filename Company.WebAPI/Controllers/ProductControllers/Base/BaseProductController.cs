using Company.WebAPI.Controllers.Base;
using Company.WebAPI.Infrastructure.Enums;
using Company.WebAPI.Infrastructure.Managers.ProductManagers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebAPI.Controllers.ProductControllers.Base;

public abstract class BaseProductController<CreateViewModel, UpdateViewModel, ViewModel> 
    : BaseController<CreateViewModel, UpdateViewModel, ViewModel>
    where CreateViewModel : class
    where UpdateViewModel : class
    where ViewModel : class
{
    private readonly IProductManager<CreateViewModel, UpdateViewModel, ViewModel> _manager;

    public BaseProductController(
        IProductManager<CreateViewModel, UpdateViewModel, ViewModel> manager) : base(manager)
    {
        _manager = manager;
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