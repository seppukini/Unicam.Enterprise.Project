namespace Unicam.Enterprise.Project.Model.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public Address DeliveryAddress { get; set; } = new Address();
    public ICollection<Course> Courses { get; set; } = new List<Course>();
    public int UserId { get; set; }
    
    public User User { get; set; } = new User();
}