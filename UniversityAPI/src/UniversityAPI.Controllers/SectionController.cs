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

    [HttpGet("{sectionId}/student")]
    public async Task<ActionResult<List<Student>>> GetRegisteredStudents([FromRoute] int id)
    {
        try
        {
            return Ok(await ((ISectionServices)_service).GetRegisteredStudents(id));
        }
        catch (SectionNotFoundException)
        {
            return NotFound();
        }
        catch (RepositoryException)
        {
            return StatusCode(500);
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }

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
