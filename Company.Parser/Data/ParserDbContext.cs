using Company.Base.Data;
using Company.Parser.Entities;
using Company.Parser.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Company.Parser.Data;

public class ParserDbContext : DbContextBase
{
    public ParserDbContext(DbContextOptions options)
        : base(options) { }

    public DbSet<InfoParser> InfoParsers { get; set; } = null!;
    public DbSet<ConfigurationParser> ConfigurationParsers { get; set; } = null!;
    public DbSet<FieldConfiguration> FieldConfigurations { get; set; } = null!;
    public DbSet<InfoURL> URLs { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly(),
            x => x.GetInterfaces()
                .Any(i => i == typeof(IParser)));
        base.OnModelCreating(modelBuilder);
    }
}