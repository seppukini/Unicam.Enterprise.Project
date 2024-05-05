using Microsoft.EntityFrameworkCore;
using Unicam.Enterprise.Project.Infrastructure.Context;
using Unicam.Enterprise.Project.Infrastructure.Repositories.Abstractions;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(MyDbContext context) : base(context) { }
    
    public async Task<User?> GetUserByEmail(string email)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<User?> FindById(int id)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
    }
}