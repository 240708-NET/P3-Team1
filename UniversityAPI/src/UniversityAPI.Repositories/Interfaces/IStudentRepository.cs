using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<List<Student>> GetStudentsByLastName(string lastName);
        Task<List<Section>?> GetRegisteredSections(int id);

        Task<Student?> AddSectionToStudent(int studentId, int sectionId);
        Task<Student?> DeleteSectionFromStudent(int studentId, int sectionId);
    }
}
