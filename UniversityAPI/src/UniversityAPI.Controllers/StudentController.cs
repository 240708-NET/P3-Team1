namespace UniversityAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using UniversityAPI.Models;
using UniversityAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class StudentController : Controller<Student>
{

    public StudentController(IStudentServices studentServices) : base(studentServices) { }

    /// <summary>
    /// Registers a new student.
    /// The only fields that will be read from the student object are <code>firstName</code>, <code>lastName</code>, and <code>password</code>.
    /// All other fields will be ignored.
    /// </summary>
    /// <param name="student">The student to register.</param>
    /// <returns>A <see cref="ActionResult{Student}"/> containing the registered student.</returns>
    /// <response code="201">The student was registered successfully.</response>
    /// <response code="500">An error occurred during registration.</response>
    [HttpPost("register")]
    public async Task<ActionResult<Student>> Register([FromBody] Student student)
    {
        try
        {
            Student registeredStudent = await ((IStudentServices)_service).Register(student);
            return CreatedAtAction("Register", registeredStudent);
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }

    /// <summary>
    /// Logs in a student.
    /// The only fields that will be read from the student object are <code>Id</code> and <code>password</code>.
    /// All other fields will be ignored.
    /// </summary>
    /// <param name="student">The student to log in.</param>
    /// <returns>A <see cref="ActionResult{Student}"/> containing the logged-in student.</returns>
    /// <response code="200">The student was logged in successfully.</response>
    /// <response code="401">The student was not found or the password was incorrect.</response>
    /// <response code="500">An error occurred during login.</response>
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

    /// <summary>
    /// Retrieves the sections registered by a student.
    /// </summary>
    /// <param name="studentId">The ID of the student.</param>
    /// <returns>A <see cref="ActionResult{IEnumerable{Section}}"/> containing the registered sections.</returns>
    /// <response code="200">The registered sections were retrieved successfully.</response>
    /// <response code="404">The student was not found.</response>
    /// <response code="500">An error occurred during retrieval.</response>
    [HttpGet("{studentId}/section")]
    public async Task<ActionResult<List<Section>>> GetRegisteredSections([FromRoute] int studentId)
    {
        try
        {
            return Ok(await ((IStudentServices)_service).GetRegisteredSections(studentId));
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

    /// <summary>
    /// Adds a section to a student's registration.
    /// </summary>
    /// <param name="id">The ID of the student.</param>
    /// <param name="sectionId">The ID of the section to add.</param>
    /// <returns>A <see cref="ActionResult{Student}"/> containing the updated student.</returns>
    /// <response code="200">The section was added successfully.</response>
    /// <response code="404">The student or section was not found.</response>
    /// <response code="409">The student is already registered for the section.</response>
    /// <response code="500">An error occurred during addition.</response>
    [HttpPost("{studentId}/section")]
    public async Task<ActionResult<Student>> AddSectionToStudent([FromRoute] int studentId, [FromBody] int sectionId)
    {
        try
        {
            return Ok(await ((IStudentServices)_service).AddSectionToStudent(studentId, sectionId));
        }
        catch(SectionOverlapException)
        {
            return StatusCode(409);
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

    /// <summary>
    /// Removes a section from a student's registration.
    /// </summary>
    /// <param name="studentId">The ID of the student.</param>
    /// <param name="sectionId">The ID of the section to remove.</param>
    /// <returns>A <see cref="ActionResult{Student}"/> containing the updated student.</returns>
    /// <response code="200">The section was removed successfully.</response>
    /// <response code="404">The student or section was not found.</response>
    /// <response code="500">An error occurred during removal.</response>
    [HttpDelete("{studentId}/section/{sectionId}")]
    public async Task<ActionResult<Student>> DeleteSectionFromStudent([FromRoute] int studentId, [FromRoute] int sectionId)
    {
        try
        {
            var result = await ((IStudentServices)_service).DeleteSectionFromStudent(studentId, sectionId);
            if (result == null) return NotFound();
            return Ok(result);
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
