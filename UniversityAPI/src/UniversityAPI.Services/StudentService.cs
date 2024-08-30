using UniversityAPI.Models;
using UniversityAPI.Repositories;

namespace UniversityAPI.Services
{
    /// <summary>
    /// Provides a service layer for managing <see cref="Student"/> entities, including operations related to student login, registration, and section management.
    /// Inherits from the generic <see cref="Service{Student}"/> class and implements the <see cref="IStudentServices"/> interface.
    /// </summary>
    public class StudentService : Service<Student>, IStudentServices
    {
        /// <summary>
        /// The repository for managing <see cref="Section"/> entities.
        /// </summary>
        private readonly ISectionRepository _sectionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentService"/> class with the specified student and section repositories.
        /// </summary>
        /// <param name="repository">The repository for managing <see cref="Student"/> entities.</param>
        /// <param name="sectionRepository">The repository for managing <see cref="Section"/> entities.</param>
        public StudentService(IStudentRepository repository, ISectionRepository sectionRepository) : base(repository)
        {
            _sectionRepository = sectionRepository;
        }

        /// <summary>
        /// Asynchronously retrieves the list of sections that a student is registered in.
        /// </summary>
        /// <param name="studentId">The ID of the student whose registered sections to retrieve.</param>
        /// <returns>A list of sections the student is registered in, or an empty list if none are found.</returns>
        /// <exception cref="StudentNotFoundException">Thrown when the student is not found.</exception>
        public async Task<List<Section>> GetRegisteredSections(int studentId)
        {
            // Fetch the student along with their sections
            var student = await _repository.GetById(studentId);
            if (student == null)
            {
                throw new StudentNotFoundException();
            }

            // If the student is not registered in any sections, return an empty list
            return student.Sections?.ToList() ?? new List<Section>();
        }

        /// <summary>
        /// Asynchronously logs in a student by validating their credentials.
        /// </summary>
        /// <param name="student">The student attempting to log in, containing the credentials.</param>
        /// <returns>The logged-in student if the credentials are valid.</returns>
        /// <exception cref="InvalidLoginException">Thrown when the student's login credentials are invalid.</exception>
        public async Task<Student> Login(Student student)
        {
            var foundStudent = await ((IStudentRepository)_repository).GetById(student.ID);
            if (foundStudent == null)
            {
                throw new InvalidLoginException();
            }
            if (student.Password != foundStudent.Password)
            {
                throw new InvalidLoginException();
            }
            return foundStudent;
        }

        /// <summary>
        /// Asynchronously registers a new student in the system.
        /// </summary>
        /// <param name="student">The student to be registered.</param>
        /// <returns>The registered student.</returns>
        /// <exception cref="RegistrationFailedException">Thrown when the student registration fails.</exception>
        public async Task<Student> Register(Student student)
        {
            var registeredStudent = await ((IStudentRepository)_repository).Insert(student);
            if (registeredStudent == null)
            {
                throw new RegistrationFailedException();
            }
            return registeredStudent;
        }

        /// <summary>
        /// Asynchronously adds a section to a student's schedule.
        /// </summary>
        /// <param name="studentId">The ID of the student to add the section to.</param>
        /// <param name="sectionId">The ID of the section to be added.</param>
        /// <returns>The updated student with the added section.</returns>
        /// <exception cref="ResourceNotFoundException">Thrown when either the student or section is not found.</exception>
        /// <exception cref="SectionOverlapException">Thrown when the section overlaps with an existing section in the student's schedule.</exception>
        public async Task<Student> AddSectionToStudent(int studentId, int sectionId)
        {
            Student? student = await ((IStudentRepository)_repository).GetById(studentId);
            Section? section = await _sectionRepository.GetById(sectionId);
            if (student == null || section == null)
            {
                throw new ResourceNotFoundException();
            }

            // Check if the section overlaps with any existing sections in the student's schedule
            if (student.Sections.Any(x => x.Overlaps(section)))
            {
                throw new SectionOverlapException();
            }

            student = await ((IStudentRepository)_repository).AddSectionToStudent(studentId, sectionId);
            if (student == null)
            {
                throw new ResourceNotFoundException();
            }
            return student;
        }

        /// <summary>
        /// Asynchronously removes a section from a student's schedule.
        /// </summary>
        /// <param name="studentId">The ID of the student from whose schedule the section should be removed.</param>
        /// <param name="sectionId">The ID of the section to remove.</param>
        /// <returns>The updated student with the removed section.</returns>
        /// <exception cref="ResourceNotFoundException">Thrown when either the student or section is not found.</exception>
        public async Task<Student> DeleteSectionFromStudent(int studentId, int sectionId)
        {
            Student? student = await ((IStudentRepository)_repository).DeleteSectionFromStudent(studentId, sectionId);
            if (student == null)
            {
                throw new ResourceNotFoundException();
            }
            return student;
        }
    }
}
