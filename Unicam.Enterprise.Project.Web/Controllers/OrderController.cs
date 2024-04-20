using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Application.Models.Responses;
using Unicam.Enterprise.Project.Application.Services.Abstractions;

namespace Unicam.Enterprise.Project.Controllers;

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
    
    [HttpPost]
    [Route("create")]
    public IActionResult CreateOrder(CreateOrderRequest request)
    {
        try
        {
            var orderDto = _orderService.CreateOrder(request, int.Parse(UserId), out var totalPrice);
            return Ok(new CreateOrderResponse(orderDto.Id, totalPrice));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}