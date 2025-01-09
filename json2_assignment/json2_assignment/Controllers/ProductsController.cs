using Microsoft.AspNetCore.Mvc;
using System.Linq;
using json2_assignment.Domain.DTOs;
using json2_assignment.DM.Models;
using json2_assignment.DAL.Repository;
using json2_assignment.Domain.Services;


namespace json2_assignment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpGet("category/{categoryId}")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByCategory(int categoryId)
    {
        var products = await _productService.GetProductsByCategoryAsync(categoryId);
        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct(ProductDto productDto)
    {
        var created = await _productService.CreateProductAsync(productDto);
        return CreatedAtAction(nameof(GetProduct), new { id = created.ProductId }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, ProductDto productDto)
    {
        if (id != productDto.ProductId)
        {
            return BadRequest();
        }
        await _productService.UpdateProductAsync(productDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productService.DeleteProductAsync(id);
        return NoContent();
    }
}