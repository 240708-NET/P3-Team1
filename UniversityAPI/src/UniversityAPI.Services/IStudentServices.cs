using UniversityAPI.Models;

namespace UniversityAPI.Services;

public interface IStudentServices : IService<Student>
{
    public Student? Login(Student student);
    public Student? Register(Student student);

}