using Company.Data.Base;
using Company.Data.DbModelConfigs.ProductConfigs;
using Company.Entity.Products;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Company.Data.DbContexts;

public class ProductDbContext : DbContextBase
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options)
       : base(options) { }

    public DbSet<BulatProduct> BulatProduct{ get; set; } = null!;
    public DbSet<RamisProduct> RamisProduct { get; set; } = null!;
    public DbSet<ZipZipProduct> ZipZipProduct { get; set; } = null!;
    public DbSet<ChipCartProduct> ChipCartProduct { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly(),
            x => x.GetInterfaces()
                .Any(i => i == typeof(IProductConfig)));
        base.OnModelCreating(modelBuilder);
    }
}
