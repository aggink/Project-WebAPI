using Company.Base.DbModelConfigs;
using Company.Parser.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Parser.Data.DbModelConfigs;

public class InfoParserConfig : AuditableModelConfig<InfoParser>, IParserModelConfig
{
    protected sealed override void AddBuilder(EntityTypeBuilder<InfoParser> builder)
    {
        builder.Property(x => x.IsStart).IsRequired();
        builder.Property(x => x.IsStartUpdate).IsRequired();
        builder.Property(x => x.IsQueue).IsRequired();
        builder.Property(x => x.IsCompleted).IsRequired();
        builder.Property(x => x.StartTime).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc)).IsRequired();
        builder.Property(x => x.CompletionTime).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc)).IsRequired();

        builder.HasMany(c => c.Configurations).WithOne(s => s.Parser).HasForeignKey(x => x.ParserId);
    }

    protected override string SetTableName()
    {
        return "Parser";
    }
}