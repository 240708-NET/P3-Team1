using UniversityAPI.Models;

namespace UniversityAPI.Services;

/// <summary>
/// Interface for student-related services, extending the base <see cref="IService{T}"/> interface
/// to include operations specific to the <see cref="Student"/> entity.
/// </summary>
public interface IStudentServices : IService<Student>
{
    /// <summary>
    /// Authenticates a student's login credentials.
    /// </summary>
    /// <param name="student">The student object containing login credentials.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the authenticated student object.</returns>
    public Task<Student> Login(Student student);

    /// <summary>
    /// Registers a new student in the system.
    /// </summary>
    /// <param name="student">The student object containing registration details.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the registered student object.</returns>
    public Task<Student> Register(Student student);

    /// <summary>
    /// Retrieves a list of sections that the student is registered in.
    /// </summary>
    /// <param name="studentId">The unique identifier of the student.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of sections the student is registered in.</returns>
    public Task<List<Section>> GetRegisteredSections(int studentId);

    /// <summary>
    /// Adds a section to a student's schedule.
    /// </summary>
    /// <param name="studentId">The unique identifier of the student.</param>
    /// <param name="sectionId">The unique identifier of the section.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated student object after the section has been added.</returns>
    public Task<Student> AddSectionToStudent(int studentId, int sectionId);

    /// <summary>
    /// Removes a section from a student's schedule.
    /// </summary>
    /// <param name="studentId">The unique identifier of the student.</param>
    /// <param name="sectionId">The unique identifier of the section.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated student object after the section has been removed.</returns>
    public Task<Student> DeleteSectionFromStudent(int studentId, int sectionId);
}
