using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Unicam.Enterprise.Project.Application.Models.DTOs;
using Unicam.Enterprise.Project.Application.Services.Abstractions;
using Unicam.Enterprise.Project.Infrastructure.Repositories;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Application.Services;

public class HistoryService : IHistoryService
{
    private readonly OrderRepository _orderRepository;
    private readonly UserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;

    public HistoryService(OrderRepository orderRepository, UserRepository userRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
    }

    public IEnumerable<OrderDto> GetOrderHistory(DateTime startDate, DateTime endDate, int? userId, int userRoleId, int pageIndex, int pageSize)
    {
        if (userRoleId != (int)Role.Admin && !userId.HasValue)
        {
            throw new ArgumentException("Non-admin users must provide their user ID.");
        }
        
        var orders = _orderRepository.GetOrdersBetweenDates(startDate, endDate);

        // apply a filter if the user is not an admin
        if (userRoleId != (int)Role.Admin)
        {
            orders = orders.Where(o => o.UserId == userId.Value);
        }

        return orders
            .Skip(pageSize * (pageIndex - 1))
            .Take(pageSize)
            .Select(o => _mapper.Map<OrderDto>(o))
            .ToList();
    }

}