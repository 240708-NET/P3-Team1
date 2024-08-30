namespace UniversityAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Net;

using UniversityAPI.Models;
using UniversityAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class SectionController : Controller<Section>
{
    public SectionController(ISectionServices sectionServices) : base(sectionServices) { }

    /// <summary>
    /// Retrieves the students registered for a section.
    /// </summary>
    /// <param name="sectionId">The ID of the section.</param>
    /// <returns>A <see cref="ActionResult{IEnumerable{Student}}"/> containing the registered students.</returns>
    /// <response code="200">The registered students were retrieved successfully.</response>
    /// <response code="404">The section was not found.</response>
    /// <response code="500">An error occurred during retrieval.</response>
    [HttpGet("{sectionId}/student")]
    public async Task<ActionResult<List<Student>>> GetRegisteredStudents([FromRoute] int sectionId)
    {
        try
        {
            return Ok(await ((ISectionServices)_service).GetRegisteredStudents(sectionId));
        }
        catch (SectionNotFoundException)
        {
            return NotFound();
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }
    
    /// <summary>
    /// Adds a student to a section.
    /// </summary>
    /// <param name="sectionId">The ID of the section.</param>
    /// <param name="studentId">The ID of the student to add.</param>
    /// <returns>A <see cref="ActionResult{Student}"/> containing the added student.</returns>
    /// <response code="200">The student was added successfully.</response>
    /// <response code="404">The section or student was not found.</response>
    /// <response code="409">The student is already registered for the section.</response>
    /// <response code="500">An error occurred during addition.</response>
    [HttpPost("{sectionId}/student")]
    public async Task<ActionResult<Student>> AddStudentToSection([FromRoute] int sectionId, [FromBody] int studentId)
    {
        try
        {
            return Ok(await ((ISectionServices)_service).AddStudentToSection(sectionId, studentId));
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
    /// Removes a student from a section.
    /// </summary>
    /// <param name="sectionId">The ID of the section.</param>
    /// <param name="studentId">The ID of the student to remove.</param>
    /// <returns>A <see cref="ActionResult{Student}"/> containing the removed student.</returns>
    /// <response code="200">The student was removed successfully.</response>
    /// <response code="404">The section or student was not found.</response>
    /// <response code="500">An error occurred during removal.</response>
    [HttpDelete("{sectionId}/student")]
    public async Task<ActionResult<Student>> DeleteStudentFromSection([FromRoute] int sectionId, [FromBody] int studentId)
    {
        try
        {
            return Ok(await ((ISectionServices)_service).DeleteStudentFromSection(sectionId, studentId));
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
