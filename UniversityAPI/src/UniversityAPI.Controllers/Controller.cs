using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Services;

namespace UniversityAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class Controller<T> : ControllerBase
{
    protected readonly IService<T> _service;

    public Controller(IService<T> service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public T? GetById(int id)
    {
        try
        {
            return _service.GetById(id);
        }
        catch (System.Exception)
        {
            Response.StatusCode = 500;
            return default(T);
        }
    }


    [HttpGet("")]
    public List<T> GetAll()
    {
        try
        {
            return _service.GetAll();
        }
        catch (System.Exception)
        {
            Response.StatusCode = 500;
            return new List<T>();
        }
    }


    [HttpPost("")]
    public T? Insert(T item)
    {
        try
        {
            return _service.Insert(item);
        }
        catch (System.Exception)
        {
            Response.StatusCode = 500;
            return default(T);
        }
    }

    [HttpPatch("{id}")]
    public T? Patch([FromBody] T item)
    {
        try
        {
            return _service.Update(item);
        }
        catch (System.Exception)
        {
            Response.StatusCode = 500;
            return default(T);
        }
    }

    [HttpDelete("{id}")]
    public T? DeleteById([FromRoute] int id)
    {
        try
        {
            return _service.DeleteById(id);
        }
        catch (System.Exception)
        {
            Response.StatusCode = 500;
            return default(T);
        }
    }

    [HttpDelete("")]
    public List<T> DeleteAll()
    {
        try
        {
            return _service.DeleteAll();
        }
        catch (System.Exception)
        {
            Response.StatusCode = 500;
            return new List<T>();
        }
    }
}