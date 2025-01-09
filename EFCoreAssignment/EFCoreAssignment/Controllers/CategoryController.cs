using EFCoreAssignment.Domain.DTOs.Request;
using EFCoreAssignment.Infrastructure.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_categoryService.GetAllCategories());
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int id)
    {
        return Ok(_categoryService.GetCategory(id));
    }

    [HttpPost]
    public IActionResult Add([FromBody] CategoryRequestDTO category)
    {
        return Ok(_categoryService.InsertCategory(category));
    }

    [HttpPut]
    public IActionResult Update([FromBody] CategoryRequestDTO category)
    {
        return Ok(_categoryService.UpdateCategory(category));
    }

    [HttpDelete]
    public IActionResult Delete([FromQuery] int id)
    {
        return Ok(_categoryService.DeleteCategory(id));
    }
}