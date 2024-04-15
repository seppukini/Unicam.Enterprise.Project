namespace Unicam.Enterprise.Project.Model.Entities;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;
    public CourseType Type { get; set; }
    
    public IEnumerable<Order> Orders { get; set; } = new List<Order>();
}