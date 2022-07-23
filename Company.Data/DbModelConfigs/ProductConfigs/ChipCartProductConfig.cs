using Company.Data.DbModelConfigs.Base;
using Company.Entity.Products;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Data.DbModelConfigs.ProductConfigs;

public class ChipCartProductConfig : AuditableModelConfig<ChipCartProduct>, IProductConfig
{
    protected override void AddBuilder(EntityTypeBuilder<ChipCartProduct> builder)
    {
        builder.Property(x => x.Price).HasPrecision(38, 18);
    }

    protected override string TableName()
    {
        return "ChipCartProduct";
    }
}
