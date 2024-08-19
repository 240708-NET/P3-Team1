using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public interface IProfessorRepository : IGenericRepository<Professor>
    {
        Task<List<Professor>> GetProfessorsByLastName(string lastName);
        Task<List<Section>> GetSectionsByProfessorID(int professorID);
    }
}
