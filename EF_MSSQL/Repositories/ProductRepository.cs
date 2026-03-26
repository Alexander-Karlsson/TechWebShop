using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace EF_MSSQL.Repositories;

public class ProductRepository(AppDbContext db) : IProductRepository
{
    public async Task<List<Product>> GetAllAsync() 
        => await db.Products.AsNoTracking().ToListAsync();
    public async Task<Product?> GetByIdAsync(Guid id) 
        => await db.Products.FindAsync(id);

    public async Task AddAsync(Product product)
    {
        await db.Products.AddAsync(product);
        await db.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(Product product)
    {
        db.Products.Update(product);
        await db.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var product = await db.Products.FindAsync(id);
        if (product is null) return false;
        
        db.Products.Remove(product);
        await db.SaveChangesAsync();
        return true;
    }
}