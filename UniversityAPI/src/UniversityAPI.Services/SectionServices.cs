using UniversityAPI.Models;
using UniversityAPI.Repositories;

namespace UniversityAPI.Services
{
    /// <summary>
    /// Provides a service layer for managing <see cref="Section"/> entities, specifically handling operations related to sections and their associated students.
    /// Inherits from the generic <see cref="Service{Section}"/> class and implements the <see cref="ISectionServices"/> interface.
    /// </summary>
    public class SectionService : Service<Section>, ISectionServices
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SectionService"/> class with the specified section repository.
        /// </summary>
        /// <param name="repository">The repository for managing <see cref="Section"/> entities.</param>
        public SectionService(ISectionRepository repository) : base(repository)
        {
        }

        /// <summary>
        /// Asynchronously adds a student to a section.
        /// </summary>
        /// <param name="sectionId">The ID of the section to which the student should be added.</param>
        /// <param name="studentId">The ID of the student to add to the section.</param>
        /// <returns>The updated section with the added student.</returns>
        /// <exception cref="ResourceNotFoundException">Thrown when the section or student is not found.</exception>
        public async Task<Section> AddStudentToSection(int sectionId, int studentId)
        {
            Section? section = await ((ISectionRepository)_repository).AddStudentToSection(sectionId, studentId);
            if (section == null)
            {
                throw new ResourceNotFoundException();
            }
            return section;
        }

        /// <summary>
        /// Asynchronously removes a student from a section.
        /// </summary>
        /// <param name="sectionId">The ID of the section from which the student should be removed.</param>
        /// <param name="studentId">The ID of the student to remove from the section.</param>
        /// <returns>The updated section with the removed student.</returns>
        /// <exception cref="ResourceNotFoundException">Thrown when the section or student is not found.</exception>
        public async Task<Section> DeleteStudentFromSection(int sectionId, int studentId)
        {
            Section? section = await ((ISectionRepository)_repository).DeleteStudentFromSection(sectionId, studentId);
            if (section == null)
            {
                throw new ResourceNotFoundException();
            }
            return section;
        }

        /// <summary>
        /// Asynchronously retrieves the list of students registered in a specific section.
        /// </summary>
        /// <param name="id">The ID of the section whose registered students to retrieve.</param>
        /// <returns>A list of students registered in the section.</returns>
        /// <exception cref="SectionNotFoundException">Thrown when the section is not found.</exception>
        /// <exception cref="RepositoryException">Thrown when the students could not be retrieved due to a repository error.</exception>
        public async Task<List<Student>> GetRegisteredStudents(int id)
        {
            Section? section = await ((ISectionRepository)_repository).GetById(id);
            if (section == null)
            {
                throw new SectionNotFoundException();
            }
            List<Student>? students = await ((ISectionRepository)_repository).GetRegisteredStudents(id);
            if (students == null)
            {
                throw new RepositoryException();
            }
            return students;
        }
    }
}
