using Unicam.Paradigmi.Project.Infrastructure.Context;
using Unicam.Paradigmi.Project.Model.Entities;

namespace Unicam.Paradigmi.Project.Infrastructure.Repositories;

public class CourseRepository : GenericRepository<Course>
{
    public CourseRepository(MyDbContext ctx) : base(ctx)
    {
    }
}