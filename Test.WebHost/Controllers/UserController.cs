using System.Threading.Tasks;
using Test.Domain.Models.User;
using Test.Data.Models;
using Test.Infrastructure.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Test.WebHost.Controllers;

/// <summary>
/// API Controller for managing user information.
/// </summary>
[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    // private readonly IUserService userService;
    private readonly ICurrentUser currentUser;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserController"/> class.
    /// </summary>
    /// <param name="userService">The service handling user-related operations.</param>
    /// <param name="currentUser">The current user context.</param>
    // public UserController(IUserService userService, ICurrentUser currentUser)
    // {
    //     this.userService = userService;
    //     this.currentUser = currentUser;
    // }
    
    /// <summary>
    /// Updates user information for a specific user.
    /// </summary>
    /// <param name="userEmail">The email of the user to update.</param>
    /// <param name="userUm">The user update model containing updated information.</param>
    /// <returns>A boolean indicating the success of the operation.</returns>
    [HttpPut]
    public async Task<ActionResult<bool>> CreateUserInfoAsync(string userEmail, UserUM userUm)
    {
        return await this.userService.UpdateUserAsync(userEmail, userUm);
    }
    
    /// <summary>
    /// Retrieves information about the currently authenticated user.
    /// </summary>
    /// <returns>The view model of the current user or a 404 response if the user is not found.</returns>
    [HttpGet("current")]
    [Authorize]
    public async Task<ActionResult<UserVM?>> GetUserMeAsync()
    {
        var result = await this.userService.GetUserByIdAsync(this.currentUser.UserId);

        if (result is null)
        {
            return this.NotFound();
        }

        return result;
    }
}