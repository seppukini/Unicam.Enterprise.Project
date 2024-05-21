using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Application.Models.Responses;

namespace Unicam.Enterprise.Project.Application.Services.Abstractions;

/// <summary>
/// Interface for the order service.
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Creates a new order for a user.
    /// </summary>
    /// <param name="request">The create order request.</param>
    /// <param name="userId">The user ID.</param>
    /// <returns>The create order response.</returns>
    Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request, int userId);
}