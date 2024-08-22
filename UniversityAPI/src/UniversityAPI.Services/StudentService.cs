using UniversityAPI.Models;
using UniversityAPI.Services;
using UniversityAPI.Repositories;

namespace UniversityAPI.Services;
public class StudentService : IStudentServices
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public Student AddSectionToStudent(int studentId, int sectionId)
    {
        throw new NotImplementedException();
    }

    public List<Student> DeleteAll()
    {
        throw new NotImplementedException();
    }

    public Student DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public Student DeleteSectionFromStudent(int studentId, int sectionId)
    {
        throw new NotImplementedException();
    }

    public List<Student> GetAll()
    {
        throw new NotImplementedException();
    }

    public Student GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Section> GetRegisteredSections(int id)
    {
        throw new NotImplementedException();
    }

    public Student Insert(Student item)
    {
        throw new NotImplementedException();
    }

    public async Task<Student?> Login(Student student)
    {
        try
        {
            if (student.ID == 0 || string.IsNullOrEmpty(student.Password))
            {
                throw new ArgumentException("Student ID or Password is missing.");
            }

            var loggedInStudent = await _studentRepository.Login(student.ID, student.Password);

            if (loggedInStudent == null)
            {
                throw new InvalidOperationException("Invalid ID or Password.");
            }

            return loggedInStudent;
        }
        catch (ArgumentException)
        {
            throw new ArgumentException("Error in Login method: ");
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException("Error in Login method: ");
        }
        catch (Exception)
        {
            throw new Exception("An unexpected error occurred during login.");
        }
    }

    public async Task<Student> Register(Student student)
    {
        try
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student cannot be null.");
            }

            var existingStudent = await _studentRepository.GetById(student.ID);
            if (existingStudent != null)
            {
                throw new StudentAlreadyRegisteredException("A student with this ID already exists.");
            }

            await _studentRepository.Insert(student);
            return student;
        }
        catch (ArgumentNullException)
        {
            throw new RegistrationFailedException("Student registration failed due to invalid input.");
        }
        catch (Exception)
        {
            throw new RegistrationFailedException("An unexpected error occurred during student registration.");
        }
    }

    public Student Update(Student item)
    {
        throw new NotImplementedException();
    }
}