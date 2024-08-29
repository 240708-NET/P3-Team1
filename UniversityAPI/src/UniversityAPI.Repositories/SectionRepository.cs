using Microsoft.EntityFrameworkCore;
using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    /// <summary>
    /// Provides a repository for managing <see cref="Section"/> entities, offering specific data operations related to sections.
    /// Inherits from the generic <see cref="Repository{Section}"/> class and implements the <see cref="ISectionRepository"/> interface.
    /// </summary>
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        /// <summary>
        /// The database context specific to the University API used for interacting with the data store.
        /// </summary>
        protected readonly UniversityContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SectionRepository"/> class with the specified <see cref="UniversityContext"/>.
        /// </summary>
        /// <param name="context">The University API database context.</param>
        public SectionRepository(UniversityContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Asynchronously retrieves all <see cref="Section"/> entities from the data store, including related <see cref="Course"/>, <see cref="Professor"/>, and <see cref="Student"/> entities.
        /// </summary>
        /// <returns>A list of all sections, including related entities.</returns>
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

        /// <summary>
        /// Asynchronously retrieves a <see cref="Section"/> entity by its identifier, including related <see cref="Course"/>, <see cref="Professor"/>, and <see cref="Student"/> entities.
        /// </summary>
        /// <param name="id">The identifier of the section.</param>
        /// <returns>The section with the specified identifier, or <c>null</c> if no section is found.</returns>
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

        /// <summary>
        /// Asynchronously retrieves a list of <see cref="Section"/> entities that are associated with the specified course ID.
        /// </summary>
        /// <param name="courseID">The ID of the course whose sections to retrieve.</param>
        /// <returns>A list of sections associated with the specified course ID, or <c>null</c> if no sections are found.</returns>
        public async Task<List<Section>?> GetSectionsByCourseID(int courseID)
        {
            //Fetch the sections by course ID
            var sections = await _context.Sections
                                        .Where(s => s.CourseID == courseID)
                                        .ToListAsync();

            //Return the list of sections (can be null if no sections exist)
            return sections.Any() ? sections : null;
        }

        /// <summary>
        /// Asynchronously retrieves a list of <see cref="Student"/> entities that are registered in the section with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the section whose registered students to retrieve.</param>
        /// <returns>A list of students registered in the section, or <c>null</c> if the section is not found.</returns>
        public async Task<List<Student>?> GetRegisteredStudents(int id)
        {
            Section? section = await _context.Sections
                                     .Include(s => s.Students)  //Eagerly load Students
                                     .FirstOrDefaultAsync(s => s.ID == id);
            if (section == null)
            {
                return null;
            }
            return section.Students.ToList();
        }

        /// <summary>
        /// Asynchronously adds a student to a section.
        /// </summary>
        /// <param name="sectionId">The ID of the section to which the student should be added.</param>
        /// <param name="studentId">The ID of the student to add to the section.</param>
        /// <returns>The updated section with the added student, or <c>null</c> if either the student or section is not found.</returns>
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

        /// <summary>
        /// Asynchronously removes a student from a section.
        /// </summary>
        /// <param name="sectionId">The ID of the section from which the student should be removed.</param>
        /// <param name="studentId">The ID of the student to remove from the section.</param>
        /// <returns>The updated section with the removed student, or <c>null</c> if either the student or section is not found.</returns>
        public async Task<Section?> DeleteStudentFromSection(int sectionId, int studentId)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.ID == studentId);
            var section = await _context.Sections
                                .Include(s => s.Students)  //Ensure Students are loaded
                                .FirstOrDefaultAsync(s => s.ID == sectionId);
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