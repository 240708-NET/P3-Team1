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
    public async Task<ActionResult<Student>> Register([FromBody] Student student)
    {
        try
        {
            Student registeredStudent = await ((IStudentServices)_service).Register(student);
            string requestPath = Request != null ? $"{Request.Path}/{registeredStudent.ID}" : "/api";
            return CreatedAtAction(new Uri(requestPath).ToString(), registeredStudent);
        }
        catch (RegistrationFailedException)
        {
            return StatusCode(500);
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult<Student>> Login([FromBody] Student student)
    {

        try
        {
            return Ok(await ((IStudentServices)_service).Login(student));
        }
        catch (StudentNotFoundException)
        {
            return Unauthorized();
        }
        catch (InvalidLoginException)
        {
            return Unauthorized();
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("{studentId}/section")]
    public async Task<ActionResult<List<Section>>> GetRegisteredSections([FromRoute] int id)
    {
        try
        {
            return Ok(await ((IStudentServices)_service).GetRegisteredSections(id));
        }
        catch (StudentNotFoundException)
        {
            return NotFound();
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPost("{studentId}/section")]
    public async Task<ActionResult<Student>> AddSectionToStudent([FromRoute] int studentId, [FromBody] int sectionId)
    {
        try
        {
            return Ok(await ((IStudentServices)_service).AddSectionToStudent(studentId, sectionId));
        }
        catch (ResourceNotFoundException)
        {
            return NotFound();
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpDelete("{studentId}/section")]
    public async Task<ActionResult<Student>> DeleteSectionFromStudent([FromRoute] int studentId, [FromBody] int sectionId)
    {
        try
        {
            return Ok(await ((IStudentServices)_service).DeleteSectionFromStudent(studentId, sectionId));
        }
        catch (ResourceNotFoundException)
        {
            return NotFound();
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }


}
