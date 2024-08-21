using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<List<Student>> GetStudentsByLastName(string lastName);

        Student CreateStudent(Student student);
        List<Student> GetAllStudents();
        Student? GetStudentById(int id);
        Student? UpdateStudent(Student student);
        Student? DeleteStudentById(int id);
        List<Student> DeleteAllStudents();
        List<Section> GetRegisteredSectionsByStudentId(int id);
    }
}
