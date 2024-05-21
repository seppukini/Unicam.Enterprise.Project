
namespace Unicam.Enterprise.Project.Model.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public Address DeliveryAddress { get; set; } = new ();

    // An order is compose by some courses
    public List<Course> Courses { get; set; } = new ();

    // Who made the order
    public int UserId { get; set; }

    public User? User { get; set; }
}