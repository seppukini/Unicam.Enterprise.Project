using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Project.Application.Abstractions.Services;
using Unicam.Paradigmi.Project.Model.Entities;

namespace Unicam.Paradigmi.Project.Controllers;

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
    [Route("new")]
    public IActionResult CreateUser(User user)
    {
        _userService.AddUser(user);
        return Ok("User created successfully!");
    }
    
    [HttpGet]
    [Route("get/{id:int}")]
    public User GetUser(int id)
    {
        return _userService.GetUser(id);
    }
    
}