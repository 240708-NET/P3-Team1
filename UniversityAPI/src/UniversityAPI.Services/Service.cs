using UniversityAPI.Models;
using UniversityAPI.Repositories;

namespace UniversityAPI.Services;

public class Service<T> : IService<T> where T : Identified
{
    protected readonly IRepository<T> _repository;

    public Service(IRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<T> GetById(int id)
    {
        var item = await _repository.GetById(id);
        if (Equals(item, default(T)))
        {
            throw new KeyNotFoundException("Student with the specified ID does not exist.");
        }
        return item;
    }

    public async Task<List<T>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<T> Insert(T item)
    {
        T? insertedItem = await _repository.Insert(item);
        return insertedItem;
    }

    public async Task<T> Update(T item)
    {
        T? updatedItem = await _repository.Update(item);
        return updatedItem;
    }

    public async Task<T> DeleteById(int id)
    {
        T? deletedItem = await _repository.DeleteById(id);
        return deletedItem;
    }
    public async Task<List<T>> DeleteAll()
    {
        List<T> deletedItems = await _repository.DeleteAll();
        return deletedItems;
    }
}
