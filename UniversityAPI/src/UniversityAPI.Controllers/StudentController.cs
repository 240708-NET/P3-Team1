namespace UniversityAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Net;

using UniversityAPI.Models;


[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{

    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public int Test()
    {
        return 42;
    }

    [HttpPost("login")]
    public Student? Login([FromBody] Student student)
    {
        Student s = new Student
        {
            ID = 123,
            FirstName = "first",
            LastName = "last",
        };

        if (s.Equals(student))
        {
            return student;
        }
        else
        {
            Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return null;
        }
    }

}
