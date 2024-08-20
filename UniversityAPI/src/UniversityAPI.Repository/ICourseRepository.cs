namespace UniversityAPI.Repositories
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<List<Course>> GetCoursesByCategory(string category);
    }
}
