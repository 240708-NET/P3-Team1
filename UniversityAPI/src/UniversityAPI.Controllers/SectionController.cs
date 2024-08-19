namespace UniversityAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Net;

using UniversityAPI.Models;
using UniversityAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class SectionController : ControllerBase, IController<Section>
{
    private readonly ISectionServices _sectionService;

    public SectionController(ISectionServices studentServices)
    {
        _sectionService = studentServices;
    }

    [HttpGet("{id}")]
    public Section? GetById([FromRoute] int id)
    {
        return _sectionService.GetById(id);
    }

    [HttpGet("")]
    public List<Section> GetAll()
    {
        return _sectionService.GetAll();
    }

    [HttpPatch("{id}")]
    public Section? Patch([FromBody] Section item)
    {
        return _sectionService.Update(item);
    }

    [HttpDelete("{id}")]
    public Section? DeleteById([FromRoute] int id)
    {
        return _sectionService.DeleteById(id);
    }

    [HttpDelete("")]
    public List<Section> DeleteAll()
    {
        return _sectionService.DeleteAll();
    }

}
