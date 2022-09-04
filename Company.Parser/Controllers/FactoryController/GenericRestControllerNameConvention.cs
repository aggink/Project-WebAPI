using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Company.Parser.Controllers.FactoryController;

/// <summary>
/// Проверка на универсальный тип контроллера и изменение наивенования
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class GenericRestControllerNameConvention : Attribute, IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        if (!controller.ControllerType.IsGenericType || !IsGenericType(controller.ControllerType.GetGenericTypeDefinition()))
        {
            return;
        }

        var entityType = controller.ControllerType.GenericTypeArguments[0];
        controller.ControllerName = controller.ControllerName.Replace("`1", $"<{entityType.Name}>");
    }

    /// <summary>
    /// Проверяем наш контроллер или нет.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static bool IsGenericType(Type type)
    {
        if (type == typeof(ParserController<>)) return true;
        else if (type == typeof(ConfigurationParserController<>)) return true;
        else if (type == typeof(FieldConfigurationController<>)) return true;
        else if (type == typeof(URLController<>)) return true;
        else return false;
    }
}