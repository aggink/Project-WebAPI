using Company.WebAPI.Infrastructure.Managers.ParserManagers.Interfaces;
using Company.WebAPI.ViewModels.ParserViewModels.FieldParserViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebAPI.Controllers.ParserControllers;

[ApiController]
[Produces("application/json")]
[Route("parser/localsetting")]
public class FieldParserController : Controller
{
    private readonly IFieldParserManager _manager;

    public FieldParserController(IFieldParserManager manager)
    {
        _manager = manager;
    }

    private readonly string _userName = "admin";

    [HttpPost]
    public async Task<IActionResult> SetParamsAsync(IList<CreateFieldParserViewModel> models)
    {
        var result = await _manager.CreateAsync(models, _userName);
        if (!result) return BadRequest();

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateParamsAsync(IList<UpdateFieldParserViewModel> models)
    {
        var result = await _manager.UpdateAsync(models, _userName);
        if(!result) return BadRequest();

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetParamsByPropertyIdAsync(Guid id)
    {
        var result = await _manager.GetByPropertyIdAsync(id);
        if(result == null) return BadRequest();

        return Json(result);
    }
}