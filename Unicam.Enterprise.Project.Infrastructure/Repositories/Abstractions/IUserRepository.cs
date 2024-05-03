using Unicam.Enterprise.Project.Infrastructure.Repositories.Abstractions;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories;

public interface IUserRepository : IRepositoryBase<User>
{
    Task<User?> GetUserByEmail(string email);
    Task<User?> FindById(int id);
}