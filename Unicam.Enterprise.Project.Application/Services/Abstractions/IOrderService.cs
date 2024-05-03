using Unicam.Enterprise.Project.Application.Models.DTOs;
using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Application.Models.Responses;

namespace Unicam.Enterprise.Project.Application.Services.Abstractions;

public interface IOrderService
{
    Task<CreateOrderResponse?> CreateOrder(CreateOrderRequest request, int userId);
}