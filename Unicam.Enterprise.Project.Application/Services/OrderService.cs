using AutoMapper;
using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Application.Models.Responses;
using Unicam.Enterprise.Project.Application.Services.Abstractions;
using Unicam.Enterprise.Project.Infrastructure.Repositories.Abstractions;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Application.Services;

/// <summary>
/// Service for managing orders.
/// </summary>
public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor to initialize the service with order and course repositories, and AutoMapper instances.
    /// </summary>
    /// <param name="orderRepository">The order repository instance.</param>
    /// <param name="courseRepository">The course repository instance.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public OrderService(IOrderRepository orderRepository, ICourseRepository courseRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new order.
    /// </summary>
    /// <param name="request">The create order request.</param>
    /// <param name="userId">The user ID.</param>
    /// <returns>The create order response.</returns>
    public async Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request, int userId)
    {
        var courses = await _courseRepository.FindByIds(request.CourseIds);
        if (courses.Count != request.CourseIds.Count)
        {
            throw new ArgumentException("One or more courses not found.");
        }
        
        var order = _mapper.Map<Order>(request);
        order.Date = DateTime.Now;
        order.UserId = userId;
        order.Courses.AddRange(courses);

        await _orderRepository.Insert(order);
        await _orderRepository.Save();
        
        var totalPrice = CalculateTotalPrice(order.Courses);

        return new CreateOrderResponse(order.Id, totalPrice);
    }
    
    private static decimal CalculateTotalPrice(List<Course> courses)
    {
        decimal totalPrice = 0;
        var courseGroups = courses.GroupBy(c => c.Type).ToDictionary(g 
            => g.Key, g => g.ToList());

        // Apply 10% discount on complete meals
        while (IsCompleteMeal(courseGroups))
        {
            var mealPrice = Enum.GetValues(typeof(CourseType)).Cast<CourseType>().Sum(type 
                => GetAndRemoveMostExpensive(courseGroups, type));
            totalPrice += mealPrice * 0.9m;
        }
        
        // Add remaining courses at full price
        totalPrice += courseGroups.Values.SelectMany(c => c).Sum(course => course.Price); 

        return totalPrice;
    }
    
    private static bool IsCompleteMeal(Dictionary<CourseType, List<Course>> courseGroups)
    {
        return Enum.GetValues(typeof(CourseType)).Cast<CourseType>().All(type => courseGroups.ContainsKey(type) && 
            courseGroups[type].Any());
    }
    
    private static decimal GetAndRemoveMostExpensive(Dictionary<CourseType, List<Course>> courseGroups, CourseType type)
    {
        var mostExpensive = courseGroups[type].OrderByDescending(c => c.Price).First();
        courseGroups[type].Remove(mostExpensive);
        if (!courseGroups[type].Any())
        {
            courseGroups.Remove(type);
        }
        return mostExpensive.Price;
    }
}