using Unicam.Paradigmi.Project.Model.Entities;

namespace Unicam.Paradigmi.Project.Application.Models.Dtos;

public class UserDto
{
    public UserDto(User user)
    {
        
    }
    
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}