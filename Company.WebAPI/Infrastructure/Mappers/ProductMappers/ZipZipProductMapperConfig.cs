using Company.Entity.Products;
using Company.WebAPI.Infrastructure.Mappers.Base;
using Company.WebAPI.ViewModels.ProductViewModels.ZipZipProductViewModels;

namespace Company.WebAPI.Infrastructure.Mappers.ProductMappers;

public class ZipZipProductMapperConfig : BaseMapperConfig
{
    public ZipZipProductMapperConfig()
    {
        #region CreateMap ZipZipProductViewModel

        CreateMap<ZipZipProduct, ZipZipProductViewModel>()
            .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
            .ForMember(x => x.PropertyParserId, o => o.MapFrom(x => x.PropertyParserId))
            .ForMember(x => x.URL, o => o.MapFrom(x => x.URL))
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.Manufacturer, o => o.MapFrom(x => x.Manufacturer))
            .ForMember(x => x.Article, o => o.MapFrom(x => x.Article))
            .ForMember(x => x.Compatibility, o => o.MapFrom(x => x.Compatibility))
            .ForMember(x => x.Availability, o => o.MapFrom(x => x.Availability))
            .ForMember(x => x.AvailabilityType, o => o.MapFrom(x => x.AvailabilityType))
            .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
            .ForMember(x => x.OriginallyProduct, o => o.MapFrom(x => x.OriginallyProduct))
            .ForMember(x => x.Category, o => o.MapFrom(x => x.Category));

        CreateMap<ZipZipProductViewModel, ZipZipProduct>()
            .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
            .ForMember(x => x.PropertyParserId, o => o.MapFrom(x => x.PropertyParserId))
            .ForMember(x => x.URL, o => o.MapFrom(x => x.URL))
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.Manufacturer, o => o.MapFrom(x => x.Manufacturer))
            .ForMember(x => x.Article, o => o.MapFrom(x => x.Article))
            .ForMember(x => x.Compatibility, o => o.MapFrom(x => x.Compatibility))
            .ForMember(x => x.Availability, o => o.MapFrom(x => x.Availability))
            .ForMember(x => x.AvailabilityType, o => o.MapFrom(x => x.AvailabilityType))
            .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
            .ForMember(x => x.OriginallyProduct, o => o.MapFrom(x => x.OriginallyProduct))
            .ForMember(x => x.Category, o => o.MapFrom(x => x.Category))
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore());

        #endregion

        #region CreateMap CreateZipZipProductViewModel

        CreateMap<ZipZipProduct, CreateZipZipProductViewModel>()
            .ForMember(x => x.PropertyParserId, o => o.MapFrom(x => x.PropertyParserId))
            .ForMember(x => x.URL, o => o.MapFrom(x => x.URL))
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.Manufacturer, o => o.MapFrom(x => x.Manufacturer))
            .ForMember(x => x.Article, o => o.MapFrom(x => x.Article))
            .ForMember(x => x.Compatibility, o => o.MapFrom(x => x.Compatibility))
            .ForMember(x => x.Availability, o => o.MapFrom(x => x.Availability))
            .ForMember(x => x.AvailabilityType, o => o.MapFrom(x => x.AvailabilityType))
            .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
            .ForMember(x => x.OriginallyProduct, o => o.MapFrom(x => x.OriginallyProduct))
            .ForMember(x => x.Category, o => o.MapFrom(x => x.Category));

        CreateMap<CreateZipZipProductViewModel, ZipZipProduct>()
            .ForMember(x => x.PropertyParserId, o => o.MapFrom(x => x.PropertyParserId))
            .ForMember(x => x.URL, o => o.MapFrom(x => x.URL))
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.Manufacturer, o => o.MapFrom(x => x.Manufacturer))
            .ForMember(x => x.Article, o => o.MapFrom(x => x.Article))
            .ForMember(x => x.Compatibility, o => o.MapFrom(x => x.Compatibility))
            .ForMember(x => x.Availability, o => o.MapFrom(x => x.Availability))
            .ForMember(x => x.AvailabilityType, o => o.MapFrom(x => x.AvailabilityType))
            .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
            .ForMember(x => x.OriginallyProduct, o => o.MapFrom(x => x.OriginallyProduct))
            .ForMember(x => x.Category, o => o.MapFrom(x => x.Category))
            .ForMember(x => x.Id, o => o.Ignore())
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore());

        #endregion

        #region CreateMap UpdateZipZipProductViewModel

        CreateMap<ZipZipProduct, UpdateZipZipProductViewModel>()
            .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
            .ForMember(x => x.PropertyParserId, o => o.MapFrom(x => x.PropertyParserId))
            .ForMember(x => x.URL, o => o.MapFrom(x => x.URL))
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.Manufacturer, o => o.MapFrom(x => x.Manufacturer))
            .ForMember(x => x.Article, o => o.MapFrom(x => x.Article))
            .ForMember(x => x.Compatibility, o => o.MapFrom(x => x.Compatibility))
            .ForMember(x => x.Availability, o => o.MapFrom(x => x.Availability))
            .ForMember(x => x.AvailabilityType, o => o.MapFrom(x => x.AvailabilityType))
            .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
            .ForMember(x => x.OriginallyProduct, o => o.MapFrom(x => x.OriginallyProduct))
            .ForMember(x => x.Category, o => o.MapFrom(x => x.Category));

        CreateMap<UpdateZipZipProductViewModel, ZipZipProduct>()
            .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
            .ForMember(x => x.PropertyParserId, o => o.MapFrom(x => x.PropertyParserId))
            .ForMember(x => x.URL, o => o.MapFrom(x => x.URL))
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.Manufacturer, o => o.MapFrom(x => x.Manufacturer))
            .ForMember(x => x.Article, o => o.MapFrom(x => x.Article))
            .ForMember(x => x.Compatibility, o => o.MapFrom(x => x.Compatibility))
            .ForMember(x => x.Availability, o => o.MapFrom(x => x.Availability))
            .ForMember(x => x.AvailabilityType, o => o.MapFrom(x => x.AvailabilityType))
            .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
            .ForMember(x => x.OriginallyProduct, o => o.MapFrom(x => x.OriginallyProduct))
            .ForMember(x => x.Category, o => o.MapFrom(x => x.Category))
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore());

        #endregion
    }
}