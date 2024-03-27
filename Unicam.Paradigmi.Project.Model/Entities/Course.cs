namespace Unicam.Paradigmi.Project.Model.Entities;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;
    public CourseKindOf Type { get; set; }
    
    public ICollection<Order> Orders { get; set; } = null!;
}