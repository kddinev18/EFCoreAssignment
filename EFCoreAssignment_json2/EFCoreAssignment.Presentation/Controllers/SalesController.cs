using Microsoft.AspNetCore.Mvc;
using EFCoreAssignment.Logic;
using EFCoreAssignment.DataAccess;

namespace EFCoreAssignment.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SalesService _saleService;

        public SalesController(SalesService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sales>>> GetSales()
        {
            var sales = await _saleService.GetAllSalesAsync();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sales>> GetSale(int id)
        {
            try
            {
                var sale = await _saleService.GetSaleByIdAsync(id);
                return Ok(sale);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Sales>> CreateSale([FromBody] Sales sale)
        {
            if (sale == null)
            {
                return BadRequest("Sale data is invalid.");
            }

            var createdSale = await _saleService.CreateSaleAsync(sale);
            return CreatedAtAction(nameof(GetSale), new { id = createdSale.SaleId }, createdSale);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Sales>> UpdateSale(int id, [FromBody] Sales sale)
        {
            if (sale == null)
            {
                return BadRequest("Sale data is invalid.");
            }

            try
            {
                var updatedSale = await _saleService.UpdateSaleAsync(id, sale);
                return Ok(updatedSale);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            try
            {
                await _saleService.DeleteSaleAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
