using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories.Abstractions;

/// <summary>
/// Interface for the user repository.
/// </summary>
public interface IUserRepository : IRepositoryBase<User>
{
    /// <summary>
    /// Gets a user by email.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <returns>The user if found, otherwise null.</returns>
    Task<User?> GetUserByEmail(string email);
}