namespace Unicam.Enterprise.Project.Model.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public Address DeliveryAddress { get; set; }
    public ICollection<Course> Courses { get; set; } 
    public int UserId { get; set; }
    
    public User User { get; set; }
}