using Unicam.Enterprise.Project.Infrastructure.Context;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User>
{
    public UserRepository(MyDbContext context) : base(context) { }
    
    public User? GetUserByEmail(string email)
    {
        return DbSet.FirstOrDefault(x => x.Email == email);
    }
}