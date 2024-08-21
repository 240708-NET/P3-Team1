using UniversityAPI.Models;

namespace UniversityAPI.Services;

public interface IService<T> where T : IIdentified
{
    public T GetById(int id);
    public List<T> GetAll();
    public T Insert(T item);
    public T Update(T item);
    public T DeleteById(int id);
    public List<T> DeleteAll();
}