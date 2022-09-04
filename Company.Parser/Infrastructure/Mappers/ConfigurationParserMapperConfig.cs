using Company.Base.Mapper;
using Company.Parser.Entities;
using Company.Parser.ViewModels.ConfigurationParserViewModels;

namespace Company.Parser.Infrastructure.Mappers;

public class ConfigurationParserMapperConfig : MapperConfig
{
    public ConfigurationParserMapperConfig()
    {
        #region CreateMap ViewModel

        CreateMap<ConfigurationParserViewModel, ConfigurationParser>()
            .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
            .ForMember(x => x.ParserId, o => o.MapFrom(m => m.ParserId))
            .ForMember(x => x.URL, o => o.MapFrom(m => m.URL))
            .ForMember(x => x.SiteName, o => o.MapFrom(m => m.SiteName))
            .ForMember(x => x.CompanyName, o => o.MapFrom(m => m.CompanyName))
            .ForMember(x => x.CompanyDescription, o => o.MapFrom(m => m.CompanyDescription))
            .ForMember(x => x.ComparatorLink, o => o.MapFrom(m => m.ComparatorLink))
            .ForMember(x => x.Fields, o => o.MapFrom(m => m.Fields))
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore())
            .ForMember(x => x.Parser, o => o.Ignore());

        CreateMap<ConfigurationParser, ConfigurationParserViewModel>()
            .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
            .ForMember(x => x.ParserId, o => o.MapFrom(m => m.ParserId))
            .ForMember(x => x.URL, o => o.MapFrom(m => m.URL))
            .ForMember(x => x.SiteName, o => o.MapFrom(m => m.SiteName))
            .ForMember(x => x.CompanyName, o => o.MapFrom(m => m.CompanyName))
            .ForMember(x => x.CompanyDescription, o => o.MapFrom(m => m.CompanyDescription))
            .ForMember(x => x.ComparatorLink, o => o.MapFrom(m => m.ComparatorLink))
            .ForMember(x => x.Fields, o => o.MapFrom(m => m.Fields));

        AddPagedListMapperConfig<ConfigurationParser, ConfigurationParserViewModel>();

        #endregion

        #region CreateMap CreateViewModel

        CreateMap<CreateConfigurationParserViewModel, ConfigurationParser>()
            .ForMember(x => x.ParserId, o => o.MapFrom(m => m.ParserId))
            .ForMember(x => x.URL, o => o.MapFrom(m => m.URL))
            .ForMember(x => x.SiteName, o => o.MapFrom(m => m.SiteName))
            .ForMember(x => x.CompanyName, o => o.MapFrom(m => m.CompanyName))
            .ForMember(x => x.CompanyDescription, o => o.MapFrom(m => m.CompanyDescription))
            .ForMember(x => x.ComparatorLink, o => o.MapFrom(m => m.ComparatorLink))
            .ForMember(x => x.Id, o => o.Ignore())
            .ForMember(x => x.Fields, o => o.Ignore())
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore())
            .ForMember(x => x.Parser, o => o.Ignore());

        CreateMap<ConfigurationParser, CreateConfigurationParserViewModel>()
            .ForMember(x => x.ParserId, o => o.MapFrom(m => m.ParserId))
            .ForMember(x => x.URL, o => o.MapFrom(m => m.URL))
            .ForMember(x => x.SiteName, o => o.MapFrom(m => m.SiteName))
            .ForMember(x => x.CompanyName, o => o.MapFrom(m => m.CompanyName))
            .ForMember(x => x.CompanyDescription, o => o.MapFrom(m => m.CompanyDescription))
            .ForMember(x => x.ComparatorLink, o => o.MapFrom(m => m.ComparatorLink));

        #endregion

        #region CreateMap UpdateViewModel

        CreateMap<UpdateConfigurationParserViewModel, ConfigurationParser>()
            .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
            .ForMember(x => x.ParserId, o => o.MapFrom(m => m.ParserId))
            .ForMember(x => x.URL, o => o.MapFrom(m => m.URL))
            .ForMember(x => x.SiteName, o => o.MapFrom(m => m.SiteName))
            .ForMember(x => x.CompanyName, o => o.MapFrom(m => m.CompanyName))
            .ForMember(x => x.CompanyDescription, o => o.MapFrom(m => m.CompanyDescription))
            .ForMember(x => x.ComparatorLink, o => o.MapFrom(m => m.ComparatorLink))
            .ForMember(x => x.Fields, o => o.Ignore())
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore())
            .ForMember(x => x.Parser, o => o.Ignore());

        CreateMap<ConfigurationParser, UpdateConfigurationParserViewModel>()
            .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
            .ForMember(x => x.ParserId, o => o.MapFrom(m => m.ParserId))
            .ForMember(x => x.URL, o => o.MapFrom(m => m.URL))
            .ForMember(x => x.SiteName, o => o.MapFrom(m => m.SiteName))
            .ForMember(x => x.CompanyName, o => o.MapFrom(m => m.CompanyName))
            .ForMember(x => x.CompanyDescription, o => o.MapFrom(m => m.CompanyDescription))
            .ForMember(x => x.ComparatorLink, o => o.MapFrom(m => m.ComparatorLink))
            .ForMember(x => x.Id, o => o.Ignore());

        #endregion
    }
}