using EfCoreTest.Models;
using EfCoreTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController()
        {
            _userService = new UserService();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet]
        public IActionResult GetById([FromQuery]int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody]User newUser)
        {
            var createdUser = _userService.AddUser(newUser);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.UserId }, createdUser);
        }

        [HttpPut]
        public IActionResult Update([FromQuery]int id, [FromBody]User updatedUser)
        {
            var result = _userService.UpdateUser(id, updatedUser);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery]int id)
        {
            var result = _userService.DeleteUser(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
