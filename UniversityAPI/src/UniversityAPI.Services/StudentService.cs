using UniversityAPI.Models;
using UniversityAPI.Repositories;

namespace UniversityAPI.Services
{
    public class StudentService : Service<Student>, IStudentServices
    {
        public StudentService(IStudentRepository repository) : base(repository) { }
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

        public async Task<Student> Register(Student student)
        {
            var registeredStudent = await ((IStudentRepository)_repository).Insert(student);
            if (registeredStudent == null)
            {
                throw new RegistrationFailedException();
            }
            return registeredStudent;
        }

        public async Task<Student> AddSectionToStudent(int studentId, int sectionId)
        {
            Student? student = await ((IStudentRepository)_repository).AddSectionToStudent(studentId, sectionId);
            if (student == null)
            {
                throw new ResourceNotFoundException();
            }
            return student;
        }

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