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

    [HttpGet("{id}/student")]
    public ActionResult<List<Student>> GetRegisteredStudents([FromRoute] int id)
    {
        try
        {
            return Ok(((ISectionServices)_service).GetRegisteredSections(id));
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPost("{id}/student")]
    public ActionResult<Student> AddStudentToSection([FromRoute] int sectionId, [FromBody] int studentId)
    {
        try
        {
            return Ok(((ISectionServices)_service).AddSectionToStudent(sectionId, studentId));
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpDelete("{id}/student")]
    public ActionResult<Student> DeleteStudentFromSection([FromRoute] int sectionId, [FromBody] int studentId)
    {
        try
        {
            return Ok(((ISectionServices)_service).DeleteSectionFromStudent(sectionId, studentId));
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }
}
