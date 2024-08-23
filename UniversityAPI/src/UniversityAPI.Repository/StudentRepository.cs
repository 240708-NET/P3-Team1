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

        public override async Task<Student?> GetById(int studentId)
        {
            //Include related entities
            return await _context.Students
                         .Include(s => s.Sections)
                         .ThenInclude(section => section.Course)
                         .Include(s => s.Sections)
                         .ThenInclude(section => section.Professor) 
                         .AsNoTracking()
                         .SingleOrDefaultAsync(s => s.ID == studentId);
        }

        public async Task<List<Student>> GetStudentsByLastName(string lastName)
        {
            return await _context.Students
                                 .Where(student => student.LastName == lastName)
                                 .ToListAsync();
        }
    }
}