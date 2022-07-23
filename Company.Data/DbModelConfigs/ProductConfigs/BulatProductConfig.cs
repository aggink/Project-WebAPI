using Company.Data.DbModelConfigs.Base;
using Company.Entity.Products;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Data.DbModelConfigs.ProductConfigs;

public class BulatProductConfig : AuditableModelConfig<BulatProduct>, IProductConfig
{
    protected override void AddBuilder(EntityTypeBuilder<BulatProduct> builder)
    {
        builder.Property(x => x.Price).HasPrecision(38, 18);
        builder.Property(x => x.PriceFrom5).HasPrecision(38, 18);
        builder.Property(x => x.PriceFrom10).HasPrecision(38, 18);
    }

    protected override string TableName()
    {
        return "BulatProduct";
    }
}
