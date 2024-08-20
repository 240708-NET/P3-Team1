using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public interface ISectionRepository : IGenericRepository<Section>
    {
        Task<List<Section>> GetSectionsByCourseID(int courseID);
    }
}
