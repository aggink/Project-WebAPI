using Company.WebAPI.Controllers.Base;
using Company.WebAPI.Infrastructure.Managers.ParserManagers.Interfaces;
using Company.WebAPI.ViewModels.ParserViewModels.FieldParserViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebAPI.Controllers.ParserControllers;

[ApiController]
[Produces("application/json")]
[Route("parser/localsetting")]
public class FieldParserController : BaseController<CreateFieldParserViewModel, UpdateFieldParserViewModel, FieldParserViewModel>
{
    private readonly IFieldParserManager _manager;

    public FieldParserController(IFieldParserManager manager) : base(manager)
    {
        _manager = manager;
    }


    [HttpPost]
    public async Task<IActionResult> Create(IList<CreateFieldParserViewModel> models)
    {
        var result = await _manager.CreateAsync(models, _userName);
        if (!result) return BadRequest();

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(IList<UpdateFieldParserViewModel> models)
    {
        var result = await _manager.UpdateAsync(models, _userName);
        if(!result) return BadRequest();

        return Ok();
    }

    [HttpGet("parser/{id}")]
    public async Task<IActionResult> GetByParserIdAsync(Guid id)
    {
        var result = await _manager.GetByPropertyIdAsync(id);
        if(result == null) return BadRequest();

        return Json(result);
    }
}