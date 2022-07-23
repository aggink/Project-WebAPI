namespace Company.WPF.Models.ParserModels;

#nullable disable

public class FieldParserForViewModel : FieldParser
{
    public List<string> AllNameProperties { get; set; }

    public FieldParserForViewModel(FieldParser model)
    {
        Id = model.Id;
        PropertyParserId = model.PropertyParserId;
        NameProperty = model.NameProperty;
        DefaultValue = model.DefaultValue;
        StringParse = model.StringParse;
    }

    public FieldParserForViewModel() { }
}

#nullable enable