using Company.Parser.Entities;
using Company.Parser.Interfaces;
using System.Reflection;

namespace Company.Parser
{
    /// <summary>
    /// Контейнер параметров добавляет к классу дополнительные параметры, содержащиеся в нем. 
    /// </summary>
    public class Property<TResult> : IProperty<TResult>
        where TResult : class
    {
        #region Constructor

        public Type EntityType { get; }
        public FieldInfo[] Fields { get; }
        public PropertyInfo[] Properties { get; }

        public Property()
        {
            EntityType = typeof(TResult);
            if (EntityType == null) throw new ArgumentNullException(nameof(EntityType));

            Fields = EntityType!.GetFields();
            Properties = EntityType!.GetProperties();
        }

        #endregion

        public TResult SetValueInField(TResult result, Parameter parameter)
        {
            var fieldInfo = Fields.FirstOrDefault(x => x.Name == parameter.Name);
            if (fieldInfo == null) throw new ArgumentNullException(nameof(fieldInfo));

            object value = parameter.Value;

            Type type = fieldInfo.FieldType;
            switch (type.Name)
            {
                case "String":
                    fieldInfo.SetValue(result, value.ToString());
                    break;

                case "Int32":
                    try
                    {
                        fieldInfo.SetValue(result, (int)Convert.ChangeType(value, type));
                    }
                    catch
                    {
                        fieldInfo.SetValue(result, default(int));
                    }
                    break;

                case "Double":
                    try
                    {
                        fieldInfo.SetValue(result, (double)Convert.ChangeType(value, type));
                    }
                    catch
                    {
                        fieldInfo.SetValue(result, default(double));
                    }
                    break;

                case "Decimal":
                    try
                    {
                        fieldInfo.SetValue(result, (decimal)Convert.ChangeType(value, type));
                    }
                    catch
                    {
                        fieldInfo.SetValue(result, default(decimal));
                    }
                    break;

                case "DateTime":
                    try
                    {
                        fieldInfo.SetValue(result, (DateTime)Convert.ChangeType(value, type));
                    }
                    catch
                    {
                        fieldInfo.SetValue(result, default(DateTime));
                    }
                    break;

                default:
                    throw new Exception();
            }

            return result;
        }

        public TResult SetValueInProperty(TResult result, Parameter parameter)
        {
            var propertyInfo = Properties.FirstOrDefault(p => p.Name == parameter.Name);
            if (propertyInfo != null) throw new ArgumentNullException(nameof(propertyInfo));

            object value = parameter.Value;

            Type type = propertyInfo!.PropertyType;
            switch (type.Name)
            {
                case "String":
                    propertyInfo.SetValue(result, value.ToString());
                    break;

                case "Int32":
                    try
                    {
                        propertyInfo.SetValue(result, (int)Convert.ChangeType(value, type));
                    }
                    catch
                    {
                        propertyInfo.SetValue(result, default(int));
                    }
                    break;

                case "Double":
                    try
                    {
                        propertyInfo.SetValue(result, (double)Convert.ChangeType(value, type));
                    }
                    catch
                    {
                        propertyInfo.SetValue(result, default(double));
                    }
                    break;

                case "Decimal":
                    try
                    {
                        propertyInfo.SetValue(result, (decimal)Convert.ChangeType(value, type));
                    }
                    catch
                    {
                        propertyInfo.SetValue(result, default(decimal));
                    }
                    break;

                case "DateTime":
                    try
                    {
                        propertyInfo.SetValue(result, (DateTime)Convert.ChangeType(value, type));
                    }
                    catch
                    {
                        propertyInfo.SetValue(result, default(DateTime));
                    }
                    break;

                default:
                    throw new Exception();
            }

            return result;
        }
    }
}