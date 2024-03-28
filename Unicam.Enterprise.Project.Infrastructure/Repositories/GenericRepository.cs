using Microsoft.EntityFrameworkCore;
using Unicam.Enterprise.Project.Infrastructure.Context;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories;

public abstract class GenericRepository<T> where T : class
{
    private MyDbContext _ctx;
    
    protected GenericRepository(MyDbContext ctx)
    {
        _ctx = ctx;
    }
    
    public void Add(T entity)
    {
        _ctx.Set<T>().Add(entity);
    }
    
    public void Update(T entity)
    {
        _ctx.Entry(entity).State = EntityState.Modified;
    }
    
    public T Get(object id)
    {
        return _ctx.Set<T>().Find(id);
    }
    
    public void Delete(object id)
    {
        var entity = _ctx.Set<T>().Find(id);
        _ctx.Entry(entity).State = EntityState.Deleted;
    }
    
    public void Save()
    {
        _ctx.SaveChanges();
    }
}