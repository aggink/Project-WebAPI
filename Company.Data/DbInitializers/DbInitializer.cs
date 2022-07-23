using Company.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Data.DbInitializers
{
    /// <summary>
    /// Инициализация БД
    /// </summary>
    public class DbInitializer
    {
        /// <summary>
        /// Инициализаци БД начальными параметрами
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();

            //проверка на существование БД

            #region ParserDb

            await using var parserDbContext = scope.ServiceProvider.GetService<ParserDbContext>();
            var parser_IsExists = parserDbContext!.GetService<IDatabaseCreator>() is RelationalDatabaseCreator parserDbCreator && await parserDbCreator.ExistsAsync();
            if (!parser_IsExists)
            {
                await parserDbContext!.Database.MigrateAsync();
                await parserDbContext!.SaveChangesAsync();
            }

            #endregion

            #region ProductDb

            await using var productDbContext = scope.ServiceProvider.GetService<ProductDbContext>();
            var product_IsExists = productDbContext!.GetService<IDatabaseCreator>() is RelationalDatabaseCreator productDbCreator && await productDbCreator.ExistsAsync();
            if (!parser_IsExists)
            {
                await productDbContext!.Database.MigrateAsync();
                await productDbContext!.SaveChangesAsync();
            }

            #endregion
        }
    }
}
