using Microsoft.AspNetCore.Mvc;
using System.Linq;
using json2_assignment.Domain.DTOs;
using json2_assignment.DM.Models;
using json2_assignment.DAL.Repository;
using json2_assignment.Domain.Services;

namespace json2_assignment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly ISaleService _saleService;

    public SalesController(ISaleService saleService)
    {
        _saleService = saleService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SaleDto>>> GetSales()
    {
        var sales = await _saleService.GetAllSalesAsync();
        return Ok(sales);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SaleDto>> GetSale(int id)
    {
        var sale = await _saleService.GetSaleByIdAsync(id);
        if (sale == null)
        {
            return NotFound();
        }
        return Ok(sale);
    }

    [HttpGet("customer/{customerId}")]
    public async Task<ActionResult<IEnumerable<SaleDto>>> GetSalesByCustomer(int customerId)
    {
        var sales = await _saleService.GetSalesByCustomerAsync(customerId);
        return Ok(sales);
    }

    [HttpPost]
    public async Task<ActionResult<SaleDto>> CreateSale(SaleDto saleDto)
    {
        var created = await _saleService.CreateSaleAsync(saleDto);
        return CreatedAtAction(nameof(GetSale), new { id = created.SaleId }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSale(int id, SaleDto saleDto)
    {
        if (id != saleDto.SaleId)
        {
            return BadRequest();
        }
        await _saleService.UpdateSaleAsync(saleDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSale(int id)
    {
        await _saleService.DeleteSaleAsync(id);
        return NoContent();
    }
}