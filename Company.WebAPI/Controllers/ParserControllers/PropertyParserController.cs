using Company.WebAPI.Infrastructure.Managers.ParserManagers.Interfaces;
using Company.WebAPI.ViewModels.ParserViewModels.PropertyParserViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebAPI.Controllers.ParserControllers;

[ApiController]
[Route("parser/setting")]
public class PropertyParserController : Controller
{
    private readonly IPropertyParserManager _manager;

    public PropertyParserController(IPropertyParserManager manager)
    {
        _manager = manager;
    }

    private readonly string _userName = "admin";

    [HttpPost]
    public async Task<IActionResult> SetPropertyAsync(CreatePropertyParserViewModel model)
    {
        var result = await _manager.CreateAsync(model, _userName);
        if (!result) return BadRequest();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePropertyAsync(Guid id)
    {
        var result = await _manager.DeleteAsync(id);
        if(!result) return BadRequest();

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePropertyAsync(UpdatePropertyParserViewModel model)
    {
        var result = await _manager.UpdateAsync(model, _userName);
        if (!result) return BadRequest();

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPropertiesAsync()
    {
        var result = await _manager.GetAllAsync();
        if(result == null) return BadRequest();

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPropertyAsync(Guid id)
    {
        var result = await _manager.GetByIdAsync(id);
        if (result == null) return BadRequest();

        return Ok();
    }
}