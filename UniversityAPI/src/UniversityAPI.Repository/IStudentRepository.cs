using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<List<Student>> GetStudentsByLastName(string lastName);
        //Will return either a student or null
        Task<Student?> Login(int id, string password);
    }
}
