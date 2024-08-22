using Microsoft.EntityFrameworkCore;
using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        protected readonly UniversityContext _context;

        public CourseRepository(UniversityContext context) : base(context)
        {
            _context = context;
        }

        public void Delete(Course course)
        {
            throw new NotImplementedException();
        }

        public Course? FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Course>> GetCoursesByCategory(string category)
        {
            return await _context.Courses
                                 .Where(course => course.Category == category)
                                 .ToListAsync();
        }

        void ICourseRepository.DeleteAll()
        {
            throw new NotImplementedException();
        }

        List<Course> ICourseRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
