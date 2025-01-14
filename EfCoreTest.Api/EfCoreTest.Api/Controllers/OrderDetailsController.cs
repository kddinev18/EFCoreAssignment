using EfCoreTest.Models;
using EfCoreTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly OrderDetailService _orderDetailService;

        public OrderDetailsController()
        {
            _orderDetailService = new OrderDetailService();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orderDetails = _orderDetailService.GetAllOrderDetails();
            return Ok(orderDetails);
        }

        [HttpGet]
        public IActionResult GetById([FromQuery]int id)
        {
            var orderDetail = _orderDetailService.GetOrderDetailsByOrderId(id);
            if (orderDetail == null || !orderDetail.Any())
                return NotFound();

            return Ok(orderDetail);
        }

        [HttpPost]
        public IActionResult Create([FromBody]OrderDetail newOrderDetail)
        {
            var createdOrderDetail = _orderDetailService.AddOrderDetail(newOrderDetail);
            return CreatedAtAction(nameof(GetById), new { id = createdOrderDetail.OrderDetailId }, createdOrderDetail);
        }

        [HttpPut]
        public IActionResult Update([FromQuery]int id, [FromBody]OrderDetail updatedOrderDetail)
        {
            var result = _orderDetailService.UpdateOrderDetail(id, updatedOrderDetail);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery]int id)
        {
            var result = _orderDetailService.DeleteOrderDetail(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
