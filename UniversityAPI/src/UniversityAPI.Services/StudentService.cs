using UniversityAPI.Models;
using UniversityAPI.Repositories;

namespace UniversityAPI.Services;
public class StudentService : Service<Student>, IStudentServices
{
    public StudentService(IStudentRepository repository) : base(repository)
    {
    }

    public async Task<Student?> DeleteSectionFromStudent(int studentId, int sectionId)
    {
        Student? student = await ((IStudentRepository)_repository).GetById(studentId);
        if (student == null)
        {
            throw new KeyNotFoundException("Student with the specified ID does not exist.");
        }

        return await _repository.DeleteById(studentId);
    }

    public async Task<List<Section>?> GetRegisteredSections(int id)
    {
        Student? student = await ((IStudentRepository)_repository).GetById(id);
        if (student == null)
        {
            throw new KeyNotFoundException("Student with the specified ID does not exist.");
        }
        // return _studentRepository.GetRegisteredSectionsByStudentId(id);
        return null;

    }

    public Task<Student> Login(Student student)
    {
        throw new NotImplementedException();
    }

    public Task<Student> Register(Student student)
    {
        throw new NotImplementedException();
    }

    Task<Student> IStudentServices.AddSectionToStudent(int studentId, int sectionId)
    {
        throw new NotImplementedException();
    }
}