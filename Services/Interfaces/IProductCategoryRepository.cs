using Entities;

namespace Services.Interfaces;

public interface IProductCategoryRepository
{
    Task<List<ProductCategory>> GetAllAsync();
    Task<ProductCategory?> GetByIdAsync(Guid id);
    Task AddAsync(ProductCategory productCategory);
    Task UpdateAsync(ProductCategory productCategory);
    Task<bool> DeleteAsync(Guid id);
}