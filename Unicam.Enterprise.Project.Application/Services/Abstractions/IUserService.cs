using Unicam.Enterprise.Project.Application.Models.Dtos;

namespace Unicam.Enterprise.Project.Application.Services.Abstractions;

public interface IUserService
{
    UserDto GetUser(int id); 
}