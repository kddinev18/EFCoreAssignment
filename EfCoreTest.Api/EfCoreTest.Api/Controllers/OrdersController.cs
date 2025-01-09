using EfCoreTest.Models;
using EfCoreTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreTest.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public IActionResult Create(Order newOrder)
        {
            var createdOrder = _orderService.AddOrder(newOrder);
            return CreatedAtAction(nameof(GetById), new { id = createdOrder.OrderId }, createdOrder);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Order updatedOrder)
        {
            var result = _orderService.UpdateOrder(id, updatedOrder);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _orderService.DeleteOrder(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}