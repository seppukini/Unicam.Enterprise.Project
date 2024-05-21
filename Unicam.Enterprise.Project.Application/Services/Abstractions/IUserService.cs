using Unicam.Enterprise.Project.Application.Models.Requests;
using Unicam.Enterprise.Project.Application.Models.Responses;

namespace Unicam.Enterprise.Project.Application.Services.Abstractions;

/// <summary>
/// Interface for the user service.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="request">The create user request.</param>
    /// <returns>The create user response.</returns>
    Task<CreateUserResponse> CreateUser(CreateUserRequest request);

    /// <summary>
    /// Logs in a user.
    /// </summary>
    /// <param name="request">The login request.</param>
    /// <returns>The login response.</returns>
    Task<LoginResponse> Login(LoginRequest request);
}