using Microsoft.AspNetCore.Mvc;
using System.Linq;
using json2_assignment.Domain.DTOs;
using json2_assignment.DM.Models;
using json2_assignment.DAL.Repository;


namespace json2_assignment;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly SaleRepository _repository;

    public SalesController(SaleRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var sales = _repository.GetAll().ToList();
        return Ok(sales.Select(s => new SaleDto
        {
            Id = s.Id,
            CustomerId = s.CustomerId,
            ProductId = s.ProductId,
            Quantity = s.Quantity,
            SaleDate = s.SaleDate,
            TotalPrice = s.TotalPrice
        }));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var sale = _repository.GetById(id);
        if (sale == null) return NotFound();
        return Ok(new SaleDto
        {
            Id = sale.Id,
            CustomerId = sale.CustomerId,
            ProductId = sale.ProductId,
            Quantity = sale.Quantity,
            SaleDate = sale.SaleDate,
            TotalPrice = sale.TotalPrice
        });
    }

    [HttpPost]
    public IActionResult Create([FromBody] SaleDto saleDto)
    {
        var sale = new Sale
        {
            Id = saleDto.Id,
            CustomerId = saleDto.CustomerId,
            ProductId = saleDto.ProductId,
            Quantity = saleDto.Quantity,
            SaleDate = saleDto.SaleDate,
            TotalPrice = saleDto.TotalPrice
        };

        if (_repository.Add(sale)) return CreatedAtAction(nameof(GetById), new { id = sale.Id }, sale);
        return BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] SaleDto saleDto)
    {
        if (id != saleDto.Id) return BadRequest();

        var sale = new Sale
        {
            Id = saleDto.Id,
            CustomerId = saleDto.CustomerId,
            ProductId = saleDto.ProductId,
            Quantity = saleDto.Quantity,
            SaleDate = saleDto.SaleDate,
            TotalPrice = saleDto.TotalPrice
        };

        if (_repository.Update(sale)) return NoContent();
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (_repository.Delete(id)) return NoContent();
        return NotFound();
    }
}