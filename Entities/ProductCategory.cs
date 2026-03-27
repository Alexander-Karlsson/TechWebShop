namespace Entities;

public class ProductCategory
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    

    public ICollection<Product> Products { get; private set; } = [];

    public ProductCategory(string name, string description)
    {
        Id = Guid.NewGuid();
        SetDetails(name, description);
    }

    public void UpdateDetails(string name, string description) => SetDetails(name, description);
    
    private void SetDetails(string name, string description)
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product category cannot be empty", nameof(name));
        if(string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Product description cannot be empty", nameof(description));

        Name = name;
        Description = description;
    }

    private ProductCategory() { } // EF Core requirement

}