namespace UniversityAPI.Repositories;

public interface IRepository<TEntity>
{
    Task<List<TEntity>> Get();
    Task<TEntity?> GetById(int id);
    Task Insert(TEntity entity);
    Task<bool> Update(TEntity entity);
    Task<bool> DeleteById(object id);
}