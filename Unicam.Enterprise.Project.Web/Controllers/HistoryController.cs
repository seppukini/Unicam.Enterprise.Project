using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Application.Models.Responses;
using Unicam.Enterprise.Project.Application.Services.Abstractions;

namespace Unicam.Enterprise.Project.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class HistoryController : ControllerBase
{
    private readonly IHistoryService _historyService;
    private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier);
    private string UserRole => User.FindFirstValue(ClaimTypes.Role);
    
    public HistoryController(IHistoryService historyService)
    {
        _historyService = historyService;
    }
    
    [HttpPost]
    [Route("history")]
    public async Task<IActionResult> GetOrderHistory(GetOrderHistoryRequest request)
    {
        try
        {
            var orderDtos = await _historyService.
                GetOrderHistory(request, int.Parse(UserId), UserRole);
            
            return Ok(new GetOrderHistoryResponse(orderDtos));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}

