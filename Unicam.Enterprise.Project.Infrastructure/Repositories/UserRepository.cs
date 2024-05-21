using Microsoft.EntityFrameworkCore;
using Unicam.Enterprise.Project.Infrastructure.Context;
using Unicam.Enterprise.Project.Infrastructure.Repositories.Abstractions;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories;

/// <summary>
/// Repository for users.
/// </summary>
public class UserRepository : RepositoryBase<User>, IUserRepository
{
    /// <summary>
    /// Constructor for the user repository.
    /// </summary>
    /// <param name="context">The database context.</param>
    public UserRepository(MyDbContext context) : base(context) { }
    
    public async Task<User?> GetUserByEmail(string email)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Email == email);
    }
}