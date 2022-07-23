using Company.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Company.Data.FactoryDbContext;

public class ProductFactoryDbContext : IDesignTimeDbContextFactory<ProductDbContext>
{
    private const string ParserDbConnection = "Server=localhost,1433;Database=Company_ProductDb;User ID=sa;Password=H5YKO3qb45ClEvV0eqWY;MultipleActiveResultSets=true";
    public ProductDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ProductDbContext>();
        optionsBuilder.UseSqlServer(ParserDbConnection);

        return new ProductDbContext(optionsBuilder.Options);
    }
}
