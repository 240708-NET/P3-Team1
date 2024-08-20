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
        try
        {
            return _professorService.GetById(id);
        }
        catch (System.Exception)
        {
            Response.StatusCode = 500;
            return null;
        }
    }


    [HttpGet("")]
    public List<Professor> GetAll()
    {
        try
        {
            return _professorService.GetAll();
        }
        catch (System.Exception)
        {
            Response.StatusCode = 500;
            return new List<Professor>();
        }
    }

    [HttpPost("")]
    public Professor? Insert(Professor item)
    {
        try
        {
            return _professorService.Insert(item);
        }
        catch (System.Exception)
        {

            Response.StatusCode = 500;
            return null;
        }
    }

    [HttpPatch("{id}")]
    public Professor? Patch([FromBody] Professor item)
    {
        try
        {
            return _professorService.Update(item);
        }
        catch (System.Exception)
        {

            Response.StatusCode = 500;
            return null;
        }
    }

    [HttpDelete("{id}")]
    public Professor? DeleteById([FromRoute] int id)
    {
        try
        {
            return _professorService.DeleteById(id);
        }
        catch (System.Exception)
        {

            Response.StatusCode = 500;
            return null;
        }
    }

    [HttpDelete("")]
    public List<Professor> DeleteAll()
    {
        try
        {
            return _professorService.DeleteAll();
        }
        catch (System.Exception)
        {

            Response.StatusCode = 500;
            return new List<Professor>();
        }
    }

    [HttpPost("register")]
    public Professor? Register([FromBody] Professor professor)
    {
        try
        {
            return _professorService.Register(professor);
        }
        catch (System.Exception)
        {

            Response.StatusCode = 500;
            return null;
        }
    }

    [HttpPost("login")]
    public Professor? Login([FromBody] Professor professor)
    {
        try
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
        catch (System.Exception)
        {
            Response.StatusCode = 500;
            return null;
        }
    }

}
