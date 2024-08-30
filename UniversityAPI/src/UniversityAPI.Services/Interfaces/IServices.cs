using UniversityAPI.Models;
using UniversityAPI.Repositories;

namespace UniversityAPI.Services;

/// <summary>
/// Generic service interface that defines the basic CRUD operations
/// for entities that inherit from the <see cref="Identified"/> class.
/// </summary>
/// <typeparam name="T">The type of the entity that implements the <see cref="Identified"/> interface.</typeparam>
public interface IService<T> where T : Identified
{
    /// <summary>
    /// Retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the entity with the specified identifier.</returns>
    public Task<T> GetById(int id);

    /// <summary>
    /// Retrieves all entities of type <typeparamref name="T"/>.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of all entities.</returns>
    public Task<List<T>> GetAll();

    /// <summary>
    /// Inserts a new entity of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="item">The entity to be inserted.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the inserted entity.</returns>
    public Task<T> Insert(T item);

    /// <summary>
    /// Updates an existing entity of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="item">The entity to be updated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated entity.</returns>
    public Task<T> Update(T item);

    /// <summary>
    /// Deletes an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deleted entity.</returns>
    public Task<T> DeleteById(int id);

    /// <summary>
    /// Deletes all entities of type <typeparamref name="T"/>.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of the deleted entities.</returns>
    public Task<List<T>> DeleteAll();
}
