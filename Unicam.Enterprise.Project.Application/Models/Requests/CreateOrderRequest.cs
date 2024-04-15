using Unicam.Enterprise.Project.Application.Models.DTOs;

namespace Unicam.Enterprise.Project.Application.Models.Requests;

public class CreateOrderRequest
{
    public DateTime Date { get; set; } = DateTime.Now;
    public AddressDto DeliveryAddress { get; set; } = new AddressDto();
    public List<int> CourseIds { get; set; } = new List<int>();
    public int UserId { get; set; }
}