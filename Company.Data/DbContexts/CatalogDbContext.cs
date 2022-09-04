using Company.Data.DbModelConfigs;
using Company.Entity;
using Company.Parser.Data;
using Company.Parser.Data.DbModelConfigs;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Company.Data.DbContexts;

public class CatalogDbContext : ParserDbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
       : base(options) { }

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<ParseValuesProduct> ParseValuesProducts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly(),
            x => x.GetInterfaces()
                .Any(i => i == typeof(ICatalogModelConfig) || i == typeof(IParserModelConfig)));
        base.OnModelCreating(modelBuilder);
    }
}
