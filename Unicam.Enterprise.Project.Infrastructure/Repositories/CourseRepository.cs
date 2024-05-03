using Microsoft.EntityFrameworkCore;
using Unicam.Enterprise.Project.Infrastructure.Context;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories;

public class CourseRepository : RepositoryBase<Course>
{
    public CourseRepository(MyDbContext context) : base(context) { }

    public async Task<List<Course>> FindByIds(IEnumerable<int> ids)
    {
        return await DbSet.Where(c => ids.Contains(c.Id)).ToListAsync();
    }
    
    public async Task<IEnumerable<Course>> GetCoursesByOrderId(int orderId)
    {
        return await DbSet
            .Where(course => (course.Orders ?? Array.Empty<Order>()).Any(order => order.Id == orderId))
            .ToListAsync();
    }
}