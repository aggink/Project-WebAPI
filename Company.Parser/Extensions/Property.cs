using Company.Parser.Models.ParserBackgroundModels;

namespace Company.Parser.Extensions;

/// <summary>
/// Контейнер параметров добавляет к классу дополнительные параметры, содержащиеся в нем. 
/// </summary>
public class Property
{
    /// <summary>
    /// Установить значение в поле
    /// </summary>
    /// <typeparam name="TEntity">Тип модели</typeparam>
    /// <param name="entity">Модель для присвоения значений</param>
    /// <param name="parameter">Значения для присвоения модели</param>
    /// <returns>Модель</returns>
    /// <exception cref="Exception">Тип не определен</exception>
    /// <exception cref="ArgumentException">Поле не найдено</exception>
    public static TEntity SetValueInField<TEntity>(TEntity entity, Parameter parameter)
        where TEntity : class
    {
        var EntityType = typeof(TEntity);
        var Fields = EntityType!.GetFields();
        if (!Fields.Any()) throw new Exception($"This type ({EntityType.FullName}) has no properties.");

        var fieldInfo = Fields.FirstOrDefault(x => x.Name == parameter.Name);
        if (fieldInfo == null) throw new Exception($"Field ({parameter.Name}) not found.");

        object value = parameter.Value;

        Type type = fieldInfo.FieldType;
        switch (type.Name)
        {
            case "String":
                fieldInfo.SetValue(entity, value.ToString());
                break;

            case "Int32":
                try
                {
                    fieldInfo.SetValue(entity, (int)Convert.ChangeType(value, type));
                }
                catch
                {
                    fieldInfo.SetValue(entity, default(int));
                }
                break;

            case "Double":
                try
                {
                    fieldInfo.SetValue(entity, (double)Convert.ChangeType(value, type));
                }
                catch
                {
                    fieldInfo.SetValue(entity, default(double));
                }
                break;

            case "Decimal":
                try
                {
                    fieldInfo.SetValue(entity, (decimal)Convert.ChangeType(value, type));
                }
                catch
                {
                    fieldInfo.SetValue(entity, default(decimal));
                }
                break;

            case "DateTime":
                try
                {
                    fieldInfo.SetValue(entity, (DateTime)Convert.ChangeType(value, type));
                }
                catch
                {
                    fieldInfo.SetValue(entity, default(DateTime));
                }
                break;

            default:
                throw new Exception();
        }

        return entity;
    }

    /// <summary>
    /// Установить значение в поле
    /// </summary>
    /// <typeparam name="TEntity">Тип модели</typeparam>
    /// <param name="entity">Модель для присвоения значений</param>
    /// <param name="parameter">Значения для присвоения модели</param>
    /// <returns>Модель</returns>
    /// <exception cref="Exception">Тип не определен</exception>
    /// <exception cref="ArgumentException">Поле не найдено</exception>
    public static TEntity SetValueInProperty<TEntity>(TEntity entity, Parameter parameter)
        where TEntity : class
    {
        var EntityType = typeof(TEntity);
        var Properties = EntityType!.GetProperties();
        if (!Properties.Any()) throw new Exception($"This type ({EntityType.FullName}) has no properties.");

        var propertyInfo = Properties.FirstOrDefault(p => p.Name == parameter.Name);
        if (propertyInfo == null) throw new Exception($"Property ({parameter.Name}) not found.");

        object value = parameter.Value;

        Type type = propertyInfo!.PropertyType;
        switch (type.Name)
        {
            case "String":
                propertyInfo.SetValue(entity, value.ToString());
                break;

            case "Int32":
                try
                {
                    propertyInfo.SetValue(entity, (int)Convert.ChangeType(value, type));
                }
                catch
                {
                    propertyInfo.SetValue(entity, default(int));
                }
                break;

            case "Double":
                try
                {
                    propertyInfo.SetValue(entity, (double)Convert.ChangeType(value, type));
                }
                catch
                {
                    propertyInfo.SetValue(entity, default(double));
                }
                break;

            case "Decimal":
                try
                {
                    propertyInfo.SetValue(entity, (decimal)Convert.ChangeType(value, type));
                }
                catch
                {
                    propertyInfo.SetValue(entity, default(decimal));
                }
                break;

            case "DateTime":
                try
                {
                    propertyInfo.SetValue(entity, (DateTime)Convert.ChangeType(value, type));
                }
                catch
                {
                    propertyInfo.SetValue(entity, default(DateTime));
                }
                break;

            default:
                throw new Exception();
        }

        return entity;
    }
}