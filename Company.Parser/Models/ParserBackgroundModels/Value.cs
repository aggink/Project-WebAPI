using Company.Parser.Entities;

namespace Company.Parser.Models.ParserBackgroundModels;

/// <summary>
/// Класс предоставляющий данные о считанном значении
/// </summary>
public class Value
{
    /// <summary>
    /// Индентификатор информации о ссылки
    /// </summary>
    public Guid InfoURLId { get; set; }

    /// <summary>
    /// Индентификатор парсера
    /// </summary>
    public ConfigurationParser Configuration { get; set; } = null!;

    /// <summary>
    /// Считанные значения
    /// </summary>
    public List<Parameter> Parameters { get; set; } = null!;

    /// <summary>
    /// Есть ли считанные значения?
    /// </summary>
    public bool IsParameters { get => Parameters.Any(); }

    public Value()
    {
        Parameters = new List<Parameter>();
    }

    /// <summary>
    /// Добавить параметр
    /// </summary>
    /// <param name="name">Имя свойства</param>
    /// <param name="value">Значение</param>
    public void AddParameter(string name, string value)
    {
        Parameters.Add(new Parameter(name, value));
    }

    /// <summary>
    /// Количество значений
    /// </summary>
    public int Count { get => Parameters.Count; }
}