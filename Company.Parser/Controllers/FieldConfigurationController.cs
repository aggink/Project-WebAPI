using Company.Base.Controllers;
using Company.Parser.Controllers.FactoryController;
using Company.Parser.Data;
using Company.Parser.Entities;
using Company.Parser.Infrastructure.Managers.Interfaces;
using Company.Parser.ViewModels.FieldConfigurationViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Company.Parser.Controllers;

[Route("parser/configuration/field")]
[GenericRestControllerNameConvention]
public class FieldConfigurationController<TDbContext>
    : BaseController<CreateFieldConfigurationViewModel, UpdateFieldConfigurationViewModel, FieldConfigurationViewModel, FieldConfiguration, TDbContext>
    where TDbContext : ParserDbContext
{
    protected new readonly IFieldParserManager<TDbContext> _manager;

    public FieldConfigurationController(IFieldParserManager<TDbContext> manager) : base(manager)
    {
        _manager = manager;
    }

    [HttpGet(Name = "GetByParserId")]
    public async Task<IActionResult> GetByParserIdAsync([FromQuery][Required] Guid id)
    {
        var result = await _manager.GetByPropertyIdAsync(id);
        if(result == null) return BadRequest();

        return Json(result);
    }
}