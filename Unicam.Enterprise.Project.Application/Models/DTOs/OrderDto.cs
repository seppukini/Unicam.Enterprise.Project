using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Application.Models.DTOs;

public class OrderDto
{
    public int Id { get; init; }
    public DateTime Date { get; init; }
    public Address DeliveryAddress { get; init; } = new();
    public List<CourseDto> Courses { get; init; } = new();
    public int UserId { get; init; }
}