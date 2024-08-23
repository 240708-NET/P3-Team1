using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public interface ISectionRepository : IRepository<Section>
    {
        Task<List<Section>?> GetSectionsByCourseID(int courseID);
        Task<Section?> AddStudentToSection(int sectionId, int studentId);
        Task<Section?> DeleteStudentFromSection(int sectionId, int studentId);
        Task<List<Student>?> GetRegisteredStudents(int id);
    }
}
