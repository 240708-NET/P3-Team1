using Microsoft.EntityFrameworkCore;
using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        protected readonly UniversityContext _context;

        public SectionRepository(UniversityContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Section?> GetById(int id)
        {
            //Include the related entities
            return await _context.Sections
                .Include(section => section.Course)  
                .Include(section => section.Professor)  
                .Include(section => section.Students)  
                .AsNoTracking()
                .SingleOrDefaultAsync(section => section.ID == id);
        }

        public async Task<List<Section>> GetSectionsByCourseID(int courseID)
        {
            return await _context.Sections
                                 .Where(section => section.CourseID == courseID)
                                 .ToListAsync();
        }
    }
}