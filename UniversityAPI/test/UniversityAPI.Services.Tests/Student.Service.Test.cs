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
        private readonly StudentService _studentService;

        public StudentServiceTests()
        {
            _repositoryMock = new Mock<IStudentRepository>();
            _studentService = new StudentService(_repositoryMock.Object);
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
        public async Task GetRegisteredSectionsReturnSectionsWhenStudentExists()
        {
            // Arrange
            int studentId = 1;
            var student = new Student { ID = studentId };
            var sections = new List<Section>
            {
                new Section { ID = 101 },
                new Section { ID = 102 }
            };

            _repositoryMock.Setup(repo => repo.GetById(studentId)).ReturnsAsync(student);
            _repositoryMock.Setup(repo => repo.GetRegisteredSections(studentId)).ReturnsAsync(sections);

            // Act
            var result = await _studentService.GetRegisteredSections(studentId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, section => section.ID == 101);
            Assert.Contains(result, section => section.ID == 102);
            _repositoryMock.Verify(repo => repo.GetById(studentId), Times.Once);
            _repositoryMock.Verify(repo => repo.GetRegisteredSections(studentId), Times.Once);
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
        public async Task ThrowRepositoryExceptionWhenSectionsCannotBeRetrieved()
        {
            // Arrange
            int studentId = 1;
            var student = new Student { ID = studentId };
            _repositoryMock.Setup(repo => repo.GetById(studentId)).ReturnsAsync(student);
            _repositoryMock.Setup(repo => repo.GetRegisteredSections(studentId)).ReturnsAsync((List<Section>?)null);

            // Act & Assert
            await Assert.ThrowsAsync<RepositoryException>(() => _studentService.GetRegisteredSections(studentId));
            _repositoryMock.Verify(repo => repo.GetById(studentId), Times.Once);
            _repositoryMock.Verify(repo => repo.GetRegisteredSections(studentId), Times.Once);
        }

        [Fact]
        public async Task ReturnStudentWhenSectionIsAddedSuccessfully()
        {
            // Arrange
            int studentId = 1;
            int sectionId = 101;
            var student = new Student { ID = studentId };

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