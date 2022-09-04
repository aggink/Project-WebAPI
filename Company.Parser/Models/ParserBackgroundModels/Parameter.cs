namespace Company.Parser.Models.ParserBackgroundModels;

/// <summary>
/// Поле: имя - значение
/// </summary>
public class Parameter
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Значение
    /// </summary>
    public object Value { get; }

    public Parameter(string name, object value)
    {
        Name = name;
        Value = value;
    }
}