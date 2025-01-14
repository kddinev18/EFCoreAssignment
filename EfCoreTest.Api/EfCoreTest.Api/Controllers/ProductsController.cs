using EfCoreTest.Models;
using EfCoreTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController()
        {
            _productService = new ProductService();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet]
        public IActionResult GetById([FromQuery]int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Product newProduct)
        {
            var createdProduct = _productService.AddProduct(newProduct);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.ProductId }, createdProduct);
        }

        [HttpPut]
        public IActionResult Update([FromQuery]int id,[FromBody] Product updatedProduct)
        {
            var result = _productService.UpdateProduct(id, updatedProduct);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery]int id)
        {
            var result = _productService.DeleteProduct(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
