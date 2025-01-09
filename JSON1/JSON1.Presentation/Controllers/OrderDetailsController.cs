using JSON1.Application.Services.Persistance;
using JSON1.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JSON1.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailsService _orderDetailService;

        public OrderDetailController(IOrderDetailsService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetails()
        {
            var details = await _orderDetailService.GetAllOrderDetailsAsync();
            return Ok(details);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var detail = await _orderDetailService.GetOrderDetailsByIdAsync(id);
            if (detail == null) return NotFound();
            return Ok(detail);
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetOrderDetailsByOrderId(int orderId)
        {
            var details = await _orderDetailService.GetOrderDetailsByOrderIdAsync(orderId);
            return Ok(details);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderDetail(OrderDetails detail)
        {
            await _orderDetailService.AddOrderDetailsAsync(detail);
            return CreatedAtAction(nameof(GetOrderDetailById), new { id = detail.OrderDetailsId }, detail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderDetail(int id, OrderDetails detail)
        {
            if (id != detail.OrderDetailsId) return BadRequest();
            await _orderDetailService.UpdateOrderDetailsAsync(detail);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await _orderDetailService.DeleteOrderDetailsAsync(id);
            return NoContent();
        }
    }

}
