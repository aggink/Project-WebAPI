using Company.Base.Mapper;
using Company.Parser.Entities;
using Company.Parser.ViewModels.FieldConfigurationViewModels;

namespace Company.Parser.Infrastructure.Mappers;

public class FieldConfigurationMapperConfig : MapperConfig
{
    public FieldConfigurationMapperConfig()
    {
        #region CreateMap ViewModel

        CreateMap<FieldConfigurationViewModel, FieldConfiguration>()
            .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
            .ForMember(x => x.ConfigurationId, o => o.MapFrom(m => m.ConfigurationId))
            .ForMember(x => x.PropertyName, o => o.MapFrom(m => m.PropertyName))
            .ForMember(x => x.Description, o => o.MapFrom(m => m.Description))
            .ForMember(x => x.StringParse, o => o.MapFrom(m => m.StringParse))
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore())
            .ForMember(x => x.Configuration, o => o.Ignore());

        CreateMap<FieldConfiguration, FieldConfigurationViewModel>()
            .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
            .ForMember(x => x.ConfigurationId, o => o.MapFrom(m => m.ConfigurationId))
            .ForMember(x => x.PropertyName, o => o.MapFrom(m => m.PropertyName))
            .ForMember(x => x.Description, o => o.MapFrom(m => m.Description))
            .ForMember(x => x.StringParse, o => o.MapFrom(m => m.StringParse));

        AddPagedListMapperConfig<FieldConfiguration, FieldConfigurationViewModel>();

        #endregion

        #region CreateMap CreateViewModel

        CreateMap<CreateFieldConfigurationViewModel, FieldConfiguration>()
            .ForMember(x => x.ConfigurationId, o => o.MapFrom(m => m.ConfigurationId))
            .ForMember(x => x.PropertyName, o => o.MapFrom(m => m.PropertyName))
            .ForMember(x => x.Description, o => o.MapFrom(m => m.Description))
            .ForMember(x => x.StringParse, o => o.MapFrom(m => m.StringParse))
            .ForMember(x => x.Id, o => o.Ignore())
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore())
            .ForMember(x => x.Configuration, o => o.Ignore());

        CreateMap<FieldConfiguration, CreateFieldConfigurationViewModel>()
            .ForMember(x => x.ConfigurationId, o => o.MapFrom(m => m.ConfigurationId))
            .ForMember(x => x.PropertyName, o => o.MapFrom(m => m.PropertyName))
            .ForMember(x => x.Description, o => o.MapFrom(m => m.Description))
            .ForMember(x => x.StringParse, o => o.MapFrom(m => m.StringParse));

        #endregion

        #region CreateMap UpdateViewModel

        CreateMap<UpdateFieldConfigurationViewModel, FieldConfiguration>()
            .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
            .ForMember(x => x.ConfigurationId, o => o.MapFrom(m => m.ConfigurationId))
            .ForMember(x => x.PropertyName, o => o.MapFrom(m => m.PropertyName))
            .ForMember(x => x.Description, o => o.MapFrom(m => m.Description))
            .ForMember(x => x.StringParse, o => o.MapFrom(m => m.StringParse))
            .ForMember(x => x.Id, o => o.Ignore())
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore())
            .ForMember(x => x.Configuration, o => o.Ignore());

        CreateMap<FieldConfiguration, UpdateFieldConfigurationViewModel>()
            .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
            .ForMember(x => x.ConfigurationId, o => o.MapFrom(m => m.ConfigurationId))
            .ForMember(x => x.PropertyName, o => o.MapFrom(m => m.PropertyName))
            .ForMember(x => x.Description, o => o.MapFrom(m => m.Description))
            .ForMember(x => x.StringParse, o => o.MapFrom(m => m.StringParse));

        #endregion
    }
}