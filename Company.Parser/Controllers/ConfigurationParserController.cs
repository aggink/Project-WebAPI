using Company.Base.Controllers;
using Company.Parser.Controllers.FactoryController;
using Company.Parser.Data;
using Company.Parser.Entities;
using Company.Parser.Infrastructure.Managers.Interfaces;
using Company.Parser.ViewModels.ConfigurationParserViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Company.Parser.Controllers;

[Route("parser/configuration")]
[GenericRestControllerNameConvention]
public class ConfigurationParserController<TDbContext>
    : BaseController<CreateConfigurationParserViewModel, UpdateConfigurationParserViewModel, ConfigurationParserViewModel, ConfigurationParser, TDbContext>
    where TDbContext : ParserDbContext
{
    protected new readonly IConfigurationParserManager<TDbContext> _manager;

    public ConfigurationParserController(IConfigurationParserManager<TDbContext> manager) : base(manager)
    {
        _manager = manager;
    }
}