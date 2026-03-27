using Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_MSSQL;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
    public DbSet<Customer> Customers => Set<Customer>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        modelBuilder.Entity<ProductCategory>().HasData(
            new { Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), Name = "iPhone", Description = "Think different. Think iPhone." },
            new { Id = Guid.Parse("b2c3d4e5-f6a7-8901-bcde-f12345678901"), Name = "Mac", Description = "Do more. Much more." },
            new { Id = Guid.Parse("c3d4e5f6-a7b8-9012-cdef-123456789012"), Name = "AirPods", Description = "Sound that moves with you." },
            new { Id = Guid.Parse("d4e5f6a7-b8c9-0123-defa-234567890123"), Name = "iPad", Description = "Thin. Powerful. Endless." }
        );
    }
}