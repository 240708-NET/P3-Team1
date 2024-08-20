namespace UniversityAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Net;

using UniversityAPI.Models;
using UniversityAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase, IController<Course>
{

    private readonly ICourseServices _courseService;

    public CourseController(ICourseServices courseService)
    {
        _courseService = courseService;
    }

    [HttpGet("{id}")]
    public Course? GetById([FromRoute] int id)
    {
        try
        {
            return _courseService.GetById(id);
        }
        catch (System.Exception)
        {
            Response.StatusCode = 500;
            return null;
        }
    }

    [HttpGet("")]
    public List<Course> GetAll()
    {
        try
        {
            return _courseService.GetAll();
        }
        catch (System.Exception)
        {
            Response.StatusCode = 500;
            return new List<Course>();
        }
    }

    [HttpPost("")]
    public Course? Insert(Course item)
    {
        try
        {
            return _courseService.Insert(item);
        }
        catch (System.Exception)
        {
            Response.StatusCode = 500;
            return null;
        }
    }

    [HttpPatch("{id}")]
    public Course? Patch([FromBody] Course item)
    {
        try
        {
            return _courseService.Update(item);
        }
        catch (System.Exception)
        {
            Response.StatusCode = 500;
            return null;
        }
    }

    [HttpDelete("{id}")]
    public Course? DeleteById([FromRoute] int id)
    {
        try
        {
            return _courseService.DeleteById(id);
        }
        catch (System.Exception)
        {
            Response.StatusCode = 500;
            return null;
        }
    }

    [HttpDelete("")]
    public List<Course> DeleteAll()
    {
        try
        {
            return _courseService.DeleteAll();
        }
        catch (System.Exception)
        {
            Response.StatusCode = 500;
            return new List<Course>();
        }
    }
}
