using Company.Base.DbModelConfigs;
using Company.Parser.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Parser.Data.DbModelConfigs;

public class FieldConfigurationConfig : AuditableModelConfig<FieldConfiguration>, IParserModelConfig
{
    protected sealed override void AddBuilder(EntityTypeBuilder<FieldConfiguration> builder)
    {
        builder.Property(x => x.ConfigurationId).IsRequired();
        builder.Property(x => x.PropertyName).IsRequired();
        builder.Property(x => x.Description).IsRequired();

        builder.HasOne(x => x.Configuration).WithMany(y => y.Fields).HasForeignKey(y => y.ConfigurationId);
    }

    protected override string SetTableName()
    {
        return "Fields";
    }
}