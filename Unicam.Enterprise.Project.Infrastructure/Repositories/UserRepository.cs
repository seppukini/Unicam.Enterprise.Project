using Unicam.Enterprise.Project.Infrastructure.Context;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>
{
    public UserRepository(MyDbContext ctx) : base(ctx)
    {
    }
}