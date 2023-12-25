using Domain.Dtos.Category;
using Infrastructure.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _serviceCategory;

    public CategoryController(ICategoryService serviceCategory)
    {
        _serviceCategory = serviceCategory;
    }

    [HttpGet("GetCategory")]
    public async Task<IActionResult> GetCategory()
    {
        var result = await _serviceCategory.GetCategory();
        return Ok(result);
    }

    [HttpGet("GetCategoryById")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var result = await _serviceCategory.GetCategoryById(id);
        return Ok(result);
    }

    [HttpPost("AddCategory")]
    public async Task<IActionResult> AddCategory([FromQuery]AddCategoryDto category)
    {
        var result = await _serviceCategory.AddCategory(category);
        return Ok(result);
    }

    [HttpPut("UpdateCategory")]
    public async Task<IActionResult> UpdateCategory([FromQuery]AddCategoryDto category)
    {
        var result = await _serviceCategory.UpdateCategory(category);
        return Ok(result);
    }

    [HttpDelete("DeleteCategory")]
    public async Task<IActionResult> DeleteCategory([FromQuery]int id)
    {
        var result = await _serviceCategory.DeleteCategory(id);
        return Ok(result);
    }
}