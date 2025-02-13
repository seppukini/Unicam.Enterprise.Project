using Microsoft.EntityFrameworkCore;
using Unicam.Enterprise.Project.Infrastructure.Context;
using Unicam.Enterprise.Project.Infrastructure.Repositories.Abstractions;

namespace Unicam.Enterprise.Project.Infrastructure.Repositories;

/// <summary>
/// Abstract base class for repositories that provides basic CRUD operations.
/// </summary>
/// <typeparam name="TEntity">The type of entity.</typeparam>
public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    private readonly MyDbContext _context;
    protected readonly DbSet<TEntity> DbSet;
    
    /// <summary>
    /// Constructor to initialize the repository with a DbContext instance.
    /// </summary>
    /// <param name="context"></param>
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