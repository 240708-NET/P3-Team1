using UniversityAPI.Models;

namespace UniversityAPI.Services;

public interface ISectionServices : IService<Section>
{
    public Student AddSectionToStudent(int sectionId, int studentId);
    public Student DeleteSectionFromStudent(int sectionId, int studentId);
    public List<Student> GetRegisteredSections(int id);
}