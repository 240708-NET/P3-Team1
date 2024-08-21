using Microsoft.EntityFrameworkCore;
using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public class ProfessorRepository : Repository<Professor>, IProfessorRepository
    {
        protected readonly UniversityContext _context;

        public ProfessorRepository(UniversityContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Professor>> GetProfessorsByLastName(string lastName)
        {
            return await _context.Professors
                                 .Where(professor => professor.LastName == lastName)
                                 .ToListAsync();
        }

        public async Task<List<Section>> GetSectionsByProfessorID(int professorID)
        {
            return await _context.Sections
                                 .Where(section => section.ProfessorID == professorID)
                                 .ToListAsync();
        }
    }
}