using Microsoft.EntityFrameworkCore;
using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IIdentified
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> EntitySet;

        public GenericRepository(DbContext context)
        {
            Context = context;
            EntitySet = context.Set<TEntity>();
        }

        public virtual Task<List<TEntity>> Get()
        {
            return EntitySet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity?> GetById(int id)
        {
            return await EntitySet.AsNoTracking().SingleOrDefaultAsync(e => e.ID == id);
        }

        public virtual async Task Insert(TEntity entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            Context.Update(entity);
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntitySet.Any(e => e.ID == entity.ID))
                    return false;
                throw;
            }
            return true;
        }

        public virtual async Task<bool> DeleteById(object id)
        {
            var entity = await EntitySet.FindAsync(id);
            if (entity == null) return false;
            
            Context.Remove(entity);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}