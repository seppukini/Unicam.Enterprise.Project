
namespace Unicam.Enterprise.Project.Model.Entities;

/// <summary>
/// Represents a course that can be ordered by a user.
/// </summary>
public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public CourseType Type { get; set; }
    
    public IEnumerable<Order> Orders { get; set; } = new List<Order>();
}