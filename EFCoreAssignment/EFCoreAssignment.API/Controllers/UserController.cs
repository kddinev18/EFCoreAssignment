using EFCoreAssignment.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EFCoreAssignment.DTOs;
using EFCoreAssignment.Data.Models;
using AutoMapper;

namespace EFCoreAssignment.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController(IBaseService baseService) : ControllerBase
    {
        private readonly Mapper _mapper = MapperConfig.InitializeAutomapper();
        private readonly IBaseService _baseService = baseService;
        
        [HttpGet(Name = "GetUserById")]
        public async Task<IActionResult> GetUserById([FromQuery] int id)
        {
            User ?user = await _baseService.GetById<User>(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet(Name = "GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            IEnumerable<User> users = await _baseService.GetAll<User>();
            return Ok(users);
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO model)
        {
            User user = _mapper.Map<User>(model);
            if (await _baseService.Create(user))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut(Name = "UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromQuery] int id, [FromBody] UserDTO model)
        {
            User? user = await _baseService.GetById<User>(id);
            if (user == null)
            {
                return NotFound();
            }
            if (await _baseService.Update(_mapper.Map(model, user)))
            {
                return Ok();
            }
            return BadRequest();

        }

        [HttpDelete(Name = "DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromQuery] int id)
        {
            User? user = await _baseService.GetById<User>(id);
            if (user == null)
            {
                return NotFound();
            }
            if (await _baseService.Delete(user))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
