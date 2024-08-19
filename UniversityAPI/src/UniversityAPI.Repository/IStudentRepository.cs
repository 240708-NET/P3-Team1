using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<List<Student>> GetStudentsByLastName(string lastName);
    }
}