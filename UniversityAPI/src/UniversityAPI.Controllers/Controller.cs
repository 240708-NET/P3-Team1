using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Models;
using UniversityAPI.Services;

namespace UniversityAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class Controller<T> : ControllerBase where T : IIdentified
{
    protected readonly IService<T> _service;

    public Controller(IService<T> service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public ActionResult<List<T>> GetById(int id)
    {
        try
        {
            return Ok(_service.GetById(id));
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }


    [HttpGet("")]
    public ActionResult<List<T>> GetAll()
    {
        try
        {
            return Ok(_service.GetAll());
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }


    [HttpPost("")]
    public ActionResult<T> Insert(T item)
    {
        try
        {
            T createdItem = _service.Insert(item);
            return CreatedAtAction(new Uri($"{Request.Path}/{createdItem.ID}").ToString(), createdItem);
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<T> Put([FromBody] T item)
    {
        try
        {
            return Ok(_service.Update(item));
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult<T> DeleteById([FromRoute] int id)
    {
        try
        {
            return Ok(_service.DeleteById(id));
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpDelete("")]
    public ActionResult<List<T>> DeleteAll()
    {
        try
        {
            return Ok(_service.DeleteAll());
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }
}