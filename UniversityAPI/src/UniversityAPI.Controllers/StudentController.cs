namespace UniversityAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

using UniversityAPI.Models;
using UniversityAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class StudentController : Controller<Student>
{


    public StudentController(IStudentServices studentServices) : base(studentServices) { }

    [HttpPost("register")]
    public Student? Register([FromBody] Student student)
    {
        return ((IStudentServices)_service).Register(student);
    }

    [HttpPost("login")]
    public Student? Login([FromBody] Student student)
    {
        Student? s = ((IStudentServices)_service)..Login(student);

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
