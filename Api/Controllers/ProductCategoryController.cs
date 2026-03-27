using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductCategoryController(ProductCategoryService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetallAsync()
    {
        var categories = await service.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetbyIdAsync(Guid id)
    {
        var category = await service.GetByIdAsync(id);
        return Ok(category);
    }
}