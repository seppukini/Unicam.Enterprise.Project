using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Unicam.Enterprise.Project.Application.Models.DTOs;
using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Application.Services.Abstractions;
using Unicam.Enterprise.Project.Infrastructure.Repositories;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Application.Services;

public class OrderService : IOrderService
{
    private readonly OrderRepository _orderRepository;
    private readonly CourseRepository _courseRepository;
    private readonly UserRepository _userRepository;
    private readonly IMapper _mapper;

    public OrderService(OrderRepository orderRepository, CourseRepository courseRepository, UserRepository userRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _courseRepository = courseRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public OrderDto CreateOrder(CreateOrderRequest request)
    {
        var user = _userRepository.FindById(request.UserId);
        if (user == null)
        {
            throw new KeyNotFoundException("User not found.");
        }

        var courses = _courseRepository.FindByIds(request.CourseIds);
        if (courses.Count != request.CourseIds.Count)
        {
            throw new KeyNotFoundException("One or more courses not found.");
        }

        var order = new Order
        {
            Date = request.Date,
            DeliveryAddress = _mapper.Map<Address>(request.DeliveryAddress),
            UserId = user.Id,
            Courses = courses
        };

        _orderRepository.Insert(order);
        _orderRepository.Save();

        return _mapper.Map<OrderDto>(order);
    }

    public IEnumerable<OrderDto> GetOrders()
    {
        var orders = _orderRepository.GetAll();
        return orders.Select(order => _mapper.Map<OrderDto>(order));
    }
}