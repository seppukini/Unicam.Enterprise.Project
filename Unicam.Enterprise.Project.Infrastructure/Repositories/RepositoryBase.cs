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
    
    protected RepositoryBase(MyDbContext context)
    {
        _context = context;
        DbSet = context.Set<TEntity>();
    }

    /// <summary>
    /// Retrieves all entities of type TEntity.
    /// </summary>
    /// <returns>A list of TEntity instances.</returns>
    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await DbSet.ToListAsync();
    }

    /// <summary>
    /// Retrieves an entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity.</param>
    /// <returns>The TEntity instance if found, otherwise null.</returns>
    public async Task<TEntity?> GetById(int id)
    {
        return await DbSet.FindAsync(id);
    }

    /// <summary>
    /// Inserts a new entity.
    /// </summary>
    /// <param name="entity">The TEntity instance to insert.</param>
    public async Task Insert(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }

    /// <summary>
    /// Updates an existing entity.
    /// </summary>
    /// <param name="entity">The TEntity instance to update.</param>
    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    /// <summary>
    /// Deletes an entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    public async Task Delete(int id)
    {
        var entity = await DbSet.FindAsync(id);
        
        if (entity != null)
        {
            DbSet.Remove(entity);
        }
    }

    /// <summary>
    /// Saves changes to the database.
    /// </summary>
    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}