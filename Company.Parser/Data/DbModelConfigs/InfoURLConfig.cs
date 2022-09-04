using Company.Base.DbModelConfigs;
using Company.Parser.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Parser.Data.DbModelConfigs;

public class InfoURLConfig : AuditableModelConfig<InfoURL>, IParserModelConfig
{
    protected override void AddBuilder(EntityTypeBuilder<InfoURL> builder)
    {
        builder.Property(x => x.ParserId).IsRequired();
        builder.Property(x => x.Url).IsRequired();
        builder.Property(x => x.HasBeenProcessed).IsRequired();
        builder.Property(x => x.IsSuccess).IsRequired();

        builder.HasOne(x => x.Parser).WithMany().HasForeignKey(x => x.ParserId);
    }

    protected override string SetTableName()
    {
        return "InfoURL";
    }
}