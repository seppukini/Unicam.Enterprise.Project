using Unicam.Enterprise.Project.Infrastructure.Context;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories;

public class UserRepositoryBase : RepositoryBase<User>
{
    public UserRepositoryBase(MyDbContext context) : base(context)
    {
    }
}