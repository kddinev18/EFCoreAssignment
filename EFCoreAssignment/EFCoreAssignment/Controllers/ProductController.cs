using EFCoreAssignment.Domain.DTOs.Request;
using EFCoreAssignment.Infrastructure.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProductController : Controller
{
    private readonly IProductService _productService;

    ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_productService.GetAllProducts());
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int id)
    {
        return Ok(_productService.GetProduct(id));
    }

    [HttpPost]
    public IActionResult Add([FromBody] ProductRequestDTO product)
    {
        return Ok(_productService.InsertProduct(product));
    }

    [HttpPut]
    public IActionResult Update([FromBody] ProductRequestDTO product)
    {
        return Ok(_productService.UpdateProduct(product));
    }

    [HttpDelete]
    public IActionResult Delete([FromQuery] int id)
    {
        return Ok(_productService.DeleteProduct(id));
    }
}