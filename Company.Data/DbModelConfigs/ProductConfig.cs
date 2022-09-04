using Company.Base.DbModelConfigs;
using Company.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Data.DbModelConfigs;

/// <summary>
/// Настройка таблицы в базе данных
/// </summary>
public class ProductConfig : AuditableModelConfig<Product>, ICatalogModelConfig
{
    protected override void AddBuilder(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.TextProductId).IsRequired();

        builder.Property(x => x.Price).HasPrecision(38, 18);
        builder.Property(x => x.PriceFrom5).HasPrecision(38, 18);
        builder.Property(x => x.PriceFrom10).HasPrecision(38, 18);

        builder.HasOne(x => x.ParseValuesProduct).WithOne().HasForeignKey<Product>(y => y.TextProductId);
    }

    protected override string SetTableName()
    {
        return "Product";
    }
}