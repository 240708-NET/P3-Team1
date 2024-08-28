using Moq;
using UniversityAPI.Models;
using UniversityAPI.Repositories;
using UniversityAPI.Services;
using Xunit;

namespace UniversityAPI.Tests.Services
{
    public class StudentServiceTests
    {
        private readonly Mock<IStudentRepository> _repositoryMock;
        private readonly Mock<ISectionRepository> _sectionRepositoryMock;
        private readonly StudentService _studentService;

        public StudentServiceTests()
        {
            _repositoryMock = new Mock<IStudentRepository>();
            _sectionRepositoryMock = new Mock<ISectionRepository>();
            _studentService = new StudentService(_repositoryMock.Object, _sectionRepositoryMock.Object);
        }

        [Fact]
        public async Task LoginReturnStudentWhenCredentialsAreValid()
        {
            // Arrange
            var student = new Student { ID = 1, Password = "password123" };
            var foundStudent = new Student { ID = 1, Password = "password123" };
            _repositoryMock.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(foundStudent);

            // Act
            var result = await _studentService.Login(student);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.ID);
            _repositoryMock.Verify(repo => repo.GetById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task LoginThrowInvalidLoginExceptionWhenStudentDoesNotExist()
        {
            // Arrange
            var student = new Student { ID = 1 };
            _repositoryMock.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync((Student?)null);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidLoginException>(() => _studentService.Login(student));
            _repositoryMock.Verify(repo => repo.GetById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task LoginThrowInvalidLoginExceptionWhenPasswordIsIncorrect()
        {
            // Arrange
            var student = new Student { ID = 1, Password = "wrongpassword" };
            var foundStudent = new Student { ID = 1, Password = "password123" };
            _repositoryMock.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(foundStudent);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidLoginException>(() => _studentService.Login(student));
            _repositoryMock.Verify(repo => repo.GetById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task RegisteReturnRegisteredStudentWhenRegistrationIsSuccessful()
        {
            // Arrange
            var student = new Student { ID = 1, Password = "password123" };
            var registeredStudent = new Student { ID = 1, Password = "password123" };
            _repositoryMock.Setup(repo => repo.Insert(It.IsAny<Student>())).ReturnsAsync(registeredStudent);

            // Act
            var result = await _studentService.Register(student);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.ID);
            _repositoryMock.Verify(repo => repo.Insert(It.IsAny<Student>()), Times.Once);
        }

        [Fact]
        public async Task ThrowRegistrationFailedExceptionWhenRegistrationFails()
        {
            // Arrange
            var student = new Student { ID = 1, Password = "password123" };
            _repositoryMock.Setup(repo => repo.Insert(It.IsAny<Student>())).ReturnsAsync((Student?)null);

            // Act & Assert
            await Assert.ThrowsAsync<RegistrationFailedException>(() => _studentService.Register(student));
            _repositoryMock.Verify(repo => repo.Insert(It.IsAny<Student>()), Times.Once);
        }



        [Fact]
        public async Task GetRegisteredSectionsThrowStudentNotFoundExceptionWhenStudentDoesNotExist()
        {
            // Arrange
            int studentId = 1;
            _repositoryMock.Setup(repo => repo.GetById(studentId)).ReturnsAsync((Student?)null);

            // Act & Assert
            await Assert.ThrowsAsync<StudentNotFoundException>(() => _studentService.GetRegisteredSections(studentId));
            _repositoryMock.Verify(repo => repo.GetById(studentId), Times.Once);
            _repositoryMock.Verify(repo => repo.GetRegisteredSections(It.IsAny<int>()), Times.Never);
        }



        [Fact]
        public async Task ReturnStudentWhenSectionIsAddedSuccessfully()
        {
            // Arrange
            int studentId = 1;
            int sectionId = 101;
            var student = new Student { ID = studentId };
            var section = new Section { ID = sectionId };

            _repositoryMock.Setup(repo => repo.GetById(studentId)).ReturnsAsync(student);
            _sectionRepositoryMock.Setup(repo => repo.GetById(sectionId)).ReturnsAsync(section);

            _repositoryMock.Setup(repo => repo.AddSectionToStudent(studentId, sectionId)).ReturnsAsync(student);

            // Act
            var result = await _studentService.AddSectionToStudent(studentId, sectionId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(studentId, result.ID);
            _repositoryMock.Verify(repo => repo.AddSectionToStudent(studentId, sectionId), Times.Once);
        }

        [Fact]
        public async Task DeleteSectionFromStudentReturnStudentWhenSectionIsDeletedSuccessfully()
        {
            // Arrange
            int studentId = 1;
            int sectionId = 101;
            var student = new Student { ID = studentId };

            _repositoryMock.Setup(repo => repo.DeleteSectionFromStudent(studentId, sectionId)).ReturnsAsync(student);

            // Act
            var result = await _studentService.DeleteSectionFromStudent(studentId, sectionId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(studentId, result.ID);
            _repositoryMock.Verify(repo => repo.DeleteSectionFromStudent(studentId, sectionId), Times.Once);
        }
    }
}