using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Application.Models.Responses;

namespace Unicam.Enterprise.Project.Application.Services.Abstractions;

/// <summary>
/// Interface for the history service.
/// </summary>
public interface IHistoryService
{
    /// <summary>
    /// Retrieves the order history for a user.
    /// </summary>
    /// <param name="request">The get order history request.</param>
    /// <param name="userId">The user ID.</param>
    /// <param name="userRole">The user role.</param>
    /// <returns>The get order history response.</returns>
    Task<GetOrderHistoryResponse> GetOrderHistory(GetOrderHistoryRequest request, int userId, string userRole);
}
