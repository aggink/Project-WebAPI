using Calabonga.UnitOfWork;
using Company.Data.DbContexts;
using Company.Entity.Products;
using Company.WebAPI.Infrastructure.Repositories.Base;

namespace Company.WebAPI.Infrastructure.Repositories.ProductRepository;

public class RamisRepository : BaseRepository<ProductDbContext, RamisProduct>
{
    public RamisRepository(
        IUnitOfWork<ProductDbContext> unitOfWork, 
        ILogger<BaseRepository<ProductDbContext, RamisProduct>> logger) 
        : base(unitOfWork, logger)
    {
    }

    protected override RamisProduct CreateEntity(RamisProduct inputEntity)
    {
        return new RamisProduct()
        {
            Id = Guid.NewGuid(),
            PropertyParserId = inputEntity.PropertyParserId,
            URL = inputEntity.URL,
            Name = inputEntity.Name,
            Manufacturer = inputEntity.Manufacturer,
            Article = inputEntity.Article,
            Weight = inputEntity.Weight,
            Vendor = inputEntity.Vendor,
            CodeProduct = inputEntity.CodeProduct,
            Description = inputEntity.Description,
            Price = inputEntity.Price,
            Availability = inputEntity.Availability,
            AvailabilityType = inputEntity.AvailabilityType,
            Color = inputEntity.Color,
            PrinterCompatibility = inputEntity.PrinterCompatibility,
            CartridgeCompatibility = inputEntity.CartridgeCompatibility,
            QuantityPackage = inputEntity.QuantityPackage,
            TrademarkAndPN = inputEntity.TrademarkAndPN
        };
    }

    protected override async Task<RamisProduct?> DeleteEntityAsync(Guid id)
    {
        return await _repository.GetFirstOrDefaultAsync(
            predicate: x => x.Id == id);
    }

    protected override RamisProduct UpdateEntity(RamisProduct entity, RamisProduct inputEntity)
    {
        entity.UpdatedBy = inputEntity.UpdatedBy;
        entity.URL = inputEntity.URL;
        entity.Name = inputEntity.Name;
        entity.Manufacturer = inputEntity.Manufacturer;
        entity.Article = inputEntity.Article;
        entity.Weight = inputEntity.Weight;
        entity.Vendor = inputEntity.Vendor;
        entity.CodeProduct = inputEntity.CodeProduct;
        entity.Description = inputEntity.Description;
        entity.Price = inputEntity.Price;
        entity.Availability = inputEntity.Availability;
        entity.AvailabilityType = inputEntity.AvailabilityType;
        entity.Color = inputEntity.Color;
        entity.PrinterCompatibility = inputEntity.PrinterCompatibility;
        entity.CartridgeCompatibility = inputEntity.CartridgeCompatibility;
        entity.QuantityPackage = inputEntity.QuantityPackage;
        entity.TrademarkAndPN = inputEntity.TrademarkAndPN;

        return entity;
    }
}
