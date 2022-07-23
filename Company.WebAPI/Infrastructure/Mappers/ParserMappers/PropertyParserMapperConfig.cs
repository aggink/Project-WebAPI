using Company.Entity.Parser;
using Company.WebAPI.Infrastructure.Mappers.Base;
using Company.WebAPI.ViewModels.ParserViewModels.PropertyParserViewModels;

namespace Company.WebAPI.Infrastructure.Mappers.ParserMappers;

public class PropertyParserMapperConfig : BaseMapperConfig
{
    public PropertyParserMapperConfig()
    {
        CreateMap<PropertyParser, PropertyParserViewModel>()
            .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
            .ForMember(x => x.URL, o => o.MapFrom(m => m.URL))
            .ForMember(x => x.NameSite, o => o.MapFrom(m => m.NameSite))
            .ForMember(x => x.CompanyName, o => o.MapFrom(m => m.CompanyName))
            .ForMember(x => x.CompanyDescription, o => o.MapFrom(m => m.CompanyDescription))
            .ForMember(x => x.TypeName, o => o.MapFrom(m => m.TypeName))
            .ForMember(x => x.ParserParams, o => o.MapFrom(m => m.ParserParams));

        CreateMap<PropertyParserViewModel, PropertyParser>()
            .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
            .ForMember(x => x.URL, o => o.MapFrom(m => m.URL))
            .ForMember(x => x.NameSite, o => o.MapFrom(m => m.NameSite))
            .ForMember(x => x.CompanyName, o => o.MapFrom(m => m.CompanyName))
            .ForMember(x => x.CompanyDescription, o => o.MapFrom(m => m.CompanyDescription))
            .ForMember(x => x.TypeName, o => o.MapFrom(m => m.TypeName))
            .ForMember(x => x.ParserParams, o => o.MapFrom(m => m.ParserParams))
            .ForMember(x => x.UserId, o => o.Ignore())
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore());

        CreateMap<PropertyParser, CreatePropertyParserViewModel>()
            .ForMember(x => x.URL, o => o.MapFrom(m => m.URL))
            .ForMember(x => x.NameSite, o => o.MapFrom(m => m.NameSite))
            .ForMember(x => x.CompanyName, o => o.MapFrom(m => m.CompanyName))
            .ForMember(x => x.CompanyDescription, o => o.MapFrom(m => m.CompanyDescription))
            .ForMember(x => x.TypeName, o => o.MapFrom(m => m.TypeName))
            .ConstructUsing(x => new CreatePropertyParserViewModel());

        CreateMap<CreatePropertyParserViewModel, PropertyParser>()
            .ForMember(x => x.URL, o => o.MapFrom(m => m.URL))
            .ForMember(x => x.NameSite, o => o.MapFrom(m => m.NameSite))
            .ForMember(x => x.CompanyName, o => o.MapFrom(m => m.CompanyName))
            .ForMember(x => x.CompanyDescription, o => o.MapFrom(m => m.CompanyDescription))
            .ForMember(x => x.TypeName, o => o.MapFrom(m => m.TypeName))
            .ForMember(x => x.Id, o => o.Ignore())
            .ForMember(x => x.UserId, o => o.Ignore())
            .ForMember(x => x.ParserParams, o => o.Ignore())
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore());

        CreateMap<PropertyParser, UpdatePropertyParserViewModel>()
            .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
            .ForMember(x => x.URL, o => o.MapFrom(m => m.URL))
            .ForMember(x => x.NameSite, o => o.MapFrom(m => m.NameSite))
            .ForMember(x => x.CompanyName, o => o.MapFrom(m => m.CompanyName))
            .ForMember(x => x.CompanyDescription, o => o.MapFrom(m => m.CompanyDescription))
            .ForMember(x => x.TypeName, o => o.MapFrom(m => m.TypeName))
            .ConstructUsing(x => new UpdatePropertyParserViewModel());

        CreateMap<UpdatePropertyParserViewModel, PropertyParser>()
            .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
            .ForMember(x => x.URL, o => o.MapFrom(m => m.URL))
            .ForMember(x => x.NameSite, o => o.MapFrom(m => m.NameSite))
            .ForMember(x => x.CompanyName, o => o.MapFrom(m => m.CompanyName))
            .ForMember(x => x.CompanyDescription, o => o.MapFrom(m => m.CompanyDescription))
            .ForMember(x => x.TypeName, o => o.MapFrom(m => m.TypeName))
            .ForMember(x => x.UserId, o => o.Ignore())
            .ForMember(x => x.ParserParams, o => o.Ignore())
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore());
    }
}