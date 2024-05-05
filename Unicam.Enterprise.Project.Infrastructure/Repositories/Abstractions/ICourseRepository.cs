using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories.Abstractions;

public interface ICourseRepository : IRepositoryBase<Course>
{
    Task<List<Course>> FindByIds(IEnumerable<int> ids);
}