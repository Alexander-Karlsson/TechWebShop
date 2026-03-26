using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace EF_MSSQL.Repositories;

public class ProductCategoryRepository(AppDbContext db) : IProductCategoryRepository
{
    public async Task<List<ProductCategory>> GetAllAsync()
        => await db.ProductCategories.AsNoTracking().ToListAsync();
    
    public async Task<ProductCategory?> GetByIdAsync(Guid id)
        => await db.ProductCategories.FindAsync(id);
    
    public async Task AddAsync(ProductCategory productCategory)
    {
        await db.ProductCategories.AddAsync(productCategory);
        await db.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(ProductCategory productCategory)
    {
        db.ProductCategories.Update(productCategory);
        await db.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var category = await db.ProductCategories.FindAsync(id);
        if(category is null) return false;

        db.ProductCategories.Remove(category);
        await db.SaveChangesAsync();
        return true;
    }
}