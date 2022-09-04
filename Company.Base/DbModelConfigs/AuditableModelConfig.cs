using Company.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Base.DbModelConfigs;

/// <summary>
/// Добавление конфигураций к базовым полям
/// </summary>
/// <typeparam name="TConfig">Сущность</typeparam>
public abstract class AuditableModelConfig<TConfig> : IEntityTypeConfiguration<TConfig> 
    where TConfig : Auditable
{
    /// <summary>
    /// Настройка сущнсоти
    /// </summary>
    /// <param name="builder">Внутренний API, который поддерживает инфраструктуру Entity Framework.</param>
    public void Configure(EntityTypeBuilder<TConfig> builder)
    {
        builder.ToTable(SetTableName());
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();

        builder.Property(x => x.CreatedAt).IsRequired().HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc)).IsRequired();
        builder.Property(x => x.CreatedBy).HasMaxLength(256).IsRequired();
        builder.Property(x => x.UpdatedAt).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc)).IsRequired();
        builder.Property(x => x.UpdatedBy).HasMaxLength(256);

        AddBuilder(builder);
    }

    /// <summary>
    /// Добавить дополнительные настройки сущности
    /// </summary>
    /// <param name="builder">Внутренний API, который поддерживает инфраструктуру Entity Framework.</param>
    protected abstract void AddBuilder(EntityTypeBuilder<TConfig> builder);

    /// <summary>
    /// Установить наименование таблицы
    /// </summary>
    /// <returns>Наименование таблицы</returns>
    protected abstract string SetTableName();
}