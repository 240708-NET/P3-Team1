using Moq;
using UniversityAPI.Models;
using UniversityAPI.Repositories;
using UniversityAPI.Services;
using Xunit;

namespace UniversityAPI.Tests.Services
{
    public class SectionServiceTests
    {
        private readonly Mock<ISectionRepository> _repositoryMock;
        private readonly SectionService _sectionService;

        public SectionServiceTests()
        {
            _repositoryMock = new Mock<ISectionRepository>();
            _sectionService = new SectionService(_repositoryMock.Object);
        }

        [Fact]
        public async Task ShouldReturnSectionWhenStudentIsAddedSuccessfully()
        {
            // Arrange
            int sectionId = 1;
            int studentId = 101;
            var section = new Section { ID = sectionId };
            _repositoryMock.Setup(repo => repo.AddStudentToSection(sectionId, studentId)).ReturnsAsync(section);

            // Act
            var result = await _sectionService.AddStudentToSection(sectionId, studentId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(sectionId, result.ID);
            _repositoryMock.Verify(repo => repo.AddStudentToSection(sectionId, studentId), Times.Once);
        }

        [Fact]
        public async Task ShouldThrowNotFoundExceptionWhenSectionNotFound()
        {
            // Arrange
            int sectionId = 1;
            int studentId = 101;

            _repositoryMock.Setup(repo => repo.AddStudentToSection(sectionId, studentId)).ReturnsAsync((Section?)null);

            // Act & Assert
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => _sectionService.AddStudentToSection(sectionId, studentId));
            _repositoryMock.Verify(repo => repo.AddStudentToSection(sectionId, studentId), Times.Once);
        }

        [Fact]
        public async Task DeleteStudentFromSectionReturnSectionWhenStudentIsRemovedSuccessfully()
        {
            // Arrange
            int sectionId = 1;
            int studentId = 101;
            var section = new Section { ID = sectionId };

            _repositoryMock.Setup(repo => repo.DeleteStudentFromSection(sectionId, studentId)).ReturnsAsync(section);

            // Act
            var result = await _sectionService.DeleteStudentFromSection(sectionId, studentId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(sectionId, result.ID);
            _repositoryMock.Verify(repo => repo.DeleteStudentFromSection(sectionId, studentId), Times.Once);
        }

        [Fact]
        public async Task DeleteStudentFromSectionThrowNotFoundExceptionWhenSectionNotFound()
        {
            // Arrange
            int sectionId = 1;
            int studentId = 101;
            _repositoryMock.Setup(repo => repo.DeleteStudentFromSection(sectionId, studentId)).ReturnsAsync((Section?)null);

            // Act & Assert
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => _sectionService.DeleteStudentFromSection(sectionId, studentId));
            _repositoryMock.Verify(repo => repo.DeleteStudentFromSection(sectionId, studentId), Times.Once);
        }

        [Fact]
        public async Task GetRegisteredStudentsReturnStudentsWhenSectionExists()
        {
            // Arrange
            int sectionId = 1;
            var section = new Section { ID = sectionId };
            var students = new List<Student>
            {
                new Student { ID = 201 },
                new Student { ID = 202 }
            };

            _repositoryMock.Setup(repo => repo.GetById(sectionId)).ReturnsAsync(section);
            _repositoryMock.Setup(repo => repo.GetRegisteredStudents(sectionId)).ReturnsAsync(students);

            // Act
            var result = await _sectionService.GetRegisteredStudents(sectionId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, student => student.ID == 201);
            Assert.Contains(result, student => student.ID == 202);
            _repositoryMock.Verify(repo => repo.GetById(sectionId), Times.Once);
            _repositoryMock.Verify(repo => repo.GetRegisteredStudents(sectionId), Times.Once);
        }

        [Fact]
        public async Task ThrowSectionNotFoundExceptionWhenSectionDoesNotExist()
        {
            // Arrange
            int sectionId = 1;
            _repositoryMock.Setup(repo => repo.GetById(sectionId)).ReturnsAsync((Section?)null);

            // Act & Assert
            await Assert.ThrowsAsync<SectionNotFoundException>(() => _sectionService.GetRegisteredStudents(sectionId));
            _repositoryMock.Verify(repo => repo.GetById(sectionId), Times.Once);
            _repositoryMock.Verify(repo => repo.GetRegisteredStudents(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async Task ThrowRepositoryExceptionWhenStudentsCannotBeRetrieved()
        {
            // Arrange
            int sectionId = 1;
            var section = new Section { ID = sectionId };
            _repositoryMock.Setup(repo => repo.GetById(sectionId)).ReturnsAsync(section);
            _repositoryMock.Setup(repo => repo.GetRegisteredStudents(sectionId)).ReturnsAsync((List<Student>?)null);

            // Act & Assert
            await Assert.ThrowsAsync<RepositoryException>(() => _sectionService.GetRegisteredStudents(sectionId));
            _repositoryMock.Verify(repo => repo.GetById(sectionId), Times.Once);
            _repositoryMock.Verify(repo => repo.GetRegisteredStudents(sectionId), Times.Once);
        }
    }
}
