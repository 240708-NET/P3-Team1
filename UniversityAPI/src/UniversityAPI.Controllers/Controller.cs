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


    /// <summary>
    /// Get an entity by its <code>id</code>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>200 with the entity in the body if id exists, 404 if id not found, 500 if any other exceptions</returns>
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

    /// <summary>
    /// Get all entities.
    /// </summary>
    /// <returns>200 with the entities in the body if successful, 500 if any other exceptions</returns>
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

    /// <summary>
    /// Insert a new entity.
    /// </summary>
    /// <param name="item">The entity to insert.</param>
    /// <returns>201 with the inserted entity in the body if successful, 500 if any other exceptions</returns>
    [HttpPost("")]
    public async Task<ActionResult<T>> Insert(T item)
    {
        try
        {
            T createdItem = await _service.Insert(item);
            return CreatedAtAction("Insert", createdItem);
        }
        catch (System.Exception)
        {
            return StatusCode(500);
        }
    }


        /// <summary>
        /// Update an existing entity.
        /// </summary>
        /// <param name="id">The id of the entity to update.</param>
        /// <param name="item">The entity to update.</param>
        /// <returns>200 with the updated entity in the body if successful, 404 if the entity doesn't exist, 500 if any other exceptions</returns>
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

    /// <summary>
    /// Delete an existing entity.
    /// </summary>
    /// <param name="id">The id of the entity to delete.</param>
    /// <returns>200 with the deleted entity in the body if successful, 404 if the entity doesn't exist, 500 if any other exceptions</returns>
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

    /// <summary>
    /// Delete all existing entities.
    /// </summary>
    /// <returns>200 with the deleted entities in the body if successful, 500 if any other exceptions</returns>
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