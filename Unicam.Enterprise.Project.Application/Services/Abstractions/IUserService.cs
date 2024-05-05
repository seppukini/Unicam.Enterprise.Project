using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Application.Models.Responses;

namespace Unicam.Enterprise.Project.Application.Services.Abstractions;

public interface IUserService
{ 
    Task<CreateUserResponse> CreateUser(CreateUserRequest request);
    Task<LoginResponse> Login(LoginRequest request);
}