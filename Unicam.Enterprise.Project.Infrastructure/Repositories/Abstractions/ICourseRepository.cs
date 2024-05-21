using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories.Abstractions;

/// <summary>
/// Interface for the course repository.
/// </summary>
public interface ICourseRepository : IRepositoryBase<Course>
{
    /// <summary>
    /// Finds courses by their IDs.
    /// </summary>
    /// <param name="ids">The IDs of the courses to find.</param>
    /// <returns>A list of courses matching the specified IDs.</returns>
    Task<List<Course>> FindByIds(IEnumerable<int> ids);
}