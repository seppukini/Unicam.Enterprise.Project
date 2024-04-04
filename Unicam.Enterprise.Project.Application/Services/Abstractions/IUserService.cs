using Unicam.Enterprise.Project.Application.Models.DTOs;
using Unicam.Enterprise.Project.Application.Models.Requests;

namespace Unicam.Enterprise.Project.Application.Services.Abstractions;

public interface IUserService
{ 
    UserDto CreateUser(CreateUserRequest request);
    string Login(LoginRequest request);
}