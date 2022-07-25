using Company.Entity.Products;
using Company.WebAPI.Infrastructure.Mappers.Base;
using Company.WebAPI.ViewModels.ProductViewModels.ChipCartProductViewModels;

namespace Company.WebAPI.Infrastructure.Mappers.ProductMappers;

public class ChipCartProductMapperConfig : BaseMapperConfig
{
    public ChipCartProductMapperConfig()
    {
        #region CreateMap ChipCartProductViewModel

        CreateMap<ChipCartProduct, ChipCartProductViewModel>()
            .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
            .ForMember(x => x.PropertyParserId, o => o.MapFrom(x => x.PropertyParserId))
            .ForMember(x => x.URL, o => o.MapFrom(x => x.URL))
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.Manufacturer, o => o.MapFrom(x => x.Manufacturer))
            .ForMember(x => x.Article, o => o.MapFrom(x => x.Article))
            .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
            .ForMember(x => x.Availability, o => o.MapFrom(x => x.Availability))
            .ForMember(x => x.AvailabilityType, o => o.MapFrom(x => x.AvailabilityType))
            .ForMember(x => x.Weight, o => o.MapFrom(x => x.Weight))
            .ForMember(x => x.Vendor, o => o.MapFrom(x => x.Vendor))
            .ForMember(x => x.CodeProduct, o => o.MapFrom(x => x.CodeProduct))
            .ForMember(x => x.Description, o => o.MapFrom(x => x.Description))
            .ForMember(x => x.Color, o => o.MapFrom(x => x.Color))
            .ForMember(x => x.PrinterCompatibility, o => o.MapFrom(x => x.PrinterCompatibility))
            .ForMember(x => x.CartridgeCompatibility, o => o.MapFrom(x => x.CartridgeCompatibility))
            .ForMember(x => x.TypeProduct, o => o.MapFrom(x => x.TypeProduct));

        CreateMap<ChipCartProductViewModel, ChipCartProduct>()
            .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
            .ForMember(x => x.PropertyParserId, o => o.MapFrom(x => x.PropertyParserId))
            .ForMember(x => x.URL, o => o.MapFrom(x => x.URL))
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.Manufacturer, o => o.MapFrom(x => x.Manufacturer))
            .ForMember(x => x.Article, o => o.MapFrom(x => x.Article))
            .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
            .ForMember(x => x.Availability, o => o.MapFrom(x => x.Availability))
            .ForMember(x => x.AvailabilityType, o => o.MapFrom(x => x.AvailabilityType))
            .ForMember(x => x.Weight, o => o.MapFrom(x => x.Weight))
            .ForMember(x => x.Vendor, o => o.MapFrom(x => x.Vendor))
            .ForMember(x => x.CodeProduct, o => o.MapFrom(x => x.CodeProduct))
            .ForMember(x => x.Description, o => o.MapFrom(x => x.Description))
            .ForMember(x => x.Color, o => o.MapFrom(x => x.Color))
            .ForMember(x => x.PrinterCompatibility, o => o.MapFrom(x => x.PrinterCompatibility))
            .ForMember(x => x.CartridgeCompatibility, o => o.MapFrom(x => x.CartridgeCompatibility))
            .ForMember(x => x.TypeProduct, o => o.MapFrom(x => x.TypeProduct))
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore());

        #endregion

        #region CreateMap CreateChipCartProductViewModel

        CreateMap<ChipCartProduct, CreateChipCartProductViewModel>()
            .ForMember(x => x.PropertyParserId, o => o.MapFrom(x => x.PropertyParserId))
            .ForMember(x => x.URL, o => o.MapFrom(x => x.URL))
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.Manufacturer, o => o.MapFrom(x => x.Manufacturer))
            .ForMember(x => x.Article, o => o.MapFrom(x => x.Article))
            .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
            .ForMember(x => x.Availability, o => o.MapFrom(x => x.Availability))
            .ForMember(x => x.AvailabilityType, o => o.MapFrom(x => x.AvailabilityType))
            .ForMember(x => x.Weight, o => o.MapFrom(x => x.Weight))
            .ForMember(x => x.Vendor, o => o.MapFrom(x => x.Vendor))
            .ForMember(x => x.CodeProduct, o => o.MapFrom(x => x.CodeProduct))
            .ForMember(x => x.Description, o => o.MapFrom(x => x.Description))
            .ForMember(x => x.Color, o => o.MapFrom(x => x.Color))
            .ForMember(x => x.PrinterCompatibility, o => o.MapFrom(x => x.PrinterCompatibility))
            .ForMember(x => x.CartridgeCompatibility, o => o.MapFrom(x => x.CartridgeCompatibility))
            .ForMember(x => x.TypeProduct, o => o.MapFrom(x => x.TypeProduct));

        CreateMap<CreateChipCartProductViewModel, ChipCartProduct>()
            .ForMember(x => x.PropertyParserId, o => o.MapFrom(x => x.PropertyParserId))
            .ForMember(x => x.URL, o => o.MapFrom(x => x.URL))
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.Manufacturer, o => o.MapFrom(x => x.Manufacturer))
            .ForMember(x => x.Article, o => o.MapFrom(x => x.Article))
            .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
            .ForMember(x => x.Availability, o => o.MapFrom(x => x.Availability))
            .ForMember(x => x.AvailabilityType, o => o.MapFrom(x => x.AvailabilityType))
            .ForMember(x => x.Weight, o => o.MapFrom(x => x.Weight))
            .ForMember(x => x.Vendor, o => o.MapFrom(x => x.Vendor))
            .ForMember(x => x.CodeProduct, o => o.MapFrom(x => x.CodeProduct))
            .ForMember(x => x.Description, o => o.MapFrom(x => x.Description))
            .ForMember(x => x.Color, o => o.MapFrom(x => x.Color))
            .ForMember(x => x.PrinterCompatibility, o => o.MapFrom(x => x.PrinterCompatibility))
            .ForMember(x => x.CartridgeCompatibility, o => o.MapFrom(x => x.CartridgeCompatibility))
            .ForMember(x => x.TypeProduct, o => o.MapFrom(x => x.TypeProduct))
            .ForMember(x => x.Id, o => o.Ignore())
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore());

        #endregion

        #region CreateMap UpdateChipCartProductViewModel

        CreateMap<ChipCartProduct, UpdateChipCartProductViewModel>()
            .ForMember(x => x.PropertyParserId, o => o.MapFrom(x => x.PropertyParserId))
            .ForMember(x => x.URL, o => o.MapFrom(x => x.URL))
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.Manufacturer, o => o.MapFrom(x => x.Manufacturer))
            .ForMember(x => x.Article, o => o.MapFrom(x => x.Article))
            .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
            .ForMember(x => x.Availability, o => o.MapFrom(x => x.Availability))
            .ForMember(x => x.AvailabilityType, o => o.MapFrom(x => x.AvailabilityType))
            .ForMember(x => x.Weight, o => o.MapFrom(x => x.Weight))
            .ForMember(x => x.Vendor, o => o.MapFrom(x => x.Vendor))
            .ForMember(x => x.CodeProduct, o => o.MapFrom(x => x.CodeProduct))
            .ForMember(x => x.Description, o => o.MapFrom(x => x.Description))
            .ForMember(x => x.Color, o => o.MapFrom(x => x.Color))
            .ForMember(x => x.PrinterCompatibility, o => o.MapFrom(x => x.PrinterCompatibility))
            .ForMember(x => x.CartridgeCompatibility, o => o.MapFrom(x => x.CartridgeCompatibility))
            .ForMember(x => x.TypeProduct, o => o.MapFrom(x => x.TypeProduct));

        CreateMap<UpdateChipCartProductViewModel, ChipCartProduct>()
            .ForMember(x => x.PropertyParserId, o => o.MapFrom(x => x.PropertyParserId))
            .ForMember(x => x.URL, o => o.MapFrom(x => x.URL))
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.Manufacturer, o => o.MapFrom(x => x.Manufacturer))
            .ForMember(x => x.Article, o => o.MapFrom(x => x.Article))
            .ForMember(x => x.Price, o => o.MapFrom(x => x.Price))
            .ForMember(x => x.Availability, o => o.MapFrom(x => x.Availability))
            .ForMember(x => x.AvailabilityType, o => o.MapFrom(x => x.AvailabilityType))
            .ForMember(x => x.Weight, o => o.MapFrom(x => x.Weight))
            .ForMember(x => x.Vendor, o => o.MapFrom(x => x.Vendor))
            .ForMember(x => x.CodeProduct, o => o.MapFrom(x => x.CodeProduct))
            .ForMember(x => x.Description, o => o.MapFrom(x => x.Description))
            .ForMember(x => x.Color, o => o.MapFrom(x => x.Color))
            .ForMember(x => x.PrinterCompatibility, o => o.MapFrom(x => x.PrinterCompatibility))
            .ForMember(x => x.CartridgeCompatibility, o => o.MapFrom(x => x.CartridgeCompatibility))
            .ForMember(x => x.TypeProduct, o => o.MapFrom(x => x.TypeProduct))
            .ForMember(x => x.Id, o => o.Ignore())
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore());

        #endregion
    }
}