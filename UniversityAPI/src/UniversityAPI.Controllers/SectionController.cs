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
    {try
    {
        
            return _sectionService.GetById(id);
    }
    catch (System.Exception)
    {
        
        throw;
    }
    }

    [HttpGet("")]
    public List<Section> GetAll()
    {try
    {
        
            return _sectionService.GetAll();
    }
    catch (System.Exception)
    {
        
        throw;
    }
    }

    [HttpPost("")]
    public Section? Insert(Section item)
    {try
    {
        
            return _sectionService.Insert(item);
    }
    catch (System.Exception)
    {
        
        throw;
    }
    }

    [HttpPatch("{id}")]
    public Section? Patch([FromBody] Section item)
    {try
    {
        
            return _sectionService.Update(item);
    }
    catch (System.Exception)
    {
        
        throw;
    }
    }

    [HttpDelete("{id}")]
    public Section? DeleteById([FromRoute] int id)
    {try
    {
        
            return _sectionService.DeleteById(id);
    }
    catch (System.Exception)
    {
        
        throw;
    }
    }

    [HttpDelete("")]
    public List<Section> DeleteAll()
    {
        return _sectionService.DeleteAll();
    }

}
