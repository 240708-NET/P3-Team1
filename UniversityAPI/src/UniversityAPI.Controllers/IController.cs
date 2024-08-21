namespace UniversityAPI.Controllers;
public interface IController<T>{
    public T? GetById(int id);
    public List<T> GetAll();
    public T? Patch(T item);
    public T? DeleteById(int id);
    public List<T> DeleteAll();
}