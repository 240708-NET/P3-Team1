using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    /// <summary>
    /// Defines the operations specific to the repository for <see cref="Section"/> entities.
    /// </summary>
    public interface ISectionRepository : IRepository<Section>
    {
        /// <summary>
        /// Asynchronously retrieves a list of <see cref="Section"/> entities that are associated with the specified course ID.
        /// </summary>
        /// <param name="courseID">The ID of the course whose sections to retrieve.</param>
        /// <returns>A list of sections associated with the specified course ID, or <c>null</c> if no sections are found.</returns>
        Task<List<Section>?> GetSectionsByCourseID(int courseID);

        /// <summary>
        /// Asynchronously adds a student to a section.
        /// </summary>
        /// <param name="sectionId">The ID of the section to which the student should be added.</param>
        /// <param name="studentId">The ID of the student to add to the section.</param>
        /// <returns>The updated section with the added student, or <c>null</c> if either the student or section is not found.</returns>
        Task<Section?> AddStudentToSection(int sectionId, int studentId);

        /// <summary>
        /// Asynchronously removes a student from a section.
        /// </summary>
        /// <param name="sectionId">The ID of the section from which the student should be removed.</param>
        /// <param name="studentId">The ID of the student to remove from the section.</param>
        /// <returns>The updated section with the removed student, or <c>null</c> if either the student or section is not found.</returns>
        Task<Section?> DeleteStudentFromSection(int sectionId, int studentId);

        /// <summary>
        /// Asynchronously retrieves a list of <see cref="Student"/> entities that are registered in the section with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the section whose registered students to retrieve.</param>
        /// <returns>A list of students registered in the section, or <c>null</c> if the section is not found.</returns>
        Task<List<Student>?> GetRegisteredStudents(int id);
    }
}