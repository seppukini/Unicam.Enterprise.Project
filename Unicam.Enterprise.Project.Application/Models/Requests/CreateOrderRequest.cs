using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Application.Models.Requests;

public class CreateOrderRequest
{
    public Address DeliveryAddress { get; set; } = new();
    public List<int> CourseIds { get; set; } = new();
}