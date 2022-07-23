namespace Company.WPF.Models.ParserModels;

#nullable disable

public class PropertyParserForViewModel : PropertyParser
{
    public List<string> AllNameTypes { get; set; }

    public PropertyParserForViewModel(PropertyParser model)
    {
        Id = model.Id;
        URL = model.URL;
        NameSite = model.NameSite;
        NameCompany = model.NameCompany;
        DescriptionCompany = model.DescriptionCompany;
        NameType = model.NameType;
        ParamsParser = model.ParamsParser;
    }

    public PropertyParserForViewModel() { }
}

#nullable enable