namespace Unicam.Paradigmi.Project.Model.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public Address Address { get; set; }
    public ICollection<Course> Courses { get; set; } 
    public User User { get; set; } 
}