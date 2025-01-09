using EFCoreAssignment.Domain.DTOs.Request;
using EFCoreAssignment.Infrastructure.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SaleController : Controller
{
    private readonly ISaleService _saleService;

    SaleController(ISaleService saleService)
    {
        _saleService = saleService;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_saleService.GetAllSales());
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int id)
    {
        return Ok(_saleService.GetSale(id));
    }

    [HttpPost]
    public IActionResult Add([FromBody] SaleRequestDTO sale)
    {
        return Ok(_saleService.InsertSale(sale));
    }

    [HttpPut]
    public IActionResult Update([FromBody] SaleRequestDTO sale)
    {
        return Ok(_saleService.UpdateSale(sale));
    }

    [HttpDelete]
    public IActionResult Delete([FromQuery] int id)
    {
        return Ok(_saleService.DeleteSale(id));
    }
}