using Domin.Entities.Product;
using Domin.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace InferStructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasMany(x => x.Products).WithOne(h => h.User).HasForeignKey(x => x.userId);
    }
}