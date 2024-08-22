using UniversityAPI.Models;
namespace UniversityAPI.Repositories;

public interface ICourseRepository : IRepository<Course>
{
    Task<List<Course>> GetCoursesByCategory(string category);
    Course? FindById(int id);
    List<Course> GetAll();
    void DeleteAll();
    void Delete(Course course);
}

