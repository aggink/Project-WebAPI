using Company.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Data.DbInitializers;

/// <summary>
/// Инициализация БД
/// </summary>
public class DbInitializer
{
    /// <summary>
    /// Инициализаци БД начальными параметрами
    /// </summary>
    /// <param name="serviceProvider">Специальный контракт для коллекции дескрипторов служб.</param>
    /// <returns></returns>
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var scope = serviceProvider.CreateScope();

        //проверка на существование БД

        #region ProductDb

        await using var productDbContext = scope.ServiceProvider.GetService<CatalogDbContext>();
        var product_IsExists = productDbContext!.GetService<IDatabaseCreator>() is RelationalDatabaseCreator productDbCreator && await productDbCreator.ExistsAsync();
        if (!product_IsExists)
        {
            await productDbContext!.Database.MigrateAsync();
            await productDbContext!.SaveChangesAsync();
        }

        #endregion
    }
}
