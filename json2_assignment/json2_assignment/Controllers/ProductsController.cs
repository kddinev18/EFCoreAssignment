using Microsoft.AspNetCore.Mvc;
using System.Linq;
using json2_assignment.Domain.DTOs;
using json2_assignment.DM.Models;
using json2_assignment.DAL.Repository;


namespace json2_assignment.Services;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductRepository _repository;

    public ProductsController(ProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var products = _repository.GetAll().ToList();
        return Ok(products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock,
            Description = p.Description,
            CategoryId = p.CategoryId
        }));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _repository.GetById(id);
        if (product == null) return NotFound();
        return Ok(new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            Description = product.Description,
            CategoryId = product.CategoryId
        });
    }

    [HttpPost]
    public IActionResult Create([FromBody] ProductDto productDto)
    {
        var product = new Product
        {
            Id = productDto.Id,
            Name = productDto.Name,
            Price = productDto.Price,
            Stock = productDto.Stock,
            Description = productDto.Description,
            CategoryId = productDto.CategoryId
        };

        if (_repository.Add(product)) return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        return BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] ProductDto productDto)
    {
        if (id != productDto.Id) return BadRequest();

        var product = new Product
        {
            Id = productDto.Id,
            Name = productDto.Name,
            Price = productDto.Price,
            Stock = productDto.Stock,
            Description = productDto.Description,
            CategoryId = productDto.CategoryId
        };

        if (_repository.Update(product)) return NoContent();
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (_repository.Delete(id)) return NoContent();
        return NotFound();
    }
}