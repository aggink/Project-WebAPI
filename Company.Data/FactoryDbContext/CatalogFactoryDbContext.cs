using Company.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Company.Data.FactoryDbContext;

/// <summary>
/// Создание базы данных
/// </summary>
public class CatalogFactoryDbContext : IDesignTimeDbContextFactory<CatalogDbContext>
{
    private const string ParserDbConnection = "Server=localhost,1433;Database=Company_CatalogDb;User ID=sa;Password=H5YKO3qb45ClEvV0eqWY;MultipleActiveResultSets=true";

    public CatalogDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CatalogDbContext>();
        optionsBuilder.UseSqlServer(ParserDbConnection);

        return new CatalogDbContext(optionsBuilder.Options);
    }
}