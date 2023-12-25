using Domain.Dtos.Product;
using Infrastructure.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpGet("GetProductFullInfo")]
    public async Task<IActionResult> GetProductFullInfo()
    {
        var result = await _service.GetProductFullInfo();
        return Ok(result);
    }
    
    [HttpGet("GetProduct")]
    public async Task<IActionResult> GetProduct()
    {
        var result = await _service.GetProduct();
        return Ok(result);
    }

    [HttpGet("GetProductById")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var result = await _service.GetProductById(id);
        return Ok(result);
    }

    [HttpPost("AddProduct")]
    public async Task<IActionResult> AddProduct([FromQuery]AddProductDto product)
    {
        var result = await _service.AddProduct(product);
        return Ok(result);
    }

    [HttpPut("UpdateProduct")]
    public async Task<IActionResult> UpdateProduct([FromQuery]AddProductDto product)
    {
        var result = await _service.UpdateProduct(product);
        return Ok(result);
    }

    [HttpDelete("DeletePeoduct")]
    public async Task<IActionResult> DeleteProduct([FromQuery] int id)
    {
        var result = await _service.DeleteProduct(id);
        return Ok(result);
    }
}