using EfCoreTest.Models;
using EfCoreTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController()
        {
            _orderService = new OrderService();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet]
        public IActionResult GetById([FromQuery]int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Order newOrder)
        {
            var createdOrder = _orderService.AddOrder(newOrder);
            return CreatedAtAction(nameof(GetById), new { id = createdOrder.OrderId }, createdOrder);
        }

        [HttpPut]
        public IActionResult Update([FromQuery]int id,[FromBody] Order updatedOrder)
        {
            var result = _orderService.UpdateOrder(id, updatedOrder);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery]int id)
        {
            var result = _orderService.DeleteOrder(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
