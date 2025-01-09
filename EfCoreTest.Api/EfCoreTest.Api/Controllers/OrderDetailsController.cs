using EfCoreTest.Models;
using EfCoreTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreTest.Api.Controllers
{
    [ApiController]
    [Route("api/orderdetails")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly OrderDetailService _orderDetailService;

        public OrderDetailsController(OrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orderDetails = _orderDetailService.GetAllOrderDetails();
            return Ok(orderDetails);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var orderDetail = _orderDetailService.GetOrderDetailsByOrderId(id);
            if (orderDetail == null || !orderDetail.Any())
                return NotFound();

            return Ok(orderDetail);
        }

        [HttpPost]
        public IActionResult Create(OrderDetail newOrderDetail)
        {
            var createdOrderDetail = _orderDetailService.AddOrderDetail(newOrderDetail);
            return CreatedAtAction(nameof(GetById), new { id = createdOrderDetail.OrderDetailId }, createdOrderDetail);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, OrderDetail updatedOrderDetail)
        {
            var result = _orderDetailService.UpdateOrderDetail(id, updatedOrderDetail);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _orderDetailService.DeleteOrderDetail(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
