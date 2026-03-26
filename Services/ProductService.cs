using Entities;
using Services.Interfaces;

namespace Services;

public class ProductService(IProductRepository productRepo) : IProductService
{
    public async Task<List<Product>> GetAllAsync() => await productRepo.GetAllAsync();

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        var product = await productRepo.GetByIdAsync(id);
        if (product is null)
            throw new KeyNotFoundException($"Product with id: {id} was not found.");
        
        return product;
    }

    public async Task AddAsync(Product product) => await productRepo.AddAsync(product);

    public async Task UpdateAsync(Product product) => await productRepo.UpdateAsync(product);

    public async Task<bool> DeleteAsync(Guid id)
    {
        var product = await productRepo.GetByIdAsync(id);
        if (product is null)
            throw new KeyNotFoundException($"Product with id: {id} was not found.");

        return await productRepo.DeleteAsync(id);
    }

}