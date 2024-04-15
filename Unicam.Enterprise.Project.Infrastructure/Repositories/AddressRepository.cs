using Unicam.Enterprise.Project.Infrastructure.Context;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories;

// TODO: review how relationships between items in repositories work.
public class AddressRepository : RepositoryBase<Address>
{
    public AddressRepository(MyDbContext context) : base(context) { }
}