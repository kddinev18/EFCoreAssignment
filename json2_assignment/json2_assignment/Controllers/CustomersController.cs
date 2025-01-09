using Microsoft.AspNetCore.Mvc;
using System.Linq;
using json2_assignment.DM.Models;
using json2_assignment.DAL.Repository;
using json2_assignment.Domain.DTOs;
using json2_assignment.Domain.Services;
using json2_assignment.Domain.Services;

namespace json2_assignment.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
    {
        var customers = await _customerService.GetAllCustomersAsync();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> CreateCustomer(CustomerDto customerDto)
    {
        var created = await _customerService.CreateCustomerAsync(customerDto);
        return CreatedAtAction(nameof(GetCustomer), new { id = created.CustomerId }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, CustomerDto customerDto)
    {
        if (id != customerDto.CustomerId)
        {
            return BadRequest();
        }
        await _customerService.UpdateCustomerAsync(customerDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        await _customerService.DeleteCustomerAsync(id);
        return NoContent();
    }
}