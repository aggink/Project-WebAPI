using Company.Data.DbContexts;
using Company.Entity.Parser;
using Company.Entity.Products;
using Company.WebAPI.Infrastructure.Repositories.Base;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Company.WebAPI.ViewModels.ParserViewModels.PropertyParserViewModels;

#nullable disable

public class UpdatePropertyParserViewModel : IValidatableObject
{
    private readonly IRepository<ParserDbContext, PropertyParser> _propertyParserRepository;
    private readonly IRepository<ParserDbContext, WorkParser> _workParserRepository;

    public UpdatePropertyParserViewModel(
        IRepository<ParserDbContext, PropertyParser> propertyParserRepository, 
        IRepository<ParserDbContext, WorkParser> workParserRepository)
    {
        _propertyParserRepository = propertyParserRepository;
        _workParserRepository = workParserRepository;
    }

    public UpdatePropertyParserViewModel() { }

    [Required]
    [JsonProperty(PropertyName = "id")]
    public Guid Id { get; set; }

    [Required]
    [JsonProperty(PropertyName = "url")]
    public string URL { get; set; }

    [Required]
    [JsonProperty(PropertyName = "name_site")]
    public string NameSite { get; set; }

    [Required]
    [JsonProperty(PropertyName = "company_name")]
    public string CompanyName { get; set; }

    [Required]
    [JsonProperty(PropertyName = "company_description")]
    public string CompanyDescription { get; set; }

    [Required]
    [JsonProperty(PropertyName = "type_name")]
    public string TypeName { get; set; }

    [Required]
    [JsonProperty(PropertyName = "parser_params")]
    public ICollection<FieldParser> ParserParams { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        List<ValidationResult> errors = new();

        if(Id == Guid.Empty)
        {
            errors.Add(new ValidationResult("Не задано поле.", new[] { nameof(Id) }));
        }
        else
        {
            var result = Task.Run(async () => await _propertyParserRepository.GetByIdAsync(Id));
            if (result == null)
            {
                errors.Add(new ValidationResult($"Данного id ({Id}) не существует", new[] { nameof(Id) }));
            }

            var work = Task.Run(async () => await _workParserRepository.GetByIdAsync(Id));
            if (work != null)
            {
                errors.Add(new ValidationResult($"В настоящее время данные не могут быть изменены. Данные используются в парсере.", new[] { nameof(Id) }));
            }
        }

        if (string.IsNullOrWhiteSpace(URL) || !CheckURLValid(URL))
        {
            errors.Add(new ValidationResult("Некорректный URL-адрес.", new[] { nameof(URL) }));
        }

        if (string.IsNullOrWhiteSpace(NameSite))
        {
            errors.Add(new ValidationResult("Не задано поле.", new[] { nameof(NameSite) }));
        }

        if (string.IsNullOrWhiteSpace(CompanyName))
        {
            errors.Add(new ValidationResult("Не задано поле.", new[] { nameof(NameSite) }));
        }

        if (string.IsNullOrWhiteSpace(CompanyDescription))
        {
            errors.Add(new ValidationResult("Не задано поле.", new[] { nameof(NameSite) }));
        }

        if (string.IsNullOrWhiteSpace(TypeName))
        {
            errors.Add(new ValidationResult("Не задано поле.", new[] { nameof(NameSite) }));
        }
        else if (!CheckTypeName(TypeName))
        {
            errors.Add(new ValidationResult("Значение поля не соответствует разрешенным значениям для данного поля.", new[] { nameof(TypeName) }));
        }

        return errors;
    }

    private bool CheckURLValid(string source)
    {
        try
        {
            if (Uri.TryCreate(source, UriKind.Absolute, out Uri uriResult) &&
                (uriResult.Scheme == Uri.UriSchemeHttps || uriResult.Scheme == Uri.UriSchemeHttp))
            {
                return true;
            }
        }
        catch { return false; }

        return false;
    }

    private bool CheckTypeName(string name)
    {
        List<string> nameClass = new()
        {
            nameof(BulatProduct),
            nameof(RamisProduct),
            nameof(ZipZipProduct),
            nameof(ChipCartProduct)
        };

        var result = nameClass.FirstOrDefault(x => x.Equals(name));
        if (result == null) return false;

        return true;
    }
}

#nullable enable