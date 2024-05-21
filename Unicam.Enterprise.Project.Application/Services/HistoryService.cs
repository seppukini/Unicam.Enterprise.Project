using AutoMapper;
using Unicam.Enterprise.Project.Application.Models.DTOs;
using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Application.Models.Responses;
using Unicam.Enterprise.Project.Application.Services.Abstractions;
using Unicam.Enterprise.Project.Infrastructure.Repositories.Abstractions;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Application.Services;

/// <summary>
/// Service for managing order history.
/// </summary>
public class HistoryService : IHistoryService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor to initialize the service with order and user repositories, and AutoMapper instances.
    /// </summary>
    /// <param name="orderRepository">The order repository instance.</param>
    /// <param name="userRepository">The user repository instance.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public HistoryService(IOrderRepository orderRepository, IUserRepository userRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<GetOrderHistoryResponse> GetOrderHistory(GetOrderHistoryRequest request, int userId, 
        string userRole)
    {
        var orders = await _orderRepository.GetOrdersBetweenDatesAsync(request.StartDate, 
            request.EndDate);
        orders = await ApplyRoleFilter(orders, request.UserId, userId, userRole);
        
        var totalPagesFound = (orders.Count() + request.PageSize - 1) / request.PageSize;
        
        var orderDtoList = orders
            .OrderByDescending(o => o.Date)
            .Skip(request.PageSize * (request.PageIndex - 1))
            .Take(request.PageSize)
            .Select(o => _mapper.Map<OrderDto>(o))
            .ToList();
        
        return new GetOrderHistoryResponse(orderDtoList, totalPagesFound);
    }
    
    private async Task<List<Order>> ApplyRoleFilter(IEnumerable<Order> orders, int? requestUserId, int userId, 
        string userRole)
    {
        // apply a filter if the user is not an admin
        if (userRole != Role.Admin.ToString())
        {
            return orders.Where(o => o.UserId == userId).ToList();
        }
        if (!requestUserId.HasValue)
        {
            return orders.ToList();
        }
        // apply a filter if the user is an admin and the request contains a UserId 
        var requestedUser = await _userRepository.GetById(requestUserId.Value);
        if (requestedUser == null)
        {
            throw new ArgumentException("User not found");
        }
        return orders.Where(o => o.UserId == requestUserId.Value).ToList();
    }
}