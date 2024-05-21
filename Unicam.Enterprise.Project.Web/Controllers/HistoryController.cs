using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Application.Services.Abstractions;

namespace Unicam.Enterprise.Project.Controllers;

/// <summary>
/// Controller for handling history-related operations.
/// For use the API of this controller, the user must be authenticated.
/// </summary>
[Route("api/v1/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class HistoryController : ControllerBase
{
    private readonly IHistoryService _historyService;
    private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier);
    private string UserRole => User.FindFirstValue(ClaimTypes.Role);

    /// <summary>
    /// Constructor for the history controller.
    /// </summary>
    /// <param name="historyService">The history service.</param>
    public HistoryController(IHistoryService historyService)
    {
        _historyService = historyService;
    }

    /// <summary>
    /// Gets the order history for a user.
    /// </summary>
    /// <param name="request">The get order history request.</param>
    /// <returns>A response indicating the result of the operation.</returns>
    [HttpPost]
    [Route("history")]
    public async Task<IActionResult> GetOrderHistory(GetOrderHistoryRequest request)
    {
        try
        {
            var response = await _historyService.GetOrderHistory(request, int.Parse(UserId), UserRole);
            
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}

