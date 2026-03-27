using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(CustomerService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await service.GetAllAsync();
        return Ok(customers);
    }
}