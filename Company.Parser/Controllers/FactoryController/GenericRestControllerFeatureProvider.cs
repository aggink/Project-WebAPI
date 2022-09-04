using Company.Parser.Data;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Reflection;

namespace Company.Parser.Controllers.FactoryController;

/// <summary>
/// Добавление generic контроллеров к контроллерам.
/// </summary>
/// <typeparam name="TDbContext"></typeparam>
public class GenericRestControllerFeatureProvider<TDbContext> : IApplicationFeatureProvider<ControllerFeature>
    where TDbContext : ParserDbContext
{
    public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
    {
        var parserControllerType = typeof(ParserController<>).MakeGenericType(typeof(TDbContext)).GetTypeInfo();
        feature.Controllers.Add(parserControllerType);

        var configurationControllerType = typeof(ConfigurationParserController<>).MakeGenericType(typeof(TDbContext)).GetTypeInfo();
        feature.Controllers.Add(configurationControllerType);

        var fieldControllerType = typeof(FieldConfigurationController<>).MakeGenericType(typeof(TDbContext)).GetTypeInfo();
        feature.Controllers.Add(fieldControllerType);

        var urlControllerType = typeof(URLController<>).MakeGenericType(typeof(TDbContext)).GetTypeInfo();
        feature.Controllers.Add(urlControllerType);
    }
}