using EfCoreTest.Models;
using EfCoreTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreTest.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create(User newUser)
        {
            var createdUser = _userService.AddUser(newUser);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.UserId }, createdUser);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, User updatedUser)
        {
            var result = _userService.UpdateUser(id, updatedUser);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _userService.DeleteUser(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}