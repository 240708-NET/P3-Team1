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

        public override async Task<List<Section>> GetAll()
        {
            //Include related entities for all sections
            return await _context.Sections
                .Include(section => section.Course)
                .Include(section => section.Professor)
                .Include(section => section.Students)
                .AsNoTracking()
                .ToListAsync();
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

        public async Task<List<Section>?> GetSectionsByCourseID(int courseID)
        {
            // Fetch the sections by course ID
            var sections = await _context.Sections
                                        .Where(s => s.CourseID == courseID)
                                        .ToListAsync();

            // Return the list of sections (can be null if no sections exist)
            return sections.Any() ? sections : null;
        }

                public async Task<List<Student>?> GetRegisteredStudents(int id)
        {
            Section? section = await _context.Sections.FirstOrDefaultAsync(s => s.ID == id);
            if (section == null)
            {
                return null;
            }
            return section.Students.ToList();
        }

        public async Task<Section?> AddStudentToSection(int sectionId, int studentId)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.ID == studentId);
            var section = await _context.Sections.FirstOrDefaultAsync(s => s.ID == sectionId);
            if (student == null || section == null)
            {
                return null;
            }
            section.Students.Add(student);
            await _context.SaveChangesAsync();
            return section;
        }

        public async Task<Section?> DeleteStudentFromSection(int sectionId, int studentId)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.ID == studentId);
            var section = await _context.Sections.FirstOrDefaultAsync(s => s.ID == sectionId);
            if (student == null || section == null)
            {
                return null;
            }
            section.Students.Remove(student);
            await _context.SaveChangesAsync();
            return section;
        }
    }
}