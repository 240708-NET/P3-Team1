using UniversityAPI.Models;

namespace UniversityAPI.Services;

public interface IStudentServices : IService<Student>
{
    Task<Student?> Login(Student student);
    Task<Student> Register(Student student); 
    public List<Section> GetRegisteredSections(int id);
    public Student AddSectionToStudent(int studentId, int sectionId);
    public Student DeleteSectionFromStudent(int studentId, int sectionId);

}