using Company.Base.Mapper;
using Company.Entity;
using Company.WebAPI.ViewModels.ParseValuesProductViewModel;

namespace Company.WebAPI.Infrastructure.Mappers;

public class ParseValuesProductMapperConfig : MapperConfig
{
    public ParseValuesProductMapperConfig()
    {
        #region CreateMap ViewModel

        CreateMap<ParseValuesProduct, ParseValuesProductViewModel>()
            .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
            .ForMember(x => x.URLId, o => o.MapFrom(x => x.InfoURLId))
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.Description, o => o.MapFrom(x => x.Description))
            .ForMember(x => x.Text, o => o.MapFrom(x => x.Text))
            .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
            .ForMember(x => x.Price5, o => o.MapFrom(x => x.Price5))
            .ForMember(x => x.Price10, o => o.MapFrom(x => x.Price10))
            .ForMember(x => x.AvailabilityProductOffice, o => o.MapFrom(x => x.AvailabilityProductOffice))
            .ForMember(x => x.AvailabilityProductStock, o => o.MapFrom(x => x.AvailabilityProductStock));

        CreateMap<ParseValuesProductViewModel, ParseValuesProduct>()
            .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.Description, o => o.MapFrom(x => x.Description))
            .ForMember(x => x.Text, o => o.MapFrom(x => x.Text))
            .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
            .ForMember(x => x.Price5, o => o.MapFrom(x => x.Price5))
            .ForMember(x => x.Price10, o => o.MapFrom(x => x.Price10))
            .ForMember(x => x.AvailabilityProductOffice, o => o.MapFrom(x => x.AvailabilityProductOffice))
            .ForMember(x => x.AvailabilityProductStock, o => o.MapFrom(x => x.AvailabilityProductStock))
            .ForMember(x => x.InfoURLId, o => o.MapFrom(x => x.URLId))
            .ForMember(x => x.InfoURL, o => o.Ignore())
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore());

        AddPagedListMapperConfig<ParseValuesProduct, ParseValuesProductViewModel>();

        #endregion

        #region CreateMap CreateViewModel

        CreateMap<ParseValuesProduct, CreateParseValuesProductViewModel>()
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.Description, o => o.MapFrom(x => x.Description))
            .ForMember(x => x.Text, o => o.MapFrom(x => x.Text))
            .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
            .ForMember(x => x.Price5, o => o.MapFrom(x => x.Price5))
            .ForMember(x => x.Price10, o => o.MapFrom(x => x.Price10))
            .ForMember(x => x.AvailabilityProductOffice, o => o.MapFrom(x => x.AvailabilityProductOffice))
            .ForMember(x => x.AvailabilityProductStock, o => o.MapFrom(x => x.AvailabilityProductStock));

        CreateMap<CreateParseValuesProductViewModel, ParseValuesProduct>()
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.Description, o => o.MapFrom(x => x.Description))
            .ForMember(x => x.Text, o => o.MapFrom(x => x.Text))
            .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
            .ForMember(x => x.Price5, o => o.MapFrom(x => x.Price5))
            .ForMember(x => x.Price10, o => o.MapFrom(x => x.Price10))
            .ForMember(x => x.AvailabilityProductOffice, o => o.MapFrom(x => x.AvailabilityProductOffice))
            .ForMember(x => x.AvailabilityProductStock, o => o.MapFrom(x => x.AvailabilityProductStock))
            .ForMember(x => x.Id, o => o.Ignore())
            .ForMember(x => x.InfoURLId, o => o.Ignore())
            .ForMember(x => x.InfoURL, o => o.Ignore())
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore());

        #endregion

        #region CreateMap UpdateViewModel

        CreateMap<ParseValuesProduct, UpdateParseValuesProductViewModel>()
            .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.Description, o => o.MapFrom(x => x.Description))
            .ForMember(x => x.Text, o => o.MapFrom(x => x.Text))
            .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
            .ForMember(x => x.Price5, o => o.MapFrom(x => x.Price5))
            .ForMember(x => x.Price10, o => o.MapFrom(x => x.Price10))
            .ForMember(x => x.AvailabilityProductOffice, o => o.MapFrom(x => x.AvailabilityProductOffice))
            .ForMember(x => x.AvailabilityProductStock, o => o.MapFrom(x => x.AvailabilityProductStock));

        CreateMap<UpdateParseValuesProductViewModel, ParseValuesProduct>()
            .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.Description, o => o.MapFrom(x => x.Description))
            .ForMember(x => x.Text, o => o.MapFrom(x => x.Text))
            .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
            .ForMember(x => x.Price5, o => o.MapFrom(x => x.Price5))
            .ForMember(x => x.Price10, o => o.MapFrom(x => x.Price10))
            .ForMember(x => x.AvailabilityProductOffice, o => o.MapFrom(x => x.AvailabilityProductOffice))
            .ForMember(x => x.AvailabilityProductStock, o => o.MapFrom(x => x.AvailabilityProductStock))
            .ForMember(x => x.InfoURLId, o => o.Ignore())
            .ForMember(x => x.InfoURL, o => o.Ignore())
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore());

        #endregion
    }
}