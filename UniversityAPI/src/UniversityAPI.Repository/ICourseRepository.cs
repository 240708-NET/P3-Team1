using UniversityAPI.Models;

namespace UniversityAPI.Repository;

public interface ICourseRepository
{
        Course? FindById(int id);
        List<Course> GetAll();
        void DeleteAll();
        void Delete(Course course);
        void Update(Course course);
}