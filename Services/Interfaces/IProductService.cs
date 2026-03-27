using Entities;

namespace Services.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task AddAsync(string name, string description, decimal price, Guid categoryId);
    Task UpdateAsync(Product product);
    Task<bool> DeleteAsync(Guid id);
    Task<List<Product>> FilterByName(string searchQuery);
}