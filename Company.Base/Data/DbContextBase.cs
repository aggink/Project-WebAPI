﻿using Calabonga.UnitOfWork;
using Company.Base.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company.Base.Data;

/// <summary>
/// Базовый класс для работы с базой данных
/// </summary>
public class DbContextBase : DbContext
{
    public SaveChangesResult SaveChangesResult { get; set; }

    protected DbContextBase(DbContextOptions options) : base(options)
    {
        SaveChangesResult = new SaveChangesResult();
    }

    public override int SaveChanges()
    {
        DbSaveChanges();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        DbSaveChanges();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        DbSaveChanges();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new())
    {
        DbSaveChanges();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    /// <summary>
    /// Сохранение изменений
    /// </summary>
    protected virtual void DbSaveChanges()
    {
        const string defaultUser = "admin";
        var defaultDate = DateTime.UtcNow;

        #region AddedEntities

        var addedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added);
        foreach (var entity in addedEntities)
        {
            if (entity.Entity is not IAuditable) continue;
            
            var id = entity.Property(nameof(IAuditable.Id)).CurrentValue;
            var createdBy = entity.Property(nameof(IAuditable.CreatedBy)).CurrentValue;
            var createdAt = entity.Property(nameof(IAuditable.CreatedAt)).CurrentValue;
            var updateBy = entity.Property(nameof(IAuditable.UpdatedBy)).CurrentValue;
            var updateAt = entity.Property(nameof(IAuditable.UpdatedAt)).CurrentValue;
            
            if((Guid)id! == Guid.Empty)
                entity.Property(nameof(Guid)).CurrentValue = Guid.NewGuid();

            if (string.IsNullOrEmpty(createdBy?.ToString()))
                entity.Property(nameof(IAuditable.CreatedBy)).CurrentValue = defaultUser;

            if (DateTime.Parse(createdAt?.ToString()!).Year < 1970)
                entity.Property(nameof(IAuditable.CreatedAt)).CurrentValue = defaultDate;

            if (string.IsNullOrEmpty(updateBy?.ToString()))
                entity.Property(nameof(IAuditable.UpdatedBy)).CurrentValue = defaultUser;

            if (DateTime.Parse(updateAt?.ToString()!).Year < 1970)
                entity.Property(nameof(IAuditable.UpdatedAt)).CurrentValue = defaultDate;

            SaveChangesResult.AddMessage("Some entities were created");
        }

        #endregion

        #region ModifiedEntities

        var modifiedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
        foreach (var entity in modifiedEntities)
        {
            if (entity.Entity is not IAuditable) continue;

            var userName = entity.Property(nameof(IAuditable.UpdatedBy)).CurrentValue is null
                ? defaultUser
                : entity.Property(nameof(IAuditable.UpdatedBy)).CurrentValue;

            entity.Property(nameof(IAuditable.UpdatedAt)).CurrentValue = defaultDate;
            entity.Property(nameof(IAuditable.UpdatedBy)).CurrentValue = userName;

            SaveChangesResult.AddMessage("Some entities were modified");
        }
        #endregion
    }
}
