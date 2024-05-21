using Microsoft.EntityFrameworkCore;
using Unicam.Enterprise.Project.Infrastructure.Context;
using Unicam.Enterprise.Project.Infrastructure.Repositories.Abstractions;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories;

/// <summary>
/// Repository for managing orders.
/// </summary>
public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    /// <summary>
    /// Constructor to initialize the repository with a DbContext instance.
    /// </summary>
    /// <param name="context">The DbContext instance.</param>
    public OrderRepository(MyDbContext context) : base(context) { }

    /// <summary>
    /// Retrieves orders between the specified dates.
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <returns>A list of orders between the specified dates.</returns>
    public async Task<IEnumerable<Order>> GetOrdersBetweenDatesAsync(DateTime startDate, DateTime endDate)
    {
        // Use the DbSet to retrieve orders between the specified dates
        // Include the Courses navigation property
        return await DbSet
            .Include(o => o.Courses)
            .Where(order => order.Date >= startDate && order.Date <= endDate)
            .ToListAsync();
    }
}