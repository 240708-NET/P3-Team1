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

    /*public async Task<List<Section>?> GetRegisteredSections(int studentId)
    {
        Student? student = await ((IStudentRepository)_repository).GetById(studentId);
        if (student == null)
        {
            throw new StudentNotFoundException();
        }
        // return _studentRepository.GetRegisteredSectionsByStudentId(id);
        return null;

    }*/

    public async Task<List<Section>?> GetRegisteredSections(int studentId)
{
    //Fetch the student along with their sections
    var student = await _repository.GetById(studentId);
    if (student == null)
    {
        throw new StudentNotFoundException();
    }

    //Return the sections that the student is registered in
    return student.Sections.ToList();
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