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
            throw new StudentNotFoundException();
        }

        return await _repository.DeleteById(studentId);
    }

    public async Task<List<Section>?> GetRegisteredSections(int id)
    {
        Student? student = await ((IStudentRepository)_repository).GetById(id);
        if (student == null)
        {
            throw new StudentNotFoundException();
        }
        // return _studentRepository.GetRegisteredSectionsByStudentId(id);
        return null;

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

    Task<Student> IStudentServices.AddSectionToStudent(int studentId, int sectionId)
    {
        throw new NotImplementedException();
    }
}