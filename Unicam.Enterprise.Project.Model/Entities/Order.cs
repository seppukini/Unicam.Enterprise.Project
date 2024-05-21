
namespace Unicam.Enterprise.Project.Model.Entities;

/// <summary>
/// Represents an order made by a user. An order is compose by some courses and a delivery address.
/// </summary>
public class Order
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public Address DeliveryAddress { get; set; } = new ();
    public List<Course> Courses { get; set; } = new ();
    public int UserId { get; set; }

    public User? User { get; set; }
}