using Microsoft.AspNetCore.Mvc;
using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Application.Models.Responses;
using Unicam.Enterprise.Project.Application.Services.Abstractions;

namespace Unicam.Enterprise.Project.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    [Route("create")]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        var user = _userService.CreateUser(request);
        return Ok(new CreateUserResponse(user));
    }
    
    [HttpPost]
    [Route("login")]
    public IActionResult Login(LoginRequest request)
    {
        var token = _userService.Login(request);
        return Ok(new LoginResponse(token));
    }
}