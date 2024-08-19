namespace UniversityAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Net;

using UniversityAPI.Models;
using UniversityAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{

    private readonly ILogger<StudentController> _logger;
    private readonly IStudentServices _studentService;

    public StudentController(ILogger<StudentController> logger, IStudentServices studentServices)
    {
        _logger = logger;
        _studentService = studentServices;
    }

    [HttpGet]
    public int Test()
    {
        return 42;
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

}
