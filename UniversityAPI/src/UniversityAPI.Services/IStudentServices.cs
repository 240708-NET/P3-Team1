using UniversityAPI.Models;

namespace UniversityAPI.Services;

public interface IStudentServices : IService<Student>
{
    public Student Login(Student student);
    public Student Register(Student student);
    public List<Section> GetRegisteredSections(int id);
    public Student AddSectionToStudent(int studentId, int sectionId);
    public Student DeleteSectionFromStudent(int studentId, int sectionId);

}