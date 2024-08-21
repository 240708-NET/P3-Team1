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

        public async Task<List<Student>> GetStudentsByLastName(string lastName)
        {
            return await _context.Students
                                 .Where(student => student.LastName == lastName)
                                 .ToListAsync();
        }

        public async Task<Student?> Login(int id, string password)
        {
            //Returns a single element or null. If multiple elements found, will throw exception
            return await _context.Students
                                 .SingleOrDefaultAsync(student => student.ID == id && student.Password == password);
        }
    }
}