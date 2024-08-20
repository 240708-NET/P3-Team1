using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<List<Course>> GetCoursesByCategory(string category);
    }
}
