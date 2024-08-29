using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    /// <summary>
    /// Defines the basic operations for a repository managing entities of type <typeparamref name="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity that the repository manages. It must inherit from the <see cref="Identified"/> class.</typeparam>
    public interface IRepository<TEntity> where TEntity : Identified
    {
        /// <summary>
        /// Asynchronously retrieves all entities of type <typeparamref name="TEntity"/> from the data store.
        /// </summary>
        /// <returns>A list of all entities of type <typeparamref name="TEntity"/>.</returns>
        Task<List<TEntity>> GetAll();

        /// <summary>
        /// Asynchronously retrieves an entity of type <typeparamref name="TEntity"/> by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>The entity with the specified identifier, or <c>null</c> if no entity is found.</returns>
        Task<TEntity?> GetById(int id);

        /// <summary>
        /// Asynchronously inserts a new entity of type <typeparamref name="TEntity"/> into the data store.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <returns>The inserted entity.</returns>
        Task<TEntity?> Insert(TEntity entity);

        /// <summary>
        /// Asynchronously updates an existing entity of type <typeparamref name="TEntity"/> in the data store.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity, or <c>null</c> if the entity does not exist.</returns>
        Task<TEntity?> Update(TEntity entity);

        /// <summary>
        /// Asynchronously deletes an entity of type <typeparamref name="TEntity"/> by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to delete.</param>
        /// <returns>The deleted entity, or <c>null</c> if no entity is found.</returns>
        Task<TEntity?> DeleteById(object id);

        /// <summary>
        /// Asynchronously deletes all entities of type <typeparamref name="TEntity"/> from the data store.
        /// </summary>
        /// <returns>A list of all deleted entities.</returns>
        Task<List<TEntity>> DeleteAll();
    }
}