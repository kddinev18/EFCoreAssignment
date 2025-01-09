using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Domain.Models.Customer;
using Test.Infrastructure.Contracts;

namespace Test.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/customer
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        // GET: api/customer/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        // POST: api/customer
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerIM customerInputModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdCustomer = await _customerService.CreateCustomerAsync(customerInputModel);
            return CreatedAtAction(nameof(GetById), new { id = createdCustomer.CustomerId }, createdCustomer);
        }

        // PUT: api/customer/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerUM customerUpdateModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedCustomer = await _customerService.UpdateCustomerAsync(id, customerUpdateModel);
            if (updatedCustomer == null) return NotFound();
            return Ok(updatedCustomer);
        }

        // DELETE: api/customer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _customerService.DeleteCustomerAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
