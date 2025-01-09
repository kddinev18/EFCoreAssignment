using Microsoft.AspNetCore.Mvc;
using System.Linq;
using json2_assignment.DAL.Repository;
using json2_assignment.DM.Models;
using json2_assignment.Domain.DTOs;


namespace json2_assignment.Domain.DTOs.Services;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly CategoryRepository _repository;

    public CategoriesController(CategoryRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var categories = _repository.GetAll().ToList();
        return Ok(categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description
        }));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var category = _repository.GetById(id);
        if (category == null) return NotFound();
        return Ok(new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        });
    }

    [HttpPost]
    public IActionResult Create([FromBody] CategoryDto categoryDto)
    {
        var category = new Category
        {
            Id = categoryDto.Id,
            Name = categoryDto.Name,
            Description = categoryDto.Description
        };

        if (_repository.Add(category)) return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        return BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] CategoryDto categoryDto)
    {
        if (id != categoryDto.Id) return BadRequest();

        var category = new Category
        {
            Id = categoryDto.Id,
            Name = categoryDto.Name,
            Description = categoryDto.Description
        };

        if (_repository.Update(category)) return NoContent();
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (_repository.Delete(id)) return NoContent();
        return NotFound();
    }
}