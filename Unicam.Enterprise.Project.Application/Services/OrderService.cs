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
    private readonly IMapper _mapper;
    
    public OrderService(OrderRepository orderRepository, CourseRepository courseRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _courseRepository = courseRepository;
        _mapper = mapper;
    }
    
    public OrderDto CreateOrder(CreateOrderRequest request, int userId, out decimal totalPrice)
    {
        var courses = _courseRepository.FindByIds(request.CourseIds);
        if (courses.Count != request.CourseIds.Count)
        {
            throw new KeyNotFoundException("One or more courses not found.");
        }
        
        var order = _mapper.Map<Order>(request);
        order.Date = DateTime.Now;
        order.UserId = userId;
        foreach (var course in courses)
        {
            order.Courses.Add(course);
        }
        
        // Calculate total price and apply discounts if applicable
        totalPrice = order.Courses.Sum(o => o.Price);
        if (IsCompleteMeal(order.Courses))
        {
            totalPrice *= 0.9m; // 10% discount for complete meal
        }
        
        _orderRepository.Insert(order);
        _orderRepository.Save();
        
        return _mapper.Map<OrderDto>(order);
    }

    private static bool IsCompleteMeal(IEnumerable<Course> courses)
    {
        var courseTypes = courses.Select(c => c.Type).Distinct().ToList();
        return courseTypes.Count == 4 && courseTypes.Contains(CourseType.Main) &&
               courseTypes.Contains(CourseType.Second) && courseTypes.Contains(CourseType.Side) &&
               courseTypes.Contains(CourseType.Dessert);
    }
}