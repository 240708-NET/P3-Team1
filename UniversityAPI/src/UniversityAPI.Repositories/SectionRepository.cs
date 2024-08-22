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


        public async Task<List<Section>?> GetSectionsByCourseID(int courseID)
        {
            Course? course = await _context.Courses.FirstOrDefaultAsync(c => c.ID == courseID);
            if (course == null)
            {
                return null;
            }
            return await _context.Sections
                                 .Where(section => section.CourseID == courseID)
                                 .ToListAsync();
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