using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace EF_MSSQL.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<List<Product>> GetAllAsync() 
        => await context.Products.AsNoTracking().ToListAsync();
    public async Task<Product?> GetByIdAsync(Guid id) 
        => await context.Products.FindAsync(id);

    public async Task AddAsync(Product product)
    {
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(Product product)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var product = await context.Products.FindAsync(id);
        if (product is null)
            return false;
        
        context.Products.Remove(product);
        await context.SaveChangesAsync();
        return true;
    }
}