using Entities;

namespace Services.Interfaces;

public interface IProductCategoryService
{
    Task<List<ProductCategory>> GetAllAsync();
    Task<ProductCategory?> GetByIdAsync(Guid id);
    Task AddAsync(ProductCategory product);
    Task UpdateAsync(ProductCategory product);
    Task<bool> DeleteAsync(Guid id);
}