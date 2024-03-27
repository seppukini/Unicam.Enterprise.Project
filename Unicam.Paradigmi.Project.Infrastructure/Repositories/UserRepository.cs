using Unicam.Paradigmi.Project.Infrastructure.Context;
using Unicam.Paradigmi.Project.Model.Entities;

namespace Unicam.Paradigmi.Project.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>
{
    public UserRepository(MyDbContext ctx) : base(ctx)
    {
    }
}