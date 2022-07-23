using Calabonga.UnitOfWork;
using Company.Data.DbContexts;
using Company.Entity.Products;
using Company.WebAPI.Infrastructure.Repositories.Base;

namespace Company.WebAPI.Infrastructure.Repositories.ProductRepository;

public class BulatRepository : BaseRepository<ProductDbContext, BulatProduct>
{
    public BulatRepository(
        IUnitOfWork<ProductDbContext> unitOfWork, 
        ILogger<BaseRepository<ProductDbContext, BulatProduct>> logger) 
        : base(unitOfWork, logger)
    {
    }

    protected override BulatProduct CreateEntity(BulatProduct inputEntity)
    {
        return new BulatProduct()
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
            Compatibility = inputEntity.Compatibility,
            LengthWidthHeight = inputEntity.LengthWidthHeight,
            Model = inputEntity.Model,
            AnalogProduct = inputEntity.AnalogProduct,
            Resource = inputEntity.Resource,
            TypeEquipment = inputEntity.TypeEquipment,
            OriginallyProduct = inputEntity.OriginallyProduct,
            SeriesProduct = inputEntity.SeriesProduct,
            PriceFrom5 = inputEntity.PriceFrom5,
            PriceFrom10 = inputEntity.PriceFrom10
        };
    }

    protected override async Task<BulatProduct?> DeleteEntityAsync(Guid id)
    {
        return await _repository.GetFirstOrDefaultAsync(
            predicate: x => x.Id == id);
    }

    protected override BulatProduct UpdateEntity(BulatProduct entity, BulatProduct inputEntity)
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
        entity.Compatibility = inputEntity.Compatibility;
        entity.LengthWidthHeight = inputEntity.LengthWidthHeight;
        entity.Model = inputEntity.Model;
        entity.AnalogProduct = inputEntity.AnalogProduct;
        entity.Resource = inputEntity.Resource;
        entity.TypeEquipment = inputEntity.TypeEquipment;
        entity.OriginallyProduct = inputEntity.OriginallyProduct;
        entity.SeriesProduct = inputEntity.SeriesProduct;
        entity.PriceFrom5 = inputEntity.PriceFrom5;
        entity.PriceFrom10 = inputEntity.PriceFrom10;

        return entity;
    }
}
