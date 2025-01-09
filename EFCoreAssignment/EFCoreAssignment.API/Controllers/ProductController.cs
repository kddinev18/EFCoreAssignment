using EFCoreAssignment.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EFCoreAssignment.DTOs;
using EFCoreAssignment.Data.Models;
using AutoMapper;

namespace EFCoreAssignment.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController(IBaseService baseService) : ControllerBase
    {
        private readonly Mapper _mapper = MapperConfig.InitializeAutomapper();
        private readonly IBaseService _baseService = baseService;

        [HttpGet(Name = "GetProductById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            Product? product = await _baseService.GetById<Product>(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet(Name = "GetAllProducts")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Product> products = await _baseService.GetAll<Product>();
            return Ok(products);
        }

        [HttpPost(Name = "CreateProduct")]
        public async Task<IActionResult> Create([FromBody] ProductDTO model)
        {
            Product product = _mapper.Map<Product>(model);
            if (await _baseService.Create(product))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut(Name = "UpdateProduct")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] ProductDTO model)
        {
            Product? product = await _baseService.GetById<Product>(id);
            if (product == null)
            {
                return NotFound();
            }
            if (await _baseService.Update(_mapper.Map(model, product)))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete(Name = "DeleteProduct")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            Product? product = await _baseService.GetById<Product>(id);
            if (product == null)
            {
                return NotFound();
            }
            if (await _baseService.Delete(product))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
