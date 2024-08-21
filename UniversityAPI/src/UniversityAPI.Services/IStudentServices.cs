using UniversityAPI.Models;

namespace UniversityAPI.Services;

public interface IStudentServices
{
    public Student? Login(Student student);
}