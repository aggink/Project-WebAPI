using System.Reflection;
using System.Text;

namespace Company.Parser.Entities
{
    public class Field
    {
        public bool IsClass { get; private set; }
        public string Name { get; private set; } = null!;
        public FieldInfo Info { get; private set; } = null!;
        public Type Type { get; private set; } = null!;

        public Field(FieldInfo field)
        {
            Name = field.Name;
            Info = field;
            Type = field.FieldType;
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