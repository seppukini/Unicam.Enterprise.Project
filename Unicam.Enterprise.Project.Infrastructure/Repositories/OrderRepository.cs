using Microsoft.EntityFrameworkCore;
using Unicam.Enterprise.Project.Infrastructure.Context;
using Unicam.Enterprise.Project.Infrastructure.Repositories.Abstractions;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(MyDbContext context) : base(context) { }

    public async Task<IEnumerable<Order>> GetOrdersBetweenDatesAsync(DateTime startDate, DateTime endDate)
    {
        return await DbSet
            .Include(o => o.Courses)
            .Where(order => order.Date >= startDate && order.Date <= endDate)
            .ToListAsync();
    }
}