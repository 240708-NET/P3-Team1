using UniversityAPI.Models;

namespace UniversityAPI.Services;

/// <summary>
/// Interface for section-related services, extending the base <see cref="IService{T}"/> interface
/// to include operations specific to the <see cref="Section"/> entity.
/// </summary>
public interface ISectionServices : IService<Section>
{
    /// <summary>
    /// Adds a student to a section by their respective IDs.
    /// </summary>
    /// <param name="sectionId">The unique identifier of the section.</param>
    /// <param name="studentId">The unique identifier of the student.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated section after the student has been added.</returns>
    public Task<Section> AddStudentToSection(int sectionId, int studentId);

    /// <summary>
    /// Removes a student from a section by their respective IDs.
    /// </summary>
    /// <param name="sectionId">The unique identifier of the section.</param>
    /// <param name="studentId">The unique identifier of the student.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated section after the student has been removed.</returns>
    public Task<Section> DeleteStudentFromSection(int sectionId, int studentId);

    /// <summary>
    /// Retrieves a list of students registered in a specific section.
    /// </summary>
    /// <param name="id">The unique identifier of the section.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of students registered in the specified section.</returns>
    public Task<List<Student>> GetRegisteredStudents(int id);
}
