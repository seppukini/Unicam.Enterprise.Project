using System;
using System.Collections.Generic;
using System.Linq;
using Unicam.Enterprise.Project.Infrastructure.Context;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories;

public class OrderRepository : RepositoryBase<Order>
{
    public OrderRepository(MyDbContext context) : base(context) { }

    public IEnumerable<Order> GetOrdersBetweenDates(DateTime startDate, DateTime endDate)
    {
        return DbSet
            .Where(order => order.Date >= startDate && order.Date <= endDate)
            .ToList();
    }
}