using System.Reflection;
using System.Text;

namespace Company.Parser.Entities
{
    public class Property
    {
        public bool IsClass { get; private set; }
        public string Name { get; private set; } = null!;
        public PropertyInfo Info { get; private set; }
        public Type Type { get; private set; } = null!;

        public Property(PropertyInfo property)
        {
            Info = property;
            Name = property.Name;
            Type = property.PropertyType;
            IsClass = Type.IsClass;
        }

        public bool IsString
        {
            get
            {
                if (Type.Name == "String")
                    return true;
                else
                    return false;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"FieldName = {Name}");
            stringBuilder.AppendLine($"FieldType = {Type.Name}");
            stringBuilder.AppendLine($"IsClass = {IsClass}");
            return stringBuilder.ToString();
        }
    }
}