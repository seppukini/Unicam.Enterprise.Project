using AutoMapper;
using Unicam.Enterprise.Project.Application.Models.DTOs;
using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Application.Services.Abstractions;
using Unicam.Enterprise.Project.Infrastructure.Repositories;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Application.Services;

public class HistoryService : IHistoryService
{
    private readonly OrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public HistoryService(OrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public IEnumerable<OrderDto> GetOrderHistory(GetOrderHistoryRequest request, int userId, string userRole)
    {
        var orders = _orderRepository.GetOrdersBetweenDates(request.StartDate, request.EndDate);
        // apply a filter if the user is not an admin
        if (userRole != Role.Admin.ToString())
        {
            orders = orders.Where(o => o.UserId == userId);
        }
        
        return orders
            .Skip(request.PageSize * (request.PageIndex - 1))
            .Take(request.PageSize)
            .Select(o => _mapper.Map<OrderDto>(o))
            .ToList();
    }
}