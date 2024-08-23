using UniversityAPI.Models;
using UniversityAPI.Repositories;

namespace UniversityAPI.Services;
public class StudentService : Service<Student>, IStudentServices
{
    public StudentService(IStudentRepository repository) : base(repository) { }

    public async Task<List<Section>> GetRegisteredSections(int id)
    {
        Student? student = await ((IStudentRepository)_repository).GetById(id);
        if (student == null)
        {
            throw new StudentNotFoundException();
        }
        List<Section>? sections = await ((IStudentRepository)_repository).GetRegisteredSections(id);
        if (sections == null)
        {
            throw new RepositoryException();
        }
        return sections;
    }

    public async Task<Student> Login(Student student)
    {
        var foundStudent = await ((IStudentRepository)_repository).GetById(student.ID);
        if (foundStudent == null)
        {
            throw new InvalidLoginException();
        }
        if (student.Password != foundStudent.Password)
        {
            throw new InvalidLoginException();
        }
        return foundStudent;
    }

    public async Task<Student> Register(Student student)
    {
        var registeredStudent = await ((IStudentRepository)_repository).Insert(student);
        if (registeredStudent == null)
        {
            throw new RegistrationFailedException();
        }
        return registeredStudent;
    }

    public async Task<Student> AddSectionToStudent(int studentId, int sectionId)
    {
        Student? student = await ((IStudentRepository)_repository).AddSectionToStudent(studentId, sectionId);
        if (student == null)
        {
            throw new ResourceNotFoundException();
        }
        return student;
    }

    public async Task<Student> DeleteSectionFromStudent(int studentId, int sectionId)
    {
        Student? student = await ((IStudentRepository)_repository).DeleteSectionFromStudent(studentId, sectionId);
        if (student == null)
        {
            throw new ResourceNotFoundException();
        }
        return student;
    }
}