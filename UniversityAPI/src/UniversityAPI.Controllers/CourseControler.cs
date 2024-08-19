namespace UniversityAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Net;

using UniversityAPI.Models;
using UniversityAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase, IController<Course>
{

    // private readonly ILogger<CourseController> _logger;
    private readonly ICourseServices _courseService;

    public CourseController(ILogger<CourseController> logger, ICourseServices courseService)
    {
        // _logger = logger;
        _courseService = courseService;
    }

    [HttpGet("{id}")]
    public Course? GetById([FromRoute] int id)
    {
        return _courseService.GetById(id);
    }

    [HttpGet("")]
    public List<Course> GetAll()
    {
        return _courseService.GetAll();
    }

    [HttpPatch("{id}")]
    public Course? Patch([FromBody] Course item)
    {
        return _courseService.Update(item);
    }

    [HttpDelete("{id}")]
    public Course? DeleteById([FromRoute] int id)
    {
        return _courseService.DeleteById(id);
    }

    [HttpDelete("")]
    public List<Course> DeleteAll()
    {
        return _courseService.DeleteAll();
    }

}
