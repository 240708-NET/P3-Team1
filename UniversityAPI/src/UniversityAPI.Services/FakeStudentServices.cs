using UniversityAPI.Models;
using UniversityAPI.Services;

namespace UniversityAPI.Services;

public class FakeStudentSertices : IStudentServices
{
    public List<Student> DeleteAll()
    {
        throw new NotImplementedException();
    }

    public Student? DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Student> GetAll()
    {
        throw new NotImplementedException();
    }

    public Student? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Section> GetRegisteredSections(int id)
    {
        throw new NotImplementedException();
    }

    public Student? Insert(Student item)
    {
        throw new NotImplementedException();
    }

    public Student? Login(Student student)
    {
        Student s = new Student
        {
            ID = 123,
            FirstName = "first",
            LastName = "last",
        };

        if (s.Equals(student))
        {
            return student;
        }
        else
        {
            return null;
        }
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