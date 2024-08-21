using Moq;

using UniversityAPI.Services;
using UniversityAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;

namespace UniversityAPI.Controllers.Tests;

public class ControllerTests
{

    private readonly Mock<IService<IIdentified>> _mockService;
    private readonly Controller<IIdentified> _controller;

    public ControllerTests()
    {
        _mockService = new Mock<IService<IIdentified>>();
        _controller = new Controller<IIdentified>(_mockService.Object);
    }

    [Fact]
    public void GetAllWhenNoEntityExistsReturnsEmptyListAnd200()
    {
        _mockService.Setup(service => service.GetAll()).Returns(new List<IIdentified>() { });
        var result = _controller.GetAll().Result as OkObjectResult;
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        var list = result.Value as List<IIdentified>;
        Assert.NotNull(list);
        Assert.Empty(list);
    }

    
    [Fact]
    public void GetAllWhenEntityExistReturnsListAnd200()
    {
        _mockService.Setup(service => service.GetAll()).Returns(new List<IIdentified>() { 
            new Student(),
            new Student(),
            new Student(),
        });
        var result = _controller.GetAll().Result as OkObjectResult;
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        var list = result.Value as List<IIdentified>;
        Assert.NotNull(list);
        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void GetByIdWhenEntityDoesNotExistReturns500(){
        _mockService.Setup(service => service.GetById(It.IsAny<int>())).Throws<Exception>();
        var result = _controller.GetById(42).Result as IStatusCodeActionResult;
        Assert.NotNull(result);
        Assert.Equal(500, result.StatusCode);
    }
}