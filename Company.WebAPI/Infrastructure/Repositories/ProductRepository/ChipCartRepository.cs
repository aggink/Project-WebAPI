using Calabonga.UnitOfWork;
using Company.Data.DbContexts;
using Company.Entity.Products;
using Company.WebAPI.Infrastructure.Repositories.Base;

namespace Company.WebAPI.Infrastructure.Repositories.ProductRepository;

public class ChipCartRepository : BaseRepository<ProductDbContext, ChipCartProduct>
{
    public ChipCartRepository(
        IUnitOfWork<ProductDbContext> unitOfWork, 
        ILogger<BaseRepository<ProductDbContext, ChipCartProduct>> logger) 
        : base(unitOfWork, logger)
    {
    }

    protected override ChipCartProduct CreateEntity(ChipCartProduct inputEntity)
    {
        return new ChipCartProduct()
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
            TypeProduct = inputEntity.TypeProduct
        };
    }

    protected override async Task<ChipCartProduct?> DeleteEntityAsync(Guid id)
    {
        return await _repository.GetFirstOrDefaultAsync(
            predicate: x => x.Id == id);
    }

    protected override ChipCartProduct UpdateEntity(ChipCartProduct entity, ChipCartProduct inputEntity)
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
        entity.TypeProduct = inputEntity.TypeProduct;

        return entity;
    }
}
