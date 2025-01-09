using Microsoft.AspNetCore.Mvc;
using System.Linq;
using json2_assignment.DAL.Repository;
using json2_assignment.DM.Models;
using json2_assignment.Domain.DTOs;
using json2_assignment.Domain.Services;

namespace json2_assignment.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetCategory(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDto>> CreateCategory(CategoryDto categoryDto)
    {
        var created = await _categoryService.CreateCategoryAsync(categoryDto);
        return CreatedAtAction(nameof(GetCategory), new { id = created.CategoryId }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, CategoryDto categoryDto)
    {
        if (id != categoryDto.CategoryId)
        {
            return BadRequest();
        }
        await _categoryService.UpdateCategoryAsync(categoryDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return NoContent();
    }
}