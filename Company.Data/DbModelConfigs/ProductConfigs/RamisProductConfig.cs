using Company.Data.DbModelConfigs.Base;
using Company.Entity.Products;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Data.DbModelConfigs.ProductConfigs;

public class RamisProductConfig : AuditableModelConfig<RamisProduct>, IProductConfig
{
    protected override void AddBuilder(EntityTypeBuilder<RamisProduct> builder)
    {
        builder.Property(x => x.Price).HasPrecision(38, 18);
    }

    protected override string TableName()
    {
        return "RamisProduct";
    }
}
