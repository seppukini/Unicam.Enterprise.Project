
namespace Unicam.Enterprise.Project.Model.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public Address DeliveryAddress { get; set; } = new ();
    public List<Course> Courses { get; set; } = new ();
    public int UserId { get; set; }
    
    public User? User { get; set; }
}