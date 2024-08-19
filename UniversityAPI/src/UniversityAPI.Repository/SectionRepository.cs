using Microsoft.EntityFrameworkCore;
using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public class SectionRepository : GenericRepository<Section>, ISectionRepository
    {
        protected readonly UniversityContext _context;

        public SectionRepository(UniversityContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Section>> GetSectionsByCourseID(int courseID)
        {
            return await _context.Sections
                                 .Where(section => section.CourseID == courseID)
                                 .ToListAsync();
        }
    }
}