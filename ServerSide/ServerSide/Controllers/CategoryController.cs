using Application.DTO.Category.Requests;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeditAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ApiController
{
    private readonly ICategoryService _categoryService;
    
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [Authorize]
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAllCategories()
    {
        var result = await _categoryService.GetAllCategoriesAsync();

        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [Authorize]
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _categoryService.DeleteCategoryAsync(id);
        return result.Match(
            _ => NoContent(),
            errors => Problem(errors));
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Add(CategoryRequestDto categoryRequestDto)
    {
        var result = await _categoryService.AddCategoryAsync(categoryRequestDto);
        return result.Match(
            result => Ok(),
            errors => Problem(errors));
    }
}
