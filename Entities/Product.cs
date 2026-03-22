namespace Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; } 
    public decimal Price { get; private set; }
    
    public Guid CategoryId { get; private set; }
    public ProductCategory Category { get; private set; }

    public Product(string name, string description, decimal price, ProductCategory category)
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name cannot be empty", nameof(name));
        if(string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Product description cannot be empty", nameof(description));
        if(price < 0)
            throw new ArgumentException("Product price cannot be negative", nameof(price));
        if(category == null)
            throw new ArgumentNullException(nameof(category), "Product category cannot be null");
        
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        Category = category;
        CategoryId = category.Id;
        
    }

    private Product() { } // EF Core requirement
}