using Company.Data.DbModelConfigs.Base;
using Company.Entity.Parser;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Data.DbModelConfigs.ParserConfigs
{
    public class PropertyParserConfig : AuditableModelConfig<PropertyParser>, IParserConfig
    {
        protected override void AddBuilder(EntityTypeBuilder<PropertyParser> builder)
        {
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.URL).IsRequired();
            builder.Property(x => x.NameSite).IsRequired();
            builder.Property(x => x.CompanyName).IsRequired();
            builder.Property(x => x.CompanyDescription).IsRequired();

            builder.HasMany(x => x.ParserParams);
        }

        protected override string TableName()
        {
            return "PropertyParser";
        }
    }
}
