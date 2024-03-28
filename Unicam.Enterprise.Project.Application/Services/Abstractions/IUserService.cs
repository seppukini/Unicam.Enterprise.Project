using Unicam.Enterpise.Project.Application.Models.Dtos;

namespace Unicam.Enterpise.Project.Application.Services.Abstractions;

public interface IUserService
{
    UserDto GetUser(int id); 
}