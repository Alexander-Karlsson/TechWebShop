
using Api.DTOs.Product;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(ProductService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var products = await service.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var product = await service.GetByIdAsync(id);
        if(product is null) return NotFound($"No Product with id: {id} was found.");
        
        return Ok(product);
    }

    
    [HttpGet("search")]
    public async Task<IActionResult> FilterQuery(string query)
    {
        var result = await service.FilterByName(query);
        if(!result.Any()) return NotFound("No products found.");

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateProductDto dto)
    {
        await service.AddAsync(dto.Name, dto.Description, dto.Price, dto.CategoryId);
        return Created();
    }
}