using AutoMapper;
using Assignment.Infrastructure.Contracts;
using Assignment.Domain.Models.InputModels;
using Assignment.Domain.Models.UpdateModels;
using Assignment.Domain.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Webhost.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class SaleController : ControllerBase
{
    private readonly ISaleService _saleService;
    private readonly IMapper _mapper;

    public SaleController(ISaleService saleService, IMapper mapper)
    {
        _saleService = saleService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SaleVm>>> GetAll(CancellationToken ct = default)
    {
        var sales = await _saleService.GetAllAsync();
        return Ok(sales);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SaleVm>> GetById(int id, CancellationToken ct = default)
    {
        var sale = await _saleService.GetByIdAsync(id);
        if (sale == null)
        {
            return NotFound();
        }
        return Ok(sale);
    }

    [HttpPost]
    public async Task<ActionResult<SaleVm>> Create([FromBody] SaleIm saleIm, CancellationToken ct = default)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var sale = await _saleService.CreateAsync(saleIm);
        return CreatedAtAction(nameof(GetById), new { id = sale.SaleId }, sale);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<SaleVm>> Update(int id, [FromBody] SaleUm saleUm, CancellationToken ct = default)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var sale = await _saleService.UpdateAsync(id, saleUm);
            return Ok(sale);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id, CancellationToken ct = default)
    {
        var success = await _saleService.DeleteAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}