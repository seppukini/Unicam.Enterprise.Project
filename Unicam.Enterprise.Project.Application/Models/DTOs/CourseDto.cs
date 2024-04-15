using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Application.Models.DTOs;

public class CourseDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Price { get; init; } = string.Empty;
    public CourseType Type { get; init; }
}