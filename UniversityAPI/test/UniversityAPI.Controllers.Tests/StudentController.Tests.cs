using Moq;

using UniversityAPI.Services;
using UniversityAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Xunit;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;

namespace UniversityAPI.Controllers.Tests;

public class StudentControllerTests
{

    private readonly Mock<IStudentServices> _mockService;
    private readonly StudentController _controller;

    public StudentControllerTests()
    {
        _mockService = new Mock<IStudentServices>();
        _controller = new StudentController(_mockService.Object);
    }

    [Fact]
    public async Task RegisterReturnsStudentAnd201()
    {
        Student s = new Student();
        _mockService.Setup(service => service.Register(It.IsAny<Student>())).Returns(Task.FromResult(s));
        var result = (await _controller.Register(s)).Result as CreatedAtActionResult;
        _mockService.Verify(service => service.Register(s), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.Created, result.StatusCode);
        Assert.NotNull(result.Value);
        Assert.True(result.Value is Student);
    }

    [Fact]
    public async Task RegisterWhenErrorReturns500()
    {
        _mockService.Setup(service => service.Register(It.IsAny<Student>())).Throws<Exception>();
        Student? student = new Student() {};
        var result = (await _controller.Register(student)).Result as StatusCodeResult;
        _mockService.Verify(service => service.Register(student), Times.Once());
        Assert.NotNull(result);
        Assert.Equal(500, result.StatusCode);
    }

    [Fact]
    public async Task LoginWhenUserDoesNotExistReturns404()
    {
        Student s = new Student();
        _mockService.Setup(service => service.Login(s)).Throws<StudentNotFoundException>();
        var result = (await _controller.Login(s)).Result as UnauthorizedResult;
        _mockService.Verify(service => service.Login(s), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.Unauthorized, result.StatusCode);
    }

    [Fact]
    public async Task LoginWhenPasswordIncorrectReturns404()
    {
        Student s = new Student();
        _mockService.Setup(service => service.Login(s)).Throws<InvalidLoginException>();
        var result = (await _controller.Login(s)).Result as UnauthorizedResult;
        _mockService.Verify(service => service.Login(s), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.Unauthorized, result.StatusCode);
    }

    [Fact]
    public async Task LoginWhenSuccessfulReturnsStudentAnd200()
    {
        Student s = new Student();
        _mockService.Setup(service => service.Login(s)).Returns(Task.FromResult(s));
        var result = (await _controller.Login(s)).Result as OkObjectResult;
        _mockService.Verify(service => service.Login(s), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        Assert.NotNull(result.Value);
        Assert.True(result.Value is Student);
    }

    [Fact]
    public async Task LoginWhenErrorReturns500()
    {
        _mockService.Setup(service => service.Login(It.IsAny<Student>())).Throws<Exception>();
        Student? student = new Student() {};
        var result = (await _controller.Login(student)).Result as StatusCodeResult;
        _mockService.Verify(service => service.Login(student), Times.Once());
        Assert.NotNull(result);
        Assert.Equal(500, result.StatusCode);
    }

    [Fact]
    public async Task GetRegisteredSectionsWhenStudentDoesNotExistReturns404()
    {
        _mockService.Setup(service => service.GetRegisteredSections(It.IsAny<int>())).Throws<StudentNotFoundException>();
        var result = (await _controller.GetRegisteredSections(42)).Result as NotFoundResult;
        _mockService.Verify(service => service.GetRegisteredSections(42), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
    }

    [Fact]
    public async Task GetRegisteredSectionsWhenStudentExistsReturnsListAnd200()
    {
        _mockService.Setup(service => service.GetRegisteredSections(It.IsAny<int>())).Returns(Task.FromResult(new List<Section>()));
        var result = (await _controller.GetRegisteredSections(42)).Result as OkObjectResult;
        _mockService.Verify(service => service.GetRegisteredSections(42), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        Assert.NotNull(result.Value);
        Assert.True(result.Value is List<Section>);
    }

    [Fact]
    public async Task GetRegisteredSectionsWhenErrorReturns500()
    {
        _mockService.Setup(service => service.GetRegisteredSections(It.IsAny<int>())).Throws<Exception>();
        var result = (await _controller.GetRegisteredSections(42)).Result as StatusCodeResult;
        _mockService.Verify(service => service.GetRegisteredSections(42), Times.Once());
        Assert.NotNull(result);
        Assert.Equal(500, result.StatusCode);
    }

    [Fact]
    public async Task AddSectionToStudentWhenStudentOrSectionDoesNotExistReturns404()
    {
        _mockService.Setup(service => service.AddSectionToStudent(It.IsAny<int>(), It.IsAny<int>())).Throws<ResourceNotFoundException>();
        var result = (await _controller.AddSectionToStudent(42, 42)).Result as NotFoundResult;
        _mockService.Verify(service => service.AddSectionToStudent(42, 42), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
    }

    [Fact]
    public async Task AddSectionToStudentWhenStudentAndSectionExistsReturnsStudentAnd200()
    {
        _mockService.Setup(service => service.AddSectionToStudent(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(new Student()));
        var result = (await _controller.AddSectionToStudent(42, 42)).Result as OkObjectResult;
        _mockService.Verify(service => service.AddSectionToStudent(42, 42), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        Assert.NotNull(result.Value);
        Assert.True(result.Value is Student);
    }

    [Fact]
    public async Task AddSectionToStudentWhenErrorReturns500()
    {
        _mockService.Setup(service => service.AddSectionToStudent(It.IsAny<int>(), It.IsAny<int>())).Throws<Exception>();
        var result = (await _controller.AddSectionToStudent(42,42)).Result as StatusCodeResult;
        _mockService.Verify(service => service.AddSectionToStudent(42,42), Times.Once());
        Assert.NotNull(result);
        Assert.Equal(500, result.StatusCode);
    }

    [Fact]
    public async Task DeleteSectionFromStudentWhenStudentOrSectionDoesNotExistReturns404()
    {
        _mockService.Setup(service => service.DeleteSectionFromStudent(It.IsAny<int>(), It.IsAny<int>())).Throws<ResourceNotFoundException>();
        var result = (await _controller.DeleteSectionFromStudent(42, 42)).Result as NotFoundResult;
        _mockService.Verify(service => service.DeleteSectionFromStudent(42, 42), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
    }

    [Fact]
    public async Task DeleteSectionFromStudentWhenStudentAndSectionExistsReturnsStudentAnd200()
    {
        _mockService.Setup(service => service.DeleteSectionFromStudent(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(new Student()));
        var result = (await _controller.DeleteSectionFromStudent(42, 42)).Result as OkObjectResult;
        _mockService.Verify(service => service.DeleteSectionFromStudent(42, 42), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        Assert.NotNull(result.Value);
        Assert.True(result.Value is Student);
    }

    [Fact]
    public async Task DeleteSectionFromStudentWhenErrorReturns500()
    {
        _mockService.Setup(service => service.DeleteSectionFromStudent(It.IsAny<int>(), It.IsAny<int>())).Throws<Exception>();
        var result = (await _controller.DeleteSectionFromStudent(42,42)).Result as StatusCodeResult;
        _mockService.Verify(service => service.DeleteSectionFromStudent(42,42), Times.Once());
        Assert.NotNull(result);
        Assert.Equal(500, result.StatusCode);
    }
}