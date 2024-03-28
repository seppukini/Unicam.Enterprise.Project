using Unicam.Enterprise.Project.Infrastructure.Context;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories;

public class CourseRepository : GenericRepository<Course>
{
    public CourseRepository(MyDbContext ctx) : base(ctx)
    {
    }
}