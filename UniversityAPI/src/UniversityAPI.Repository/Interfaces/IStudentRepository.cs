using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<List<Student>> GetStudentsByLastName(string lastName);
    }
}
