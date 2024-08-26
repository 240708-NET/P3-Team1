using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Models;
using UniversityAPI.Services;

namespace UniversityAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class Controller<T> : ControllerBase where T : Identified
{
    protected readonly IService<T> _service;

    public Controller(IService<T> service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<T>>> GetById(int id)
    {
        try
        {
            return Ok(await _service.GetById(id));
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


    [HttpGet("")]
    public async Task<ActionResult<List<T>>> GetAll()
    {
        try
        {
            return Ok(await _service.GetAll());
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }


    [HttpPost("")]
    public async Task<ActionResult<T>> Insert(T item)
    {
        try
        {
            Console.WriteLine(item is Student);
            T createdItem = await _service.Insert(item);
            string requestPath = Request != null ? $"{Request.Path}/{createdItem.ID}" : "/api";
            Console.WriteLine(requestPath);
            return CreatedAtAction(new Uri(requestPath).ToString(), createdItem);
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<T>> Put([FromRoute] int id, [FromBody] T item)
    {
        try
        {
            item.ID = id;
            return Ok(await _service.Update(item));
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

    [HttpDelete("{id}")]
    public async Task<ActionResult<T>> DeleteById([FromRoute] int id)
    {
        try
        {
            return Ok(await _service.DeleteById(id));
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

    [HttpDelete("")]
    public async Task<ActionResult<List<T>>> DeleteAll()
    {
        try
        {
            return Ok(await _service.DeleteAll());
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }
}