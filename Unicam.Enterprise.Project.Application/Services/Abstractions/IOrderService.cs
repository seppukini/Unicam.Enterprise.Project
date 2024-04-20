using Unicam.Enterprise.Project.Application.Models.DTOs;
using Unicam.Enterprise.Project.Application.Models.Requests;

namespace Unicam.Enterprise.Project.Application.Services.Abstractions;

public interface IOrderService
{
    OrderDto CreateOrder(CreateOrderRequest request, int userId, out decimal totalPrice);
}