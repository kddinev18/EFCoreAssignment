using EfCoreTest.Models;
using EfCoreTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreTest.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Product newProduct)
        {
            var createdProduct = _productService.AddProduct(newProduct);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.ProductId }, createdProduct);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Product updatedProduct)
        {
            var result = _productService.UpdateProduct(id, updatedProduct);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.DeleteProduct(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}