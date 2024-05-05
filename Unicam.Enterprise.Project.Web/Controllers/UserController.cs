using Microsoft.AspNetCore.Mvc;
using Unicam.Enterprise.Project.Application.Models.Requests;
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
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        var response = await _userService.CreateUser(request);
        
        return Ok(response);
    }
    
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