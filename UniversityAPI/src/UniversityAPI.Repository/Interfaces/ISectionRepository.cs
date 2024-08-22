using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public interface ISectionRepository : IRepository<Section>
    {
        Task<List<Section>> GetSectionsByCourseID(int courseID);
    }
}
