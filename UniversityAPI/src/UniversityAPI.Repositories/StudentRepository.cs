using Microsoft.EntityFrameworkCore;
using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        protected readonly UniversityContext _context;

        public StudentRepository(UniversityContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Section>?> GetRegisteredSections(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.ID == id);
            if (student == null)
            {
                return null;
            }
            return student.Sections.ToList();
        }

        public async Task<List<Student>> GetStudentsByLastName(string lastName)
        {
            return await _context.Students
                                 .Where(student => student.LastName == lastName)
                                 .ToListAsync();
        }

        public async Task<Student?> AddSectionToStudent(int studentId, int sectionId)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.ID == studentId);
            var section = await _context.Sections.FirstOrDefaultAsync(s => s.ID == sectionId);
            if (student == null || section == null)
            {
                return null;
            }
            student.Sections.Add(section);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student?> DeleteSectionFromStudent(int studentId, int sectionId)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.ID == studentId);
            var section = await _context.Sections.FirstOrDefaultAsync(s => s.ID == sectionId);
            if (student == null || section == null)
            {
                return null;
            }
            student.Sections.Remove(section);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}