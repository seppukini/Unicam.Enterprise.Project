using Microsoft.EntityFrameworkCore;
using Unicam.Enterprise.Project.Infrastructure.Context;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories;

public abstract class RepositoryBase<TEntity> where TEntity : class
{
    private readonly MyDbContext _context;
    protected readonly DbSet<TEntity> DbSet;
    
    // TODO: consider adding async methods
    
    protected RepositoryBase(MyDbContext context)
    {
        _context = context;
        DbSet = context.Set<TEntity>();
    }
    
    public IEnumerable<TEntity> GetAll()
    {
        return DbSet.ToList();
    }
    
    public TEntity? GetById(int id)
    {
        return DbSet.Find(id);
    }
    
    public void Insert(TEntity entity)
    {
        DbSet.Add(entity);
    }
    
    public void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }
    
    public void Delete(int id)
    {
        var entity = DbSet.Find(id);
        if (entity != null)
        {
            DbSet.Remove(entity);
        }
    }
    
    public void Save()
    {
        _context.SaveChanges();
    }
}