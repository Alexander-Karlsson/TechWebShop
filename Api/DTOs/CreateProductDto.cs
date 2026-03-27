namespace Api.DTOs;

public record CreateProductDto(
    string Name,
    string Description,
    decimal Price,
    Guid CategoryId
);