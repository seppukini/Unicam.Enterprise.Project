
namespace Unicam.Enterprise.Project.Application.Models.DTOs;

/// <summary>
/// Data transfer object for a course.
/// </summary>
public class CourseDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Price { get; init; } = string.Empty;
    public string Type { get; init; } = string.Empty;
}