using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories.Abstractions;

public interface IUserRepository : IRepositoryBase<User>
{
    Task<User?> GetUserByEmail(string email);
}