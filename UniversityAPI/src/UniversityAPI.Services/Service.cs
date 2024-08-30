using UniversityAPI.Models;
using UniversityAPI.Repositories;

namespace UniversityAPI.Services
{
    /// <summary>
    /// Provides a generic service layer for managing entities that implement the <see cref="Identified"/> interface.
    /// This class serves as a bridge between the controllers and the repositories, handling business logic and data validation.
    /// Implements the <see cref="IService{T}"/> interface.
    /// </summary>
    /// <typeparam name="T">The type of entity managed by this service, which must implement <see cref="Identified"/>.</typeparam>
    public class Service<T> : IService<T> where T : Identified
    {
        /// <summary>
        /// The repository used for interacting with the data store.
        /// </summary>
        protected readonly IRepository<T> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{T}"/> class with the specified repository.
        /// </summary>
        /// <param name="repository">The repository for managing the entity of type <typeparamref name="T"/>.</param>
        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Asynchronously retrieves an entity of type <typeparamref name="T"/> by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to retrieve.</param>
        /// <returns>The entity with the specified identifier.</returns>
        /// <exception cref="ResourceNotFoundException">Thrown when no entity is found with the specified identifier.</exception>
        public async Task<T> GetById(int id)
        {
            var item = await _repository.GetById(id);
            if (item == null)
            {
                throw new ResourceNotFoundException();
            }
            return item;
        }

        /// <summary>
        /// Asynchronously retrieves all entities of type <typeparamref name="T"/>.
        /// </summary>
        /// <returns>A list of all entities of type <typeparamref name="T"/>.</returns>
        public async Task<List<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        /// <summary>
        /// Asynchronously inserts a new entity of type <typeparamref name="T"/> into the data store.
        /// </summary>
        /// <param name="item">The entity to insert.</param>
        /// <returns>The inserted entity.</returns>
        /// <exception cref="ResourceCreationFailedException">Thrown when the entity could not be created.</exception>
        public async Task<T> Insert(T item)
        {
            T? insertedItem = await _repository.Insert(item);
            if (insertedItem == null)
            {
                throw new ResourceCreationFailedException();
            }
            return insertedItem;
        }

        /// <summary>
        /// Asynchronously updates an existing entity of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="item">The entity with updated values.</param>
        /// <returns>The updated entity.</returns>
        /// <exception cref="ResourceNotFoundException">Thrown when the entity to update is not found.</exception>
        /// <exception cref="ResourceUpdateFailedException">Thrown when the entity could not be updated.</exception>
        public async Task<T> Update(T item)
        {
            T? foundItem = await _repository.GetById(item.ID);
            if (foundItem == null)
            {
                throw new ResourceNotFoundException();
            }
            T? updatedItem = await _repository.Update(item);
            if (updatedItem == null)
            {
                throw new ResourceUpdateFailedException();
            }
            return updatedItem;
        }

        /// <summary>
        /// Asynchronously deletes an entity of type <typeparamref name="T"/> by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to delete.</param>
        /// <returns>The deleted entity.</returns>
        /// <exception cref="ResourceNotFoundException">Thrown when the entity to delete is not found.</exception>
        /// <exception cref="ResourceDeletionFailedException">Thrown when the entity could not be deleted.</exception>
        public async Task<T> DeleteById(int id)
        {
            T? foundItem = await _repository.GetById(id);
            if (foundItem == null)
            {
                throw new ResourceNotFoundException();
            }
            T? deletedItem = await _repository.DeleteById(id);
            if (deletedItem == null)
            {
                throw new ResourceDeletionFailedException();
            }
            return deletedItem;
        }

        /// <summary>
        /// Asynchronously deletes all entities of type <typeparamref name="T"/> from the data store.
        /// </summary>
        /// <returns>A list of deleted entities.</returns>
        public async Task<List<T>> DeleteAll()
        {
            List<T> deletedItems = await _repository.DeleteAll();
            return deletedItems;
        }
    }
}
