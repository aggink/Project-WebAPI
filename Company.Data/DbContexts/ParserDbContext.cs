using Company.Data.Base;
using Company.Data.DbModelConfigs.ParserConfigs;
using Company.Entity.Parser;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Company.Data.DbContexts
{
    public class ParserDbContext : DbContextBase
    {
        public ParserDbContext(DbContextOptions<ParserDbContext> options)
           : base(options) { }

        public DbSet<PropertyParser> PropertyParser { get; set; } = null!;
        public DbSet<FieldParser> FieldParser { get; set; } = null!;
        public DbSet<WorkParser> WorkParser { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly(),
                x => x.GetInterfaces()
                    .Any(i => i == typeof(IParserConfig)));
            base.OnModelCreating(modelBuilder);
        }
    }
}
