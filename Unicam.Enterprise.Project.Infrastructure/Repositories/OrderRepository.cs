using Unicam.Paradigmi.Project.Infrastructure.Context;
using Unicam.Paradigmi.Project.Model.Entities;

namespace Unicam.Paradigmi.Project.Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Order>
{
    public OrderRepository(MyDbContext ctx) : base(ctx)
    {
    }
}