using EFCoreAssignment.Domain.DTOs.Request;
using EFCoreAssignment.Infrastructure.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_customerService.GetAllCustomers());
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int id)
    {
        return Ok(_customerService.GetCustomer(id));
    }

    [HttpPost]
    public IActionResult Add([FromBody] CustomerRequestDTO customer)
    {
        return Ok(_customerService.InsertCustomer(customer));
    }

    [HttpPut]
    public IActionResult Update([FromBody] CustomerRequestDTO customer)
    {
        return Ok(_customerService.UpdateCustomer(customer));
    }

    [HttpDelete]
    public IActionResult Delete([FromQuery] int id)
    {
        return Ok(_customerService.DeleteCustomer(id));
    }
}