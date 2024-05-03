using Unicam.Enterprise.Project.Infrastructure.Context;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories;

public class AddressRepository : RepositoryBase<Address>
{
    public AddressRepository(MyDbContext context) : base(context) { }
}