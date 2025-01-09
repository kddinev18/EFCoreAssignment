using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Domain.Models.Sale;
using Test.Infrastructure.Contracts;

namespace Test.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        // GET: api/sale
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sales = await _saleService.GetAllSalesAsync();
            return Ok(sales);
        }

        // GET: api/sale/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sale = await _saleService.GetSaleByIdAsync(id);
            if (sale == null) return NotFound();
            return Ok(sale);
        }

        // POST: api/sale
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaleIM saleInputModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdSale = await _saleService.CreateSaleAsync(saleInputModel);
            return CreatedAtAction(nameof(GetById), new { id = createdSale.SaleId }, createdSale);
        }

        // PUT: api/sale/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SaleUM saleUpdateModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedSale = await _saleService.UpdateSaleAsync(id, saleUpdateModel);
            if (updatedSale == null) return NotFound();
            return Ok(updatedSale);
        }

        // DELETE: api/sale/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _saleService.DeleteSaleAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
