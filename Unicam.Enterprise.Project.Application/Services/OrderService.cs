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

    public OrderService(OrderRepository orderRepository, CourseRepository courseRepository,
        UserRepository userRepository, IMapper mapper)
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
            UserId = user.Id,
            Date = request.Date,
            DeliveryAddress = _mapper.Map<Address>(request.DeliveryAddress),
            Courses = new List<Course>()
        };

        foreach (var course in courses)
        {
            order.Courses.Add(course);
        }

        // Calculate total price and apply discounts if applicable
        decimal totalPrice = order.Courses.Sum(c => decimal.Parse(c.Price));
        if (IsCompleteMeal(order.Courses))
        {
            totalPrice *= 0.9m; // 10% discount for complete meal
        }

        _orderRepository.Insert(order);
        _orderRepository.Save();

        return new OrderDto
        {
            Id = order.Id,
            Date = order.Date,
            DeliveryAddress = _mapper.Map<AddressDto>(order.DeliveryAddress),
            Courses = _mapper.Map<List<CourseDto>>(order.Courses),
            UserId = order.UserId,
            User = _mapper.Map<UserDto>(user),
            TotalPrice = totalPrice.ToString("F2")
        };
    }

    private bool IsCompleteMeal(ICollection<Course> courses)
    {
        var courseTypes = courses.Select(c => c.Type).Distinct().ToList();
        
        return courseTypes.Count == 4 && courseTypes.Contains(CourseType.Main) &&
               courseTypes.Contains(CourseType.Second) && courseTypes.Contains(CourseType.Side) &&
               courseTypes.Contains(CourseType.Dessert);
    }


    public IEnumerable<OrderDto> GetOrders()
    {
        var orders = _orderRepository.GetAll();
        return orders.Select(order => _mapper.Map<OrderDto>(order));
    }
}