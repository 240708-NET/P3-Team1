using Microsoft.EntityFrameworkCore;
using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    /// <summary>
    /// Provides a repository for managing <see cref="Professor"/> entities, offering specific data operations related to professors.
    /// Inherits from the generic <see cref="Repository{Professor}"/> class and implements the <see cref="IProfessorRepository"/> interface.
    /// </summary>
    public class ProfessorRepository : Repository<Professor>, IProfessorRepository
    {
        /// <summary>
        /// The database context specific to the University API used for interacting with the data store.
        /// </summary>
        protected readonly UniversityContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfessorRepository"/> class with the specified <see cref="UniversityContext"/>.
        /// </summary>
        /// <param name="context">The University API database context.</param>
        public ProfessorRepository(UniversityContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Asynchronously retrieves a list of <see cref="Professor"/> entities that have the specified last name.
        /// </summary>
        /// <param name="lastName">The last name of the professors to retrieve.</param>
        /// <returns>A list of professors with the specified last name.</returns>
        public async Task<List<Professor>> GetProfessorsByLastName(string lastName)
        {
            return await _context.Professors
                                 .Where(professor => professor.LastName == lastName)
                                 .ToListAsync();
        }

        /// <summary>
        /// Asynchronously retrieves a list of <see cref="Section"/> entities that are taught by the professor with the specified ID.
        /// </summary>
        /// <param name="professorID">The ID of the professor whose sections to retrieve.</param>
        /// <returns>A list of sections taught by the professor with the specified ID.</returns>
        public async Task<List<Section>> GetSectionsByProfessorID(int professorID)
        {
            return await _context.Sections
                                 .Where(section => section.ProfessorID == professorID)
                                 .ToListAsync();
        }
    }
}