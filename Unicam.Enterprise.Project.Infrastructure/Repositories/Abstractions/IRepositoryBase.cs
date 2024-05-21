namespace Unicam.Enterprise.Project.Infrastructure.Repositories.Abstractions;

/// <summary>
/// Base interface for repositories.
/// </summary>
/// <typeparam name="TEntity">The type of entity.</typeparam>
public interface IRepositoryBase<TEntity> where TEntity : class
{
    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>A collection of entities.</returns>
    Task<IEnumerable<TEntity>> GetAll();
    
    /// <summary>
    /// Gets an entity by ID.
    /// </summary>
    /// <param name="id">The ID of the entity.</param>
    /// <returns>The entity if found, otherwise null.</returns>
    Task<TEntity?> GetById(int id);
    
    /// <summary>
    /// Inserts a new entity.
    /// </summary>
    /// <param name="entity">The entity to insert.</param>
    Task Insert(TEntity entity);
    
    /// <summary>
    /// Updates an existing entity.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    void Update(TEntity entity);
    
    /// <summary>
    /// Deletes an entity by ID.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    Task Delete(int id);
    
    /// <summary>
    /// Saves the changes.
    /// </summary>
    Task Save();
}