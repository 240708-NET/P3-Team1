using UniversityAPI.Models;

namespace UniversityAPI.Services;

public interface IProfessorServices : IService<Professor>
{
    public Professor Login(Professor student);
    public Professor Register(Professor student);
}