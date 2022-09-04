using Company.Base.DbModelConfigs;
using Company.Parser.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Parser.Data.DbModelConfigs;

public class ConfigurationParserConfig : AuditableModelConfig<ConfigurationParser>, IParserModelConfig
{
    protected sealed override void AddBuilder(EntityTypeBuilder<ConfigurationParser> builder)
    {
        builder.Property(x => x.ParserId).IsRequired();
        builder.Property(x => x.URL).IsRequired();
        builder.Property(x => x.SiteName).IsRequired();
        builder.Property(x => x.CompanyName).IsRequired();
        builder.Property(x => x.CompanyDescription).IsRequired();

        builder.HasOne(x => x.Parser).WithMany().HasForeignKey(x => x.ParserId);
        builder.HasMany(x => x.Fields).WithOne().HasForeignKey(x => x.ConfigurationId);
    }

    protected override string SetTableName()
    {
        return "Configurations";
    }
}