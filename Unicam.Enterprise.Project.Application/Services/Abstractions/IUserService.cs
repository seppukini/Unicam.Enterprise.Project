using Unicam.Enterprise.Project.Application.Models.DTOs;
using Unicam.Enterprise.Project.Application.Models.Requests;

namespace Unicam.Enterprise.Project.Application.Services.Abstractions;

public interface IUserService
{ 
    Task<UserDto> CreateUser(CreateUserRequest request);
    Task<string> Login(LoginRequest request);
}