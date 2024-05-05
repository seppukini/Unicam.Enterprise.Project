using Microsoft.EntityFrameworkCore;
using Unicam.Enterprise.Project.Infrastructure.Context;
using Unicam.Enterprise.Project.Infrastructure.Repositories.Abstractions;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories;

public class CourseRepository : RepositoryBase<Course>, ICourseRepository
{
    public CourseRepository(MyDbContext context) : base(context) { }

    public async Task<List<Course>> FindByIds(IEnumerable<int> ids)
    {
        return await DbSet.Where(c => ids.Contains(c.Id)).ToListAsync();
    }
}