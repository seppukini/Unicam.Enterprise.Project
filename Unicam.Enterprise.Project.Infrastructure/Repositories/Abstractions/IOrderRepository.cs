using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories.Abstractions;

/// <summary>
/// Interface for the order repository.
/// </summary>
public interface IOrderRepository : IRepositoryBase<Order>
{
    /// <summary>
    /// Gets orders between a specified date range.
    /// </summary>
    /// <param name="startDate">The start date of the range.</param>
    /// <param name="endDate">The end date of the range.</param>
    /// <returns>A collection of orders between the specified dates.</returns>
    Task<IEnumerable<Order>> GetOrdersBetweenDatesAsync(DateTime startDate, DateTime endDate);
}