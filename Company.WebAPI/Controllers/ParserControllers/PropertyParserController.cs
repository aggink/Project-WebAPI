using Company.WebAPI.Controllers.Base;
using Company.WebAPI.Infrastructure.Managers.ParserManagers.Interfaces;
using Company.WebAPI.ViewModels.ParserViewModels.PropertyParserViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebAPI.Controllers.ParserControllers;

[ApiController]
[Produces("application/json")]
[Route("parser/setting")]
public class PropertyParserController : BaseController<CreatePropertyParserViewModel, UpdatePropertyParserViewModel, PropertyParserViewModel>
{
    private readonly IPropertyParserManager _manager;

    public PropertyParserController(IPropertyParserManager manager) : base(manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _manager.GetAllAsync();
        if (result == null) return BadRequest();

        return Json(result);
    }
}