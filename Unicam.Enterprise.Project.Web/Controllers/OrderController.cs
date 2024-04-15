using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Unicam.Enterprise.Project.Application.Models.DTOs;
using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Application.Services;

namespace Unicam.Enterprise.Project.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
// TODO: make an application to properly generate these and a postman template to test these
// [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public IActionResult CreateOrder([FromBody] CreateOrderRequest request)
    {
        try
        {
            var orderDto = _orderService.CreateOrder(request);
            return CreatedAtAction(nameof(GetOrder), new { id = orderDto.Id }, orderDto);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetOrder(int id)
    {
        var order = _orderService.GetOrders().FirstOrDefault(o => o.Id == id);
        if (order == null)
        {
            return NotFound("Order not found.");
        }
        return Ok(order);
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        var orders = _orderService.GetOrders();
        return Ok(orders);
    }
}