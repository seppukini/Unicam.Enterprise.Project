
namespace Unicam.Enterprise.Project.Model.Entities;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public CourseType Type { get; set; }
    
    public IEnumerable<Order>? Orders { get; set; }
}