using Company.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Company.Data.FactoryDbContext
{
    public class ParserFactoryDbContext : IDesignTimeDbContextFactory<ParserDbContext>
    {
        private const string ParserDbConnection = "Server=localhost,1433;Database=Company_ParserDb;User ID=sa;Password=H5YKO3qb45ClEvV0eqWY;MultipleActiveResultSets=true";
        public ParserDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ParserDbContext>();
            optionsBuilder.UseSqlServer(ParserDbConnection);

            return new ParserDbContext(optionsBuilder.Options);
        }
    }
}
