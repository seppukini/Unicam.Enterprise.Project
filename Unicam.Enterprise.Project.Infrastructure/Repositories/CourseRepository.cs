using Microsoft.EntityFrameworkCore;
using Unicam.Enterprise.Project.Infrastructure.Context;
using Unicam.Enterprise.Project.Infrastructure.Repositories.Abstractions;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories;

/// <summary>
/// Repository for managing courses.
/// </summary>
public class CourseRepository : RepositoryBase<Course>, ICourseRepository
{
    /// <summary>
    /// Constructor to initialize the repository with a DbContext instance.
    /// </summary>
    /// <param name="context">The DbContext instance.</param>
    public CourseRepository(MyDbContext context) : base(context) { }
    
    public async Task<List<Course>> FindByIds(IEnumerable<int> ids)
    {
        // Use the DbSet to retrieve courses by their IDs
        return await DbSet.Where(c => ids.Contains(c.Id)).ToListAsync();
    }
}