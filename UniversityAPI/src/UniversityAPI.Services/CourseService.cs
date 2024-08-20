using UniversityAPI.Models;
using UniversityAPI.Repository;

namespace UniversityAPI.Services;

public class CourseService : ICourseServices
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }
    
    public List<Course> DeleteAll()
    {
        var courses = _courseRepository.GetAll();
        _courseRepository.DeleteAll();
        return courses;
    }

    public Course? DeleteById(int id)
    {

        throw new NotImplementedException();

    }

    public List<Course> GetAll()
    {
        return _courseRepository.GetAll();
    }

    public Course? GetById(int id)
    {
        throw new NotImplementedException();

    }

    public Course? Update(Course item)
    {

        throw new NotImplementedException();
    }
}