using Company.Base.DbModelConfigs;
using Company.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Data.DbModelConfigs;

public class ParseValuesProductConfig : AuditableModelConfig<ParseValuesProduct>, ICatalogModelConfig
{
    protected override void AddBuilder(EntityTypeBuilder<ParseValuesProduct> builder)
    {
        builder.Property(x => x.InfoURLId).IsRequired();
        builder.Property(x => x.Name).IsRequired(false);
        builder.Property(x => x.Description).IsRequired(false);
        builder.Property(x => x.Text).IsRequired(false);
        builder.Property(x => x.Price).IsRequired(false);
        builder.Property(x => x.Price5).IsRequired(false);
        builder.Property(x => x.Price10).IsRequired(false);
        builder.Property(x => x.AvailabilityProductOffice).IsRequired(false);
        builder.Property(x => x.AvailabilityProductStock).IsRequired(false);

        builder.HasOne(x => x.InfoURL).WithMany().HasForeignKey(x => x.InfoURLId).OnDelete(DeleteBehavior.SetNull);
    }

    protected override string SetTableName()
    {
        return "ParseValuesProduct";
    }
}