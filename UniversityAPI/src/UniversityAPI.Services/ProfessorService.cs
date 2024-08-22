using UniversityAPI.Models;
using UniversityAPI.Repositories;
using UniversityAPI.Services;

namespace UniversityAPI.Services;

public class ProfessorService : Service<Professor>, IProfessorServices
{
    public ProfessorService(IProfessorRepository repository) : base(repository)
    {
    }

    public Professor Login(Professor student)
    {
        throw new NotImplementedException();
    }

    public Professor Register(Professor student)
    {
        throw new NotImplementedException();
    }
}