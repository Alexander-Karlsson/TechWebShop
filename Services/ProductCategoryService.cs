using Entities;
using Services.Interfaces;

namespace Services;

public class ProductCategoryService(IProductCategoryRepository categoryRepo) : IProductCategoryService
{
    public async Task<List<ProductCategory>> GetAllAsync() => await categoryRepo.GetAllAsync();

    public async Task<ProductCategory?> GetByIdAsync(Guid id)
    {
        var category = await categoryRepo.GetByIdAsync(id);
        if(category is null)
            throw new KeyNotFoundException($"Category with id: {id} was not found");

        return category;
    }

    public async Task AddAsync(ProductCategory category) => await categoryRepo.AddAsync(category);
    
    public async Task UpdateAsync(ProductCategory category) => await categoryRepo.UpdateAsync(category);

    public async Task<bool> DeleteAsync(Guid id)
    {
        var category = await categoryRepo.GetByIdAsync(id);
        if(category is null)
            throw new KeyNotFoundException($"Category with id: {id} was not found");
        
        return await categoryRepo.DeleteAsync(id);
    }

}