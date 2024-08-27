using Moq;
using UniversityAPI.Models;
using UniversityAPI.Repositories;
using UniversityAPI.Services;
using Xunit;

namespace UniversityAPI.Tests.Services
{
    public class ServiceTests
    {
        private readonly Mock<IRepository<Identified>> _repositoryMock;
        private readonly Service<Identified> _service;

        public ServiceTests()
        {
            _repositoryMock = new Mock<IRepository<Identified>>();
            _service = new Service<Identified>(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetById_ShouldReturnItem_WhenItemExists()
        {
            // Arrange
            var item = new Identified { ID = 1 };
            _repositoryMock.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(item);

            // Act
            var result = await _service.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.ID);
            _repositoryMock.Verify(repo => repo.GetById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task GetById_ShouldThrowResourceNotFoundException_WhenItemDoesNotExist()
        {
            // Arrange
            _repositoryMock.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync((Identified?)null);

            // Act & Assert
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => _service.GetById(1));
            _repositoryMock.Verify(repo => repo.GetById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task GetAll_ShouldReturnListOfItems_WhenItemsExist()
        {
            // Arrange
            var items = new List<Identified>
            {
                new Identified { ID = 1 },
                new Identified { ID = 2 },
                new Identified { ID = 3 }
            };
            _repositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(items);

            // Act
            var result = await _service.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            _repositoryMock.Verify(repo => repo.GetAll(), Times.Once);
        }

        [Fact]
        public async Task GetAll_ShouldReturnEmptyList_WhenNoItemsExist()
        {
            // Arrange
            _repositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(new List<Identified>());

            // Act
            var result = await _service.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            _repositoryMock.Verify(repo => repo.GetAll(), Times.Once);
        }

        [Fact]
        public async Task Insert_ShouldReturnInsertedItem_WhenInsertIsSuccessful()
        {
            // Arrange
            var item = new Identified { ID = 1 };
            _repositoryMock.Setup(repo => repo.Insert(It.IsAny<Identified>())).ReturnsAsync(item);

            // Act
            var result = await _service.Insert(item);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.ID);
            _repositoryMock.Verify(repo => repo.Insert(It.IsAny<Identified>()), Times.Once);
        }

        [Fact]
        public async Task Insert_ShouldThrowResourceCreationFailedException_WhenInsertFails()
        {
            // Arrange
            _repositoryMock.Setup(repo => repo.Insert(It.IsAny<Identified>())).ReturnsAsync((Identified?)null);

            // Act & Assert
            await Assert.ThrowsAsync<ResourceCreationFailedException>(() => _service.Insert(new Identified()));
            _repositoryMock.Verify(repo => repo.Insert(It.IsAny<Identified>()), Times.Once);
        }

        [Fact]
        public async Task Update_ShouldReturnUpdatedItem_WhenUpdateIsSuccessful()
        {
            // Arrange
            var item = new Identified { ID = 1 };
            _repositoryMock.Setup(repo => repo.GetById(item.ID)).ReturnsAsync(item);
            _repositoryMock.Setup(repo => repo.Update(It.IsAny<Identified>())).ReturnsAsync(item);

            // Act
            var result = await _service.Update(item);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.ID);
            _repositoryMock.Verify(repo => repo.GetById(item.ID), Times.Once);
            _repositoryMock.Verify(repo => repo.Update(It.IsAny<Identified>()), Times.Once);
        }

        [Fact]
        public async Task Update_ShouldThrowResourceNotFoundException_WhenItemDoesNotExist()
        {
            // Arrange
            var item = new Identified { ID = 1 };
            _repositoryMock.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync((Identified?)null);

            // Act & Assert
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => _service.Update(item));
            _repositoryMock.Verify(repo => repo.GetById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task Update_ShouldThrowResourceUpdateFailedException_WhenUpdateFails()
        {
            // Arrange
            var item = new Identified { ID = 1 };
            _repositoryMock.Setup(repo => repo.GetById(item.ID)).ReturnsAsync(item);
            _repositoryMock.Setup(repo => repo.Update(It.IsAny<Identified>())).ReturnsAsync((Identified?)null);

            // Act & Assert
            await Assert.ThrowsAsync<ResourceUpdateFailedException>(() => _service.Update(item));
            _repositoryMock.Verify(repo => repo.GetById(item.ID), Times.Once);
            _repositoryMock.Verify(repo => repo.Update(It.IsAny<Identified>()), Times.Once);
        }

        [Fact]
        public async Task DeleteById_ShouldReturnDeletedItem_WhenDeletionIsSuccessful()
        {
            // Arrange
            var item = new Identified { ID = 1 };
            _repositoryMock.Setup(repo => repo.GetById(item.ID)).ReturnsAsync(item);
            _repositoryMock.Setup(repo => repo.DeleteById(It.IsAny<int>())).ReturnsAsync(item);

            // Act
            var result = await _service.DeleteById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.ID);
            _repositoryMock.Verify(repo => repo.GetById(1), Times.Once);
            _repositoryMock.Verify(repo => repo.DeleteById(1), Times.Once);
        }

        [Fact]
        public async Task DeleteById_ShouldThrowResourceNotFoundException_WhenItemDoesNotExist()
        {
            // Arrange
            _repositoryMock.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync((Identified?)null);

            // Act & Assert
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => _service.DeleteById(1));
            _repositoryMock.Verify(repo => repo.GetById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task DeleteById_ShouldThrowResourceDeletionFailedException_WhenDeletionFails()
        {
            // Arrange
            var item = new Identified { ID = 1 };
            _repositoryMock.Setup(repo => repo.GetById(item.ID)).ReturnsAsync(item);
            _repositoryMock.Setup(repo => repo.DeleteById(It.IsAny<int>())).ReturnsAsync((Identified?)null);

            // Act & Assert
            await Assert.ThrowsAsync<ResourceDeletionFailedException>(() => _service.DeleteById(1));
            _repositoryMock.Verify(repo => repo.GetById(item.ID), Times.Once);
            _repositoryMock.Verify(repo => repo.DeleteById(1), Times.Once);
        }

        [Fact]
        public async Task DeleteAll_ShouldReturnListOfDeletedItems_WhenDeletionIsSuccessful()
        {
            // Arrange
            var items = new List<Identified>
            {
                new Identified { ID = 1 },
                new Identified { ID = 2 }
            };
            _repositoryMock.Setup(repo => repo.DeleteAll()).ReturnsAsync(items);

            // Act
            var result = await _service.DeleteAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            _repositoryMock.Verify(repo => repo.DeleteAll(), Times.Once);
        }

        [Fact]
        public async Task DeleteAll_ShouldReturnEmptyList_WhenNoItemsAreDeleted()
        {
            // Arrange
            _repositoryMock.Setup(repo => repo.DeleteAll()).ReturnsAsync(new List<Identified>());

            // Act
            var result = await _service.DeleteAll();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            _repositoryMock.Verify(repo => repo.DeleteAll(), Times.Once);
        }
    }
}
