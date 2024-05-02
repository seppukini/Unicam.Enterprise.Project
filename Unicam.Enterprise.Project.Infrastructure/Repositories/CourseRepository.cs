using Unicam.Enterprise.Project.Infrastructure.Context;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories;

public class CourseRepository : RepositoryBase<Course>
{
    public CourseRepository(MyDbContext context) : base(context) { }

    public List<Course> FindByIds(IEnumerable<int> ids)
    {
        return DbSet.Where(c => ids.Contains(c.Id)).ToList();
    }
    
    public IEnumerable<Course> GetCoursesByOrderId(int orderId)
    {
        return DbSet
            .Where(course => course.Orders.Any(order => order.Id == orderId))
            .ToList();
    }
}