using UniversityAPI.Models;

namespace UniversityAPI.Services;

public class FakeStudentSertices : IStudentServices
{
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

    public Student Login(Student student)
    {
        Student s = new Student
        {
            ID = 123,
            FirstName = "first",
            LastName = "last",
            Password = "string"
        };

        if (s.Equals(student))
        {
            return student;
        }
        else
        {
            throw new InvalidDataException("");
        }
    }

    public Student Register(Student student)
    {
        throw new NotImplementedException();
    }

    public Student Update(Student item)
    {
        throw new NotImplementedException();
    }
}