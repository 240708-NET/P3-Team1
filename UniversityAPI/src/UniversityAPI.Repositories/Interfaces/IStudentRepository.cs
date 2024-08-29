using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    /// <summary>
    /// Defines the operations specific to the repository for <see cref="Student"/> entities.
    /// </summary>
    public interface IStudentRepository : IRepository<Student>
    {
        /// <summary>
        /// Asynchronously retrieves a list of <see cref="Student"/> entities that have the specified last name.
        /// </summary>
        /// <param name="lastName">The last name of the students to retrieve.</param>
        /// <returns>A list of students with the specified last name.</returns>
        Task<List<Student>> GetStudentsByLastName(string lastName);

        /// <summary>
        /// Asynchronously retrieves a list of <see cref="Section"/> entities that a student is registered in, based on the student's ID.
        /// </summary>
        /// <param name="id">The ID of the student whose registered sections to retrieve.</param>
        /// <returns>A list of sections the student is registered in, or <c>null</c> if the student is not found.</returns>
        Task<List<Section>?> GetRegisteredSections(int id);

        /// <summary>
        /// Asynchronously adds a section to a student's registered sections.
        /// </summary>
        /// <param name="studentId">The ID of the student to whom the section should be added.</param>
        /// <param name="sectionId">The ID of the section to add to the student.</param>
        /// <returns>The updated student with the added section, or <c>null</c> if either the student or section is not found.</returns>
        Task<Student?> AddSectionToStudent(int studentId, int sectionId);

        /// <summary>
        /// Asynchronously removes a section from a student's registered sections.
        /// </summary>
        /// <param name="studentId">The ID of the student from whom the section should be removed.</param>
        /// <param name="sectionId">The ID of the section to remove from the student.</param>
        /// <returns>The updated student with the removed section, or <c>null</c> if either the student or section is not found.</returns>
        Task<Student?> DeleteSectionFromStudent(int studentId, int sectionId);
    }
}