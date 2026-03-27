using Entities;

namespace Services.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task<bool> DeleteAsync(Guid id);
    Task<List<Product>> FilterByName(string searchQuery);
}