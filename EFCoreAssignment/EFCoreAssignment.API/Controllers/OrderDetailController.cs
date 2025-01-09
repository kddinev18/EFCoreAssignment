using EFCoreAssignment.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EFCoreAssignment.DTOs;
using EFCoreAssignment.Data.Models;
using AutoMapper;

namespace EFCoreAssignment.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderDetailController(IBaseService baseService) : ControllerBase
    {
        private readonly Mapper _mapper = MapperConfig.InitializeAutomapper();
        private readonly IBaseService _baseService = baseService;

        [HttpGet(Name = "GetOrderDetailById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            OrderDetail? orderDetail = await _baseService.GetById<OrderDetail>(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail);
        }

        [HttpGet(Name = "GetAllOrderDetails")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<OrderDetail> orderDetails = await _baseService.GetAll<OrderDetail>();
            return Ok(orderDetails);
        }

        [HttpPost(Name = "CreateOrderDetail")]
        public async Task<IActionResult> Create([FromBody] OrderDetailDTO model)
        {
            if (await _baseService.GetById<Order>(model.OrderId) == null)
            {
                return BadRequest(new { message = "Order doesn't exist!" });
            }
            if (await _baseService.GetById<Product>(model.ProductId) == null)
            {
                return BadRequest(new { message = "Product doesn't exist!" });
            }
            OrderDetail orderDetail = _mapper.Map<OrderDetail>(model);
            if (await _baseService.Create(orderDetail))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut(Name = "UpdateOrderDetail")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] OrderDetailDTO model)
        {
            OrderDetail? orderDetail = await _baseService.GetById<OrderDetail>(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            if (await _baseService.GetById<Order>(model.OrderId) == null)
            {
                return BadRequest(new { message = "Order doesn't exist!" });
            }
            if (await _baseService.GetById<Product>(model.ProductId) == null)
            {
                return BadRequest(new { message = "Product doesn't exist!" });
            }
            if (await _baseService.Update(_mapper.Map(model, orderDetail)))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete(Name = "DeleteOrderDetail")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            OrderDetail? orderDetail = await _baseService.GetById<OrderDetail>(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            if (await _baseService.Delete(orderDetail))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
