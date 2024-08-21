using UniversityAPI.Models;
using UniversityAPI.Repositories;

namespace UniversityAPI.Services;
public class StudentService : IStudentServices
{

    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public List<Student> DeleteAll()
    {
        try
        {
            return _studentRepository.DeleteAllStudents();
        }
        catch (Exception)
        {
            throw new InvalidOperationException("An error occurred while deleting all students.");
        }
    }

    public Student? DeleteById(int id)
    {
        try
        {
            Student? student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                throw new KeyNotFoundException("Student with the specified ID does not exist.");
            }

            return _studentRepository.DeleteStudentById(id);
        }
        catch (KeyNotFoundException)
        {
            throw;
        }
        catch (Exception)
        {
            throw new InvalidOperationException("An error occurred while deleting the student.");
        }
    }

    public List<Student> GetAll()
    {
        try
        {
            return _studentRepository.GetAllStudents();
        }
        catch (Exception)
        {
            throw new InvalidOperationException("An error occurred while retrieving all students.");
        }
    }

    public Student? GetById(int id)
    {
        try
        {
            Student? student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                throw new KeyNotFoundException("Student with the specified ID does not exist.");
            }
            return student;
        }
        catch (KeyNotFoundException)
        {
            throw;
        }
        catch (Exception)
        {
            throw new InvalidOperationException("An error occurred while retrieving the student.");
        }
    }

    public List<Section> GetRegisteredSections(int id)
    {
        try
        {
            Student? student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                throw new KeyNotFoundException("Student with the specified ID does not exist.");
            }
            return _studentRepository.GetRegisteredSectionsByStudentId(id);
        }
        catch (KeyNotFoundException)
        {
            throw;
        }
        catch (Exception)
        {
            throw new InvalidOperationException("An error occurred while retrieving registered sections.");
        }
    }

    public Student? Login(Student student)
    {
        throw new NotImplementedException();
    }

    public Student? Register(Student student)
    {
        throw new NotImplementedException();
    }

    public Student? Update(Student item)
    {
        throw new NotImplementedException();
    }
}