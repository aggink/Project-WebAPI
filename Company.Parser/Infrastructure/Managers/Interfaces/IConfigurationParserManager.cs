using Company.Base.Infractructure.Manager;
using Company.Parser.Data;
using Company.Parser.Entities;
using Company.Parser.ViewModels.ConfigurationParserViewModels;

namespace Company.Parser.Infrastructure.Managers.Interfaces;

/// <summary>
/// Интерфейс предоставляющий методы по работе с данными Properties
/// </summary>
public interface IConfigurationParserManager<TDbContext>
    : IBaseManager<CreateConfigurationParserViewModel, UpdateConfigurationParserViewModel, ConfigurationParserViewModel>
    where TDbContext : ParserDbContext
{
    
}