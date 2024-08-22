using UniversityAPI.Models;

namespace UniversityAPI.Repositories;

public interface IRepository<TEntity> where TEntity : IIdentified
{
    Task<List<TEntity>> GetAll();
    Task<TEntity?> GetById(int id);
    Task<TEntity?> Insert(TEntity entity);
    Task<TEntity?> Update(TEntity entity);
    Task<TEntity?> DeleteById(object id);
    Task<List<TEntity>> DeleteAll();
}