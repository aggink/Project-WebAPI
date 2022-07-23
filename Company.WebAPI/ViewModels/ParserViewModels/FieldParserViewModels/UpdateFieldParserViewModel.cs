using Company.Data.DbContexts;
using Company.Entity.Parser;
using Company.Entity.Products;
using Company.WebAPI.Infrastructure.Repositories.Base;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Company.WebAPI.ViewModels.ParserViewModels.FieldParserViewModels;

#nullable disable

public class UpdateFieldParserViewModel : IValidatableObject
{
    private readonly IRepository<ParserDbContext, PropertyParser> _propertyParserRepository;
    private readonly IRepository<ParserDbContext, FieldParser> _fieldParserRepository;
    private readonly IRepository<ParserDbContext, WorkParser> _workParserRepository;

    public UpdateFieldParserViewModel(
        IRepository<ParserDbContext, PropertyParser> propertyParserRepository,
        IRepository<ParserDbContext, FieldParser> fieldParserRepository,
        IRepository<ParserDbContext, WorkParser> workParserRepository)
    {
        _propertyParserRepository = propertyParserRepository;
        _fieldParserRepository = fieldParserRepository;
        _workParserRepository = workParserRepository;
    }

    public UpdateFieldParserViewModel() { }

    [Required]
    [JsonProperty(PropertyName = "id")]
    public Guid Id { get; set; }

    [Required]
    [JsonProperty(PropertyName = "property_parser_id")]
    public Guid PropertyParserId { get; set; }

    [Required]
    [JsonProperty(PropertyName = "property_name")]
    public string PropertyName { get; set; }

    [Required]
    [JsonProperty(PropertyName = "default_value")]
    public string DefaultValue { get; set; }

    [Required]
    [JsonProperty(PropertyName = "string_parse")]
    public string StringParse { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        List<ValidationResult> errors = new();

        if (Id == Guid.Empty)
        {
            errors.Add(new ValidationResult("Не задано поле.", new[] { nameof(Id) }));
        }
        else
        {
            var result = Task.Run(async () => await _fieldParserRepository.GetByIdAsync(Id));
            if(result == null)
            {
                errors.Add(new ValidationResult($"Данного id ({Id}) не существует", new[] { nameof(Id) }));
            }
        }

        if (PropertyParserId == Guid.Empty)
        {
            errors.Add(new ValidationResult("Не задано поле.", new[] { nameof(PropertyParserId) }));
        }
        else
        {
            var result = Task.Run(async () => await _propertyParserRepository.GetByIdAsync(PropertyParserId));
            if (result == null)
            {
                errors.Add(new ValidationResult($"Данного id ({PropertyParserId}) не существует", new[] { nameof(PropertyParserId) }));
            }

            var work = Task.Run(async () => await _workParserRepository.GetByIdAsync(PropertyParserId));
            if(work != null)
            {
                errors.Add(new ValidationResult($"В настоящее время данные не могут быть изменены. Данные используются в парсере.", new[] { nameof(PropertyParserId) }));
            }
        }

        if (string.IsNullOrWhiteSpace(PropertyName))
        {
            errors.Add(new ValidationResult("Не задано поле.", new[] { nameof(PropertyName) }));
        }
        else if (!CheckPropertyName(PropertyName))
        {
            errors.Add(new ValidationResult("Значение поля не соответствует разрешенным значениям для данного поля.", new[] { nameof(PropertyName) }));
        }

        if (string.IsNullOrWhiteSpace(DefaultValue))
        {
            errors.Add(new ValidationResult("Не задано поле.", new[] { nameof(DefaultValue) }));
        }

        if (string.IsNullOrWhiteSpace(StringParse))
        {
            errors.Add(new ValidationResult("Не задано поле.", new[] { nameof(StringParse) }));
        }

        return errors;
    }

    private bool CheckPropertyName(string propertyName)
    {
        List<string> nameProperties = new();
        nameProperties.AddRange(typeof(BulatProduct).GetProperties().Select(x => x.Name));
        nameProperties.AddRange(typeof(RamisProduct).GetProperties().Select(x => x.Name));
        nameProperties.AddRange(typeof(ChipCartProduct).GetProperties().Select(x => x.Name));
        nameProperties.AddRange(typeof(ZipZipProduct).GetProperties().Select(x => x.Name));

        var result = nameProperties.FirstOrDefault(x => x.Equals(propertyName));
        if (result == null) return false;

        return true;
    }
}

#nullable enable