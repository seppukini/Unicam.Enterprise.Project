using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Application.Models.DTOs;

public class OrderDto
{
    public int Id { get; init; }
    public DateTime Date { get; init; }
    public Address DeliveryAddress { get; init; } = new ();
    public IEnumerable<CourseDto> Courses { get; init; } = new List<CourseDto>();
    public int UserId { get; init; }
}