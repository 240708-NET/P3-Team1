using Microsoft.EntityFrameworkCore;
using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IIdentified
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> EntitySet;

        public Repository(DbContext context)
        {
            Context = context;
            EntitySet = context.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await EntitySet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity?> GetById(int id)
        {
            return await EntitySet.AsNoTracking().SingleOrDefaultAsync(e => e.ID == id);
        }

        public virtual async Task<TEntity?> Insert(TEntity entity)
        {
            var item = await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return item.Entity;
        }

        public virtual async Task<TEntity?> Update(TEntity entity)
        {
            var item = Context.Update(entity);
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntitySet.Any(e => e.ID == entity.ID))
                    return null;
                throw;
            }
            return item.Entity;
        }

        public virtual async Task<TEntity?> DeleteById(object id)
        {
            var entity = await EntitySet.FindAsync(id);
            if (entity == null) return null;

            Context.Remove(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<List<TEntity>> DeleteAll()
        {
            var items = await EntitySet.AsNoTracking().ToListAsync();
            EntitySet.RemoveRange(items);
            await Context.SaveChangesAsync();
            return items;
        }
    }
}
