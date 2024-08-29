using Microsoft.EntityFrameworkCore;
using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    /// <summary>
    /// Provides a generic repository implementation for entities that inherit from the <see cref="Identified"/> base class.
    /// This repository offers common data operations such as retrieving all entities, retrieving by ID, 
    /// inserting, updating, and deleting entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity that this repository manages. It must inherit from the <see cref="Identified"/> base class.</typeparam>
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Identified
    {
        /// <summary>
        /// The database context used for interacting with the data store.
        /// </summary>
        protected readonly DbContext Context;

        /// <summary>
        /// The DbSet representing the collection of entities of type <typeparamref name="TEntity"/> in the context.
        /// </summary>
        protected readonly DbSet<TEntity> EntitySet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class with the specified database context.
        /// </summary>
        /// <param name="context">The database context used for interacting with the data store.</param>
        public Repository(DbContext context)
        {
            Context = context;
            EntitySet = context.Set<TEntity>();
        }

        /// <summary>
        /// Asynchronously retrieves all entities of type <typeparamref name="TEntity"/> from the data store.
        /// </summary>
        /// <returns>A list of all entities of type <typeparamref name="TEntity"/>.</returns>
        public virtual async Task<List<TEntity>> GetAll()
        {
            return await EntitySet.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Asynchronously retrieves an entity of type <typeparamref name="TEntity"/> by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>The entity with the specified identifier, or <c>null</c> if no entity is found.</returns>
        public virtual async Task<TEntity?> GetById(int id)
        {
            return await EntitySet.AsNoTracking().SingleOrDefaultAsync(e => e.ID == id);
        }

        /// <summary>
        /// Asynchronously inserts a new entity of type <typeparamref name="TEntity"/> into the data store.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <returns>The inserted entity.</returns>
        public virtual async Task<TEntity?> Insert(TEntity entity)
        {
            var item = await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return item.Entity;
        }

        /// <summary>
        /// Asynchronously updates an existing entity of type <typeparamref name="TEntity"/> in the data store.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity, or <c>null</c> if the entity does not exist.</returns>
        /// <exception cref="DbUpdateConcurrencyException">Thrown when a concurrency violation occurs during update.</exception>
        public virtual async Task<TEntity?> Update(TEntity entity)
        {
            var item = Context.Update(entity);
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EntitySet.AnyAsync(e => e.ID == entity.ID))
                    return null;
                throw;
            }
            return item.Entity;
        }

        /// <summary>
        /// Asynchronously deletes an entity of type <typeparamref name="TEntity"/> by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to delete.</param>
        /// <returns>The deleted entity, or <c>null</c> if no entity is found.</returns>
        public virtual async Task<TEntity?> DeleteById(object id)
        {
            var entity = await EntitySet.FindAsync(id);
            if (entity == null) return null;

            Context.Remove(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Asynchronously deletes all entities of type <typeparamref name="TEntity"/> from the data store.
        /// </summary>
        /// <returns>A list of all deleted entities.</returns>
        public virtual async Task<List<TEntity>> DeleteAll()
        {
            var items = await EntitySet.AsNoTracking().ToListAsync();
            EntitySet.RemoveRange(items);
            await Context.SaveChangesAsync();
            return items;
        }
    }
}