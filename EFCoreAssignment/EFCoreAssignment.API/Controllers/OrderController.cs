using EFCoreAssignment.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EFCoreAssignment.DTOs;
using EFCoreAssignment.Data.Models;
using AutoMapper;

namespace EFCoreAssignment.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController(IBaseService baseService) : ControllerBase
    {
        private readonly Mapper _mapper = MapperConfig.InitializeAutomapper();
        private readonly IBaseService _baseService = baseService;

        [HttpGet(Name = "GetOrderById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            Order? order = await _baseService.GetById<Order>(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet(Name = "GetAllOrders")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Order> orders = await _baseService.GetAll<Order>();
            return Ok(orders);
        }

        [HttpPost(Name = "CreateOrder")]
        public async Task<IActionResult> Create([FromBody] OrderDTO model)
        {
            if (await _baseService.GetById<User>(model.UserId) == null)
            {
                return BadRequest(new { message = "User doesn't exist!" });
            }
            Order order = _mapper.Map<Order>(model);
            if (await _baseService.Create(order))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut(Name = "UpdateOrder")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] OrderDTO model)
        {
            Order? order = await _baseService.GetById<Order>(id);
            if (order == null)
            {
                return NotFound();
            }
            if (await _baseService.GetById<User>(model.UserId) == null)
            {
                return BadRequest(new { message = "User doesn't exist!" });
            }   
            if (await _baseService.Update(_mapper.Map(model, order)))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete(Name = "DeleteOrder")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            Order? order = await _baseService.GetById<Order>(id);
            if (order == null)
            {
                return NotFound();
            }
            if (await _baseService.Delete(order))
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
