using Microsoft.AspNetCore.Mvc;
using System.Linq;
using json2_assignment.DM.Models;
using json2_assignment.DAL.Repository;
using json2_assignment.Domain.DTOs;

namespace json2_assignment.Services;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly CustomerRepository _repository;

    public CustomersController(CustomerRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var customers = _repository.GetAll().ToList();
        return Ok(customers.Select(c => new CustomerDto
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email,
            PhoneNumber = c.PhoneNumber,
            Address = c.Address,
            DateRegistered = c.DateRegistered
        }));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var customer = _repository.GetById(id);
        if (customer == null) return NotFound();
        return Ok(new CustomerDto
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            Address = customer.Address,
            DateRegistered = customer.DateRegistered
        });
    }

    [HttpPost]
    public IActionResult Create([FromBody] CustomerDto customerDto)
    {
        var customer = new Customer
        {
            Id = customerDto.Id,
            Name = customerDto.Name,
            Email = customerDto.Email,
            PhoneNumber = customerDto.PhoneNumber,
            Address = customerDto.Address,
            DateRegistered = customerDto.DateRegistered
        };

        if (_repository.Add(customer)) return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        return BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] CustomerDto customerDto)
    {
        if (id != customerDto.Id) return BadRequest();

        var customer = new Customer
        {
            Id = customerDto.Id,
            Name = customerDto.Name,
            Email = customerDto.Email,
            PhoneNumber = customerDto.PhoneNumber,
            Address = customerDto.Address,
            DateRegistered = customerDto.DateRegistered
        };

        if (_repository.Update(customer)) return NoContent();
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (_repository.Delete(id)) return NoContent();
        return NotFound();
    }
}