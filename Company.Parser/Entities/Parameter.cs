namespace Company.Parser.Entities
{
    public class Parameter
    {
        public string Name { get; }
        public object Value { get; }

        public Parameter(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}