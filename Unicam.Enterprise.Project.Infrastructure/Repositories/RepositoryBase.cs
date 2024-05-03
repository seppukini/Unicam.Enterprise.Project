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
    
    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await DbSet.ToListAsync();
    }
    
    public async Task<TEntity?> GetById(int id)
    {
        return await DbSet.FindAsync(id);
    }
    
    public async Task Insert(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }

    // no updateasync :(
    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }
    
    public async Task Delete(int id)
    {
        var entity = await DbSet.FindAsync(id);
        
        if (entity != null)
        {
            DbSet.Remove(entity);
        }
    }
    
    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}