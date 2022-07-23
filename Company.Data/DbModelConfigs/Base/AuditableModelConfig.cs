using Company.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Data.DbModelConfigs.Base
{
    /// <summary>
    /// Добавление конфигураций к базовым полям
    /// </summary>
    /// <typeparam name="TConfig"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract class AuditableModelConfig<TConfig> : IEntityTypeConfiguration<TConfig> where TConfig : Auditable
    {
        public void Configure(EntityTypeBuilder<TConfig> builder)
        {
            builder.ToTable(TableName());
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.CreatedAt).IsRequired().HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc)).IsRequired();
            builder.Property(x => x.CreatedBy).HasMaxLength(256).IsRequired();
            builder.Property(x => x.UpdatedAt).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc)).IsRequired();
            builder.Property(x => x.UpdatedBy).HasMaxLength(256);

            AddBuilder(builder);
        }

        protected abstract void AddBuilder(EntityTypeBuilder<TConfig> builder);

        protected abstract string TableName();
    }
}
