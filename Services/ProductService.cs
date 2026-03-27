using Entities;
using Services.Interfaces;

namespace Services;

public class ProductService(IProductRepository productRepo, IProductCategoryRepository categoryRepo) : IProductService
{
    public async Task<List<Product>> GetAllAsync() => await productRepo.GetAllAsync();

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        var product = await productRepo.GetByIdAsync(id);
        if (product is null)
            throw new KeyNotFoundException($"Product with id: {id} was not found.");
        
        return product;
    }

    public async Task AddAsync(string name, string description, decimal price, Guid categoryId)
    {
        var category = await categoryRepo.GetByIdAsync(categoryId);
        if(category is null) throw new KeyNotFoundException($"Category with id: {categoryId} was not found.");
        
        var product = new Product(name, description, price, category);
        await productRepo.AddAsync(product);
    }

    public async Task UpdateAsync(Product product) => await productRepo.UpdateAsync(product);

    public async Task<bool> DeleteAsync(Guid id)
    {
        var product = await productRepo.GetByIdAsync(id);
        if (product is null)
            throw new KeyNotFoundException($"Product with id: {id} was not found.");

        return await productRepo.DeleteAsync(id);
    }

    public async Task<List<Product>> FilterByName(string searchQuery)
        => await productRepo.FilterByName(searchQuery);
    

}