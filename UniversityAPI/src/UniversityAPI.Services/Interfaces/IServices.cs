using UniversityAPI.Models;
using UniversityAPI.Repositories;

namespace UniversityAPI.Services;

public interface IService<T> where T : Identified
{
    public Task<T> GetById(int id);
    public Task<List<T>> GetAll();
    public Task<T> Insert(T item);
    public Task<T> Update(T item);
    public Task<T> DeleteById(int id);
    public Task<List<T>> DeleteAll();
}
