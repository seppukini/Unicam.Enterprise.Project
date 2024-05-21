using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Application.Services.Abstractions;

namespace Unicam.Enterprise.Project.Controllers;

/// <summary>
/// Controller for handling order-related operations.
/// For use the API of this controller, the user must be authenticated.
/// </summary>
[Route("api/v1/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier);
    
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    /// <summary>
    /// Creates a new order.
    /// </summary>
    /// <param name="request">The create order request.</param>
    /// <returns>A response indicating the result of the operation.</returns>
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
    {
        try
        {
            var response = await _orderService.CreateOrder(request, int.Parse(UserId));
            
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}