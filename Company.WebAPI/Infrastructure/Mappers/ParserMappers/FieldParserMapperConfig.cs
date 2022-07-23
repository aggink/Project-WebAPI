using Company.Entity.Parser;
using Company.WebAPI.Infrastructure.Mappers.Base;
using Company.WebAPI.ViewModels.ParserViewModels.FieldParserViewModels;

namespace Company.WebAPI.Infrastructure.Mappers.ParserMappers;

public class FieldParserMapperConfig : BaseMapperConfig
{
    public FieldParserMapperConfig()
    {
        CreateMap<FieldParser, FieldParserViewModel>()
            .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
            .ForMember(x => x.PropertyParserId, o => o.MapFrom(m => m.PropertyParserId))
            .ForMember(x => x.PropertyName, o => o.MapFrom(m => m.PropertyName))
            .ForMember(x => x.DefaultValue, o => o.MapFrom(m => m.DefaultValue))
            .ForMember(x => x.StringParse, o => o.MapFrom(m => m.StringParse));

        CreateMap<FieldParserViewModel, FieldParser>()
            .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
            .ForMember(x => x.PropertyParserId, o => o.MapFrom(m => m.PropertyParserId))
            .ForMember(x => x.PropertyName, o => o.MapFrom(m => m.PropertyName))
            .ForMember(x => x.DefaultValue, o => o.MapFrom(m => m.DefaultValue))
            .ForMember(x => x.StringParse, o => o.MapFrom(m => m.StringParse))
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore());

        CreateMap<FieldParser, CreateFieldParserViewModel>()
            .ForMember(x => x.PropertyParserId, o => o.MapFrom(m => m.PropertyParserId))
            .ForMember(x => x.PropertyName, o => o.MapFrom(m => m.PropertyName))
            .ForMember(x => x.DefaultValue, o => o.MapFrom(m => m.DefaultValue))
            .ForMember(x => x.StringParse, o => o.MapFrom(m => m.StringParse))
            .ConstructUsing(x => new CreateFieldParserViewModel());

        CreateMap<CreateFieldParserViewModel, FieldParser>()
            .ForMember(x => x.PropertyParserId, o => o.MapFrom(m => m.PropertyParserId))
            .ForMember(x => x.PropertyName, o => o.MapFrom(m => m.PropertyName))
            .ForMember(x => x.DefaultValue, o => o.MapFrom(m => m.DefaultValue))
            .ForMember(x => x.StringParse, o => o.MapFrom(m => m.StringParse))
            .ForMember(x => x.Id, o => o.Ignore())
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore());

        CreateMap<FieldParser, UpdateFieldParserViewModel>()
            .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
            .ForMember(x => x.PropertyParserId, o => o.MapFrom(m => m.PropertyParserId))
            .ForMember(x => x.PropertyName, o => o.MapFrom(m => m.PropertyName))
            .ForMember(x => x.DefaultValue, o => o.MapFrom(m => m.DefaultValue))
            .ForMember(x => x.StringParse, o => o.MapFrom(m => m.StringParse))
            .ConstructUsing(x => new UpdateFieldParserViewModel());

        CreateMap<UpdateFieldParserViewModel, FieldParser>()
            .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
            .ForMember(x => x.PropertyParserId, o => o.MapFrom(m => m.PropertyParserId))
            .ForMember(x => x.PropertyName, o => o.MapFrom(m => m.PropertyName))
            .ForMember(x => x.DefaultValue, o => o.MapFrom(m => m.DefaultValue))
            .ForMember(x => x.StringParse, o => o.MapFrom(m => m.StringParse))
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore());
    }
}