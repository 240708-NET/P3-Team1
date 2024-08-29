using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    /// <summary>
    /// Defines the operations specific to the repository for <see cref="Course"/> entities.
    /// </summary>
    public interface ICourseRepository : IRepository<Course>
    {
        /// <summary>
        /// Asynchronously retrieves a list of <see cref="Course"/> entities that belong to the specified category.
        /// </summary>
        /// <param name="category">The category of courses to retrieve.</param>
        /// <returns>A list of courses that belong to the specified category.</returns>
        Task<List<Course>> GetCoursesByCategory(string category);
    }
}