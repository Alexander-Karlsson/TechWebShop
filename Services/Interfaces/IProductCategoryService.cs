using Entities;

namespace Services.Interfaces;

public interface IProductCategoryService
{
    Task<List<ProductCategory>> GetAllAsync();
    Task<ProductCategory?> GetByIdAsync(Guid id);
    Task AddAsync(string name, string description);
    Task UpdateAsync(Guid id, string name, string description);
    Task<bool> DeleteAsync(Guid id);
}