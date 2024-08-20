using UniversityAPI.Models;

namespace UniversityAPI.Repository;

public interface ICourseRepository
{
        Course? FindById(int id); // Ensure this method is defined correctly
        List<Course> GetAll();
        void DeleteAll();
        void Delete(Course course);
        void Update(Course course);
}