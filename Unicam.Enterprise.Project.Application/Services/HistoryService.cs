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
    private readonly UserRepository _userRepository;
    private readonly IMapper _mapper;

    public HistoryService(OrderRepository orderRepository, UserRepository userRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public IEnumerable<OrderDto> GetOrderHistory(GetOrderHistoryRequest request, int userId, string userRole)
    {
        var orders = _orderRepository.GetOrdersBetweenDates(request.StartDate, request.EndDate);
        
        // apply a filter if the user is an admin and the request contains a UserId
        if (request.UserId.HasValue && userRole == Role.Admin.ToString())
        {
            if (_userRepository.GetById(request.UserId.Value) == null)
            {
                throw new ArgumentException("User not found");
            }
            orders = orders.Where(o => o.UserId == request.UserId);
        }
        // apply a filter if the user is not an admin
        else
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