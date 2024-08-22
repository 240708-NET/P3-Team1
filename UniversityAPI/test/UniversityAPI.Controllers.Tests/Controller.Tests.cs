using Moq;

using UniversityAPI.Services;
using UniversityAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Xunit;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;

namespace UniversityAPI.Controllers.Tests;

public class ControllerTests
{

    private readonly Mock<IService<Identified>> _mockService;
    private readonly Controller<Identified> _controller;

    public ControllerTests()
    {
        _mockService = new Mock<IService<Identified>>();
        _controller = new Controller<Identified>(_mockService.Object);
    }

    [Fact]
    public async Task GetAllWhenNoEntityExistsReturnsEmptyListAnd200()
    {
        _mockService.Setup(service => service.GetAll()).Returns(Task.FromResult(new List<Identified>()));
        var result = (await _controller.GetAll()).Result as OkObjectResult;
        _mockService.Verify(service => service.GetAll(), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        var list = result.Value as List<Identified>;
        Assert.NotNull(list);
        Assert.Empty(list);
    }


    [Fact]
    public async Task GetAllWhenEntityExistReturnsListAnd200()
    {
        _mockService.Setup(service => service.GetAll()).Returns(Task.FromResult(new List<Identified>() {
            new Identified(),
            new Identified(),
            new Identified(),
        }));
        var result = (await _controller.GetAll()).Result as OkObjectResult;
        _mockService.Verify(service => service.GetAll(), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        var list = result.Value as List<Identified>;
        Assert.NotNull(list);
        Assert.Equal(3, list.Count);
    }

    [Fact]
    public async Task GetByIdWhenEntityDoesNotExistReturns404()
    {
        _mockService.Setup(service => service.GetById(It.IsAny<int>())).Throws<ResourceNotFoundException>();
        var result = (await _controller.GetById(42)).Result as NotFoundResult;
        _mockService.Verify(service => service.GetById(42), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
    }

    [Fact]
    public async Task GetByIdWhenEntityExistsReturnsEntityAnd200()
    {
        _mockService.Setup(service => service.GetById(It.IsAny<int>())).Returns(Task.FromResult(new Identified()
        {
            ID = 42,
        }));
        var result = (await _controller.GetById(42)).Result as OkObjectResult;
        _mockService.Verify(service => service.GetById(42), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        var item = result.Value as Identified;
        Assert.NotNull(item);
        Assert.Equal(42, item.ID);
    }

    [Fact]
    public async Task InsertReturnsEntityAnd201()
    {
        _mockService.Setup(service => service.Insert(It.IsAny<Identified>())).Returns(Task.FromResult(new Identified() { ID = 42 }));
        Identified? item = new Identified() { ID = 42 };
        var result = (await _controller.Insert(item)).Result as CreatedAtActionResult;
        _mockService.Verify(service => service.Insert(item), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.Created, result.StatusCode);
        item = result.Value as Identified;
        Assert.NotNull(item);
        Assert.Equal(42, item.ID);
    }

    [Fact]
    public async Task PutWhenEntityDoesNotExistReturns404()
    {
        _mockService.Setup(service => service.Update(It.IsAny<Identified>())).Throws<ResourceNotFoundException>();
        Identified? item = new Identified();
        var result = (await _controller.Put(42, item)).Result as NotFoundResult;
        _mockService.Verify(service => service.Update(item), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
    }

    [Fact]
    public async Task PutWhenEntityExistsReturnsUpdatedEntityAnd200()
    {
        _mockService.Setup(service => service.Update(It.IsAny<Identified>())).Returns(Task.FromResult(new Identified { ID = 42 }));
        Identified? item = new Identified();
        var result = (await _controller.Put(42, item)).Result as OkObjectResult;
        _mockService.Verify(service => service.Update(item), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        item = result.Value as Identified;
        Assert.NotNull(item);
        Assert.Equal(42, item.ID);
    }

    [Fact]
    public async Task DeleteByIdWhenEntityDoesNotExistReturns404()
    {
        _mockService.Setup(service => service.DeleteById(It.IsAny<int>())).Throws<ResourceNotFoundException>();
        var result = (await _controller.DeleteById(42)).Result as NotFoundResult;
        _mockService.Verify(service => service.DeleteById(42), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
    }

    [Fact]
    public async Task DeleteByIdWhenEntityExistsReturnsEntityAnd200()
    {
        _mockService.Setup(service => service.DeleteById(It.IsAny<int>())).Returns(Task.FromResult(new Identified() { ID = 42 }));
        var result = (await _controller.DeleteById(42)).Result as OkObjectResult;
        _mockService.Verify(service => service.DeleteById(42), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        var item = result.Value as Identified;
        Assert.NotNull(item);
        Assert.Equal(42, item.ID);
    }

    [Fact]
    public async Task DeleteAllWhenNoEntityExistsReturnsEmptyListAnd200()
    {
        _mockService.Setup(service => service.DeleteAll()).Returns(Task.FromResult(new List<Identified>()));
        var result = (await _controller.DeleteAll()).Result as OkObjectResult;
        _mockService.Verify(service => service.DeleteAll(), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        var list = result.Value as List<Identified>;
        Assert.NotNull(list);
        Assert.Empty(list);
    }


    [Fact]
    public async Task DeleteAllWhenEntityExistReturnsListAnd200()
    {
        _mockService.Setup(service => service.DeleteAll()).Returns(Task.FromResult(new List<Identified>() {
            new Identified(),
            new Identified(),
            new Identified(),
        }));
        var result = (await _controller.DeleteAll()).Result as OkObjectResult;
        _mockService.Verify(service => service.DeleteAll(), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        var list = result.Value as List<Identified>;
        Assert.NotNull(list);
        Assert.Equal(3, list.Count);
    }

}