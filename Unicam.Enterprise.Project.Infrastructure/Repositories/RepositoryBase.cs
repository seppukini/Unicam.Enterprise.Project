using Microsoft.EntityFrameworkCore;
using Unicam.Enterprise.Project.Infrastructure.Context;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories;

public abstract class RepositoryBase<TEntity> where TEntity : class
{
    private readonly MyDbContext _context;
    private readonly DbSet<TEntity> _dbSet;
    
    // TODO: valutare se inserire metodi asincroni
    
    protected RepositoryBase(MyDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    
    public IEnumerable<TEntity> GetAll()
    {
        return _dbSet.ToList();
    }
    
    public TEntity? GetById(int id)
    {
        return _dbSet.Find(id);
    }
    
    public void Insert(TEntity entity)
    {
        _dbSet.Add(entity);
    }
    
    public void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }
    
    public void Delete(int id)
    {
        var entity = _dbSet.Find(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }
    
    public void Save()
    {
        _context.SaveChanges();
    }
}