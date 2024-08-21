using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public interface IProfessorRepository : IRepository<Professor>
    {
        Task<List<Professor>> GetProfessorsByLastName(string lastName);
        Task<List<Section>> GetSectionsByProfessorID(int professorID);
    }
}
