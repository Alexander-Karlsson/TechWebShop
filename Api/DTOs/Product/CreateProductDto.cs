namespace Api.DTOs.Product;

public record CreateProductDto(
    string Name,
    string Description,
    decimal Price,
    Guid CategoryId
);