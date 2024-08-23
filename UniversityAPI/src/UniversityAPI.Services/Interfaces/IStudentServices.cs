using UniversityAPI.Models;

namespace UniversityAPI.Services;

public interface IStudentServices : IService<Student>
{
    public Task<Student> Login(Student student);
    public Task<Student> Register(Student student);
    public Task<List<Section>> GetRegisteredSections(int id);
    public Task<Student> AddSectionToStudent(int studentId, int sectionId);
    public Task<Student> DeleteSectionFromStudent(int studentId, int sectionId);

}