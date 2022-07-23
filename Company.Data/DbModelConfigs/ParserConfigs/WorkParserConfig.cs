using Company.Data.DbModelConfigs.Base;
using Company.Entity.Parser;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Data.DbModelConfigs.ParserConfigs;

public class WorkParserConfig : AuditableModelConfig<WorkParser>, IParserConfig
{
    protected override void AddBuilder(EntityTypeBuilder<WorkParser> builder)
    {
        builder.Property(x => x.PropertyParserId).IsRequired();
        builder.Property(x => x.StartTime).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc)).IsRequired();
        builder.Property(x => x.CompletionTime).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc)).IsRequired();
    }

    protected override string TableName()
    {
        return "WorkParser";
    }
}
