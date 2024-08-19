namespace UniversityAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

using UniversityAPI.Models;
using UniversityAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase, IController<Student>
{

    private readonly ILogger<StudentController> _logger;
    private readonly IStudentServices _studentService;

    public StudentController(ILogger<StudentController> logger, IStudentServices studentServices)
    {
        _logger = logger;
        _studentService = studentServices;
    }

    [HttpGet("{id}")]
    public Student? GetById([FromRoute] int id)
    {
        return _studentService.GetById(id);
    }


    [HttpGet("")]
    public List<Student> GetAll()
    {
        return _studentService.GetAll();
    }

    [HttpPatch("{id}")]
    public Student? Patch([FromBody] Student item)
    {
        return _studentService.Update(item);
    }

    [HttpDelete("{id}")]
    public Student? DeleteById([FromRoute] int id)
    {
        return _studentService.DeleteById(id);
    }

    [HttpDelete("")]
    public List<Student> DeleteAll()
    {
        return _studentService.DeleteAll();
    }

    [HttpPost("register")]
    public Student? Register([FromBody] Student student)
    {
        return _studentService.Register(student);
    }

    [HttpPost("login")]
    public Student? Login([FromBody] Student student)
    {
        Student? s = _studentService.Login(student);

        if (s == null)
        {
            Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return null;
        }
        else
        {
            return s;
        }
    }

    [HttpGet("{id}/sections")]
    public List<Section> GetRegisteredSections([FromRoute] int id)
    {
        return _studentService.GetRegisteredSections(id);
    }

    // add section
    // [Http]

    // remove section

}
