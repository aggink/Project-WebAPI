using Company.Parser.Entities;
using System.Reflection;

namespace Company.Parser.Interfaces
{
    /// <summary>
    /// Контейнер параметров добавляет к классу дополнительные параметры, содержащиеся в нем. 
    /// </summary>
    public interface IProperty<TResult>
    {
        Type EntityType { get; }
        FieldInfo[] Fields { get; }
        PropertyInfo[] Properties { get; }

        /// <summary>
        /// Установить значение
        /// </summary>
        /// <param name="result"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        TResult SetValueInField(TResult result, Parameter parameter);

        /// <summary>
        /// Установить свойство
        /// </summary>
        /// <param name="result"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        TResult SetValueInProperty(TResult result, Parameter parameter);
    }
}
