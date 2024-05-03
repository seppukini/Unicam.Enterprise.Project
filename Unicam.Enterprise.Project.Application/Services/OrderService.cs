using System.Diagnostics;
using AutoMapper;
using Unicam.Enterprise.Project.Application.Models.DTOs;
using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Application.Models.Responses;
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
    
    public async Task<CreateOrderResponse?> CreateOrder(CreateOrderRequest request, int userId)
    {
        var courses = await _courseRepository.FindByIds(request.CourseIds);
        
        if (courses.Count != request.CourseIds.Count)
        {
            throw new KeyNotFoundException("One or more courses not found.");
        }
        
        var order = _mapper.Map<Order>(request);
        order.Date = DateTime.Now;
        order.UserId = userId;
        
        foreach (var course in courses)
        {
            order.Courses?.Add(course);
        }
        
        // Calculate total price and apply discounts if applicable
        if (order.Courses == null || order.Courses.Count == 0)
        {
            return null;
        }

        decimal totalPrice = order.Courses.Sum(o => o.Price);
        if (IsCompleteMeal(order.Courses))
        {
            totalPrice *= 0.9m; // 10% discount for complete meal
        }

        await _orderRepository.Insert(order);
        await _orderRepository.Save();

        // ignore this mapping
        _ = _mapper.Map<OrderDto>(order);

        return new CreateOrderResponse(order.Id, totalPrice);
    }

    private static bool IsCompleteMeal(IEnumerable<Course> courses)
    {
        var courseTypes = courses.Select(c => c.Type).Distinct().ToList();
        return courseTypes.Count == 4 && courseTypes.Contains(CourseType.Main) &&
               courseTypes.Contains(CourseType.Second) && courseTypes.Contains(CourseType.Side) &&
               courseTypes.Contains(CourseType.Dessert);
    }
}