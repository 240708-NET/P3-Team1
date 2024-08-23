using Moq;

using UniversityAPI.Services;
using UniversityAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Xunit;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;

namespace UniversityAPI.Controllers.Tests;

public class SectionControllerTests
{

    private readonly Mock<ISectionServices> _mockService;
    private readonly SectionController _controller;

    public SectionControllerTests()
    {
        _mockService = new Mock<ISectionServices>();
        _controller = new SectionController(_mockService.Object);
    }

    [Fact]
    public async Task GetRegisteredStudentsWhenSectionDoesNotExistReturns404()
    {
        _mockService.Setup(service => service.GetRegisteredStudents(It.IsAny<int>())).Throws<SectionNotFoundException>();
        var result = (await _controller.GetRegisteredStudents(42)).Result as NotFoundResult;
        _mockService.Verify(service => service.GetRegisteredStudents(42), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
    }

    [Fact]
    public async Task GetRegisteredStudentsWhenSectionExistsReturnsListAnd200()
    {
        _mockService.Setup(service => service.GetRegisteredStudents(It.IsAny<int>())).Returns(Task.FromResult(new List<Student>()));
        var result = (await _controller.GetRegisteredStudents(42)).Result as OkObjectResult;
        _mockService.Verify(service => service.GetRegisteredStudents(42), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        Assert.NotNull(result.Value);
        Assert.True(result.Value is List<Student>);
    }

    [Fact]
    public async Task AddSectionToStudentWhenStudentOrSectionDoesNotExistReturns404()
    {
        _mockService.Setup(service => service.AddStudentToSection(It.IsAny<int>(), It.IsAny<int>())).Throws<ResourceNotFoundException>();
        var result = (await _controller.AddStudentToSection(42, 42)).Result as NotFoundResult;
        _mockService.Verify(service => service.AddStudentToSection(42, 42), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
    }

    [Fact]
    public async Task AddSectionToStudentWhenStudentAndSectionExistsReturnsStudentAnd200()
    {
        _mockService.Setup(service => service.AddStudentToSection(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(new Section()));
        var result = (await _controller.AddStudentToSection(42, 42)).Result as OkObjectResult;
        _mockService.Verify(service => service.AddStudentToSection(42, 42), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        Assert.NotNull(result.Value);
        Assert.True(result.Value is Section);
    }

    [Fact]
    public async Task DeleteSectionFromStudentWhenStudentOrSectionDoesNotExistReturns404()
    {
        _mockService.Setup(service => service.DeleteStudentFromSection(It.IsAny<int>(), It.IsAny<int>())).Throws<ResourceNotFoundException>();
        var result = (await _controller.DeleteStudentFromSection(42, 42)).Result as NotFoundResult;
        _mockService.Verify(service => service.DeleteStudentFromSection(42, 42), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
    }

    [Fact]
    public async Task DeleteSectionFromStudentWhenStudentAndSectionExistsReturnsStudentAnd200()
    {
        _mockService.Setup(service => service.DeleteStudentFromSection(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(new Section()));
        var result = (await _controller.DeleteStudentFromSection(42, 42)).Result as OkObjectResult;
        _mockService.Verify(service => service.DeleteStudentFromSection(42, 42), Times.Once());
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        Assert.NotNull(result.Value);
        Assert.True(result.Value is Section);
    }

}