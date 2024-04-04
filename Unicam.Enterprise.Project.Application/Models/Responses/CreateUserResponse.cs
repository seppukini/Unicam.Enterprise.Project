using Unicam.Enterprise.Project.Application.Models.DTOs;

namespace Unicam.Enterprise.Project.Application.Models.Responses;

public class CreateUserResponse
{
    public CreateUserResponse(UserDto user)
    {
        User = user;
    }

    public UserDto User { get; set; }
}