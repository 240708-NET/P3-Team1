using UniversityAPI.Models;
using UniversityAPI.Repositories;

namespace UniversityAPI.Services;

public class CourseService : Service<Course>, ICourseServices
{
    public CourseService(ICourseRepository repository) : base(repository)
    {
    }
}