namespace Unicam.Enterprise.Project.Infrastructure.Repositories.Abstractions;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity?> GetById(int id);
    Task Insert(TEntity entity);
    void Update(TEntity entity);
    Task Delete(int id);
    Task Save();
}