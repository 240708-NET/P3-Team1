using Microsoft.EntityFrameworkCore;
using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    /// <summary>
    /// Provides a repository for managing <see cref="Student"/> entities, offering specific data operations related to students.
    /// Inherits from the generic <see cref="Repository{Student}"/> class and implements the <see cref="IStudentRepository"/> interface.
    /// </summary>
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        /// <summary>
        /// The database context specific to the University API used for interacting with the data store.
        /// </summary>
        protected readonly UniversityContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentRepository"/> class with the specified <see cref="UniversityContext"/>.
        /// </summary>
        /// <param name="context">The University API database context.</param>
        public StudentRepository(UniversityContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Asynchronously retrieves a <see cref="Student"/> entity by its identifier, including related <see cref="Section"/>, <see cref="Course"/>, and <see cref="Professor"/> entities.
        /// </summary>
        /// <param name="studentId">The identifier of the student.</param>
        /// <returns>The student with the specified identifier, or <c>null</c> if no student is found.</returns>
        public override async Task<Student?> GetById(int studentId)
        {
            //Include related entities
            return await _context.Students
                         .Include(s => s.Sections)
                         .ThenInclude(section => section.Course)
                         .Include(s => s.Sections)
                         .ThenInclude(section => section.Professor) 
                         .SingleOrDefaultAsync(s => s.ID == studentId);
        }

        /// <summary>
        /// Asynchronously retrieves a list of <see cref="Student"/> entities that have the specified last name.
        /// </summary>
        /// <param name="lastName">The last name of the students to retrieve.</param>
        /// <returns>A list of students with the specified last name.</returns>
        public async Task<List<Student>> GetStudentsByLastName(string lastName)
        {
            return await _context.Students
                                 .Where(student => student.LastName == lastName)
                                 .ToListAsync();
        }

        /// <summary>
        /// Asynchronously retrieves a list of <see cref="Section"/> entities that a student is registered in, based on the student's ID.
        /// </summary>
        /// <param name="id">The ID of the student whose registered sections to retrieve.</param>
        /// <returns>A list of sections the student is registered in, or <c>null</c> if the student is not found.</returns>
        public async Task<List<Section>?> GetRegisteredSections(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.ID == id);
            if (student == null)
            {
                return null;
            }
            return student.Sections.ToList();
        }

        /// <summary>
        /// Asynchronously adds a section to a student's registered sections.
        /// </summary>
        /// <param name="studentId">The ID of the student to whom the section should be added.</param>
        /// <param name="sectionId">The ID of the section to add to the student.</param>
        /// <returns>The updated student with the added section, or <c>null</c> if either the student or section is not found.</returns>
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

        /// <summary>
        /// Asynchronously removes a section from a student's registered sections.
        /// </summary>
        /// <param name="studentId">The ID of the student from whom the section should be removed.</param>
        /// <param name="sectionId">The ID of the section to remove from the student.</param>
        /// <returns>The updated student with the removed section, or <c>null</c> if either the student or section is not found.</returns>
        public async Task<Student?> DeleteSectionFromStudent(int studentId, int sectionId)
        {
            var student = await _context.Students
                .Include(s => s.Sections)
                .FirstOrDefaultAsync(s => s.ID == studentId);

            if (student == null)
            {
                return null;
            }

            var section = student.Sections.FirstOrDefault(s => s.ID == sectionId);
            if (section == null)
            {
                return null;
            }

            student.Sections.Remove(section);
            await _context.SaveChangesAsync();

            return student;
        }
    }
}