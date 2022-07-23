using Company.Data.DbModelConfigs.Base;
using Company.Entity.Parser;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Data.DbModelConfigs.ParserConfigs
{
    public class FieldParserConfig : AuditableModelConfig<FieldParser>, IParserConfig
    {
        protected override void AddBuilder(EntityTypeBuilder<FieldParser> builder)
        {
            builder.Property(x => x.PropertyParserId).IsRequired();
            builder.Property(x => x.PropertyName).IsRequired();
            builder.Property(x => x.DefaultValue).IsRequired();
        }

        protected override string TableName()
        {
            return "FieldParser";
        }
    }
}
