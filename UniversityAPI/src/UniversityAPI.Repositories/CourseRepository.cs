using Microsoft.EntityFrameworkCore;
using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    /// <summary>
    /// Provides a repository for managing <see cref="Course"/> entities, offering specific data operations related to courses.
    /// Inherits from the generic <see cref="Repository{Course}"/> class and implements the <see cref="ICourseRepository"/> interface.
    /// </summary>
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        /// <summary>
        /// The database context specific to the University API used for interacting with the data store.
        /// </summary>
        protected readonly UniversityContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseRepository"/> class with the specified <see cref="UniversityContext"/>.
        /// </summary>
        /// <param name="context">The University API database context.</param>
        public CourseRepository(UniversityContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Asynchronously retrieves a list of <see cref="Course"/> entities that belong to the specified category.
        /// </summary>
        /// <param name="category">The category of courses to retrieve.</param>
        /// <returns>A list of courses that belong to the specified category.</returns>
        public async Task<List<Course>> GetCoursesByCategory(string category)
        {
            return await _context.Courses
                                 .Where(course => course.Category == category)
                                 .ToListAsync();
        }
    }
}