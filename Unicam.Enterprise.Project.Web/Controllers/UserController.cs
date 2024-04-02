using Microsoft.AspNetCore.Mvc;
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
    
    [HttpGet]
    [Route("get/{id:int}")]
    public IActionResult GetUser(int id)
    {
        return Ok(_userService.GetUser(id));
    }
}