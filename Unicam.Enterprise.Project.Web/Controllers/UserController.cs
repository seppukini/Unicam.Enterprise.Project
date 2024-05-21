using Microsoft.AspNetCore.Mvc;
using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Application.Services.Abstractions;

namespace Unicam.Enterprise.Project.Controllers;

/// <summary>
/// Controller for handling user-related operations.
/// </summary>
[Route("api/v1/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    /// <summary>
    /// Constructor for the user controller.
    /// </summary>
    /// <param name="userService">The user service.</param>
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="request">The create user request.</param>
    /// <returns>A response indicating the result of the operation.</returns>
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        var response = await _userService.CreateUser(request);
        
        return Ok(response);
    }

    /// <summary>
    /// Logs in a user.
    /// </summary>
    /// <param name="request">The login request.</param>
    /// <returns>A response indicating the result of the operation.</returns>
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        try
        {
            var response = await _userService.Login(request);
            
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}