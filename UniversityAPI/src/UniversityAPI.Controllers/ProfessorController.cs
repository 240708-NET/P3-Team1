namespace UniversityAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

using UniversityAPI.Models;
using UniversityAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class ProfessorController : ControllerBase, IController<Professor>
{

    private readonly IProfessorServices _professorService;

    public ProfessorController(IProfessorServices professorService)
    {
        _professorService = professorService;
    }

    [HttpGet("{id}")]
    public Professor? GetById([FromRoute] int id)
    {
        return _professorService.GetById(id);
    }


    [HttpGet("")]
    public List<Professor> GetAll()
    {
        return _professorService.GetAll();
    }

    [HttpPatch("{id}")]
    public Professor? Patch([FromBody] Professor item)
    {
        return _professorService.Update(item);
    }

    [HttpDelete("{id}")]
    public Professor? DeleteById([FromRoute] int id)
    {
        return _professorService.DeleteById(id);
    }

    [HttpDelete("")]
    public List<Professor> DeleteAll()
    {
        return _professorService.DeleteAll();
    }

    [HttpPost("register")]
    public Professor? Register([FromBody] Professor professor)
    {
        return _professorService.Register(professor);
    }

    [HttpPost("login")]
    public Professor? Login([FromBody] Professor professor)
    {
        Professor? s = _professorService.Login(professor);

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
