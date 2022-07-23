using Calabonga.UnitOfWork;
using Company.Data.DbContexts;
using Company.Entity.Products;
using Company.WebAPI.Infrastructure.Repositories.Base;

namespace Company.WebAPI.Infrastructure.Repositories.ProductRepository;

public class ZipZipRepository : BaseRepository<ProductDbContext, ZipZipProduct>
{
    public ZipZipRepository(
        IUnitOfWork<ProductDbContext> unitOfWork, 
        ILogger<BaseRepository<ProductDbContext, ZipZipProduct>> logger) 
        : base(unitOfWork, logger)
    {
    }

    protected override ZipZipProduct CreateEntity(ZipZipProduct inputEntity)
    {
        return new ZipZipProduct()
        {
            Id = Guid.NewGuid(),
            PropertyParserId = inputEntity.PropertyParserId,
            Name = inputEntity.Name,
            Manufacturer = inputEntity.Manufacturer,
            Article = inputEntity.Article,
            Compatibility = inputEntity.Compatibility,
            Availability = inputEntity.Availability,
            AvailabilityType = inputEntity.AvailabilityType,
            Price = inputEntity.Price,
            OriginallyProduct = inputEntity.OriginallyProduct,
            Category = inputEntity.Category
        };
    }

    protected override async Task<ZipZipProduct?> DeleteEntityAsync(Guid id)
    {
        return await _repository.GetFirstOrDefaultAsync(
            predicate: x => x.Id == id);
    }

    protected override ZipZipProduct UpdateEntity(ZipZipProduct entity, ZipZipProduct inputEntity)
    {
        entity.Name = inputEntity.Name;
        entity.Manufacturer = inputEntity.Manufacturer;
        entity.Article = inputEntity.Article;
        entity.Compatibility = inputEntity.Compatibility;
        entity.Availability = inputEntity.Availability;
        entity.AvailabilityType = inputEntity.AvailabilityType;
        entity.Price = inputEntity.Price;
        entity.OriginallyProduct = inputEntity.OriginallyProduct;
        entity.Category = inputEntity.Category;

        return entity;
    }
}
