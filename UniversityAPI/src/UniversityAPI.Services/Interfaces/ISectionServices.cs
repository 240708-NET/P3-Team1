using UniversityAPI.Models;

namespace UniversityAPI.Services;

public interface ISectionServices : IService<Section>
{
    public Task<Section> AddStudentToSection(int sectionId, int studentId);
    public Task<Section> DeleteStudentFromSection(int sectionId, int studentId);
    public Task<List<Student>> GetRegisteredStudents(int id);
}