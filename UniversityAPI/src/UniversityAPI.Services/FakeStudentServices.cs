using UniversityAPI.Models;
using UniversityAPI.Services;

namespace UniversityAPI.Services;

public class FakeStudentSertices : IStudentServices
{
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
}