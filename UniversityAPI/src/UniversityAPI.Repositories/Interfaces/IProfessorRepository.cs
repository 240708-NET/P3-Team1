using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    /// <summary>
    /// Defines the operations specific to the repository for <see cref="Professor"/> entities.
    /// </summary>
    public interface IProfessorRepository : IRepository<Professor>
    {
        /// <summary>
        /// Asynchronously retrieves a list of <see cref="Professor"/> entities that have the specified last name.
        /// </summary>
        /// <param name="lastName">The last name of the professors to retrieve.</param>
        /// <returns>A list of professors with the specified last name.</returns>
        Task<List<Professor>> GetProfessorsByLastName(string lastName);

        /// <summary>
        /// Asynchronously retrieves a list of <see cref="Section"/> entities that are taught by the professor with the specified ID.
        /// </summary>
        /// <param name="professorID">The ID of the professor whose sections to retrieve.</param>
        /// <returns>A list of sections taught by the professor with the specified ID.</returns>
        Task<List<Section>> GetSectionsByProfessorID(int professorID);
    }
}